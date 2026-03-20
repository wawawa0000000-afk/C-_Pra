using System;

public class HPbar
{
  public static void Main()
  {
    float maxHp = 100f;
    int barMaxCount = 10; // バーの最大文字数

    // テスト用のダメージ値（HPが0未満になる超過ダメージもテストに追加）
    float[] testDams = { 0, 1, 9, 10, 11, 50, 95, 99, 100, 120 };

    foreach (float dam in testDams)
    {
      float currentHp = maxHp - dam;
      Console.WriteLine($"\n--- ダメージ: {dam} ---");
      
      // 直接書き込まず、文字列として受け取ってから表示する
      string hpBarText = GenerateHpBarString(currentHp, maxHp, barMaxCount);
      Console.WriteLine(hpBarText);
    }
  }

  /// <summary>
  /// HPバーの文字列表現を生成します。
  /// </summary>
  public static string GenerateHpBarString(float current, float max, int maxBar, char fillChar = '■', char emptyChar = '□')
  {
    // 【可用性・信頼性】最大HPが0以下の場合のエラー（ゼロ除算）を防ぐガード処理
    if (max <= 0)
    {
      return $"HP:{current,3} []";
    }

    int fillCount;

    if (current >= max)
    {
      fillCount = maxBar; // 満タン
    }
    else if (current <= 0)
    {
      fillCount = 0; // 0以下
    }
    else
    {
      // 割合を計算（「少しでも削れたら1減る」「0より大きければ1残る」仕様）
      int calculated = (int)Math.Floor((current / max) * maxBar);
      fillCount = Math.Clamp(calculated, 1, maxBar - 1);
    }

    // 【効率性】forループを使わず、new string() で指定した文字数の文字列を一括生成する
    string filledStr = new string(fillChar, fillCount);
    string emptyStr = new string(emptyChar, maxBar - fillCount);

    // 【拡張性】Consoleに依存せず文字列を返すことで、UIテキスト等あらゆる場所で使い回せるようにする
    return $"HP:{current,3} [{filledStr}{emptyStr}]";
  }
}

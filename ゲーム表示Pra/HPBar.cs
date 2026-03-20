/*
using System;

public class HPbar
{
  public static void OldMain()
  {
    float maxHp = 100f;
    int barMaxCount = 10; // バーの最大文字数

    // テスト用のダメージ値
    float[] testDams = { 0, 1, 9, 10, 11, 50, 95, 99, 100 };

    foreach (float dam in testDams)
    {
      float currentHp = maxHp - dam;
      Console.WriteLine($"\n--- ダメージ: {dam} ---");
      PrintHpBar(currentHp, maxHp, barMaxCount);
    }
  }

  public static void PrintHpBar(float current, float max, int maxBar)
  {
    int fillCount;

    if (current >= max)
    {
      // 満タンならフル表示
      fillCount = maxBar;
    }
    else if (current <= 0)
    {
      // 0以下なら表示なし
      fillCount = 0;
    }
    else
    {
      // 割合を計算して切り捨て、かつ「最低でも1、最高でも最大数-1」に収める
      // これで「少しでも削れたら1減る」かつ「0より大きければ1残る」が実現します
      int calculated = (int)Math.Floor((current / max) * maxBar);
      fillCount = Math.Clamp(calculated, 1, maxBar - 1);
    }

    // 描画処理
    Console.Write($"HP:{current,3} [");
    for (int i = 0; i < fillCount; i++) Console.Write("*");
    for (int i = 0; i < (maxBar - fillCount); i++) Console.Write("-");
    Console.WriteLine("]");
  }
}
*/



/*public class HPbar
{
  public static void Main()
  {
    int barFlg = 0;

    float hp = 100.0f;
    Console.WriteLine($"HP:{hp}");

    int dam = 95;
    Console.WriteLine($"Dam:{dam}");
    Console.WriteLine($"残りHP:{((int)hp - dam)}");
    Console.WriteLine($"HP%:{((int)hp - dam) / 10}");

    for (int i = ((int)hp - dam) / 10; i > 0; i--)
    {
      Console.Write('*');

    }
    if (((int)hp - dam) / 10 == 0 && ((int)hp - dam) > 0)
    {
      Console.Write('*');
      barFlg = 1;
    }

    for (int j = barFlg; j < dam / 10; j++)
    {
      Console.Write('-');
    }
  }
}*/
/*
using System;

public class SurveyingStake
{
  private int _stakeId;
  public int StakeId
  {
    get => _stakeId;
    set
    {
      if (value <= 0)
      {
        throw new ArgumentOutOfRangeException(
          nameof(value),
          "エラー：IDは1以上である必要があります");
      }

      _stakeId = value;
    }
  }
  private float _position;
  public float Position
  {
    get => _position;
    set
    {
      // ✅ 案1：例外で明示的に失敗させる（StakeIdと同じ方針に統一）
      if (value >= 10000)
      {
        throw new ArgumentOutOfRangeException(nameof(value),
            $"位置は10000m未満で指定してください。（入力値: {value}）");
      }

      // ✅ 案2：どうしてもClampしたいなら、ログを残す
      if (value >= 10000)
      {
        Console.WriteLine($"[WARN] 位置 {value}m を上限値 9999m にClampしました");
        value = 9999f;
      }

      _position = value;
    }
  }
    // ✅ 将来を見据えた構造
    public class StakePosition  // 座標を独立したクラスに
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float? Altitude { get; set; } // 前回のSurveyingクラスと連携
    }
}
public class Property
{
  public void ShowStatus(SurveyingStake stake)
  {
    // 可読性：null合体演算子(??)で未設定時の表示をスマートに
    // ❌ int と float は null にならないので、??以降は絶対に実行されない
    //Console.WriteLine($"杭数：{stake.StakeId.ToString() ?? "未設定"}本目");

    // ✅ 意図通りに動かすには、型をnull許容にする必要がある
    // SurveyingStake側を int? に変更するか、初期値で判定する
    Console.WriteLine($"杭数：{(stake.StakeId == 0 ? "未設定" : stake.StakeId.ToString())}本目");
    Console.WriteLine($"位置：{stake.Position.ToString() ?? "未設定"}m");
  }
  public static void OldMain()
  {
    var stake = new SurveyingStake();
    var prop = new Property();

    for (int i = -1; i <= 2; i++)
    {
      try
      {
        Console.WriteLine($"--- ID:{i} の代入に挑戦 ---");
        stake.StakeId = i;
        stake.Position = 5000f * i;

        // 正常に代入できたときだけ、ここを通る
        Console.WriteLine("成功しました！");
        prop.ShowStatus(stake);
      }
      catch (Exception ex)
      {
        // ここでエラーを捕まえても、tryはループ内にあるので、
        // 次の i の処理（次のループ）へ進める！
        Console.WriteLine($"[LOG] 失敗： {ex.Message}");
      }
    }
  }
}
*/
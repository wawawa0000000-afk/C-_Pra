/*using System;

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
      if (value >= 10000)
      {
        Console.WriteLine($"[WARN] 位置 {value}m を上限値 9999m にClampしました");
        value = 9999f;
      }

      _position = value;
    }
  }
}
public class Property
{
  public void ShowStatus(SurveyingStake stake)
  {
    // 可読性：null合体演算子(??)で未設定時の表示をスマートに
    Console.WriteLine($"杭数：{stake.StakeId.ToString() ?? "未設定"}本目");
    Console.WriteLine($"位置：{stake.Position.ToString() ?? "未設定"}m");
  }
  public static void Main()
  {
    var stake = new SurveyingStake();
    var prop = new Property();

    // -5, 0, 5 と変化するループ
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
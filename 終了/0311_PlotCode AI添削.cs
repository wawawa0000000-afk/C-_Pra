using System;

public class Surveying
{
    // C#の「プロパティ」機能を使うと、可読性と効率性が上がります
    private float? _altitude;
    public float? Altitude
    {
        get => _altitude;
        set
        {
            if (value.HasValue && (value.Value < -100f || value.Value > 9000f))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"標高は -100m ～ 9000m の範囲で指定してください。（入力値: {value}）"
                );
            }
            _altitude = value;
        }
    }

    public void ShowStatus()
    {
        // 可読性：null合体演算子(??)で未設定時の表示をスマートに
        Console.WriteLine($"標高：{Altitude?.ToString() ?? "未設定"}m");
    }

    public static void OldMain()
    {
        var p_test = new Surveying();

        try
        {
            p_test.Altitude = 100f;  // セットするだけで検閲が走る
            p_test.ShowStatus();

            p_test.Altitude = 10000f; // ここで例外が発生
        }
        catch (Exception ex)
        {
            // 信頼性：エラーが起きたことを明確にログに残す
            Console.WriteLine($"[LOG] {ex.Message}");
        }

        Surveying? p_empty = null;
        p_empty?.ShowStatus(); // 可用性：Nullでも落ちない

        Console.WriteLine("プログラムは安全に終了しました。");
    }
}
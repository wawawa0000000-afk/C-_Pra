using System;
using System.IO;

public class Program
{
    static void ExecuteProcess(bool isRecoverable)
    {
        try
        {
            // 【疑問①の答え：ここは何？】
            // 今回は例外処理を「練習」するために、ここでわざとエラーを発生させています。
            // 実際のプログラムではここに「ファイルを読み込む処理」などが入り、
            // ファイルが無い場合はシステムが勝手に throw new FileNotFoundException を発動させます。
            if (isRecoverable)
            {
                throw new FileNotFoundException("ファイルなし");
            }
            else
            {
                throw new InvalidOperationException("システム異常");
            }
        }    
        catch(FileNotFoundException ex) 
        {
            // 【疑問③の答え：throw;を書かなくて正解？】
            // 大正解です！
            // catchブロックの中でエラーをキャッチし、そのあとに throw; を「書かない」でおくと、
            // C#は「エラーはここで処理された（解決した）」とみなし、プログラムをクラッシュさせずに通常の処理に戻ります[1]。
            // この「エラーを飲み込む」ことこそが「回復」の正体です。
            Console.WriteLine("回復処理：代替データを使用します");
        }
        catch (Exception ex)
        {
            Console.WriteLine("未知のエラーを検知しました");
            
            // 【疑問④の答え：throw; はどこへ飛ぶ？】
            // ここの throw; は、このエラーを「自分を呼び出した元の場所」にそのまま投げ返します[2, 3]。
            throw; 
            
            // ＝＝＝＝＝ ここから、呼び出し元である Mainメソッド の catch ブロックへワープ（飛ぶ）します ＝＝＝＝＝
        }
    }
    
    public static void Main()
    {
        try
        {
            Console.WriteLine("hello");
            
            // 1回目の呼び出し：回復可能なエラーが発生し、ExecuteProcess内で飲み込まれる（解決する）
            ExecuteProcess(true);
            
            // 2回目の呼び出し：網目2に引っかかり、ExecuteProcessの中の「throw;」が実行される
            ExecuteProcess(false); 
        }
        catch(Exception ex)
        {
            // ＝＝＝＝＝ ExecuteProcessの throw; から、ここに飛んできます！ ＝＝＝＝＝
            
            // 【最後の防波堤】
            Console.WriteLine("最上位でエラーを記録して終了します");
            // ex.Message でエラーの原因を取り出したり、
            // ex.ToString() でエラーの発生場所（スタックトレース）を取り出して記録したりする
            Console.WriteLine($"エラー発生: {ex.Message}");
        }
    }
}

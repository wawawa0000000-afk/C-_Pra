using System;
using System.IO;

public class Program
{
  public static void Main()
  {
    try
    {
      int a = 10;
      int b = 0;
      int result = a / b;
      Console.WriteLine($"{a} / {b} = {result}");
    }
    catch(DivideByZeroException nn)
    {
      Console.WriteLine ("0で割ることはできません！");
      Console.WriteLine($"エラー発生: {nn.Message}");
    }
    finally
    {
      Console.WriteLine ("計算処理を完了しました。");
    }
  }
}
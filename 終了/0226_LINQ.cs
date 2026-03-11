using System;
using System.Linq;//可読性のために記述する

public class Guild
{
  public static void OldMain()
  {
    string exp = Result();
    Prize(exp);
  }
  public static string Result()
  {
    return "50 120 10 300 80 15 200";
  }
  public static void Prize(string exp)
  {
    int sum = 0;
    var processList = exp                               //expを推論型の変数に代入
      .Split(' ')                                       //スペースで区切る
      .Select(processList => int.Parse(processList))    //文字列を数値に変換
      .Where(n => n >= 100)                             //新たにnを宣言し100以上の数値だけを抽出                     
      .OrderByDescending(n => n)                        //数値を文字列に変換して降順に並び替える
      .ToList();
    Console.WriteLine("===報酬獲得===");
    foreach (var n in processList)
    {
      Console.WriteLine(n);
      sum += n;
    }
    Console.WriteLine($"合計経験値:{sum}");
  }
}
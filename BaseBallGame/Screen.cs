using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Screen
{
  Datebase DB_ = new Datebase();
  public void PlayScreen()
  {
    for (int i = 0; i < DB_.Position.Count; i++)
    {
      Console.WriteLine($"番号：{i + 1}\t\t守備位置：{DB_.Position[i]}");
    }

    Console.WriteLine("プレイヤーたちを登録してください");
    while (DB_.PlayerName.Contains("（未登録）"))
    {
      BackActive();
      for (int i = 0; i < DB_.Position.Count; i++)
      {
        // 選手名リストがまだ空、または足りない場合の安全策
        string name = (i < DB_.PlayerName.Count) ? DB_.PlayerName[i] : "（未登録）";

        Console.WriteLine($"番号：{i + 1}\t守備位置：{DB_.Position[i]}\t名前：{name}");
      }
    }
  }
  public void BackActive()
  {
    Console.WriteLine("番号(1-9)と名前を入力してください（例: 1 イチロー）");
    string input = Console.ReadLine() ?? "";
    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    // 入力が「番号 名前」の形式かチェック
    if (parts.Length >= 2 && int.TryParse(parts[0], out int number))
    {
      int index = number - 1; // 番号をリストの添え字に変換

      // 範囲内かチェックして、その場所だけを書き換える！
      if (index >= 0 && index < DB_.PlayerName.Count)
      {
        DB_.PlayerName[index] = parts[1]; // ここが「更新」
        Console.WriteLine($"{parts[0]}番の {parts[1]} を登録しました。");
      }
    }
    else
    {
      Console.WriteLine("入力形式が正しくありません。");
    }
  }
}
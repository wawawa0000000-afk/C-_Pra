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

    BackActive();
    for (int i = 0; i < DB_.Position.Count; i++)
    {
      // 選手名リストがまだ空、または足りない場合の安全策
      string name = (i < DB_.PlayerName.Count) ? DB_.PlayerName[i] : "（未登録）";

      Console.WriteLine($"番号：{i + 1}\t守備位置：{DB_.Position[i]}\t名前：{name}");
    }
  }
  public void BackActive()
  {
    string inputPlayerName = Console.ReadLine() ?? "不足";
    var nameTable = inputPlayerName
      .Split(' ')
      .ToList();

    DB_.PlayerName = nameTable;
  }
}
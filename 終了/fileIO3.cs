using System;
using System.IO;
using System.Text.Json;

public class HighScoreData
{
  public string? PlayerName {get; set;}
  public int Score {get; set;}
}

public class Program
{
  public static void Main()
  {
    string filePath = "highscore.json";
    HighScoreData scoreDataBox = new HighScoreData{PlayerName = "satoshi",Score = 10};
    string playerMem = JsonSerializer.Serialize(scoreDataBox);
    File.WriteAllText(filePath, playerMem);
    
    Console.WriteLine("--- パーティのセーブ完了 ---");
    if (!File.Exists(filePath))
    {
      Console.WriteLine("セーブデータがありません！");
      return;
    }

    string loadPlayer = File.ReadAllText(filePath);
    HighScoreData? loadData = JsonSerializer.Deserialize<HighScoreData>(loadPlayer);
    if (loadData == null)
    {
      Console.WriteLine("データのロードに失敗しました");
      return;
    }

    Console.WriteLine("--- パーティのロード完了 ---");
    Console.WriteLine($"プレイヤー: {loadData.PlayerName} (Lv.{loadData.Score})");
  }
}
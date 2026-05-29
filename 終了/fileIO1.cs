using System;
using System.IO;
// 【1】JSONを扱うための名前空間（System.Text.Json）を宣言してください
using System.Text.Json;


public class SaveData
{
  public string? PlayerName { get; set; }
  public int Level { get; set; }
  public int HP { get; set; }
}

public class Program
{
  public static void Main()
  {
    // ① データクラスの用意（セーブするデータを作る）
    SaveData myData = new SaveData { PlayerName = "アーサー", Level = 15, HP = 120 };
    string filePath = "savegame.json";

    // ==========================================
    // 💾 セーブ処理
    // ==========================================
    // 【2】JsonSerializerの機能を使って、myDataオブジェクトをJSON文字列に「シリアライズ」してください
    // ヒント：JsonSerializer.Serialize(変換したいオブジェクト)
    string jsonString = JsonSerializer.Serialize(myData);

    // 【3】Fileクラスの機能を使って、filePathの場所にjsonStringを「テキストとして書き込んで」ください
    // ヒント：File.WriteAllText(ファイルパス, 書き込む文字列)
    File.WriteAllText(filePath, jsonString);


    Console.WriteLine("--- セーブ完了 ---");
    Console.WriteLine(jsonString);


    // ==========================================
    // 📂 ロード処理
    // ==========================================
    // 【4】Fileクラスの機能を使って、filePathの場所から「テキストをすべて読み込んで」ください
    // ヒント：File.ReadAllText(ファイルパス)
    string loadedJson = File.ReadAllText(filePath);

    // 【5】JsonSerializerの機能を使って、読み込んだJSON文字列をSaveData型のオブジェクトに「デシリアライズ」してください
    // ヒント：JsonSerializer.Deserialize<戻したい型>(読み込んだJSON文字列)
    SaveData? loadedData = JsonSerializer.Deserialize<SaveData>(loadedJson);
    if (loadedData == null)
    {
      Console.WriteLine("データのロードに失敗しました");
      return;
    }

    Console.WriteLine("\n--- ロード完了 ---");
    Console.WriteLine($"プレイヤー: {loadedData.PlayerName} (Lv.{loadedData.Level}) HP:{loadedData.HP}");
  }
}
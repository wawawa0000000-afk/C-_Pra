using System;
using System.Collections.Generic;
using System.IO;
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
    string filePath = "party_save.json";

    // ① 複数人のデータ（パーティ）のリストを作成
    List<SaveData> party = new List<SaveData>
        {
            new SaveData { PlayerName = "アーサー", Level = 15, HP = 120 },
            new SaveData { PlayerName = "ランスロット", Level = 45, HP = 300 },
            new SaveData { PlayerName = "マーリン", Level = 60, HP = 80 }
        };

    // ==========================================
    // 💾 セーブ処理
    // ==========================================
    // 【1】partyリストをJSON文字列にシリアライズしてください
    string partyMem = JsonSerializer.Serialize(party);

    // 【2】Fileクラスを使って、filePathの場所にJSON文字列を保存してください
    File.WriteAllText(filePath, partyMem);

    Console.WriteLine("--- パーティのセーブ完了 ---");


    // ==========================================
    // 📂 ロード処理
    // ==========================================
    // 【3】ガード句：File.Exists(ファイルパス) を使って、ファイルが存在しない場合は
    // "セーブデータがありません！"とコンソールに表示して return;（早期リターン）してください。
    // ヒント： if (!File.Exists(filePath)) { ... }
    if (!File.Exists(filePath))
    {
      Console.WriteLine("セーブデータがありません！");
      return;
    }

    // 【4】ファイルからテキスト（JSON文字列）を読み込んでください
    string loadJsonText = File.ReadAllText(filePath);

    // 【5】読み込んだJSON文字列を List<SaveData> 型にデシリアライズしてください
    // ヒント：JsonSerializer.Deserialize<戻したい型>(読み込んだJSON文字列);
    List<SaveData>? loadData = JsonSerializer.Deserialize<List<SaveData>>(loadJsonText);
    if (loadData == null)
    {
      Console.WriteLine("データのロードに失敗しました");
      return;
    }
    Console.WriteLine("\n--- ロード完了 ---");
    // 【6】foreach文を使って、ロードした全員の名前とHPをコンソールに表示してください
    foreach (SaveData t in loadData)
    {
      Console.WriteLine($"プレイヤー: {t.PlayerName} HP:{t.HP}");
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq; // LINQの魔法を使うために必須！

public class Character
{
  public string Name { get; set; }
  public string Job { get; set; }
  public int Level { get; set; }
}

public class Program
{
  public static void Main()
  {
    // ギルドに所属するメンバーのリスト
    List<Character> guildMembers = new List<Character>
        {
            new Character { Name = "アーサー", Job = "騎士", Level = 15 },
            new Character { Name = "ランスロット", Job = "騎士", Level = 45 },
            new Character { Name = "マーリン", Job = "魔法使い", Level = 60 },
            new Character { Name = "ガウェイン", Job = "戦士", Level = 35 },
            new Character { Name = "トリスタン", Job = "戦士", Level = 10 }
        };

    // ==========================================
    // ミッション：レベル30以上のキャラを選抜し、レベルが高い順に並び替え、
    // 名前と職業のリストを作成せよ！
    // ==========================================
    // 【1】Whereを使って、Levelが30「以上」のキャラだけを抽出してください
    // 【2】OrderByDescendingを使って、Levelが「高い順（降順）」に並び替えてください
    // 【3】Selectを使って、「"名前 (職業 - Lv.レベル)"」という形の新しい文字列に加工して抽出してください
    // ヒント：文字列補間 $"{s.Name} ..." を使います
    var eliteMembers = guildMembers
      .Where(s => s.Level >= 30)
      .OrderByDescending(s => s.Level)
      .Select(s => $"{s.Name}({s.Job} - Lv.{s.Level})");

    Console.WriteLine("【精鋭部隊リスト】");
    // 【4】foreach文を使って、抽出した eliteMembers の中身をすべてコンソールに出力してください
    foreach(string C_Name in eliteMembers)
    {
      Console.WriteLine($"{C_Name}");
    }


    Console.ReadLine();
  }
}
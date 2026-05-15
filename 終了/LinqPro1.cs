using System;
using System.Collections.Generic;
using System.Linq; // LINQの魔法を使うために必須！

public class Character
{
  public string Name { get; set; }
  public int HP { get; set; }
}

public class Program
{
  public static void Main()
  {
    // パーティメンバーのリスト
    List<Character> party = new List<Character>
    {
      new Character { Name = "勇者", HP = 100 },
      new Character { Name = "戦士", HP = 40 },
      new Character { Name = "魔法使い", HP = 20 },
      new Character { Name = "僧侶", HP = 80 }
    };

    // ==========================================
    // ミッション：HPが50以下のキャラの名前を抽出して表示せよ！
    // ==========================================

    // 1. party から、Where で HP <= 50 のキャラを絞り込み、
    //    そのまま Select で Name だけを取り出すメソッドチェーンを書く
    var pinchNames = party
      .Where( s => s.HP <= 50)
      .Select(s => s.Name)
        /* ここにLINQを書く */;

    // 2. 抽出した名前を foreach で表示する
    Console.WriteLine("【ピンチな仲間】");
    foreach (var name in pinchNames)
    {
      Console.WriteLine(name);
    }

    Console.ReadLine();
  }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Weapon
{
  public string Name { get; set; }
  public int Power { get; set; }
  public int Price { get; set; }
}

public class Program
{
  public static void Main()
  {
    List<Weapon> weapons = new List<Weapon>
    {
      new Weapon { Name = "ひのきのぼう", Power = 5, Price = 30},
      new Weapon { Name = "はがねのつるぎ", Power = 100, Price = 150},
      new Weapon { Name = "炎の杖", Power = 60, Price = 400},
      new Weapon { Name = "ドラゴンキラー", Power = 300, Price = 900},
      new Weapon { Name = "でんせつのたて", Power = 0, Price = 2500}
    };

    var selectweapons = weapons
      .Where(s => s.Price <= 2000)
      .OrderByDescending(s => s.Power)
      // 変更後（名前と攻撃力の2つを埋め込んで、新しい文字列を作る！）
      .Select(s => $"{s.Name} (攻撃力: {s.Power})");
      // 変更前（名前だけ）
      //.Select(s => s.Name)

    foreach (var name in selectweapons)
    {
      Console.WriteLine(name);
    }

    Console.ReadLine();
  }
}
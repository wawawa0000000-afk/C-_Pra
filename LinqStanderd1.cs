using System;
using System.Collections.Generic;
using System.Linq;

public class Adventurer
{
  public string Name { get; set; }
  public int Gold { get; set; }
}

public class Program
{
  public static void Main()
  {
    List<Adventurer> adventurers = new List<Adventurer>
    {
      new Adventurer { Name = "戦士", Gold = 300},
      new Adventurer { Name = "魔法使い", Gold = 1200},
      new Adventurer { Name = "戦士", Gold = 500}
    };

    var SumAdventurers = adventurers
      .Sum(s => s.Gold);
    
    var CountAdventurers = adventurers
      .Count(s => s.Gold >= 500);
    
    var FirstAdventurers = adventurers
      .First();
    
    Console.WriteLine($"合計費用：{SumAdventurers}\n500G以上の費用者：{CountAdventurers}\n最初の仲間：{FirstAdventurers.Name}");
  }
}
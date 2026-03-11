using System;
using System.Collections.Generic;

public class HeroRPG
{
  public static void OldMain()
  {
    List<string> pouch = Start();
    Game(pouch);
  }
  public static List<string> Start()
  {
    return new List<string> {"やくそう", "ひのきのぼう", "どくけしそう"};
  }
  public static void Game(List<string> pouch)
  {Console.WriteLine("冒険に出発します！");
    Console.WriteLine("持ち物:");
    for(int i = 0; i < pouch.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {pouch[i]}");
    }

    Console.WriteLine("伝説の剣を手に入れた");
    pouch.Insert(0, "伝説の剣");

    if (pouch.Contains("ひのきのぼう"))
    {
      Console.WriteLine("ひのきぼうを持っている");
      pouch.Remove("ひのきのぼう");
    }
    else
    {
      Console.WriteLine("ひのきぼうを持っていない");
      return;
    }

    Console.WriteLine("===戦闘発生===");
    int weapon = 0;
    Console.WriteLine($"持ち物:{weapon + 1}. {pouch[weapon]}を取り出した");
    Console.WriteLine($"持ち物:{weapon + 1}. {pouch[weapon]}を消費した");
    pouch.RemoveAt(weapon);


    Console.WriteLine("~~~罠にかかった~~~");
    pouch.Clear();
    Console.WriteLine ($"持ち物の数:{pouch.Count}");
  }
}
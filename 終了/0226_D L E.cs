using System;

public class Border
{
  public static event Action? OnTownDestroyed;
  public static void OldMain()
  {
    int TownHP = 100;

    OnTownDestroyed += () => Console.WriteLine("市民：急いで地下シェルターは避難します");
    OnTownDestroyed += () => Console.WriteLine("防衛隊：総員撤退 街を放棄する");

    int[] damage = { 40, 50, 20 };
    for (int i = 0; i < 3; i++)
    {
      TownHP -= damage[i];
      Console.WriteLine($"{damage[i]}のダメージ｜残りHP：{TownHP}");
    }

    if (TownHP <= 0)
    {
      OnTownDestroyed?.Invoke();
    }
  }
}
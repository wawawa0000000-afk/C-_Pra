using System;

public class Program
{
  public static void Main()
  {
    Dictionary<int, Item> gacha = new Dictionary<int, Item>();
    gacha.Add(1, new Item { Name = "gold", weight = 10 });
    gacha.Add(2, new Item { Name = "silv", weight = 30 });
    gacha.Add(10, new Item { Name = "wood", weight = 60 });

    Random rand = new Random();

    for (int n = 0; n < 10; n++)
    {
      int roll = rand.Next(0, 100);

      foreach (var item in gacha)
      {
        roll -= item.Value.weight;
        if (roll <= 0)
        {
          Console.WriteLine($"当選：{item.Value.Name}");
          break;
        }
      }
    }
  }
}

public class Item
{
  public string? Name { get; set; }
  public int weight { get; set; }
}
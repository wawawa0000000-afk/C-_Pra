using System;

public class Program
{
  public static void Main()
  {
    int selectID = 999;
    Dictionary<int, Item> itemDic = new Dictionary<int, Item>();

    itemDic.Add(1, new Item { Name = "薬草", HealAmount = 30, Price = 10 });
    itemDic.Add(2, new Item { Name = "どくけしそう", HealAmount = 0, Price = 15 });
    itemDic.Add(105, new Item { Name = "薬草", HealAmount = 999, Price = 10000 });

    int searchId = selectID;
    if (itemDic.TryGetValue(searchId, out Item foundItem))
    {
      Console.WriteLine($"見つかりました！ 名前:{foundItem.Name}");
    }
    else
    {
      Console.WriteLine($"ID:{searchId} のアイテムは見つかりませんでした。"); 
    }
  }
}

public class Item
{
  public string? Name { get; set; }
  public int? HealAmount { get; set; }
  public int? Price { get; set; }
}
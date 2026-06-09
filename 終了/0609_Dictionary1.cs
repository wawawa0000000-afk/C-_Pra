using System;

public class Program
{
  public static void Main()
  {
    //int selectID = 105;
    Dictionary<int , string> itemDic = new Dictionary<int , string>();

    itemDic.Add(1,"薬草");
    itemDic.Add(2,"どくけしそう");
    itemDic.Add(105,"エクスカリバー");

    foreach(var item in itemDic)
    {
      Console.WriteLine($"ID:{item.Key} Item:{item.Value}");
    }
  }
}
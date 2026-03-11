using System;
using System.Collections.Generic; // Listに必要
using System.Threading.Tasks;     // Taskに必要
public class Reflection
{

  public static async Task OldMain()
  {
    List<float> Box = new List<float>(10);
    Random rand10 = new Random();

    float min = 10.0f;
    float max = 100.0f;
    for (int i = 0; i < 10; i++)
    {

      float nList = (float)rand10.NextDouble() * (max - min) + min;
      Box.Insert(i, nList);
    }

    await Screen(Box);
  }

  public static async Task Screen(List<float> Box)
  {
    float Sum = 0;
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine($"{Box[i]}");
      await Task.Delay(1000);

      Sum = Sum + Box[i]; 
      if(Sum >= 500)
      Console.WriteLine("---500到達---");
    }
  }
}
using System;
using System.Linq;

public class WriteLine
{
  public static void OldMain()
  {
    double[]? coords = Console.ReadLine()
    .Split(',')
    .Select(s => s.Trim())
    .Select(double.Parse)
    .ToArray();


    double x, y, z;
    if (coords.Length >= 3)
    {
      x = coords[0];
      y = coords[1];
      z = coords[2];
    }
    else
    {
      Console.WriteLine("データ不足");
      return;
    }

    double sum = x + y + z;
    double sumRoot = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
    // 配列の各要素を2乗(Select)して、全部足して(Sum)、最後にルート(Sqrt)
    //double distance = Math.Sqrt(coords.Select(n => n * n).Sum());

    Console.WriteLine($"sum:{sum}\nroot:{sumRoot}");
  }
}
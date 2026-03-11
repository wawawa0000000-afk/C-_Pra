using System;

public class Plot
{
  public static int Total = 0;
  public float? Z;

  public static void OldMain()
  {
    // オブジェクト初期化子を使って new と代入を一行に
    var p1 = new Plot { Z = 10.5f };
    ShowTotal(++Total); // 前置演算で増やしてすぐ渡す
    p1.ShowStatus();

    var p2 = new Plot { Z = 20.8f };
    ShowTotal(++Total);
    p2.ShowStatus();

    var p3 = new Plot { Z = null };
    Plot.ShowTotal(++Total);
    p3.ShowStatus();
  }

  // 引数を Z に限定せず、自分の持つ Z を表示するように変更
  public void ShowStatus() => Console.WriteLine($"標高: {Z ?? -1.0}");

  // 式形式の本体（=>）を使ってメソッドを短縮
  public static void ShowTotal(int count) => Console.WriteLine($"総数: {count}");
}
//私の記述したコード
/*public class Prastatic
{
  public static int TotalPlots = new int();
  public static void Main()
  {
    float Z = new float();
    Prastatic _manage = new Prastatic();

    if(Z == new float())  ShowTotal(TotalPlots+=1);
    _manage.ShowStatus(Z += 10.5f);
    Z = new float();
    if(Z == new float())  ShowTotal(TotalPlots+=1);
    _manage.ShowStatus(Z += 20.8f); 
  }

  //自分の標高（Z）を表示する。
  public void ShowStatus(float Z)
  {
    Console.WriteLine(Z);
  }

  //現在世界に何本の杭があるか（TotalPlots）を表示する。
  public static void ShowTotal(int TotalPlots)
  {
    Console.WriteLine(TotalPlots);
  }
}*/
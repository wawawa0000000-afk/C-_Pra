using System;
using System.Threading.Tasks;

public class AsyncAwait
{
  public static async Task OldMain()
  {
    Task mapTask = LoadMapAsync();
    Task fogTask =LoadFogAsync();
    Task noboruTask =LoadNoboruAsync();
    
    Console.WriteLine("全データの同時ロード中...");

    await Task.WhenAll(mapTask, fogTask, noboruTask);
    Console.WriteLine($"ロード完了！\tゲームスタート！");
  }
  public static async Task LoadMapAsync()
  {
    Console.WriteLine("マップデータ読み込み開始…");
    await Task.Delay(3000);
    Console.WriteLine("マップ完了！");
  }
  public static async Task LoadFogAsync()
  {
    Console.WriteLine("霧エフェクト読み込み開始…");
    await Task.Delay(2000);
    Console.WriteLine("霧完了！");
  }
  public static async Task LoadNoboruAsync()
  {
    Console.WriteLine("ノボル読み込み開始…");
    await Task.Delay(1000);
    Console.WriteLine("ノボル完了！");
  }
}
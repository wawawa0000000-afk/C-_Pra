using System;
using System.Reactive.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("プレイヤーは毒状態になった！");

        // ① 1秒ごとに発生するストリームに Take(5) を繋げて、5回で終わる川を作る
        IObservable<long> poisonStream = Observable.Interval(TimeSpan.FromSeconds(1)).Take(5);
        
        // ② ストリームを購読し、「ダメージ処理」と「完了時の処理」の2つをセットする
        poisonStream.Subscribe(
          count => Console.WriteLine($"毒のダメージ！ HPが5減った... (経過: {count}秒)")
        );

        // プログラムがすぐ終わらないように待機
        Console.ReadLine();
    }
}
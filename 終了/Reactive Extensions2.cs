using System;
using System.Reactive.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("プレイヤーは毒状態になった！");

        // ① 1秒ごとに発生する「時間のストリーム」を作成
        IObservable<long> poisonStream = Observable.Interval(TimeSpan.FromSeconds(1));
        
        // ② ストリームを購読し、データ(count)が来るたびに毒ダメージメッセージを出す
        poisonStream.Subscribe(
          count => Console.WriteLine($"毒のダメージ！ HPが5減った... (経過: {count}秒)" )
        );

        // プログラムがすぐ終わらないように待機
        Console.ReadLine();
    }
}
using System;
using System.Reactive.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("リジェネ魔法を発動しました！");

        // ① 1秒ごとに発生する「時間のストリーム」を作成
        IObservable<long> timerStream = Observable.Interval(TimeSpan.FromSeconds(1));
        
        // ② ストリームを購読し、データ(count)が来るたびに回復メッセージを出す
        timerStream.Subscribe(count => 
            Console.WriteLine($"リジェネ効果！ HPが10回復しました (経過: {count}秒)")
        );

        // プログラムがすぐ終わらないように待機
        Console.ReadLine();
    }
}
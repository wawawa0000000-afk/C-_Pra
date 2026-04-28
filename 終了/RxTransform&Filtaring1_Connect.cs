using System;
using System.Reactive.Linq;
using System.Reactive.Subjects; // IConnectableObservable を使うための詠唱

public class Program
{
    public static void Main()
    {
        Console.WriteLine("戦闘開始！ 毎秒ダメージを受けます...");
        Random rand = new Random();

        // =========================================================
        // 【第一の柱】 Publish() で「分配可能な1つの蛇口」に変換する
        // =========================================================
        // ただの Interval だと購読のたびにタイマーが新設されてしまうため、
        // 末尾に .Publish() をつけて「ホットストリーム」に変換します。
        // ※この魔法を使うと、型が IObservable から IConnectableObservable に進化します。
        IConnectableObservable<int> hpStream = Observable
            .Interval(TimeSpan.FromSeconds(1)).Take(10)
            .Select(_ => rand.Next(10, 101))
            .Publish(); 

        // hpStream を Where で加工し、「HPが30以下」の時だけ通す pinchStream を作る
        IObservable<int> pinchStream = hpStream
            .Where(hp => hp <= 30);

        // =========================================================
        // 【第二の柱】 各々が Subscribe() で待機状態（契約）に入る
        // =========================================================
        // Publish() を使っている場合、Subscribeした時点ではまだ水（データ）は流れません。
        // 「水が流れてきたらこう表示するよ」という契約（コップを置く作業）だけを先に済ませます。
        hpStream.Subscribe(
            hp => Console.WriteLine($"(負荷)HPが {hp} に低下！")
        );
        pinchStream.Subscribe(
            hp => Console.WriteLine($"【警告】HPが {hp} に低下！ オートポーションを使用します！")
        );

        // =========================================================
        // 【第三の柱】 Connect() で大元の蛇口をひねる！
        // =========================================================
        // 全員の購読（コップの配置）が終わったら、最後に Connect() の魔法を唱えます。
        // ここで初めて「1つだけの大元のタイマー」が起動し、全員に同じランダム値が同時に分配されます。
        hpStream.Connect();

        // プログラムがすぐ終わらないように待機
        Console.ReadLine();
    }
}
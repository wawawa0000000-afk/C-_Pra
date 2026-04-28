using System;
using System.Reactive.Linq;

public class Program
{
  public static void Main()
  {
    Console.WriteLine("戦闘開始！ 毎秒ダメージを受けます...");
    Random rand = new Random();

    // 毎秒、10～100のランダムなHPの数値を流すストリーム（ここは完成しています）
    IObservable<int> hpStream = Observable
      .Interval(TimeSpan.FromSeconds(1)).Take(10)
      .Select(_ => rand.Next(10, 101));
    
    // ① hpStream を Where で加工し、「HPが30以下」の時だけ通す pinchStream を作る
    IObservable<int> pinchStream = hpStream
      .Where(hp => hp <= 30);

    // ② pinchStream を購読(Subscribe)し、警告と回復のメッセージを出す
    hpStream.Subscribe(
      hp => Console.WriteLine($"(負荷)HPが {hp} に低下！")
    );
    pinchStream.Subscribe(
      hp => Console.WriteLine( $"【警告】HPが {hp} に低下！ オートポーションを使用します！")
    );

    // プログラムがすぐ終わらないように待機
    Console.ReadLine();
  }
}
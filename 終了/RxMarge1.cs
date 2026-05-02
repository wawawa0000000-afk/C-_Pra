using System;
using System.Reactive.Linq;

public class Program
{
  public static void Main()
  {
    Console.WriteLine("激闘開始！");

    // 1秒ごとに発動するプレイヤーの攻撃ストリーム（3回で終了）
    IObservable<string> playerStream = Observable
      .Interval(TimeSpan.FromSeconds(1))
      .Take(3)
      .Select(_ => "剣士の連続攻撃！");

    // 2秒ごとに発動するドラゴンの攻撃ストリーム（2回で終了）
    IObservable<string> dragonStream = Observable
      .Interval(TimeSpan.FromSeconds(2))
      .Take(2)
      .Select(_ => "ドラゴンの炎のブレス！");

    // ① playerStream と dragonStream を Merge で合流させ、battleStream を作成せよ！
    IObservable<string> battleStream = playerStream
      .Merge(dragonStream); 
    //IObservable<string> battleStream = Observable.Merge(playerStream,dragonStream);

    // ② battleStream を Subscribe して、流れてくるメッセージを表示せよ！
    battleStream.Subscribe(
      message => Console.WriteLine(message)
    );

    // プログラムがすぐ終わらないように待機
    Console.ReadLine();
  }
}
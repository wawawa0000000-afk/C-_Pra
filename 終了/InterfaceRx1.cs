using System;
using System.Reactive.Linq;

// ① 状態異常のインターフェース（契約）
public interface IStatusEffect
{
  // メッセージが流れてくるストリーム（川）を返す
  IObservable<string> StartEffect();
}

// ② 毒（Poison）クラス
public class Poison : IStatusEffect
{
  public IObservable<string> StartEffect()
  {
    // 1秒ごとに3回、「毒のダメージ！」を流す川を作る
    return Observable.Interval(TimeSpan.FromSeconds(1))
                     .Take(3)
                     .Select(_ => "毒のダメージ！");
  }
}

// ③ リジェネ（Regen）クラスを自分で作ってみよう！
// （IStatusEffect を実装し、"HPが回復した！" を3回流す川を作る）
public class Regen : IStatusEffect
{
  public IObservable<string> StartEffect()
  {
    return Observable.Interval(TimeSpan.FromSeconds(1))
                     .Take(3)
                     .Select(_ => "HPが回復した");
  }
}


public class Player
{
  // ④ 状態異常を受け取り、発動させるメソッド
  public void AddStatusEffect(IStatusEffect effect)
  {
    Console.WriteLine("プレイヤーに新たな状態異常が付与された！");

    // ここで effect.StartEffect() を呼び出してストリームを受け取り、Subscribeする！
    effect.StartEffect().Subscribe(
      effectMsg => Console.WriteLine(effectMsg),
      () => Console.WriteLine("状態の変化が切れた")
    );
  }
}

public class Program
{
  public static void Main()
  {
    Player player = new Player();

    // 毒を付与
    player.AddStatusEffect(new Poison());

    // ちょっと待機（1.5秒）してからリジェネを付与
    // 毒のダメージとリジェネの回復が並行して流れるのを確認する
    System.Threading.Thread.Sleep(1500);
    player.AddStatusEffect(new Regen());

    // プログラムがすぐ終わらないように待機
    Console.ReadLine();
  }
}
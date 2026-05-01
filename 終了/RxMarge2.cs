using System;
using System.Reactive.Linq;

// ① 攻撃の共通インターフェース
public interface IAttack
{
  string GetDamageMessage();
}

// ② プレイヤーの攻撃クラス（IAttackを実装）
public class SwordAttack : IAttack
{
  public string GetDamageMessage() => "剣士の斬撃！(10ダメージ)";
}

// ③ ドラゴンの攻撃クラス（IAttackを実装）
public class FireBreath : IAttack
{
  public string GetDamageMessage() => "ドラゴンの炎！(30ダメージ)";
}

public class Program
{
  public static void Main()
  {
    Console.WriteLine("激闘開始！");

    // 1秒ごとに「SwordAttackのインスタンス」が流れる川（3回で終了）
    IObservable<SwordAttack> playerStream = Observable
        .Interval(TimeSpan.FromSeconds(1))
        .Take(3)
        .Select(_ => new SwordAttack());

    // 2秒ごとに「FireBreathのインスタンス」が流れる川（2回で終了）
    IObservable<FireBreath> dragonStream = Observable
        .Interval(TimeSpan.FromSeconds(2))
        .Take(2)
        .Select(_ => new FireBreath());

    // ==========================================
    // ④ ここから下を設計・実装してください！
    // ==========================================

    // 1. playerStream を IAttack 型の川に変換 (pStream)
    IObservable<IAttack> pStream = playerStream.Select(s => s);
    // 2. dragonStream を IAttack 型の川に変換 (dStream)
    IObservable<IAttack> dStream = dragonStream.Select(s => s);
    // 3. pStream と dStream を Merge して合流 (battleStream)
    IObservable<IAttack> battleStream = Observable.Merge(pStream, dStream);
    // 4. battleStream を Subscribe して、各攻撃のメッセージを表示！
    // 修正後（流れてきたオブジェクトのメソッドを呼ぶ！）
    battleStream.Subscribe(
      attackObj => Console.WriteLine(attackObj.GetDamageMessage())
    );
    /*
    // 修正前
    battleStream.Subscribe(
      message => Console.WriteLine(message)
    );
    */

    Console.ReadLine();
  }
}
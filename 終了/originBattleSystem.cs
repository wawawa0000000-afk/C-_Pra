using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

// =========================================================
// 1. オブジェクト指向（インターフェースとポリモーフィズム）
// =========================================================
public interface IAction
{
  string ActionName { get; }
  int Value { get; } // ダメージ量や回復量として使う
}

public class Attack : IAction
{
  public string ActionName => "勇者の攻撃";
  public int Value => 100;
}

public class Heal : IAction
{
  public string ActionName => "勇者の回復";
  public int Value => 50;
}

public class BossMagic : IAction
{
  public string ActionName => "魔王の破壊光線";
  public int Value => 60;
}

public class Program
{
  public static async Task Main()
  {
    // =========================================================
    // 2. 非同期処理（Task.Run × Task.WhenAll）
    // =========================================================
    Console.WriteLine("--- 準備フェーズ ---");
    Task heroReady = Task.Run(async () =>
    {
      await Task.Delay(1000);
      Console.WriteLine("勇者：魔法準備完了！");
    });
    Task bossReady = Task.Run(async () =>
    {
      await Task.Delay(2000);
      Console.WriteLine("魔王：戦闘準備完了！");
    });

    // 両方の準備が整うまで待機
    await Task.WhenAll(heroReady, bossReady);
    Console.WriteLine("バトル開始！！！\n");


    // --- バトル用の状態と履歴リスト ---
    int heroHP = 100;
    int bossHP = 500;
    List<IAction> history = new List<IAction>(); // LINQで集計するための履歴

    // =========================================================
    // 3. 時間とイベントの操作（Rxストリーム × Merge）
    // =========================================================
    // 勇者の行動ストリーム（1秒ごと。あなたの書いたロジック通りHPで動的に判定！）
    var heroStream = Observable.Interval(TimeSpan.FromSeconds(1))
        .Select(_ => heroHP > 30 ? (IAction)new Attack() : (IAction)new Heal());

    // ボスの行動ストリーム（2秒ごと）
    var bossStream = Observable.Interval(TimeSpan.FromSeconds(2))
        .Select(_ => (IAction)new BossMagic());

    // 2つの川を合流させ、どちらかのHPが0以下になるまで流し続ける
    var battleStream = Observable.Merge(heroStream, bossStream)
        .TakeWhile(_ => heroHP > 0 && bossHP > 0);

    // 合流した川を購読してバトルを実行
    battleStream.Subscribe(
        // 川からアクションが流れてきた時の処理
        onNext: action =>
        {
          history.Add(action); // 履歴に保存

          // ポリモーフィズムで行動を分岐
          if (action is Attack) bossHP -= action.Value;
          else if (action is Heal) heroHP += action.Value;
          else if (action is BossMagic) heroHP -= action.Value;

          Console.WriteLine($"{action.ActionName}！（効果: {action.Value}）");
          Console.WriteLine($"HERO: {heroHP} / BOSS: {bossHP}\n");
        },
        // 川がせき止められた（終了した）時の処理
        onCompleted: () =>
        {
          Console.WriteLine("バトル終了！！！\n");

          // =========================================================
          // 4. データの操作と集計（LINQ）
          // =========================================================
          Console.WriteLine("--- 戦闘結果の集計 ---");

          // 勇者が攻撃した回数をカウント
          var attackCount = history.Count(a => a is Attack);
          Console.WriteLine($"勇者の攻撃回数: {attackCount}回");

          // ボスが与えた合計ダメージを計算
          var bossDamage = history.Where(a => a is BossMagic).Sum(a => a.Value);
          Console.WriteLine($"ボスが与えた合計ダメージ: {bossDamage}");
        }
    );

    // プログラムが終了しないように待機
    Console.ReadLine();
  }
}


/*
using System;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Linq;

public interface IAction
{
  int NumAction { get; }
  string Action();
}

public class Attack : IAction
{
  public int NumAction => 100;
  public string Action() => "attack";
}
public class Magic : IAction
{
  public int NumAction => 60;
  public string Action() => "magic";
}
public class Heal : IAction
{
  public int NumAction => 50;
  public string Action() => "heal";
}

public class Program
{
  public static async Task Main()
  {
    int heroHP = 100;
    int bossHP = 500;
    // 準備完了表記
    await Task.Delay(1);
    Console.WriteLine("魔法準備");

    Console.WriteLine("バトル！！！");

    // 周期行動
    for (; ; )
    {
      if (heroHP > 30)
      {
        Attack attack = new Attack();
        attack.Action();
        bossHP -= attack.NumAction;
        Console.WriteLine($"{attack.Action()}\nダメージ：{attack.NumAction}");
        Console.WriteLine($"HERO : {heroHP}\nBOSS : {bossHP}\n");
      }
      else
      {
        Heal heal = new Heal();
        heal.Action();
        heroHP += heal.NumAction;
        Console.WriteLine($"{heal.Action()}\nダメージ：{heal.NumAction}");
        Console.WriteLine($"HERO : {heroHP}\nBOSS : {bossHP}\n");
      }

      if (heroHP < 0 || bossHP < 0)
      {
        if (heroHP < 0)
        {
          heroHP = 0;
          Console.WriteLine($"HERO : {heroHP}\nBOSS : {bossHP}\n");
        }
        else if (bossHP < 0)
        {
          bossHP = 0;
          Console.WriteLine($"HERO : {heroHP}\nBOSS : {bossHP}\n");
        }
        break;
      }
    }


    Console.ReadLine();
  }
}
*/
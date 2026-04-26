using System;
using System.Collections.Generic;
using System.IO;  // StreamWriterを使うために必要
using System.Linq;
using System.Security.Cryptography.X509Certificates;

// 【TODO 1：インターフェースとポリモーフィズム】
// 武器の振る舞いを定義する IWeapon インターフェース（void Attack(); を持つ）と、
// それを実装して「剣で斬る！」と表示する Sword クラスを作成してください。
public interface IWeapon
{
  void Attack();
}

public class Sword : IWeapon
{
  public void Attack() => Console.WriteLine("剣で切る？");
}


public class Player
{

  public string Name { get; set; }

  private int _hp;
  public int HP
  {
    get => _hp;
    set
    {
      // 【TODO 2：カプセル化とガード句】
      // value（代入されようとしている値）が 0未満 の場合、
      // ArgumentOutOfRangeException をスローして不正な値を弾いてください。
      try
      {
        // 正解のガード句（不正なら throw new して即座に終了！）
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(nameof(value), "HPは0未満にできません");
        }
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.WriteLine($"error : {ex.Message}");
        throw;
      }

      _hp = value;
    }
  }

  public List<int> DamageHistory { get; set; } = new List<int>();
  private IWeapon _weapon;

  // コンストラクタ（依存性逆転）
  public Player(string name, IWeapon weapon)
  {
    Name = name;
    _weapon = weapon;
  }

  public void PerformAttack()
  {
    // 【TODO 1：続き】
    // 中身が剣か弓かを気にせず、装備している武器のAttackメソッドを呼び出してください。
    _weapon.Attack();
  }
}

public class Program
{
  // 【TODO 3：イベントとデリゲート】
  // 外部から上書きされないように保護された、Action型の OnQuestStart イベントを宣言してください。
  public static event Action? OnQuestStart;

  public static void Main()
  {
    // イベントへの処理の登録
    OnQuestStart += () => Console.WriteLine("【イベント】クエストに出発します！");

    StreamWriter sw = null; // ファイル操作用の変数

    try
    {
      // 【TODO 3：続き】イベントを安全に呼び出してください（null条件演算子を使用）。
      OnQuestStart?.Invoke();

      // ファイルを開く（ここでOSのリソースを掴むため「代償」が発生します）
      sw = new StreamWriter("quest_log.txt");
      sw.WriteLine("クエストログ開始");

      // プレイヤーの生成
      Player hero = new Player("勇者", new Sword());
      hero.HP = 100;
      hero.PerformAttack();

      // 【TODO 4：LINQ】
      hero.DamageHistory = new List<int> { 15, 0, 20, 5, 10 };
      // DamageHistory の中から「10以上」のダメージだけを抽出し、
      // 「大きい順（降順）」に並び替えてリスト化（ToList）する LINQ を書いてください。
      var heavyDamages = hero.DamageHistory
        .Where(s => s >= 10)
        .OrderByDescending(s => s)
        .ToList();

      Console.WriteLine("重傷履歴:");
      foreach (var dmg in heavyDamages) Console.WriteLine(dmg);

      sw.WriteLine("LINQの処理完了");

      // 【例外の発生】
      Console.WriteLine("毒の沼地に入った！HPにマイナスを代入します...");
      // ここでわざとマイナス値を入れて、TODO 2で作ったガード句のエラーを発生させます
      hero.HP = -10;

      // 上の行でエラーになり catch に飛ぶため、ここは絶対に実行されません
      sw.WriteLine("無事にクエストから帰還しました。");
    }
    catch (ArgumentOutOfRangeException ex)
    {
      // ガード句から投げられたエラーを捕まえる
      Console.WriteLine($"エラーを検知！ 不正なステータスです: {ex.Message}");
    }
    finally
    {
      // 【TODO 5：例外処理（finallyの真価）】
      // エラーが起きて処理が中断されても、必ずここを通ります。
      // StreamWriter (sw) が null でなければ、Dispose() メソッドを呼び出して
      // 確実にファイルを閉じ、OSにリソースを返却してください。

      if (sw != null)
      {
        sw.Dispose();
      }
    }
  }
}
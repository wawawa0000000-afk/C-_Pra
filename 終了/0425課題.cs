using System;

// 【抽象化・インターフェース分離】攻撃の振る舞いを定義するインターフェース
public interface IAttackBehavior
{
  void Attack();
}

// 【単一責任・オープンクローズド】攻撃の具体的な実装
public class SwordAttack : IAttackBehavior
{
  public void Attack() => Console.WriteLine("剣で斬る！");
}

public class BowAttack : IAttackBehavior
{
  public void Attack() => Console.WriteLine("弓で射る！");
}

public class MagicAttack : IAttackBehavior
{
  public void Attack() => Console.WriteLine("魔法を放つ！");
}

// Playerクラス
public class Player
{
  private IAttackBehavior _attackBehavior;

  public Player(IAttackBehavior attackBehavior)
  {
    _attackBehavior = attackBehavior;
  }

  public void PerformAttack()
  {
    _attackBehavior.Attack();
  }
}

public class Program
{
  public static void Main()
  {
    // 剣で攻撃するプレイヤーを作成
    Player swordMan = new Player(new SwordAttack());
    swordMan.PerformAttack(); // 出力: 剣で斬る！

    // 弓で攻撃するプレイヤーを作成
    Player bowMan = new Player(new BowAttack());
    bowMan.PerformAttack(); // 出力: 弓で射る！
  }
}
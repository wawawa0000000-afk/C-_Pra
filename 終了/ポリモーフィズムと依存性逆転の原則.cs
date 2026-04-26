using System;

// 攻撃の振る舞いを定義するインターフェース
public interface IAttackBehavior 
{
    void Attack();
}

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

public class Player
{
    // インターフェースに依存させる（継承より委譲）
    private IAttackBehavior _attackBehavior; 

    // コンストラクタ・インジェクション
    public Player(IAttackBehavior attackBehavior) 
    {
        _attackBehavior = attackBehavior;
    }

    public void PerformAttack() 
    {
        // メッセージ通信とポリモーフィズム
        _attackBehavior.Attack(); 
    }
}

public class Program
{
    public static void Main()
    {
        Player swordMan = new Player(new SwordAttack());
        swordMan.PerformAttack(); 

        Player bowMan = new Player(new BowAttack());
        bowMan.PerformAttack(); 
    }
} 
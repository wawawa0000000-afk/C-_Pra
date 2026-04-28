using System;
using System.Security.Cryptography.X509Certificates;

// ① IWeapon インターフェースを作る
public interface IWeapon
{
  void Attack();
}

// ② Sword と Bow を作る
public class Sword : IWeapon
{
  public void Attack() => Console.WriteLine("剣できる！");
}

public class Bow : IWeapon
{
  public void Attack() => Console.WriteLine("弓で射る！");
}
public class Player
{
  // ③-1 IWeapon を保持するフィールド
  private IWeapon _weapon;
  // ③-2 初期装備を受け取るコンストラクタ
  public Player(IWeapon weapon)
  {
    _weapon = weapon;
  }
  // ③-3 武器を持ち替えるメソッド (ChangeWeapon)
  public void ChangeWeapon(IWeapon newWepon)
  {
    _weapon = newWepon;
  }
  // ③-4 攻撃を実行するメソッド (PerformAttack)
  public void PerformAttack()
  {
    _weapon.Attack();
  }
}

public class Program
{
  public static void Main()
  {
    try
    {
      // ④ プレイヤーを生み出し、剣で攻撃 → 弓に持ち替えて攻撃 をテストする
      Player player = new Player(new Sword());
      player.PerformAttack();

      player.ChangeWeapon(new Bow());
      player.PerformAttack();

      Console.WriteLine("チェンジ成功");
    }
    catch//(何らかのガード句　変数)
    {
      //console.writeline($"error : {変数.message}");
    }
    finally
    {
      Console.WriteLine($"終わるよ");
    }
  }
}
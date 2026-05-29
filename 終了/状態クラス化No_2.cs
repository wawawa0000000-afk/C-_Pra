using System;

public interface IState
{
  void OnTurnStart(Character chara);
}

public class HealthyState : IState
{
  public void OnTurnStart(Character chara)
  {
    chara.HP += 50;
    Console.WriteLine($"{chara.Name}:{chara.HP}");
  }
}

public class PoisonState : IState
{
  public void OnTurnStart(Character chara)
  {
    chara.HP += -100;
    Console.WriteLine($"{chara.Name}:{chara.HP}");
    if(chara.HP <= 0)
    {
      chara.CurrentState = new DeadState();
    }
  }
}

public class DeadState : IState
{
  public void OnTurnStart(Character chara)
  {
    Console.WriteLine($"{chara.Name}は倒れている...");
  }
}

public class Character
{
  public string Name { get; set; }
  public int HP { get; set; }
  public IState CurrentState { get; set; }
  public void TakeTurn()
  {
    CurrentState.OnTurnStart(this);
  }
}

public class Program
{
  public static void Main()
  {
    Character player = new Character();
    player.Name= "アーサー";
    player.HP = 100;
    Console.WriteLine($"{player.Name}:{player.HP}");
    Console.WriteLine("---バトル開始---");

    player.CurrentState = new HealthyState();
    player.TakeTurn();

    player.CurrentState = new PoisonState();
    player.TakeTurn();
    player.TakeTurn();
    player.TakeTurn();
    
    Console.WriteLine("===バトル終了===");
    Console.WriteLine($"{player.Name}:{player.HP}");
  }
}
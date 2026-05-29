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
    chara.SendMessage($"{chara.Name}:{chara.HP}");
  }
}

public class PoisonState : IState
{
  public void OnTurnStart(Character chara)
  {
    chara.HP += -100;
    chara.SendMessage($"{chara.Name}:{chara.HP}");
    if (chara.HP <= 0)
    {
      chara.CurrentState = new DeadState();
    }
  }
}
public class DeadState : IState
{
  public void OnTurnStart(Character chara)
  {
    chara.SendMessage($"{chara.Name}は倒れている...");
  }
}

public class Character
{
  public event Action<string>? OnMessage;
  public string? Name { get; set; }
  public int HP { get; set; }
  public IState? CurrentState { get; set; }
  public void TakeTurn()
  {
    CurrentState?.OnTurnStart(this);
  }
  // event内からでも動かせるようになる
  public void SendMessage(string msg)
  {
    OnMessage?.Invoke(msg);
  }
}

public class Program
{
  public static void Main()
  {
    Character player = new Character();
    player.OnMessage += (msg) =>
    {
      if (msg.Contains(":"))
      {
        var parts = msg.Split(':');        // ["アーサー", "-50"] に分割
        int hp = int.Parse(parts[1]);      // "-50" → -50 に変換
        int displayHp = hp < 0 ? 0 : hp;  // マイナスなら0に補正
        Console.WriteLine($"{parts[0]}:{displayHp}");
      }
      else
      {
        Console.WriteLine(msg);  // 「倒れている...」はそのまま
      }
    };
    player.Name = "アーサー";
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
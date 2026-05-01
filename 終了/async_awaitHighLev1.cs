using System;

public interface IMagic
{
  string Name { get; }
  Task CastAsync();
}

public class FireBall : IMagic
{
  public string Name => "FireBall";
  // 波括弧 { } を使って2つの処理を順番に書く
  public async Task CastAsync()
  {
    await Task.Delay(1000);
    Console.WriteLine($"{Name}の詠唱完了！");
  }
  /*
  public async Task<string> CastAsync() => await Task.Delay(1000)
    ,Console.WriteLine($"{Name}の詠唱完了");
    */
}
public class Meteor : IMagic
{
  public string Name => "Meteor";
  // 波括弧 { } を使って2つの処理を順番に書く
  public async Task CastAsync()
  {
    await Task.Delay(1000);
    Console.WriteLine($"{Name}の詠唱完了！");
  }
  /*
  public async Task<string> CastAsync() => await Task.Delay(1000)
    ,Console.WriteLine($"{Name}の詠唱完了");
    */
}

public class Program
{
  public static async Task Main()
  {
    FireBall fireBall = new FireBall();
    Meteor meteor = new Meteor();

    Task fireballTask = fireBall.CastAsync();
    Task meteorTask = meteor.CastAsync();

    await Task.WhenAll(fireballTask, meteorTask);

    Console.WriteLine("すべての魔法が一斉に発動した！");
  }
}
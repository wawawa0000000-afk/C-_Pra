using System;
using System.Reactive.Linq;


public interface IMagic
{
  string Name { get; }
  IObservable<string> Cast();
}
public class Fireball : IMagic
{
  public string Name => "Fireball";
  public IObservable<string> Cast()
  {
    return Observable.Interval(TimeSpan.FromSeconds(1))
                     .Take(1)
                     .Select(_ => $"{Name}が発動した！");
  }
}
public class Meteor : IMagic
{
  public string Name => "Meteor";
  public IObservable<string> Cast()
  {
    return Observable.Interval(TimeSpan.FromSeconds(3))
                     .Take(1)
                     .Select(_ => $"{Name}が発動した！");
  }
}

public class Wizerd
{
  public void UseMagic(IMagic magic)
  {
    Console.WriteLine($"魔法使いは{magic.Name}の詠唱を始めた...");
    magic.Cast().Subscribe(
      magicMsg => Console.WriteLine(magicMsg)
    );
  }
}

public class Program
{
  public static void Main()
  {
    Wizerd wiz = new Wizerd();
    wiz.UseMagic(new Fireball());
    wiz.UseMagic(new Meteor());

    Console.ReadLine();
  }
}
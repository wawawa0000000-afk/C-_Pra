using System;
public class DeSub
{
  public static Action? OnDayPassed;
  public static void OldMain()
  {
    OnDayPassed += GrowCrap;

    Console.WriteLine("1日経過...");
    OnDayPassed?.Invoke();

    Console.WriteLine("1日経過...");
    Console.WriteLine("農作物を収穫した");
    OnDayPassed -= GrowCrap;

    Console.WriteLine("さらに1日経過...");
    OnDayPassed?.Invoke();
  }
  public static void GrowCrap()
  {
    Console.WriteLine("農作物が成長した");
  }
}
using System;

// 【1】乗り物のインターフェース IVehicle を作ってください。
// (戻り値なしの Run() というメソッドの契約だけを書きます)
public interface IVehicle
{
  void Run();
}


// 【2】IVehicle を実装する Car(車) と Bicycle(自転車) クラスを作ってください。
// (Run() を実装し、それぞれ "車が走る！"、"自転車が走る！" と出力させます)
public class Car : IVehicle
{
  public void Run() => Console.WriteLine("車が走る！");
}
public class Bicycle : IVehicle
{
  public void Run() => Console.WriteLine("自転車が走る！");
}

public class Driver
{
  private IVehicle _vehicle;

  // 【3】コンストラクタを作成し、引数で IVehicle を受け取ってください。

  public Driver(IVehicle vehicle)
  {
    // 【4】ガード句：もし受け取った vehicle が null だった場合、
    // ArgumentNullException を throw して即座に弾いてください。
    // ヒント: if (vehicle == null) { throw new ArgumentNullException(...); }
    if (vehicle == null) { throw new ArgumentNullException(); }
    //if (vehicle == null) { throw new ArgumentNullException(nameof(vehicle)); } <- こちらのほうが可読性があがってよろし
    _vehicle = vehicle;
  }

  public void PerformDrive()
  {
    _vehicle.Run();
  }
}

public class Program
{
  public static void Main()
  {
    try
    {
      Driver myDriver = new Driver(new Car());
      myDriver.PerformDrive();
      myDriver = new Driver(new Bicycle());
      myDriver.PerformDrive();
      Console.WriteLine("--- 次はnullを渡してみます ---");
      // 【5】わざとエラーを起こすため、Driverに null を渡してインスタンス化し、
      // PerformDrive() を呼び出してみてください。
      myDriver = new Driver(null);
      myDriver.PerformDrive();


    }
    catch (ArgumentNullException ex) // 【疑問の解決】ガード句が発動すると、ここに飛んできて変数exに入ります！
    {
      Console.WriteLine($"エラー検知 : {ex.Message}");
    }
    finally
    {
      Console.WriteLine("終わるよ");
    }
  }
}
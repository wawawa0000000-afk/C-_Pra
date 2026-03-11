using System;

public static class Buttle
{
  //public static Action? GameMain;
  public static async Task OldMain()
  {
    int[] Enemy = { 5, 10, 15 };
    int HeroHP = 20;
    int tern = 0;

    for (; ; )
    {
      tern = Start(tern, HeroHP);
      if (tern == -1) break;
      await Task.Delay(2000);
      Enemy = Attack(Enemy);
      await Task.Delay(2000);
      HeroHP = Defence(HeroHP);
      if (HeroHP <= 0)
      {
        for (int n = 0; n < 3; n++)
        {
          Console.Write(".");
          await Task.Delay(1000);
        }
        Console.WriteLine("目の前が真っ暗になった");
        break;
      }
      await Task.Delay(2000);
    }

    return;
  }

  public static event Action? StartScreen;
  //戦闘するかの選択
  public static int Start(int tern, int HeroHP)
  {
    Console.WriteLine($"ターン:{tern + 1}");
    Task.Delay(100);
    StartScreen += () => Console.WriteLine($"HP:{HeroHP}");
    StartScreen += () => Console.WriteLine("戦闘をしますか？\n\t\t\t(y:戦う)\n\t\t\t(n:逃げる)");
    StartScreen?.Invoke();
    StartScreen = null;

    string comand = Console.ReadLine() ?? "";

    if (comand == "y" || comand == "")
    {
      Console.WriteLine("はい");
      return tern += 1;
    }
    else if (comand == "n")
    {
      Console.WriteLine("いいえ");
      return tern = -1;
    }
    else
    {
      Console.WriteLine("コマンドが違います");
      return tern;
    }
  }

  public static event Action? ButtleScreen;
  //戦闘
  public static int[] Attack(int[] Enemy)
  {
    //桁指定
    string E1 = Enemy[0].ToString("D1");
    string E2 = Enemy[1].ToString("D2");
    string E3 = Enemy[2].ToString("D2");
    Task.Delay(2000);
    //戦闘前描画
    ButtleScreen += () => Console.WriteLine("-----   ------   -------"); Task.Delay(200);
    ButtleScreen += () => Console.WriteLine("*   *   *    *   *     *"); Task.Delay(200);
    ButtleScreen += () => Console.WriteLine($"* {E1} *   * {E2} *   *  {E3} *"); Task.Delay(200);
    ButtleScreen += () => Console.WriteLine("*   *   *    *   *     *"); Task.Delay(200);
    ButtleScreen += () => Console.WriteLine("=====   ======   =======");
    ButtleScreen?.Invoke();

    Task.Delay(300);
    Console.WriteLine("敵を選択してください: \t1\t2\t3");
    string Select = Console.ReadLine() ?? "";
    if (Select == "") Select = "1";

    //stringを配列に変換
    var NumAttack = Select
      .Split(' ')
      .Select(s => int.Parse(s))
      .Where(n => n > 0 || n < 4)
      .ToArray();

    int damX, damY, damTime;
    Random anyR = new Random();
    damX = anyR.Next(1, 6);
    damY = anyR.Next(1, 6);
    damTime = damX * damY;

    if (NumAttack[0] != 1 && NumAttack[0] != 2 && NumAttack[0] != 3)
    {
      Task.Delay(200);
      Console.WriteLine("その番号はありません");
      ButtleScreen = null;
      return Attack(Enemy);
    }
    else if (Enemy[NumAttack[0] - 1] <= 0)
    {
      Task.Delay(200);
      Console.WriteLine("その敵はもういません");
      ButtleScreen = null;
      return Attack(Enemy);
    }
    else
    {
      Enemy[NumAttack[0] - 1] -= damTime;
      Task.Delay(200);
      Console.WriteLine($"{NumAttack[0]}に{damTime}ダメージの攻撃");
      if (Enemy[NumAttack[0] - 1] < 0) Enemy[NumAttack[0] - 1] = 0;
    }

    //表記更新
    E1 = Enemy[0].ToString("D1");
    E2 = Enemy[1].ToString("D2");
    E3 = Enemy[2].ToString("D2");
    //戦闘後描画
    ButtleScreen?.Invoke();
    ButtleScreen = null;
    return Enemy;
  }

  public static int Defence(int HeroHP)
  {
    int _dam;
    Random anyR = new Random();
    _dam = anyR.Next(1, 6);

    Console.WriteLine($"Heroは{_dam}ダメージ受けた");
    return HeroHP - _dam;
  }
}
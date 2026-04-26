using System;

public class Player
{
    public string P_Name { get; set; }
    public int Level { get; set; }

    // メインのコンストラクタ
    public Player(string player, int level)
    {
        P_Name = player;
        Level = level;
    }
    
    // コンストラクタの連鎖（this）
    public Player(string player) : this (player, 1)
    {
    }
}

public class Weapon
{
    public string W_Name { get; set; }
    public int W_Power { get; set; }

    // メインのコンストラクタ
    public Weapon(string name, int power)
    {
        W_Name = name;
        W_Power = power;
    }

    // コンストラクタの連鎖（this）
    public Weapon(string name) : this(name, 10)
    {
    }
}

public class Program
{
    public static void Main()
    {
        Weapon sword = new Weapon("はがねのつるぎ", 30);
        Weapon stick = new Weapon("ひのきのぼう");

        Player Hero = new Player("さとし", 5);
        Player Sub = new Player("たけし");
        
        Console.WriteLine($"{Hero.P_Name}\nレベル : {Hero.Level}\n持ち物[{sword.W_Name} : 攻撃力 {sword.W_Power}]");
        Console.WriteLine($"{Sub.P_Name}\nレベル : {Sub.Level}\n持ち物[{stick.W_Name} : 攻撃力 {stick.W_Power}]");
    }
}
/*
using System;

public class Player
{
    public string P_Name { get; set; }
    public int Level { get; set; }

    public Player(string player, int level)
    {
        P_Name = player;
        Level = level;
    }
    
    public Player(string player) : this (player, 1)
    {
    }
}
public class Weapon
{
    public string W_Name { get; set; }
    public int W_Power { get; set; }

    // ① メインのコンストラクタ（ここで実際の初期化を行う）
    public Weapon(string name, int power)
    {
        W_Name = name;
        W_Power = power;
    }

    // ② 引数1つのコンストラクタ（thisを使って①を呼び出す）
    // 攻撃力を指定されなかった場合は、自動的に「10」にする
    public Weapon(string name) : this(name, 10)
    {
    }
}

public class Program
{
    public static void Main()
    {
        Weapon sword = new Weapon("はがねのつるぎ", 30); // ①が呼ばれる
        Weapon stick = new Weapon("ひのきのぼう");       // ②が呼ばれ、そこから①が呼ばれる

        Player Hero = new Player("さとし", 5);
        Player Sub = new Player("たけし");
        
        Console.WriteLine($"{Hero.P_Name}\nレベル : {Hero.Level}\n持ち物[{sword.W_Name} : 攻撃力 {sword.W_Power}]");
        Console.WriteLine($"{Sub.P_Name}\nレベル : {Sub.Level}\n持ち物[{stick.W_Name} : 攻撃力 {stick.W_Power}]");
    }
}*/
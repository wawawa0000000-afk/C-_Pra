using System;
using System.Linq;

public class Program
{
    public static async Task Main()
    {
        List<Monster> monsters = new List<Monster>
        {
            new Monster("スライム",30,5),
            new Monster("ゴブリン",50,12),
            new Monster("ドラゴン",200,45)
        };
        var AttackChar = monsters.Where(s => s.AttackPower >= 10).ToList();

        var output = await GetStrongestAsync(monsters);
        Console.WriteLine(output);

    }
    public static async Task<Monster> GetStrongestAsync(List<Monster> monsters)
    {
        await Task.Delay(100);
        return monsters.OrderByDescending(m => m.HP).First();
    }
}

public class Monster
{
    public string? Name { get; set; }
    public int HP { get; set; }
    public int AttackPower { get; set; }
    public Monster(string name, int hp, int attacP)
    {
        Name = name;
        HP = hp;
        AttackPower = attacP;
    }
    public override string ToString()
    {
        return $"{Name} (HP:{HP}, ATK:{AttackPower})";
    }
}
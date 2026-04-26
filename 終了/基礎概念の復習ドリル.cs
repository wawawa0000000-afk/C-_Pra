using System;
using System.Collections.Generic;
using System.Linq;

public class ReviewQuizzes
{
    // --- インターフェースとポリモーフィズム ---
    public interface IAnimal { void Speak(); }
    public class Dog : IAnimal { public void Speak() => Console.WriteLine("ワン！"); }
    public class PetOwner
    {
        private IAnimal _pet;
        public PetOwner(IAnimal pet) => _pet = pet;
        public void Play() => _pet.Speak(); 
    }

    // --- LINQ ---
    public static void LinqQuiz()
    {
        List<int> numbers = new List<int> { 1, 5, 8, 3, 10, 2 };
        var result = numbers
            .Where(n => n % 2 == 0)             // 抽出
            .OrderByDescending(n => n)          // 降順に並び替え
            .ToList();
    }

    // --- イベントとデリゲート ---
    public static event Action OnGameStart;
    public static void EventQuiz()
    {
        OnGameStart += () => Console.WriteLine("ゲームが開始されました！");
        OnGameStart?.Invoke();
    }
}
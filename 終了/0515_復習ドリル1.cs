using System;

// 【1】IAnimal というインターフェースを定義してください。
// （戻り値なしの Speak() というメソッドの「契約」だけを書きます）
public interface IAnimal
{
  void Speak();
}

// 【2】IAnimal を実装する Cat クラスを定義してください。
// （Speak() を実装し、Console.WriteLine で "ニャー！" と表示させます）
public class Cat : IAnimal
{
  public void Speak() => Console.WriteLine("ニャー！");
}

public class PetOwner
{
    // インターフェースを型として使うことで、どんな動物でも飼えるようにする！
    private IAnimal _pet;

    // 【3】PetOwner のコンストラクタを作成してください。
    // （引数で IAnimal を受け取り、フィールドの _pet に代入します）
    public PetOwner(IAnimal animal)
  {
    _pet = animal;
  }

    public void Play()
    {
        Console.WriteLine("飼い主はペットと遊んだ！");
        _pet.Speak(); // どんな動物が入っていても、その動物固有の鳴き声が出る（ポリモーフィズム）
    }
}

public class Program
{
    public static void Main()
    {
        // ここはコメントアウトを外すだけでOKです！
        PetOwner owner = new PetOwner(new Cat());
        owner.Play();
    }
}
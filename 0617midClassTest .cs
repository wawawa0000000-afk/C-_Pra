using System;

public interface Adventurer
{
  string Name { get; set; }
  string heroClass { get; set; }
  int Lev { get; set; }
  long HitP { get; set; }
}

public class Warrior : Adventurer
{
  public string Name { get; set; } = "Assor";
  public string heroClass { get; set; } = "Warrior";
  public int Lev { get; set; } = 30;
  public long HitP { get; set; } = 255;
}

public class Mage : Adventurer
{
  public string Name { get; set; } = "Marin";
  public string heroClass { get; set; } = "Mage";
  public int Lev { get; set; } = 27;
  public long HitP { get; set; } = 127;
}

public class Healer : Adventurer
{
  public string Name { get; set; } = "Antowanet";
  public string heroClass { get; set; } = "Healer";
  public int Lev { get; set; } = 29;
  public long HitP { get; set; } = 229;
}

public class Gild
{
  DataManager<Adventurer> book = new DataManager<Adventurer>();
  public event Action<string>? OnMessage;
  public void Register(int id, Adventurer adventurer)
  {
    book.Add(id, adventurer);
  }

  public void ShowAll()
  {
    foreach (var item in book.GetAll())
    {
      Console.WriteLine($"No.{item.Key} Name:{item.Value.Name} Class:{item.Value.heroClass} Lev:{item.Value.Lev} HP:{item.Value.HitP}");
    }
  }

  public Adventurer? GetAdventurer(int id)
  {
    if (book.TryGetValue(id, out Adventurer? adventurer))
      return adventurer;
    return null;
  }

  public void SendMessage(string msg)
  {
    OnMessage?.Invoke(msg);
  }
}

public class Quest
{
  DataManager<qLev> sLev = new DataManager<qLev>();

  public void SelectLev()
  {
    sLev.Add(1, new qLev { qName = "Easy", qDiffLev = 20, damMem = 10 });
    sLev.Add(2, new qLev { qName = "Normal", qDiffLev = 28, damMem = 30 });
    sLev.Add(3, new qLev { qName = "Hard", qDiffLev = 35, damMem = 60 });
  }

  public qLev? GetQuest(int id)
  {
    if (sLev.TryGetValue(id, out qLev? quest))
      return quest;
    return null;
  }
}

public class qLev
{
  public string? qName { get; set; }
  public int qDiffLev { get; set; }
  public int damMem { get; set; }
}

public class DataManager<T>
{
  Dictionary<int, T> data = new Dictionary<int, T>();

  public void Add(int id, T item) => data.Add(id, item);

  public bool TryGetValue(int id, out T? item) // 成功/失敗をboolで返す検索メソッド
  {
    bool found = data.TryGetValue(id, out item); // 検索結果をフラグに格納
    Console.WriteLine($"検索結果: {found}"); // フラグの値を確認
    return found; // フラグを呼び出し元に返す
  }

  public Dictionary<int, T> GetAll() => data;
}

public class Program
{
  public static void Main()
  {
    Gild gild = new Gild();
    Quest quest = new Quest();

    gild.OnMessage += (msg) => Console.WriteLine(msg);

    gild.Register(1, new Warrior());
    gild.Register(2, new Mage());
    gild.Register(3, new Healer());

    quest.SelectLev();

    Console.WriteLine("=== 冒険者ギルドへようこそ ===\n");
    gild.ShowAll();

    for (; ; )
    {
      Console.WriteLine("\nプレイヤーを選んで（1-3、それ以外で終了）");
      int.TryParse(Console.ReadLine(), out int G_input);
      if (G_input < 1 || G_input > 3) break;

      Adventurer? adventurer = gild.GetAdventurer(G_input);
      if (adventurer == null) break;

      if (adventurer.HitP <= 0)
      {
        gild.SendMessage($"{adventurer.Name}はHPが0のため出発できない！");
        continue;
      }

      Console.WriteLine("クエストを選んで（1:Easy 2:Normal 3:Hard）");
      int.TryParse(Console.ReadLine(), out int Q_input);
      if (Q_input < 1 || Q_input > 3) break;

      qLev? selectedQuest = quest.GetQuest(Q_input);
      if (selectedQuest == null) break;

      if (adventurer.Lev >= selectedQuest.qDiffLev)
      {
        adventurer.Lev += 1;
        gild.SendMessage($"{adventurer.Name}が{selectedQuest.qName}をクリア！ Lev:{adventurer.Lev}");
      }
      else
      {
        adventurer.HitP -= selectedQuest.damMem;
        gild.SendMessage($"{adventurer.Name}が{selectedQuest.qName}に失敗… HP:{adventurer.HitP}");
      }
    }

    Console.WriteLine("\n=== 最終結果 ===");
    gild.ShowAll();
  }
}
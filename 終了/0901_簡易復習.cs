public class Item
{
    // 読み取り専用ではなく、外部から取得・設定できるプロパティにする
    public string Name { get; set; }
    
    public int Price { get; set; }

    // コンストラクタ：Name と Price を受け取って初期化する
    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

List<Item> items = new List<Item>
{
    new Item("薬草", 50),
    new Item("エリクサー", 500),
    new Item("鉄の剣", 150)
};

// LINQを使って100以上のアイテムだけ取得
var expensiveItems = items.Where(i => i.Price >= 100).ToList();

public async Task<Item> GetItemByIdAsync(int id)
{
    // 本来はDBアクセスだが、ここでは疑似的に遅延を再現
    await Task.Delay(100);

    return items.FirstOrDefault(i => i.Id == id);
}


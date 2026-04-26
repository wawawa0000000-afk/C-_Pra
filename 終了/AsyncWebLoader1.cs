using System;
using System.Net.Http; // Web通信を行うための設計図
using System.Threading.Tasks;

public class Program
{
  // 【要件1】
  // Mainメソッドを「非同期」にするために、void ではなく Task を返すようにし、
  // async キーワードを追加してください。
  public static async Task Main()
  {
    Console.WriteLine("通信を開始します...");

    // 【要件2】
    // Web通信を行うための実体（インスタンス）を生成します。
    // using を使って、使い終わったら安全に破棄されるようにしてください。
    // （ヒント： var client = new HttpClient()）
    var client = new HttpClient();

    // 【要件3】
    // client.GetStringAsync("https://example.com"); を呼び出して、
    // 指定したURLのデータを取得します。
    // ※ここで絶対に「await」を使って、データが届くまで待機（ロード）させてください！
    // 取得したデータ（文字列）を変数 html に代入します。
    string html = await client.GetStringAsync("https://example.com");

    // 【要件4】
    // 無事にデータが届いたら、その文字数（html.Length）を
    // Console.WriteLine で表示してください。
    Console.WriteLine($"{html.Length}");

    Console.WriteLine("すべての通信が完了しました！");
  }
}
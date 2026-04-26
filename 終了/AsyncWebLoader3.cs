using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
  public static async Task Main()
  {
    using var client = new HttpClient();

    // 手癖4：通信などの「危険な処理」は try で囲む
    try
    {
      // わざと間違ったURL("https://example.com/notfound_error") から文字列を取得しようとして、エラーを起こす
      // 【ここに await を使った取得コードを書く。変数は string html など適当でOK】
      string html = await client.GetStringAsync("https://example.com/notfound_error");

      Console.WriteLine("取得成功！");
    }
    // 手癖5：Web通信のエラー(HttpRequestException)をキャッチする
    catch (HttpRequestException ex)
    {
      // 「通信エラーが発生しました！」と出力し、ex.Message も表示する
      // 【ここにコードを書く】
      Console.WriteLine("通信エラーが発生しました！");

      Console.WriteLine($"{ex.Message}");
    }
  }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
  public static async Task Main()
  {
    using var client = new HttpClient();

    try
    {
      Console.WriteLine("3匹のポケモンを同時に探しに行きます！...");

      Task<string> pokemon1 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/pikachu"); // ピカチュウ
      Task<string> pokemon2 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/snorlax"); // カビゴン
      Task<string> pokemon3 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/agumon"); // アグモン (error)

      Console.WriteLine("通信中...（3匹が同時に走っています！）");
      string[] results = await Task.WhenAll(pokemon1, pokemon2, pokemon3);
      Console.WriteLine($"ピカチュウのデータ量: {results[0].Length}\nミュウツーのデータ量{results[1].Length}\nカビゴンのデータ量{results[2].Length}");
      Console.WriteLine("すべての通信が完了しました！");
    }
    catch(HttpRequestException httpEx)
    {
      Console.WriteLine($"{httpEx.Message}");
      Console.WriteLine("通信がうまくつながりませんでした");
    }
  }
}
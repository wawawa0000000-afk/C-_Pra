using System;
using System.IO; // ファイル操作(File.WriteAllTextAsync)に必要
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
  public static async Task Main()
  {
    // さあ、すべての知識を総動員して、自らの手でファイルを生成してください！

    using var client = new HttpClient();
    try
    {
      Console.WriteLine("3匹のポケモンを同時に探しに行きます！...");

      Task<string> pika = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/pikachu");
      Task<string> kabi = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/snorlax");
      Task<string> myu2 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/mewtwo");

      Console.WriteLine("通信中...（3匹が同時に走っています！）");
      string[] result = await Task.WhenAll(pika, kabi, myu2);
      string allData = result[0] + result[1] + result[2];
      await File.WriteAllTextAsync("pokemon_data.txt", allData);
      Console.WriteLine("図鑑の作成が完了しました！");
    }
    catch (HttpRequestException HttpEx)
    {
      Console.WriteLine($"草むらからエラーが飛び出してきた！");
      Console.WriteLine($"error : {HttpEx.Message}");
    }
  }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
  // 手癖1：Mainメソッドを非同期(async Task)にする
  public static async Task Main()
  {
    Console.WriteLine("通信を開始します...");
    // 手癖2：通信クライアントを安全に準備する（using var を使う！）
    // 【ここにコードを書く】
    using var client = new HttpClient();

    // 手癖3：以下のURLから文字列を取得し、awaitで待機して 変数 pokemonData に入れる
    // URL: "https://pokeapi.co/api/v2/pokemon/pikachu"
    // 【ここにコードを書く】
    string pokemonData = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/pikachu");
    // 取得した文字列を表示する
    // Console.WriteLine(pokemonData);
    Console.WriteLine(pokemonData);
  }
}
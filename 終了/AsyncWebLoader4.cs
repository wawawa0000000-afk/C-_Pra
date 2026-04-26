using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        using var client = new HttpClient();

        Console.WriteLine("3匹のポケモンを同時に探しに行きます！...");

        // 【TODO 1：3つのタスクを「awaitを付けずに」スタートさせる】
        // 取得の指示だけを出して変数に保持します。awaitがないのでここで立ち止まりません。
        Task<string> task1 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/pikachu"); 
        Task<string> task2 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/mewtwo");  
        // カビゴン（snorlax）のタスク task3 を自分で書いてみてください。
        Task<string> task3 = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/snorlax");  
        
        Console.WriteLine("通信中...（3匹が同時に走っています！）");

        // 【TODO 2：Task.WhenAllを使って、全員が帰ってくるのを一気に待つ】
        // Task.WhenAll は、渡されたタスクがすべて完了したときに完了するタスクを返します。
        // ここで初めて await を使い、全員の結果を string 配列（文字列の配列）として受け取ります。
        // ヒント： string[] results = await Task.WhenAll(task1, task2, task3);
        string[] results = await Task.WhenAll(task1, task2, task3);
        

        // 【TODO 3：無事にすべて取得できたら、それぞれの文字数を表示する】
        // results配列には、task1, task2, task3 の順番で結果が入っています。
        // （例：Console.WriteLine($"ピカチュウのデータ量: {results.Length}"); ）
        Console.WriteLine($"ピカチュウのデータ量: {results[0].Length}\nミュウツーのデータ量{results[1].Length}\nカビゴンのデータ量{results[2].Length}");
        
        
        
        Console.WriteLine("すべての通信が完了しました！");
    }
}
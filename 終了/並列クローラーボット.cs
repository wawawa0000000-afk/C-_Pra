using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
  public static async Task Main()
  {
    try
    {
      using var client = new HttpClient();

      Task<string> task1 = client.GetStringAsync("https://example.com");
      Task<string> task2 = client.GetStringAsync("https://example.net");
      //Task<string> task3 = client.GetStringAsync("https://example.org/not_found_page");

      string[] TaskAll = await Task.WhenAll(task1, task2 );//,task3
      string HtmlString = TaskAll[0] + TaskAll[1];// + TaskAll[2]
      await File.WriteAllTextAsync("crawler_result.txt", HtmlString);
      Console.WriteLine("ファイルの保存が完了しました！");
    }
    catch (HttpRequestException HttpEx)
    {
      Console.WriteLine($"{HttpEx.Message}");
    }
  }
}
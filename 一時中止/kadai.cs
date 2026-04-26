using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Argo
{
  public static void Main()
  { 
    
  }
}

/*
//三項演算子
  public static void Main()
  { 
    StringBuilder sb = new StringBuilder();
    int money = 450, price = 900;
    int alpha = 45, beta = 92;
    var  userName = Console.ReadLine() ?? "null";

    var result = (money > price) ? "購入" : "お金が足りません";
    var steel = (alpha > beta) ? "盗めた" : "盗めなかった";
    var Name = (!string.IsNullOrEmpty(userName)) ? userName : "ゲスト";
    sb.AppendLine (result);
    sb.AppendLine (steel);
    sb.AppendLine ($"{Name}は追い出された");
      
    Console.WriteLine(sb.ToString());
  }

//課題３
正答
    public static void Main()
    {
        int n = 20; 
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= n; i++)
        {
            string result = "";
            if (i % 3 == 0) result += "Fizz";
            if (i % 5 == 0) result += "Buzz";

            // resultが空（どちらの倍数でもない）なら数字、そうでなければresultを入れる
            sb.AppendLine(string.IsNullOrEmpty(result) ? i.ToString() : result);
        }

        Console.WriteLine(sb.ToString());
    }
解答
    public static void Main()
    {
        int n = 20; 
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= n; i++)
        {
            const int s = 3, t = 5;
            bool Per3 = i % 3 == 0;
            bool Per5 = i % 5 == 0;
            if(Per3&&Per5)
            {
              sb.AppendLine("FizzBuzz");
            }
            else if(Per3)
            {
              sb.AppendLine("Fizz");
            }
            else if(Per5)
            {
              sb.AppendLine("Buzz");
            }
            else
            {
              sb.AppendLine($"{i}");
            }

        }

        Console.WriteLine(sb.ToString());
    }
//課題２
正答
        public static void Main()
    {
        int[] numbers = { 5, 2, 8, 2, 1, 5, 9 };

        bool hasDuplicate = numbers.Length != numbers.Distinct().Count();
        Console.WriteLine($"重複あり: {hasDuplicate}");

        int[] result = numbers.Distinct().OrderBy(n => n).ToArray();

        Console.WriteLine("ユニークな配列: " + string.Join(", ", result));
    }
    解答
    public static void Main()
    {
        int[] numbers = { 5, 2, 8, 2, 1, 5, 9 };
        
        // 配列からリストに変換（すでに数値なのでParseなどは不要）
        List<int> input = numbers.ToList();
        
        bool flg = false;
        
        // 二重ループで重複チェック
        for (int i = 0; i < input.Count; i++)
        {
            // j は i の次の要素から最後まで回す
            for (int j = i + 1; j < input.Count; j++)
            {
                if (input[i] == input[j])
                {
                    flg = true;
                    Console.WriteLine($"重複発見: インデックス {i} と {j} (値: {input[i]})");
                    input.RemoveAt(j);
                    j--;
                }
            }
        }

        // 最後にソート（小さい順に並び替え）
        input.Sort();

        // 結果表示
        Console.WriteLine($"重複あり: {flg}");
        Console.WriteLine("ユニークな配列: " + string.Join(", ", input));
    }

//課題１
public class Argo
{
  public static void OldMain()
  {
    string kadaibun = "Programing";
    for(int i = kadaibun.Length - 1; i >= 0; i--)
    {
      Console.Write(kadaibun[i]);
    }
    Console.WriteLine();

    int count = 0;
    List<char> vowels = new List<char> {'a','i','u','e','o'};

    foreach(char c in vowels) 
    {
      count++;
    }
    Console.WriteLine(count);
  }
}
*/
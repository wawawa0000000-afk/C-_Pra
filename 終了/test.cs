using System;
using System.Linq;

class Program
{
  static void Main()
  {
    int N, M;

    N = int.Parse(Console.ReadLine());
    M = int.Parse(Console.ReadLine());

    string? InputBox = Console.ReadLine();
    var itemBox = InputBox?
                  .Split(' ')
                  .Where(s => !string.IsNullOrWhiteSpace(s))
                  .Select(s => long.Parse(s))
                  .OrderBy(n => n)
                  .ToArray();

    int[,] DepriceTickets = new int[M,2];
    for (int i = 0; i < M; i++)
    {
      string InputDeprice = Console.ReadLine();
      var DePriceBox = InputDeprice?
                      .Split(' ')
                      .Where(s => !string.IsNullOrWhiteSpace(s))
                      .Select(s => int.Parse(s))
                      .ToArray();

      DepriceTickets[i,0] = DePriceBox[0];
      DepriceTickets[i,1] = DePriceBox[1];
    }

  }
}

/*
paiza さんは買い物に来ています。お店にある N 個の商品を買う予定で、i 番目の商品の値段は a_i 円です。
また、paiza さんは M 種類のクーポン券を保有しています。j 種類目のクーポンは一枚につき p_j 円割引でき、x_j 枚所持しています。
商品の値段を超えた額のクーポン券の使用によって商品の値段を 0 未満にすることはできません。その場合は0円となります。
また、一つの商品につきクーポン券は一枚のみ使用できます。

クーポン券を適切に使用し、全ての商品の支払い総額の最小値を出力してください。

N:商品の数 M:クーポンの種類
a_1 a_2 ... a_N それぞれの商品の値段
p_1 x_1　（クーポンの引き額　枚数）
p_2 x_2
...
p_M x_M
*/
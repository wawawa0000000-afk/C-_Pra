using System;
using System.Linq;

public class MainApp
{
  static int[] dx = { 0, 0, -1, 1 };
  static int[] dy = { -1, 1, 0, 0 };

  static int m, n;
  static int count = 0;
  static bool[,] visited;

  static public void Main()
  {
    var input = Console.ReadLine()!
                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();

    m = input[0];
    n = input[1];

    visited = new bool[m, n];

    visited[0, 0] = true;

    DFS(0, 0, 1);

    Console.WriteLine(count);
  }

  static void DFS(int x, int y, int visitedCount)
  {
    Console.WriteLine($"[DFS呼び出し] x={x}, y={y}, visitedCount={visitedCount}");

    if (visitedCount == m * n)
    {
      count++;
      return;
    }

    for (int i = 0; i < 4; i++)
    {
      int nx = x + dx[i];
      int ny = y + dy[i];

      if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny])
      {
        visited[nx, ny] = true;
        DFS(nx, ny, visitedCount + 1);

        visited[nx, ny] = false;
      }
    }
  }
}

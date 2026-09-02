using System;
using System.Collections.Generic;

public class MainApp
{
  static int[] dx = { 0, 0, -1, 1 };
  static int[] dy = { -1, 1, 0, 0 };

  static int m, n;
  static bool[,] visited;

  static public void Main()
  {
    m = 3;
    n = 3;
    visited = new bool[m, n];

    int result = BFS(0, 0, m - 1, n - 1); // (0,0)から(2,2)への最短歩数
    Console.WriteLine(result);
  }

  static int BFS(int startX, int startY, int goalX, int goalY)
  {
    // キュー: 「次に調べるべき場所」を順番に並べておく箱
    Queue<(int x, int y, int steps)> queue = new Queue<(int, int, int)>();

    queue.Enqueue((startX, startY, 0));
    visited[startX, startY] = true;

    while (queue.Count > 0)
    {
      var (x, y, steps) = queue.Dequeue();

      Console.WriteLine($"[BFS訪問] x={x}, y={y}, steps={steps}");

      if (x == goalX && y == goalY)
      {
        return steps; // ゴールに着いた時点で、それが最短歩数
      }

      for (int i = 0; i < 4; i++)
      {
        int nx = x + dx[i];
        int ny = y + dy[i];

        if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny])
        {
          visited[nx, ny] = true;
          queue.Enqueue((nx, ny, steps + 1)); // 次に調べる候補として「予約」しておく
        }
      }
    }

    return -1; // 辿り着けない場合
  }
}
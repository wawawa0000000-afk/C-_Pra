using System;

public static class PraClass
{
  public static void OldMain()
  {
    int c1 = new int(); // 0で初期化
    c1++;               // 1になる

    int c2 = c1;        // c1の「値(1)」をc2にコピー（これ以降、c1とc2は無関係）

    int c3 = new int(); // 0で初期化
    c3++;               // 1になる

    // 値（中身の数字）の比較：すべて「1」なので True
    Console.WriteLine(c1 == c2);
    Console.WriteLine(c2 == c3);
    Console.WriteLine(c3 == c1);

    // 参照の比較：値型を渡すと「その場で別々の箱(Boxing)」が作られる
    // 箱の住所を比べることになるため、たとえ中身が同じでもすべて False
    //Console.WriteLine(object.ReferenceEquals(c1, c2));
    //Console.WriteLine(object.ReferenceEquals(c1, c1));
  }
}
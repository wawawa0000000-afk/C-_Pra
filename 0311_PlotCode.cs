using System;
using System.IO.Compression;

public class Surveying
{
  private float? _altitude;
  // privateの値を代入する関数
  public void SetAltitude(float val)
  {
    // ここでチェック（検閲）ができる！
    if (val < -100 || val > 9000)
    {
      Console.WriteLine("エラー：その高さはあり得ません。");
      return; // 処理を中断して値をセットさせない
    }
    _altitude = val;
  }

  public void ShowStatus()
  {
    Console.WriteLine($"標高：{_altitude}");
  }

  public static void Main()
  {
    var p_test = new Surveying();
    // 正常値の代入
    p_test?.SetAltitude(100f);
    p_test?.ShowStatus();

    // 異常値の代入
    p_test?.SetAltitude(10000f);
    p_test?.ShowStatus();

    // 1. 変数を空っぽ（null）にする
    Surveying? p_empty = null;

    Console.WriteLine("--- Nullのテスト開始 ---");

    // 2. 普通ならエラーで落ちるはずの呼び出しを「?.」で行う
    p_empty?.ShowStatus(); 

    Console.WriteLine("プログラムは無事に終了しました。");
  }
}
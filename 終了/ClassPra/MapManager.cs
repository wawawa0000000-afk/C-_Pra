using System;
using System.Collections.Generic;
public class MapManager
{
  // 読み取り専用で公開し、追加はAddStakeメソッド経由のみにする
  private List<SurveyingStake> _stakeList = new List<SurveyingStake>();
  public IReadOnlyList<SurveyingStake> StakeList => _stakeList;
  public static void OldMain()
  {
    MapManager MMana = new MapManager();

    // ここが「値の送り出し」！
    MMana.AddStake(100f, 1);  // 1本目
    MMana.AddStake(10000f, 2); // 2本目（異常値）
    MMana.AddStake(-500f, 3);  // 3本目（異常値）
    MMana.AddStake(500f, 4);

    MMana.PrintMapSummary();
  }
  public void PrintMapSummary()
  {
    //変数sにStakeListを代入しその中の変数を確認する
    foreach (var s in StakeList)
    {
      Console.WriteLine($"ステータス: {s.Status}, 標高: {s.Altitude}m, ID: No.{s.Id}");
    }
  }
  public void AddStake(float altitude, int id)
  {
    // 1. 新しい杭の実体を作る
    SurveyingStake newStake = new SurveyingStake();

    // 2. 標高をセット（ここでプロパティ内のステータス判定が走る）
    newStake.Altitude = altitude;
    newStake.Id = id;

    // 3. リストに追加する
    _stakeList.Add(newStake);
  }
}
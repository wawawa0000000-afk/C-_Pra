using System;
using System.Collections.Generic;

public class SurveyingStake
{
  public enum StakeStatus { None, Confirmed, Error };
  public StakeStatus Status =>
    (!_altitudeValid && !_idValid) ? StakeStatus.None      // 未入力
    : (_altitudeValid && _idValid) ? StakeStatus.Confirmed  // 全部OK
    : StakeStatus.Error;                                    // 一部NG

  // ✅ 改善案：2つのフラグを別々に持つ
  private bool _altitudeValid = false;
  private bool _idValid = false;

  private float? _altitude;
  public float? Altitude
  {
    get => _altitude;
    set
    {
      _altitude = value;
      _altitudeValid = (value >= -100 && value <= 9000);
    }
  }
  private int _id;
  public int Id
  {
    get => _id;
    set
    {
      _id = value;
      _idValid = (value > 0);
    }
  }
}
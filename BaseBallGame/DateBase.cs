using System;

public class Datebase
{
  public List<string> Position = new List<string>{
    "ピッチャー",
    "キャッチャー",
    "ファースト",
    "セカンド",
    "サード",
    "ショート",
    "レフト",
    "センター",
    "ライト"
  };

  public List<string> PlayerName = new List<string>  {
    "（未登録）",    "（未登録）",    "（未登録）",
    "（未登録）",    "（未登録）",    "（未登録）",
    "（未登録）",    "（未登録）",    "（未登録）",
  };

  public List<float> HitAVG = new List<float>  {
    .000f,.000f,.000f,
    .000f,.000f,.000f,
    .000f,.000f,.000f
  };
}
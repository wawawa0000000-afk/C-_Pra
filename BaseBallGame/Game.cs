using System;
using System.Security.Cryptography.X509Certificates;

public class Game
{
  public static Screen GameScreen_ = new Screen();
  public static bool gameEnd;
  public static void Main()
  {
    for (;;)
    {
      GameScreen_.PlayScreen();
      if(gameEnd)
      {
        break;
      }
    }
    return;
    
  }
}
using System;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

public class Argo
{
  public static void Main()
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
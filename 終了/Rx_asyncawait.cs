using System;
using System.Threading.Tasks;
using System.Reactive.Linq;

// ==========================================
// 1. ポリモーフィズム（攻撃の部品）
// ==========================================
public interface IAttack
{
    string GetMessage();
}

public class HeroAttack : IAttack
{
    public string GetMessage() => "勇者の斬撃！";
}

public class BossAttack : IAttack
{
    public string GetMessage() => "魔王の破壊光線！";
}

public class Program
{
    public static async Task Main()
    {
        // ==========================================
        // 2. 準備フェーズ（Task × WhenAll）
        // ==========================================
        // 勇者の準備（1秒）
        Task heroTask = Task.Run(async () =>
        {
            await Task.Delay(1000);
            Console.WriteLine("勇者の準備完了！");
        });

        // 魔王の準備（2秒）
        Task bossTask = Task.Run(async () =>
        {
            await Task.Delay(2000);
            Console.WriteLine("魔王が姿を現した！");
        });

        // 両方の準備が完了するまで待機！
        await Task.WhenAll(heroTask, bossTask);
        Console.WriteLine("バトル開始！");


        // ==========================================
        // 3. 戦闘フェーズ（Rxストリーム × Merge）
        // ==========================================
        // 1秒ごとに勇者の攻撃が流れる川（3回）
        IObservable<IAttack> heroStream = Observable
            .Interval(TimeSpan.FromSeconds(1))
            .Take(3)
            .Select(_ => (IAttack)new HeroAttack());

        // 2秒ごとに魔王の攻撃が流れる川（2回）
        IObservable<IAttack> bossStream = Observable
            .Interval(TimeSpan.FromSeconds(2))
            .Take(2)
            .Select(_ => (IAttack)new BossAttack());

        // 2つの川を合流！
        IObservable<IAttack> battleStream = heroStream.Merge(bossStream);

        // 合流した川を購読して、届いたオブジェクトのメッセージを表示
        battleStream.Subscribe(
            attackObj => Console.WriteLine(attackObj.GetMessage())
        );

        // プログラムが終了しないように待機
        Console.ReadLine();
    }
}
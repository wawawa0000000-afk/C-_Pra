using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// =========================================================
// ① データモデル（状態を持つモノの設計図）
// =========================================================
public class Character
{
    public string Name { get; }
    public int HP { get; private set; }
    public int MaxHP { get; }
    public bool IsDead => HP <= 0; // プロの書き方：HPが0以下なら自動的にtrueを返すプロパティ

    // コンストラクタ引数で誕生時の安全を確保！
    public Character(string name, int hp)
    {
        Name = name;
        HP = hp;
        MaxHP = hp;
    }

    public void TakeDamage(int damage)
    {
        // 0未満にならないようにMath.Maxを使う
        HP = Math.Max(0, HP - damage);
    }
}

// =========================================================
// ② ゲームロジック（UIを持たず、計算と進行だけを行う支配者）
// =========================================================
public class BattleManager
{
    public Character Hero { get; private set; }
    public List<Character> Enemies { get; private set; }
    private readonly Random _rand = new Random();

    // ★イベント：UI側に「画面を更新して！」「メッセージを出して！」と伝えるための合図
    public event Action? OnScreenUpdate;
    public event Action<string>? OnMessage;

    public BattleManager()
    {
        Hero = new Character("ノボル", 20);
        // Listを使って敵を管理する（配列より柔軟！）
        Enemies = new List<Character>
        {
            new Character("敵1", 5),
            new Character("敵2", 10),
            new Character("敵3", 15)
        };
    }

    public async Task StartBattleAsync()
    {
        int turn = 1;

        // LINQの強力な魔法：ノボルが生きている ＆＆ 敵が1体でも生きていればループ継続
        while (!Hero.IsDead && Enemies.Any(e => !e.IsDead))
        {
            OnScreenUpdate?.Invoke(); // 画面の再描画を合図
            OnMessage?.Invoke($"\n=== ターン {turn} ===");
            await Task.Delay(1000);

            // 1. プレイヤーの行動選択
            bool isFighting = await ChooseActionAsync();
            if (!isFighting)
            {
                OnMessage?.Invoke($"{Hero.Name}は逃げ出した！");
                return; // バトル強制終了
            }

            // 2. プレイヤーの攻撃
            await PlayerAttackAsync();

            // 敵が全滅したかLINQでチェック
            if (Enemies.All(e => e.IsDead)) break;

            // 3. 敵の攻撃（生きている敵だけが反撃する）
            await EnemyAttackAsync();

            turn++;
            await Task.Delay(2000);
        }

        // --- 決着 ---
        OnScreenUpdate?.Invoke();
        if (Hero.IsDead)
        {
            OnMessage?.Invoke("......目の前が真っ暗になった。");
        }
        else
        {
            OnMessage?.Invoke("すべての敵を打ち倒した！");
        }
    }

    private async Task<bool> ChooseActionAsync()
    {
        while (true) // 正しい入力が来るまで無限ループ（再帰呼び出しを回避）
        {
            OnMessage?.Invoke("行動を選択してください (y:戦う / n:逃げる) > ");
            string input = Console.ReadLine()?.ToLower() ?? "";

            if (input == "y" || input == "") return true;
            if (input == "n") return false;
            
            OnMessage?.Invoke("コマンドが違います。");
        }
    }

    private async Task PlayerAttackAsync()
    {
        OnMessage?.Invoke("\n攻撃する敵の番号を入力してください (1, 2, 3) > ");
        int targetIndex = -1;

        // 入力チェック（プロはユーザーの入力を決して信用しない）
        while (true)
        {
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int num) && num >= 1 && num <= 3)
            {
                targetIndex = num - 1; // 配列のインデックスに合わせる
                if (!Enemies[targetIndex].IsDead)
                {
                    break; // 正しい入力で、かつ敵が生きていればループ脱出
                }
                OnMessage?.Invoke("その敵はすでに倒れています！別の番号を！ > ");
            }
            else
            {
                OnMessage?.Invoke("1〜3の正しい番号を入力してください > ");
            }
        }

        // サイコロ2つの掛け算（1～6が出るように Next(1, 7) に修正）
        int dice1 = _rand.Next(1, 7);
        int dice2 = _rand.Next(1, 7);
        int damage = dice1 * dice2;

        Character target = Enemies[targetIndex];
        OnMessage?.Invoke($"{Hero.Name}の攻撃！ (サイコロ: {dice1} × {dice2})");
        await Task.Delay(1000);

        target.TakeDamage(damage);
        OnMessage?.Invoke($"{target.Name}に {damage} のダメージ！");
    }

    private async Task EnemyAttackAsync()
    {
        OnMessage?.Invoke("\n--- 敵の反撃 ---");
        await Task.Delay(1000);

        // LINQで生きている敵だけを抽出してforeachで回す
        foreach (var enemy in Enemies.Where(e => !e.IsDead))
        {
            int damage = _rand.Next(1, 7);
            Hero.TakeDamage(damage);
            OnMessage?.Invoke($"{enemy.Name}の攻撃！ {Hero.Name}は {damage} のダメージを受けた！");
            await Task.Delay(1000);
            
            if (Hero.IsDead) break; // ノボルが倒れたら反撃ストップ
        }
    }
}

// =========================================================
// ③ 実行エントリーポイント ＆ UI（画面表示の担当）
// =========================================================
public class Program
{
    public static async Task OldMain()
    {
        BattleManager game = new BattleManager();

        // ★魔法の連携：裏側（ロジック）の合図と、表側（UI）の処理を接続する！
        // ロジックから「メッセージ出して！」と合図が来たら、Console.WriteLineを実行する
        game.OnMessage += (msg) => Console.WriteLine(msg);
        
        // ロジックから「画面更新して！」と合図が来たら、DrawScreenを実行する
        game.OnScreenUpdate += () => DrawScreen(game);

        // ゲームスタート
        await game.StartBattleAsync();
    }

    // 画面の描画を1つのメソッドに隔離（UIロジックの独立）
    private static void DrawScreen(BattleManager game)
    {
        Console.Clear(); // 画面を一度真っさらにする（プロのよくやるUIリセット）
        Console.WriteLine("=================================");
        
        // LINQを使って、敵のHP表示を生成
        var enemyHPs = game.Enemies.Select(e => e.IsDead ? " [×] " : $"[{e.HP:D2}]").ToArray();
        
        Console.WriteLine("-----   ------   -------");
        Console.WriteLine("* * * * * *");
        Console.WriteLine($"*{enemyHPs[0]}* *{enemyHPs[1]}* *{enemyHPs[2]}*");
        Console.WriteLine("* * * * * *");
        Console.WriteLine("=====   ======   =======");
        Console.WriteLine();
        Console.WriteLine($"【{game.Hero.Name}】 HP: {game.Hero.HP} / {game.Hero.MaxHP}");
        Console.WriteLine("=================================");
    }
}
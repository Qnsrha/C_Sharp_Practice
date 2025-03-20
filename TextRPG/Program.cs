
class FightUnit
{
    protected string NAME = "none";
    protected int HP = 50;
    protected int AT = 10;
    protected int MAXHP = 100;

    public void StatusRender()
    {
        Console.WriteLine(NAME + "-----------------------------------");
        Console.WriteLine("체력 : " + HP + "/" + MAXHP);
        Console.WriteLine("공격력 : " + AT);
        Console.WriteLine("--------------------------------------------");
    }

    public bool Damege(FightUnit _FightUnit)
    {        
        if (HP <=0)
        {
            return false;
        }

        _FightUnit.HP -= AT;

        Console.WriteLine(NAME + "가 " + AT + " 의 데미지를 입혔습니다.");

        if (_FightUnit.HP <= 0)
        {
            return true;
        }
        else 
        {
            
            return false;
        }
        

    }
}
class Player : FightUnit
{
    public Player()
    {
        NAME = "플레이어";
    }
    
    public void Rest()
    {
        HP = MAXHP;
    }

}

class Monster : FightUnit  
{
    public Monster()
    {
        NAME = "몬스터";
    }

}

enum STARTSELECT
{
    SELECTTOWN,
    SELECTBATTLE,
    NON
}

internal class Program
{

    static STARTSELECT StartSelect()
    {
        Console.Clear();
        Console.WriteLine("1. 마을");
        Console.WriteLine("2. 사냥터");


        ConsoleKeyInfo CKI = Console.ReadKey();
        Console.WriteLine("");
        switch (CKI.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine("마을로 이동");
                Console.ReadKey();
                return STARTSELECT.SELECTTOWN;
            case ConsoleKey.D2:
                Console.WriteLine("사냥터로 이동");
                Console.ReadKey();
                return STARTSELECT.SELECTBATTLE;
            default:
                Console.WriteLine("잘못된 선택");
                Console.ReadKey();
                return STARTSELECT.NON;
        }

    }
    static STARTSELECT Town(Player _Player)
    {
        while (true)
        {
            Console.Clear();
            _Player.StatusRender();

            Console.WriteLine("마을");
            Console.WriteLine("1. 체력회복");
            Console.WriteLine("2. 무기강화");
            Console.WriteLine("3. 나가기");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    _Player.Rest();
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    return STARTSELECT.NON;
            }
        }
    }

    static STARTSELECT Battle(Player _Player, Monster _Monster)
    {
        bool Die1 = false;
        bool Die2 = false;


        

        while (!(Die1 || Die2))
        {
            Console.Clear();
            _Player.StatusRender();
            _Monster.StatusRender();
            Console.ReadKey();

            Die1 = _Player.Damege(_Monster);
            Die2 = _Monster.Damege(_Player);
            Console.ReadKey();
        }
        if (Die1 == true)
        {
            Console.WriteLine("싸움 끝 플레이어의 승리");
        }
        else
        {
            Console.WriteLine("싸움 끝 몬스터의 승리");
        }
        Console.ReadKey();

        return STARTSELECT.T;

    }

    private static void Main(string[] args)
    {
        Player NewPlayer = new Player();
        Monster NewMonster = new Monster();

        STARTSELECT SelectCheck = STARTSELECT.NON;

        while (true)
        {
            switch (SelectCheck)
            {
                case STARTSELECT.SELECTTOWN:
                    SelectCheck = Town(NewPlayer);
                    break;
                case STARTSELECT.SELECTBATTLE:
                    SelectCheck = Battle(NewPlayer, NewMonster);
                    break;
                case STARTSELECT.NON:
                    SelectCheck = StartSelect();
                    break;
             }
        }
        
    }
}
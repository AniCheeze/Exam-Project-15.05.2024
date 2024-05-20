using System;
partial class Program
{
    public static void Main(string[] args)
    {
        int menu = 1;
        int menu1 = 1;
        bool lostgame = false;
        Zombie zombie = new Zombie();
        Skeleton skeleton = new Skeleton();
        List<Enemy> list = new List<Enemy>();
        list.Add(zombie);
        list.Add(skeleton);
        list.Add(zombie);
        Ogre ogre = new Ogre();
        Player P1 = new Player();
        string[] Nmaps = { "Холл", "Техническое помещение", "Буфет", "Комната" };
        string[] maps = { "|---&&---|\n|********|\n|********|\n#********#\n|********|\n|********|\n|********|\n#********#\n|***G****|\n----&&----","\n_________________\n|O***?******HHHH|\n|TTTTTTTTT******|\n|***********?***|\n|*T*****T**?**T*|\n|***?***********|\n|*T*****T*****T*|\n|**********?****|\n|*T**?**T*****T*|\n|***************|\n|*T***?*T****GT*|\n------------&----", "\n-----\n|**O|\n|***|\n|?**|\n|***|\n|**G|\n---&-", "\n_______\n|H*****H|\n|*******|\n|*******|\n|*******|\n|***?***|\n|*******|\n|***G***|\n---&---" };
        char[] Gmap = new char[150];
        while (menu != 0)
        {
            Console.WriteLine("1 - Начало игры, 2 - прокачка, 3 - информация, 4 - тест боя");
            try
            {
                menu = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
            }
            switch (menu)
            {
                case 1:
                    {
                        Map m = new Map();
                        Gmap = maps[0].ToCharArray();
                        Game(Gmap, P1, m, list, lostgame,maps);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Выберите стат для улучшения(1 - Здоровье, 2 - Урон, 3 - Защита, 4 - Удача) - ");
                        try
                        {
                            menu1 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Неверный ввод");
                        }
                        P1.Upgrade(menu1, P1.money);
                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 4:
                    P1.BattleInitiate(1, list, lostgame);
                    break;
                default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
            }
        }
    }
    public static void Game(char[] m, Player P1, Map map, List<Enemy> list, bool lostgame, string[] maps)
    {
        string GG,sim;
        int UpDoun=0, GameMenu; 
        while (P1.GetHP() > 0)
        {
            if (map.GetMapType() == 0)
            {
                UpDoun = 11;
            }
            else if (map.GetMapType() == 1)
            {
                UpDoun = 18;
            }
            else if (map.GetMapType() == 2)
            {
                UpDoun = 6;
            }
            else if (map.GetMapType() == 3)
            {
                UpDoun = 8;
            }
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write(m[i]);
            }
            Console.Write("\nВведите действие\n[1] - Вверх\n[2] - Влево\n[3] - Вниз\n[4] - Вправо\nВвод: ");
            GameMenu = Convert.ToInt32(Console.ReadLine());
            switch (GameMenu)
            {
                case 1:
                    {
                        for(int i = 0;i<m.Length;i++)
                        {
                            if (m[i] == 'G')
                            {
                                if (m[i - UpDoun]!= '-' && m[i - UpDoun] != '_' && m[i - UpDoun] != 'T' && m[i - UpDoun] != '&') {
                                    Console.WriteLine(UpDoun);
                                    m[i - UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i-UpDoun] == '&')
                                {
                                    map.ViborMap(maps, 0);
                                    m = maps[map.GetMapType()].ToCharArray();
                                }
                                else if (m[i - UpDoun] == 'O')
                                {
                                    P1.money += P1.rnd.Next(5);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else if(m[i - UpDoun] == '?')
                                {
                                    P1.BattleInitiate(1, list, lostgame);
                                }
                                else if(m[i - UpDoun] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                        }

                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < m.Length; i++)
                        {
                            if (m[i] == 'G')
                            {
                                if (m[i - 1] != '-' && m[i - 1] != '_' && m[i - 1] != 'T' && m[i - 1] != '|'&& m[i - 1] != '#')
                                {
                                    Console.WriteLine(UpDoun);
                                    m[i - 1] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i-1] == '#')
                                {
                                    map.ViborMap(maps,1);
                                    m = maps[map.GetMapType()].ToCharArray();
                                    break;
                                }
                                else if (m[i - 1] == 'O')
                                {
                                    P1.money += P1.rnd.Next(5);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else if (m[i - 1] == '?')
                                {
                                    P1.BattleInitiate(1, list, lostgame);
                                }
                                else if (m[i - 1] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < m.Length; i++)
                        {
                            if (m[i] == 'G')
                            {
                                if (m[i + UpDoun] != '-' && m[i + UpDoun] != '_' && m[i + UpDoun] != 'T' && m[i + UpDoun] != '&')
                                {
                                    Console.WriteLine(UpDoun);
                                    m[i + UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + UpDoun] == '&')
                                {
                                    map.ViborMap(maps, 0);
                                    m = maps[map.GetMapType()].ToCharArray();
                                }
                                else if (m[i + UpDoun] == 'O')
                                {
                                    P1.money += P1.rnd.Next(5);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else if (m[i + UpDoun] == '?')
                                {
                                    P1.BattleInitiate(1, list, lostgame);
                                }
                                else if (m[i + UpDoun] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < m.Length; i++)
                        {
                            if (m[i] == 'G')
                            {
                                if (m[i + 1] != '-' && m[i + 1] != '_' && m[i + 1] != 'T' && m[i + 1] != '|' && m[i + 1] != '#')
                                {
                                    Console.WriteLine(UpDoun);
                                    m[i + 1] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + 1] == '#')
                                {
                                    map.ViborMap(maps,1);
                                    m = maps[map.GetMapType()].ToCharArray();
                                }
                                else if (m[i + 1] == 'O')
                                {
                                    P1.money += P1.rnd.Next(5);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else if (m[i + 1] == '?')
                                {
                                    P1.BattleInitiate(1, list, lostgame);
                                }
                                else if (m[i + 1] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Знаеете кто вовсем виноват?\nЕвр...");
                        break;
                    }
            }
        }

        
    }
}

interface Enemy
{
    string name { get; set; }
    int hp { get; set; }
    int damage { get; set; }

    void GetDamage(int a);
    int ReturnDamage();
    int ReturnHp();
    void SetHp(int a);
    string ReturnName();
}
class Zombie : Enemy
{
    public string name { get; set; }
    public int hp { get; set; }
    public int damage { get; set; }

    public Zombie()
    {
        name = "Zombie";
        hp = 100;
        damage = 12;
    }

    public void GetDamage(int a)
    {
        hp -= a;
    }
    public int ReturnDamage()
    {
        return damage;
    }
    public int ReturnHp()
    {
        return hp;
    }
    public  void SetHp(int a)
    {
        hp = a;
    }
    public  string ReturnName()
    {
        return name;
    }
}
class Skeleton : Enemy
{
    public string name { get; set; }
    public int hp { get; set; }
    public int damage { get; set; }
    public Skeleton()
    {
        name = "Skeleton";
        hp = 60;
        damage = 20;
    }
    public void GetDamage(int a)
    {
        hp -= a;
    }
    public int ReturnDamage()
    {
        return damage;
    }
    public int ReturnHp()
    {
        return hp;
    }
    public void SetHp(int a)
    {
        hp = a;
    }
    public string ReturnName()
    {
        return name;
    }
}
class Ogre : Enemy
{
    public string name { get; set; }
    public int hp { get; set; }
    public int damage { get; set; }
    public Ogre()
    {
        name = "Ogre";
        hp = 180;
        damage = 25;
    }
    public void GetDamage(int a)
    {
        hp -= a;
    }
    public int ReturnDamage()
    {
        return damage;
    }
    public int ReturnHp()
    {
        return hp;
    }
    public void SetHp(int a)
    {
        hp = a;
    }
    public string ReturnName()
    {
        return name;
    }
}

class Map
{
    Random rnd = new Random();
    string map;
    int lvl;
    int type;
    public void ViborMap(string[] maps,int chis)
    {
        if (chis != 0)
        {
            type = rnd.Next(1, 3);
            map = maps[type];
        }
        else
        {
            type = 0;
        }
    }
    public int GetMapType() { return type; }
}
/*
Холл(Хохол)

/n|---&&---|
/n|********|
/n|********|
/n#********#
/n|********|
/n|********|
/n|********|
/n#********#
/n|***G****|
/n----&&----
*/
/*
Буфет
/n _______________
/n|O***?******HHHH|
/n|TTTTTTTTT******|
/n|***********?***|
/n|*T*****T**?**T*|
/n|***?***********|
/n|*T*****T*****T*|
/n|**********?****|
/n|*T**?**T*****T*|
/n|***************|
/n|*T***?*T****GT*|
/n------------&--
*/
/*
Тех помещение
/n -----
/n|**O|
/n|***|
/n|?**|
/n|***|
/n|**G|
/n---&-
*/
/*
Комната
/n _______
/n|H*****H|
/n|*******|
/n|*******|
/n|*******|
/n|***?***|
/n|*******|
/n|***G***|
/n ---&---
*/
class Player
{
    string name;
    int hp;
    int damage;
    int defense;
    public int money = 0;
    public Random rnd = new Random();
    //Если будет время
    int fortune;
    bool BO = false;
    Random rand = new Random();
    public Player()
    {
        name = "Player";
        hp = 100;
        damage = 15;
        defense = 10;
        fortune = 10;
    }
    public int ReturnDamage()
    {
        return damage;
    }
    public void Upgrade(int a, int money)
    {
        switch (a)
        {
            case 1:
                if (money >= 10)
                {
                    hp += 5;
                    money -= 10;
                }
                else
                {
                    Console.WriteLine("Ты бедность");
                }
                break;
            case 2:
                if (money >= 10)
                {
                    damage += 2;
                    money -= 10;
                }
                else
                {
                    Console.WriteLine("Ты бедность");
                }
                break;
            case 3:
                if (money >= 10)
                {
                    defense += 2;
                    money -= 10;
                }
                else
                {
                    Console.WriteLine("Ты бедность");
                }
                break;
            case 4:
                if (money >= 10)
                {
                    fortune += 2;
                    money -= 10;
                }
                else
                {
                    Console.WriteLine("Ты бедность");
                }
                break;
        }
    }
    public void GetDamage(int a)
    {
        hp -= (a - defense);
    }
    public int ReturnHp()
    {
        return hp;
    }
    public void SetHp(int a)
    {
        hp = a;
    }
    public void BattleInitiate(double modifier, List<Enemy> A, bool LG)
    {
        int BD;
        if(BO != true)
        {
            BD = rand.Next(2);
            switch (BD)
            {
                case 0:
                    while(BO != true)
                    {
                        Console.WriteLine($"Ваш противник - {A[BD].ReturnName}");
                        A[BD].GetDamage(damage);
                        Console.WriteLine($"Вы нанесли зомби {damage} ед урона");
                        GetDamage(A[BD].ReturnDamage());
                        Console.WriteLine($"Вы получили {A[BD].ReturnDamage() - defense} ");
                        if(A[BD].ReturnHp() <= 100)
                        {
                            Console.WriteLine("Вы победили");
                            BO = true;
                            A[BD].SetHp(100);
                        }
                        else if(ReturnHp() <= 100)
                        {
                            Console.WriteLine("Вы проиграли");
                            BO = true;
                            LG = true;
                            A[BD].SetHp(100);
                        }
                    }
                    break;

                case 1:
                    Console.WriteLine($"Ваш противник - {A[BD].ReturnName}");
                    A[BD].GetDamage(damage);
                    Console.WriteLine($"Вы нанесли зомби {damage} ед урона");
                    GetDamage(A[BD].ReturnDamage());
                    Console.WriteLine($"Вы получили {A[BD].ReturnDamage() - defense} ");
                    if (A[BD].ReturnHp() <= 100)
                    {
                        Console.WriteLine("Вы победили");
                        BO = true;
                        A[BD].SetHp(100);
                    }
                    else if (ReturnHp() <= 100)
                    {
                        Console.WriteLine("Вы проиграли");
                        BO = true;
                        LG = true;
                        A[BD].SetHp(100);
                    }
                    break;

                case 2:
                    Console.WriteLine($"Ваш противник - {A[BD].ReturnName}");
                    A[BD].GetDamage(damage);
                    Console.WriteLine($"Вы нанесли зомби {damage} ед урона");
                    GetDamage(A[BD].ReturnDamage());
                    Console.WriteLine($"Вы получили {A[BD].ReturnDamage() - defense} ");
                    if (A[BD].ReturnHp() <= 100)
                    {
                        Console.WriteLine("Вы победили");
                        BO = true;
                        A[BD].SetHp(100);
                    }
                    else if (ReturnHp() <= 100)
                    {
                        Console.WriteLine("Вы проиграли");
                        BO = true;
                        LG = true;
                        A[BD].SetHp(100);
                    }
                    break;
                default:
                        Console.WriteLine("Враг не найден");
                        break;
            }
        }
    }

    public int GetHP() { return hp; }
}

using System;
using static System.Net.Mime.MediaTypeNames;
partial class Program
{
    public static void Main(string[] args)
    {
        int menu = 1;
        bool lostgame = false;
        Zombie zombie = new Zombie();
        Skeleton skeleton = new Skeleton();
        Ogre ogre = new Ogre();
        List<Enemy> list = new List<Enemy>();
        list.Add(zombie);
        list.Add(skeleton);
        list.Add(ogre);
        Player P1 = new Player();
        string[] Nmaps = { "Холл", "Буфет", "Техническое помещение", "Комната" };
        string[] maps = { "|---&&---|\n|********|\n|********|\n#********#\n|********|\n|********|\n|********|\n#********#\n|***G****|\n----&&----","\n_________________\n|O***?******HHHH|\n|TTTTTTTTT******|\n|***********?***|\n|*T*****T**?**T*|\n|***?***********|\n|*T*****T*****T*|\n|**********?****|\n|*T**?**T*****T*|\n|***************|\n|*T***?*T****GT*|\n------------&----", "\n-----\n|**O|\n|***|\n|?**|\n|***|\n|**G|\n---&-", "\n_______\n|H*****H|\n|*******|\n|*******|\n|*******|\n|***?***|\n|*******|\n|***G***|\n---&---" };
        char[] Gmap = new char[150];
        while (menu != 0)
        {
            Console.Write("1 - Начало игры, 2 - информация, 3 - тест боя\nВвод: ");
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
                        Game(Gmap, P1, m, list, lostgame,maps,Nmaps);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine($"Имя: {P1.GetName()}\nхп: {P1.ReturnHp()}\nДеньги: {P1.GetMoney()}");
                        break;
                    }
                case 3:
                    BattleInitiate(1, list, lostgame, P1);
                    break;
                default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
            }
        }
    }

    public static void BattleInitiate(double modifier, List<Enemy> A, bool LG, Player P1)
    {
        int menuBT = 1;
        int BD;
        if (P1.BO != true)
        {
            BD = P1.rand.Next(3);
            switch (BD)
            {
                case 0:
                    while (P1.BO != true)
                    {
                        Console.WriteLine($"Ваш противник - зомби");
                        Console.WriteLine($"Ваше ХП - {P1.GetHP()}");
                        Console.WriteLine($"Здоровье противка {A[BD].ReturnHp()}");
                        Console.WriteLine("1 - Атака, 2 - Парирование, 3 - Побег\nВыберите действие - ");
                        try
                        {
                            menuBT = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        switch (menuBT)
                        {
                            case 1:
                                Console.WriteLine($"Вам нанесли {A[BD].ReturnDamage() - P1.ReturnDefence()}");
                                P1.GetDamage(A[BD].ReturnDamage());
                                Console.WriteLine($"Вы нанесли {P1.ReturnDamage()}");
                                A[BD].GetDamage(P1.ReturnDamage());
                                break;

                            case 2:
                                if(P1.rand.Next(100) < 50)
                                {
                                    Console.WriteLine("Вы успешно парировали атаку врага. + 15 ХП");
                                    P1.SetHp(P1.ReturnHp() + 15);
                                }
                                else
                                {
                                    Console.WriteLine("Провал");
                                    Console.WriteLine($"Вам нанесли {A[BD].ReturnDamage() - P1.ReturnDefence()}");
                                    P1.GetDamage(A[BD].ReturnDamage());
                                }
                                break;

                            case 3:
                                Console.WriteLine("Вы сбежали.");
                                P1.BO = true;
                                A[BD].SetHp(100);
                                break;

                            default:
                                Console.WriteLine("Ошибка ввода.");
                                break;
                        }
                        if (A[BD].ReturnHp() <= 0)
                        {
                            Console.WriteLine("Вы победили");
                            P1.BO = true;
                            A[BD].SetHp(100);
                        }
                        else if (P1.ReturnHp() <= 0)
                        {
                            Console.WriteLine("Вы проиграли");
                            P1.BO = true;
                            LG = true;
                            A[BD].SetHp(100);
                        }
                    }
                    break;

                case 1:
                    while (P1.BO != true)
                    {
                        Console.WriteLine($"Ваш противник - скелет");
                        Console.WriteLine($"Ваше ХП - {P1.GetHP()}");
                        Console.WriteLine($"Здоровье противка {A[BD].ReturnHp()}");
                        Console.WriteLine("1 - Атака, 2 - Парирование, 3 - Побег\nВыберите действие - ");
                        try
                        {
                            menuBT = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        switch (menuBT)
                        {
                            case 1:
                                Console.WriteLine($"Вам нанесли {A[BD].ReturnDamage() - P1.ReturnDefence()}");
                                P1.GetDamage(A[BD].ReturnDamage());
                                Console.WriteLine($"Вы нанесли {P1.ReturnDamage()}");
                                A[BD].GetDamage(P1.ReturnDamage());
                                break;

                            case 2:
                                if (P1.rand.Next(100) < 50)
                                {
                                    Console.WriteLine("Вы успешно парировали атаку врага. + 15 ХП");
                                    P1.SetHp(P1.ReturnHp() + 15);
                                }
                                else
                                {
                                    Console.WriteLine("Провал");
                                    Console.WriteLine($"Вам нанесли {A[BD].ReturnDamage() - P1.ReturnDefence()}");
                                    P1.GetDamage(A[BD].ReturnDamage());
                                }
                                break;

                            case 3:
                                Console.WriteLine("Вы сбежали.");
                                P1.BO = true;
                                A[BD].SetHp(100);
                                break;

                            default:
                                Console.WriteLine("Ошибка ввода.");
                                break;
                        }
                        if (A[BD].ReturnHp() <= 0)
                        {
                            Console.WriteLine("Вы победили");
                            P1.BO = true;
                            A[BD].SetHp(100);
                        }
                        else if (P1.ReturnHp() <= 0)
                        {
                            Console.WriteLine("Вы проиграли");
                            P1.BO = true;
                            LG = true;
                            A[BD].SetHp(100);
                        }
                    }
                    break;

                case 2:
                    while (P1.BO != true)
                    {
                        Console.WriteLine($"Ваш противник - Огр");
                        Console.WriteLine($"Ваше ХП - {P1.GetHP()}");
                        Console.WriteLine($"Здоровье противка {A[BD].ReturnHp()}");
                        Console.WriteLine("1 - Атака, 2 - Парирование, 3 - Побег\nВыберите действие - ");
                        try
                        {
                            menuBT = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        switch (menuBT)
                        {
                            case 1:
                                Console.WriteLine($"Вам нанесли {A[BD].ReturnDamage() - P1.ReturnDefence()}");
                                P1.GetDamage(A[BD].ReturnDamage());
                                Console.WriteLine($"Вы нанесли {P1.ReturnDamage()}");
                                A[BD].GetDamage(P1.ReturnDamage());
                                break;

                            case 2:
                                if (P1.rand.Next(100) < 50)
                                {
                                    Console.WriteLine("Вы успешно парировали атаку врага. + 15 ХП");
                                    P1.SetHp(P1.ReturnHp() + 15);
                                }
                                else
                                {
                                    Console.WriteLine("Провал");
                                    Console.WriteLine($"Вам нанесли {A[BD].ReturnDamage() - P1.ReturnDefence()}");
                                    P1.GetDamage(A[BD].ReturnDamage());
                                }
                                break;

                            case 3:
                                Console.WriteLine("Вы сбежали.");
                                P1.BO = true;
                                A[BD].SetHp(100);
                                break;

                            default:
                                Console.WriteLine("Ошибка ввода.");
                                break;
                        }
                        if (A[BD].ReturnHp() <= 0)
                        {
                            Console.WriteLine("Вы победили");
                            P1.BO = true;
                            A[BD].SetHp(100);
                        }
                        else if (P1.ReturnHp() <= 0)
                        {
                            Console.WriteLine("Вы проиграли");
                            P1.BO = true;
                            LG = true;
                            A[BD].SetHp(100);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Враг не найден");
                    break;
            }
        }
        P1.BO = false;
        LG = false;
    }
    public static void Game(char[] m, Player P1, Map map, List<Enemy> list, bool lostgame, string[] maps, string[] Nmaps)
    {
        string GG,sim;
        int UpDoun=0, GameMenu=0; 
        P1.NewHp();
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
            Console.WriteLine($"\nУровень: {map.GetLvl()}\n{Nmaps[map.GetMapType()]}");
            for (int i = 0; i < m.Length; i++)
                {
                    Console.Write(m[i]);
                }            
            Console.Write("\nВведите действие\n[1] - Вверх\n[2] - Влево\n[3] - Вниз\n[4] - Вправо\n[5] - Магазин прокачики\nВвод: ");
            try
            {
                GameMenu = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                GameMenu=-1;
            }
            switch (GameMenu)
            {
                case 1:
                    {
                        for (int i = 0; i < m.Length; i++)
                        {
                            if (m[i] == 'G')
                            {
                                if (m[i - UpDoun] != '-' && m[i - UpDoun] != '_' && m[i - UpDoun] != 'T' && m[i - UpDoun] != '&' && m[i - UpDoun] != 'O' && m[i - UpDoun] != '?' && m[i - UpDoun] != 'H')
                                {
                                    m[i - UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i - UpDoun] == '&')
                                {
                                    P1.NewHp();
                                    map++;
                                    map.ViborMap(maps, 0);
                                    m = maps[map.GetMapType()].ToCharArray();
                                }
                                else if (m[i - UpDoun] == 'O')
                                {
                                    P1.money += P1.rnd.Next(5);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                    m[i - UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i - UpDoun] == '?')
                                {
                                    BattleInitiate(1, list, lostgame, P1);
                                    m[i - UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i - UpDoun] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                    m[i - UpDoun] = 'G';
                                    m[i] = '*';
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
                                if (m[i - 1] != '-' && m[i - 1] != '_' && m[i - 1] != 'T' && m[i - 1] != '|'&& m[i - 1] != '#' && m[i - 1] != 'O' && m[i - 1] != '?' && m[i - 1] != 'H')
                                {
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
                                    BattleInitiate(1, list, lostgame, P1);
                                    m[i - 1] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i - 1] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                    m[i - 1] = 'G';
                                    m[i] = '*';
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
                                if (m[i + UpDoun] != '-' && m[i + UpDoun] != '_' && m[i + UpDoun] != 'T' && m[i + UpDoun] != '&' && m[i + UpDoun] != 'O' && m[i + UpDoun] != '?' && m[i + UpDoun] != 'H')
                                {
                                    m[i + UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + UpDoun] == '&')
                                {
                                    P1.NewHp();
                                    map++;
                                    map.ViborMap(maps, 0);
                                    m = maps[map.GetMapType()].ToCharArray();
                                    
                                }
                                else if (m[i + UpDoun] == 'O')
                                {
                                    P1.money += P1.rnd.Next(5);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                    m[i + UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + UpDoun] == '?')
                                {
                                    BattleInitiate(1, list, lostgame, P1);
                                    m[i + UpDoun] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + UpDoun] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                    m[i + UpDoun] = 'G';
                                    m[i] = '*';
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
                                if (m[i + 1] != '-' && m[i + 1] != '_' && m[i + 1] != 'T' && m[i + 1] != '|' && m[i + 1] != '#' && m[i + 1] != 'O' && m[i + 1] != '?' && m[i + 1] != 'H')
                                {
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
                                    m[i + 1] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + 1] == '?')
                                {
                                    BattleInitiate(1, list, lostgame, P1);
                                    m[i + 1] = 'G';
                                    m[i] = '*';
                                }
                                else if (m[i + 1] == 'H')
                                {
                                    P1.money += P1.rnd.Next(10);
                                    Console.WriteLine($"Вы получили монеты, у вас теперь - {P1.money} монет ");
                                    m[i + 1] = 'G';
                                    m[i] = '*';
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
                case 5:
                    {
                        Console.Write($"------------------Магазин \"Четкая вкусняшка\" приветсвут вас------------------\nУ вас монет:{P1.GetMoney()}\nВыберите стат для улучшения(Все по 10 монет):\n[1] - Здоровье\n[2] - Урон\n[3] - Защита\n[4] - Удача\nВвод: ");
                        try
                        {
                            GameMenu = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Знаеете кто вовсем виноват?\nЕвр...");
                        }
                        P1.Upgrade(GameMenu, P1.money);
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
    int lvl = 0;
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
    public static Map operator ++ (Map m)
    {
        m.lvl++;
        return m;
    }
    public int GetLvl() { return lvl; }
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

Тех помещение
/n -----
/n|**O|
/n|***|
/n|?**|
/n|***|
/n|**G|
/n---&-

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
    public bool BO = false;
    public Random rand = new Random();
    public Player()
    {
        name = "Player";
        hp = 100;
        damage = 15;
        defense = 10;
        fortune = 10;
    }
    public void NewHp()
    {
        hp = 100;
    }
    public int ReturnDamage(){ return damage; }
    public int ReturnDefence(){ return defense;}
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
    public int ReturnHp(){ return hp;}
    public void SetHp(int a)
    {
        hp = a;
    }
    public string GetName(){ return name;}
    public int GetHP() { return hp; }
    public int GetMoney() { return money;} 
}

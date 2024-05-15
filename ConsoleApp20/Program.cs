using System;
partial class Program
{
    public static void Main(string[] args)
    {
        int menu = 1;
        int menu1 = 1;
        int money = 0;
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
        string[] maps = { "|---&&---| |********| |********| #********# |********| |********| |********| #********# |***G****| ----&&----", " _________________ |O***?******HHHH| |TTTTTTTTT******| |***********?***| |*T*****T**?**T*| |***?***********| |*T*****T*****T*| |**********?****| |*T**?**T*****T*| |***************| |*T***?*T****GT*| ------------&----", " ----- |**O| |***| |?**| |***| |**G| ---&-", " _______ |H*****H| |*******| |*******| |*******| |***?***| |*******| |***G***| ---&---" };
        string[] Gmap = new string[150];
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
                        m.ViborMap(maps);
                        Gmap = m.CreateMap(Gmap);
                        Game(Gmap);
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
                        P1.Upgrade(menu1, money);
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
    public static void Game(string[] m)
    {
        foreach (string n in m)
        {
            Console.Write(n);
            Console.WriteLine();
        }
    }
}

class Enemy
{
    protected string name;
    protected int hp;
    protected int damage;

    public Enemy()
    {
        name = "Enemy";
        hp = 100;
        damage = 10;
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
class Zombie : Enemy
{
    public Zombie()
    {
        name = "Zombie";
        hp = 100;
        damage = 12;
    }
}
class Skeleton : Enemy
{
    public Skeleton()
    {
        name = "Skeleton";
        hp = 60;
        damage = 20;
    }
}
class Ogre : Enemy
{
    public Ogre()
    {
        name = "Ogre";
        hp = 180;
        damage = 25;
    }
}

class Map
{
    Random rnd = new Random();
    string map;
    int lvl;
    public Map()
    {

    }
    public void ViborMap(string[] maps)
    {
        map = maps[rnd.Next(0, 3)];
    }
    public string[] CreateMap(string[] m)
    {
        m = map.Split();
        return m;
    }
}
/*
Холл

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
}

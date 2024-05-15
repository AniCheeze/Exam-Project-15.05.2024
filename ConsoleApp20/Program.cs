using System;

class Program
{
    public static void Main(string[] args)
    {
        int menu = 1;
        int menu1 = 1;
        int money = 0;
        Player P1 = new Player();
        string[] Nmaps = { "Холл", "Техническое помещение", "Буфет", "Комната" };
        string[] maps = { "|---&&---| |********| |********| #********# |********| |********| |********| #********# |***G****| ----&&----", " _________________ |O***?******HHHH| |TTTTTTTTT******| |***********?***| |*T*****T**?**T*| |***?***********| |*T*****T*****T*| |**********?****| |*T**?**T*****T*| |***************| |*T***?*T****GT*| ------------&----", " ----- |**O| |***| |?**| |***| |**G| ---&-", " _______ |H*****H| |*******| |*******| |*******| |***?***| |*******| |***G***| ---&---" };
        string[] Gmap = new string[150];
        while (menu != 0)
        {
            Console.WriteLine("1 - Начало игры, 2 - прокачка, 3 - информация");
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
                        Game(Gmap, P1, m);
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
                default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
            }
        }
    }
    public static void Game(string[] m, Player P1, Map map)
    {
        string GG,sim;
        int UpDoun = 0, GameMenu;
        if (map.GetMapType() == 0)
        {
            UpDoun = 10;
        }
        else if (map.GetMapType() == 1)
        {
            UpDoun = 5;
        }
        else if (map.GetMapType() == 2)
        {
            UpDoun = 17;
        }
        else
        {
            Console.WriteLine("Знаеете кто вовсем виноват?\nЕвр...");
        }
        while (P1.GetHP() > 0)
        {
            foreach (string n in m)
            {
                Console.Write(n);
                Console.WriteLine();
            }
            Console.Write("Введите действие\n[1] - Вверх\n[2] - Влево\n[3] - Вниз\n[4] - Вправо\nВвод: ");
            GameMenu = Convert.ToInt32(Console.ReadLine());
            switch (GameMenu)
            {
                case 1:
                    {
                        for(int i = 0;i<m.Length;i++)
                        {
                            if (m[i] == "G")
                            {
                                if (m[i + UpDoun] != "|" || m[i + UpDoun] != "-" || m[i + UpDoun] != "_")
                                {
                                    m[i + UpDoun] = "G";
                                    m[i] = "*";
                                }
                                
                                break;

                            }
                        }

                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 4:
                    {

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
}
class Zombie : Enemy
{
    public Zombie()
    {
        name = "Zombie";
        hp = 100;
        damage = 10;
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
    int type;
    public void ViborMap(string[] maps)
    {
        type = rnd.Next(0, 3);
        map = maps[type];
    }
    public int GetMapType() { return type; }
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

    public Player()
    {
        name = "Player";
        hp = 100;
        damage = 10;
        defense = 10;
        fortune = 10;
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
    public int GetHP() { return hp; }
}

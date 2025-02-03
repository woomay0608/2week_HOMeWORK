using System.Text;
using System.Collections.Generic;
using static TextRPG.Program;

namespace TextRPG
{
    internal class Program
    {

        static void Main(string[] args)
        {
            String name;
            String Job;
            int j;



            Console.WriteLine("당신은 평범하게 길을 걷고 있다");
            Thread.Sleep(1000);
            Console.WriteLine("트럭이 미끄러지며 당신에게 맹렬히 돌진한다");
            Thread.Sleep(1000);
            Console.WriteLine("신님께서 사정을 살피시고 딱하게 여기셔서 이세계로 전생한다");
            Console.WriteLine("이름은:");
            name = Console.ReadLine();
            Console.WriteLine("직업을 결정해라");
            Console.WriteLine("1. 전사 2. 마법사 3. 궁수");
            j = int.Parse(Console.ReadLine());

            switch (j)
            {
                case 1:
                    Job = "전사";
                    Player player1 = new Player(name, Job);
                    player1.EquipItem[0] = new Weapon("철검", "기본적인 검이다", 2, "0");
                    Console.WriteLine("기본 장비:" + player1.EquipItem[0].ToString());
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.");
                    GoToVillage(player1);
                    break;
                case 2:
                    Job = "마법사";
                    Player player2 = new Player(name, Job);
                    player2.EquipItem[0] = new Weapon("지팡이", "기본적인 지팡이다", 2, "0");
                    Console.WriteLine("기본 장비:" + player2.EquipItem[0].ToString());
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.");
                    GoToVillage(player2);
                    break;
                case 3:
                    Job = "궁수";
                    Player player3 = new Player(name, Job);
                    player3.EquipItem[0] = new Weapon("활", "기본적인 활이다", 2, "0");
                    Console.WriteLine("기본 장비:" + player3.EquipItem[0].ToString());
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.\n");
                    GoToVillage(player3);
                    break;
            }


        }

        public static void GoToVillage(Player player)
        {
            bool Gameend = true;
            while (Gameend)
            {
                Console.WriteLine("촌장의 딸/ 앨리스");
                Console.WriteLine("\"안녕하세요, 모험가분이시라면 아래의 곳들을 둘러볼 수 있어요\"");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 가방 확인");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 여관(휴식)");
                Console.WriteLine("5. 던전");
                Console.WriteLine("6. 잠자기(저장 후 종료)");
                Console.WriteLine();
                Console.WriteLine("무엇을 할까?");
                int select = int.Parse(Console.ReadLine());

                switch (select) 
                {
                    case 1:
                        player.Status();
                        break;
                    case 2:
                        player.Inventory();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Gameend = false;
                        Console.WriteLine("오늘밤은 좋은 꿈을 꿀 것 같다.");
                        Thread.Sleep(1000);
                        Console.WriteLine("ZZZ");
                        Thread.Sleep(1000);
                        Console.WriteLine("ZZ");
                        Thread.Sleep(1000);
                        Console.WriteLine("Z");
                        break;

                }

            }


        }

        public void shop(Player player)
        {

        }

        public void Inn(Player player)
        {

        }
        public void Dungeon(Player player)
        {

        }


        public class Player
        { 

            private int level {  get; set; }
            private int health { get; set; }
            private int attack {  get; set; }
            private int defense { get; set; }
            private String name {  get; set; }
            private String Job { get; set; }
            private int Money { get; set; }

            public Item[] EquipItem = new Item[7]; //투구, 갑옷, 신발, 무기, 액세사리, 액세사리
            public Item[] NoEquip = new Item [20];//





            
            public Player(String n, String j) 
            {
                name = n;
                Job = j;
                level = 0;
                health = 100;
                attack = 10;
                defense = 5;
                Money = 1500;
            }

            public void Inventory()
            {

                    
                if (EquipItem != null)
                {for (int i = 0; i < EquipItem.Length; i++)
                    { if (EquipItem[i] != null)
                        { Console.WriteLine("[E]" + EquipItem[i].ToString()); } 
                    }
                }
                //전체 null체크 / 개별 null체크 / ToString
                if (NoEquip != null)
                {for (int i = 0; i < NoEquip.Length; i++)
                    { if (NoEquip[i] != null)
                        {Console.WriteLine(NoEquip.ToString());}
                    }
                }

                while (true);
                {
                    Console.WriteLine("");
                    
                }

            }

            public void Status()
            {
                Console.WriteLine($"Lv.{level}");
                Console.WriteLine("chad:" + Job );

                if (attack > 10)
                { Console.WriteLine($"공격력: {attack} + ({attack - 10})"); }
                else
                { Console.WriteLine($"공격력: {attack}"); }


                if (defense > 5)
                { Console.WriteLine($"방어력: {defense} + ({defense - 5})"); }
                else
                { Console.WriteLine($"방어력: {defense}"); }
                if (health > 100)
                { Console.WriteLine($"체력: {health} + ({health - 100})"); }
                else
                { Console.WriteLine($"체력: {defense}"); }
                Console.WriteLine($"돈: {Money}");
            }




        }

        public class Inventory
        {
            Weapon Weapon { get; set; }
            Head Head { get; set; }
            Armor Armor { get; set; } 
            Shoes  shoes { get; set; }
            Ring Ring { get; set; }
            Necklace Necklace { get; set; }



            public Inventory(Weapon weapon)
            {
                Weapon = weapon;
            }
            public Inventory(Head Head)
            {
                this.Head = Head;
            }
            public Inventory(Armor Armor)
            {
                this.Armor = Armor;
            }
            public Inventory(Shoes shoes)
            {
                this.shoes = shoes;
            }
            public Inventory(Ring Ring)
            {
                this.Ring = Ring;
            }
            public Inventory(Necklace Necklace)
            {
               this.Necklace = Necklace;
            }

        }


        public class Item
        {
            protected String itemname { get; set; }
            protected String itemdesc { get; set; }
            protected String itemMoney { get; set; }
        }
        public class Weapon : Item
        {
            private int itemability { get; set; }
            public Weapon(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append( "/").Append("공격력").Append( itemability).Append("/").Append( itemdesc).Append("/"); 
                String s = str.ToString();
                return s;
            }
        }
        public class Head : Item
        {
            private int itemability { get; set; }
            public Head(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("/").Append("방어력").Append(itemability).Append("/").Append(itemdesc).Append("/");
                String s = str.ToString();
                return s;
            }
        }
        public class Armor : Item
        {
            private int itemability { get; set; }
            public Armor(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("/").Append("방어력").Append(itemability).Append("/").Append(itemdesc).Append("/");
                String s = str.ToString();
                return s;
            }
        }
        public class Shoes : Item
        {
            private int itemability { get; set; }
            public Shoes(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("/").Append("방어력").Append(itemability).Append("/").Append(itemdesc).Append("/");
                String s = str.ToString();
                return s;
            }
        }
        public class Ring : Item
        {
            private int itemability { get; set; }
            public Ring(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("/").Append("체력").Append(itemability).Append("/").Append(itemdesc).Append("/");
                String s = str.ToString();
                return s;
            }
        }
        public class Necklace : Item
        {
            private int itemability { get; set; }
            public Necklace(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("/").Append("체력").Append(itemability).Append("/").Append(itemdesc).Append("/");
                String s = str.ToString();
                return s;
            }
        }








    }
}

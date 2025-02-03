using System.Text;
using System.Collections.Generic;
using static TextRPG.Program;
using System.Collections;


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
                    player1.currenthealth = player1.Maxhealth;
                    player1.useitem.Add(new Weapon("철검", "기본적인 검이다", 2, "0")); 
                    Console.WriteLine("기본 장비:" + player1.useitem[0].ToString());
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.");
                    GoToVillage(player1);
                    break;
                case 2:
                    Job = "마법사";
                    Player player2 = new Player(name, Job);
                    player2.currenthealth = player2.Maxhealth;
                    player2.useitem.Add(new Weapon("지팡이", "기본적인 지팡이다", 2, "0"));
                    Console.WriteLine("기본 장비:" + player2.useitem[0].ToString());
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.");
                    GoToVillage(player2);
                    break;
                case 3:
                    Job = "궁수";
                    Player player3 = new Player(name, Job);
                    player3.currenthealth = player3.Maxhealth;
                    player3.useitem.Add(new Weapon("활", "기본적인 활이다", 2, "0"));
                    Console.WriteLine("기본 장비:" + player3.useitem[0].ToString());
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.\n");
                    GoToVillage(player3);
                    
                    break;
            }


        }

        public static void GoToVillage(Player player)
        {



            //아이템들 적용시켜주기
            foreach (Item item in player.useitem)
            {
                if (item.itemtype.Equals("공"))
                {                
                    player.attack += item.itemability;
                }
                else if (item.itemtype.Equals("방"))
                {
                    
                    player.defense += item.itemability;
                }
                else if (item.itemtype.Equals("체"))
                {
                    
                    player.Maxhealth += item.itemability;
                }


            }
            bool Gameend = true;
            while (Gameend)
            {
               
                Console.WriteLine("[촌장의 딸/ 앨리스]");
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
                        Inn(player);
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
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;

                }

            }


        }

        public void shop(Player player)
        {
            
            

        }

        public static void Inn(Player player)
        {
            Console.Clear();
            Console.WriteLine("[촌장의 아내/ 베이지]");
            Console.WriteLine("\"모험가라면 잠시 쉬다가세요\"");
            if (player.Money < 500)
            {
                Console.WriteLine("돈이 쪼금 모자라네~");

            }
            else if (player.currenthealth == player.Maxhealth)
            {
                Console.WriteLine("몸이 멀쩡한 것 같은데?");
            }
            else
            {
                player.currenthealth += 50;
                if (player.currenthealth > player.Maxhealth)
                {
                    player.currenthealth = player.Maxhealth;
                }
                player.Money -= 500;
            }
        }
        public void Dungeon(Player player)
        {

        }


        public class Player
        { 

            public int level {  get; set; }
            public int Maxhealth { get; set; }
            public int currenthealth { get; set; }
            public int attack {  get; set; }
            public int defense { get; set; }
            public String name {  get; set; }
            public String Job { get; set; }
            public int Money { get; set; }

            //public Item[] EquipItem = new Item[7]; //투구, 갑옷, 신발, 무기, 액세사리, 액세사리
            //public Item[] NoEquip = new Item [20];//가방

            public List<Item> useitem = new List<Item>();
            public List<Item> nouseitem = new List<Item>();






            public Player(String n, String j) 
            {
                name = n;
                Job = j;
                level = 0;
                Maxhealth = 100;
                attack = 10;
                defense = 5;
                Money = 1500;
            }

            public void Inventory()
            {
                if (useitem.Count() == 0 && nouseitem.Count() == 0)
                {
                    Console.WriteLine("장비가 없습니다.");
                    Thread.Sleep(700);
                    Console.Clear();
                    GoToVillage(this);
                }

                if (useitem != null)
                {
                    for (int i = 0; i < useitem.Count(); i++)
                    {
                        
                        Console.WriteLine( "[E]" + useitem[i].ToString()); 
                    }
                }
              
                if (nouseitem != null)
                {
                    for (int i = 0; i < nouseitem.Count(); i++)
                    {
                        Console.WriteLine(nouseitem[i].ToString());
                    }
                }

                while (true)
                {
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("1. 장비 설정");
                    int s = int.Parse(Console.ReadLine());
                    if(s == 0)
                    {
                        GoToVillage(this);
                        
                    }
                    else if(s == 1)
                    {
                        
                        Console.Clear();
                        Change();
                    }
                    else { Console.WriteLine("잘못된 입력입니다."); }
                    
                    
                    
                }

                

            }
            public void Change()
            {
                
                

                while (true)
                {
                    int number = 1;
                    int nouse = nouseitem.Count();
                    int use = useitem.Count();
                    if (useitem != null)
                    {
                        for (int i = 0; i < use; i++)
                        {
                            if (useitem.Count > 0 && useitem[i] != null )
                            {
                                Console.WriteLine($"{number}. [E] {useitem[i].ToString()}");
                                number++;
                            }
                        }
                    }

                    
                    if (nouseitem != null)
                    {
                        for (int i = 0; i < nouse; i++)
                        {
                            if (nouseitem.Count > 0) 
                            {
                                Console.WriteLine($"{number}. {nouseitem[i].ToString()}");
                                number++;
                            } 
                        }
                    }



                    if (nouse > 20)
                    {
                        Console.WriteLine("가방 칸이 꽉찼습니다.");
                    }
                    
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("번호를 입력하면 장비가 장착/해제 됩니다.");
                    int s = int.Parse(Console.ReadLine());
                    Console.Clear();


                    if (s == 0)
                    {
                        Inventory();
                    }
                    else if (s > 0 && use >= s && use != 0) //장착에서 비장착
                    {

                        nouseitem.Add(useitem[s-1]);
                        useitem.RemoveAt(s-1);
                        
                    }
                    else if (use + nouse >= s && use < s) //비장착에서 장착
                    {
                        foreach(Item item in useitem)
                        {
                            if(item.GetType() == nouseitem[s-use].GetType())
                            {
                                Console.WriteLine("같은 종류의 장비를 장착중입니다.");
                                Change();
                            }
                        }
                        useitem.Add(nouseitem[s -use-1]);
                        nouseitem.RemoveAt(s-use-1);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        number = 1;
                    }
                }

            }

            public void Status()
            {
 

                Console.WriteLine(name);
                Console.WriteLine($"Lv.{level}");
                Console.WriteLine("chad:" + Job );

                if (attack > 10)
                { Console.WriteLine($"공격력: {attack} + ({attack-10l})"); }
                else
                { Console.WriteLine($"공격력: {attack}"); }
                if (defense > 5)
                { Console.WriteLine($"방어력: {defense} + ({defense-5})"); }
                else
                { Console.WriteLine($"방어력: {defense}"); }
                if (Maxhealth > 100)
                { Console.WriteLine($"최대체력: {Maxhealth} + ({Maxhealth-100})"); }
                else
                { Console.WriteLine($"최대체력: {Maxhealth}"); }
                Console.WriteLine($"현재체력: {currenthealth}");
                Console.WriteLine($"돈: {Money}");

                Console.WriteLine("0.나가기");
                
                String s = Console.ReadLine();
                if(s.Equals("0"))
                  {
                    Console.Clear();
                    GoToVillage(this); 
                }
                else { Console.WriteLine("잘못된 입력입니다."); }
            }
        }

        public class Item
        {
            protected String itemname;
            protected String itemdesc;
            protected String itemMoney;
            public String itemtype = "기본";
            public int itemability { get; set; }
        }
        public class Weapon : Item
        {
            
            
            public Weapon(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
                itemtype = "공";
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
           
            
            public Head(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
                itemtype = "방";
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
            
            
            public Armor(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
                itemtype = "방";
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
           
           
            public Shoes(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
                itemtype = "방";
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
         
            public Ring(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
                itemtype = "체";
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
            public Necklace(String n, String d, int a, String m)
            {
                itemname = n;
                itemdesc = d;
                itemability = a;
                itemMoney = m;
                itemtype = "체";
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

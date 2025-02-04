using System.Text;
using System.Collections.Generic;
using static TextRPG.Program;
using System.Collections;
using static Item.Item; //item.item. items 인데 생략하게 만들어줌
using static Play.Player;
using static GameManage.GameManager;
using Enemy;
using GameManage;


namespace TextRPG
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            GameManager GM = new GameManager();

            GM.GameStart();

           

        }

        public static void GoToVillage(Players player)
        {


            if (player.useitem != null)
            {
                //아이템들 적용시켜주기
                foreach (items item in player.useitem)
                {
                    player.attack = (float)(10 + (player.level *0.5));
                    player.defense = 5 + (player.level * 1);
                    player.Maxhealth = 100;
                    if (player.currenthealth > player.Maxhealth)
                    {
                        player.currenthealth = player.Maxhealth;
                    }

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

            }
            else
            {
                player.attack = 10;
                player.defense = 5;
                player.Maxhealth = 100;
            }

            bool Gameend = true;
            Death(player, Gameend);
            while (Gameend)
            {
                Console.Clear();
                Console.WriteLine("[촌장의 딸(소꿉친구)/ 앨리스]");
                Console.WriteLine($"\"안녕 {player.name}, 오늘은 뭐할거야?\"");
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
                        Maze.Dungeon(player);
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

        public void shop(Players player)
        {



        }

        public static void Inn(Players player)
        {

            while (true)
            {

                Console.WriteLine("[촌장의 아내/ 베이지]");
                Console.WriteLine($"\"{player.name}이 오랜만이네 조금 쉬다가렴~\"");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 쉬어가기");
                int j = int.Parse(Console.ReadLine());
                if (j == 1)
                {
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
                else if (j == 0) { GoToVillage(player); }
                else { Console.Clear(); Console.WriteLine("잘못된 입력입니다"); }
            }
        }
        

        public static void Death(Players player, bool Gameover)
        {
            if (player.currenthealth <= 0)
            {
                Console.WriteLine("눈 앞이 흐려진다");
                Console.WriteLine("오늘 밤은  악몽을 꿀 것 같다.");
                Thread.Sleep(1000);
                Console.WriteLine("ZZZ");
                Thread.Sleep(1000);
                Console.WriteLine("ZZ");
                Thread.Sleep(1000);
                Console.WriteLine("Z");
                Gameover = false;
            }
        }


        

       







    }
}

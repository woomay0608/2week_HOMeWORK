using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Play.Player;
using static TextRPG.Program;

namespace Enemy
{
    internal class Maze
    {
        public static void Dungeon(Players player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[촌장/ 그레이]");
                Console.WriteLine($"\"{player.name}던전에 도전할 생각이면 장비를 잘 갖추고 규칙을 숙지하렴\"");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 던전 규칙 보기");
                Console.WriteLine("2. 던전 들어가기");

                int j = int.Parse(Console.ReadLine());
                if (j == 1)
                {
                    Dungeonrule();
                }
                else if (j == 0)
                {
                    GoToVillage(player);
                }
                else if (j == 2)
                {
                    GotoDungeon(player);
                }
                else { Console.Clear(); Console.WriteLine("잘못된 입력입니다"); }

            }

        }
        public static void Dungeonrule()
        {
            Console.Clear();
            Console.WriteLine("던전의 난이도는 총 3개입니다.");

            Console.WriteLine("------------권장방어력------------");
            Console.WriteLine("던전마다 각 권장 방어력이 존재하고");
            Console.WriteLine("권장 방어력보다 낮거나 같다면 40%확률로 실패합니다.");
            Console.WriteLine("실패할 시 보상은 없습니다");
            Console.WriteLine("권장 방어력보다 높으면 무조건 성공합니다.");
            Console.WriteLine("던전을 클리어하던 실패하던 체력은 감소합니다.");
            Console.WriteLine("체력 감소 비율(랜덤): 20+(내 방어력 - 권장 방어력) ~ 35(내 방어력 - 권장 방어력)");


            Console.WriteLine("------------클리어 보상------------");
            Console.WriteLine("쉬움: 1000Gold, 일반: 1700Gold, 어려움: 2500G");
            Console.WriteLine("추가로 자기의 공격력에 따라서 추가 보상을 얻습니다.");
            Console.WriteLine("추가 보상 비율(랜덤): 공격력% ~ 공격력*2%");


        }

        public static void GotoDungeon(Players player)
        {


            Console.WriteLine("0. 나가기");
            Console.WriteLine($"1. 쉬움/방어력 5 이상/기본 보상:1000/ 공격력 추가 보상:{player.attack}%~{player.attack * 2}%");
            Console.WriteLine($"2. 보통/방어력 11 이상/기본 보상:1700/ 공격력 추가 보상:{player.attack}%~{player.attack * 2}%");
            Console.WriteLine($"3. 어려움/방어력 17 이상/기본 보상:2500/ 공격력 추가 보상:{player.attack}%~{player.attack * 2}%");
            int j = int.Parse(Console.ReadLine());
            if (j == 1)
            {
                DungeonTry(player, 5, 1);
            }
            else if (j == 2)
            {
                DungeonTry(player, 11, 2);
            }
            else if (j == 3)
            {
                DungeonTry(player, 17, 3);
            }
            else if (j == 0) { GoToVillage(player); }
            else { Console.Clear(); Console.WriteLine("잘못된 입력입니다"); }

        }


        public static void DungeonTry(Players player, int defense, int level)
        {
            Random ran = new Random();
            int winper = ran.Next(0, 5);
            int minushealth = ran.Next(20, 36);

            int plusMoney = 0;
            int ClearMoney = 0;
            switch (level)
            {
                case 1:
                    ClearMoney = 1000;
                    plusMoney = (ClearMoney * (ran.Next((int)player.attack, (int)player.attack * 2)) / 100);
                    break;
                case 2:
                    ClearMoney = 1700;
                    plusMoney = (ClearMoney * (ran.Next((int)player.attack, (int)player.attack * 2)) / 100);
                    break;
                case 3:
                    ClearMoney = 2500;
                    plusMoney = (ClearMoney * (ran.Next((int)player.attack, (int)player.attack * 2)) / 100);
                    break;
            }


            if (player.defense <= defense)
            {
                if (winper >= 0 && winper < 2)
                {
                    Console.WriteLine("던전 클리어!");
                    Console.WriteLine($"체력:{player.currenthealth}->{player.currenthealth - minushealth}\n " +
                        $"돈:{player.Money} ->{player.Money + ClearMoney + plusMoney}");
                    player.currenthealth -= minushealth;
                    player.Money += ClearMoney + plusMoney;
                    player.level += 1;


                    Console.WriteLine("0. 나가기");
                    int j = int.Parse(Console.ReadLine());
                    if (j == 0)
                    {
                        GoToVillage(player);
                    }

                }
                else
                {
                    Console.WriteLine("던전 패배");
                    Console.WriteLine($"체력:{player.currenthealth}->{player.currenthealth - minushealth}");
                    player.currenthealth -= minushealth;
                    Console.WriteLine("0. 나가기");
                    int j = int.Parse(Console.ReadLine());
                    if (j == 0)
                    {
                        GoToVillage(player);
                    }
                }
            }
            else
            {
                Console.WriteLine("던전 승리!");
                Console.WriteLine($"체력:{player.currenthealth}->{player.currenthealth - minushealth}\n " +
                        $"돈:{player.Money} ->{player.Money + ClearMoney + plusMoney}");
                player.Money += ClearMoney + plusMoney;
                player.level += 1;
 
                Console.WriteLine("0. 나가기");
                int j = int.Parse(Console.ReadLine());
                if (j == 0)
                {
                    GoToVillage(player);
                }
            }
        }
    }
}

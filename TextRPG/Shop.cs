using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Item.Item; //item.item. items 인데 생략하게 만들어줌
using static Play.Player;
using Enemy;
using GameManage;
using static TextRPG.Program;
using Play;

namespace TextRPG
{
    internal class Shop
    {

        //게임 매니저에 있는 리스트를 받고 배치를 해야함
        // tostring에 가격 붙여서

        public void SetItem(GameManager Gm)
        {


            List<List<items>> items = new List<List<items>>();

            items = Gm.ShopItem();

        }

        public void ShowItem(List<List<items>> items, Players player, int i)
        {
            int number = 0;

            List<items> onelist = new List<items>();
            List<items> twolist = new List<items>();
            List<items> Threelist = new List<items>();

            onelist = items[0];
            twolist = items[1];
            Threelist = items[2];

            Console.WriteLine($"현재 가진 골드:{player.Money}\n");


            if (player.level <= 1)
            {
                foreach (items item in onelist)
                {
                    Console.WriteLine($"{number}. {item.ToString}|{item.itemMoney}");

                }
            }
            if (player.level == 2)
            {
                foreach (items item in twolist)
                {
                    Console.WriteLine($"{number}. {item.ToString}|{item.itemMoney}");

                }
            }
            if (player.level == 3)
            {
                foreach (items item in Threelist)
                {
                    Console.WriteLine($"{number}. {item.ToString}|{item.itemMoney}");

                }
            }

            if (i == 1) //구매
            {
                Console.WriteLine();
                Console.WriteLine("구매할 번호를 선택해주세요");
                int ii = int.Parse(Console.ReadLine());

                if (player.level < 1 && i < 9)
                {
                    if (int.Parse(onelist[ii - 1].itemMoney) > player.Money || onelist[ii - 1].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하거나 돈이 부족합니다."); //오류 찾기
                    }


                    if (onelist[ii].GetType() == player.useitem[player.useitem.Count()].GetType())
                    {
                        player.nouseitem[player.nouseitem.Count()] = onelist[ii - 1];
                        Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                        onelist[ii - 1].itemMoney = "판매완료";
                    }
                    else
                    {
                        player.useitem[player.useitem.Count()] = onelist[ii - 1];
                        Console.WriteLine("장착 완료.");
                        onelist[ii - 1].itemMoney = "판매완료";
                    }
                }
                else if (player.level <= 2 && i > 8 && i < 17)
                {

                    if (int.Parse(twolist[ii - 9].itemMoney) > player.Money || twolist[ii - 9].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하거나 돈이 부족합니다.");
                    }
                    if (twolist[ii - 9].GetType() == player.useitem[player.useitem.Count()].GetType())
                    {
                        player.nouseitem[player.nouseitem.Count()] = twolist[ii - 9];
                        Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                        twolist[ii - 9].itemMoney = "판매완료";
                    }
                    else
                    {
                        player.useitem[player.useitem.Count()] = twolist[ii - 9];
                        Console.WriteLine("장착 완료.");
                        twolist[ii - 9].itemMoney = "판매완료";
                    }
                }
                else if (player.level <= 3 && i > 16 && i < 25)
                {

                    if (int.Parse(Threelist[ii - 17].itemMoney) > player.Money || Threelist[ii - 17].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하거나 돈이 부족합니다.");
                    }
                    if (Threelist[ii - 17].GetType() == player.useitem[player.useitem.Count()].GetType())
                    {
                        player.nouseitem[player.nouseitem.Count()] = Threelist[ii - 17];
                        Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                        Threelist[ii - 17].itemMoney = "판매완료";
                    }
                    else
                    {
                        player.useitem[player.useitem.Count()] = Threelist[ii - 17];
                        Console.WriteLine("장착 완료.");
                        Threelist[ii - 17].itemMoney = "판매완료";
                    }
                }
                else if (i == 2) //판매
                { }
                else if (i == 0) // 나가기
                {
                    GoToVillage(player);
                }
                else { Console.WriteLine("잘못된 입력입니다."); }





            }



            //구매
            //일단 돈을 보여주고
            //장착이 안된 장비라면 자동 장착 -> 검사를 해야한다
            //장착이 된 장비면 장착 안하는 장비칸으로


            //돈이 충분한가
            //이미 산 품목인가


            //판매
            //내가 입고있는거 or 벗은거
            //85%를 환불 받아요



        }
    }
}

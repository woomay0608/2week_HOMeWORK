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

namespace shopping;

internal class Shop
{

    public void ShowItem(List<List<items>> items, Players player, int i)
    {
        int number = 1;

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
                
                Console.WriteLine(number+". " +item.ToString() +item.itemMoney);
                number++;
            }
        }
        if (player.level == 2)
        {
            foreach (items item in twolist)
            {
                Console.WriteLine(number + ". " + item.ToString() + item.itemMoney);
                number++;
            }
        }
        if (player.level == 3)
        {
            foreach (items item in Threelist)
            {
                Console.WriteLine(number + ". " + item.ToString()  + item.itemMoney);
                number++;
            }
        }

        if (i == 1) //구매
        {
            Console.WriteLine();
            Console.WriteLine("구매할 번호를 선택해주세요");
            int ii = int.Parse(Console.ReadLine());

            if (player.level < 1 && ii < 9)
            {
                if (int.Parse(onelist[ii - 1].itemMoney) > player.Money || onelist[ii - 1].itemMoney.Equals("판매완료"))
                {
                    Console.WriteLine("이미 구매하거나 돈이 부족합니다."); //오류 찾기
                }
               if(player.useitem.Count() == 6 && player.nouseitem.Count() == 20)
               {
                    Console.WriteLine("가방이 꽉찼습니다.");
                }
                for (int iii = 0; iii < player.useitem.Count(); iii++)
                {
                    if (onelist[ii - 1].GetType() == player.useitem[iii].GetType()) //실수했다
                    {
                        player.nouseitem.Add(onelist[ii - 1]); 
                        Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                        onelist[ii - 1].itemMoney = "판매완료";
                    }
                }
                player.nouseitem.Add(onelist[ii - 1]);
                Console.WriteLine("장착 완료.");
                    onelist[ii - 1].itemMoney = "판매완료";
               
            }
            else if (player.level <= 2 && i > 8 && i < 17)
            {

                if (int.Parse(twolist[ii - 9].itemMoney) > player.Money || twolist[ii - 9].itemMoney.Equals("판매완료"))
                {
                    Console.WriteLine("이미 구매하거나 돈이 부족합니다.");
                }
                if (twolist[ii - 9].GetType() == player.useitem[player.useitem.Count()].GetType())
                {
                    player.nouseitem.Add(twolist[ii - 9]);
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
                    player.nouseitem.Add(Threelist[ii - 17]);
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
        }
        else if (i == 2) //판매
        { }
        else if (i == 0) // 나가기
        {
            GoToVillage(player);
        }
        else { Console.WriteLine("잘못된 입력입니다."); }







    }
}

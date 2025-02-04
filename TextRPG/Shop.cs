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
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace shopping;

internal class Shop
{

    public void ShowItem(List<List<items>> items, Players player, int i)
    {
        

        
        List<items> onelist = new List<items>();
        List<items> twolist = new List<items>();
        List<items> Threelist = new List<items>();

        onelist = items[0];
        twolist = items[1];
        Threelist = items[2];

        if (i == 1) //구매
        {
            Console.WriteLine($"현재 가진 골드:{player.Money}\n");
            while (true)
            {
                
                Show(player,items );
                Console.WriteLine();
                Console.WriteLine("구매할 번호를 선택해주세요");
                Console.WriteLine("0은 나가기");
                int ii = int.Parse(Console.ReadLine());

                if (player.level < 1 && ii < 9 && ii > 0)
                {
                    if(onelist[ii - 1].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하셨습니다.");
                        ShowItem(items, player, 1);
                    }
                    if (int.Parse(onelist[ii - 1].itemMoney) > player.Money)
                    {
                        Console.WriteLine("돈이 부족합니다.");
                        ShowItem(items, player, 1);
                    }
                    if (player.useitem.Count() == 6 && player.nouseitem.Count() == 20)
                    {
                        Console.WriteLine("가방이 꽉찼습니다.");//오류 찾기
                        ShowItem(items, player, 1);
                    }
                    for (int iii = 0; iii < player.useitem.Count(); iii++)
                    {
                        if (onelist[ii - 1].GetType() == player.useitem[iii].GetType())
                        {
                            player.nouseitem.Add(onelist[ii - 1]);
                            Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                            player.Money -= int.Parse(onelist[ii - 1].itemMoney);
                            onelist[ii - 1].itemMoney = "판매완료";
                            ShowItem(items, player, 1);
                            
                        }

                        
                    }
                    
                    player.useitem.Add(onelist[ii - 1]);
                    Console.WriteLine("장착 완료.");
                    player.Money -= int.Parse(onelist[ii - 1].itemMoney);
                    onelist[ii - 1].itemMoney = "판매완료";

                }
                else if (player.level <= 2 && i > 8 && i < 17)
                {

                    if (onelist[ii - 1].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하셨습니다.");
                        ShowItem(items, player, 1);
                    }
                    if (int.Parse(onelist[ii - 1].itemMoney) > player.Money)
                    {
                        Console.WriteLine("돈이 부족합니다.");
                        ShowItem(items, player, 1);
                    }
                    if (player.useitem.Count() == 6 && player.nouseitem.Count() == 20)
                    {
                        Console.WriteLine("가방이 꽉찼습니다.");//오류 찾기
                    }
                    for (int iii = 0; iii < player.useitem.Count(); iii++)
                    {
                        if (twolist[ii - 9].GetType() == player.useitem[iii].GetType())
                        {
                            player.nouseitem.Add(twolist[ii - 9]);
                            Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                            player.Money -= int.Parse(twolist[ii - 9].itemMoney);
                            twolist[ii - 9].itemMoney = "판매완료";
                            ShowItem(items, player, 1);
                        }
                    }
                    player.useitem.Add(twolist[ii - 9]);
                    Console.WriteLine("장착 완료.");
                    player.Money -= int.Parse(twolist[ii - 9].itemMoney);
                    twolist[ii - 9].itemMoney = "판매완료";
                }
                else if (player.level <= 3 && i > 16 && i < 25)
                {

                    if (onelist[ii - 1].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하셨습니다.");
                        ShowItem(items, player, 1);
                    }
                    if (int.Parse(onelist[ii - 1].itemMoney) > player.Money)
                    {
                        Console.WriteLine("돈이 부족합니다.");
                        ShowItem(items, player, 1);
                    }
                    if (player.useitem.Count() == 6 && player.nouseitem.Count() == 20)
                    {
                        Console.WriteLine("가방이 꽉찼습니다.");//오류 찾기
                    }
                    for (int iii = 0; iii < player.useitem.Count(); iii++)
                    {
                        if (Threelist[ii - 17].GetType() == player.useitem[iii].GetType())
                        {
                            player.nouseitem.Add(Threelist[ii - 17]);
                            Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");                    
                            player.Money -= int.Parse(Threelist[ii - 17].itemMoney);
                            Threelist[ii - 17].itemMoney = "판매완료";
                            ShowItem(items, player, 1);
                        }
                    }
                    player.useitem.Add(Threelist[ii - 17]);
                    Console.WriteLine("장착 완료.");
                    player.Money -= int.Parse(Threelist[ii - 17].itemMoney);
                    Threelist[ii - 17].itemMoney = "판매완료";
                }
                else if(ii == 0)
                {
                    shop(player);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
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
    public void Show(Players player, List<List<items>> items )
    {

        int number = 1;
        


        List<items> onelist = new List<items>();
        List<items> twolist = new List<items>();
        List<items> Threelist = new List<items>();

        onelist = items[0];
        twolist = items[1];
        Threelist = items[2];

        if (player.level <= 1)
        {
            foreach (items item in onelist)
            {

                Console.WriteLine(number + ". " + item.ToString() + item.itemMoney);
                number++;
            }
        }
        else if (player.level == 2)
        {
            foreach (items item in onelist)
            {

                Console.WriteLine(number + ". " + item.ToString() + item.itemMoney);
                number++;
            }
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
                Console.WriteLine(number + ". " + item.ToString() + item.itemMoney);
                number++;
            }
            foreach (items item in onelist)
            {

                Console.WriteLine(number + ". " + item.ToString() + item.itemMoney);
                number++;
            }
            foreach (items item in twolist)
            {
                Console.WriteLine(number + ". " + item.ToString() + item.itemMoney);
                number++;
            }
        }
    }
    
}

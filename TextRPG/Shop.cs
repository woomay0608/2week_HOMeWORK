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
        List<items> onelist = new List<items>(); //0~1레벨 아이템들
        List<items> twolist = new List<items>(); // 2레벨 아이템들
        List<items> Threelist = new List<items>(); // 3레벨 아이템들

        onelist = items[0];
        twolist = items[1];
        Threelist = items[2];

        if (i == 1) //구매를 입력했을 때
        {
            Console.WriteLine($"현재 가진 골드:{player.Money}\n");
            while (true)
            {

                Show(player, items);
                Console.WriteLine();
                Console.WriteLine("구매할 번호를 선택해주세요");
                Console.WriteLine("0은 나가기");
                int ii = int.Parse(Console.ReadLine());

                if (ii < 9 && ii > 0)
                {
                    if (onelist[ii - 1].itemMoney.Equals("판매완료")) //판매 완료면 오류 띄우기
                    {
                        Console.WriteLine("이미 구매하셨습니다.");
                        ShowItem(items, player, 1);
                    }
                    if (int.Parse(onelist[ii - 1].itemMoney) > player.Money)//돈 부족하면 오류 띄우기
                    {
                        Console.WriteLine("돈이 부족합니다.");
                        ShowItem(items, player, 1);
                    }
                    if (player.useitem.Count() == 6 && player.nouseitem.Count() == 20)//가방 꽉차면 오류 -> 논리 오류가 있음
                    {
                        Console.WriteLine("가방이 꽉찼습니다.");//오류 찾기
                        ShowItem(items, player, 1);
                    }
                    for (int iii = 0; iii < player.useitem.Count(); iii++)
                    {
                        //장비를 넣기 전에 그 타입의 장비가 없다면 장착을 바로 해야하기에 검사

                        if (onelist[ii - 1].GetType() == player.useitem[iii].GetType()) //같은 타입의 장비가 있으면 안되기에 검사
                        {
                            //있다면 사용하지 않는 장비 리스트로 넘겨주기
                            player.nouseitem.Add(onelist[ii - 1]);
                            Console.WriteLine("같은 장비를 착용중이라 가방으로 보내드렸습니다.");
                            player.Money -= int.Parse(onelist[ii - 1].itemMoney); //돈 깎기
                            onelist[ii - 1].itemMoney = "판매완료"; //판매완료로 만들어주기
                            ShowItem(items, player, 1);

                        }


                    }
                    //그 종류의 장비를 장착하지 않았다면 장착 장비로 보내기
                    player.useitem.Add(onelist[ii - 1]);
                    Console.WriteLine("장착 완료.");
                    player.Money -= int.Parse(onelist[ii - 1].itemMoney);
                    onelist[ii - 1].itemMoney = "판매완료";

                }// 158줄 까지 레벨에 따른 선택만 다름
                else if (ii > 8 && ii < 17)
                {
                    if (player.level <= 1)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        ShowItem(items, player, 1);
                    }

                    if (twolist[ii - 9].itemMoney.Equals("판매완료"))
                    {
                        Console.WriteLine("이미 구매하셨습니다.");
                        ShowItem(items, player, 1);
                    }
                    if (int.Parse(twolist[ii - 9].itemMoney) > player.Money)
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
                else if (ii > 16 && ii < 25)
                {
                    if (player.level <= 2)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        ShowItem(items, player, 1);
                    }

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
                else if (ii == 0)
                {//나가기
                    shop(player);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
        else if (i == 2) //판매 부분
        {
            while (true)
            {
                int number = 1;

                int use = player.useitem.Count(); //장착 장비 갯수
                int nouse = player.nouseitem.Count(); // 비장착 장비 갯수
                if (player.useitem != null)
                {
                    foreach (items item in player.useitem)
                    {
                        Console.WriteLine(number + ". [E]" + item.ToString() + item.OriginalMoney); //원래 돈 띄우기
                        number++;
                    }
                }
                else { Console.WriteLine("널임"); }
                if (player.nouseitem != null)
                {
                    foreach (items item in player.nouseitem)
                    {
                        Console.WriteLine(number + ". " + item.ToString() + item.OriginalMoney);
                        number++;
                    }
                }
                else { Console.WriteLine("널임"); }

                Console.WriteLine();
                Console.WriteLine("판매할 장비의 번호를 선택해주세요");
                Console.WriteLine("0은 나가기");
                int ii = int.Parse(Console.ReadLine());
                if (ii == 0) { shop(player); }
                else if (ii <= use && 0 < ii) // 1번부터 장착한장비의 갯수면 -> 장착한 장비면
                {
                    player.Money += (85/100)*int.Parse(player.useitem[ii - 1].OriginalMoney); //돈을 얻고
                    player.useitem[ii - 1].itemMoney = player.useitem[ii - 1].OriginalMoney; //판매완료 -> 다시 돈으로
                    Console.WriteLine("판매 성공");
                    Console.WriteLine($"돈 {player.Money - int.Parse(player.useitem[ii - 1].OriginalMoney)} ->{player.Money}");
                    player.useitem.RemoveAt(ii - 1); //삭제
                   

                }
                else if (ii > use && ii <= use + nouse)//장착한 장비 ~ 비장착 장비 갯수 + 장착장비 갯수 -> 비장착 장비면
                {
                    player.Money += (85 / 100) * int.Parse(player.nouseitem[ii - use - 1].OriginalMoney);
                    player.nouseitem[ii - use - 1].itemMoney = player.nouseitem[ii - use - 1].OriginalMoney;
                    Console.WriteLine("판매 성공");
                    Console.WriteLine($"돈 {player.Money - int.Parse(player.nouseitem[ii - use - 1].OriginalMoney)} ->{player.Money}");
                    player.nouseitem.RemoveAt(ii - use - 1);
                   
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

        }
        else if (i == 0) // 나가기
        {
            GoToVillage(player);
        }
        else { Console.WriteLine("잘못된 입력입니다."); }
    }
    public void Show(Players player, List<List<items>> items )
    {
        //단순히 상품들 보여주는 메소드
        //단순히 상품들 보여주는 메소드



        int number = 1;
        


        List<items> onelist = new List<items>();
        List<items> twolist = new List<items>();
        List<items> Threelist = new List<items>();

        onelist = items[0];
        twolist = items[1];
        Threelist = items[2];
        //레벨에 따라 추가
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

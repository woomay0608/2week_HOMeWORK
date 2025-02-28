﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Item.Item;

using static TextRPG.Program;

namespace Play
{
    internal class Player
    {
        public class Players
        {

            public int level { get; set; }
            public int Maxhealth { get; set; }
            public int currenthealth { get; set; }
            public float attack { get; set; }
            public int defense { get; set; }
            public String name { get; set; }
            public String Job { get; set; }
            public int Money { get; set; }

            //public Item[] EquipItem = new Item[7]; //투구, 갑옷, 신발, 무기, 액세사리, 액세사리
            //public Item[] NoEquip = new Item [20];//가방

            public List<items> useitem = new List<items>();//장착 중인 장비
            public List<items> nouseitem = new List<items>(); // 장착하지 않은 장비






            public Players(String n)
            {
                name = n; //이름
                Job = "dd"; //직업
                level = 0; //레벨
                Maxhealth = 100; //최대 체력
                attack = 10; //공격력
                defense = 5; //방어력
                Money = 1500; //돈
                
            }

            public void Inventory() //장비를 보여주는 메소드
            {
                if (useitem.Count() == 0 && nouseitem.Count() == 0)//장비가 없을 때
                {
                    Console.WriteLine("장비가 없습니다.");
                    Thread.Sleep(700);
                    Console.Clear();
                    GoToVillage(this);
                }

                if (useitem != null) //널검사후 보여주기
                {
                    for (int i = 0; i < useitem.Count(); i++)
                    {

                        Console.WriteLine("[E]" + useitem[i].ToString());
                    }
                }

                if (nouseitem != null)//널검사후 보여주기
                {
                    for (int i = 0; i < nouseitem.Count(); i++)
                    {
                        Console.WriteLine(nouseitem[i].ToString());
                    }
                }

                while (true)
                {
                    //장비 설정 할지 말지 입력받기
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("1. 장비 설정");
                    int s = int.Parse(Console.ReadLine());
                    if (s == 0)
                    {
                        GoToVillage(this);

                    }
                    else if (s == 1)
                    {

                        Console.Clear();
                        Change();
                    }
                    else { Console.WriteLine("잘못된 입력입니다."); }



                }



            }
            public void Change() 
            {
                //장비를 바꾸는 메소드


                while (true)
                {
                    int number = 1; //장비 앞에 번호 달기
                    int nouse = nouseitem.Count(); //안쓴 장비 갯수
                    int use = useitem.Count(); //장비 갯수

                    //장비 보여주기 번호 + 장비
                    if (useitem != null)
                    {
                        for (int i = 0; i < use; i++)
                        {
                            if (useitem.Count > 0 && useitem[i] != null)
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


                    //가방이 꽉차면 오류
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
                        Inventory();//나가면 다시 아이템 보여주기
                    }
                    else if (s > 0 && use >= s && use != 0) //장착에서 비장착
                    {

                        nouseitem.Add(useitem[s - 1]); // 장착에서 -> 비장착
                        useitem.RemoveAt(s - 1); // 장착에서 지우기


                    }
                    else if (use + nouse >= s && use < s) //비장착에서 장착
                    {
                        foreach (items item in useitem)
                        {
                            if (item.GetType() == nouseitem[s - use-1].GetType()) //같은 장비가 있다면 리턴
                            {
                                Console.WriteLine("같은 종류의 장비를 장착중입니다.");
                                Change();
                            }
                        }
                        useitem.Add(nouseitem[s - use-1]); //비장착 -> 장착
                        nouseitem.RemoveAt(s - use-1); //비장착에서 지우기
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
                Console.WriteLine("chad:" + Job);

                if (attack > 10)
                { Console.WriteLine($"공격력: {attack} + ({attack - 10})"); } // 추가 능력치 있을때만 능력치 + 추가 능력치 띄우기
                else
                { Console.WriteLine($"공격력: {attack}"); }
                if (defense > 5)
                { Console.WriteLine($"방어력: {defense} + ({defense - 5})"); }
                else
                { Console.WriteLine($"방어력: {defense}"); }
                if (Maxhealth > 100)
                { Console.WriteLine($"최대체력: {Maxhealth} + ({Maxhealth - 100})"); }
                else
                { Console.WriteLine($"최대체력: {Maxhealth}"); }
                Console.WriteLine($"현재체력: {currenthealth}");
                Console.WriteLine($"돈: {Money}");
             

                Console.WriteLine("0.나가기");

                String s = Console.ReadLine();

                
                if (s.Equals("0"))
                {
                    Console.Clear();
                    GoToVillage(this);
                }
                else { Console.WriteLine("잘못된 입력입니다."); }
            }
        }
    }
}

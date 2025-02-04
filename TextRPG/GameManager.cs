using Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using static Item.Item;
using static Play.Player;
using static TextRPG.Program;

namespace GameManage
{
    internal class GameManager
    {

        

        public Players Init()
        {
            String name;
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
           
            
            Players player = new Players(name);
            player.currenthealth = player.Maxhealth;
            switch (j)
            {
                case 1:
                    player.useitem.Add(new Weapon("철검", "기본적인 검이다", 2, "0"));
                    player.Job = "전사";
                    break;
                case 2:
                    player.useitem.Add(new Weapon("지팡이", "기본적인 지팡이다", 2, "0"));
                    player.Job = "마법사";
                    break;
                case 3:
                    player.useitem.Add(new Weapon("활", "기본적인 활이다", 2, "0"));
                    player.Job = "궁수";
                    break;
            }

            Console.WriteLine("기본 장비:" + player.useitem[0].ToString());
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("눈을 뜨니 앞에 한 마을이 보인다.");
           return player;
        }

        public void Death(Players player, bool Gameover)
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
        public void ShopItem(List<List<items>> items)
        {

            // 공격력 1 200
            // 방어력  1 250
            // 체력 10 500
            List<items> LevelOne = new List<items>();//레벨 0~1 아이템

            Weapon one1 = new Weapon("창", "기본적인 창이다", 3, "500");
            Weapon one2 = new Weapon("석궁", "기본적인 석궁이다", 3, "500");
            Weapon one3 = new Weapon("마도서", "기본적인 마도서다", 3, "500");

            Head one4 = new Head("나무 모자", "기본적인 나무 모자", 3, "1000");
            Armor one5 = new Armor("나무 갑옷", "기본적인 나무 갑옷", 4, "1250");
            Shoes one6 = new Shoes("가죽 신발", " 기본적인 신발이다", 2, "750");

            Ring one7 = new Ring("은반지", "기본적인 반지", 20, "1000");
            Necklace one8 = new Necklace("은 목걸이", "기본적인 목걸이", 30, "1500");

            LevelOne.Add(one1);
            LevelOne.Add(one2);
            LevelOne.Add(one3);
            LevelOne.Add(one4);
            LevelOne.Add(one5);
            LevelOne.Add(one6);
            LevelOne.Add(one7);
            LevelOne.Add(one8);



            List<items> LevelTwo = new List<items>();//레벨 2 아이템

            Weapon two1 = new Weapon("귀신 들린 검", "벨 때마다 쾌감이 느껴진다", 8, "1500");
            Weapon two2 = new Weapon("엘프의 활", "엘프가 썼다고 전해지는 활, 자연친화적이다.", 8, "1500");
            Weapon two3 = new Weapon("딱총나무 지팡이", "죽음의 주문을 쓸 수 있을 것 같다", 8, "1500");

            Head two4 = new Head("은 헬멧", "은으로 된 헬멧", 5, "1500");
            Armor two5 = new Armor("은 갑옷", "은으로 된 갑옷", 7, "2000");
            Shoes two6 = new Shoes("은 장화", " 은으로 된 장화이다", 4, "1250");

            Ring two7 = new Ring("금반지", "금으로 된 반지", 30, "1500");
            Necklace two8 = new Necklace("금 목걸이", "금으로 된 목걸이", 40, "2000");

            LevelTwo.Add(two1);
            LevelTwo.Add(two2);
            LevelTwo.Add(two3);
            LevelTwo.Add(two4);
            LevelTwo.Add(two5);
            LevelTwo.Add(two6);
            LevelTwo.Add(two7);
            LevelTwo.Add(two8);

            List<items> LevelThree = new List<items>();//레벨 3 아이템

            Weapon three1 = new Weapon("용창", "용의 뿔로 만든 창", 13, "2500");
            Weapon three2 = new Weapon("세계수의 석궁", "세계수의 가지로 만든 석궁", 13, "2500");
            Weapon three3 = new Weapon("죽먹자의 마법서", "상대를 고통에 빠뜨리기 충분하다 ", 13, "2500");

            Head three4 = new Head("오리칼쿰 헬멧", "아틀란티스에 있다는 전설의 광물의 헬멧", 8, "2250");
            Armor three5 = new Armor("오리칼쿰 갑옷", "아틀란티스에 있다는 전설의 광물의 갑옷", 11, "3000");
            Shoes three6 = new Shoes("오리칼쿰 장화", " 아틀란티스에 있다는 전설의 광물의 장화", 7, "2000");

            Ring three7 = new Ring("타임 스톤 반지", "시간을 멈출 수 있을 것 같은 반지", 40, "2000");
            Necklace three8 = new Necklace("마인드 스톤 목걸이", "누군가의 이마에 박혀있었다", 60, "3000");

            LevelThree.Add(three1);
            LevelThree.Add(three2);
            LevelThree.Add(three3);
            LevelThree.Add(three4);
            LevelThree.Add(three5);
            LevelThree.Add(three6);
            LevelThree.Add(three7);
            LevelThree.Add(three8);


            





            items.Add(LevelOne);
            items.Add(LevelTwo);
            items.Add(LevelThree);


        }


        //블로그 보고 따라만 한 것
        public void SaveData(Players players)
        {
            String file = "C:\\Users\\USER\\Desktop\\2week_HOMeWORK\\player\\player.json";
            try
            {
                string json = JsonConvert.SerializeObject(players, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(file, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Players LoadData()
        {
            String file = "C:\\Users\\USER\\Desktop\\2week_HOMeWORK\\player\\player.json";
            try
            {
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    
                    return JsonConvert.DeserializeObject<Players>(json);
                    
                }
                else
                {
                   
                    return Init();
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error Load data: {ex.Message}");
                
                return Init();
            }
        }



    }



}

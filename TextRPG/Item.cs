using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item
{
    internal class Item
    {
        public class items
        {
            public String itemname;//이름
            public String itemdesc;//설명
            public String itemMoney;//돈 -> 판매완료
            public String OriginalMoney; // 판매완료에서 다시 돈으로 바꾸기 위해 만든 변수
            public String itemtype = "기본"; //능력치를 적용할 때 구분짓기 위함
            public int itemability { get; set; } //적용되는 수치

            public override string ToString()
            {
                if (itemtype.Equals("공")) //능력치 적용을 위해 만든 itemtype으로 Tostring 
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(itemname).Append("|").Append("공격력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                    String s = str.ToString();
                    return s;
                }
                else if (itemtype.Equals("방"))
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(itemname).Append("|").Append("방어력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                    String s = str.ToString();
                    return s;
                }
                else
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(itemname).Append("|").Append("체력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                    String s = str.ToString();
                    return s;
                }


            }
            public class Weapon : items
            {


                public Weapon(String n, String d, int a, String m)
                {
                    itemname = n;
                    itemdesc = d;
                    itemability = a;
                    itemMoney = m;
                    itemtype = "공";
                    OriginalMoney = m;
                }




            }
            public class Head : items
            {


                public Head(String n, String d, int a, String m)
                {
                    itemname = n;
                    itemdesc = d;
                    itemability = a;
                    itemMoney = m;
                    itemtype = "방";
                    OriginalMoney = m;

                }

            }
            public class Armor : items
            {


                public Armor(String n, String d, int a, String m)
                {
                    itemname = n;
                    itemdesc = d;
                    itemability = a;
                    itemMoney = m;
                    itemtype = "방";
                    OriginalMoney = m;
                }

            }
            public class Shoes : items
            {


                public Shoes(String n, String d, int a, String m)
                {
                    itemname = n;
                    itemdesc = d;
                    itemability = a;
                    itemMoney = m;
                    itemtype = "방";
                    OriginalMoney = m;
                }

            }
            public class Ring : items
            {

                public Ring(String n, String d, int a, String m)
                {
                    itemname = n;
                    itemdesc = d;
                    itemability = a;
                    itemMoney = m;
                    itemtype = "체";
                    OriginalMoney = m;
                }

            }
            public class Necklace : items
            {
                public Necklace(String n, String d, int a, String m)
                {
                    itemname = n;
                    itemdesc = d;
                    itemability = a;
                    itemMoney = m;
                    itemtype = "체";
                    OriginalMoney = m;
                }

            }

        }
    }
}


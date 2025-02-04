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
            protected String itemname;
            protected String itemdesc;
            public String itemMoney;
            public String itemtype = "기본";
            public int itemability { get; set; }
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
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("|").Append("공격력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                String s = str.ToString();
                return s;
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
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("|").Append("방어력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                String s = str.ToString();
                return s;
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
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("|").Append("방어력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                String s = str.ToString();
                return s;
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
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("|").Append("방어력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                String s = str.ToString();
                return s;
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
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("|").Append("체력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                String s = str.ToString();
                return s;
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
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(itemname).Append("|").Append("체력").Append(itemability).Append("|").Append(itemdesc).Append("|");
                String s = str.ToString();
                return s;
            }
        }

    }
}

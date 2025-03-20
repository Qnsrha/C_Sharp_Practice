using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class Inven
    {
        int mSelectIndex = 0;
        Item[] ArrItem;
        int mItemX;

        public int SelectIndex
        {
            get { return mSelectIndex; }
            set { mSelectIndex = value; }
        }

        public int ItemX
        {
            get { return mItemX; }
            set { mItemX = value; }
        }


        public Inven(int _X, int _Y)
        {
            if (_X < 1)
            {
                _X = 1;

            }
            if (_Y < 1)
            {
                _Y = 1;
            }
            mItemX = _X;
            ArrItem = new Item[(_X * _Y)];
        }

        public void Render()
        {
            if (SelectIndex >= ArrItem.Length)
            {
                SelectIndex = ArrItem.Length-1;
            }
            if (SelectIndex < 0)
            {
                SelectIndex = 0;
            }

            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (i % mItemX == 0 && i != 0)
                {
                    Console.WriteLine("");
                }

                if (SelectIndex == i)
                {
                    Console.Write("▣");
                }
                else if (ArrItem[i] == null)
                {
                    Console.Write("□");
                }
                else
                {
                    Console.Write("■");
                }



            }
            if (ArrItem[SelectIndex] == null)
            {
                Console.WriteLine("");
                Console.WriteLine("비어있음");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("현재 선택된 아이템");
                Console.WriteLine("이름 :" + ArrItem[SelectIndex].Name);
                Console.WriteLine("가격 :" + ArrItem[SelectIndex].Gold);
            }

        }

        public void ItemIn(Item _Item)
        {

            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (ArrItem[i] == null)
                {
                    ArrItem[i] = _Item;
                    break;
                }

            }
            
        }
        public void ItemIn(Item _Item, int _Order)
        {
            if (ArrItem[_Order] != null || _Order >= ArrItem.Length)
            {
                return;
            }
            ArrItem[_Order] = _Item;
        }
    }
}

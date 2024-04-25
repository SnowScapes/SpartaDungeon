using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Shop
    {
        bool NotValid = false;
        bool purchase = false;
        public void ShowShop()
        {
        notvalid:
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G\n", Program.data.GetGold());
            Console.WriteLine("[아이템 목록]");
            foreach (item i in Program.Items)
            {
                if (i.name != null)
                    Console.WriteLine("- {0}  | {1} +{2}  | {3}  |  {4}", i.name, i.type == 0 ? "방어력" : "공격력", i.value, i.description, i.purchased ? "구매완료" : i.price + " G");
                else
                    continue;
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기\n");
            if (NotValid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            if (purchase)
            {
                Console.WriteLine("구매를 완료했습니다.");
                purchase = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");

            switch(Console.ReadLine())
            {
                case "0": return;
                case "1": Shop_Buy(); goto notvalid;
                case "2": Shop_Sell(); goto notvalid;
                default: NotValid = true; goto notvalid;
            }
        }

        private void Shop_Buy()
        {
            bool NotValid = false;
            bool Fail = false;
            bool purchased = false;
            notvalid:
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G\n", Program.data.GetGold());
            Console.WriteLine("[아이템 목록]");

            foreach (item i in Program.Items)
                Console.WriteLine("- {0} {1}  | {2} +{3}  | {4}  |  {5}", i.index+1, i.name, i.type == 0 ? "방어력" : "공격력", i.value, i.description, i.purchased ? "구매완료" : i.price + " G");
            Console.WriteLine("\n 0. 나가기\n");

            if (NotValid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            if (Fail)
            {
                Console.WriteLine("Gold가 부족합니다.");
                Fail = false;
            }
            if(purchased)
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
                purchased = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");
            string Sel = Console.ReadLine();

            if (Sel == "0")
                return;
            else if (int.TryParse(Sel, out int Sel_idx) && Sel_idx > 0 && Sel_idx < Program.Items.Length+1)
            {
                if (!Program.Items[Sel_idx-1].purchased && Program.data.GetGold() >= Program.Items[Sel_idx-1].price)
                {
                    Program.Items[Sel_idx - 1].purchased = true;
                    Program.data.SetGold(Program.data.GetGold() - Program.Items[Sel_idx - 1].price);
                    purchase = true;
                }
                else if (!Program.Items[Sel_idx - 1].purchased && Program.data.GetGold() < Program.Items[Sel_idx - 1].price)
                {
                    Fail = true;
                    goto notvalid;
                }
                else if (Program.Items[Sel_idx - 1].purchased)
                {
                    purchased = true;
                    goto notvalid;
                }
            }
            else
            {
                NotValid = true;
                goto notvalid;
            }
        }

        private void Shop_Sell()
        {
            item[] aval_item = new item[6];
            bool NotValid = false;
            notvalid:
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G\n", Program.data.GetGold());
            Console.WriteLine("[아이템 목록]");

            //idx는 판매 메뉴의 번호 입력을 위한 변수
            int idx = 1;

            foreach (item i in Program.Items)
            {
                if (i.purchased)
                {
                    Console.Write("- {0} ", idx);
                    Console.Write("{0}", i.Equals(Program.data.GetArmor()) || i.Equals(Program.data.GetWeapon()) ? "[E]" : "");
                    Console.WriteLine("{0}  | {1} +{2}  | {3}  |  {4}", i.name, i.type == 0 ? "방어력" : "공격력", i.value, i.description, i.purchased ? "구매완료" : i.price + " G");
                    aval_item[idx - 1] = i;
                    idx++;
                }
            }
            Console.WriteLine("\n 0. 나가기\n");
            if (NotValid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");
            string Sel = Console.ReadLine();
            if (Sel == "0")
                return;
            else if (int.TryParse(Sel, out int result) && result > 0 && result <= idx)
                Program.data.SellItem(ref Program.Items[aval_item[result - 1].index]);
            else
            {
                NotValid = true;
                goto notvalid;
            }
        }
    }
}

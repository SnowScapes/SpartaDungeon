using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Inventory
    {
        public bool ShowInventory()
        {
            bool NotValid = false;
        notvalid:
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (item i in Program.Items)
            {
                if (!i.purchased)
                {
                    continue;
                }
                else
                {
                    Console.Write("- ");
                    Console.Write("{0}", i.Equals(Program.data.GetArmor()) || i.Equals(Program.data.GetWeapon()) ? "[E]" : "");
                    Console.WriteLine("{0}  | {1} +{2}  | {3}", i.name, i.type == 0 ? "방어력" : "공격력", i.value, i.description);
                }
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기\n");
            if (NotValid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");
            string sel = Console.ReadLine();
            if (sel == "0")
                return true;
            else if (sel == "1")
            {
                if (Equip_Item())
                    goto notvalid;
                return false;
            }
            else
            {
                NotValid = true;
                goto notvalid;
            }
        }

        private bool Equip_Item()
        {
            item[] aval_item = new item[6];
            bool Notvalid = false;
            notvalid:
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            int idx = 1;
            foreach (item i in Program.Items)
            {
                if (i.purchased)
                {
                    Console.Write("- {0} ", idx);
                    Console.Write("{0}", i.Equals(Program.data.GetArmor()) || i.Equals(Program.data.GetWeapon()) ? "[E]" : "");
                    Console.WriteLine("{0}  | {1} +{2}  | {3}", i.name, i.type == 0 ? "방어력" : "공격력", i.value, i.description);
                    aval_item[idx - 1] = i;
                    idx++;
                }
            }
            Console.WriteLine("\n0. 나가기\n");
            if (Notvalid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Notvalid = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");
            string sel = Console.ReadLine();
            if (sel == "0")
                return true;
            else if (int.TryParse(sel, out int result) && result > 0 && result <= idx) {
                Program.data.ManageItem(aval_item[result - 1]);
                return true;
            }
            else
            {
                Notvalid = true;
                goto notvalid;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Status
    {
        bool NotValid = false;
        public bool ShowStatus()
        {
            notvalid:
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("LV. " + Program.data.GetLevel().ToString("D2"));
            Console.WriteLine("{0} ( {1} )", Program.data.GetName(), Program.data.GetJob());
            Console.WriteLine("공격력 : {0}{1}", Program.data.GetTotalAtk(), Program.data.GetWeapon().name != null ? string.Format(" (+{0})", Program.data.GetWeapon().value):"");
            Console.WriteLine("방어력 : {0}{1}", Program.data.GetTotalDef(), Program.data.GetArmor().name != null ? string.Format(" (+{0})", Program.data.GetArmor().value) : "");
            Console.WriteLine("체력 : " + Program.data.GetHp());
            Console.WriteLine("Gold : {0} G\n", Program.data.GetGold());
            Console.WriteLine("0. 나가기\n");
            if(NotValid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");
            if (Console.ReadLine() == "0")
                return true;
            else
            {
                NotValid = true;
                goto notvalid;
            }
        }
    }
}

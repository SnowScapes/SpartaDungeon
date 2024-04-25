using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Rest
    {
        public void HPRest()
        {
            start:
            bool rest = false;
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)\n", Program.data.GetGold());
            Console.WriteLine("1. 휴식하기\n0.나가기");
            Console.WriteLine("{0}", rest ? "\n휴식을 완료했습니다." : "");
            Console.Write("원하시는 행동을 입력해주세요 : ");
            switch (Console.ReadLine())
            {
                case "0": break;
                case "1": Program.data.SetHp(100); Program.data.SetGold(Program.data.GetGold() - 500); rest = true ; goto start;
            }
        }
    }
}

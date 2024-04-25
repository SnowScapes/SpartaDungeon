using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Dungeon
    {
        Random rand = new Random();
        public void Select_Dungeon()
        {
            repeat:
            Console.Clear();
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 쉬운 던전     | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전     | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전     | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요 : ");
            String sel = Console.ReadLine();
            if (int.TryParse(sel, out int _out))
            {
                if (_out >= 1 && _out <= 3)
                    Dungeon_Play(_out);
                else if (_out == 0)
                    return;
            }
            else
                goto repeat;
        }

        void Dungeon_Play(int Rank)
        {
            String RankName = "";
            int required_Def = 0;
            switch (Rank)
            {
                case 1: RankName = "쉬운"; required_Def = 5 ; break;
                case 2: RankName = "일반"; required_Def = 11 ; break;
                case 3: RankName = "어려운"; required_Def = 17; break;
            }
            int result = rand.Next(1, 6);
            Console.Clear();
            if (Program.data.GetDef() < required_Def && result > 3)
            {
                Console.WriteLine("던전 클리어 실패");
                Console.WriteLine("당신은 가까스로 던전에서 도망쳤습니다.\n");
                Rank = 0;
            }
            else
            {
                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine("{0} 던전을 클리어 하였습니다.\n", RankName);
            }
            Difficulty(Rank, required_Def);
        }

        void Difficulty(int Rank, int _required_def)
        {
            
            int reward = 0;
            int usedHP;
            switch(Rank)
            {
                case 1: reward = 1000;break;
                case 2: reward = 1700;break;
                case 3: reward = 2500;break;
                default: reward = 0; usedHP = Program.data.GetHp()/2; goto iffail;
            }
            usedHP = rand.Next(20, 36) - (Program.data.GetTotalDef()- _required_def);
            reward += reward * (rand.Next((int)Program.data.GetTotalAtk(),(int)(Program.data.GetTotalAtk()*2+1))) / 100;
            Program.data.ClearCount();
            iffail:
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine("체력 {0} -> {1}", Program.data.GetHp(), Program.data.GetHp()-usedHP);
            Console.WriteLine("Gold {0} G -> {1} G\n", Program.data.GetGold(), Program.data.GetGold()+reward);
            Program.data.SetHp(Program.data.GetHp() - usedHP);
            Program.data.SetGold(Program.data.GetGold() + reward);
            Console.Write("\n아무 키나 눌러 나가기");
            Console.ReadLine();
        }
    }
}

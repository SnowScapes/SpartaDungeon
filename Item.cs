using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    struct item
    {
        //index는 savedata및 장비 관리를 위해 아이템 배열에서 자신의 위치를 저장
        //name 아이템 이름 / type 방어구or무기 / value 방어력or공격력 증가수치 / description 아이템 설명 / price 아이템 가격 / purchased 아이템 구매 여부(인벤토리에서 사용)
        public int index;
        public string name;
        public int type;
        public int value;
        public string description;
        public int price;
        public bool purchased;
    }
}

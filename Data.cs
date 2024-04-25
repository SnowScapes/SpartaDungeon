using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    struct PlayerData
    {
        private int Level;
        private String Name;
        private String Job;
        private float Atk;
        private int Def;
        private int Hp;
        private int Gold;
        private item weapon;
        private item armor;
        private int Clear_Count;

        //각 데이터를 private로 선언 후, 직접 값을 넣는게 아닌 메소드를 통해 값을 받거나 수정
        public void SetLevel(int _Level)
        {
            Level = _Level;
        }
        public int GetLevel()
        {
            return Level;
        }
        public void ClearCount()
        {
            Clear_Count++;
            if(Clear_Count == Level)
            {
                Level++;
                Clear_Count = 0;
                Atk += 0.5f;
                Def += 1;
            }
        }
        public int getClearCount()
        {
            return Clear_Count;
        }
        public void setClearCount(int _Clear_Count)
        {
            Clear_Count = _Clear_Count;
        }
        public String GetName()
        {
            return Name;
        }
        public void SetName(string _Name)
        {
            Name = _Name;
        }
        public String GetJob()
        {
            return Job;
        }
        public void SetJob(String _Job)
        {
            Job = _Job;
        }
        public float GetAtk()
        {
            return Atk;
        }
        public float GetTotalAtk()
        {
            return Atk + weapon.value;
        }
        public void SetAtk(float _Atk)
        {
            Atk = _Atk;
        }
        public int GetDef()
        {
            return Def;
        }
        public int GetTotalDef()
        {
            return Def + armor.value;
        }
        public void SetDef(int _Def)
        {
            Def = _Def;
        }
        public int GetHp()
        {
            return Hp;
        }
        public void SetHp(int _Hp)
        {
            Hp = _Hp;
        }
        public int GetGold()
        {
            return Gold;
        }
        public void SetGold(int _Gold)
        {
            Gold = _Gold;
        }

        public item GetArmor()
        {
            return armor;
        }
        public item GetWeapon()
        {
            return weapon;
        }

        //아이템 장착, 해제 기능
        //type(방어구or무기)에 따라 각 위치에 장착
        //판매 혹은 해제할 경우엔 초기화
        public void ManageItem(item _equip)
        {
            if (_equip.type == 0)
            {
                if (armor.Equals(_equip))
                    armor = new item();
                else
                    armor = _equip;
            }
            else
            {
                if (weapon.Equals(_equip))
                    weapon = new item();
                else
                    weapon = _equip;
            }
        }

        //아이템 판매 기능
        //purchased를 false로 바꾸면 더이상 inventory에서 표시되지 않음
        //판매가격은 구매가격의 85%
        public void SellItem(ref item _item)
        {
            if (armor.Equals(_item))
            {
                armor = new item();
                _item.purchased = false;
                Gold += (int)(_item.price * 0.85);
            }
            else if (weapon.Equals(_item))
            {
                weapon = new item();
                _item.purchased = false;
                Gold += (int)(_item.price * 0.85);
            }
            else
            {
                _item.purchased = false;
                Gold += (int)(_item.price * 0.85);
            }
        }
    }
}

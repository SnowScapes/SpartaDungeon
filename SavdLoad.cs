using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpartaDungeon
{
    internal class SavdLoad
    {
        public bool Save()
        {
            string filePath = "userInfo.json";
            JObject userSpec = new JObject(
                new JProperty("name", Program.data.GetName()),
                new JProperty("Level", Program.data.GetLevel()),
                new JProperty("Job", Program.data.GetJob()),
                new JProperty("ATK", Program.data.GetAtk()),
                new JProperty("DEF", Program.data.GetDef()),
                new JProperty("HP", Program.data.GetHp()),
                new JProperty("Gold", Program.data.GetGold()),
                new JProperty("Armor", Program.data.GetArmor().name == null? null : Program.data.GetArmor().index),
                new JProperty("Weapon", Program.data.GetWeapon().name == null ? null : Program.data.GetWeapon().index)
                );
            File.WriteAllText(filePath,userSpec.ToString());
            return true;
        }

        public void LoadPlayerData()
        {
            string filePath = "userInfo.json";
            string jsonText = File.ReadAllText(filePath);
            JObject jsonObject = JObject.Parse(jsonText);
            int idx;

            Program.data.SetName((string)jsonObject["name"]);
            Program.data.SetLevel((int)jsonObject["Level"]);
            Program.data.SetJob((string)jsonObject["Job"]);
            Program.data.SetAtk((float)jsonObject["ATK"]);
            Program.data.SetDef((int)jsonObject["DEF"]);
            Program.data.SetHp((int)jsonObject["HP"]);
            Program.data.SetGold((int)jsonObject["Gold"]);
            if (int.TryParse((string)jsonObject["Armor"], out idx)) 
            {
                Program.data.ManageItem(Program.Items[idx]);
            }

            if (int.TryParse((string)jsonObject["Weapon"], out idx))
            {
                Program.data.ManageItem(Program.Items[idx]);
            }
        }

        public void LoadItemData()
        {
            string filePath = "ItemInfo.json";
            string jsonText = File.ReadAllText(filePath);
            Program.Items = JsonConvert.DeserializeObject<item[]>(jsonText);
        }
    }
}

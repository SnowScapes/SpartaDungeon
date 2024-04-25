
namespace SpartaDungeon
{
    internal class Program
    {
        public static SavdLoad savedata = new SavdLoad();
        public static PlayerData data = new PlayerData();
        public static item[] Items;
        static void Main(string[] args)
        {
            Status stat = new Status();
            Inventory inven = new Inventory();
            Shop shop = new Shop();
            Dungeon dung = new Dungeon();
            Rest rest = new Rest();
            bool NotValid = false;
            savedata.LoadItemData();
            savedata.LoadPlayerData();
        gamestart:
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("6. 게임저장\n");
            if (NotValid)
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            Console.Write("원하시는 행동을 입력해주세요 : ");
            String Sel = Console.ReadLine();
            switch (Sel)
            {
                case "1": if(stat.ShowStatus()) goto gamestart; break;
                case "2": if (inven.ShowInventory()) goto gamestart; break;
                case "3": if (shop.ShowShop()) goto gamestart; break;
                case "4": if (dung.Select_Dungeon()) goto gamestart; break;
                case "5": rest.HPRest(); goto gamestart;
                case "6": savedata.Save(); goto gamestart;
                default: NotValid = true; goto gamestart;
            }
        }
    }
}
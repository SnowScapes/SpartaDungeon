
namespace SpartaDungeon
{
    internal class Program
    {
        public static SavdLoad savedata = new SavdLoad();
        public static PlayerData data = new PlayerData();
        public static item[] Items;
        static void Main(string[] args)
        {
            //각 페이지 클래스 불러오기
            Status stat = new Status();
            Inventory inven = new Inventory();
            Shop shop = new Shop();
            Dungeon dung = new Dungeon();
            Rest rest = new Rest();
            bool NotValid = false;

            //아이템데이터 불러오기 /bin/Debug/net6.0/ItemInfo.json 아이템 정보(json 파일을 수정하여 아이템을 추가하거나 수정 가능)
            //플레이어데이터 불러오기 /bin/Debug/net6.0/userInfo.json 플레이어 정보
            savedata.LoadItemData();
            savedata.LoadPlayerData();

            //입력이 잘못 들어오거나 메인화면으로 돌아올 때 다시 시작될 지점
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
            switch (Console.ReadLine())
            {
                case "1": stat.ShowStatus(); goto gamestart;
                case "2": inven.ShowInventory(); goto gamestart;
                case "3": shop.ShowShop(); goto gamestart;
                case "4": dung.Select_Dungeon(); goto gamestart;
                case "5": rest.HPRest(); goto gamestart;
                case "6": savedata.Save(); goto gamestart;
                default: NotValid = true; goto gamestart;
            }
        }
    }
}
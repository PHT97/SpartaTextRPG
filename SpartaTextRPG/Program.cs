using System.Data;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace SpartaTextRPG
{
    internal class Program
    {
        // main이 static이라서 맞춰줘야함
        // static 실행되는 초기화순서가 있는데 그것에 대해 조사해보면 왜 메인이 static으로 되는지
        public static Character player;
        public static List<Item> item = new List<Item>();
        public static List<Item> useitem = new List<Item>();
        public static List<Item> equipitemdefence = new List<Item>();
        public static List<Item> equipitemattack = new List<Item>();
        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("마을에 들어가기전 당신의 이름을 말해주세요.");
            string UserName = Console.ReadLine();
            player = new Character(UserName, " (전사)", 1, 10, 5, 100, 1500);

            item.Add(new Item(false, "   ", 0, "수련자 갑옷    ", 0, 5, "수련에 도움을 주는 갑옷입니다", "100"));
            item.Add(new Item(false, "   ", 1, "무쇠갑옷       ", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", "500"));
            item.Add(new Item(false, "   ", 2, "스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다", "1000"));
            item.Add(new Item(false, "   ", 3, "낡은 검        ", 1, 2, "쉽게 볼 수 있는 낡은검 입니다.", "100"));
            item.Add(new Item(false, "   ", 4, "청동 도끼      ", 1, 5, "어디선가 사용됐던거 같은 도끼입니다.", "500"));
            item.Add(new Item(false, "   ", 5, "스파르타의 창  ", 1, 7, "스파르타의 전사들이 사용했다는 전설의 창 입니다.", "1000"));

            MainScene();
        }
        static void MainScene()
        {
            Console.Clear();
            Console.WriteLine("{0} 용사님! 스파르타 마을에 오신것을 환영합니다.", player.Name);
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            int inputKey = CheckPlay(1, 3);
            switch (inputKey)
            {
                case 1:
                    UserState();
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    Shop();
                    break;
            }
        }
        //플레이어의 행동을 체크하는 코드
        static int CheckPlay(int min, int max)
        {
            while (true)
            {
                //콘솔창에서 유저선택을 받아옴
                string UserSelect = Console.ReadLine();
                //유저선택이 숫자면 참, 아니면 거짓이되도록 TryParse문사용
                bool NumCheck = int.TryParse(UserSelect, out var Num);
                if (NumCheck)
                {
                    if (Num >= min && Num <= max)
                    {
                        return Num;
                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        //상태창
        static void UserState()
        {
            Console.Clear();
            //텍스트문자에 색을 입히는 코드
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태보기");
            Console.ResetColor(); //이것으로 입힌색을 다시 원상복귀시킨다.
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("\n");

            player.CharacterInfo();

            Console.WriteLine("\n");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");

            int inputKey = CheckPlay(0, 0);
            switch (inputKey)
            {
                case 0:
                    MainScene();
                    break;
            }
        }

        //인벤토리
        static void Inventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("\n");
            if (useitem.Count == 0)
            {
                Console.WriteLine("");
            }
            else
            {
                for (int i = 0; i < useitem.Count; i++)
                {
                    if (useitem[i].ItemType == 0)
                    {
                        Console.WriteLine((i + 1) + "_ " + useitem[i].ItemEqit + useitem[i].ItemName + " | 방어력 +" + useitem[i].PlusState + " | " + useitem[i].ItemInfo);
                    }
                    else
                    {
                        Console.WriteLine((i + 1) + "_ " + useitem[i].ItemEqit + useitem[i].ItemName + " | 공격력 +" + useitem[i].PlusState + " | " + useitem[i].ItemInfo);
                    }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int inputKey = CheckPlay(0, 1);
            switch (inputKey)
            {
                case 0:
                    MainScene();
                    break;
                case 1:
                    InventorySetting();
                    break;
            }
        }

        static void InventorySetting()
        {
            Console.Clear();
            int i;
            Console.WriteLine("이곳에서 아이템 탈착을 할 수 있습니다.");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("\n");
            for (i = 0; i < useitem.Count; i++)
            {
                if (useitem[i].ItemType == 0)
                {
                    Console.WriteLine((i + 1) + "_" + useitem[i].ItemEqit + useitem[i].ItemName + " | 방어력 +" + useitem[i].PlusState + " | " + useitem[i].ItemInfo);
                }
                else
                {
                    Console.WriteLine((i + 1) + "_" + useitem[i].ItemEqit + useitem[i].ItemName + " | 공격력 +" + useitem[i].PlusState + " | " + useitem[i].ItemInfo);
                }
            }
            Console.WriteLine("장착할 아이템을 입력해주세요");
            Console.WriteLine("나가기 = 0");
            Console.Write(">> ");
            int Use = CheckPlay(0, useitem.Count) - 1; // 플레이어가 선택한 숫자를 받아옴
            if (Use >= 0 && Use < useitem.Count)
            {
                if (useitem[Use].ItemUse == false)
                {
                    if (useitem[Use].ItemType == 0) // 방어구 장착
                    {
                        useitem[Use].ItemUse = true;
                        useitem[Use].ItemEqit = "[E]";
                        player.Defense += useitem[Use].PlusState;
                        player.plusDefense += useitem[Use].PlusState;
                    }
                    else // 무기 장착
                    {
                        useitem[Use].ItemUse = true;
                        useitem[Use].ItemEqit = "[E]";
                        player.Attack += useitem[Use].PlusState;
                        player.plusAttack += useitem[Use].PlusState;
                    }

                }
                else if (useitem[Use].ItemUse == true)
                {
                    if (useitem[Use].ItemType == 0)
                    {
                        useitem[Use].ItemUse = false;
                        useitem[Use].ItemEqit = "   ";
                        player.Defense -= useitem[Use].PlusState;
                        player.plusDefense -= useitem[Use].PlusState;
                    }
                    else
                    {
                        useitem[Use].ItemUse = false;
                        useitem[Use].ItemEqit = "   ";
                        player.Attack -= useitem[Use].PlusState;
                        player.plusAttack -= useitem[Use].PlusState;
                    }
                }
            }
            Inventory();
        }
        //상점
        static void Shop()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine("{0}", player.Gold + "G");
            Console.WriteLine("\n");

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].ItemType == 0)
                {
                    Console.WriteLine(" - " + item[i].ItemName + 1 + " | 방어력 +" + item[i].PlusState + " | " + item[i].ItemInfo + " | " + item[i].ItemPay);
                }
                else
                {
                    Console.WriteLine(" - " + item[i].ItemName + 1 + " | 공격력 +" + item[i].PlusState + " | " + item[i].ItemInfo + " | " + item[i].ItemPay);
                }
            }
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int inputKeyshop = CheckPlay(0, 1);
            switch (inputKeyshop)
            {
                case 0:
                    MainScene();
                    break;
                case 1:
                    BuyItem();
                    break;
            }
        }
        static void BuyItem()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("현재 보유자금 = " + player.Gold + "G");
            Console.WriteLine("\n");
            Console.WriteLine("구매하실 상품의 번호를 입력해주세요.");
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].ItemType == 0)
                {
                    Console.WriteLine((item[i].ItemID + 1 + " ") + item[i].ItemName + " | 방어력 +" + item[i].PlusState + " | " + item[i].ItemInfo + " | " + item[i].ItemPay);
                }
                else
                {
                    Console.WriteLine((item[i].ItemID + 1 + " ") + item[i].ItemName + " | 공격력 +" + item[i].PlusState + " | " + item[i].ItemInfo + " | " + item[i].ItemPay);
                }
            }
            Console.Write(">>");
            string PlayerSelect = Console.ReadLine();//플레이어가 선택한 아이템번호
            int CheckSell = int.Parse(PlayerSelect) - 1;
            if (CheckSell >= 0 && CheckSell <= 5)
            {
                if (item[CheckSell].ItemPay != "구매완료")
                {
                    int SelectItemPay = int.Parse(item[CheckSell].ItemPay); //string인 ItemPay를 int로 변환
                    if (player.Gold >= SelectItemPay)
                    {
                        Console.WriteLine("구매를 완료했습니다");
                        player.Gold -= SelectItemPay;
                        item[CheckSell].ItemPay = "구매완료";
                        useitem.Add(item[CheckSell]);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Gold가 부족합니다.");
                    }
                }
                else
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
            }
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int inputKeyshop = CheckPlay(0, 1);
            switch (inputKeyshop)
            {
                case 0:
                    MainScene();
                    break;
                case 1:
                    BuyItem();
                    break;
            }
        }
    }

}

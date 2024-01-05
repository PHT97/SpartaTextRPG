using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    //아이템 배열을 생성한다음 넣을 class Item
    internal class Item
    {
        public bool ItemUse { get; set; }
        public string ItemEqit { get; set; }
        public int ItemID { get; set; }     //아이템의 배열순서
        public string ItemName { get; set; }//아이템 이름
        public int ItemType { get; set; }  //아이템의 타입 0이면 방어구, 1이면 무기
        public int PlusState { get; set; } //장착아이템에따라 스테이터스 변화
        public string ItemInfo { get; set; }//아이템 설명
        public string ItemPay { get; set; } //아이템 가격

        public Item(bool utemuse,string itemeqit, int itemID, string itemName, int itemType, int plusState, string itemInfo, string itempay)
        {
            ItemUse = utemuse;
            ItemEqit = itemeqit;
            ItemID = itemID;
            ItemName = itemName;
            ItemType = itemType;
            PlusState = plusState;
            ItemInfo = itemInfo;
            ItemPay = itempay;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Data {

    public enum SlotType { HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS };
    public static int SlotTypeCount = 7;

    public enum ItemType { WEAPON, SHIELD, ARMOR };
    public static int ItemTypeCount = 3;

    public enum ItemQuality { NORMAL, MAGIC, LEGENDARY };
    public static int ItemQualityCount = 3;

    public static int inventorySlotPerItemType = 49;

    public static Inventory inventory;
}

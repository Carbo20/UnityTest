using UnityEngine;
using System.Collections;

public class ItemData {

    private string itemName;
    private int spriteId;
    private string description;
    public Data.SlotType slotType;
    public Data.IconType iconType;

    public ItemData(string _itemName, int _spriteId, string _description, Data.SlotType _slotType, Data.IconType _iconType)
    {
        itemName = _itemName;
        spriteId = _spriteId;
        description = _description;
        slotType = _slotType;
        iconType = _iconType;
    }

    public int SpriteId
    {
        get
        {
            return spriteId;
        }

        set
        {
            spriteId = value;

        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }
    }
}

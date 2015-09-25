using UnityEngine;
using System.Collections;
using System;

[Serializable()]
public class ItemData {

    public string itemName;
    public int spriteId;
    public string description;
    public Data.SlotType slotType;
    public Data.IconType iconType;

    public ItemData()
    {
        itemName = "";
        spriteId = 0;
        description = "";
        slotType = Data.SlotType.HEAD;
        iconType = Data.IconType.HEAD;
    }

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

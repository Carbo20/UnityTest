using UnityEngine;
using System.Collections;

public class ItemData : MonoBehaviour {

    private string itemName;
    private int spriteId;
    private string description;
    public Data.SlotType slotType;

    public ItemData(string _itemName, int _spriteId, string _description, Data.SlotType _slotType)
    {
        itemName = _itemName;
        spriteId = _spriteId;
        description = _description;
        slotType = _slotType;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public int SpriteId
    {
        get
        {
            return spriteId;
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

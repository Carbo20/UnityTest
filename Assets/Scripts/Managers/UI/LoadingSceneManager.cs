using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;

public class LoadingSceneManager : MonoBehaviour {

    //edit in inspector
    public string heroDataXMLFilename;
    public string itemsDataXMLFilename;
    public List<Sprite> sprites;

    private float ready;
	// Use this for initialization
	void Start () {
        LoadHeroData();
        LoadSprites();
        LoadItemsData();
        ready = 0;
       // Debug.Log(Data.listOfItems);
	}
	
	// Update is called once per frame
	void Update () {
        if (ready < 1f)
            ready += Time.deltaTime;
        else
            Application.LoadLevel("MainMenu");
	}

    void LoadSprites()
    {
        Data.sprites = new List<Sprite>();

        foreach(Sprite s in sprites)
        {
            Data.sprites.Add(s);
        }

    }

    void LoadHeroData()
    {
        XmlDocument xmlDoc = new XmlDocument(); 
        xmlDoc.Load(heroDataXMLFilename);
        XmlNodeList heroStats = xmlDoc.GetElementsByTagName("ooo_row");

        foreach (XmlNode heroStat in heroStats)
        {
            XmlNodeList stats = heroStat.ChildNodes;

            foreach (XmlNode stat in stats)
            {
                switch (stat.Name)
                {
                    case "HPMAX"         : Data.heroData.hpMax          = Int32.Parse(stat.InnerText); break;
                    case "MANAMAX"       : Data.heroData.manaMax        = Int32.Parse(stat.InnerText); break;
                    case "STRENGHT"      : Data.heroData.strenght       = Int32.Parse(stat.InnerText); break;
                    case "INTELLIGENCE"  : Data.heroData.intelligence   = Int32.Parse(stat.InnerText); break;
                    case "AGILITY"       : Data.heroData.agility        = Int32.Parse(stat.InnerText); break;
                    case "VITALITY"      : Data.heroData.vitality       = Int32.Parse(stat.InnerText); break;
                    case "DAMAGE"        : Data.heroData.damage         = Int32.Parse(stat.InnerText); break;
                    case "SPELLDAMAGE"   : Data.heroData.spellDamage    = Int32.Parse(stat.InnerText); break;
                    case "DODGE"         : Data.heroData.dodge          = Int32.Parse(stat.InnerText); break;
                    case "CRITICAL"      : Data.heroData.critical       = Int32.Parse(stat.InnerText); break;
                    case "SPEED"         : Data.heroData.speed          = Int32.Parse(stat.InnerText); break;
                    case "XP"            : Data.heroData.xp             = Int32.Parse(stat.InnerText); break;
                    case "XPFORNEXTLEVEL": Data.heroData.xpForNextLevel = Int32.Parse(stat.InnerText); break;
                    case "LEVEL"         : Data.heroData.level          = Int32.Parse(stat.InnerText); break;
                }
            }
        }
    }

    void LoadItemsData()
    {
        Data.listOfItems = new List<List<ItemData>>();
        for (int i = 0; i < Data.IconTypeCount; i++)
        {
            Data.listOfItems.Add(new List<ItemData>());
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(itemsDataXMLFilename);
        XmlNodeList items = xmlDoc.GetElementsByTagName("ooo_row");
        string name="fail loading name", desc = "fail loading desc";
        int id = -1;
        Data.SlotType st = Data.SlotType.HANDS;
        Data.IconType it = Data.IconType.AXE;

        foreach (XmlNode itemData in items)
        {
            XmlNodeList item = itemData.ChildNodes;

            foreach (XmlNode itemDataRead in item)
            {
                switch (itemDataRead.Name)
                {
                    case "ITEMNAME": name = itemDataRead.InnerText; break;
                    case "SPRITEID": id = Int32.Parse(itemDataRead.InnerText); break;
                    case "DESCRIPTION": desc = itemDataRead.InnerText; break;
                    case "SLOTTYPE": st = (Data.SlotType)Int32.Parse(itemDataRead.InnerText); break;
                    case "ICONTYPE": it = (Data.IconType)Int32.Parse(itemDataRead.InnerText); break;
                    
                }
            }

            Data.listOfItems[it.GetHashCode()].Add(new ItemData(name, id, desc, st, it));
        }
    }
}

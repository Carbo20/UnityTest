using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;

public class LoadingSceneManager : MonoBehaviour {

    public string heroDataXMLFilename;
    public string itemsDataXMLFilename;
    public float ready;
	// Use this for initialization
	void Start () {
        LoadHeroData();
       // LoadItemsData();
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
        for (int i = 0; i < Data.SlotTypeCount; i++)
        {
            Data.listOfItems.Add(new List<ItemData>());
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(itemsDataXMLFilename);
        XmlNodeList items = xmlDoc.GetElementsByTagName("ooo_row");
        string name="fail loading name", desc = "fail loading desc";
        int id = -1;
        Data.SlotType st = Data.SlotType.HANDS;
        foreach (XmlNode itemData in items)
        {
            XmlNodeList item = itemData.ChildNodes;

            foreach (XmlNode itemDataRead in item)
            {
                switch (itemData.Name)
                {
                    case "ITEMNAME": name = itemData.InnerText; break;
                    case "SPRITEID": id = Int32.Parse(itemData.InnerText); break;
                    case "DESCRIPTION": desc = itemData.InnerText; break;
                    case "SLOTTYPE": st = (Data.SlotType)Int32.Parse(itemData.InnerText); break;
                    
                }
            }

            Data.listOfItems[st.GetHashCode()].Add(new ItemData(name, id, desc, st));
        }
    }
}

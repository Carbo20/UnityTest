using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
        LoadInventoryFromXML();
        ready = 0;
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
        Data.heroData.LoadHeroData();
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

   
     public void LoadInventoryFromXML()
     {
         /*FileStream fs = new FileStream("inventory.xml", FileMode.Open);
         XmlSerializer x = new XmlSerializer(typeof(Inventory));
         Data.inventory = (Inventory)x.Deserialize(fs);*/
         if (File.Exists("inventory"))
         {
             Stream stream = File.OpenRead("inventory");
             BinaryFormatter deserializer = new BinaryFormatter();
             Data.inventory = (Inventory)deserializer.Deserialize(stream);
             stream.Close();
         }
     }
     
}

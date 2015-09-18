using System.Collections.Generic;

public class Inventory {

    public List<List<Item>> items;

    public Inventory()
    {
        items = new List<List<Item>>();
        for (int i = 0; i < Data.SlotTypeCount; i++)
            items.Add(new List<Item>());
    }

    //TODO
    /*
     public void LoadInventoryFromXML()
     {
      
     }
     */

    //TODO
    /*
     public void SaveInventoryFromXML()
     {
      
     }
     */
}

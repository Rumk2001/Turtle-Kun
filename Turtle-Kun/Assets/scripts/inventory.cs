using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    
    private int maxSpace;
    //Dictionary<int,Item,int>
    Dictionary<int,int> items;
     
    public Inventory(int maxSpace = 5)
    {
        this.maxSpace = maxSpace;
        items = new Dictionary<int,int>();
    }

    public void removeItems(Item itemToRemove)
    {
        items.TryGetValue(itemToRemove.Type, out int value);

        if (items.ContainsKey(itemToRemove.Type)  && value > 0)
        { 
            items[itemToRemove.Type]--;
            if (items[itemToRemove.Type] == 0) { items.Remove(itemToRemove.Type); }
        }
        else
          items.Remove(itemToRemove.Type);
        
    }
    public int GetNumberOfItem(int i)
    {
        items.TryGetValue(i, out int value);
        return value;
    }
    public void add(Item itemToAdd)
    {
        if (items.Count < maxSpace)
        {
            if (items.ContainsKey(itemToAdd.Type))
            { items[itemToAdd.Type]++; }
            else
                items.Add(itemToAdd.Type, 1);
        }
        //TODO: send a message if inventory is full
        else { return; }

    }
    public void upgrade()
    {
        maxSpace=10;
    }

}

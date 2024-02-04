using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    
    private int maxSpace;
    //Dictionary<int,Item,int>
    Dictionary<Item,int> items;
     
    public Inventory(int maxSpace = 5)
    {
        this.maxSpace = maxSpace;
        items = new Dictionary<Item,int>();
    }

    public void removeItems(Item itemToRemove)
    {
        int value = 0;
        items.TryGetValue(itemToRemove, out value);

        if (items.ContainsKey(itemToRemove)  && value > 0)
        { 
            items[itemToRemove]--;
            if (items[itemToRemove] == 0) { items.Remove(itemToRemove); }
        }
        else
          items.Remove(itemToRemove);
        
    }
    public Item GetItem(int i)
    {
        
        return null;
    }
    public void add(Item itemToAdd)
    {
        if (items.Count < maxSpace)
        {
            if (items.ContainsKey(itemToAdd))
            { items[itemToAdd]++; }
            else
                items.Add(itemToAdd, 1);
        }
        //TODO: send a message if inventory is full
        else { return; }

    }
    public void upgrade()
    {
        maxSpace=10;
    }

}

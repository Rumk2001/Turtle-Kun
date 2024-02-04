using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private int maxSpace;
    Dictionary<Item,int> items;
     
    public Inventory(int maxSpace = 5)
    {
        this.maxSpace = maxSpace;
        this.items = new Dictionary<Item,int>();
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

    public Boolean findItems(Item itemTofind, int quantity)
    {
        if (items.ContainsKey(itemTofind))
        {
            if (items[itemTofind] >= quantity)
            {
                return true;
            }
        }
        return false;
    }
    public void upgrade()
    {
        maxSpace=10;
    }

}

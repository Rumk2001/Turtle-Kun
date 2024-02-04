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

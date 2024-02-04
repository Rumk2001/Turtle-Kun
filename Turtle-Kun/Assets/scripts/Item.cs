using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    private int id;
    private int type;
    private float damage;
    private string description;
    public Item(int id, string name, float damage, string description, int type ) {
        this.id = id;
        this.name = name;
        this.damage = damage;
        this.description = description;
        this.type = type;
    }


    public string Name { 
        get { return this.name; } 
        set { this.name = value; } 
    }
    public int ID
    {
        get { return id; }
        set { this.id = value; }
    }
    public int Type
    {
        get { return type; }
        set { type = value; }
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
}

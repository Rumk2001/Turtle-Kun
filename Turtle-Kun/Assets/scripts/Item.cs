using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    private string name;
    private int id;
    private float damage;
    private string description;
    public Item(int id, string name, float damage, string description ) {
        this.id = id;
        this.name = name;
        this.damage = damage;
        this.description = description;
    }

}

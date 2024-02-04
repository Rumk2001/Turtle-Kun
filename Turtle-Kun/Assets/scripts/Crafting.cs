using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting
{

    public void craftWaterBottle(Inventory inventory)
    {
        //craft reusable water bottle from 3 water bottle
        if (inventory.findItems(itemCreator.CreatePlastic(1), 3)){
            for (int i = 0; i < 3;i++) { inventory.removeItems(itemCreator.CreatePlastic(1)); }
            inventory.add(itemCreator.CreatePlastic(8));
        }
    }

    public void craftBackPack(Inventory inventory)
    {
        //craft backpack from 4 reusable water bottles
        if (inventory.findItems(itemCreator.CreatePlastic(8), 4))
        {
            for (int i = 0; i < 4; i++) { inventory.removeItems(itemCreator.CreatePlastic(8)); }
            inventory.upgrade();
        }
    }

    public void craftVerticalGarden(Inventory inventory)
    {
        //craft vertical garden from 4 water bottles
        if (inventory.findItems(itemCreator.CreatePlastic(1), 4))
        {
            for (int i = 0; i < 4; i++) { inventory.removeItems(itemCreator.CreatePlastic(1)); }
            createVerticalGarden();
        }
    }

    private void createVerticalGarden()
    {
        //TODO:should create vertical garden in the shell
    }

    public void craftRecyclingBin(Inventory inventory,int id)
    {
        if (id == 8) { return; }
        if (inventory.findItems(itemCreator.CreatePlastic(id), 3))
        {
            for (int i = 0; i < 3; i++) { inventory.removeItems(itemCreator.CreatePlastic(id)); }
            createRecyclingBin(id);
        }
    }
    private void createRecyclingBin(int id)
    {
        //TODO:should create respective recycling bin from id in the shell
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class itemCreator
{
    public static int nbItemType = 7;

    public static Item CreatePlastic(int id)
    {
        switch (id)
        {
            case 1:
                return new Item(id, "Plastic Bottle",0.05f, "This bottle made of PET (Polyethylene terephthalateis) can be recycled",id);
                break;
            case 2:
                return new Item(id, "Plastic Milk Jug", 0.15f, "This plastic milk made of high density polyethylene jug can be recycled ",id);
                break;
            case 3:
                return new Item(id, "Plastic Fire Truck", 0.30f, "This fire truck made of PVC cannot be recycled",id);
                break;
            case 4:
                return new Item(id, "Plastic Bag", 0.45f, "This plastic bag made of low density polyethylene can sometimes be recycled",id);
                break;
            case 5:
                return new Item(id, "Plastic Straw", 0.55f, "These straws made of polypropylene can sometimes be recycled",id);
                break;
            case 6:
                return new Item(id, "Plastic Coffee Cup", 0.69f, "This Styrofoam made of polystyrene can sometimes be recycled",id);
                break;
            case 7:
                return new Item(id, "Plastic Can", 0.75f, "This plastic can can't usually be recycled",id);
                break;
            default:
                return null;
                break;
        }
    }
}

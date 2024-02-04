using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryShelf : MonoBehaviour
{
    public GameObject shelf;
    public GameObject[] slots;
    public TextMeshProUGUI text;
    public static InventoryShelf instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void hide()
    {
        
        shelf.SetActive(false);
    }
    public void show(Inventory inventory)
    {
        
        shelf.SetActive(true);
        for(int i = 0; i <= slots.Length-1; i++)
        {
            if (slots[i] != null)
            {
                slots[i].GetComponentInChildren<TextMeshProUGUI>().text = $"{inventory.GetNumberOfItem(i+1)}";
            }
        }
    }
}

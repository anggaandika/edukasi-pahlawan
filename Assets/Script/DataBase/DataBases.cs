using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataBases : MonoBehaviour
{
    public ItemDatabase items;
    public static DataBases instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static ItemScript GetItemById(string Id)
    {
        return instance.items.allItems.FirstOrDefault(i => i.itemId == Id);
    }
    public static ItemScript GetRandomItem()
    {
        return instance.items.allItems[Random.Range(1, instance.items.allItems.Count())];
    }
}

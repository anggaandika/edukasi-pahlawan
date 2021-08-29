using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item DataBase", menuName = "Assets/DataBases/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemScript> allItems;
}

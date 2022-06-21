using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;


}


[System.Serializable]
public class Combine
{
    public Item secondItem;
    public Item result;
}

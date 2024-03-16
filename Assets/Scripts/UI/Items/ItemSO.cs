using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public AttributesChange attributesChange = new AttributesChange();
    public int amountToChangeAttribute;

    public void UseItem()
    {
        // AttributesChange
        if (attributesChange == AttributesChange.Detection)
        {
            GameObject.Find("PlayerUI").GetComponent<RandomMovements>().ChangeDetextionSkill(amountToChangeAttribute);
        }
    }

    public enum AttributesChange
    {
        None,
        Strenght,
        Dexterity,
        Intelligence,
        Detection
    };
}

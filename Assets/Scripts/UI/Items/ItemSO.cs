using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public AttributesChange attributesChange = new AttributesChange();
    public int amountToChangeAttribute;

    public bool UseItem()
    {
        // AttributesChange
        if (attributesChange == AttributesChange.Detection)
        {
            RandomMovements randomMovementsScript = GameObject.Find("PlayerUI").GetComponent<RandomMovements>();
            if (randomMovementsScript.DetectionSkill <= 5 && randomMovementsScript.DetectionSkill > 0 )
            {
                randomMovementsScript.ChangeDetextionSkill(itemName, amountToChangeAttribute);
                return true;
            }
            else if (randomMovementsScript.DetectionSkill > 5 && randomMovementsScript.DetectionSkill < 0)
            {
                return false;
            }
        }
        return false;
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

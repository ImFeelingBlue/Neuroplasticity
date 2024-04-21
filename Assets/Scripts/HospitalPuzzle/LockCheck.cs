using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCheck : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private DoorOpenButton1 doorOpenButton1;
    private DoorOpenButton2 doorOpenButton2;
    private DoorOpenButton3 doorOpenButton3;
    private DoorOpenButton4 doorOpenButton4;
    private DoorOpenButton5 doorOpenButton5;
    private DoorOpenButton6 doorOpenButton6;

    private void Start()
    {
        // Find all DoorOpenButton components in the scene
        doorOpenButton1 = FindObjectOfType<DoorOpenButton1>();
        doorOpenButton2 = FindObjectOfType<DoorOpenButton2>();
        doorOpenButton3 = FindObjectOfType<DoorOpenButton3>();
        doorOpenButton4 = FindObjectOfType<DoorOpenButton4>();
        doorOpenButton5 = FindObjectOfType<DoorOpenButton5>();
        doorOpenButton6 = FindObjectOfType<DoorOpenButton6>();
    }

    private void Update()
    {
        // Check if all doorOpenButton references are not null and their correctColor properties match specific conditions
        if (doorOpenButton1 != null &&
            doorOpenButton2 != null &&
            doorOpenButton3 != null &&
            doorOpenButton4 != null &&
            doorOpenButton5 != null &&
            doorOpenButton6 != null &&
            doorOpenButton1.correctColor1 == false &&
            doorOpenButton2.correctColor2 == false &&
            doorOpenButton3.correctColor3 &&
            doorOpenButton4.correctColor4 == false &&
            doorOpenButton5.correctColor5 &&
            doorOpenButton6.correctColor6)
        {
            Destroy(door);
        }
    }
}

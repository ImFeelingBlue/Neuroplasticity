using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageWriting : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GarageWritingOnTheWall;
    private bool lockIt = false;

    private void Start()
    {
        GarageWritingOnTheWall.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            GarageWritingOnTheWall.SetActive(true);
            //StartCoroutine(TurnItInvisable());
        }
    }

    //private IEnumerator TurnItInvisable()
    //{
      //  yield return new WaitForSeconds(3f);
        //GarageWritingOnTheWall.SetActive(false);
        //lockIt = true;
    //}
}

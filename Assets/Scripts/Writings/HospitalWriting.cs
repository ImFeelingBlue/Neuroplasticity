using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalWriting : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject HospitalWritingOnTheWall;
    private bool lockIt = false;

    private void Start()
    {
        HospitalWritingOnTheWall.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            HospitalWritingOnTheWall.SetActive(true);
            StartCoroutine(TurnItInvisable());
        }
    }

    private IEnumerator TurnItInvisable()
    {
        yield return new WaitForSeconds(3f);
        HospitalWritingOnTheWall.SetActive(false);
        lockIt = true;
    }
}

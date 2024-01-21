using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerController : MonoBehaviour
{
    private int spaceCountSound = 0;
    [SerializeField] private AudioSource firstMeetingGodSound;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCountSound++;
            Debug.Log(spaceCountSound);
        }
        if (spaceCountSound == 28)
        {
            firstMeetingGodSound.Play();
        }
        else if (spaceCountSound == 29) 
        {
            firstMeetingGodSound.Stop();
        }
    }
}

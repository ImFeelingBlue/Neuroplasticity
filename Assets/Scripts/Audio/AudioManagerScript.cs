using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] private AudioClip footStepMudAudioClip;
    [SerializeField] private AudioClip sewingItemPickUpAudioClip;

    [SerializeField] private AudioClip footstep_wood_1;
    [SerializeField] private AudioClip footstep_wood_2;
    [SerializeField] private AudioClip squeakladder;

    [SerializeField] private AudioSource audioManagerAudioSource;
    [SerializeField] private GameObject sewingItem;

    [SerializeField] List<GameObject> boxItemList;

    public CameraMovement cameraMovement;
    public StairsSoundTrigger stairsSoundTrigger;

    private bool soundPlayed = false;
    private bool soundPlayedWalking = false;
    private bool playWood1 = true;
    private bool soundPlayingSewing = false;

    void Update()
    {
        // Walking sound toggler
        if (cameraMovement != null && cameraMovement.IsWalking() && !soundPlayedWalking)
        {
            soundPlayedWalking = true;

            if (playWood1)
            {
                audioManagerAudioSource.PlayOneShot(footstep_wood_1);
            }
            else
            {
                audioManagerAudioSource.PlayOneShot(footstep_wood_2);
            }

            playWood1 = !playWood1;
            StartCoroutine(ResetSoundFlag());
        }

        if (stairsSoundTrigger.stairsSoundIsTriggered)
        {
            audioManagerAudioSource.PlayOneShot(squeakladder);
            stairsSoundTrigger.stairsSoundIsTriggered = false;
        }


        // Box item loop
        for (int i = boxItemList.Count - 1; i >= 0; i--)
        {
            if (boxItemList[i] == null)
            {
                if (!soundPlayed)
                {
                    audioManagerAudioSource.PlayOneShot(footStepMudAudioClip);
                    StartCoroutine(DelayedResetSound());
                }

                // Remove the destroyed object from the list
                boxItemList.RemoveAt(i);
            }
            else
            {
                // The GameObject obj is still active
            }
        }

        // Sewing item 
        if (sewingItem == null)
        {
            if (!soundPlayingSewing)
            {
                audioManagerAudioSource.PlayOneShot(sewingItemPickUpAudioClip);
                soundPlayingSewing = true;
            }
        }

    }

    IEnumerator ResetSoundFlag()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        soundPlayedWalking = false;
    }

    IEnumerator DelayedResetSound()
    {
        yield return new WaitForSeconds(0.2f);
        soundPlayed = false;
    }
}

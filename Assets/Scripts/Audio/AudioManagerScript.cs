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
    [SerializeField] private AudioClip backGroundSound;

    [SerializeField] private AudioSource mainAudioSource;
    [SerializeField] private AudioSource audioSourceWalking;
    [SerializeField] private AudioSource audioSourceBackGroundSound;
    [SerializeField] private GameObject sewingItem;
    public SewingKitSoundTrigger sewingKitSoundTrigger;

    [SerializeField] List<GameObject> boxItemList;

    public CameraMovement cameraMovement;
    public StairsSoundTrigger stairsSoundTrigger;

    private bool soundPlayed = false;
    private bool soundPlayedWalking = false;
    private bool playWood1 = true;
    private bool backGroundSoundPlaying = true;
    private bool sewingItemSoundLock = false;

    void Update()
    {
        if (backGroundSoundPlaying)
        {
            backGroundSoundPlaying = false;
            audioSourceBackGroundSound.PlayOneShot(backGroundSound);
            StartCoroutine(LoopBackGroundSound());
        }

        // Walking sound toggler
        if (cameraMovement != null && cameraMovement.IsWalking() && !soundPlayedWalking)
        {
            soundPlayedWalking = true;

            if (playWood1)
            {
                audioSourceWalking.PlayOneShot(footstep_wood_1);
            }
            else
            {
                audioSourceWalking.PlayOneShot(footstep_wood_2);
            }

            playWood1 = !playWood1;
            StartCoroutine(ResetSoundFlag());
        }

        if (stairsSoundTrigger.stairsSoundIsTriggered)
        {
            mainAudioSource.PlayOneShot(squeakladder);
            stairsSoundTrigger.stairsSoundIsTriggered = false;
        }


        // Box item loop
        for (int i = boxItemList.Count - 1; i >= 0; i--)
        {
            if (boxItemList[i] == null)
            {
                if (!soundPlayed)
                {
                    mainAudioSource.PlayOneShot(footStepMudAudioClip);
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
        if (sewingItem != null)
        {
            if (!sewingItemSoundLock && sewingKitSoundTrigger.hasCollided)
            {
                sewingItemSoundLock = true;
                mainAudioSource.PlayOneShot(sewingItemPickUpAudioClip);
            }
        }

    }

    IEnumerator ResetSoundFlag()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        soundPlayedWalking = false;
    }
    IEnumerator LoopBackGroundSound()
    {
        yield return new WaitForSeconds(3f); // Adjust the delay as needed
        backGroundSoundPlaying = true;
    }

    IEnumerator DelayedResetSound()
    {
        yield return new WaitForSeconds(0.2f);
        soundPlayed = false;
    }
}

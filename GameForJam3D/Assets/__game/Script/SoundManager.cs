using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip playerHit;
    public AudioClip playerJump;
    public AudioClip playerHealthUp;
    public AudioClip objPickUp;
    public AudioClip objPickOff;
    public AudioClip resetPos;
    public AudioClip doorOpen;

    public void PlayerGetDamage()
    {
        audioSource.PlayOneShot(playerHit);
    }

    public void PLayerJump()
    {
        audioSource.PlayOneShot(playerJump);
    }

    public void PlayerHealthUp()
    {
        audioSource.PlayOneShot(playerHealthUp);
    }

    public void ResetPosition()
    {
        audioSource.PlayOneShot(resetPos);
    }

    public void ObjectPickUp()
    {
        audioSource.PlayOneShot(objPickUp);
    }

    public void ObjectPickOff()
    {
        audioSource.PlayOneShot(objPickOff);
    }
    
    public void DoorOpen()
    {
        audioSource.PlayOneShot(doorOpen);
    }
}

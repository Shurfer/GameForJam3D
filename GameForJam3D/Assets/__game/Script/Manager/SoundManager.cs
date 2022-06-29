using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public AudioClip enemyHit;
    public AudioClip back2;
    private void Start()
    {
        StartCoroutine(back2On());
    }
    
    IEnumerator back2On()
    {
        yield return new WaitForSeconds(Random.Range(30,90));
        audioSource.PlayOneShot(back2);
    }

    public void PlayerGetDamage()
    {
        audioSource.PlayOneShot(playerHit);
    }

    public void PlayerJump()
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

    public void EnemyHit()
    {
        audioSource.PlayOneShot(enemyHit);
    }
}

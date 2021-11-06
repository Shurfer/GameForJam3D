using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public SoundManager soundManager;
    private void OnCollisionEnter(Collision collision)
    {  
        if (collision.gameObject.tag == "Door")
        {
            soundManager.DoorOpen();
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }
    }
}

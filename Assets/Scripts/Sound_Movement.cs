using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Movement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource powerup;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the character has moved and the audio is not currently playing
        if (transform.position != lastPosition && !audioSource.isPlaying)
        {
            // Randomly change the playback speed a small amount
            audioSource.pitch = Random.Range(0.9f, 1.2f);
            // Randomly change the volume a small amount
            audioSource.volume = Random.Range(0.4f, 1f);
            // Play the step sound
            audioSource.Play();
            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.pitch = 0.8f;
            audioSource.Play();
        }
        // Update lastPosition for the next frame
        if (transform.position == lastPosition && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        lastPosition = transform.position;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Small Sphere")
        {
            powerup.pitch = 1.5f;
            powerup.Play();
        }

        if(collision.gameObject.name == "Large Sphere")
        {
            powerup.pitch = 0.5f;
            powerup.Play();
        }
    }

}

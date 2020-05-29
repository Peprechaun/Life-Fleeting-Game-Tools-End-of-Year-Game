using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float health = 10f;
    public ParticleSystem zombieGuts;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;




    private void Start()
    {
        //setRigidbodyState(true);
        //setColliderState(false);
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            
            Die();
            
        }
    }
    
    void Die()
    {
        zombieGuts.Play();
        audioSource.PlayOneShot(clip, volume);
        Destroy(gameObject,2f);

        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    public AudioSource audioSource;
    
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Hellowa blin");
        ParticleSystem ps1 = GetComponent<ParticleSystem>();
        var em1 = ps1.emission;
        em1.enabled = true;
        Renderer rend1;
        rend1 = GetComponent<Renderer>();
        rend1.enabled = false;
        
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript =
                Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
}

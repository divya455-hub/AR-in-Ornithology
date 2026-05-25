using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithParticles : MonoBehaviour
{
    public AudioSource blastSound;
    public GameObject particleinstantiate;
    public Transform cracker;
    public GameObject gameobjecttodestroy;

    private void Start()
    {
        Invoke("Destroygameobject", 3);
        Invoke("ParticleSyatemPlay", 2.7f);
    }
    private void ParticleSyatemPlay()
    {
        blastSound.Play();
    }
    private void Destroygameobject()
    {
        Instantiate(particleinstantiate, cracker.position, cracker.rotation);
        Destroy(gameobjecttodestroy);
        Invoke("DestroyParent", 3);
    }
    private void DestroyParent()
    {
        Destroy(gameObject);
    }
}
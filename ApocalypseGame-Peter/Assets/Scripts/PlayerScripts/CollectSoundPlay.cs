using UnityEngine;

public class CollectSoundPlay : MonoBehaviour
{
    public AudioSource collectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Treasure"))
        {
            collectSound.Play();
        }
    }
}

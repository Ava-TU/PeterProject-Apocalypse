using UnityEngine;
using UnityEngine.Events;

public class MaterialsScript : MonoBehaviour
{

    public AudioSource collectSound;
    private void CollectMaterial()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.SetActive(false);
        Debug.Log("Mat collected");
        collectSound.Play();
        //GameEventManager.instance.miscEvents.MatCollected();
        StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectMaterial();
        }
    }
}

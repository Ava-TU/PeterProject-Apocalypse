using UnityEngine;
using UnityEngine.Events;

public class MaterialsScript : MonoBehaviour
{

    public AudioSource collectSound;
    private void CollectMaterial()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("Mat collected");
        
        //GameEventManager.instance.miscEvents.MatCollected();
        //StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectSound.Play();
            CollectMaterial();
        }
    }
}

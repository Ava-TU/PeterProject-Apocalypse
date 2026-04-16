using UnityEngine;
using UnityEngine.Events;

public class MaterialsScript : MonoBehaviour
{
    private void CollectMaterial()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);
        Debug.Log("Mat collected");
        GameEventManager.instance.miscEvents.MatCollected();
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

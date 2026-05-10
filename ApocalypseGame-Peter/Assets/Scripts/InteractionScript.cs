using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger, interacted;
    private bool insideTrigger;

    public int sceneIndex;

    // Update is called once per frame
    void Update()
    {
        if (insideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            interacted?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            insideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            insideTrigger = false;
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

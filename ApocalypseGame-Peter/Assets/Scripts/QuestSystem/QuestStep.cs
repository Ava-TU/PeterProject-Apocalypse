using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;

    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;

            //TO DO - Advance quest forward now that its finished this step

            Destroy(this.gameObject);
        }
    }
}

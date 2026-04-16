using UnityEngine;
using UnityEngine.Events;

public class CollectItemsQuestStep : QuestStep
{
    private int materialsCollected = 0;
    private int materialsToComplete = 5;

    private void OnEnable()
    {
        GameEventManager.instance.miscEvents.onMatsCollected += MatCollected;
    }

    private void OnDisable()
    {
        GameEventManager.instance.miscEvents.onMatsCollected -= MatCollected;
    }

    private void MatCollected()
    {
        if (materialsCollected < materialsToComplete)
        {
            materialsCollected++;
        }

        if (materialsCollected >= materialsToComplete)
        {
            FinishQuestStep();
        }
    }
}

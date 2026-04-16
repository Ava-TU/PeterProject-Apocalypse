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
            UpdateState();
        }

        if (materialsCollected >= materialsToComplete)
        {
            FinishQuestStep();
        }
    }

    private void UpdateState()
    {
        string state = materialsCollected.ToString();
        ChangeState(state);
    }

    protected override void SetQuestStepState(string state)
    {
        this.materialsCollected = System.Int32.Parse(state);
        UpdateState();
    }
}

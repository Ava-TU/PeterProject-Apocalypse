using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    public KeyCode submit;

    private bool isPlayerNear = false;
    private string questId;
    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void Update()
    {
        if (Input.GetKeyDown((submit)))
        {
            SubmitPressed();
        } 
        
    }

    private void SubmitPressed()
    {
        if (!isPlayerNear)
        {
            return;
        }

        GameEventManager.instance.questEvents.StartQuest(questId);
        GameEventManager.instance.questEvents.AdvanceQuest(questId);
        GameEventManager.instance.questEvents.FinishQuest(questId);

    }

    private void QuestStateChange(Quest quest)
    {
        //only update the quest state if this point has the corresponding quest
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest with id: "+ questId + " updated to state: "+ currentQuestState);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}

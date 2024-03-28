using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EnduranceTaskSystem : MonoBehaviour
{
    [SerializeField] private EnduranceTaskEntity entity;
    [SerializeField] private EnduranceTaskPlayer player;
    [SerializeField] private int jobRequire;

    //TODO - Make JobQuestObjectiveInteraction system:
    [SerializeField] private QuestObjective quest;
    [SerializeField] private bool ConnectToQuest = true;

    public delegate void OnEnduranceTaskComplete(QuestObjective quest, int offset);
    public static event OnEnduranceTaskComplete OnEnduranceTaskCompleteEvent;

    private PlayerInput input;
    private Player playerInstance;
    private GameObject playerGameObject;

    private float attackCooldown = .55f;
    private float CurrentCooldown;

    void OnEnable()
    {
        FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Abort").performed += AbortEvent;
        FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Use").performed += Damage;
    }

    void OnDisable()
    {
        FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Abort").performed -= AbortEvent;
        FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Use").performed -= Damage;
    }

    private void Damage(InputAction.CallbackContext context) 
    {  
        if(Time.time > CurrentCooldown)
        {
            entity.Damage(playerInstance.attack.TotalValue);
            CurrentCooldown = Time.time + attackCooldown;
        }
    }
    private void AbortEvent(InputAction.CallbackContext context) {
        Finish(true); 
        FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Abort").performed -= AbortEvent;
        FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Use").performed -= Damage;
    }

    public void Setup(Player player, GameObject target, ItemInstance itemInstance, QuestObjective quest, bool ConnectToQuest)
    {
        playerInstance = player;
        playerGameObject = player.gameObject;

        input = FindObjectOfType<PlayerInput>();
        input.actions.FindActionMap("Player").Disable();
        input.actions.FindActionMap("EnduranceTask").Enable();
        this.entity = target.AddComponent<EnduranceTaskEntity>();
        this.entity.enduranceTaskSystem = this;
        this.entity.itemInstance = itemInstance;
        this.player = playerGameObject.AddComponent<EnduranceTaskPlayer>();
        this.player.taskPos = target.transform.position;
        this.quest = quest;
        this.ConnectToQuest = ConnectToQuest;

    }

    public UnityEvent Finish(bool abort = false)
    {
        input.actions.FindActionMap("EnduranceTask").Disable();
        input.actions.FindActionMap("Player").Enable();

        if(ConnectToQuest && !abort)
        {
            quest.currentAmount++;
            
            OnEnduranceTaskCompleteEvent(
                quest,  
                0       // MINER OFFSET
            );
        }

        if(abort)
            FindObjectOfType<EnduranceTaskTrigger>().hasBeenActivated = false;
        else
            FindObjectOfType<EnduranceTaskTrigger>().onFinish?.Invoke();

        Destroy(player);

        return null;
    }
}
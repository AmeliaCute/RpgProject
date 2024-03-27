using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EnduranceTaskTrigger : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    [SerializeField] private GameObject transitions;
    [SerializeField] private ItemInstance itemInstance;
    [SerializeField] private bool isTrigger = false;
    public bool hasBeenActivated = false;
    [SerializeField] private int jobRequire;
    [SerializeField] private QuestObjective quest;
    [SerializeField] private bool connectToQuest = true;
    public UnityEvent onFinish;

    private Player player;
    private JobManager jobManager;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        jobManager = GameObject.FindObjectOfType<JobManager>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    void OnEnable()
    {
        use.action.performed += PerformUse;
    }

    void OnDisable()
    {
        use.action.performed -= PerformUse;
    }

    public void PerformUse(InputAction.CallbackContext context)
    {
        if(isTrigger && !hasBeenActivated && player.jobManager.jobs[0].level >= 1)
        {
            hasBeenActivated = true;
            Instantiate(transitions, GameObject.FindGameObjectsWithTag("CANVAS")[0].GetComponent<Canvas>().transform);
            gameObject.AddComponent<EnduranceTaskSystem>().Setup(GameObject.FindObjectOfType<Player>(), gameObject, itemInstance, quest, connectToQuest);
        }
    }
}
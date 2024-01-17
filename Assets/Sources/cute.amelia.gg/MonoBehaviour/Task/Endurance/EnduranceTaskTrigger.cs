using UnityEngine;
using UnityEngine.InputSystem;

public class EnduranceTaskTrigger : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    [SerializeField] private GameObject transitions;
    [SerializeField] private ItemInstance itemInstance;
    [SerializeField] private bool isTrigger = false;


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

    private void PerformUse(InputAction.CallbackContext context)
    {
        if(isTrigger)
        {
            Instantiate(transitions).transform.SetParent(GameObject.FindGameObjectsWithTag("CANVAS")[0].GetComponent<Canvas>().transform, false);
            gameObject.AddComponent<EnduranceTaskSystem>().Setup(GameObject.FindObjectOfType<Player>(), gameObject, itemInstance);
        }
    }
}
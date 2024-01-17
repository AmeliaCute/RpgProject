using UnityEngine;
using UnityEngine.InputSystem;

public class DropTest : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    public ItemInstance items;
    [SerializeField] private bool infinite = false;
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
            GameObject.FindObjectOfType<Player>().AddItem(items);
            if(!infinite)
                Destroy(gameObject);
        }
    }
}
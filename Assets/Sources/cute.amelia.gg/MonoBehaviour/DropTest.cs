using UnityEngine;
using UnityEngine.InputSystem;

public class DropTest : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    [SerializeField] private ItemInstance items;
    [SerializeField] private bool isTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HEYYYYYYYYYYYY");
        isTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("BYYYYYYYYYYYYYYE");
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
        }
    }
}
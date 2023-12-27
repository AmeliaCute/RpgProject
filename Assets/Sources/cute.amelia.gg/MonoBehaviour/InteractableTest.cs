using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableTest : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    [SerializeField] private GameObject prefab;
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
            GameObject.Instantiate(prefab).transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class DropTest : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    [SerializeField] private Animator panel;
    [SerializeField] private CameraLooker cameraLooker;
    public ItemInstance items;
    [SerializeField] private bool infinite = false;
    [SerializeField] private bool isTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        cameraLooker.updateObject = true;
        panel.Play("DropInfoPanelShow");
    }
    void OnTriggerExit(Collider other)
    {
        isTrigger = false;
        cameraLooker.updateObject = false;
        panel.Play("DropInfoPanelClose");
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
            panel.Play("DropInfoPanelClose");
            if(!infinite)
            {
                isTrigger = false;
                Destroy(gameObject, 0.15f);
            }
        }
    }
}
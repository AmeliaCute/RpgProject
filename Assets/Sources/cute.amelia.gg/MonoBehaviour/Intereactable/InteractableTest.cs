using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractableTest : MonoBehaviour
{
    [SerializeField] private InputActionReference use;
    [SerializeField] private GameObject prefab;
    
    [SerializeField] private Animator panel;
    [SerializeField] private CameraLooker cameraLooker;
    [SerializeField] private bool isTrigger = false;
    [SerializeField] private Text interactionText;
    [SerializeField] private string InteractionName = "Popen UwU";
    
    void Start()
    {
        interactionText.text = InteractionName;
    }

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
            GameObject.Instantiate(prefab, GameObject.FindGameObjectsWithTag("CANVAS")[0].GetComponent<Canvas>().transform);
    }
}
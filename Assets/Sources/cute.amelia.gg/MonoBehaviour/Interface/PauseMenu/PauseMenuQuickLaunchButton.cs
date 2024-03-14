using UnityEngine;
using UnityEngine.UI;

public class PauseMenuQuickLaunchButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject quickLaunchUI;
    void Start()
    {
        button.onClick.AddListener(() => GameObject.Instantiate(quickLaunchUI, GameObject.FindGameObjectsWithTag("CANVAS")[0].GetComponent<Canvas>().transform));
    }
}
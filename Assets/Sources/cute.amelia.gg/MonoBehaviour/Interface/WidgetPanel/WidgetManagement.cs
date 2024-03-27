using UnityEngine;

public class WidgetManagement : MonoBehaviour
{
    [SerializeField] private Animator WidgetPanelAnimator;
    [SerializeField] private GameObject left,top,bottom,rightbottom;
    
    private bool isClosed = false;
    public static WidgetManagement instance;
    void Start()
    {
        instance = this;
    }

    public void OpenPanel()
    {   
        if(!isClosed) return;
        WidgetPanelAnimator.Play("WidgetPanelOpen");
        isClosed = false;
    }

    public void ClosePanel()
    {
        if(isClosed) return;
        WidgetPanelAnimator.Play("WidgetPanelClosing");
        isClosed = true;
    }

    public void AttachWidget(GameObject widget, WidgetEmplacement placement)
    {
        switch(placement)
        {
            case WidgetEmplacement.Left:
                widget.transform.SetParent(left.transform);
                break;
            case WidgetEmplacement.Top:
                widget.transform.SetParent(top.transform);
                break;
            case WidgetEmplacement.Bottom:
                widget.transform.SetParent(bottom.transform);
                break;
            case WidgetEmplacement.BottomRight:
                widget.transform.SetParent(rightbottom.transform);  
                break;
            default:
                break;
        }
    }
}

public enum WidgetEmplacement
{
    Left,
    Top,
    Bottom,
    BottomRight //TODO - Implement bottom right placement
}
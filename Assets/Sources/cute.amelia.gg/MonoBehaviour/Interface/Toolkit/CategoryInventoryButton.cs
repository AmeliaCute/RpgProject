using UnityEngine;
using UnityEngine.UI;

public class CategoryInventoryButton : MonoBehaviour
{
    [SerializeField] ItemCategory category;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ItemInventoryCreator iic =  FindObjectOfType<ItemInventoryCreator>();
            iic.ChangeCategory(category);
            iic.reload();
        });
    }
}
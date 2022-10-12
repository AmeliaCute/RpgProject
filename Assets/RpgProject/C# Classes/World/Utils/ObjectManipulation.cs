using UnityEngine;

public class ObjectManipulation {

    public static void SetLayerRecursively(GameObject go, int layerNumber) {
        if (go == null) return;
        go.layer = layerNumber;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true)) {
            trans.gameObject.layer = layerNumber;
        }
    }
}
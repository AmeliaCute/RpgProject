using UnityEngine;

class GrassRenderHelper : MonoBehaviour
{
    Renderer rend;
    Transform p_trans;

    void Start()
    {
        rend = GameObject.FindObjectOfType<Terrain>().GetComponent<Renderer>();
        p_trans = RpgClass.PLAYER.entityPlayer.transform;
        rend.material.shader = Shader.Find("Custom/GeometryGrass");
    }

    void Update()
    {
        rend.material.SetVector("_PositionMoving", p_trans.position);
    }
}
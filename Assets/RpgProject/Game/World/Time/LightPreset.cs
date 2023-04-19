using UnityEngine;

[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Time/Lighting Preset")]
public class LightPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}

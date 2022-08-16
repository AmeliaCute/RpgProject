using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

[ExecuteAlways]
public class Manager : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private VolumeProfile Volumefog;
    [SerializeField] private LightPreset preset;

    private Fog fog;

    private void Update()
    {
        if(preset == null)
            return;
        if(Application.isPlaying)
        {
            LightVar.time += Time.deltaTime / 60;
            LightVar.time %= 24;
            UpdateLighting(LightVar.time / 24f);
        }    
        else
        {
            UpdateLighting(LightVar.time / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        fog.albedo.value = preset.FogColor.Evaluate(timePercent);

        if(_light != null)
        {
            _light.color = preset.DirectionalColor.Evaluate(timePercent);
            _light.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0f));
        }
    }

    private void OnValidate()
    {
        Volumefog.TryGet(out fog);
        if (_light != null)
        {
            return;
        }
        if(RenderSettings.sun != null)
        {
            _light = RenderSettings.sun;
        }
        else
        {
            Debug.LogError("No light found");
            Debug.LogError("Please add a light to the scene");
        }
    }

    public float getTime()
    {
        return LightVar.time;
    }
}

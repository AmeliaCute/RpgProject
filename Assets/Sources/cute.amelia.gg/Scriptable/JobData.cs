using UnityEngine;

[CreateAssetMenu(menuName = "JobData")]
public class JobData : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
    [Range(1,20)]
    public int maxLevel;
    public int baseLevelExp;
}
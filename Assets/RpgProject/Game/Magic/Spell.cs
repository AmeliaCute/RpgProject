using UnityEngine;
using UnityEngine.UI;
using Action = RpgProject.Framework.Graphics.Overlays.Action;

namespace RpgProject.Magic
{
    public class Spell
    {
        public string Name;
        public Sprite Image;
        public Action OnTouchEnemy;
        public GameObject TrailPrefab;
        public float TrailSpeed;

        public Spell(string name, Sprite image, Action onTouchEnemy, GameObject trailPrefab, float trailSpeed)
        {
            Name = name;
            Image = image;
            OnTouchEnemy = onTouchEnemy;
            TrailPrefab = trailPrefab;
            TrailSpeed = trailSpeed;
        }
    }
}
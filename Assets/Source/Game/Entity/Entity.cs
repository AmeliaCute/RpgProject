using UnityEngine;
using UnityEngine.Events;

namespace RpgProject.Game.Entity
{
    public class Entity : MonoBehaviour
    {
        public event UnityAction TakeDamage;
        public virtual bool Damageable { get; set; } = true;
        public virtual bool HasEndurance { get; set; } = false;
        public virtual bool ByPassGamestatePriority { get; set; } = false;
        public virtual string Name { get; set; } = "Entity";
        public virtual string EntityMarker { get; set; } = "ENTITY";
        public virtual string DisplayName { get; set; } = null;

        public virtual float MaxHealth { get; set; } = 1;
        public float health;

        public virtual float MaxEndurance { get; set; } = 0;
        public float endurance;

        private void Awake()
        {
            gameObject.tag = EntityMarker;
            init();
            if (Damageable) health = MaxHealth;
            if (HasEndurance) endurance = MaxEndurance;
        }

        private void Update()
        {
            if (Gamestates.get() == GameState.PLAYING || ByPassGamestatePriority) update();
            if (Gamestates.get() == GameState.BUSY) busyUpdate();
        }

        public void takeDamage(float damage)
        {
            if(Damageable)
            {
                health -= damage;

                if(health <= 0)
                {
                    health = 0;
                    die();
                    return;
                }

                TakeDamage?.Invoke();
            }
        }

        public GameObject Control()
        {
            return gameObject;
        }

        public virtual void init() { }
        public virtual void update() { }
        public virtual void die() { }
        public virtual void busyUpdate() { }
        public static void SpawnGameObject(GameObject gameObject, Vector3 position, Vector3 rotation)
        {
            GameObject gb = GameObject.Instantiate(gameObject);
            gb.transform.position = position;
            gb.transform.rotation = Quaternion.Euler(rotation);
        }
        public static void SpawnGameObject(GameObject gameObject, Vector3 position, Quaternion rotation)
        {
            GameObject gb = GameObject.Instantiate(gameObject);
            gb.transform.position = position;
            gb.transform.rotation = rotation;
        }
    }
}
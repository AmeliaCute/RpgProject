using UnityEngine;
using RpgProject.Magic;

namespace RpgProject.Objects
{
    public class Wand : Weapon
    {
        //private GameObject trailsPrefab;
        public readonly float trailSpeed = 20f;
        public readonly float enduranceUse = 40f;
        public override string secret_type => "211929052023";

        public Wand(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon, float Durability, Quality quality, int Damage, float Reloadtime,int attackRange): base(name,rarity, description, price, itemModel, itemIcon, Durability, quality, Damage, Reloadtime, attackRange) 
        {
            this.Damage = Damage;
            this.reloadTime = Reloadtime;
            this.attackRange = attackRange;
            //this.trailsPrefab = trailsPrefab;
        }


        //public GameObject getTrailsPrefab() { return trailsPrefab; }

        public void SendAttack()
        {
            var gameObject = new GameObject("TempsTrails");
            var x = gameObject.AddComponent<TrailProjectile>();

            //x.trailPrefab = trailsPrefab;
            x.trailSpeed = trailSpeed;
            x.Damage = Damage;
            x.CreateTrail();

            Player.instance.endurance -= enduranceUse;
        }
    }

    public class TrailProjectile : MonoBehaviour
    {
        public int Damage;
        public Spell trail;
        public float trailSpeed = 20f;
        public GameObject currentTrail;
        public TrailRenderer trailRenderer;
        public float maxTimeBeforeDestroy = 2f;
        public float time;

        private Vector3 playerPos;

        private void Start()
        {
            time = Time.time;
            trailSpeed = trail.TrailSpeed;


            playerPos = Player.instance.transform.TransformDirection(Vector3.right);
        }

        private void Update()
        {
            if (currentTrail != null)
            {
                currentTrail.transform.position += playerPos * trailSpeed * Time.deltaTime;

                RaycastHit hit;
                if (Physics.Raycast(currentTrail.transform.position,  playerPos, out hit, trailSpeed * Time.deltaTime))
                {
                    RpgClass.RPGLOGGER.Warning("The trail touched somethings: " + hit.collider.gameObject.name);
                    if(hit.collider.gameObject.tag == "Entity" || hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<Entity>().takeDamage(Damage);
                    }
                    Destroy(gameObject);
                    Destroy(currentTrail);
                }

                if (Time.time > time + maxTimeBeforeDestroy)
                {
                    Destroy(currentTrail);
                    Destroy(gameObject);
                }
            }
        }

        public void CreateTrail()
        {
            if (currentTrail != null)
                Destroy(currentTrail);

            // Instancie la trail à partir du prefab
            currentTrail = Instantiate(trail.TrailPrefab, Player.instance.transform.position, Player.instance.transform.rotation);
            trailRenderer = currentTrail.GetComponent<TrailRenderer>();
        }
    }
}
using UnityEngine;

namespace RpgProject.Objects
{
    public class Wand : Weapon
    {
        private GameObject trailsPrefab;
        public override string secret_type => "211929052023";

        public Wand(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon, float Durability, Quality quality, int Damage, float Reloadtime,int attackRange, GameObject trailsPrefab): base(name,rarity, description, price, itemModel, itemIcon, Durability, quality, Damage, Reloadtime, attackRange) 
        {
            this.Damage = Damage;
            this.reloadTime = Reloadtime;
            this.attackRange = attackRange;
            this.trailsPrefab = trailsPrefab;
        }

        public GameObject getTrailsPrefab() { return trailsPrefab; }

        public void SendAttack()
        {
            var gameObject = new GameObject("TempsTrails");
            var x = gameObject.AddComponent<TrailProjectile>();
            x.trailPrefab = trailsPrefab;
            x.CreateTrail();
            x.Damage = Damage;
        }
    }

    public class TrailProjectile : MonoBehaviour
    {
        public int Damage;
        public GameObject trailPrefab;
        public float trailSpeed = 20f;
        public GameObject currentTrail;
        public TrailRenderer trailRenderer;
        public float maxTimeBeforeDestroy = 2f;
        public float time;

        private Vector3 playerPos;

        private void Start()
        {
            time = Time.time;
            playerPos = Player.instance.transform.TransformDirection(Vector3.right);
        }

        private void Update()
        {
            if (currentTrail != null)
            {
                // Fait avancer la trail dans la direction du joueur
                currentTrail.transform.position += playerPos * trailSpeed * Time.deltaTime;

                // Lance un raycast pour détecter les collisions avec les objets
                RaycastHit hit;
                if (Physics.Raycast(currentTrail.transform.position,  playerPos, out hit, trailSpeed * Time.deltaTime))
                {
                    // Si la trail touche un objet, renvoie l'objet touché
                    RpgClass.RPGLOGGER.Warning("The trail touched somethings: " + hit.collider.gameObject.name);
                    if(hit.collider.gameObject.tag == "Entity" || hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<Entity>().takeDamage(Damage);
                    }
                    Destroy(gameObject);
                    Destroy(currentTrail);
                }

                // Si la trail a atteint la distance maximale, la détruit
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
            currentTrail = Instantiate(trailPrefab, Player.instance.transform.position, Player.instance.transform.rotation);
            trailRenderer = currentTrail.GetComponent<TrailRenderer>();
        }
    }
}
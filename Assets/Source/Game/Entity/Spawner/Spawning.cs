using UnityEngine;

namespace RpgProject.Game.Entity
{
    class Spawning : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameObjectPrefab;

        public void Load()
        {
            gameObject.SetActive(false);
            Entity.SpawnGameObject(gameObjectPrefab, transform.position, transform.rotation);
        }

        public static void LoadAll()
        {
            var objects = GameObject.FindGameObjectsWithTag("SpawnableObject");
            foreach (var go in objects)
                go.GetComponent<Spawning>().Load();
        }
    }
}
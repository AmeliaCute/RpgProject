using RpgProject.Framework.Thread;
using UnityEngine;

namespace RpgProject.Game.Threaded
{
    public class Camera : ThreadedRedundantTask
    {
        public GameObject camera;
        public Camera() : base("camera.thread", RpgClass.SETTINGS.Values.Framerate / 1000)
        {
            camera = GameObject.FindObjectOfType<UnityEngine.Camera>().gameObject;
        }

        public override void Update()
        {
           if(Gamestates.get() == GameState.PLAYING)
           {
                Vector3 pPos = RpgClass.PLAYER.gameObject.transform.position;
                camera.transform.position = new Vector3(pPos.x, pPos.y + 4f, pPos.z-6f);
           }
        }
    }
}
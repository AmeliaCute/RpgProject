using RpgProject.Framework.Graphics;
using RpgProject.Framework.Screens.Game;
using RpgProject.Framework.Thread;
using UnityEngine;

namespace RpgProject.Game.Threaded
{
    public class Interface : ThreadedRedundantTask
    {
        public static StatBar statBar;
        public Interface() : base("interface.thread", 33)
        {
            statBar = new();
        }

        public override void Update()
        {
            Drawable.NewSize(GameObject.Find("statbar.endurance.overlay").GetComponent<RectTransform>(), new(Player.instance.endurance / Player.instance.maxEndurance * 2.4f, 0.05f));
        }
    }
}
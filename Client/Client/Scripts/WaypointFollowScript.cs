using Client.GameObjects;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Scripts
{
    public class WaypointFollowScript : ScriptComponent
    {
        public List<Vector3> Waypoints = new List<Vector3>();
        public int index = 0;
        public float Move = 1;

        public WaypointFollowScript(List<Vector3> locations) : base()
        {
            Waypoints = locations;
        }

        public override void Update()
        {
            if (Waypoints.Count == 0)
            {
                Waypoints = Owner.Scene.GetGameObjects<Waypoint>().Select(w => w.Location).ToList();
            }

            base.Update();
        }


    }
}

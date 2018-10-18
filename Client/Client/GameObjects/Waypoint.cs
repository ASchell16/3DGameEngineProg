using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GameObjects
{
    public class Waypoint: GameObject
    {
        public Vector3 location { get; set; }

        public Waypoint(Vector3 location) : base(location)
        {
            this.location = location;
        }
    }
}

using Engine.Base;
using Client.Scripts;
using Engine.Components.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GameObjects
{
    public class SimpleMeshObjects : GameObject
    {
        private string asset;

        public SimpleMeshObjects(string asset, Vector3 location) : base(location)
        {
            this.asset = asset;
        }

        public override void Initialize()
        {
            List<Vector3> locations = new List<Vector3>();
            locations.Add(new Vector3(-3, 0, 0));
            locations.Add(new Vector3(0, 3, 0));
            locations.Add(new Vector3(3, 0, 0));


            AddComponent(new BasicEffectModel(asset));
            if (asset == "cube")
            {
                AddComponent(new RotateObject(new Vector3(25, 25, 25)));
                AddComponent(new WaypointFollowScript(locations));
          
               // AddComponent(new BobbingObject(10));
            }
           
           
            base.Initialize();
        }
    }
}

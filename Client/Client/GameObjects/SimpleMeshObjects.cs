using Engine.Base;
using Client.Scripts;
using Engine.Components.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Components.Cameras;
using Engine.Components.Physics;

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
            // add objects 


            //List<Vector3> locations = new List<Vector3>();
            //locations.Add(new Vector3(-3, 0, 0));
            //locations.Add(new Vector3(0, 3, 0));
            //locations.Add(new Vector3(3, 0, 0));
     

            AddComponent(new BasicEffectModel(asset));
            //if (asset == "cube")
            //{
            //    //AddComponent(new BobbingObject(10));
            //    //AddComponent(new RotateObject(new Vector3(25, 0, 0)));
            //    //AddComponent(new WaypointFollowScript(locations));
               
            //}

            AddComponent(new BoxBody(1));
            //AddComponent(new StaticMeshBody());
            //AddComponent(new DebugComponent());
            //AddComponent(new FixedCamera(Vector3.Forward, 1, 10));
           
           
            base.Initialize();
        }
    }
}

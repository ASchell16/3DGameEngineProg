using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine.Base;
using Client.GameObjects;

namespace Client.Scenes
{
    class SimpleScene : Scene
    {
        public SimpleScene() : base()
        {

        }

        public override void Initialize()
        {
            

            AddObject(new SimplePlayerObject("cube", new Vector3(0, 0, 10)));
            AddObject(new SimpleMeshObjects("cube", new Vector3(0, 0, -10)));
            AddObject(new SimpleMeshObjects("plane", new Vector3(0, -2, 0)));

            base.Initialize();
        }
    }
}

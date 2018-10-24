using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Scripts;
using Engine.Base;
using Engine.Components.Cameras;
using Engine.Components.Input;
using Microsoft.Xna.Framework;

namespace Client.GameObjects
{
    public class SimplePlayerObject : GameObject
    {
        private string asset;
        public SimplePlayerObject(string asset, Vector3 location) : base(location)
        {
            this.asset = asset;
        }

        public override void Initialize()
        {
            AddComponent(new FixedCamera(new Vector3(0, 0, -1)));
            AddComponent(new PlayerMovementController(10));         
            
            base.Initialize();
        }
    }
}

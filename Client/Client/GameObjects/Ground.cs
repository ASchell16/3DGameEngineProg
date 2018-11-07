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
    public class Ground : GameObject
    {
        private string asset;

        public Ground(string asset, Vector3 location) : base(location)
        {
            this.asset = asset;
        }

        public override void Initialize()
        {
            AddComponent(new BasicEffectModel(asset));
            AddComponent(new StaticMeshBody());

            base.Initialize();
        }
    }
}

using Engine;
using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Scripts
{
    public class BobbingObject : ScriptComponent
    {
        public float BobbingAmount { get; set; }
        public Vector3 StartLocation { get; set; }
        private float MaxY, MinY;
        private bool IsMovingUp = true;

        public BobbingObject(float bobbing)
            : base()
        {
            BobbingAmount = bobbing;
        }

        public override void Initialize()
        {
            MaxY = StartLocation.Y + 1;
            MinY = StartLocation.Y - 1;
            

            base.Initialize();
        }

        public override void Update()
        {
            if (IsMovingUp)
            {
                Owner.World *= Matrix.CreateTranslation(0, BobbingAmount * GameUtilities.DeltaTime, 0);
                if (Owner.Location.Y > MaxY)
                    IsMovingUp = false;
            }
            if (!IsMovingUp)
            {
                Owner.World *= Matrix.CreateTranslation(0, -BobbingAmount * GameUtilities.DeltaTime, 0);
                if (Owner.Location.Y < MinY)
                    IsMovingUp = true;
            }

            base.Update();
        }

    }
}

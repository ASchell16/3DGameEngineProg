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
    public class RotateObject : ScriptComponent
    {
        public Vector3 RotationToBeApplied { get; set; }

        public RotateObject(Vector3 rotation)
               : base()
        {
            RotationToBeApplied = rotation;
        }

        public override void Update()
        {
            var translation = Owner.Location;
            // Change axis to local axis by subtracting the location
            Owner.World *= Matrix.CreateTranslation(-translation);     
            
            // rotate on all axis's
            Owner.World *= Matrix.CreateRotationX(MathHelper.
                                                  ToRadians(RotationToBeApplied.X 
                                                   * GameUtilities.DeltaTime));
            Owner.World *= Matrix.CreateRotationY(MathHelper.
                                                  ToRadians(RotationToBeApplied.Y 
                                                  * GameUtilities.DeltaTime));
            Owner.World *= Matrix.CreateRotationZ(MathHelper.
                                                  ToRadians(RotationToBeApplied.Z 
                                                  * GameUtilities.DeltaTime));

            // reset the location back 
            Owner.World *= Matrix.CreateTranslation(translation);



        }
    }
}

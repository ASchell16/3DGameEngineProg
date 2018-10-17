using Engine.Base;
using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Engine.Components.Input
{
    public class PlayerMovementController : ScriptComponent
    {
        public float MovementSpeed { get; set; }
              

        public PlayerMovementController(float speed) : base()
        {
            MovementSpeed = speed;
        }

        public override void Update()
        {            

            if (InputManager.IsKeyHeld(Keys.W))
            {
              Owner.World *= Matrix.CreateTranslation(0, 0, MovementSpeed * GameUtilities.DeltaTime );
            }
            if (InputManager.IsKeyHeld(Keys.S))
            {
                Owner.World *= Matrix.CreateTranslation(0, 0, -MovementSpeed * GameUtilities.DeltaTime);
            }
            if (InputManager.IsKeyHeld(Keys.A))
            {
                Owner.World *= Matrix.CreateTranslation(-MovementSpeed * GameUtilities.DeltaTime, 0, 0);
            }
            if (InputManager.IsKeyHeld(Keys.D))
            {
                Owner.World *= Matrix.CreateTranslation(MovementSpeed * GameUtilities.DeltaTime, 0, 0);
            }

            base.Update();
        }
    }
}

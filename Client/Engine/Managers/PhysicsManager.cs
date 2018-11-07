using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BEPUphysics;
using BEPUphysics.Entities;
using BEPUphysics.BroadPhaseEntries;

namespace Engine.Managers
{
    public class PhysicsManager : GameComponent
    {
        public static Space WorldSpace;

        public override void Initialize()
        {

            base.Initialize();
        }
        public PhysicsManager(Game game) : base(game)
        {
            
            WorldSpace = new Space();
            SetGravity(-9.8f);
            game.Components.Add(this);
        }
        public static void SetGravity(float gravity)
        {
            if(WorldSpace != null)
            {
                WorldSpace.ForceUpdater.Gravity = new BEPUutilities.Vector3
                                                                    (0, gravity, 0);
            }
        }
        public static void AddEntity(Entity newEntity)
        {
            if (newEntity != null)
                if (!WorldSpace.Entities.Contains(newEntity))
                    WorldSpace.Add(newEntity);
        }
        public static void RemoveEntity(Entity entity)
        {
            try
            {
                if (WorldSpace.Entities.Contains(entity))
                    WorldSpace.Remove(entity);
            }
            catch (Exception)
            {

            }
        }
        public static void AddStaticMesh(StaticMesh mesh)
        {
            WorldSpace.Add(mesh);
        }
        public static void RemoveStaticMesh(StaticMesh mesh)
        {
            WorldSpace.Remove(mesh);
        }
        public override void Update(GameTime gameTime)
        {
            WorldSpace.Update(GameUtilities.DeltaTime);
            base.Update(gameTime);
        }

    }
}

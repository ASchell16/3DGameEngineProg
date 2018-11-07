using BEPUphysics.Entities;
using Engine.Base;
using Engine.Components.Graphics;
using Engine.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public abstract class PhysicsComponent : Component
    {
        public Entity Entity { get; set; }

        public float Mass { get; set; }
        public PhysicsComponent(float mass):base()
        {
            Mass = mass;
        }
        public override void Destroy()
        {
            PhysicsManager.RemoveEntity(Entity);
            base.Destroy();
        }

        public override void Initialize()
        {
            if (Entity != null)
            {
                GameObjectInfo info = new GameObjectInfo(Owner.ID, Owner.GetType());
                Entity.CollisionInformation.Tag = info;
                Entity.Tag = info;

                PhysicsManager.AddEntity(Entity);
            }
            base.Initialize();
        }

       

        public Model TryAndGetModelFromOwner()
        {
            if (Owner.HasComponent<BasicEffectModel>())
            {
                try
                {
                    var result = Owner.GetComponent<BasicEffectModel>();
                    if (result.Model != null)
                        return result.Model;
                }
                catch
                {
                    return null;
                }
            }
            return null; 
        }

        public override void Update()
        {
            if (Entity != null)
                Owner.World = MathConverter.Convert(Entity.WorldTransform);
            base.Update();
        }

        public class GameObjectInfo
        {
             public Type GameObjectType { get; set; }
             public string ID { get; set; }

             public GameObjectInfo(string id, Type type)
             {
                ID = id;
                GameObjectType = type;

             }
        }
    }

  

}

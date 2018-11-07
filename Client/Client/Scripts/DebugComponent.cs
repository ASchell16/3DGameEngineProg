using Engine;
using Engine.Base;
using Engine.Components.Cameras;
using Engine.Components.Graphics;
using Engine.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*_____________________________________________________________________
    Collision Component

 */
namespace Client.Scripts
{
    public class DebugComponent: Component
    {
       
        public BoundingBox AABB;
        public BoundingSphere AABS;

        BasicEffectModel modelComponent;
        FixedCamera cameraComponent;

        public override void PostInitialize()
        {
            if (Owner.HasComponent<BasicEffectModel>())
            {
                //get model component
                modelComponent = Owner.GetComponent<BasicEffectModel>();
                if (modelComponent.Model != null)
                {
                    //extract Verticies from model
                    Vector3[] vertices;
                    int[] indices;
                    ModelDataExtractor.GetVerticesAndIndicesFromModel(modelComponent.Model, 
                                                                      out vertices,
                                                                      out indices);

                    AABB = BoundingBox.CreateFromPoints(vertices);
                    AABB.Min = Vector3.Transform(AABB.Min, Owner.World);
                    AABB.Max = Vector3.Transform(AABB.Max, Owner.World);
                    AABS = BoundingSphere.CreateFromPoints(vertices);
                    AABS.Center = Vector3.Transform(AABS.Center, Owner.World);
                    
                }
                if (Owner.HasComponent<FixedCamera>())
                {
                    cameraComponent = Owner.GetComponent<FixedCamera>();
                }
            }
            base.PostInitialize();
        }
        public override void Update()
        {
            if (AABB != null && AABS != null)
            {
                //DebugManager.AddBoundingBox(AABB, Color.LawnGreen);
                //DebugManager.AddBoundingSphere(AABS, Color.Red);
            }
            if (cameraComponent != null)
            {
                //cameraComponent.CameraDirection = Owner.World.Forward;
                //DebugManager.AddBoundingFrustum(cameraComponent.Frustum, Color.PapayaWhip);

            }

            base.Update();
        }

    }
}

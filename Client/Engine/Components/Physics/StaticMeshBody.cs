using BEPUphysics.BroadPhaseEntries;
using Engine.Base;
using Engine.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Components.Physics
{
    public class StaticMeshBody : PhysicsComponent
    {
        public StaticMeshBody() : base(0)
        {

        }

        public override void Initialize()
        {
            var model = TryAndGetModelFromOwner();
            if (model != null)
            {
                Vector3[] vertices;
                int[] Indices;

                ModelDataExtractor.GetVerticesAndIndicesFromModel(model, out vertices, out Indices);
                StaticMesh mesh = new StaticMesh(MathConverter.Convert(vertices), Indices);
                PhysicsManager.AddStaticMesh(mesh);
            }

            base.Initialize();
        }
    }
}

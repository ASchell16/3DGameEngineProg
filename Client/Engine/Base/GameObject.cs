using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public abstract class GameObject
    {
        public string ID { get; set; }
        public bool Enabled { get; set; }

        public event ObjectIDHandler OnDestroy;

        public Matrix World { get; set; }
        public Vector3 Location { get { return World.Translation; } }
        public Vector3 Scale { get { return World.Scale; } }
        public Quaternion Rotation { get { return World.Rotation; } }

        public GameObject Parent { get; set; }
        public List<GameObject> Children { get; set; }

        private List<Component> commponents = new List<Component>();
        public List<Component> Components { get { return commponents; } }

        private List<string> awaitingRemoval = new List<string>();

        private bool isInitialized = false;
        public bool IsInitialized  { get { return IsInitialized; } }



    }
}

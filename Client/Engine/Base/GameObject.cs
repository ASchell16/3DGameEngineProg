using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Base;

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

        private List<Component> components = new List<Component>();
        public List<Component> Components { get { return components; } }

        private List<string> awaitingRemoval = new List<string>();

        private bool isInitialized = false;
        public bool IsInitialized  { get { return IsInitialized; } }



        public virtual void Initialize()
        {
            foreach (var init in components)
            {
                init.Initialize();
                init.Enabled = true;
            }

            isInitialized = true;
        }

        public GameObject()
        {
            ID = this.GetType().Name + Guid.NewGuid();
            Enabled = true;
            World = Matrix.Identity;
            Children = new List<GameObject>();

        }
        public GameObject(Vector3 location)
        {
            ID = this.GetType().Name + Guid.NewGuid();
            Enabled = true;
            World = Matrix.Identity * Matrix.CreateTranslation(location);
            Children = new List<GameObject>();
        }
        public void AddComponent(Component newComponent)
        {
            newComponent.Owner = this;

            if (IsInitialized)
                newComponent.Initialize();

            newComponent.OnDestroy += NewComponent_OnDestroy;
            components.Add(newComponent);

        }

        private void NewComponent_OnDestroy(string ID)
        {
            awaitingRemoval.Add(ID);
            throw new NotImplementedException();
        }

        private void Component_OnDestroy(string id)
        {
            awaitingRemoval.Add(id);
        }    

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }
        public void Destroy()
        {
            components.Clear();
            if (OnDestroy != null)
                OnDestroy(ID);
        }
        public Component GetComponent(string id)
        {
            return components.Find(c => c.ID == id);
        }
        public Component GetComponent(Type componentType)
        {
            return components.Find(c => c.GetType() == componentType);
        }

        //--------------------------------------------------------------------------------
        public void RemoveComponent(int index)
        {
            components.RemoveAt(index);    
        }
        public void RemoveComponent(string id)
        {
     
        }
        public float GetDistanceTo(GameObject otherObject)
        {

        }

        public void Draw(CameraComponent camera)
        {
            foreach (var rc in components)
            {
                if (rc.Enabled)
                {
                    
                }                   
            }
        }

        public bool HasComponent<T>()
        {

        }

        public virtual void Update(float delta)
        {
            foreach (var component in Components)
            {

            }
        }

        public List<Component> GetComponents(Type componentType)
        {

        }

        public T GetComponent<t>()
        {

        }

        public List<T> GetComponents<T>()
        {

        }
        
    }
}

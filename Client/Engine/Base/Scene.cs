using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Base
{
    public abstract class Scene
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> GameObjects { get { return gameObjects; } }

        public List<string> awatingRemoval = new List<string>();
        protected bool isInitialized = false;
        public Scene() { }

        public void AddObject(GameObject newObject)
        {
            newObject.Scene = this;

            if (isInitialized)
                isInitialized = true;

            newObject.OnDestroy += NewObject_OnDestroy;
            gameObjects.Add(newObject);
        }
        private void NewObject_OnDestroy(string id) { }
        public virtual void Initialize()
        {
            foreach (var objects in gameObjects)
            {
                objects.Initialize();
                objects.Enabled = true;
            }

            isInitialized = true;
        }
        public virtual void Update()
        {
            foreach (var s in gameObjects)
            {
               if(s.Enabled)
                  s.Update();
            }

            foreach (var g in awatingRemoval)
            {
                RemoveObject(g);
            }

            awatingRemoval.Clear();

        }
        public virtual void Draw(CameraComponent camera)
        {
            foreach (var s in gameObjects)
                s.Draw(camera);
        }
        public virtual void DrawUI()
        {

        }
        public bool HasObject(string id)
        {
            return gameObjects.Exists(go => go.ID == id);      
        }
        public bool HasObject<T>()
        {
            return gameObjects.Exists(go => go.Scene.GetType() == typeof(T));
        }
        public int GetObjectIndexInPool(string objectID)
        {
            if (gameObjects.Exists(p => p.ID == objectID))
            {
                return gameObjects.FindIndex(p => p.ID == objectID);
            }
            else
            {
                return -1;
            }
        }
        //public GameObject GetObject(string objectID)
        //{ 

        //    return gameObjects.Find(go => go.ID == objectID);
        //}
        public GameObject GetObject<T>()
        {
            return gameObjects.Find(go => go.GetType() == typeof(T));
        }


        public List<GameObject> GetGameObjects<T>()
        {
            return gameObjects.FindAll(go=> go.GetType() == typeof(T));
        }
       
        public void RemoveObject(string objectID) { }
        //public T GetComponentInObject<T>(string objectID)
        //{
        //    gameObjects.Exists(go => go.ID == objectID);
        //    if(gameObjects.Find(go => go.GetComponent() == typeof(T)))
        //        return

        //}     
        
       

    }
}

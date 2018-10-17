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
        private void NewObject_OnDestroy(string id)
        {
            awatingRemoval.Add(id);
        }
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
            foreach (GameObject go in gameObjects)
            {
               if(go.Enabled)
                  go.Update();
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
            int index = -1;

            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].ID == objectID)
                {
                    return gameObjects.FindIndex(p => p.ID == objectID);
                }

            }
            return index;
                
            
        }
        public GameObject GetObject(string objectid)
        {

            return gameObjects.Find(go => go.ID == objectid);
        }
        public GameObject GetObject<T>()
        {
            return gameObjects.Find(go => go.GetType() == typeof(T));
        }
        public List<GameObject> GetGameObjects<T>()
        {
            return gameObjects.FindAll(go=> go.GetType() == typeof(T));
        }       
        public void RemoveObject(string objectID)
        {
            int index = GetObjectIndexInPool(objectID);
            if (index != -1)
            {
                gameObjects.RemoveAt(index);
            }
        }
        public T GetComponentInObject<T>(string objectID) where T: Component
        {
            var gameObject = gameObjects.FirstOrDefault(go => go.ID == objectID);

            if (gameObject != null)
               return gameObject.GetComponent<T>();

            else return null;

        }

    }
}

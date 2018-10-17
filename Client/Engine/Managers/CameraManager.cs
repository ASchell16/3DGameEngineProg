using Engine.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers
{
    public sealed class CameraManager : GameComponent
    {
        private static Dictionary<string, CameraComponent> Cameras = new Dictionary<string, CameraComponent>();
        private static CameraComponent activeCamera;
        public static CameraComponent ActiveCamera { get { return activeCamera; } }
        public CameraManager(Game game) : base(game)
        {
            game.Components.Add(this);
        }

        public static void SetActiveCamera(string id)
        {
            if (activeCamera != null)
            {
                // compares id being passed and id of active camera
                if (activeCamera.ID != id)
                {
                    if (Cameras.ContainsKey(id))
                    {
                        activeCamera = Cameras[id];
                    }
                }
            }
            else
            {
                if (Cameras.ContainsKey(id))
                {
                    activeCamera = Cameras[id];
                }
            }


        }
        public static void AddCamera(CameraComponent camera)
        {
            // if no camera exists add camera component
            if (!Cameras.ContainsKey(camera.ID))
            {
                Cameras.Add(camera.ID, camera);
                if (Cameras.Count == 1)
                    SetActiveCamera(camera.ID);
            }

            // if newly added camera is only camera set as active camera
            if (Cameras.ContainsKey(camera.ID))
            {
                camera.Enabled = true;
            }

        }        
       
        public static void Clear()
        {
            Cameras.Clear();
            activeCamera = null;
        }
        public static void RemoveCamera(string id)
        {
            if (Cameras.ContainsKey(id))
            {
                Cameras.Remove(id);
                if (activeCamera.ID == id)
                {
                    activeCamera = null;
                }
            }
        }
        public static List<string> GetCurrentCamerasIDs()
        {
            return Cameras.Keys.ToList();
        }
        public static List<CameraComponent> GetCurrentCameras()
        {
            return Cameras.Values.ToList();
        }
        public static void EnableActiveCamera()
        {
            if (activeCamera != null)
                activeCamera.Enabled = true;
            
        }
        public static void DisableActiveCamera()
        {
            if (activeCamera != null)
                activeCamera.Enabled = false;
        }


    }
}

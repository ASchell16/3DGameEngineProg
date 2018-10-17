using Engine.Base;
using Engine.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public sealed class GameEngine : DrawableGameComponent
    {
        InputManager input;
        CameraManager camera;
        FrameRateCounter fpsCounter;
        PhysicsManager physics;

        private Scene activeScene;
        public Scene ActiveScene {get { return activeScene; } }

        public GameEngine(Game game) : base(game)
        {
            game.Components.Add(this);

            input = new InputManager(game);
            camera = new CameraManager(game);
            physics = new PhysicsManager(game);
            fpsCounter = new FrameRateCounter(game);
        }

        public void LoadScene(Scene newScene)
        {
            if (newScene != null)
            {
                if (activeScene != null)
                {
                    UnloadScene();
                }
            }

            activeScene = newScene;
            activeScene.Initialize();
        }
        public void UnloadScene()
        {
            activeScene = null;
            CameraManager.Clear();
            GameUtilities.SceneConetent.Unload();
        }
        public override void Update(GameTime gameTime)
        {
            GameUtilities.Time = gameTime;
            if (activeScene != null)
            {
                activeScene.Update();
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if(activeScene != null && CameraManager.ActiveCamera != null)
            {
                activeScene.Draw(CameraManager.ActiveCamera);
            }
            base.Draw(gameTime);
        }

    }
}

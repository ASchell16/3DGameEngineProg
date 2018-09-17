using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3DGameEngineProgramming
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        //Camera
        Matrix view;
        Matrix projection;

        //Matrix
        Matrix world = Matrix.Identity;

        // Colour Verticies
        VertexPositionColor[] colourVerticies;

        // Texture Verticies
        VertexPositionTexture[] texturedVertices;

        //Normal Verticies
        VertexPositionNormalTexture[] normalVertices;
        // Texture
        Texture2D uvTexture;

        // Effect
        BasicEffect effect;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1280; // Screen Width
            graphics.PreferredBackBufferHeight = 720;   // Screen Height

            IsMouseVisible = true; // Makes Mouse Visable
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 16); // 


            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Creates our cameras View position
            view = Matrix.CreateLookAt(new Vector3(0, 0, 5),
                                       new Vector3(0, 0, -1), 
                                       Vector3.Up);                 

            // Creates our field of view and perspective
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45),
                                                             GraphicsDevice.DisplayMode.AspectRatio,
                                                             0.1f,
                                                             1000f);
            base.Initialize();
        }

        protected override void LoadContent()
        {

            // SetupColourVerticies();
            // SetupTextureVerticies();
            SetupNormalVertices();
        }

        void SetupColourVerticies()
        {
            colourVerticies = new VertexPositionColor[12];

            //BL
            colourVerticies[0] = new VertexPositionColor(new Vector3(-1, -1, 0), 
                                                         Color.Purple);
            //TL
            colourVerticies[1] = new VertexPositionColor(new Vector3(-1, 1, 0), 
                                                         Color.Green);
            //BR
            colourVerticies[2] = new VertexPositionColor(new Vector3(1, -1, 0), 
                                                         Color.Yellow);
        
            //TR
            colourVerticies[3] = new VertexPositionColor(new Vector3(1, 1, 0),
                                                        Color.Purple);

            //BR
            colourVerticies[4] = new VertexPositionColor(new Vector3(1, -1, 0),
                                                        Color.Yellow);

            //TL
            colourVerticies[5] = new VertexPositionColor(new Vector3(-1, 1, 0),
                                                        Color.Green);


            


            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = false;

        }

        void SetupTextureVerticies()
        {
            // amount of verticies
            texturedVertices = new VertexPositionTexture[6];


            // Bl
            texturedVertices[0] = new VertexPositionTexture(new Vector3(-1, -1, 0),
                                                            new Vector2(0, 1));
            // Tl
            texturedVertices[1] = new VertexPositionTexture(new Vector3(-1, 1, 0),
                                                            new Vector2(0, 0));
            // BR
            texturedVertices[2] = new VertexPositionTexture(new Vector3(1, -1, 0),
                                                            new Vector2(1, 1));
            //-------------------------------------------------------------------
           
            // Tr
            texturedVertices[3] = new VertexPositionTexture(new Vector3(1, 1, 0),
                                                            new Vector2(1, 0));
            // BR
            texturedVertices[4] = new VertexPositionTexture(new Vector3(1, -1, 0),
                                                            new Vector2(1, 1));
            // Tl
            texturedVertices[5] = new VertexPositionTexture(new Vector3(-1, 1, 0),
                                                            new Vector2(0, 0));


            // load texture
            uvTexture = Content.Load<Texture2D>("uv_texture");



            effect = new BasicEffect(GraphicsDevice);
            effect.TextureEnabled = true;
            effect.Texture = uvTexture;

        }

        void SetupNormalVertices()
        {
            normalVertices = new VertexPositionNormalTexture[6];

            normalVertices[0] = new VertexPositionNormalTexture(new Vector3(-1, -1, 0), 
                                                                Vector3.Forward,
                                                                new Vector2(0, 1));

            normalVertices[1] = new VertexPositionNormalTexture(new Vector3(-1, 1, 0),
                                                                Vector3.Forward,
                                                                new Vector2(0, 0));

            normalVertices[2] = new VertexPositionNormalTexture(new Vector3(1, -1, 0),
                                                               Vector3.Forward,
                                                                new Vector2(1, 1));

            normalVertices[3] = new VertexPositionNormalTexture(new Vector3(1, 1, 0),
                                                                Vector3.Forward,
                                                                new Vector2(1, 0));

            normalVertices[4] = new VertexPositionNormalTexture(new Vector3(1, -1, 0),
                                                                Vector3.Forward,
                                                                new Vector2(1, 1));

            normalVertices[5] = new VertexPositionNormalTexture(new Vector3(-1, 1, 0),
                                                                Vector3.Forward,
                                                                new Vector2(0, 0));


            // load texture
            uvTexture = Content.Load<Texture2D>("uv_texture");

            effect = new BasicEffect(GraphicsDevice);
            effect.TextureEnabled = true;
            effect.Texture = uvTexture;

            effect.EnableDefaultLighting();
            effect.PreferPerPixelLighting = true;

            effect.DirectionalLight0.Enabled = true;
            effect.DirectionalLight1.Enabled = false;
            effect.DirectionalLight2.Enabled = false;

            effect.DirectionalLight0.Direction = Vector3.Backward;
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        void DrawTexturedVertices()
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, normalVertices, 0, (normalVertices.Length / 3));
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            effect.View = view;
            effect.Projection = projection;

            effect.World = world;
            world *=  Matrix.CreateTranslation(new Vector3(0, 0, -1));
            world *=  Matrix.CreateRotationY(MathHelper.ToRadians(5f));
            world *= Matrix.CreateScale(1);
            /*// rotate object
            effect.World *= Matrix.CreateRotationZ(MathHelper.ToRadians(0.5f));
            effect.World *= Matrix.CreateRotationY(MathHelper.ToRadians(0.5f));
            effect.World *= Matrix.CreateRotationX(MathHelper.ToRadians(0.5f));
            */

            DrawTexturedVertices();
            

            base.Draw(gameTime);
        }
    }
}

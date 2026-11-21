using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileMap;

public class Game1 : Game
{
    // The game camera
    FPSCamera camera;
    // The terrain 
    Terrain terrain;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        // Initialize the camera 
        camera = new FPSCamera(this, new Vector3(0, 3, 10));
        // Build the terrain
        Texture2D heightmap = Content.Load<Texture2D>("heightmap");
        terrain = new Terrain(this, heightmap, 10f, Matrix.Identity);
        camera.HeightMap = terrain;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        camera.Update(gameTime);  
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        // Draw the terrain
        terrain.Draw(camera);
        base.Draw(gameTime);
    }
}

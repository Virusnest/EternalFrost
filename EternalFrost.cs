using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EternalFrost.Utils.TileMap.Tiles;
using EternalFrost.Utils.TileMap;
using MonoGame.Extended.TextureAtlases;
using EternalFrost.Utils;

namespace EternalFrost;

public class EternalFrost : Game
{
    Texture2D TileTexture;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RenderTarget2D _lowResTarget;
    private int _ResWidth = 16*16;
    private int _ResHeight = 9*16;
    Texture2D TILE_ATLAS_TEXTURE;
    public static TextureAtlas tileAtlas;
    Utils.Camera camera;
    public TileMap world;
    TileMapRenderer tileRenderer;


	public EternalFrost()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
        base.Window.AllowUserResizing = true;
        Console.WriteLine("INIT");
        _lowResTarget = new RenderTarget2D(GraphicsDevice, _ResWidth, _ResHeight);
        camera = new Utils.Camera(new Viewport(0, 0, _ResWidth, _ResHeight));
        camera.Position = new Vector2(_ResWidth/2, _ResHeight/2);
        tileAtlas = TextureAtlas.Create("tiles",TILE_ATLAS_TEXTURE,16,16);
  		//camera.AdjustZoom(1);
		//world = new TileMap(16, 9);
        //world.FillTiles(new InGameTypes.WorldTile(new GroundTile()));
		//camera.rotation = (360*(float)Math.PI)/4;

		tileRenderer = new TileMapRenderer(world,16,GraphicsDevice);
	}

    
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
        TileTexture = Content.Load<Texture2D>("Ice");

		// TODO: use this.Content to load your game content here
	}

	protected override void Update(GameTime gameTime)
    {
        camera.UpdateCamera(new Viewport(0, 0, _ResWidth, _ResHeight));

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
			Vector2 size = Utils.Math.CalcAspectScale(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 16, 9);
            Vector2 diff = new Vector2( GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height) - size;
            Vector2 scale = size / new Vector2(_ResWidth, _ResHeight);
			Vector2 pos = camera.DeprojectScreenPositionScale(Mouse.GetState().Position,scale.X,diff);
			Console.WriteLine($"{(int)MathF.Floor(pos.X / 16)} {(int)MathF.Floor(pos.Y / 16)}");
			world.SetTile((int)MathF.Floor(pos.X / 16), (int)MathF.Floor(pos.Y/16), null);
		}
		//camera.Position = new Vector2(0.1f * (float)gameTime.TotalGameTime.Seconds);
		// TODO: Add your update logic here
		base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(_lowResTarget);
        GraphicsDevice.Clear(Color.DarkCyan);
        _spriteBatch.Begin(transformMatrix:camera.Transform, samplerState: SamplerState.PointClamp, sortMode:SpriteSortMode.Immediate);
		tileRenderer.Render(_spriteBatch);
		//_spriteBatch.Draw(TileTexture, new Vector2(0, 0), Color.White);
        _spriteBatch.End();
        DrawToMainBuffer();
        //Console.WriteLine(Utils.Math.CalcFps(gameTime.ElapsedGameTime.Milliseconds));
        base.Draw(gameTime);
        // TODO: Add your drawing code here

    }
    private void DrawToMainBuffer() {
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);
        Vector2 size = Utils.Math.CalcAspectScale(GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height, 16, 9);
        //Console.WriteLine(size);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(
        texture: _lowResTarget,
        destinationRectangle: new Rectangle(
            GraphicsDevice.Viewport.X + (GraphicsDevice.Viewport.Width - (int)size.X) / 2,
            GraphicsDevice.Viewport.Y + (GraphicsDevice.Viewport.Height - (int)size.Y) / 2,
            (int)MathF.Round(size.X),
            (int)MathF.Round(size.Y)
        ),
        color: Color.White);
        _spriteBatch.End();
    }
    
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using EternalFrost.Utils.TileMap.Tiles;
using EternalFrost.Utils.TileMap;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using EternalFrost.Utils;
using EternalFrost.Managers;
using EternalFrost.Types;

namespace EternalFrost;

public class EternalFrost : Game
{
    Texture2D TileTexture;

	private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RenderTarget2D _lowResTarget;
    private int _ResWidth = 16*16*4;
    private int _ResHeight = 9*16*4;
    Texture2D TILE_ATLAS_TEXTURE;
	public static SpriteFont font;
	ScalingViewportAdapter viewport;
	public static TileAtlas tileAtlas;
	OrthographicCamera camera;
	ChunkRenderer renderer;
	WorldManager manager = new WorldManager();
	public EternalFrost()
    {
        _graphics = new GraphicsDeviceManager(this) { PreferredBackBufferHeight=800,
		PreferredBackBufferWidth=900};
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        var noise = new FastNoiseLite(123129);
		noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
		base.Initialize();
        base.Window.AllowUserResizing = true;
        Console.WriteLine("INIT");
        _lowResTarget = new RenderTarget2D(GraphicsDevice, _ResWidth, _ResHeight);
        viewport = new BoxingViewport(Window,GraphicsDevice, _ResWidth, _ResHeight);
        camera = new OrthographicCamera(viewport);
		camera.Position = new Vector2(-1,-1);
		renderer = new ChunkRenderer();
        //tileAtlas = TextureAtlas.Create("tiles", TILE_ATLAS_TEXTURE, 16, 16);
        tileAtlas = new TileAtlas(GraphicsDevice, 16, 16, 256);
		Console.Write(Tiles.ICE);
		int counter = 0;
		Texture2D[] texture = new Texture2D[Registry.Registries.TILE_REG.GetLength()];
		string[] id = new string[Registry.Registries.TILE_REG.GetLength()];
		foreach (Registry.RegistryItem entry in Registry.Registries.TILE_REG.Keys()) {
			Console.WriteLine("texture/" + entry.getLocation());
			texture[counter] = Content.Load<Texture2D>("texture/" + entry.getLocation());
			id[counter] = entry.getLocation();
			counter++;
		}
		tileAtlas.AddTextures(texture, id);
		
	}


	protected override void UnloadContent()
	{
		base.UnloadContent();
	}

	protected override void LoadContent()
    {
		font = this.Content.Load<SpriteFont>("font/eternalfrost/font");
        _spriteBatch = new SpriteBatch(GraphicsDevice);
		// TODO: use this.Content to load your game content here

		// TODO: use this.Content to load your game content here

	}

	protected override void Update(GameTime gameTime)
    {
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

		if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
			var pos = camera.ScreenToWorld(Mouse.GetState().Position.ToVector2());
			manager.world.SetTile(new BlockPos((int)MathF.Floor(pos.X / 16), (int)MathF.Floor(pos.Y / 16), 1), null);
		}
		if (Mouse.GetState().RightButton == ButtonState.Pressed) {
			var pos = camera.ScreenToWorld(Mouse.GetState().Position.ToVector2());
			manager.world.SetTile(new BlockPos((int)MathF.Floor(pos.X / 16), (int)MathF.Floor(pos.Y / 16),1), new InGameTypes.WorldTile(Tiles.ICE));
		}
		if (Keyboard.GetState().IsKeyDown(Keys.Left))
			camera.Move(new Vector2(-5f, 0));
		if (Keyboard.GetState().IsKeyDown(Keys.Right))
			camera.Move(new Vector2(5f, 0));
		if (Keyboard.GetState().IsKeyDown(Keys.Up))
			camera.Move(new Vector2(0, -5f));
		if (Keyboard.GetState().IsKeyDown(Keys.Down))
			camera.Move(new Vector2(0,5f));
	
			// Additional logic for handling resize if necessary
		
		//camera.Position = new Vector2(0.1f * (float)gameTime.TotalGameTime.Seconds);
		// TODO: Add your update logic here
		base.Update(gameTime);
		manager.Update(camera);
    }

    protected override void Draw(GameTime gameTime)
    {

		GraphicsDevice.SetRenderTarget(_lowResTarget);
		//GraphicsDevice.SetRenderTarget(null);

		GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(transformMatrix:camera.GetViewMatrix(), samplerState: SamplerState.PointClamp, sortMode:SpriteSortMode.Immediate);
        //_spriteBatch.Draw(tileAtlas.getTexture(),Vector2.Zero,Color.White);
		//_spriteBatch.Draw(TileTexture, new Vector2(0, 0), Color.White);
		_spriteBatch.End();
		manager.Render(_spriteBatch,camera.GetViewMatrix());
		DrawToMainBuffer();
		//Con sole.WriteLine(Utils.Math.CalcFps(gameTime.ElapsedGameTime.Milliseconds));
		base.Draw(gameTime);

		// TODO: Add your drawing code here

	}
    private void DrawToMainBuffer() {
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);
        Rectangle size = Utils.Math.CalcAspectScale(Window.ClientBounds, _ResWidth, _ResHeight);
		//Console.WriteLine(size);
		_spriteBatch.Begin(samplerState:SamplerState.PointClamp);
		_spriteBatch.Draw(_lowResTarget, size, Color.White);
		_spriteBatch.End();

	}

}


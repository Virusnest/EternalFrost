﻿using EternalFrost.Utils.TileMap.Tiles;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using EternalFrost.Utils;
using EternalFrost.Managers;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap;
using System.IO;
using EternalFrost.Input;

namespace EternalFrost;

public class EternalFrost : Game
{
  Texture2D TileTexture;

  private GraphicsDeviceManager _graphics;
  public static SpriteBatch _spriteBatch;
  private RenderTarget2D _lowResTarget;
  private int _ResWidth = 16 * 10 * 5;
  private int _ResHeight = 9 * 10 * 5;
  public static SpriteFont font;
  BoxingViewportAdapter viewport;
  public static TileAtlas tileAtlas;
  OrthographicCamera camera;
  public OrthographicCamera mouseCam;

  WorldManager manager = new WorldManager();

  public EternalFrost()
  {
    _graphics = new GraphicsDeviceManager(this) {
      PreferMultiSampling = true,
      PreferredBackBufferHeight = _ResHeight,
      SynchronizeWithVerticalRetrace = false,
      PreferredBackBufferWidth = _ResWidth
    };
    Content.RootDirectory = "Content";
    IsMouseVisible = true;
  }

  protected override void Initialize()
  {
    // TODO: Add your initialization logic here
    base.Initialize();
    Window.AllowUserResizing = true;
    Console.WriteLine("INIT");
    _lowResTarget = new RenderTarget2D(GraphicsDevice, _ResWidth, _ResHeight);
    viewport = new BoxingViewportAdapter(Window, GraphicsDevice, _ResWidth, _ResHeight);
    mouseCam = new OrthographicCamera(viewport);
    camera = new OrthographicCamera(viewport);
    camera.Position = new Vector2(0, 0);
    _graphics.SynchronizeWithVerticalRetrace = false;
    //tileAtlas = TextureAtlas.Create("tiles", TILE_ATLAS_TEXTURE, 16, 16);
    tileAtlas = new TileAtlas(GraphicsDevice, 8, 8, 256);
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
    manager.Init();
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
  bool shot = false;
  protected override void Update(GameTime gameTime)
  { 
    mouseCam.Position = camera.Position;
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();

    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
    {
      
			var pos = camera.ScreenToWorld(Mouse.GetState().Position.ToVector2());
			// Apply scaling to world coordinates      
      manager.world.SetTile(new TilePos((int)MathF.Floor(pos.X / ChunkRenderer.TILESIZE), (int)MathF.Floor(pos.Y / ChunkRenderer.TILESIZE), 1), null);
    }
    if (Mouse.GetState().RightButton == ButtonState.Pressed)
    {
      var pos = mouseCam.ScreenToWorld(Mouse.GetState().Position.ToVector2());
      manager.world.SetTile(new TilePos((int)MathF.Floor(pos.X / ChunkRenderer.TILESIZE), (int)MathF.Floor(pos.Y / ChunkRenderer.TILESIZE), 1), new InGameTypes.WorldTile(Tiles.SNOWY_ICE));
    }
    if (Keyboard.GetState().IsKeyDown(Keys.Enter)&&!shot) {
      FileStream stream = File.Create(DateTime.Now.ToFileTime()+".png");
      _lowResTarget.SaveAsPng(stream,_ResWidth,_ResHeight);
      shot = !shot;
    }
		if (Keyboard.GetState().IsKeyUp(Keys.Enter) && shot) {
			shot = !shot;
		}
    if (Keyboard.GetState().IsKeyDown(Keybinds.LEFT.Bind))
      camera.Move(new Vector2(-5, 0));
    if (Keyboard.GetState().IsKeyDown(Keybinds.RIGHT.Bind))
      camera.Move(new Vector2(5f, 0));
    if (Keyboard.GetState().IsKeyDown(Keybinds.UP.Bind))
      camera.Move(new Vector2(0, -5f));
    if (Keyboard.GetState().IsKeyDown(Keybinds.DOWN.Bind))
      camera.Move(new Vector2(0, 5f));

		// Additional logic for handling resize if necessary

		//camera.Position = new Vector2(0.1f * (float)gameTime.TotalGameTime.Seconds);
		// TODO: Add your update logic here
	  manager.Update(camera, gameTime);
  	base.Update(gameTime);

	}

	protected override void Draw(GameTime gameTime)
  {

		GraphicsDevice.SetRenderTarget(_lowResTarget);
    GraphicsDevice.Clear(Color.CornflowerBlue);
    manager.Render(_spriteBatch, camera.GetViewMatrix());
    DrawToMainBuffer();
    base.Draw(gameTime);
    _spriteBatch.Begin();
    _spriteBatch.DrawString(font, (1000/gameTime.ElapsedGameTime.Milliseconds).ToString(), Vector2.Zero, Color.White);
    _spriteBatch.End();
    // TODO: Add your drawing code here

  }
  private void DrawToMainBuffer()
  {
		GraphicsDevice.Viewport =new Viewport(MathG.CalcAspectScale(Window.ClientBounds, _ResWidth, _ResHeight));
		GraphicsDevice.SetRenderTarget(null);
    GraphicsDevice.Clear(Color.Black);
    Rectangle size = MathG.CalcAspectScale(Window.ClientBounds, _ResWidth, _ResHeight);
    //Console.WriteLine(size);
    _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
    _spriteBatch.Draw(_lowResTarget, size, Color.White);
    _spriteBatch.End();
  }

}


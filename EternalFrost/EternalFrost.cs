using EternalFrost.Utils.TileMap.Tile;

using EternalFrost.Utils;
using EternalFrost.Managers;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap;
using System.IO;
using EternalFrost.Input;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended;
using EternalFrost.Item;

namespace EternalFrost;

public class EternalFrost : Game
{
  public static GraphicsDeviceManager _graphics;
  public static SpriteBatch _spriteBatch;
  private RenderTarget2D _lowResTarget;
  public static int _ResWidth = 16 * 10 * 4;
  public static int _ResHeight = 9 * 10 * 4;
  public static SpriteFont font;
  BoxingViewportAdapter viewport;
  public static TextureAtlas tileAtlas;
  public static OrthographicCamera camera;
  OrthographicCamera mouseCam;
  public static TimeSpan elapsedtime;
  public static WorldManager manager = new WorldManager();
  public EternalFrost()
  {
    _graphics = new GraphicsDeviceManager(this)
    {
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
    TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / 60);
    Window.AllowUserResizing = true;
    Console.WriteLine("INIT");
    _lowResTarget = new RenderTarget2D(GraphicsDevice, _ResWidth, _ResHeight);
    viewport = new BoxingViewportAdapter(Window, GraphicsDevice, _ResWidth, _ResHeight);
    mouseCam = new OrthographicCamera(viewport);
    camera = new OrthographicCamera(viewport);
    camera.Position = new Vector2(0, 0);
    _graphics.SynchronizeWithVerticalRetrace = false;
    //tileAtlas = TextureAtlas.Create("tiles", TILE_ATLAS_TEXTURE, 16, 16);
    tileAtlas = new TextureAtlas(GraphicsDevice);
    Console.Write(Tiles.STONE);

		AssetManager.AtlasTextures();
		manager.Init();
  }


  protected override void UnloadContent()
  {
    base.UnloadContent();
  }

  protected override void LoadContent()
  {
		Console.Write(Items.SNOWBALL);

		font = this.Content.Load<SpriteFont>("font/eternalfrost/font");
    _spriteBatch = new SpriteBatch(GraphicsDevice);
		AssetManager.LoadAssets();
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
      manager.world.SetTile(new TilePos((int)MathF.Floor(pos.X / ChunkRenderer.TILESIZE), (int)MathF.Floor(pos.Y / ChunkRenderer.TILESIZE), 1), new InGameTypes.WorldTile(Tiles.STONE));
    }
    if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !shot)
    {
      FileStream stream = File.Create(DateTime.Now.ToFileTime() + ".png");
      _lowResTarget.SaveAsPng(stream, _ResWidth, _ResHeight);
      shot = !shot;
    }
    if (Keyboard.GetState().IsKeyUp(Keys.Enter) && shot)
    {
      shot = !shot;
    }
    // Additional logic for handling resize if necessary

    //camera.Position = new Vector2(0.1f * (float)gameTime.TotalGameTime.Seconds);
    // TODO: Add your update logic here
    manager.Update(camera, gameTime);
		elapsedtime = gameTime.TotalGameTime;
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
    _spriteBatch.DrawString(font, (1000 / gameTime.ElapsedGameTime.Milliseconds).ToString(), Vector2.Zero, Color.White);
    _spriteBatch.End();
    // TODO: Add your drawing code here

  }
  private void DrawToMainBuffer()
  {
    GraphicsDevice.Viewport = new Viewport(MathG.CalcAspectScale(Window.ClientBounds, _ResWidth, _ResHeight));
    GraphicsDevice.SetRenderTarget(null);
    GraphicsDevice.Clear(Color.Black);
    Rectangle size = MathG.CalcAspectScale(Window.ClientBounds, _ResWidth, _ResHeight);
    //Console.WriteLine(size);
    _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
    _spriteBatch.Draw(_lowResTarget, size, Color.White);
    _spriteBatch.End();
  }

}


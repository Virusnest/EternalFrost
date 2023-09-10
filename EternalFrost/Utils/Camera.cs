
using MonoGame.Extended.ViewportAdapters;


namespace EternalFrost.Utils;

public class Camera
{
	private ViewportAdapter viewport;
	public Vector2 pos;
	public float rot;
	public Vector2 orig;

	public Camera(ViewportAdapter viewport)
	{
		this.viewport = viewport;
	}
	private Matrix GetVirtualViewMatrix(Vector2 parallaxFactor)
	{
		return
			Matrix.CreateTranslation(Vector3.Floor(new Vector3(-(pos) * parallaxFactor, 0.0f))) *
			Matrix.CreateTranslation(Vector3.Floor(new Vector3(-orig, 0.0f))) *
			Matrix.CreateRotationZ(MathF.Floor(rot)) *
			Matrix.CreateTranslation(Vector3.Floor(new Vector3(orig, 0.0f)));
	}
	private Matrix GetVirtualViewMatrix()
	{
		return GetVirtualViewMatrix(Vector2.One);
	}
	public Matrix GetViewMatrix()
	{
		return GetVirtualViewMatrix(Vector2.One)*viewport.GetScaleMatrix();
	}
	public void Move(Vector2 vector)
	{
		pos=pos + vector;
	}
	public bool IsVisible(Vector2 pos)
	{
		return viewport.BoundingRectangle.Contains(pos);
	}
	public BoundingFrustum GetBoundingFrustum()
	{
		var viewMatrix = GetVirtualViewMatrix();
		var projectionMatrix = GetProjectionMatrix(viewMatrix);
		return new BoundingFrustum(projectionMatrix);
	}
	private Matrix GetProjectionMatrix(Matrix viewMatrix)
	{
		var projection = Matrix.CreateOrthographicOffCenter(0, viewport.VirtualWidth, viewport.VirtualHeight, 0, -1, 0);
		Matrix.Multiply(ref viewMatrix, ref projection, out projection);
		return projection;
	}

	public ContainmentType Contains(Rectangle rectangle)
	{
		var max = new Vector3(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height, 0.5f);
		var min = new Vector3(rectangle.X, rectangle.Y, 0.5f);
		var boundingBox = new BoundingBox(min, max);
		return GetBoundingFrustum().Contains(boundingBox);
	}
}
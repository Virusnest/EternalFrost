using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EternalFrost.Utils;

public class Camera
{
    public float Zoom { get; set; }
    public Vector2 Position { get; set; }
    public Viewport Viewport { get; protected set; }
	public Rectangle Bounds { get; protected set; }
    public Rectangle VisibleArea { get; protected set; }
    public Matrix Transform { get; protected set; }
	public Matrix InverseViewMatrix { get; protected set; }
	public float rotation { get; set; }

    private float currentMouseWheelValue, previousMouseWheelValue, zoom, previousZoom;

    public Camera(Viewport viewport)
    {
        Bounds = viewport.Bounds;
        Viewport = viewport;
        Zoom = 1f;
        Position = Vector2.Zero;
    }


    private void UpdateVisibleArea()
    {
        InverseViewMatrix = Matrix.Invert(Transform);

		var tl = Vector2.Transform(Vector2.Zero, InverseViewMatrix);
        var tr = Vector2.Transform(new Vector2(Bounds.X, 0), InverseViewMatrix);
        
        var bl = Vector2.Transform(new Vector2(0, Bounds.Y), InverseViewMatrix);
        var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), InverseViewMatrix);

        var min = new Vector2(
            MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
            MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
        var max = new Vector2(
            MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
            MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
        VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
    }

    private void UpdateMatrix()
    {
        Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0)) *
                Matrix.CreateScale(Zoom);
        UpdateVisibleArea();
    }

    public void MoveCamera(Vector2 movePosition)
    {
        Vector2 newPosition = Position + movePosition;
        Position = newPosition;
    }

    public void AdjustZoom(float zoomAmount)
    {
        Zoom = zoomAmount;
    }

    public void UpdateCamera(Viewport bounds)
    {
        Bounds = bounds.Bounds;
        UpdateMatrix();

        //Console.WriteLine(Position);
        Vector2 cameraMovement = Vector2.Zero;
        float moveSpeed;

        if (Zoom > .8f)
        {
            moveSpeed = 0.1f;
        }
        else if (Zoom < .8f && Zoom >= .6f)
        {
            moveSpeed = 20;
        }
        else if (Zoom < .6f && Zoom > .35f)
        {
            moveSpeed = 25;
        }
        else if (Zoom <= .35f)
        {
            moveSpeed = 30;
        }
        else
        {
            moveSpeed = 0.1f;
        }



        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            cameraMovement.Y = -moveSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            cameraMovement.Y = moveSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            cameraMovement.X = -moveSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            cameraMovement.X = moveSpeed;
        }

        previousMouseWheelValue = currentMouseWheelValue;
        currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

        if (currentMouseWheelValue > previousMouseWheelValue)
        {
            AdjustZoom(.05f);
            Console.WriteLine(moveSpeed);
        }

        if (currentMouseWheelValue < previousMouseWheelValue)
        {
            AdjustZoom(-.05f);
            Console.WriteLine(moveSpeed);
        }

        previousZoom = zoom;
        zoom = Zoom;
        if (previousZoom != zoom)
        {
            Console.WriteLine(zoom);

        }

        MoveCamera(cameraMovement);
    }
	public Vector2 DeprojectScreenPosition(Vector2 position)
	{
		return (Vector2.Transform(position,InverseViewMatrix));
	}
	public Vector2 DeprojectScreenPosition(Point position) // for MouseState.Position
	{
		return Vector2.Transform(new Vector2(position.X, position.Y),InverseViewMatrix);
	}
	public Vector2 DeprojectScreenPositionScale(Vector2 position, float scale,Vector2 offset)
	{
		return Vector2.Transform(position,InverseViewMatrix * Matrix.Invert(Matrix.Invert(InverseViewMatrix) * Matrix.CreateScale(scale) * Matrix.CreateTranslation(offset.X/2, offset.Y / 2,0)));
	}
	public Vector2 DeprojectScreenPositionScale(Point position,float scale,Vector2 offset) // for MouseState.Position
	{
		return Vector2.Transform(new Vector2(position.X, position.Y), Matrix.Invert(Matrix.Invert(InverseViewMatrix)*Matrix.CreateScale(scale) * Matrix.CreateTranslation(offset.X / 2, offset.Y / 2, 0)));
	}
}
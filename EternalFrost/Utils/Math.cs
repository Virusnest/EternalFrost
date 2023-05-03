using System;
using Microsoft.Xna.Framework;
namespace EternalFrost.Utils
{
    public class Math
    {
        public static Vector2 CalcAspectScale(float width, float height, int aspectw, int aspecth)
        {
            Vector2 size = new Vector2();
            if (width/aspectw>height/aspecth)
            {
                size.Y = height;
                size.X = (height * aspectw) / aspecth;
            }
            else
            {
                size.X = width;
                size.Y = (width * aspecth) / aspectw;
            }
            return size;
        }

        public static int CalcFps(int delta) {
            int fps;
            fps = 1000 / delta;
            return fps;
        }
    }
}


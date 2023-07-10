using System;
using System.Xml;
using Microsoft.Xna.Framework;
namespace EternalFrost.Utils
{
    public class Math
    {
        public static Rectangle CalcAspectScale(Rectangle port, int aspectw, int aspecth)
        {
            var scale = MathF.Min((float)port.Width / aspectw, (float)port.Height / aspecth);
            int nh = (int)(aspecth * scale);
            int nw = (int)(aspectw * scale);
			int x = (port.Width - nw) / 2;
            int y = (port.Height - nh) / 2;
            return new Rectangle(x, y, nw, nh);
		}

		public static int CalcFps(int delta) {
            int fps;
            fps = 1000 / delta;
            return fps;
        }
    }
}


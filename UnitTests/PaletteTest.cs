using System;
using EternalFrost.Collections;
using EternalFrost.Managers;
using EternalFrost.InGameTypes;
using NUnit.Framework.Interfaces;

namespace UnitTests
{
	public class PaletteTest
	{
		[Test]
		public void SwapNull()
		{
			Assert.IsTrue(Tests.palette.Swap(1, "ball")=="");
		}

		[Test]
		public void SwapVal()
		{
			List<string> l = new List<string>(3);
			//Tests.palette.Set(1, "balls");
			Tests.palette.Set(1, "");
			Assert.IsFalse(Tests.palette.Data.Palette[1]== Tests.palette.Data.Palette[0]);
		}
		[Test]
		public void TestBitMaskTool()
		{
			Tests.data.SetNibble(0xf);
			Tests.data.SetBool(1, true);
			Console.WriteLine(Tests.data.GetNibble().ToString());
			Assert.IsTrue(Tests.data.GetBoolNibble()==2);
			Assert.IsTrue(Tests.data.GetBool(1));
			//Console.WriteLine(Convert.ToString(Tests.data.Data,2));
			Assert.IsTrue(Tests.data.Data==0xf2);
		}
	}
}


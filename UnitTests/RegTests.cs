using System;
using System.Xml.Linq;
using EternalFrost.Registry;
using Microsoft.Win32;

namespace UnitTests
{
  public class RegTests
  {
    [Test]
    public void RegistryGetKeyTest()
    {
      Assert.IsTrue(Tests.registry.GetKey(Tests.element).Value.ID == new ResourceLocation("testelement").ID);
    }

    [Test]
    public void RegistryGetValue()
    {
      Assert.IsTrue(Tests.registry.GetValue(new ResourceLocation("testelement")) == Tests.element);
    }
  }
}


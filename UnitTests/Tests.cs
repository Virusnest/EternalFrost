using EternalFrost.Collections;
using EternalFrost.InGameTypes;
using EternalFrost.Registry;
namespace UnitTests;

[SetUpFixture]
public class Tests
{
  public static Registry<string> registry = new Registry<string>(new ResourceLocation("testreg"));
  public static PaletteCollection<string> palette = new PaletteCollection<string>("", 5);
  public static ByteData data = new ByteData();

  public static string element = "reststore";

  [OneTimeSetUp]
  public void Setup()
  {
    registry.Register(new ResourceLocation("testelement"), element);

  }

  [OneTimeTearDown]
  public void Teardown()
  {

  }
}

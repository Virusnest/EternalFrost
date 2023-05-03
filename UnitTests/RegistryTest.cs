using EternalFrost.Registry;
namespace UnitTests;

[SetUpFixture]
public class Tests
{
    public static Registry<string> registry = new Registry<string>(new ResourceLocation("testreg"));
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

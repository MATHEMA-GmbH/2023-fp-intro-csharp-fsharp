using Examples1CSharp;

namespace Examples1CSharpTests;

public class HelloWorldTests
{
    [Fact]
    public void Test1() => HelloWorld.SayHello().Should().Be("Hello World!");
}

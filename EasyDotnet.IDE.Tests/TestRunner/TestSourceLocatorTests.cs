using EasyDotnet.IDE.TestRunner.Analysis;

namespace EasyDotnet.IDE.Tests.TestRunner;

public class TestSourceLocatorTests
{
  [Test]
  public async Task ParseContent_ProbableMethodIncludesNestedNamespaceParts()
  {
    const string source = """
      namespace Sample.Tests;
      public class Example
      {
          [Xunit.Fact]
          public void Works() { }
      }
      """;

    var parsed = TestSourceLocator.ParseContent(source);

    await Assert.That(parsed.ProbableMethods.Count).IsEqualTo(1);
    await Assert.That(parsed.ProbableMethods[0].NamespaceParts).IsEquivalentTo(["Sample", "Tests"]);
  }
}
using System;
using Xunit;

namespace CFlatTests {
  public class MathTests {
    [Fact]
    public void TestIntCases() {
      Assert.Equal(1, CFlat.Math.Ceiling2N(0));
      Assert.Equal(4, CFlat.Math.Ceiling2N(3));
    }
  }
}

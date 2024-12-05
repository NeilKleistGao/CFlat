using System;
using Xunit;

namespace CFlatTests {
  public class MathTests {
    [Fact]
    public void TestCeiling2N() {
      // === bytes
      Assert.Equal(0b1, CFlat.Math.Ceiling2N(0b0));
      Assert.Equal(0b100, CFlat.Math.Ceiling2N(0b11));
      Assert.Equal(0b0000_0000, CFlat.Math.Ceiling2N(0b1101_0110));
      // === ushort
      Assert.Equal(0b10_0000_0000, CFlat.Math.Ceiling2N(0b1_1010_1100));
      Assert.Equal(0b1000_0000_0000, CFlat.Math.Ceiling2N(0b1000_0000_0000));
      Assert.Equal(0b100_0000_0000_0000, CFlat.Math.Ceiling2N(0b11_1000_0000_0000));
      // === uint
      Assert.Equal(0b0100_0000_0000_0000_0000u, CFlat.Math.Ceiling2N(0b0010_0000_1000_0000_0001u));
      // === ulong
      Assert.Equal(0b0100_0000_0000_0000_0000_0000_0000_0000_0000_0000ul,
        CFlat.Math.Ceiling2N(0b0010_0000_1000_0000_0001_0010_0000_1000_0000_0001ul));
    }
  }
}

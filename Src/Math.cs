using System;

namespace CFlat {
  public static class Math {
    /// <summary>
    /// Get the minimum 2^N that is greater than the given number b.
    /// Can be overflowed to 0.
    /// </summary>
    public static byte Ceiling2N(byte b) {
      if ((b & (b - 1)) > 0) {
        b |= (byte)(b >> 1);
        b |= (byte)(b >> 2);
        b |= (byte)(b >> 4);
        return (byte)(b + 1);
      }
      else {
        return b == 0 ? (byte)1 : b;
      }
    }

    /// <summary>
    /// Get the minimum 2^N that is greater than the given number s.
    /// Can be overflowed to 0.
    /// </summary>
    public static ushort Ceiling2N(ushort s) {
      if ((s & (s - 1)) > 0) {
        s |= (ushort)(s >> 1);
        s |= (ushort)(s >> 2);
        s |= (ushort)(s >> 4);
        s |= (ushort)(s >> 8);
        return (ushort)(s + 1);
      }
      else {
        return s == 0 ? (ushort)1 : s;
      }
    }

    /// <summary>
    /// Get the minimum 2^N that is greater than the given number i.
    /// Can be overflowed to 0.
    /// </summary>
    public static uint Ceiling2N(uint i) {
      if ((i & (i - 1)) > 0) {
        i |= i >> 1;
        i |= i >> 2;
        i |= i >> 4;
        i |= i >> 8;
        i |= i >> 16;
        return i + 1;
      }
      else {
        return i == 0 ? 1 : i;
      }
    }

    /// <summary>
    /// Get the minimum 2^N that is greater than the given number ln.
    /// Can be overflowed to 0.
    /// </summary>
    public static ulong Ceiling2N(ulong ln) {
      if ((ln & (ln - 1)) > 0) {
        ln |= ln >> 1;
        ln |= ln >> 2;
        ln |= ln >> 4;
        ln |= ln >> 8;
        ln |= ln >> 16;
        ln |= ln >> 32;
        return ln + 1;
      }
      else {
        return ln == 0 ? 1 : ln;
      }
    }
  }
}

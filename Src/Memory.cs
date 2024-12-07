using System;

namespace CFlat {
  public static class Memory {
    public static void Swap<T>(ref T lhs, ref T rhs) {
      T tmp = lhs;
      lhs = rhs;
      rhs = tmp;
    }
  }
}

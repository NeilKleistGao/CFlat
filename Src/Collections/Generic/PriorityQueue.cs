using System;

namespace CFlat {
  namespace Collections {
    namespace Generic {
      public class PriorityQueue<TElement> where TElement: IComparable<TElement> {
        private TElement[] heap;
        private Func<TElement, TElement, int> compareFunc;

        private uint size = 0;

        public PriorityQueue(Func<TElement, TElement, int> func, uint defaultCapacity) {
          compareFunc = func;
          heap = new TElement[Math.Ceiling2N(defaultCapacity)];
        }

        public PriorityQueue(Func<TElement, TElement, int> func) : this(func, 64) {}

        public PriorityQueue(uint defaultCapacity) : this((x, y) => x.CompareTo(y), defaultCapacity) {}

        public PriorityQueue(): this(64) {}
      }
    }
  }
}

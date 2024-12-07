using System;

namespace CFlat {
  namespace Collections {
    namespace Generic {
      public class PriorityQueue<TElement> where TElement: IComparable<TElement> {
        private TElement[] heap;
        private Func<TElement, TElement, int> compareFunc;

        private int count = 0;

        public PriorityQueue(Func<TElement, TElement, int> func, uint defaultCapacity) {
          compareFunc = func;
          heap = new TElement[Math.Ceiling2N(defaultCapacity)];
        }

        public PriorityQueue(Func<TElement, TElement, int> func) : this(func, 64) {}

        public PriorityQueue(uint defaultCapacity) : this((x, y) => x.CompareTo(y), defaultCapacity) {}

        public PriorityQueue(): this(64) {}

        public int Count {
          get { return count; }
        }

        public int Capacity {
          get { return heap.Length; }
        }

        public TElement Peek {
          get { return heap[0]; }
        }

        public TElement[] ToArray() {
          var arr = new TElement[Count];
          for (int i = 0; i < Count; ++i) {
            arr[i] = heap[i];
          }

          return arr;
        }

        private void Resize(int newCap) {
          int realCap = (int)Math.Ceiling2N((uint)newCap); // TODO: overflow?
          var newHeap = new TElement[realCap];
          int numCopy = (realCap < Capacity) ? realCap : Capacity;

          for (int i = 0; i < numCopy; ++i) {
            newHeap[i] = heap[i];
          }
          heap = newHeap;
        }

        private void FloatElement(int index) {
          if (index == 0) { return; }

          int parent = index >> 1;
          if (compareFunc(heap[parent], heap[index]) < 0) {
            Memory.Swap(ref heap[parent], ref heap[index]);
            FloatElement(parent);
          }
        }

        private void SinkElement(int index) {
          int? next = null;
          Func<int, bool> checkChild = child =>
            child < Count &&
            compareFunc(heap[child], heap[index]) > 0 &&
            ((next is int ni) ? compareFunc(heap[ni], heap[child]) < 0 : true);

          if (checkChild(index << 1)) { next = index << 1; }
          if (checkChild((index << 1) + 1)) { next = (index << 1) + 1; }

          if (next is int ni) {
            Memory.Swap(ref heap[index], ref heap[ni]);
            SinkElement(ni);
          }
        }

        public void Enqueue(TElement item) {
          if (Count == Capacity) { Resize(Capacity << 1); }

          heap[Count] = item; ++count;
          FloatElement(Count - 1);
        }

        public TElement Dequeue() {
          if (Count == 0) { throw new Exception(); } // TODO: proper exception

          --count;
          if (Count > 0) { Memory.Swap(ref heap[0], ref heap[Count]); }
          var res = heap[Count];
          SinkElement(0);
          return res;
        }

        public void Clear() {
          count = 0; // TODO: should we dispose elements?
        }
      }
    }
  }
}

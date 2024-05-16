namespace SharpReminder;
using System.Collections;


public class CustomStack<T> : IEnumerable<T>
{
    private T[] _stack;

    public int Capacity
    {
        get { return _stack.Length; }
    }

    public int Count { get; private set; }

    public CustomStack()
    {
        const int defaultCap = 2;
        _stack = new T[defaultCap];
    }

    public CustomStack(int capacity)
    {
        _stack = new T[capacity];
    }

    public void Push(T a)
    {
        if (_stack.Length == Count)
        {
            T[] newArray = new T[_stack.Length * 2];
            Array.Copy(_stack, newArray, Count);
            _stack = newArray;
        }

        _stack[Count++] = a;
    }

    public void Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            _stack[--Count] = default;
        }
    }

    public object Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        return _stack[Count - 1];
    }

    // public IEnumerator<T> GetEnumerator() крутая версия даже итератор не надо реализовывать
    // {
    //     for (int i = 0; i < _stack.Length; i++)
    //     {
    //         yield return _stack[i];
    //     }
    // }

    public IEnumerator<T> GetEnumerator()
    {
        return new StackIenumerator<T>(_stack);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}
    public class StackIenumerator<T> : IEnumerator<T>
    {
        private readonly T[] _a;
        private int _position = -1; //итератор

        public StackIenumerator(T[] arr)
        {
            this._a = arr;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _a.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current
        {
            get { return _a[_position]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() //удаление
        {

        }
    }

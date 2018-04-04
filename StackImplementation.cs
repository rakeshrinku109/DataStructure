using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    public class StackImplementation<T> : IEnumerable<T>
    {
        LinkedList<T> _list = new LinkedList<T>();
    
        public void Push(T Value)
        {
            _list.Add(Value); 
        }

        public T Pop(T Value)
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("this stack is empty");
            }
            T value = _list.Head.Value;
            _list.RemoveFirst();

            return value;
        }

        public void clear()
        {
            _list.Clear();
        }


        public T Peek(T Value)
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("this stack is empty");
            }
            T value = _list.Head.Value;
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }

    public class StackArrayImpl<T> : IEnumerable<T>
    {
        T[] _arr = new T[4];
        int _index;

        public void Push(T item)
        {
            if (_index + 1 == _arr.Length)
            {
                int newLen = _arr.Length * 2;
                T[] _temp = new T[newLen];
                _arr.CopyTo(_temp, 0);
                _arr = _temp; 
            }
            _arr[_index] = item;
            _index++;
        }



        public T Pop()
        {
            return _arr[_index + 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _index; i++)
            {
                yield return _arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
     


}

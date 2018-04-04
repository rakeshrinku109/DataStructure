using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkedListImplementation
{
    public class LinkedList<T> : ICollection<T>,IDisposable
    {
        public Node<T> Head;
        public Node<T> Tail;
        Node<T> _current;
        
        public int Count { get; private set; } = 0;

        public object SyncRoot { get; }

        public bool IsSynchronized { get; }

        public bool IsReadOnly => false;

        private void AddFirst(T Value)
        {
            Node<T> Node = this.Head;
            Node<T> NewNode = Intitialize(Value);

            this.Head = NewNode;
            this.Head.Next = Node;

            if (Count == 0)
            {
                Tail = Head;
            }
            Count++;
        }

        private void AddLast(T Value)
        {
            Node<T> NewNode = Intitialize(Value);
            Node<T> TempNode = this.Tail;
            this.Tail.Next = NewNode;
            this.Tail = NewNode;
            if (Count == 0)
            {
                Head = Tail;
            }
            Count++;
        }

        public Node<T> Intitialize(T Value) => new Node<T>(value:Value);


        public void CopyTo(Array array, int index)
        {
            
        }

        /// <summary>
        /// Implement sorting algorithm
        /// </summary>
        /// <param name="_node"></param>
        public void Sort(Node<T> _node)
        {

        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
            this.Dispose();
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            this._current = Head;
            while (_current.Next !=null)
            {
                _current = _current.Next;
                 return _current.Value.Equals(item);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _current = this.Head;
            while (_current != null)
            {
                array[arrayIndex++] = _current.Value;
                _current = _current.Next;
            }
        }

        public bool Remove(T item)
        {
            Node<T> _previous = null;
            this._current = this.Head;
                while (_current != null)
                {
                    if (_current.Value.Equals(item))
                    {
                        if (_previous != null)
                        {
                            _previous.Next = _current.Next;

                            if (_current.Next == null)
                            {
                                Tail = _previous;
                            }
                          Count--;
                        }
                        else
                        {
                          RemoveFirst();
                        }
                    return true;
                    }
                    _previous = this._current;
                    _current = _current.Next;
                }
            return false;
        }

            public void RemoveFirst()
            {
                if (Count != 0)
                {
                    // Before: Head -> 3 -> 5
                    // After:  Head ------> 5

                    // Head -> 3 -> null
                    // Head ------> null
                    Head = Head.Next;
                    Count--;

                    if (Count == 0)
                    {
                        Tail = null;
                    }
                }
            }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    // Before: Head --> 3 --> 5 --> 7
                    //         Tail = 7
                    // After:  Head --> 3 --> 5 --> null
                    //         Tail = 5
                    Node<T> current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;
                }

                Count--;
            }
        }



        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            _current = Head;
            while (_current !=null)
            {
                yield return _current.Value;
                _current = _current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }


        bool IsDisposed = true;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // dispose unmanaged object
                    
                }

            }

        }


     
    }

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public Node<T> Next;
        
    }
}

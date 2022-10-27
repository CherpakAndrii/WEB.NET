using System.Collections;

namespace OwnListLib;

public partial class OwnList<T>
{
    public class ListEnumerator : IEnumerator<T>
    {
        public ListEnumerator(Node? first)
        {
            _current = new Node(default) { Next = first };
        }

        private Node _current;
        public bool MoveNext()
        {
            if (_current.Next is null) return false;
            _current = _current.Next;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public T Current => _current.Data;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            List<int> l = new List<int>();
            var v = l.GetEnumerator();
        }
    }
}
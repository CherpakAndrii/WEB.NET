using System.Collections;

namespace OwnListLib;

public partial class OwnList<T> : IList<T> where T : IEquatable<T>
{
    private int _count;
    public int Count => _count;

    public Node? _head, _tail;
    public bool IsReadOnly { get; set; }

    public OwnList()
    {
        _head = _tail = null;
        _count = 0;
        IsReadOnly = false;
    }
    
    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (_count == 0)
        {
            _head = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
        }
        _tail = newNode;
        _count++;
        OnAddElement?.Invoke(this, EventArgs.Empty);
    }

    public void Clear()
    {
        _count = 0;
        _head = _tail = null;
        OnClearList?.Invoke(this, EventArgs.Empty);
    }

    public bool Contains(T item)
    {
        return FindNodeByValue(item).Item1 != -1;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex + Count > array.Length) throw new IndexOutOfRangeException("Array length is less than required");
        IEnumerator<T> enumerator = GetEnumerator();
        while (enumerator.MoveNext())
        {
            array[arrayIndex] = enumerator.Current;
            arrayIndex++;
        }
        enumerator.Dispose();
    }

    public bool Remove(T item)
    {
        Node? selected = FindNodeByValue(item).Item2;
        if (selected is null) return false;
        RemoveNode(selected);
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new ListEnumerator(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return FindNodeByValue(item).Item1;
    }

    public void Insert(int index, T item)
    {
        if (index > _count || index < 0) throw new IndexOutOfRangeException();
        if (index == _count)
        {
            Add(item);
            return;
        }
        Node selected = GetNodeAtIndex(index);
        Node newNode = new Node(item);
        if (index == 0) _head = newNode;
        else
        {
            selected.Previous.Next = newNode;
            
        }
        newNode.Previous = selected.Previous;
        selected.Previous = newNode;
        newNode.Next = selected;
        _count++;
        OnAddElement?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveAt(int index)
    {
        if (index < 0) throw new IndexOutOfRangeException();
        Node selected = GetNodeAtIndex(index);
        RemoveNode(selected);
    }

    public T this[int index]
    {
        get => GetNodeAtIndex(index).Data;
        set
        {
            if (IsReadOnly) throw new FieldAccessException("The list is readonly");
            GetNodeAtIndex(index).Data = value;
        }
    }

    private (int, Node?) FindNodeByValue(T value)
    {
        if (_count == 0) return (-1, null);
        Node? current = _head;
        int index = 0;
        do
        {
            if (current.Data.Equals(value)) return (index, current);
            current = current.Next;
            index++;
        } while (current is not null);
        return (-1, null);
    }

    private Node GetNodeAtIndex(int index)
    {
        if (index < 0) index += _count;
        if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
        if (index < _count / 2) return _head[index];
        return _tail[index - _count + 1];
    }

    private void RemoveNode(Node selected)
    {
        if (_count == 1) _head = _tail = null;
        else if (selected == _head)
        {
            _head = selected.Next;
            _head.Previous = null;
        }
        else if (selected == _tail)
        {
            _tail = selected.Previous;
            _tail.Next = null;
        }
        else
        {
            selected.Previous.Next = selected.Next;
            selected.Next.Previous = selected.Previous;
        }

        _count--;
        OnRemoveElement?.Invoke(this, EventArgs.Empty);
    }
    
    public void MakeReadonly() => IsReadOnly = true;

    public event EventHandler? OnAddElement;
    public event EventHandler? OnRemoveElement;
    public event EventHandler? OnClearList;
}
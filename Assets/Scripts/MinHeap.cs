using System;
using System.Collections.Generic;

public class MinHeap<T>
{
    private List<T> elements = new List<T>();
    private IComparer<T> comparator;
    private Dictionary<T, bool> visited = new Dictionary<T, bool>();

    public MinHeap(IComparer<T> c)
    {
        comparator = c;
    }

    public int GetSize()
    {
        return elements.Count;
    }

    public T GetMin()
    {
        return this.elements.Count > 0 ? this.elements[0] : default(T);
    }

    public int Count()
    {
        return elements.Count;
    }

    private void AddIt(T item)
    {
        elements.Add(item);
        this.HeapifyUp(elements.Count - 1);
    }

    public bool Add(T item)
    {
        if (visited.ContainsKey(item))
        {
            return false;
        }
        else
        {
            visited.Add(item, true);
            AddIt(item);
            return true;
        }
    }

    public T PopMin()
    {
        if (elements.Count > 0)
        {
            T item = elements[0];
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);

            visited.Remove(item);

            this.HeapifyDown(0);
            return item;
        }

        throw new InvalidOperationException("no element in heap");
    }

    private void HeapifyUp(int index)
    {
        var parent = this.GetParent(index);
        if (parent >= 0 && (comparator.Compare(elements[index], elements[parent])) < 0)
        {
            var temp = elements[index];
            elements[index] = elements[parent];
            elements[parent] = temp;

            this.HeapifyUp(parent);
        }
    }

    private void HeapifyDown(int index)
    {
        var smallest = index;

        var left = this.GetLeft(index);
        var right = this.GetRight(index);

        if (left < this.GetSize() && comparator.Compare(elements[left], elements[index]) < 0)
        {
            smallest = left;
        }

        if (right < this.GetSize() && comparator.Compare(elements[right], elements[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != index)
        {
            var temp = elements[index];
            elements[index] = elements[smallest];
            elements[smallest] = temp;

            this.HeapifyDown(smallest);
        }

    }

    private int GetParent(int index)
    {
        if (index <= 0)
        {
            return -1;
        }

        return (index - 1) / 2;
    }

    private int GetLeft(int index)
    {
        return 2 * index + 1;
    }

    private int GetRight(int index)
    {
        return 2 * index + 2;
    }
}
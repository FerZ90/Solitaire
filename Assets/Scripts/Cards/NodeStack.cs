using System.Collections.Generic;

public class NodeStack<T> : IStack<T>
{
    private Node<T> head;

    public void AddFirst(T item)
    {
        Node<T> toAdd = new Node<T>();

        toAdd.data = item;
        toAdd.next = head;

        head = toAdd;
    }

    public bool AddLast(T item)
    {
        if (head == null)
        {
            head = new Node<T>();
            head.data = item;
            head.next = null;
        }
        else
        {
            Node<T> toAdd = new Node<T>();
            toAdd.data = item;

            Node<T> current = head;

            while (current.next != null)
            {
                if (current.data.Equals(item))
                    return false;

                current = current.next;
            }

            current.next = toAdd;
        }

        return true;
    }

    public int GetItemIndex(T item)
    {
        if (head == null)
            return -1;

        Node<T> current = head;
        int count = 0;

        while (current.next != null)
        {
            count++;

            if (current.next.data.Equals(item))
                break;

            current = current.next;
        }

        return count;
    }

    public List<T> GetNodeItems(T item)
    {
        List<T> pile = new List<T>();

        Node<T> current = head;

        if (current == null || current.data == null)
            return null;

        bool found = false;

        while (current.data != null)
        {
            if (current.data.Equals(item))
                found = true;

            if (found)
                pile.Add(current.data);

            current = current.next;
        }

        return pile;
    }

    public bool RemoveItem(T item)
    {
        Node<T> current = head;

        if (current.data.Equals(item))
        {
            head = null;
            return true;
        }

        while (current.next != null)
        {
            if (current.next.Equals(item))
            {
                current.next = current.next.next;
                return true;
            }

        }

        return false;
    }

    public T RemoveLast()
    {
        Node<T> previous = null;
        Node<T> current = head;

        while (current != null && current.next != null)
        {
            previous = current;
            current = current.next;
        }

        if (current == head)
            head = null;

        if (current == null)
            return default(T);

        if (previous != null)
            previous.next = null;

        return current.data;
    }
}


public class Node<T>
{
    public T data;
    public Node<T> next;
}

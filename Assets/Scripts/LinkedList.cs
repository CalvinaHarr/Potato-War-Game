using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList<T> : MonoBehaviour
{
    Node<T> head;

    public LinkedList()
    {
        head = null;
    }

    public void AddToFront(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.setNext(this.head);
        this.head = newNode;
    }

    public Node<T> Head()
    {
        return head;
    }

    /*public Iterator<T> GetIterator()
    {
        return new Iterator<T>(this);
    }*/

    public bool Remove(T data)
    {
        Node<T> curr = head;
        while(curr.Next() != null)
        {
            if(curr.Data().Equals(data))
            {
                curr.setNext(curr.Next());
                return true;
            }
            curr = curr.Next();
        }
        if(curr.Data().Equals(data))
        {
        curr.setNext(curr.Next());
        return true;
        }
        return false;
    }

    
/*
    public class Iterator<D>
    {
        Node<T> current;
        public T next;

        public Iterator(LinkedList<T> list)
        {
            current = list.Head();
        }

        public bool HasNext()
        {
            return next == null;
        }

        public T Next()
        {
            return next;
        }
    }*/
}

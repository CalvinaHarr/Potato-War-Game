using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T> : MonoBehaviour
{
        T data;
        Node<T> next;

        public Node(T data)
        {
            data = data;
            next = null;
        }

        public Node<T> Next()
        {
            return next;
        }

        public T Data()
        {
            return data;
        }

        public void setNext(Node<T> nextNode)
        {
            next = nextNode;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            // TODO: write your implementation of Equals() here
            throw new System.NotImplementedException();
            return base.Equals (obj);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }
}

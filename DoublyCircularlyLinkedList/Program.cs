using System;
using System.Net.Http.Headers;

namespace DoublyCircularlyLinkedList
{
    class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T value)
        {
            Value = value;
        }
    }
    class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
        public int Count;
        public Node<T> Head;
        public Node<T> Tail;
        public T Value { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public void AddFirst(T value)
        {
            if (Head == null)
            {
                Node<T> node = new Node<T>(Value);
                Head = node;
                Tail = Head;
                Head.Next = Tail;
                Head.Previous = Tail;
                Count++;

            }
            else
            {
                Node<T> nodeToInsert = new Node<T>(Value);
                nodeToInsert.Next = Head;
                Head.Previous = nodeToInsert;
                Head = nodeToInsert;
                nodeToInsert.Previous = Tail;
                Tail.Next = Head;

                Count++;
            }
        }

        public void AddLast(T Value)
        {
            if (Head == null)
            {
                Node<T> node = new Node<T>(Value);
                Head = node;
                Tail = Head;
                Head.Next = Tail;
                Head.Previous = Tail;
                Count++;

            }
            else
            {
                Node<T> nodeToInsert = new Node<T>(Value);
                nodeToInsert.Previous = Tail;
                Tail.Next = nodeToInsert;
                Tail = nodeToInsert;
                nodeToInsert.Next = Head;
                Head.Previous = Tail;


            }
        }

        public void AddAfter(Node<T> node, T value)
        {
            Node<T> placeHolder = Head;
            for (int i = 0; i < Count; placeHolder = placeHolder.Next, i++)
            {
                if(placeHolder == node)
                {
                    Node<T> newNode = new Node<T>(Value);
                    
                    newNode.Next = placeHolder.Next.Next;
                    newNode.Previous = placeHolder;
                    placeHolder.Next = newNode;

                }
            }
        }
    }



}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}


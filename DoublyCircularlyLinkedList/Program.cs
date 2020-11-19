using DoublyCircularlyLinkedList;
using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

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
    class DoublyLinkedList<T>
    {

        public int Count;
        public Node<T> Head;
        public Node<T> Tail;




        public void AddFirst(T Value)
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
                Count++;


            }
        }

        public void AddAfter(T node, T Value)
        {
            Node<T> placeHolder = Head;
            for (int i = 0; i < Count; placeHolder = placeHolder.Next, i++)
            {
                if (placeHolder.Value.Equals(node))
                {
                    Node<T> newNode = new Node<T>(Value);

                    newNode.Next = placeHolder.Next;
                    newNode.Previous = placeHolder;
                    placeHolder.Next = newNode;
                    placeHolder.Next.Next.Previous = newNode;
                    Count++;

                }
            }
        }

        public void AddBefore(T node, T Value)
        {
            Node<T> placeHolder = Head;
            for (int i = 0; i < Count; placeHolder = placeHolder.Next, i++)
            {
                if (placeHolder.Value.Equals(node))
                {
                    Node<T> newNode = new Node<T>(Value);

                    newNode.Previous = placeHolder.Previous;
                    newNode.Next = placeHolder;
                    placeHolder.Previous = newNode;
                    placeHolder.Previous.Previous.Next = newNode;
                    Count++;
                }
            }
        }

        public bool RemoveFirst()
        {

            if (Head == null)
            {
                return false;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = Tail;
                Tail.Next = Head;
                Count--;

                if (Count == 0)
                {
                    Clear();
                }
                return true;
            }


        }

        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                Tail = Tail.Previous;
                Head.Previous = Tail;
                Tail.Next = Head;

                Count--;

                if (Count == 0)
                {
                    Clear();
                }
                return true;
            }
        }

        public bool Remove(T Value)
        {

            if (Head == null)
            {
                return false;
            }

            if (Value.Equals(Head))
            {
                RemoveFirst();
            }

            if (Value.Equals(Tail))
            {
                RemoveLast();
            }
            Node<T> placeHolder = Head;
            for (int i = 0; i < Count; placeHolder = placeHolder.Next, i++)
            {
                if (placeHolder.Value.Equals(Value))
                {
                    Node<T> placeHolderPrev = placeHolder.Previous;


                    placeHolder = placeHolder.Next;
                    placeHolder.Previous = placeHolderPrev;
                    placeHolder.Previous.Next = placeHolder;
                    Count--;

                    if (Count == 0)
                    {
                        Clear();
                    }
                    return true;


                }

            }

            return false;
        }


        public bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }

            return false;
        }

        public int Counter => Count;

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

    }




    class Program
    {
        static void Main(string[] args)
        {

            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.Remove(58);
            //list.AddFirst(3);
            //list.AddFirst(2);
            //list.AddFirst(1);
            //;

            //list.AddLast(4);
            //list.AddLast(5);
            //;

            //list.AddBefore(3, 6);
            //;
            //list.AddAfter(6, 7);
            //;


            //list.RemoveFirst();
            //;
            //list.RemoveLast();
            //;

            //list.Remove(6);
            ;
        }
    }
}


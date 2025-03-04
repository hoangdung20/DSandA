using System.ComponentModel;
using System.Text;

/// <summary>
/// 参照: https://www.geeksforgeeks.org/how-to-implement-generic-singly-linkedlist-in-c-sharp/
/// </summary>
//namespace Singly_linkedlist
//{
//    public interface INode<K>
//    {
//        K Value { get; set; }
//    }
//    public class LinkedList<T>
//    {
//        private class Node<K>:INode<K>
//        {
//            public K Value { get; set; }
//            public Node<K> Next { get; set; }   
//            public Node(K value, Node<K> next)
//            {
//                Value = value;
//                Next = next;
//            }
//            /// <summary>
//            /// Print the node and the next value 
//            /// Output Format of the function 
//            // {(element)->next element}
//            /// </summary>
//            /// <returns></returns>
//            public override string ToString()
//            {
//                StringBuilder sb = new StringBuilder();
//                sb.Append("{");
//                sb.Append("(");
//                sb.Append(Value);
//                sb.Append(")->");
//                sb.Append(Next.Next == null ? "XXX":Next.Value.ToString());
//                sb.Append("}");

//                return sb.ToString();
//            }

//        }
//        private Node<T> Head { get; set; }
//        private Node<T> Tail { get; set; }
//        public int Count { get; private set; } = 0;
//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public LinkedList()
//        {
//            Head = new Node<T>(default(T), null);
//            Tail = new Node<T>(default(T), null);
//            Head.Next = Tail;
//        }
//        public INode<T> First
//        {
//            get
//            {
//                if (Count == 0) return null;
//                return Head.Next;
//            }
//        }
//        /// <summary>
//        /// Function return the next node of the node passed in the function
//        /// </summary>
//        /// <param name="node"></param>
//        /// <returns></returns>
//        /// <exception cref="NullReferenceException"></exception>
//        /// <exception cref="InvalidOperationException"></exception>
//        public INode<T> After(INode<T> node)
//        {
//            if(node == null) throw new NullReferenceException();
//            Node<T> node_current = node as Node<T> ;
//            if(node_current.Next == null)
//            {
//                throw new InvalidOperationException("The node referred 'after' is no longer in the list");
//            }
//            if (node_current.Next.Equals(Tail)) return null;
//            return node_current.Next;
//        }
//        /// <summary>
//        /// Function to find a particular node 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public INode<T> Find(T value)
//        {
//            Node<T> node = Head.Next;
//            while (!node.Equals(Tail))
//            {
//                if(node.Value.Equals(value)) return node;
//                node = node.Next;
//            }
//            return null;
//        }
//        /// <summary>
//        /// Function to print the entire linked list 
//        /// </summary>
//        /// <returns></returns>
//        public override string ToString()
//        {
//            if (Count == 0) return "[]";
//            StringBuilder sb = new StringBuilder();
//            sb.Append("[");
//            int k = 0;
//            Node<T> node = Head.Next;
//            while (!node.Equals(Tail))
//            {
//                sb.Append(node.ToString());
//                node = node.Next;
//                if(k < Count - 1) sb.Append(",");
//                k++;
//            }
//            sb.Append("]");

//            return sb.ToString();

//        }
//        /// <summary>
//        /// Function to add elements at the starting of the list 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public INode<T> AddFirst(T value)
//        {
//            Node<T> new_node = new Node<T>(value, Head.Next);
//            Head.Next = new_node;
//            Count++;
//            return new_node;
//        }
//        /// <summary>
//        /// Function to add at the end of the list
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public INode<T> AddLast(T value)
//        {
//            Node<T> node = Head;
//            Node<T> new_node;
//            if(Head.Next != Tail)
//            {
//                while (!node.Next.Equals(Tail))
//                {
//                    node = node.Next;
//                }
//            }
//            new_node = new Node<T>(value, Tail);
//            node.Next = new_node;
//            Count++;
//            return new_node;
//        }
//        public INode<T> AddAfter(INode<T> after, T value)
//        {
//            Node<T>  current_node = after as Node<T>;
//            Node<T> new_node = new Node<T>(value, current_node.Next);
//            current_node.Next = new_node;
//            Count++;
//            return new_node;
//        }
//        /// <summary>
//        /// Function to remove all the elements of the list
//        /// 
//        /// </summary>
//        public void Clear()
//        {
//            INode<T> node = First;
//            for(int i = 0; i < Count; i++)
//            {
//                Remove(node);
//                node = After(node);
//            }
//            Count = 0;
//        }
//        /// <summary>
//        /// Function to remove a particular node
//        /// </summary>
//        /// <param name="node"></param>
//        /// <exception cref="ArgumentNullException"></exception>
//        /// <exception cref="InvalidOperationException"></exception>
//        public void Remove(INode<T> node)
//        {
//            if (node == null) throw new ArgumentNullException();
//            if (Find(node.Value) == null) throw new InvalidOperationException();
//            Node<T> remove = node as Node<T>;
//            Node<T> current_node = Head;
//            while (!current_node.Next.Next.Equals(remove.Next))
//            {
//                current_node = current_node.Next;
//            }
//            current_node.Next = remove.Next;
//            Count--;
//        }
//        /// <summary>
//        /// Frist to remove frist node
//        /// </summary>
//        /// <exception cref="InvalidOperationException"></exception>
//        public void RemoveFirst()
//        {
//            if(Count == 0) throw new InvalidOperationException();
//            Remove(First);
//        }
//        /// <summary>
//        /// Function to remove last node
//        /// </summary>
//        public void RemoveLast()
//        {
//            if (Count == 0) throw new InvalidOperationException();
//            Node<T> current_node = Head;
//            while (!current_node.Next.Next.Equals(Tail))
//            {
//                current_node = current_node.Next;
//            }
//            current_node.Next=Tail;
//            Count--;
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            LinkedList<int> list = new LinkedList<int>();
//            list.AddLast(0);
//            list.AddLast(1);
//            list.AddLast(2);
//            list.AddLast(3);
//            list.AddLast(4);
//            Console.Write("List: ");
//            Console.WriteLine(list.ToString());

//            list.AddAfter(list.Find(4), 5);
//            Console.Write("List after adding 5: ");
//            Console.WriteLine(list.ToString());

//            list.RemoveLast();
//            Console.Write("List after remove last: ");
//            Console.WriteLine(list.ToString());

//            list.RemoveFirst();
//            Console.Write("List after remove first: ");
//            Console.WriteLine(list.ToString());

//            list.AddFirst(0);
//            Console.Write("List after Add first: ");
//            Console.WriteLine(list.ToString());

//            //list.AddLast(5);
//            //Console.Write("List: ");
//            //Console.WriteLine(list.ToString());

//            //Console.Write("After 4: ");
//            //Console.WriteLine(list.After(list.Find(4)));

//            //list.Remove(list.Find(7));
//            //Console.Write("List after removing 7: ");
//            //Console.WriteLine(list.ToString());

//            //Console.WriteLine();

//            //LinkedList<string> cities = new LinkedList<string>();

//            //cities.AddFirst("Ludhiana");
//            //cities.AddFirst("Jalandhar");

//            //Console.Write("Cities: ");
//            //Console.WriteLine(cities.ToString());

//            //cities.AddLast("Amritsar");

//            //Console.Write("Cities: ");
//            //Console.WriteLine(cities.ToString());
//        }
//    }
//}

namespace Singly_linkedlist
{
    public sealed class LinkedList<T>
    {
        private sealed class Node
        {
            public T Value { get; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public override string ToString() => $"{{{Value}}}";
        }

        private Node? _head;
        private Node? _tail;
        public int Count { get; private set; }

        public LinkedList()
        {
            _head = null;
            _tail = null;
        }

        // Thay đổi ở đây để xử lý trường hợp null
        public T First
        {
            get
            {
                if (_head == null)
                {
                    throw new InvalidOperationException("List is empty");
                }
                return _head.Value;
            }
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        private Node? Find(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (Equals(current.Value, value)) return current;
                current = current.Next;
            }
            return null;
        }

        public void AddFirst(T value)
        {
            var newNode = new Node(value);
            newNode.Next = _head;
            _head = newNode;

            if (_tail == null) _tail = newNode;

            Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail!.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        public bool Remove(T value)
        {
            if (_head == null) return false;

            if (Equals(_head.Value, value))
            {
                _head = _head.Next;
                Count--;

                if (_head == null) _tail = null;

                return true;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (Equals(current.Next.Value, value))
                {
                    current.Next = current.Next.Next;

                    if (current.Next == null) _tail = current;

                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";

            var sb = new StringBuilder("[");
            var current = _head;
            while (current != null)
            {
                sb.Append(current);
                current = current.Next;
                if (current != null) sb.Append(", ");
            }
            sb.Append(']');

            return sb.ToString();
        }
    }

    internal class Program
    {
        static void Main()
        {
            var list = new LinkedList<int>();

            //list.Remove(4);
            //Console.WriteLine("List after remove: " + list);

            list.AddFirst(-1);
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            Console.WriteLine("List: " + list);
            //Console.WriteLine("List after add first: " + list);
            // Thêm một ví dụ về việc xử lý trường hợp First khi danh sách rỗng
            try
            {
                var firstElement = list.First; // Sẽ ném ra InvalidOperationException nếu danh sách rỗng
                Console.WriteLine($"First element: {firstElement}");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
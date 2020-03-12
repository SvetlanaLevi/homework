using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{

    public class Node
    {
        public int value;
        public Node next;
        public Node prev;

        public Node(int val)
        {
            value = val;
        }
    }

    public class LinkedList
    {
        private Node head;
        private Node tail;
        private Node prev;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            prev = null;
            count = 0;
        }

        public LinkedList(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                AddLast(vals[i]);
            }
        }


        public Node GetlastNode()
        {
            if (head == null) return head;
            //шагание по нодам
            Node currentnode = head;
            while (currentnode.next != null)
            {
                currentnode = currentnode.next;
            }

            return currentnode;
        }


        public int GetFirst() //вернёт значение первого элемента списка
        {
            return head.value;
        }


        public int GetLast() //вернёт значение последнего элемента списка
        {
            return tail.value;
        }


        public int GetSize() //узнать кол-во элементов в списке
        {
            return count;
        }


        public int Get(int idx) //вернёт значение элемента списка c указанным индексом
        {
            if (idx >= count)
            {
                //выдать ошибку
            }

            Node currentnode = head;
            int i = 0;
            while (i < idx)
            {
                currentnode = currentnode.next;
                i++;
            }
            return currentnode.value;
        }


        public void AddLast(int val) //добавление значения в конец списка
        {
            Node node = new Node(val);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
            }
            tail = node;
            count++;
        }


        public void AddLast(int[] vals)  //добавление массива в конец списка
        {
            for (int i = 0; i < vals.Length; i++)
            {
                AddLast(vals[i]);
            }
        }


        public void AddFirst(int val) //добавление в начало списка
        {
            Node node = new Node(val);
            if (count == 0)
            {
                tail = head;
            }
            else
            {
            node.next = head;
            head.prev = node;
            }
            head = node;
            count++;
        }

        public void AddFirst(int[] vals) //добавление массива в начало списка
        {
            Node LastInArray = new Node(vals[vals.Length - 1]);

            if (count == 0)
            {
                tail = LastInArray;
            }
            else
            {
                head.prev = LastInArray;
                LastInArray.next = head;
            }
            count++;

            Node node = new Node(vals[0]);
            head = node;
            count++;
            Node prev = null;
            
            for (int i = 1; i < vals.Length - 2; i++)
            {
                node.next = new Node(vals[i]);
                node.prev = prev;
                prev = node;
                node = node.next;
                count++;
            }

            node.next = LastInArray;
        }


        public void AddAt(int idx, int val) //вставка по указанному индексу
        {
            if (idx > count)
            {
                //выдать ошибку!!!
            }

            if (idx == 0)
            {
                AddFirst(val);
                return;
            }

            if (idx == count)
            {
                AddLast(val);
                return;
            }

            Node currentnode = head;
            int i = 0;
            while (i < idx - 1)
            {
                currentnode = currentnode.next;
                i++;
            }
            Node node = new Node(val);
            node.next = currentnode.next;
            node.prev = currentnode;
            currentnode.next = node;
            node.next.prev = node;
            count++;

        }


        public void AddAt(int idx, int[] vals) //вставка массива по указанному индексу
        {
            if (idx > count)
            {
                //выдать ошибку
            }

            for (int i = 0; i < vals.Length; i++)
            {
                AddAt(idx, vals[i]);
                idx++;
            }
        }


        public void Set(int idx, int val) //поменять значение элемента с указанным индексом 
        {
            if (idx >= count)
            {
                //выдать ошибку
            }

            Node currentnode = head;
            int i = 0;
            while (i < idx)
            {
                currentnode = currentnode.next;
                i++;
            }
            currentnode.value = val;
        }


        public void RemoveFirst() //удаление первого элемента 
        {
            this.head = head.next;
            count--;
        }


        public void RemoveLast() //удаление последнего элемента
        {
            Node currentnode = head;
            for (int i = 0; i < count - 1; i++)
            {
                currentnode = currentnode.next;
            }

            tail = currentnode;
            currentnode.next = null;
            count--;
        }


        public void RemoveAt(int idx) //удаление по индексу
        {
            if (idx >= count)
            {
                //выдать ошибку
            }

            if (idx == 0)
            {
                RemoveFirst();
                return;
            }

            if (idx == count - 1)
            {
                RemoveLast();
                return;
            }

            Node currentnode = head;
            for (int i = 0; i < idx - 1; i++)
            {
                currentnode = currentnode.next;
            }

            Node next = currentnode.next;
            currentnode.next = next.next;
            next.next.prev = currentnode;
            count--;
        }


        public void RemoveAll(int val) //удалить все элементы, равные val
        {
            Node currentnode = head;
            for (int i = 0; i < count; i++)
            {
                if (currentnode.value == val)
                {
                    RemoveAt(i);
                }
                currentnode = currentnode.next;
            }
        }


        public int Contains(int val) //вернёт индекс первого найденного элемента, равного val (или -1, если элементов с таким значением в списке нет) 
        {
            Node currentnode = head;
            for (int i = 0; i < count; i++)
            {
                if (currentnode.value == val)
                {
                    return i;
                }
                currentnode = currentnode.next;
            }
            return -1;
        }

        public int[] ToArray() //преобразовать список в массив
        {
            Node currentnode = head;
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = currentnode.value;
                currentnode = currentnode.next;
            }
            return array;
        }


        public void Reverse() //изменение порядка элементов списка на обратный
        {
            Node current = head;
            tail = head;
            while (current != null)
            {
                Node tmp = current.next;
                current.next = current.prev;                             
                current.prev = tmp;
                head = current;
                current = current.prev;
            }

        }

    }
}
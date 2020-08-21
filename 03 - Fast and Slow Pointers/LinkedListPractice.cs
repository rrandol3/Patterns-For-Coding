using System;
using System.Collections.Generic;
using System.Text;

namespace _03___Fast_and_Slow_Pointers
{
    public class LinkedListPractice
    {
        LinkedListNodePractice head;
        public void AddFirst(int val)
        {
            LinkedListNodePractice newNode = new LinkedListNodePractice(val);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
                //Another possible way
                //var oldHead = head;
                //head = newNode;
                //newNode.next = oldHead;
            }
        }
        public void AddLast(int val)
        {
            LinkedListNodePractice newNode = new LinkedListNodePractice(val);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = newNode;
            }
        }
        public void AddAtIndex(int index, int val)
        {
            LinkedListNodePractice newNode = new LinkedListNodePractice(val);
            if (index == 0)
            {
                //newNode.next = head;
                //head = newNode;
                //or
                AddFirst(val);
            }
            else
            {
                var curr = head;
                LinkedListNodePractice prev = null;
                int i = 0;
                while (curr != null)
                {
                    if (i == index)
                    {
                        prev.next = newNode;
                        newNode.next = curr;
                        break;
                    }
                    prev = curr;
                    curr = curr.next;
                    i++;
                }
            }
        }
        public void RemoveFirst()
        {
            head = head.next;
        }
        public void RemoveLast()
        {
            var curr = head;
            LinkedListNodePractice prev = null;
            while (curr.next != null)
            {
                prev = curr;
                curr = curr.next;
            }
            prev.next = null;
        }
        public void RemoveAtIndex(int index)
        {
            if (index == 0)
            {
                head = head.next;
                return;
            }
            var curr = head;
            LinkedListNodePractice prev = null;
            int i = 0;
            while (curr != null)
            {
                if (i == index)
                {
                    prev.next = curr.next;
                    curr.next = null;
                    break;
                }
                prev = curr;
                curr = curr.next;
                i++;
            }
        }
        public void Reverse()
        {
            var curr = head;
            LinkedListNodePractice prev = null;
            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }
        public void Print()
        {
            var curr = head;
            while (curr != null)
            {
                Console.Write($"{curr.val} ");
                curr = curr.next;
            }
        }
    }

    public class LinkedListNodePractice
    {
        public int val;
        public LinkedListNodePractice next;
        public LinkedListNodePractice(int val)
        {
            this.val = val;
        }
        public LinkedListNodePractice()
        {

        }
    }
}

using System;
using System.Xml;

namespace _06___In_place_Reversal_of_a_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);
            var ans = ReverseBetween(list, 2, 4);
            while (ans != null)
            {
                Console.Write($"{ans.val} ");
                ans = ans.next;
            }
        }

        //Reverse a LinkedList (easy) https://leetcode.com/problems/reverse-linked-list/
        public static ListNode ReverseList(ListNode head)
        {
            var curr = head;
            ListNode prev = null;
            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        //Reverse a Sub-list (medium) https://leetcode.com/problems/reverse-linked-list-ii/
        //Notes: did not get right, need to review
        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            var curr = head;
            ListNode prev = null;
            for (int i = 0; curr != null && i < m - 1; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            var lastNodeOfFirstPart = prev;
            var lastNodeOfSubList = curr;
            ListNode next = null;
            for (int i = 0; curr != null && i < n - m + 1; i++)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            if (lastNodeOfFirstPart != null)
            {
                lastNodeOfFirstPart.next = prev;
            }
            else
            {
                head = prev;
            }

            lastNodeOfSubList.next = curr;


            return head;
        }

        //Reverse every K-element Sub-list (medium) https://leetcode.com/problems/reverse-nodes-in-k-group/
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            var curr = head;
            ListNode prev = null;
            
            return prev;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val)
        {
            this.val = val;
        }
    }
}

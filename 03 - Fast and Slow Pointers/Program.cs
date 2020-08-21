using System;

namespace _03___Fast_and_Slow_Pointers
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListPractice list = new LinkedListPractice();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.Reverse();
            list.Print();
        }

        //LinkedList Cycle (easy) 141. Linked List Cycle https://leetcode.com/problems/linked-list-cycle/
        public static bool HasCycle(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        //Start of LinkedList Cycle (medium) https://leetcode.com/problems/linked-list-cycle-ii/
        //Notes: did not get right, need to review
        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var slow = head;
            var fast = head;
            ListNode ans = null;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    ans = FindNode(slow, head);
                    break;
                }
            }
            return ans;
        }
        public static ListNode FindNode(ListNode node, ListNode head)
        {
            var ptr1 = node;
            var ptr2 = head;
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }
            return ptr1;
        }

        //Happy Number (medium) https://leetcode.com/problems/happy-number/
        public bool IsHappy(int n)
        {
            
            return false;
        }

        //Middle of the LinkedList (easy) https://leetcode.com/problems/middle-of-the-linked-list/
        public static ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
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

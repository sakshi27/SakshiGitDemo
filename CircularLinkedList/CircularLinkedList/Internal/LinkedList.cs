using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList.Internal
{
    class LinkedList<T>
    {
        private ElementNode<T> head= null;
        private ElementNode<T> temp= null;

        private ElementNode<T> CircularLoopPoint()
        {
            ElementNode<T> slow=head, fast=head;
            if (null == slow || null == fast)
                return null;
            while(null!= fast || fast != slow)
            {
                slow = slow.next;
                if(fast.next != null)
                    fast = fast.next.next;
            }
            if(fast != null)
            {
                return fast;
            }
            return null;
        }

        private int LengthofCircularLoop()
        {
            ElementNode<T> meetingNode = CircularLoopPoint();
            if (null == meetingNode) { return -1; }
            ElementNode<T> node= meetingNode;
            int length=0;
            while(node.next != meetingNode)
            {
                length++;
                node = node.next;
            }
            return length;
        }

        private void MakeStaightLL()
        {
            BreakLLFromLoopPoint();
        }

        private void BreakLLFromLoopPoint()
        {
            ElementNode<T> loopPoint = CircularLoopPoint();
            temp = loopPoint.next;
            loopPoint.next = null;

            ElementNode<T> intersectionnode = IntersectionPoint(head, temp);
            ElementNode<T> secondListHead = temp;
            while (temp.next != intersectionnode)
            {
                temp = temp.next;
            }
            temp.next = null;

            loopPoint.next = secondListHead;
        }

        private ElementNode<T> IntersectionPoint(ElementNode<T> head, ElementNode<T> temp)
        {
            bool isIntersect = AreListsIntersecting(head , temp);
            if (!isIntersect)
                return null;
            int headLength = ListSize(head);
            int tempLength = ListSize(temp);
            if(headLength > tempLength)
            {
                for (int i = 0; i < (headLength- tempLength); i++)
                {
                    head = head.next;
                }
            }
            else
            {
                for (int i = 0; i < (tempLength - headLength); i++)
                {
                    temp = temp.next;
                }
            }

            while(head!= temp)
            {
                head = head.next;
                temp = temp.next;
            }
            return temp;
        }

        private bool AreListsIntersecting(ElementNode<T> head, ElementNode<T> temp)
        {
            while (head != null)
                head = head.next;
            while (temp != null)
                temp = temp.next;
            if (head == temp)
                return true;
            else
                return false;
        }

        private int ListSize(ElementNode<T> headLsit)
        {
            int length = 0;
            if (null == headLsit)
                return 0;
            while(headLsit != null){
                length++;
            }
            return length;
        }

        public void InsertValue(T value)
        {
            InsertNodeInLLAtHead(new ElementNode<T>(value));
        }
        private void InsertNodeInLLAtHead(ElementNode<T> node)
        {
            if (head == null)
            {
                head = node;
                return;
            }
            node.next = head;
            head = node;
        }
    }

    
}

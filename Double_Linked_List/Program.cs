using System;

namespace Double_Linked_List
{
    class Node
    {
        /*Node class represents the node of doubly linked list.
         * * It consists of the information part and links to
         * * its succeeding and preceeding nodes
         * * in terms of next and previous nodes. */
        public int rollNumber;
        public string name;
        public Node next; /*points to the succeeding node*/
        public Node prev; /*points to the preceeding node*/
    }
    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()/*Adds a new node*/
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student:  ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.rollNumber = rollNo;
            newNode.name = nm;
            /*Checks if the list is empty*/
            if (START == null || rollNo <= START.rollNumber)
            {
                if ((START != null) && (rollNo == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                rollNo >= current.rollNumber; previous = current, current =
                current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop,prev and 
             * * current will point to those nodes
             * between which the new node is to be inserted. */
            newNode.next = current;
            newNode.prev = previous;

            /*if the node is to be inserted at the end of the list. */
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.next = newNode;
            previous.next = current;
        }

        
        }
    }
}
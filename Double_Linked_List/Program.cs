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
        /*Checks wheteher the specified node is present*/
        public bool search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNo != current.rollNumber; previous = current,
                current = current.next)
            { }
            /*The above for loop traverses the list if the specified node
             * * is found then the fonction returns true, otherwise false. */
            return (current != null);
        }

        public bool dellNode(int rollNo) /*Deletes the specified node*/
        {
            Node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == START)/*If the first node is to be deleted*/
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)/*If the last node is to be deleted*/
            {
                previous.next = null;
                return true;
            }
            /*If the node to be deleted is in beetwen the list then the
             * following lines of code is excuted. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public void traverse()/*Traverses the list*/
        {

            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" +
                    "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " "
                        + currentNode.name + "\n");
            }
        }

        /*traverses the list in the reverse direction*/
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" +
                    "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + " "
                        + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu" +
                        "\n 1. Add a record to the list" +
                        "\n 2. Delete a record from the list" +
                        "\n 3. View all record in ascending order of roll number" +
                        "\n 4. View all record in descending order of roll number" +
                        "\n 5. Search for a record in the list " +
                        "\n 6.Exit \n" +
                        "\n Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" +
                                    "whose record is to be deleted:");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                obj.revtraverse();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList id Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the rol number of the student whoses rocord you want to search:");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number" + curr.rollNumber);
                                    Console.WriteLine("\nName:" + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }
}
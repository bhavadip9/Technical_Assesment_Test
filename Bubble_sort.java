class Node
{
    int data;
    Node next;

    Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

public class Bubble_sort
{
    Node head;

    void add(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node temp = head;
        while (temp.next != null)
            temp = temp.next;
        temp.next = newNode;
    }

  
    void printList()
    {
        Node temp = head;
        while (temp != null)
        {
            System.out.print(temp.data);
            if (temp.next != null)
                System.out.print(" -> ");
            temp = temp.next;
        }
        System.out.println();
    }

   
    void bubbleSort()
    {
        if (head == null || head.next == null)
            return;

        boolean swapped;
        do
        {
            swapped = false;
            Node prev = null;
            Node curr = head;

            while (curr != null && curr.next != null)
            {
                Node next = curr.next;

                if (curr.data > next.data)
                {
                    
                    if (prev == null)
                    {
                        
                        curr.next = next.next;
                        next.next = curr;
                        head = next;
                        prev = head;
                    }
                    else
                    {
                        prev.next = next;
                        curr.next = next.next;
                        next.next = curr;
                        prev = next;
                    }

                    swapped = true;
                }
                else
                {
                    prev = curr;
                    curr = curr.next;
                }
            }
        } while (swapped);
    }

    public static void main(String[] args)
    {
        Bubble_sort list = new Bubble_sort();
        list.add(5);
        list.add(1);
        list.add(12);
        list.add(85);
        list.add(42);

        System.out.println("Before sorting:");
        list.printList();

        list.bubbleSort();

        System.out.println("After sorting:");
        list.printList();
    }
}

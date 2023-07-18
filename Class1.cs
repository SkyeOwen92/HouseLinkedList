using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HouseLinkedList
{
    internal class House
    {
        public int HouseNum { get; set; }
        public string Address { get; set; }
        public House next; 
        public House(int houseNum, string address, House house)
        {
            HouseNum = houseNum;
            Address = address;
            next = house;
        }
    }
    class LinkedList
    {
        private House head;
        private House tail;
        private int size;
        public LinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public int Length
        {
            get { return size; }
        }
        public bool IsEmpty()
        { return size == 0; }
        public void AddFirst(int num, string address)
        {
            House newHouse = new House(num, address, null);
            if (IsEmpty())
            {
                tail = newHouse;
            }
            else
            {
                newHouse.next = head;
            }
            head = newHouse;
            size++;

        }
        public void AddLast(int num, string address)
        {
            House newHouse = new House(num, address, null);
            if (IsEmpty())
            {
                head = newHouse;
            }
            else
            {
                tail.next = newHouse;
            }
            tail = newHouse;
            size++;

        }
        public void AddAt(int num, string address, int position)
        {
            if (position <= 0 || position > size)
            {
                MessageBox.Show("Invalid Position");
                return;
            }
            else if (position == 1)
            {
                AddFirst(num, address);
            }
            else
            {
                House newHouse = new House(num,address, null);
                House p = head;
                int i = 2;
                while (i < position-1)
                {
                    p = p.next;
                    i++;
                }
                newHouse.next = p.next;
                p.next = newHouse;
                size++;

            }
        }
        public void RemoveFirst()
        {
            if(IsEmpty())
            {
                MessageBox.Show("List is Empty");
            }
            else
            {
                MessageBox.Show(head.HouseNum + " has been Removed");
                head = head.next;
                size--; 
                if (IsEmpty())
                {
                    tail = null; 
                }
            }
        }
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                MessageBox.Show("List is Empty");
            }
            else
            {
                MessageBox.Show(tail.HouseNum + " has been Removed");
                House p = head;
                int i = 1;
                while (i < size -1)
                {
                    p = p.next;
                    i++;
                }
                p.next = null;
                tail = p; 
                size--;
                if (IsEmpty())
                {
                    head = null;
                }
            }
        }
        public void RemoveAt(int position)
        {
            if (position <= 0 || position > size)
            {
                MessageBox.Show("Invalid Position");
            }
            else if (position == 1)
            {
                RemoveFirst();
            }
            else if (position == size)
            {
                RemoveLast();
            }
            else
            { 
                House p = head;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i++;
                }
                p.next = p.next.next;
                size--;
            }
        }
        public void Search(int num, RichTextBox rtb)
        {
            if(IsEmpty())
            {
                rtb.AppendText("The List is Empty\n");
            }
            House p = head;
            for (int i = 1; i <= size; i++) 
            {
                if(p.HouseNum == num)
                { 
                    rtb.AppendText($"House {p.HouseNum} is located at position {i} and has an address of {p.Address}\n");
                    return;
                }
                p= p.next;
            }
            rtb.AppendText("There is no such house\n");

        }
        public void Display(Label[] nums, PictureBox[] houseIm, PictureBox[] pointer )
        {
            House p = head; //temp pointer
            int i = 0; 
            while (p != null)
            {
                nums[i].Visible = true;
                nums[i].Text = p.HouseNum.ToString();
                houseIm[i].Visible = true;
                if (p.next != null)
                {
                    pointer[i].Visible=true;
                }
                p = p.next;
                i++;
            }
        }
    }
}

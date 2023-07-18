using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseLinkedList
{
    public partial class Form1 : Form
    {
        LinkedList houses = new LinkedList();
        int action;
        int houseNum;
        string addy;
        int pos;
        Label[] houseNumbers = new Label[7];
        PictureBox[] houseImages = new PictureBox[7];
        PictureBox[] pointers = new PictureBox[7];
        public Form1()
        {
            InitializeComponent();
        }
        private void ViewAddFirstOrLast()
        {
            lblAddHouseAddy.Visible = true;
            lblAddHouseNum.Visible = true;
            txtBoxHNAdd.Visible = true;
            textBAddy.Visible = true;
            btnSubmit.Location = new Point(463, 119);
            btnSubmit.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            houseNumbers[0] = lblHN1; houseNumbers[1] = lblHN2; houseNumbers[2] = lblHN3; houseNumbers[3] = lblHN4; houseNumbers[4] = lblHN5; houseNumbers[5] = lblHN6; houseNumbers[6] = lblHN7;
            houseImages[0] = housepic1; houseImages[1] = housepic2; houseImages[2] = housepic3; houseImages[3] = housepic4; houseImages[4] = housepic5; houseImages[5] = housepic6; houseImages[6] = housepic7;
            pointers[0] = pointer1; pointers[1] = pointer2; pointers[2] = pointer3; pointers[3] = pointer4; pointers[4] = pointer5; pointers[5] = pointer6; pointers[6] = pointer7;
        }
        public void DisplayList()
        {
            if(!houses.IsEmpty())
            {
                houses.Display(houseNumbers,houseImages,pointers);
            }
        }
        private void btnAddFront_Click(object sender, EventArgs e)
        {
            ViewAddFirstOrLast();
            action = 0;
        }

        private void btnAddEnd_Click(object sender, EventArgs e)
        {
            ViewAddFirstOrLast();
            action = 1;
        }

        private void btnAddto_Click(object sender, EventArgs e)
        {
            lblAddHouseAddy.Visible = true;
            lblAddHouseNum.Visible = true;
            txtBoxHNAdd.Visible = true;
            textBAddy.Visible = true;
            lblAddPosition.Visible = true;
            txtAddPos.Visible = true;
            btnSubmit.Location = new Point(598, 147);
            btnSubmit.Visible = true;
            action = 2; 
        }
        private void HideAll()
        {
            lblAddHouseAddy.Visible = false;
            lblAddHouseNum.Visible = false;
            txtBoxHNAdd.Visible = false;
            txtBoxHNAdd.Text = string.Empty;
            textBAddy.Visible = false;
            textBAddy.Text = string.Empty;
            lblAddPosition.Visible = false;
            txtAddPos.Visible = false;
            txtAddPos.Text = string.Empty;
            btnSubmit.Visible = false;
            lblRemovePos.Visible = false;
            txtBSearchORRemove.Visible = false;
            txtBSearchORRemove.Text = string.Empty;
            lblSearch.Visible = false;
            rtbSearch.Visible = false;
            lblHN1.Visible = false;
            lblHN2.Visible = false;
            lblHN3.Visible = false;
            lblHN4.Visible = false;
            lblHN5.Visible = false;
            lblHN6.Visible = false;
            lblHN7.Visible = false;
            housepic1.Visible = false;
            housepic2.Visible = false;
            housepic3.Visible = false;
            housepic4.Visible = false;
            housepic5.Visible = false;
            housepic6.Visible = false;
            housepic7.Visible = false;
            pointer1.Visible = false;
            pointer2.Visible = false;
            pointer3.Visible = false;
            pointer4.Visible = false;
            pointer5.Visible = false;
            pointer6.Visible = false;
            pointer7.Visible = false;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lblRemovePos.Visible = true;
            txtBSearchORRemove.Visible = true;
            btnSubmit.Location = new Point(1381, 155);
            btnSubmit.Visible = true;
            action = 3;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblSearch.Visible = true;
            txtBSearchORRemove.Visible = true;
            btnSubmit.Location = new Point(1381, 155);
            btnSubmit.Visible = true;
            action = 4;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (houses.Length == 7)
            {
                MessageBox.Show("Sorry I can only show you 7 houses here, lets remove some first.");
                HideAll();
                DisplayList();
                pointer7.Visible = true; 
            }
            else
            {
                switch (action)
                {
                    case 0:
                        houseNum = Int32.Parse(txtBoxHNAdd.Text);
                        addy = textBAddy.Text;
                        houses.AddFirst(houseNum, addy);
                        HideAll();
                        DisplayList();
                        break;
                    case 1:
                        houseNum = Int32.Parse(txtBoxHNAdd.Text);
                        addy = textBAddy.Text;
                        houses.AddLast(houseNum, addy);
                        HideAll();
                        DisplayList();
                        break;
                    case 2:
                        houseNum = Int32.Parse(txtBoxHNAdd.Text);
                        addy = textBAddy.Text;
                        pos = Int32.Parse(txtAddPos.Text);
                        houses.AddAt(houseNum, addy, pos);
                        HideAll();
                        DisplayList();
                        break;
                    case 3:
                        pos = Int32.Parse(txtBSearchORRemove.Text);
                        houses.RemoveAt(pos);
                        HideAll();
                        DisplayList();
                        break;
                    case 4:
                        rtbSearch.Visible = true;
                        houseNum = Int32.Parse(txtBSearchORRemove.Text);
                        houses.Search(houseNum, rtbSearch);
                        break;
                }
            }

        }

        private void btnRemoveLast_Click(object sender, EventArgs e)
        {
            HideAll();
            houses.RemoveLast();
            DisplayList();
        }

        private void btnRemoveFront_Click(object sender, EventArgs e)
        {
            HideAll();
            houses.RemoveFirst();
            DisplayList();
        }
    }
}

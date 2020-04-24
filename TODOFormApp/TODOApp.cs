using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TODOFormApp
{
    public partial class TODOApp : Form
    {
        PriorityQueue newList = new PriorityQueue();
        public TODOApp()
        {
            InitializeComponent();
            AddPriorityDDL();
        }


        public void AddPriorityDDL()
        {
            ddlPriority.Items.Add("Urgent");
            ddlPriority.Items.Add("High");
            ddlPriority.Items.Add("Normal");
            ddlPriority.Items.Add("Low");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtNew.Text == "")
            {
                MessageBox.Show("Please enter an item name for your list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ddlPriority.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a priority for your item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string input = txtNew.Text;

                int n = ddlPriority.SelectedIndex;
                string p = ddlPriority.SelectedItem.ToString();
                ToDo itemInput = new ToDo(n, input, p);

                newList.Enqueue(itemInput);

                lblTotal.Text = newList.Count.ToString();
                lblUrgent.Text = newList.CountUrgent.ToString();
                lblHigh.Text = newList.CountHigh.ToString();
                lblNormal.Text = newList.CountNormal.ToString();
                lblLow.Text = newList.CountLow.ToString();

                Clear();
            }

        }

        private void BtnAllList_Click(object sender, EventArgs e)
        {
            string result = "";
            if (newList.Count != 0)
            {
                foreach (ToDo a in newList)
                {
                    result += a.Item + "\n";
                }
                MessageBox.Show(result, "Your To-Do List");
            }
            else
            {
                MessageBox.Show("Your To-Do List is empty. Make a new one?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtNew.Clear();
            txtNew.Focus();
            ddlPriority.SelectedIndex = -1;
        }

        private void BtnViewItem_Click(object sender, EventArgs e)
        {
            try
            {
                lblItem.Text = newList.Peek();
                lblItem.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("You completed your To-Do list. Make a new one?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                newList.Dequeue();
                lblItem.Text = "";
                lblItem.Visible = true;
                lblTotal.Text = newList.Count.ToString();
                lblUrgent.Text = newList.CountUrgent.ToString();
                lblHigh.Text = newList.CountHigh.ToString();
                lblNormal.Text = newList.CountNormal.ToString();
                lblLow.Text = newList.CountLow.ToString();
                MessageBox.Show("To-Do completed!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("You have no To-Do in list. Make a new one?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnClearList_Click(object sender, EventArgs e)
        {
            if (newList.Count == 0)
            {
                MessageBox.Show("You have no To-Do in list. Make a new one?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the entire To-Do list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    newList.Clear();
                    lblTotal.Text = newList.Count.ToString();
                    lblUrgent.Text = newList.CountUrgent.ToString();
                    lblHigh.Text = newList.CountHigh.ToString();
                    lblNormal.Text = newList.CountNormal.ToString();
                    lblLow.Text = newList.CountLow.ToString();
                }
            }


        }
    }
}

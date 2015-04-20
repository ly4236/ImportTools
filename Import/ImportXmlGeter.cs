using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Import
{
    public partial class ImportXmlGeter : Form
    {
        private ListViewItem lvItem;
        public ImportXmlGeter()
        {
            InitializeComponent();

            // Set view of ListView to Details.
            this.myListView1.View = View.Details;

            // Turn on full row select.
            this.myListView1.FullRowSelect = true;

            // Add data to the ListView.
            ColumnHeader columnheader;
            ListViewItem listviewitem;

            // Create sample ListView data.
            listviewitem = new ListViewItem("23232");
            this.myListView1.Items.Add(listviewitem);

            listviewitem = new ListViewItem("数据文件");
        
            listviewitem.SubItems.Add("未知");
            this.myListView1.Items.Add(listviewitem);

            // Create column headers for the data.
            columnheader = new ColumnHeader();
            columnheader.Text = "数据文件";
            this.myListView1.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "数据库";
            this.myListView1.Columns.Add(columnheader);

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.myListView1.Columns)
            {
                ch.Width = -2;
            }

        }

        public class Person
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        private void cbListViewCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            // Set text of ListView item to match the ComboBox.
            lvItem.Text = this.cbxDataFile.Text;

            // Hide the ComboBox.
            this.cbxDataFile.Visible = false;

        }

        private void cbListViewCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set text of ListView item to match the ComboBox.
            lvItem.Text = this.cbxDataFile.Text;

            // Hide the ComboBox.
            this.cbxDataFile.Visible = false;
        }

        private void cbListViewCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the user presses ESC.
            switch (e.KeyChar)
            {
                case (char)(int)Keys.Escape:
                    {
                        // Reset the original text value, and then hide the ComboBox.
                        this.cbxDataFile.Text = lvItem.Text;
                        this.cbxDataFile.Visible = false;
                        break;
                    }

                case (char)(int)Keys.Enter:
                    {
                        // Hide the ComboBox.
                        this.cbxDataFile.Visible = false;
                        break;
                    }
            }

        }

        private void myListView1_MouseUp(object sender, MouseEventArgs e)
        {
            lvItem = this.myListView1.GetItemAt(e.X, e.Y);

            // Make sure that an item is clicked.
            if (lvItem != null)
            {

                // Get the bounds of the item that is clicked.
                Rectangle ClickedItem = lvItem.Bounds;

                //单击ListView第一列显示ComBoBox控件
                if (e.X > this.myListView1.Columns[0].Width)
                {
                    return;
                }
                // Verify that the column is completely scrolled off to the left.
                if ((ClickedItem.Left + this.myListView1.Columns[0].Width) < 0)
                {
                    // If the cell is out of view to the left, do nothing.
                    return;
                }　　　　　　　　 // Verify that the column is partially scrolled off to the left.
                else if (ClickedItem.Left < 0)
                {
                    // Determine if column extends beyond right side of ListView.
                    if ((ClickedItem.Left + this.myListView1.Columns[0].Width) > this.myListView1.Width)
                    {
                        // Set width of column to match width of ListView.
                        ClickedItem.Width = this.myListView1.Width;
                        ClickedItem.X = 0;
                    }
                    else
                    {
                        // Right side of cell is in view.
                        ClickedItem.Width = this.myListView1.Columns[0].Width + ClickedItem.Left;
                        ClickedItem.X = 2;
                    }
                }
                else if (this.myListView1.Columns[0].Width > this.myListView1.Width)
                {
                    ClickedItem.Width = this.myListView1.Width;
                }
                else
                {
                    ClickedItem.Width = this.myListView1.Columns[0].Width;
                    ClickedItem.X = 2;
                }

                // Adjust the top to account for the location of the ListView.
                ClickedItem.Y += this.myListView1.Top;
                ClickedItem.X += this.myListView1.Left;

                // Assign calculated bounds to the ComboBox.
                this.cbxDataFile.Bounds = ClickedItem;

                // Set default text for ComboBox to match the item that is clicked.
                this.cbxDataFile.Text = lvItem.Text;

                // Display the ComboBox, and make sure that it is on top with focus.
                this.cbxDataFile.Visible = true;
                this.cbxDataFile.BringToFront();
                this.cbxDataFile.Focus();


            }
        }

        private void myListView1_Click(object sender, EventArgs e)
        {
            //this.myListView1.Select();
            this.cbxDataFile.Visible = false;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!LoadCheck())
            {
                MessageBox.Show("初始化数据出错");
                return;
            }

            string datafilePath = this.txtPath.Text;
            string tableName = this.txtTableName.Text;


            string[] columnNames = ExcelDataReader.GetColumnName(datafilePath, cbxIsHaveColumnNames.Checked, Convert.ToInt32(this.txtRowNumber.Text));
            cbxDataFile.DataSource = columnNames;
        }

        private bool LoadCheck()
        {
            if (string.IsNullOrEmpty(this.txtTableName.Text.Trim()))
            {
                return false;
            }
            else if (!System.IO.File.Exists(this.txtPath.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtRowNumber.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fileDialog.FileName;

            }
        }

        private void cbxIsHaveColumnNames_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxIsHaveColumnNames.Checked)
            {
                this.lblRow.Visible = true;
                this.lblRowNumber.Visible = true;
                this.txtRowNumber.Visible = true;
            }
            else
            {
                this.lblRow.Visible = false;
                this.lblRowNumber.Visible = false;
                this.txtRowNumber.Visible = false;
            }
        }
    }
}

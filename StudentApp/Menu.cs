﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void entryButton_Click(object sender, EventArgs e)
        {
            studentForm frm = new studentForm();
            frm.Show();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            ViewUI frm = new ViewUI();
            frm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace E4423
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindingList<SomeList> Some = new BindingList<SomeList>();
            Some.Add(new SomeList(12, "Alex", "Some"));
            Some.Add(new SomeList(11, "Bill", "thing"));
            Some.Add(new SomeList(1, "I", "am"));
            Some.AllowNew = true;


            vGridControlDescendant1.AllowNew = true;
            vGridControlDescendant1.DataSource = Some;
            
            gridControl1.DataSource = Some;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
           


        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1: Form
    {
        imagesEntities db = new imagesEntities();
        DataGridViewRow ViewRow;

        public Form1()
        {
            InitializeComponent();
            list();
        }

        void list()
        {
            dataGridView1.DataSource = db.test.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var test = new test();
            var form = new Form2();
            if (form.ShowDialog() == DialogResult.OK) {
                test.Name =  form.textBox1.Text;
                db.test.Add(test);
                db.SaveChanges();
            }
            list();
            //form.textBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ViewRow!=null) {
                var test = ViewRow.DataBoundItem as test;
                var form = new Form2();
                form.textBox1.Text = test.Name;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    test.Name = form.textBox1.Text;
                    db.SaveChanges();
                }
                list();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var test = ViewRow.DataBoundItem as test;
                db.test.Remove(test);
                db.SaveChanges();
                list();
            }
            catch
            {

            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ViewRow = dataGridView1.SelectedRows[0];
            }
        }
    }
}

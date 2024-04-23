using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamResults
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
               
                JointExamResultEntities1 db = new JointExamResultEntities1();
                ExamResult data = new ExamResult();
                data.ApplicationNumber =   Convert.ToInt32(textBox1.Text);

                var result = from sample in db.ExamResults
                             where sample.ApplicationNumber == data.ApplicationNumber
                             select sample;
                if (result == null)
                {
                    MessageBox.Show("Credential not match");
                }
                else{
                    dataGridView1.DataSource = result.ToList();
                }
               
            }
            catch (Exception )
            {
                MessageBox.Show("Credentials not match");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TesterCourseProject
{
    public partial class AddRow : Form
    {
        CreateTest frm = null;
        public AddRow(CreateTest main)
        {
            InitializeComponent();
            frm = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if(textBox1.Text == "")
            {
                ok = false;
                MessageBox.Show("Не задан вопрос", "No Question", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if(textBox2.Text == "")
            {
                ok = false;
                MessageBox.Show("Не задан 1-ый обязательный вариант", "No Variants", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (textBox3.Text == "")
            {
                ok = false;
                MessageBox.Show("Не задан 2-ой обязательный вариант", "No Variants", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if(ok)
            {
                if((checkBox1.Checked==false) && (checkBox2.Checked==false) && (checkBox3.Checked == false) && (checkBox4.Checked == false) && (checkBox5.Checked == false) && (checkBox6.Checked == false))
                {
                    ok = false;
                    MessageBox.Show("Не задан ответ(ы)!", "No Right Answers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if(ok)
            {
                frm.dataGridView1.Rows.Add(textBox1.Text, checkBox1.Checked, textBox2.Text, checkBox2.Checked, textBox3.Text, checkBox3.Checked, textBox4.Text, checkBox4.Checked, textBox5.Text, checkBox5.Checked, textBox6.Text, checkBox6.Checked, textBox7.Text);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                checkBox3.Checked = false;
                textBox5.Enabled = false;
                checkBox4.Checked = false;
                checkBox4.Enabled = false;
            }
            else
            {
                textBox5.Enabled = true;
                checkBox4.Enabled = true;
            }


            if (textBox5.Text == "")
            {
                checkBox4.Checked = false;
                textBox6.Enabled = false;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
            }
            else
            {
                textBox6.Enabled = true;
                checkBox5.Enabled = true;
            }



            if (textBox6.Text == "")
            {
                checkBox5.Checked = false;
                textBox7.Enabled = false;
                checkBox6.Checked = false;
                checkBox6.Enabled = false;
            }
            else
            {
                textBox7.Enabled = true;
                checkBox6.Enabled = true;
            }


            if(textBox7.Text=="")
                checkBox6.Checked = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

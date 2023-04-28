using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TesterCourseProject
{
    public partial class ViewPeople : Form
    {

        bool filter = false;

        public ViewPeople()
        {
            InitializeComponent();
            _update();
        }


        public void _update()
        {
            dataGridView1.Rows.Clear();

            if(!filter)
            {
                SqlConnection conn = new SqlConnection(Conn.Default.connStr);
                conn.Open();
                String sql = "SELECT * FROM People";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString());
                }
                conn.Close();
                conn.Dispose();
            }//заполняем таблицу!
            else
            {
                SqlConnection conn = new SqlConnection(Conn.Default.connStr);
                conn.Open();
                String sql = String.Format("SELECT * FROM People WHERE Cast(Cast([When] As VarChar(11)) As DateTime)>='{0}' and Cast(Cast([When] As VarChar(11)) As DateTime)<='{1}'", dateTimePicker1.Value.Date.ToShortDateString(),dateTimePicker2.Value.Date.ToShortDateString());
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString());
                }
                conn.Close();
                conn.Dispose();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filter = true;
            if(dateTimePicker1.Value>dateTimePicker2.Value)
            {
                DateTime dt = dateTimePicker1.Value;
                dateTimePicker1.Value = dateTimePicker2.Value;
                dateTimePicker2.Value = dt;
            }
            _update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter = false;
            _update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

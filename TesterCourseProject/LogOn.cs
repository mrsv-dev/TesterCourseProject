using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TesterCourseProject
{
    public partial class LogOn : Form
    {
        public int what;

        public LogOn(int what)
        {
            InitializeComponent();
            this.what = what;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool find = false;
            {
                SqlConnection conn = new SqlConnection(Conn.Default.connStr);
                conn.Open();
                String sql = "SELECT * FROM Admins";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if((reader.GetValue(1).ToString()==textBox1.Text) && (reader.GetValue(2).ToString()==textBox2.Text))
                    {
                        find = true;
                        break;
                    }
                }
                conn.Close();
                conn.Dispose();
            }//проверяем на наличие в базе

            if(find)
            {
                if (what == 1)
                {
                    Form frm = new CreateTest();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
 
                }//открываем создание теста
                else
                {
                    Form frm = new ViewPeople();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();

                }//открываем сдавших тест
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void LogOn_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

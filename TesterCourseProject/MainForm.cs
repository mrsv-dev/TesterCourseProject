using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TesterCourseProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            _update();
        }

        private void добавлениеТестаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new LogOn(1);
            frm.ShowDialog();
            _update();
        }



        public void _update()
        {
            int Index = comboBox1.SelectedIndex;
            comboBox1.Items.Clear();
            int amount_tables = 0;
            {
                SqlConnection conn = new SqlConnection(Conn.Default.connStr);
                conn.Open();
                String sql = "SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_TYPE LIKE '%TABLE%'";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                //щщас бы строку удалить)
                while (reader.Read())
                {
                    String table = reader.GetString(0);
                    if ((table != "People") && (table != "Admins"))
                    {
                        comboBox1.Items.Add(table);
                        amount_tables += 1;
                    }
                }
                conn.Close();
                conn.Dispose();
            }//считываем количество таблиц в базе

            int amount_people=0;
            {
                SqlConnection conn = new SqlConnection(Conn.Default.connStr);
                conn.Open();
                String sql = "SELECT * FROM People";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    amount_people += 1;
                }
                conn.Close();
                conn.Dispose();
            }//считываем количество таблиц в базе


            if (comboBox1.Items.Count != 0)
            {
                if (Index == -1)
                    comboBox1.SelectedIndex = 0;
                else
                    comboBox1.SelectedIndex = Index;
                startTest.Enabled = true;
            }
            else
            {
                startTest.Enabled = false;
            }//если у нас есть хоть 1 таблица с тестами то ставим ее в автовыбор и активируем кнопку,
            //если тестов нет кнопка блокируется

            toolStripStatusLabel1.Text = String.Format("В данный момент тесты были сданы:{0} раз", amount_people);
            toolStripStatusLabel2.Text = String.Format("Количество тестов в базе:{0}", amount_tables);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            _update();
        }


        private void startTest_Click(object sender, EventArgs e)
        {
            bool check = true;
            if(nameBox.Text.Length == 0)
            {
                MessageBox.Show("Введите вашу фамилию и инициалы!", "Не введено имя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            if(groupBox.Text.Length == 0)
            {
                MessageBox.Show("Введите вашу группу!", "Не введена группа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }

            if(check)
            {
                Regex reg = new Regex(@"^[А-Я][а-я]+ [А-Я].[А-Я].$"); //проверка фамилии + инициалов
                Match mt = reg.Match(nameBox.Text);
                if(!mt.Success)
                {
                    MessageBox.Show("Фамилия и инициалы введенны в некорректном формате!\nВводить в формате:Фамилия И.И.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                }
                reg = new Regex(@"^\+38[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$");
                mt = reg.Match(groupBox.Text);
                if(!mt.Success)
                {
                    MessageBox.Show("Номер телефона введен в некорректном формате!\nВводить в формате:+380994322735", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                }

                //end checking name and group

                if(check)
                {
                    TestOpened frm = new TestOpened(this, comboBox1.Items[comboBox1.SelectedIndex].ToString(),nameBox.Text,groupBox.Text);
                    frm.ShowDialog();
                    nameBox.Text = "";
                    groupBox.Text = "";
                }

            }// end if check
        }

        private void просмотрСдавшихТестыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new LogOn(2);
            frm.ShowDialog();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програмный продукт предназначен для сдачи тестирования новыми сотрудниками банка \n Для помощи обращайтесь по телефону +380994322735", "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Круглый С.И.", "Разработчик", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void программаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TesterCourseProject
{
    public partial class CreateTest : Form
    {

        public class Questions
        {
            public String Question;

            public bool True1;
            public String Var1;

            public bool True2;
            public String Var2;

            public bool True3;
            public String Var3;

            public bool True4;
            public String Var4;

            public bool True5;
            public String Var5;

            public bool True6;
            public String Var6;
        }

        public List<Questions> All = new List<Questions>();


        public CreateTest()
        {
            InitializeComponent();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                MessageBox.Show("Нельзя задать пустое имя теста!", "Ошибка в названии",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if(dataGridView1.Rows.Count!=0)
                {
                    SqlConnection conn = new SqlConnection(Conn.Default.connStr);

                    conn.Open();
                    SqlCommand cmdCreateTable = new SqlCommand(String.Format("CREATE TABLE [{0}] (Question NVARCHAR (MAX) NOT NULL, True1 BIT NOT NULL, Var1 NVARCHAR (MAX) NOT NULL, True2 BIT NOT NULL, Var2 NVARCHAR (MAX) NOT NULL, True3 BIT NULL, Var3 NVARCHAR (MAX) NULL, True4 BIT NULL, Var4 NVARCHAR (MAX) NULL, True5 BIT NULL, Var5 NVARCHAR (MAX) NULL, True6 BIT NULL, Var6 NVARCHAR (MAX) NULL);", textBox1.Text),conn);
                    //посылаем запрос

                    bool ok = true;
                    try
                    {
                        cmdCreateTable.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка при создании таблицы: " + ex.Message);
                        ok = false;
                    }
                    if(ok)
                    {
                        InsertingQuestions(conn);
                    }//if ok
                    conn.Close();
                    conn.Dispose();
                }//end if have rows
                else
                {
                    MessageBox.Show("Нельзя создать тест без вопросов!", "No Questions in test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }//end button click


        public void InsertingQuestions(SqlConnection conn)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Questions quest = new Questions();
                quest.Question = dataGridView1.Rows[i].Cells[0].Value.ToString();
                //all variants down
                try
                {
                    quest.Var1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                }
                catch
                {
                    quest.Var1 = null;
                }


                //
                try
                {
                    quest.Var2 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                }
                catch
                {
                    quest.Var2 = null;
                }


                //
                try
                {
                    quest.Var3 = dataGridView1.Rows[i].Cells[6].Value.ToString();
                }
                catch
                {
                    quest.Var3 = null;
                }


                //
                try
                {
                    quest.Var4 = dataGridView1.Rows[i].Cells[8].Value.ToString();
                }
                catch
                {
                    quest.Var4 = null;
                }


                //
                try
                {
                    quest.Var5 = dataGridView1.Rows[i].Cells[10].Value.ToString();
                }
                catch
                {
                    quest.Var5 = null;
                }


                //
                try
                {
                    quest.Var6 = dataGridView1.Rows[i].Cells[12].Value.ToString();
                }
                catch
                {
                    quest.Var6 = null;
                }


                //all bool down
                //1
                try
                {
                    quest.True1 = (Boolean)dataGridView1.Rows[i].Cells[1].Value;
                }
                catch
                {
                    quest.True1 = false;
                }


                //2
                try
                {
                    quest.True2 = (Boolean)dataGridView1.Rows[i].Cells[3].Value;
                }
                catch
                {
                    quest.True2 = false;
                }


                //3
                try
                {
                    quest.True3 = (Boolean)dataGridView1.Rows[i].Cells[5].Value;
                }
                catch
                {
                    quest.True3 = false;
                }


                //4
                try
                {
                    quest.True4 = (Boolean)dataGridView1.Rows[i].Cells[7].Value;
                }
                catch
                {
                    quest.True4 = false;
                }


                //5
                try
                {
                    quest.True5 = (Boolean)dataGridView1.Rows[i].Cells[9].Value;
                }
                catch
                {
                    quest.True5 = false;
                }


                //6
                try
                {
                    quest.True6 = (Boolean)dataGridView1.Rows[i].Cells[11].Value;
                }
                catch
                {
                    quest.True6 = false;
                }

                All.Add(quest);
            }//end adding all questions

            foreach (Questions quest in All)
            {
                SqlCommand cmdInsert = new SqlCommand(String.Format("INSERT INTO [{0}](Question, True1, Var1, True2, Var2, True3, Var3, True4, Var4, True5, Var5, True6, Var6) VALUES ('{1}', {2}, '{3}', {4}, '{5}', {6}, '{7}', {8}, '{9}', {10}, '{11}', {12}, '{13}');", textBox1.Text, quest.Question, Convert.ToInt32(quest.True1), quest.Var1, Convert.ToInt32(quest.True2), quest.Var2, Convert.ToInt32(quest.True3), quest.Var3, Convert.ToInt32(quest.True4), quest.Var4, Convert.ToInt32(quest.True5), quest.Var5, Convert.ToInt32(quest.True6), quest.Var6), conn);

                try
                {
                    cmdInsert.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Oшибка, при выполнении запроса на добавление записи:" + ex.Message);
                }
            }

            MessageBox.Show("Успешно выполнено!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            conn.Dispose();
            this.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            AddRow frm = new AddRow(this);
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}

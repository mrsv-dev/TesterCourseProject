using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TesterCourseProject
{
    public partial class TestOpened : Form
    {
        MainForm frm = null;
        String testName = null;

        public int right_count = 0;
        public int all_count = 0;


        public String name;
        public String group;


        public class Questions
        {
            public String Question;

            public bool True1;
            public String Var1 = null;

            public bool True2;
            public String Var2 = null;

            public bool True3;
            public String Var3 = null;

            public bool True4;
            public String Var4 = null;

            public bool True5;
            public String Var5 = null;

            public bool True6;
            public String Var6 = null;
        }

        public List<Questions> All = new List<Questions>();

        public TestOpened(MainForm main, String TestName, String name, String group)
        {
            InitializeComponent();
            frm = main;
            testName = TestName;
            this.name = name;
            this.group = group;
            InitializeTest();
        }


        public void InitializeTest()
        {
            SqlConnection conn = new SqlConnection(Conn.Default.connStr);
            try
            {
                //пробуем подключится
                conn.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Ошибка подключения:{0}", se.Message);
            }

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM [{0}]",testName), conn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Questions quest = new Questions();
                quest.Question = dr.GetValue(0).ToString();
                

                quest.True1 = Convert.ToBoolean(dr.GetValue(1));
                quest.Var1 = dr.GetValue(2).ToString();

                quest.True2 = Convert.ToBoolean(dr.GetValue(3));
                quest.Var2 = dr.GetValue(4).ToString();

                quest.True3 = Convert.ToBoolean(dr.GetValue(5));
                quest.Var3 = dr.GetValue(6).ToString();

                quest.True4 = Convert.ToBoolean(dr.GetValue(7));
                quest.Var4 = dr.GetValue(8).ToString();

                quest.True5 = Convert.ToBoolean(dr.GetValue(9));
                quest.Var5 = dr.GetValue(10).ToString();

                quest.True6 = Convert.ToBoolean(dr.GetValue(11));
                quest.Var6 = dr.GetValue(12).ToString();
                All.Add(quest);
            }
            conn.Close();
            conn.Dispose();

            //start creating test
            {
                for(int i=0;i<All.Count;i++)
                {
                    
                        TabPage tp = new TabPage();
                        tabControl1.TabPages.Add(tp);
                        Label question = new Label();

                    question.AutoSize = true;
                    question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    question.MinimumSize = new System.Drawing.Size(tabControl1.Width - 20, 10);
                    question.MaximumSize = new System.Drawing.Size(tabControl1.Width - 20, 200);




                    question.Text = All[i].Question;
                    tabControl1.TabPages[i].Controls.Add(question);

                        bool stop = false;
                        int trueCount = 0;




                        if ((All[i].Var3 != "") && (All[i].Var4 != "") && (All[i].Var5 != "") && (All[i].Var6 != ""))
                        {


                            stop = true;
                            if (All[i].True1 == true)
                                trueCount += 1;
                            if (All[i].True2 == true)
                                trueCount += 1;
                            if (All[i].True3 == true)
                                trueCount += 1;
                            if (All[i].True4 == true)
                                trueCount += 1;
                            if (All[i].True5 == true)
                                trueCount += 1;
                            if (All[i].True6 == true)
                                trueCount += 1;

                            if(trueCount == 1)
                            {
                                RadioButton rd1 = new RadioButton();
                                RadioButton rd2 = new RadioButton();
                                RadioButton rd3 = new RadioButton();
                                RadioButton rd4 = new RadioButton();
                                RadioButton rd5 = new RadioButton();
                                RadioButton rd6 = new RadioButton();

                                rd1.Text = All[i].Var1;
                                rd2.Text = All[i].Var2;
                                rd3.Text = All[i].Var3;
                                rd4.Text = All[i].Var4;
                                rd5.Text = All[i].Var5;
                                rd6.Text = All[i].Var6;


                            rd1.AutoSize = true;
                            rd2.AutoSize = true;
                            rd3.AutoSize = true;
                            rd4.AutoSize = true;
                            rd5.AutoSize = true;
                            rd6.AutoSize = true;

                            rd1.Top = question.Height+10;
                                rd2.Top = question.Height + rd1.Height + 20;
                                rd3.Top = question.Height + rd1.Height + rd2.Height + 30;
                                rd4.Top = question.Height + rd1.Height + rd2.Height + rd3.Height + 40;
                                rd5.Top = question.Height + rd1.Height + rd2.Height + rd3.Height + rd4.Height + 50;
                                rd6.Top = question.Height + rd1.Height + rd2.Height + rd3.Height + rd4.Height + rd5.Height + 60;



                                tabControl1.TabPages[i].Controls.Add(rd1);
                                tabControl1.TabPages[i].Controls.Add(rd2);
                                tabControl1.TabPages[i].Controls.Add(rd3);
                                tabControl1.TabPages[i].Controls.Add(rd4);
                                tabControl1.TabPages[i].Controls.Add(rd5);
                                tabControl1.TabPages[i].Controls.Add(rd6);
                            }

                            else
                            {

                                CheckBox cb1 = new CheckBox();
                                CheckBox cb2 = new CheckBox();
                                CheckBox cb3 = new CheckBox();
                                CheckBox cb4 = new CheckBox();
                                CheckBox cb5 = new CheckBox();
                                CheckBox cb6 = new CheckBox();


                                cb1.Text = All[i].Var1;
                                cb2.Text = All[i].Var2;
                                cb3.Text = All[i].Var3;
                                cb4.Text = All[i].Var4;
                                cb5.Text = All[i].Var5;
                                cb6.Text = All[i].Var6;

                            cb1.AutoSize = true;
                            cb2.AutoSize = true;
                            cb3.AutoSize = true;
                            cb4.AutoSize = true;
                            cb5.AutoSize = true;
                            cb6.AutoSize = true;

                            cb1.Top = question.Height + 10;
                                cb2.Top = question.Height + cb1.Height + 20;
                                cb3.Top = question.Height + cb1.Height + cb2.Height + 30;
                                cb4.Top = question.Height + cb1.Height + cb2.Height + cb3.Height + 40;
                                cb5.Top = question.Height + cb1.Height + cb2.Height + cb3.Height + cb4.Height + 50;
                                cb6.Top = question.Height + cb1.Height + cb2.Height + cb3.Height + cb4.Height + cb5.Height + 60;

                                tabControl1.TabPages[i].Controls.Add(cb1);
                                tabControl1.TabPages[i].Controls.Add(cb2);
                                tabControl1.TabPages[i].Controls.Add(cb3);
                                tabControl1.TabPages[i].Controls.Add(cb4);
                                tabControl1.TabPages[i].Controls.Add(cb5);
                                tabControl1.TabPages[i].Controls.Add(cb6);

                            }


                        }//end if all question have


                        if ((All[i].Var3 != "") && (All[i].Var4 != "") && (All[i].Var5 != "") && (!stop))
                        {



                            stop = true;
                            if (All[i].True1 == true)
                                trueCount += 1;
                            if (All[i].True2 == true)
                                trueCount += 1;
                            if (All[i].True3 == true)
                                trueCount += 1;
                            if (All[i].True4 == true)
                                trueCount += 1;
                            if (All[i].True5 == true)
                                trueCount += 1;


                            if (trueCount == 1)
                            {
                                RadioButton rd1 = new RadioButton();
                                RadioButton rd2 = new RadioButton();
                                RadioButton rd3 = new RadioButton();
                                RadioButton rd4 = new RadioButton();
                                RadioButton rd5 = new RadioButton();

                                rd1.Text = All[i].Var1;
                                rd2.Text = All[i].Var2;
                                rd3.Text = All[i].Var3;
                                rd4.Text = All[i].Var4;
                                rd5.Text = All[i].Var5;


                            rd1.AutoSize = true;
                            rd2.AutoSize = true;
                            rd3.AutoSize = true;
                            rd4.AutoSize = true;
                            rd5.AutoSize = true;


                            rd1.Top = question.Height + 10;
                                rd2.Top = question.Height + rd1.Height + 20;
                                rd3.Top = question.Height + rd1.Height + rd2.Height + 30;
                                rd4.Top = question.Height + rd1.Height + rd2.Height + rd3.Height + 40;
                                rd5.Top = question.Height + rd1.Height + rd2.Height + rd3.Height + rd4.Height + 50;



                                tabControl1.TabPages[i].Controls.Add(rd1);
                                tabControl1.TabPages[i].Controls.Add(rd2);
                                tabControl1.TabPages[i].Controls.Add(rd3);
                                tabControl1.TabPages[i].Controls.Add(rd4);
                                tabControl1.TabPages[i].Controls.Add(rd5);
                            }

                            else
                            {

                                CheckBox cb1 = new CheckBox();
                                CheckBox cb2 = new CheckBox();
                                CheckBox cb3 = new CheckBox();
                                CheckBox cb4 = new CheckBox();
                                CheckBox cb5 = new CheckBox();


                                cb1.Text = All[i].Var1;
                                cb2.Text = All[i].Var2;
                                cb3.Text = All[i].Var3;
                                cb4.Text = All[i].Var4;
                                cb5.Text = All[i].Var5;


                            cb1.AutoSize = true;
                            cb2.AutoSize = true;
                            cb3.AutoSize = true;
                            cb4.AutoSize = true;
                            cb5.AutoSize = true;



                            cb1.Top = question.Height + 10;
                                cb2.Top = question.Height + cb1.Height + 20;
                                cb3.Top = question.Height + cb1.Height + cb2.Height + 30;
                                cb4.Top = question.Height + cb1.Height + cb2.Height + cb3.Height + 40;
                                cb5.Top = question.Height + cb1.Height + cb2.Height + cb3.Height + cb4.Height + 50;




                                tabControl1.TabPages[i].Controls.Add(cb1);
                                tabControl1.TabPages[i].Controls.Add(cb2);
                                tabControl1.TabPages[i].Controls.Add(cb3);
                                tabControl1.TabPages[i].Controls.Add(cb4);
                                tabControl1.TabPages[i].Controls.Add(cb5);

                            }


                        }//end if 5 questions




                        if ((All[i].Var3 != "") && (All[i].Var4 != "") && (!stop))
                        {
                            stop = true;
                            if (All[i].True1 == true)
                                trueCount += 1;
                            if (All[i].True2 == true)
                                trueCount += 1;
                            if (All[i].True3 == true)
                                trueCount += 1;
                            if (All[i].True4 == true)
                                trueCount += 1;


                            if (trueCount == 1)
                            {
                                RadioButton rd1 = new RadioButton();
                                RadioButton rd2 = new RadioButton();
                                RadioButton rd3 = new RadioButton();
                                RadioButton rd4 = new RadioButton();

                                rd1.Text = All[i].Var1;
                                rd2.Text = All[i].Var2;
                                rd3.Text = All[i].Var3;
                                rd4.Text = All[i].Var4;

                            rd1.AutoSize = true;
                            rd2.AutoSize = true;
                            rd3.AutoSize = true;
                            rd4.AutoSize = true;



                            rd1.Top = question.Height + 10;
                                rd2.Top = question.Height + rd1.Height + 20;
                                rd3.Top = question.Height + rd1.Height + rd2.Height + 30;
                                rd4.Top = question.Height + rd1.Height + rd2.Height + rd3.Height + 40;


                                tabControl1.TabPages[i].Controls.Add(rd1);
                                tabControl1.TabPages[i].Controls.Add(rd2);
                                tabControl1.TabPages[i].Controls.Add(rd3);
                                tabControl1.TabPages[i].Controls.Add(rd4);
                            }

                            else
                            {

                                CheckBox cb1 = new CheckBox();
                                CheckBox cb2 = new CheckBox();
                                CheckBox cb3 = new CheckBox();
                                CheckBox cb4 = new CheckBox();


                                cb1.Text = All[i].Var1;
                                cb2.Text = All[i].Var2;
                                cb3.Text = All[i].Var3;
                                cb4.Text = All[i].Var4;

                            cb1.AutoSize = true;
                            cb2.AutoSize = true;
                            cb3.AutoSize = true;
                            cb4.AutoSize = true;


                            cb1.Top = question.Height + 10;
                                cb2.Top = question.Height + cb1.Height + 20;
                                cb3.Top = question.Height + cb1.Height + cb2.Height + 30;
                                cb4.Top = question.Height + cb1.Height + cb2.Height + cb3.Height + 40;


                                tabControl1.TabPages[i].Controls.Add(cb1);
                                tabControl1.TabPages[i].Controls.Add(cb2);
                                tabControl1.TabPages[i].Controls.Add(cb3);
                                tabControl1.TabPages[i].Controls.Add(cb4);

                            }


                        }//end if 4 questions



                        if ((All[i].Var3 != "") && (!stop))
                        {
                            stop = true;
                            if (All[i].True1 == true)
                                trueCount += 1;
                            if (All[i].True2 == true)
                                trueCount += 1;
                            if (All[i].True3 == true)
                                trueCount += 1;


                            if (trueCount == 1)
                            {
                                RadioButton rd1 = new RadioButton();
                                RadioButton rd2 = new RadioButton();
                                RadioButton rd3 = new RadioButton();

                                rd1.Text = All[i].Var1;
                                rd2.Text = All[i].Var2;
                                rd3.Text = All[i].Var3;

                            rd1.AutoSize = true;
                            rd2.AutoSize = true;
                            rd3.AutoSize = true;


                            rd1.Top = question.Height + 10;
                                rd2.Top = question.Height + rd1.Height + 20;
                                rd3.Top = question.Height + rd1.Height + rd2.Height + 30;


                                tabControl1.TabPages[i].Controls.Add(rd1);
                                tabControl1.TabPages[i].Controls.Add(rd2);
                                tabControl1.TabPages[i].Controls.Add(rd3);
                            }

                            else
                            {

                                CheckBox cb1 = new CheckBox();
                                CheckBox cb2 = new CheckBox();
                                CheckBox cb3 = new CheckBox();


                                cb1.Text = All[i].Var1;
                                cb2.Text = All[i].Var2;
                                cb3.Text = All[i].Var3;

                            cb1.AutoSize = true;
                            cb2.AutoSize = true;
                            cb3.AutoSize = true;


                            cb1.Top = question.Height + 10;
                                cb2.Top = question.Height + cb1.Height + 20;
                                cb3.Top = question.Height + cb1.Height + cb2.Height + 30;


                                tabControl1.TabPages[i].Controls.Add(cb1);
                                tabControl1.TabPages[i].Controls.Add(cb2);
                                tabControl1.TabPages[i].Controls.Add(cb3);

                            }


                        }//end if 3 questions


                        if (!stop)
                        {
                            stop = true;
                            if (All[i].True1 == true)
                                trueCount += 1;
                            if (All[i].True2 == true)
                                trueCount += 1;


                            if (trueCount == 1)
                            {
                                RadioButton rd1 = new RadioButton();
                                RadioButton rd2 = new RadioButton();

                                rd1.Text = All[i].Var1;
                                rd2.Text = All[i].Var2;

                            rd1.AutoSize = true;
                            rd2.AutoSize = true;



                            rd1.Top = question.Height + 10;
                                rd2.Top = question.Height + rd1.Height + 20;


                                tabControl1.TabPages[i].Controls.Add(rd1);
                                tabControl1.TabPages[i].Controls.Add(rd2);
                            }

                            else
                            {

                                CheckBox cb1 = new CheckBox();
                                CheckBox cb2 = new CheckBox();




                                cb1.Text = All[i].Var1;
                                cb2.Text = All[i].Var2;

                            cb1.AutoSize = true;
                            cb2.AutoSize = true;



                            cb1.Top = question.Height + 10;
                                cb2.Top = question.Height + cb1.Height + 20;


                                tabControl1.TabPages[i].Controls.Add(cb1);
                                tabControl1.TabPages[i].Controls.Add(cb2);

                            }


                        }//end if 2 questions





                    Button bt = new Button();
                    bt.Dock = DockStyle.Bottom;
                    bt.Height = 80;

                    if (i != All.Count - 1)//start if not last question
                    {

                        bt.Text = "Следующий вопрос";

                        bt.Click += new EventHandler(this.NextPage_Click);
                    }//end if not last question
                    else
                    {
                        bt.Text = "Закончить тест";
                        bt.Click += new EventHandler(this.LastPage_Click);
                    }
                    tabControl1.TabPages[i].Controls.Add(bt);
                }
            }
            //end creating test

        }//end Initialize



        public void _checkAnswer()
        {
            int helper = 0;

            if (All[tabControl1.SelectedIndex].True1)
                helper += 1;

            if (All[tabControl1.SelectedIndex].True2)
                helper += 1;

            if ((All[tabControl1.SelectedIndex].True3) && (All[tabControl1.SelectedIndex].Var3 != ""))
                helper += 1;

            if ((All[tabControl1.SelectedIndex].True4) && (All[tabControl1.SelectedIndex].Var4 != ""))
                helper += 1;

            if ((All[tabControl1.SelectedIndex].True5) && (All[tabControl1.SelectedIndex].Var5 != ""))
                helper += 1;

            if ((All[tabControl1.SelectedIndex].True6) && (All[tabControl1.SelectedIndex].Var6 != ""))
                helper += 1;






            if (helper == 1)
            {
                if (All[tabControl1.SelectedIndex].True1)
                {
                    if (((RadioButton)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[1]).Checked)
                    {
                        right_count += 1;
                    }
                }


                if (All[tabControl1.SelectedIndex].True2)
                {
                    if (((RadioButton)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[2]).Checked)
                    {
                        right_count += 1;
                    }
                }

                if ((All[tabControl1.SelectedIndex].True3) && (All[tabControl1.SelectedIndex].Var3!=""))
                {
                    if (((RadioButton)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[3]).Checked)
                    {
                        right_count += 1;
                    }
                }

                if ((All[tabControl1.SelectedIndex].True4)&& (All[tabControl1.SelectedIndex].Var4 != ""))
                {
                    if (((RadioButton)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[4]).Checked)
                    {
                        right_count += 1;
                    }
                }

                if ((All[tabControl1.SelectedIndex].True5)&& (All[tabControl1.SelectedIndex].Var5 != ""))
                {
                    if (((RadioButton)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[5]).Checked)
                    {
                        right_count += 1;
                    }
                }

                if ((All[tabControl1.SelectedIndex].True6)&& (All[tabControl1.SelectedIndex].Var6 != ""))
                {
                    if (((RadioButton)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[6]).Checked)
                    {
                        right_count += 1;
                    }
                }

            }
            else
            {
                int help2 = 0;



                if (All[tabControl1.SelectedIndex].True1)
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[1]).Checked)
                    {
                        help2 += 1;
                    }
                }


                if (!All[tabControl1.SelectedIndex].True1)
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[1]).Checked)
                    {
                        help2 -= 1;
                    }
                }


                if (All[tabControl1.SelectedIndex].True2)
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[2]).Checked)
                    {
                        help2 += 1;
                    }
                }


                if (!All[tabControl1.SelectedIndex].True2)
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[2]).Checked)
                    {
                        help2 -= 1;
                    }
                }



                if ((All[tabControl1.SelectedIndex].True3)&& (All[tabControl1.SelectedIndex].Var3 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[3]).Checked)
                    {
                        help2 += 1;
                    }
                }



                if ((!All[tabControl1.SelectedIndex].True3)&& (All[tabControl1.SelectedIndex].Var3 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[3]).Checked)
                    {
                        help2 -= 1;
                    }
                }


                if ((All[tabControl1.SelectedIndex].True4)&& (All[tabControl1.SelectedIndex].Var4 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[4]).Checked)
                    {
                        help2 += 1;
                    }
                }



                if ((!All[tabControl1.SelectedIndex].True4)&& (All[tabControl1.SelectedIndex].Var4 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[4]).Checked)
                    {
                        help2 -= 1;
                    }
                }


                if ((All[tabControl1.SelectedIndex].True5)&& (All[tabControl1.SelectedIndex].Var5 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[5]).Checked)
                    {
                        help2 += 1;
                    }
                }


                if ((!All[tabControl1.SelectedIndex].True5)&& (All[tabControl1.SelectedIndex].Var5 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[5]).Checked)
                    {
                        help2 -= 1;
                    }
                }



                if ((All[tabControl1.SelectedIndex].True6)&& (All[tabControl1.SelectedIndex].Var6 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[6]).Checked)
                    {
                        help2 += 1;
                    }
                }



                if ((!All[tabControl1.SelectedIndex].True6)&& (All[tabControl1.SelectedIndex].Var6 != ""))
                {
                    if (((CheckBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[6]).Checked)
                    {
                        help2 -= 1;
                    }
                }



                if (help2 == helper)
                    right_count += 1;



            }
        }




        private void NextPage_Click(object sender, EventArgs e)
        {
            all_count += 1;
            _checkAnswer();
            tabControl1.SelectTab(tabControl1.SelectedIndex+1);
        }


        private void LastPage_Click(object sender, EventArgs e)
        {
            all_count += 1;
            _checkAnswer();


            SqlConnection conn = new SqlConnection(Conn.Default.connStr);
            try
            {
                //пробуем подключится
                conn.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Ошибка подключения:{0}", se.Message);
            }
            int mark = 0;
            DateTime dt = DateTime.Now;
            if (((Double)right_count * 100 / all_count) > 90)
            {
                mark = 5;
            }
            else if (((Double)right_count * 100 / all_count) > 74)
            {
                mark = 4;
            }
            else if (((Double)right_count * 100 / all_count) > 60)
            {
                mark = 3;
            }
            else
                mark = 2;


            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO People VALUES ('{0}', '{1}', '{2}', '{3} из {4}', {5}, '{6}');", name , group, testName, right_count, all_count, mark, dt)
                , conn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Ошибка добавления записи:"+ex.Message);
            }
            String done;
            if (mark == 2)
                done = "К сожалению, по результатам теста Вы нам не подходите, попробуйте пройти тестирование позже";
            else
                done = "Поздравляем, Вы успешно прошли тестирование, приходите на стажировку.";
            
            //ок
            MessageBox.Show(String.Format("{0} вы ответили правильно на:\n{1} из {2} вопросов\nВаша оценка:{3}\n{4}", name, right_count, all_count, mark, done), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            conn.Dispose();
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}

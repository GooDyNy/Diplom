using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prof
{
    public partial class Testirovanie : Form
    {
        int id = 0;
        public Testirovanie()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            button2.Visible = false;
            Load();
            Style();
        }

        /// <summary>
        /// ЗагрузкаПервого вопроса
        /// </summary>
        public int balls = 0;
        public string table;
        public void Load()
        {
            id++;
           int table = BD.Prof;
            SqlConnection connection2 = new SqlConnection(BD.connStr);
            connection2.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($@"SELECT [Test].IdVopr, [Vopros], [Otvet1], [Otvet2], [Otvet3],  [IdVopr]={id} FROM [Test] WHERE IdProf = {table}", connection2);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            BD.IdVopr = ds.Tables[0].Rows[0].Field<int>(ds.Tables[0].Columns[0]);
            BD.Vopros = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[1]);
            BD.Otvet1 = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[2]);
            BD.Otvet2 = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[3]);
            BD.Otvet3 = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[4]);
            label2.Text = BD.Vopros;
            radioButton1.Text = BD.Otvet1;
            radioButton2.Text = BD.Otvet2;
            radioButton3.Text = BD.Otvet3;
            label1.Text = Convert.ToString($"{id}/15");
            if (radioButton1.Checked)
                balls = balls + 10;
            if (radioButton2.Checked)
                balls = balls - 2;
            if (radioButton3.Checked)
                balls = balls - 10;
            BD.balls = 100 * balls / 150;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Menu avtorization = new Menu();
            avtorization.Show();
            Hide();
        }
        


      /// <summary>
      /// Кнопка для переключения вопроса
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            id++;
            SqlConnection connection2 = new SqlConnection(BD.connStr);

            try
            {
                if (id <= 15)
                {
                    int table = BD.Prof;
                    connection2.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter($@"SELECT [Test].IdVopr, [Vopros], [Otvet1], [Otvet2], [Otvet3], IdProf = {table} FROM [Test] WHERE [IdVopr]={id}", connection2);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    BD.IdVopr = ds.Tables[0].Rows[0].Field<int>(ds.Tables[0].Columns[0]);
                    BD.Vopros = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[1]);
                    BD.Otvet1 = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[2]);
                    BD.Otvet2 = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[3]);
                    BD.Otvet3 = ds.Tables[0].Rows[0].Field<string>(ds.Tables[0].Columns[4]);
                    label2.Text = BD.Vopros;
                    radioButton1.Text = BD.Otvet1;
                    radioButton2.Text = BD.Otvet2;
                    radioButton3.Text = BD.Otvet3;
                    label1.Text = Convert.ToString($"{id}/15");

                    if (radioButton1.Checked)
                        balls = balls + 10;
                    if (radioButton2.Checked)
                        balls = balls - 2;
                    if (radioButton3.Checked)
                        balls = balls - 10;
                    BD.balls = 100 * balls / 150;

                }
                else
                {
                    if (BD.balls <= 0)
                    {
                        connection2.Open();
                        SqlCommand cmd = new SqlCommand($"INSERT INTO Rezulitati (IdStudenta, Rezulitati, Kolichestvo_ballov) VALUES ('{BD.ID}', '{BD.Prof2}', '0' )", connection2);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($@"Ваш результат: 0%!");
                        Menu menu = new Menu();
                        menu.Show();
                        Hide();
                    }
                    else
                    {
                        connection2.Open();
                        SqlCommand cmd = new SqlCommand($"INSERT INTO Rezulitati (IdStudenta, Rezulitati, Kolichestvo_ballov) VALUES ('{BD.ID}', '{BD.Prof2}', '{BD.balls}' )", connection2);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($@"Ваш результат: {BD.balls}%!");
                        Menu menu = new Menu();
                        menu.Show();
                        Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection2.Close();
            }
        }

        /// <summary>
        /// Изменение видимости элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            button3.Visible = false;
            button2.Visible = true;
        }
        private void Testirovanie_Load(object sender, EventArgs e)
        {

        }

        public void Style()
        {
            if (BD.style == 5)
            {
                this.BackColor = Color.Moccasin;
                button3.BackColor = Color.CadetBlue;
            }
            
        }
    }
}

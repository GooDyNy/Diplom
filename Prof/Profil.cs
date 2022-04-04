using Microsoft.Toolkit;
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
    public partial class Profil : Form
    {
        public Profil()
        {
            InitializeComponent();
            Load();
            Diagramma();
            LoadD();
        }
        
        /// <summary>
        /// Загрузка данных
        /// </summary>
        public  void LoadD()
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter2 = new SqlDataAdapter($"SELECT  Studenti.IdStudenta as 'Номер студента', [Familia] as 'Фамилия', [Imia] as 'Имя', [Otchestvo] as " +
                 $"'Отчество', [NomerGrupi] as 'Номер группы', [Pochta] as 'Email', [Login] as 'Логин', [Parol] as 'Пароль' FROM Studenti WHERE IdStudenta = {BD.ID} ", connection);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);

            label7.Text = ds2.Tables[0].Rows[0].Field<string>(ds2.Tables[0].Columns[1]);
            label8.Text = ds2.Tables[0].Rows[0].Field<string>(ds2.Tables[0].Columns[2]);
            label9.Text = ds2.Tables[0].Rows[0].Field<string>(ds2.Tables[0].Columns[3]);
            label10.Text = ds2.Tables[0].Rows[0].Field<String>(ds2.Tables[0].Columns[4]);
            label11.Text = ds2.Tables[0].Rows[0].Field<String>(ds2.Tables[0].Columns[5]);

            

            BD.Familia = label7.Text;
            BD.Imia = label8.Text;
            BD.Otchestvo = label9.Text;
            BD.Gruppa = label10.Text;
            BD.Pochta = label11.Text;

        }


        public void Load()
        {
            
            SqlConnection Connect = new SqlConnection(BD.connStr);
            listBox1.Items.Clear();
            Connect.Open();
            System.Text.StringBuilder results = new System.Text.StringBuilder();
            SqlCommand SC = new SqlCommand();
            SC.Connection = Connect;
            SC.CommandType = CommandType.Text;
            SC.CommandText = $"SELECT [Rezulitati].IdRezult, [Rezulitati], [Kolichestvo_ballov] FROM [Rezulitati] WHERE IdStudenta = {BD.ID}";
            SqlDataReader SDR = SC.ExecuteReader();
            bool MoreResults = false;
            do
            {
                while (SDR.Read())
                {
                    for (int i = 0; i < SDR.FieldCount; i = i + 3)
                        listBox1.Items.Add(SDR[i + 1] + ""+" - " + SDR[i + 2] + ""+"%" ).ToString();
                }
                MoreResults = SDR.NextResult();
            } while (MoreResults);
            SDR.Close();

            //label7.Text = BD.Familia;
            //label8.Text = BD.Imia;
            //label9.Text = BD.Otchestvo;
            //label10.Text = BD.Gruppa;
            //label11.Text = BD.Pochta;

        }
       
        /// <summary>
        /// Сортировка результатов по специальностям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                SqlConnection Connect = new SqlConnection(BD.connStr);
                listBox1.Items.Clear();
                Connect.Open();
                System.Text.StringBuilder results = new System.Text.StringBuilder();
                SqlCommand SC = new SqlCommand();
                SC.Connection = Connect;
                SC.CommandType = CommandType.Text;
                SC.CommandText = $"SELECT [Rezulitati].IdRezult, [Rezulitati], [Kolichestvo_ballov] FROM Rezulitati WHERE IdStudenta = {BD.ID} AND Rezulitati= 'Программист'";
                SqlDataReader SDR = SC.ExecuteReader();
                bool MoreResults = false;
                do
                {
                    while (SDR.Read())
                    {
                        for (int i = 0; i < SDR.FieldCount; i = i + 4)
                            listBox1.Items.Add(SDR[i + 1] + "" + " - " + SDR[i + 2] + "" + "%").ToString();
                    }
                    MoreResults = SDR.NextResult();
                } while (MoreResults);
                SDR.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;

            Load();
        }

        /// <summary>
        /// Сортировка результатов по специальностям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                SqlConnection Connect = new SqlConnection(BD.connStr);
                listBox1.Items.Clear();
                Connect.Open();
                System.Text.StringBuilder results = new System.Text.StringBuilder();
                SqlCommand SC = new SqlCommand();
                SC.Connection = Connect;
                SC.CommandType = CommandType.Text;
                SC.CommandText = $"SELECT [Rezulitati].IdRezult, [Rezulitati], [Kolichestvo_ballov] FROM Rezulitati WHERE IdStudenta = {BD.ID} AND Rezulitati= 'Тестировщик'";
                SqlDataReader SDR = SC.ExecuteReader();
                bool MoreResults = false;
                do
                {
                    while (SDR.Read())
                    {
                        for (int i = 0; i < SDR.FieldCount; i = i + 4)
                            listBox1.Items.Add(SDR[i + 1] + "" + " - " + SDR[i + 2] + "" + "%").ToString();
                    }
                    MoreResults = SDR.NextResult();
                } while (MoreResults);
                SDR.Close();
        }

        /// <summary>
        /// Сортировка результатов по специальностям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
                SqlConnection Connect = new SqlConnection(BD.connStr);
                listBox1.Items.Clear();
                Connect.Open();
                System.Text.StringBuilder results = new System.Text.StringBuilder();
                SqlCommand SC = new SqlCommand();
                SC.Connection = Connect;
                SC.CommandType = CommandType.Text;
                SC.CommandText = $"SELECT [Rezulitati].IdRezult, [Rezulitati], [Kolichestvo_ballov] FROM Rezulitati WHERE IdStudenta = {BD.ID} AND Rezulitati= 'Специалист по информационным системам'";
                SqlDataReader SDR = SC.ExecuteReader();
                bool MoreResults = false;
                do
                {
                    while (SDR.Read())
                    {
                        for (int i = 0; i < SDR.FieldCount; i = i + 4)
                            listBox1.Items.Add(SDR[i + 1] + "" + " - " + SDR[i + 2] + "" + "%").ToString();
                    }
                    MoreResults = SDR.NextResult();
                } while (MoreResults);
                SDR.Close();
        }

        /// <summary>
        /// Сортировка результатов по специальностям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
                SqlConnection Connect = new SqlConnection(BD.connStr);
                listBox1.Items.Clear();
                Connect.Open();
                System.Text.StringBuilder results = new System.Text.StringBuilder();
                SqlCommand SC = new SqlCommand();
                SC.Connection = Connect;
                SC.CommandType = CommandType.Text;
                SC.CommandText = $"SELECT [Rezulitati].IdRezult, [Rezulitati], [Kolichestvo_ballov] FROM Rezulitati WHERE IdStudenta = {BD.ID} AND Rezulitati= 'Web-Дизайнер'";
                SqlDataReader SDR = SC.ExecuteReader();
                bool MoreResults = false;
                do
                {
                    while (SDR.Read())
                    {
                        for (int i = 0; i < SDR.FieldCount; i = i + 4)
                            listBox1.Items.Add(SDR[i + 1] + "" + " - " + SDR[i + 2] + "" + "%").ToString();
                    }
                    MoreResults = SDR.NextResult();
                } while (MoreResults);
                SDR.Close();
        }

        /// <summary>
        /// Сортировка результатов по специальностям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
                SqlConnection Connect = new SqlConnection(BD.connStr);
                listBox1.Items.Clear();
                Connect.Open();
                System.Text.StringBuilder results = new System.Text.StringBuilder();
                SqlCommand SC = new SqlCommand();
                SC.Connection = Connect;
                SC.CommandType = CommandType.Text;
                SC.CommandText = $"SELECT [Rezulitati].IdRezult, [Rezulitati], [Kolichestvo_ballov] FROM Rezulitati WHERE IdStudenta = {BD.ID} AND Rezulitati= 'Администратор баз данных'";
                SqlDataReader SDR = SC.ExecuteReader();
                bool MoreResults = false;
                do
                {
                    while (SDR.Read())
                    {
                        for (int i = 0; i < SDR.FieldCount; i = i + 4)
                            listBox1.Items.Add(SDR[i + 1] + "" + " - " + SDR[i + 2] + "" + "%").ToString();
                    }
                    MoreResults = SDR.NextResult();
                } while (MoreResults);
                SDR.Close();
        }

        /// <summary>
        /// Вывод данных в диаграмму
        /// </summary>
        public void Diagramma()
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            connection.Open();
            SqlDataAdapter adapter4 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE  IdStudenta={BD.ID} AND Rezulitati = 'Программист'", connection);
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4);
            SqlDataAdapter adapter3 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE  IdStudenta={BD.ID} AND Rezulitati = 'Тестировщик'", connection);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);
            SqlDataAdapter adapter2 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE  IdStudenta={BD.ID} AND Rezulitati = 'Web-дизайнер'", connection);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            SqlDataAdapter adapter1 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE IdStudenta={BD.ID} AND Rezulitati = 'Специалист по информационным системам'", connection);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE IdStudenta={BD.ID} AND Rezulitati = 'Администратор баз данных'", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int iduser4 = Convert.ToInt32(adapter4.SelectCommand.ExecuteScalar().ToString());
            int iduser3 = Convert.ToInt32(adapter3.SelectCommand.ExecuteScalar().ToString());
            var iduser2 = Convert.ToInt32(adapter2.SelectCommand.ExecuteScalar().ToString());
            var iduser1 = Convert.ToInt32(adapter1.SelectCommand.ExecuteScalar().ToString());
            var iduser = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar().ToString());

            this.chart1.Series[0].Points.AddXY(0, iduser4);
            this.chart1.Series[1].Points.AddXY(0, iduser3);
            this.chart1.Series[2].Points.AddXY(0, iduser2);
            this.chart1.Series[3].Points.AddXY(0, iduser1);
            this.chart1.Series[4].Points.AddXY(0, iduser);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
            
        }
    }
}

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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadAdmin();
            GridStyle();
        }

        /// <summary>
        /// Стиль датагрида
        /// </summary>
        void GridStyle()
        {
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(205, 205, 205);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Aqua;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.BackgroundColor = Color.DarkGray;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(205, 205, 205);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(205, 205, 205);
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Aqua;
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView2.BackgroundColor = Color.DarkGray;
            dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(205, 205, 205);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            avtorization.Show();
            Hide();
        }

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            try
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Rezulitati WHERE IdStudenta={dataGridView1.CurrentRow.Cells[0].Value}", connection);
                SqlCommand cmd2 = new SqlCommand($"DELETE FROM Studenti WHERE IdStudenta={dataGridView1.CurrentRow.Cells[0].Value}", connection);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Удаление выполнено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                LoadAdmin();
            }
        }

        public void LoadAdmin()
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT  Rezulitati.IdRezult as 'Номер результата', [IdStudenta] as 'Номер студента', " +
                "[Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы' FROM Rezulitati", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT  Studenti.IdStudenta as 'Номер студента', [Familia] as 'Фамилия', [Imia] as 'Имя', [Otchestvo] as " +
                 "'Отчество', [NomerGrupi] as 'Номер группы', [Pochta] as 'Email', [Login] as 'Логин', [Parol] as 'Пароль' FROM Studenti", connection);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            BD.ID = Convert.ToInt32(id);
            BD.Familia = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            BD.Imia = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            BD.Otchestvo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            BD.Gruppa = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            BD.Pochta = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            BD.Login = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            BD.Parol = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%{textBox7.Text}%'";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Statistica statistica = new Statistica();
            statistica.Show();
        }

        /// <summary>
        /// Сортировка студентов по результатам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Rezulitati.IdRezult as 'Номер результата', [IdStudenta] as 'Номер студента', [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Количество баллов' FROM Rezulitati WHERE Rezulitati = 'Программист'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadAdmin();
        }

        /// <summary>
        /// Сортировка студентов по результатам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Rezulitati.IdRezult as 'Номер результата', [IdStudenta] as 'Номер студента', [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Количество баллов' FROM Rezulitati WHERE Rezulitati = 'Тестировщик'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Rezulitati.IdRezult as 'Номер результата', [IdStudenta] as 'Номер студента', [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Количество баллов' FROM Rezulitati WHERE Rezulitati = 'Web-Дизайнер'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Rezulitati.IdRezult as 'Номер результата', [IdStudenta] as 'Номер студента', [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Количество баллов' FROM Rezulitati WHERE Rezulitati = 'Специалист по информационным системам'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Rezulitati.IdRezult as 'Номер результата', [IdStudenta] as 'Номер студента', [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Количество баллов' FROM Rezulitati WHERE Rezulitati = 'Администратор баз данных'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nastroiki nastroiki = new Nastroiki();
            nastroiki.Show();
        }
    }
}

using Microsoft.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Prof
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            avtorization.Show();
            Hide();
        }
        /// <summary>
        /// Хэширование
        /// </summary>
        /// <param name="parol"></param>
        /// <returns></returns>
        private string GetHash(string parol)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(parol));

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Кнопка авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            try
            {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                    {
                        if (StringExtensions.IsEmail(textBox5.Text))
                        {
                            button1.Enabled = true;
                            connection.Open();
                            string parol = GetHash(textBox7.Text);
                            SqlCommand cmd = new SqlCommand($"INSERT INTO Studenti (Familia, Imia, Otchestvo, NomerGrupi, Pochta, Login, Parol, IdRole)"
                                + $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{parol}', '2')", connection);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Регистрация прошла успешно!");
                            Avtorization useri = new Avtorization();
                            useri.Show();
                            Hide();
                        }
                        else
                            MessageBox.Show("Email-адрес неправильно введен.");
                    }
                    else
                    {
                        MessageBox.Show("Пустое поле!");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using Microsoft.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prof
{
    public partial class EditPar : Form
    {
        public EditPar()
        {
            InitializeComponent();
            textBox1.Text = BD.Login;
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
        /// Изменение пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            try
            {
                SqlConnection connection2 = new SqlConnection(BD.connStr);
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                        connection.Open();
                   string parol = GetHash(textBox2.Text);
                    SqlCommand cmd = new SqlCommand($"UPDATE Admin SET Login='{textBox1.Text}', Parol='{parol}' WHERE IdAdmina={BD.ID}", connection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Пароль изменеи");
                    SqlDataAdapter cmd2 = new SqlDataAdapter($"SELECT * FROM Admin WHERE IdAdmina = '{BD.ID}'", connection2);
                    DataSet ds = new DataSet();
                    cmd2.Fill(ds);
                    BD.Login = textBox1.Text;
                    BD.Parol = textBox2.Text;
                    Close();
                    Admin admin = new Admin();
                    admin.Show();
                    Hide();
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
    }
}

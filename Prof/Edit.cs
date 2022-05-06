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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            textBox1.Text = BD.Familia;
            textBox2.Text = BD.Imia;
            textBox3.Text = BD.Otchestvo;
            textBox4.Text = BD.Gruppa;
            textBox5.Text = BD.Pochta;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            try
            {
                SqlConnection connection2 = new SqlConnection(BD.connStr);
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    if (StringExtensions.IsEmail(textBox5.Text))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand($"UPDATE Studenti SET Familia='{textBox1.Text}', Imia='{textBox2.Text}',  Otchestvo='{textBox3.Text}', NomerGrupi='{textBox4.Text}', Pochta='{textBox5.Text}'," +
                            $" Login='{BD.Login}', Parol='{BD.Parol}' WHERE IdStudenta={BD.ID}", connection);
                        cmd.ExecuteNonQuery();

                        
                        MessageBox.Show("Данные о студенте изменены!");
                        if (BD.Role == 1)
                        {
                            Admin admin = new Admin();
                            admin.Show();
                            Hide();
                        }
                        else if (BD.Role == 2)
                        {
                            Profil profil1 = new Profil();
                            profil1.Show();
                            Hide();
                        }
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
                textBox1.Text = BD.Familia;
                textBox2.Text = BD.Imia;
                textBox3.Text = BD.Otchestvo;
                textBox4.Text = BD.Gruppa;
                textBox5.Text = BD.Pochta;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }
    }
}

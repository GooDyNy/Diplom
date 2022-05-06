using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class Avtorization : Form
    {
        public Avtorization()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection(BD.connStr);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM Admin", sqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int admin = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar().ToString());

            if (admin == 0) { 
                label1.Visible = false;
            //{   label1.Location = new System.Drawing.Point(79, 271);
                label4.Text = "Здравствуйте, зарегистрируйте администратора, для это введите логин и пароль в соотвествующие поля и нажмите кнопку <Войти>";
            }
            else
                label4.Visible = false;


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
        /// Метод авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(BD.connStr);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM Admin", sqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int admin = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar().ToString());

            if (admin != 0)
            {
                string parol = GetHash(textBox2.Text);
                SqlConnection connection = new SqlConnection(BD.connStr);

                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"if exists (SELECT * from Studenti" +
                    $" where Login='{textBox1.Text}' AND Parol='{parol}') select 1, * FROM Studenti where Login='{textBox1.Text}' AND Parol='{parol}'", connection);
                DataSet ds3 = new DataSet();
                dataAdapter.Fill(ds3);
                if (dataAdapter.SelectCommand.ExecuteScalar() != null)
                {
                    BD.ID = ds3.Tables[0].Rows[0].Field<int>(ds3.Tables[0].Columns[1]);
                    BD.Familia = ds3.Tables[0].Rows[0].Field<string>(ds3.Tables[0].Columns[2]);
                    BD.Imia = ds3.Tables[0].Rows[0].Field<string>(ds3.Tables[0].Columns[3]);
                    BD.Otchestvo = ds3.Tables[0].Rows[0].Field<string>(ds3.Tables[0].Columns[4]);
                    BD.Gruppa = ds3.Tables[0].Rows[0].Field<String>(ds3.Tables[0].Columns[5]);
                    BD.Pochta = ds3.Tables[0].Rows[0].Field<String>(ds3.Tables[0].Columns[6]);
                    BD.Login = ds3.Tables[0].Rows[0].Field<String>(ds3.Tables[0].Columns[7]);
                    BD.Parol = ds3.Tables[0].Rows[0].Field<String>(ds3.Tables[0].Columns[8]);
                    BD.Role = ds3.Tables[0].Rows[0].Field<int>(ds3.Tables[0].Columns[9]);
                    Menu menu = new Menu();
                    menu.Show();
                    Hide();
                }
                else
                {
                    dataAdapter = new SqlDataAdapter($"SELECT Admin.IdAdmina, Login, Parol, Roli.IdRole FROM Admin inner join Roli on Roli.IdRole = Admin.IdRole " +
                        $"WHERE Login = '{textBox1.Text}' AND Parol='{parol}'", connection);
                    DataSet ds1 = new DataSet();
                    dataAdapter.Fill(ds1);
                    if (dataAdapter.SelectCommand.ExecuteScalar() != null)
                    {
                        BD.ID = ds1.Tables[0].Rows[0].Field<int>(ds1.Tables[0].Columns[0]);
                        BD.Login = ds1.Tables[0].Rows[0].Field<string>(ds1.Tables[0].Columns[1]);
                        BD.Parol = ds1.Tables[0].Rows[0].Field<string>(ds1.Tables[0].Columns[2]);
                        BD.Role = ds1.Tables[0].Rows[0].Field<int>(ds1.Tables[0].Columns[3]);
                        Admin admin1 = new Admin();
                        admin1.Show();
                        Hide();
                        connection.Close();

                    }
                }


        } else
            {
                SqlConnection connection = new SqlConnection(BD.connStr);
                connection.Open();
                string parol = GetHash(textBox2.Text);
                SqlCommand cmd = new SqlCommand($"INSERT INTO Admin (Login, Parol, IdRole) VALUES ('{textBox1.Text}','{parol}', '1')", connection);
                cmd.ExecuteNonQuery();
            }       
        }
    


        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Hide();
        }
    }
}

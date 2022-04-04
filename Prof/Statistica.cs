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
    public partial class Statistica : Form
    {
        /// <summary>
        /// Вывод общей статистики
        /// </summary>
        public Statistica()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(BD.connStr);
            connection.Open();
            SqlDataAdapter adapter4 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >100 and  Kolichestvo_ballov<=150 and Rezulitati = 'Программист'", connection);
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4);
            SqlDataAdapter adapter3 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >100 and  Kolichestvo_ballov<=150 and Rezulitati = 'Тестировщик'", connection);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);
            SqlDataAdapter adapter2 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >100 and  Kolichestvo_ballov<=150 and Rezulitati = 'Web-дизайнер'", connection);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            SqlDataAdapter adapter1 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >100 and  Kolichestvo_ballov<=150 and Rezulitati = 'Специалист по информационным системам'", connection);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >100 and  Kolichestvo_ballov<=150 and Rezulitati = 'Администратор баз данных'", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int iduser4 = Convert.ToInt32(adapter4.SelectCommand.ExecuteScalar().ToString());
            int iduser3 = Convert.ToInt32(adapter3.SelectCommand.ExecuteScalar().ToString());
            var iduser2 = Convert.ToInt32(adapter2.SelectCommand.ExecuteScalar().ToString());
            var iduser1 = Convert.ToInt32(adapter1.SelectCommand.ExecuteScalar().ToString());
            var iduser = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar().ToString());


            SqlDataAdapter adapter5 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >50 and  Kolichestvo_ballov<=100 and Rezulitati = 'Программист'", connection);
            DataSet ds5 = new DataSet();
            adapter5.Fill(ds5);
            SqlDataAdapter adapter6 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >50 and  Kolichestvo_ballov<=100 and Rezulitati = 'Тестировщик'", connection);
            DataSet ds6 = new DataSet();
            adapter6.Fill(ds6);
            SqlDataAdapter adapter7 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >50 and  Kolichestvo_ballov<=100 and Rezulitati = 'Web-дизайнер'", connection);
            DataSet ds7 = new DataSet();
            adapter7.Fill(ds7);
            SqlDataAdapter adapter8 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >50 and  Kolichestvo_ballov<=100 and Rezulitati = 'Специалист по информационным системам'", connection);
            DataSet ds8 = new DataSet();
            adapter8.Fill(ds5);
            SqlDataAdapter adapter9 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov >50 and  Kolichestvo_ballov<=100 and Rezulitati = 'Администратор баз данных'", connection);
            DataSet ds9 = new DataSet();
            adapter9.Fill(ds9);
            var iduser5 = Convert.ToInt32(adapter5.SelectCommand.ExecuteScalar().ToString());
            var iduser6 = Convert.ToInt32(adapter6.SelectCommand.ExecuteScalar().ToString());
            var iduser7 = Convert.ToInt32(adapter7.SelectCommand.ExecuteScalar().ToString());
            var iduser8 = Convert.ToInt32(adapter8.SelectCommand.ExecuteScalar().ToString());
            var iduser9 = Convert.ToInt32(adapter9.SelectCommand.ExecuteScalar().ToString());


            SqlDataAdapter adapter10 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov <=50 and Rezulitati = 'Программист'", connection);
            DataSet ds10 = new DataSet();
            adapter10.Fill(ds10);
            SqlDataAdapter adapter11 = new SqlDataAdapter($"SELECT COUNT(*) FROM Rezulitati WHERE Kolichestvo_ballov <= 50 and Rezulitati = 'Тестировщик'", connection);
            DataSet ds11 = new DataSet();
            adapter11.Fill(ds11);
            SqlDataAdapter adapter12 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov <=50 and Rezulitati = 'Web-дизайнер'", connection);
            DataSet ds12 = new DataSet();
            adapter12.Fill(ds12);
            SqlDataAdapter adapter13 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov <=50 and Rezulitati = 'Специалист по информационным системам'", connection);
            DataSet ds13 = new DataSet();
            adapter13.Fill(ds13);
            SqlDataAdapter adapter14 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE Kolichestvo_ballov <=50 and Rezulitati = 'Администратор баз данных'", connection);
            DataSet ds14 = new DataSet();
            adapter14.Fill(ds14);

            var iduser10 = Convert.ToInt32(adapter10.SelectCommand.ExecuteScalar().ToString());
            var iduser11 = Convert.ToInt32(adapter11.SelectCommand.ExecuteScalar().ToString());
            var iduser12 = Convert.ToInt32(adapter12.SelectCommand.ExecuteScalar().ToString());
            var iduser13 = Convert.ToInt32(adapter13.SelectCommand.ExecuteScalar().ToString());
            var iduser14 = Convert.ToInt32(adapter14.SelectCommand.ExecuteScalar().ToString());



            this.chart1.Series[0].Points.AddXY("От 0 до 50", iduser4);
            this.chart1.Series[1].Points.AddXY(0, iduser3);
            this.chart1.Series[2].Points.AddXY(0, iduser2);
            this.chart1.Series[3].Points.AddXY(0, iduser1);
            this.chart1.Series[4].Points.AddXY(0, iduser);

            this.chart1.Series[0].Points.AddXY("51 до 100", iduser5);
            this.chart1.Series[1].Points.AddXY(0, iduser6);
            this.chart1.Series[2].Points.AddXY(0, iduser7);
            this.chart1.Series[3].Points.AddXY(0, iduser8);
            this.chart1.Series[4].Points.AddXY(0, iduser9);

            this.chart1.Series[0].Points.AddXY("От 101 до 150 ", iduser10);
            this.chart1.Series[1].Points.AddXY(0, iduser11);
            this.chart1.Series[2].Points.AddXY(0, iduser12);
            this.chart1.Series[3].Points.AddXY(0, iduser13);
            this.chart1.Series[4].Points.AddXY(0, iduser14);
        }

    }
}

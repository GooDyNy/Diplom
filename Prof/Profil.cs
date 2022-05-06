using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                SqlConnection connection = new SqlConnection(BD.connStr);
                connection.Open();
                SqlDataAdapter adapter4 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND Kolichestvo_ballov >75 and  Kolichestvo_ballov<=100 and Rezulitati = 'Программист'", connection);
                DataSet ds4 = new DataSet();
                adapter4.Fill(ds4);
                SqlDataAdapter adapter3 = new SqlDataAdapter($"Select  [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND Kolichestvo_ballov >75 and  Kolichestvo_ballov<=100 and Rezulitati = 'Тестировщик'", connection);
                DataSet ds3 = new DataSet();
                adapter3.Fill(ds3);
                SqlDataAdapter adapter2 = new SqlDataAdapter($"Select  [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta = {BD.ID} AND Kolichestvo_ballov >75 and  Kolichestvo_ballov<=100 and Rezulitati = 'Web-дизайнер'", connection);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2);
                SqlDataAdapter adapter1 = new SqlDataAdapter($"Select  [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta = {BD.ID} AND Kolichestvo_ballov >75 and  Kolichestvo_ballov<=100 and Rezulitati = 'Специалист по информационным системам'", connection);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1);
                SqlDataAdapter adapter = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND Kolichestvo_ballov >75 and  Kolichestvo_ballov<=100 and Rezulitati = 'Администратор баз данных'", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);


            var iduser4 = Convert.ToInt32((adapter4.SelectCommand.ExecuteScalar() == null) ? "0" : adapter4.SelectCommand.ExecuteScalar().ToString());
            var iduser3 = Convert.ToInt32((adapter3.SelectCommand.ExecuteScalar() == null) ? "0" : adapter3.SelectCommand.ExecuteScalar().ToString());
            var iduser2 = Convert.ToInt32((adapter2.SelectCommand.ExecuteScalar() == null) ? "0" : adapter2.SelectCommand.ExecuteScalar().ToString());
            var iduser1 = Convert.ToInt32((adapter1.SelectCommand.ExecuteScalar() == null) ? "0" : adapter1.SelectCommand.ExecuteScalar().ToString());
            var iduser = Convert.ToInt32((adapter.SelectCommand.ExecuteScalar() == null) ? "0" : adapter.SelectCommand.ExecuteScalar().ToString());



            SqlDataAdapter adapter5 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND Kolichestvo_ballov >40 and  Kolichestvo_ballov<=75 and Rezulitati = 'Программист'", connection);
                DataSet ds5 = new DataSet();
                adapter5.Fill(ds5);
                SqlDataAdapter adapter6 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov >40 and  Kolichestvo_ballov<=75 and Rezulitati = 'Тестировщик'", connection);
                DataSet ds6 = new DataSet();
                adapter6.Fill(ds6);
                SqlDataAdapter adapter7 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov >40 and  Kolichestvo_ballov<=75 and Rezulitati = 'Web-дизайнер'", connection);
                DataSet ds7 = new DataSet();
                adapter7.Fill(ds7);
                SqlDataAdapter adapter8 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov >40 and  Kolichestvo_ballov<=75 and Rezulitati = 'Специалист по информационным системам'", connection);
                DataSet ds8 = new DataSet();
                adapter8.Fill(ds5);
                SqlDataAdapter adapter9 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov >40 and  Kolichestvo_ballov<=75 and Rezulitati = 'Администратор баз данных'", connection);
                DataSet ds9 = new DataSet();
                adapter9.Fill(ds9);

            var iduser5 = Convert.ToInt32((adapter5.SelectCommand.ExecuteScalar() == null) ? "0" : adapter5.SelectCommand.ExecuteScalar().ToString());
            var iduser6 = Convert.ToInt32((adapter6.SelectCommand.ExecuteScalar() == null) ? "0" : adapter6.SelectCommand.ExecuteScalar().ToString());
            var iduser7 = Convert.ToInt32((adapter7.SelectCommand.ExecuteScalar() == null) ? "0" : adapter7.SelectCommand.ExecuteScalar().ToString());
            var iduser8 = Convert.ToInt32((adapter8.SelectCommand.ExecuteScalar() == null) ? "0" : adapter8.SelectCommand.ExecuteScalar().ToString());
            var iduser9 = Convert.ToInt32((adapter9.SelectCommand.ExecuteScalar() == null) ? "0" : adapter9.SelectCommand.ExecuteScalar().ToString());


            SqlDataAdapter adapter10 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov <=40 and Rezulitati = 'Программист'", connection);
                DataSet ds10 = new DataSet();
                adapter10.Fill(ds10);
                SqlDataAdapter adapter11 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND Kolichestvo_ballov <= 40 and Rezulitati = 'Тестировщик'", connection);
                DataSet ds11 = new DataSet();
                adapter11.Fill(ds11);
                SqlDataAdapter adapter12 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov <=40 and Rezulitati = 'Web-дизайнер'", connection);
                DataSet ds12 = new DataSet();
                adapter12.Fill(ds12);
                SqlDataAdapter adapter13 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov <=40 and Rezulitati = 'Специалист по информационным системам'", connection);
                DataSet ds13 = new DataSet();
                adapter13.Fill(ds13);
                SqlDataAdapter adapter14 = new SqlDataAdapter($"Select [Kolichestvo_ballov] as 'Баллы'  FROM Rezulitati  WHERE IdStudenta =  {BD.ID} AND  Kolichestvo_ballov <=40 and Rezulitati = 'Администратор баз данных'", connection);
                DataSet ds14 = new DataSet();
                adapter14.Fill(ds14);

            var iduser10 = Convert.ToInt32((adapter10.SelectCommand.ExecuteScalar() == null) ? "0" : adapter10.SelectCommand.ExecuteScalar().ToString());
            var iduser11 = Convert.ToInt32((adapter11.SelectCommand.ExecuteScalar() == null) ? "0" : adapter11.SelectCommand.ExecuteScalar().ToString());
            var iduser12 = Convert.ToInt32((adapter12.SelectCommand.ExecuteScalar() == null) ? "0" : adapter12.SelectCommand.ExecuteScalar().ToString());
            var iduser13 = Convert.ToInt32((adapter13.SelectCommand.ExecuteScalar() == null) ? "0" : adapter13.SelectCommand.ExecuteScalar().ToString());
            var iduser14 = Convert.ToInt32((adapter14.SelectCommand.ExecuteScalar() == null) ? "0" : adapter14.SelectCommand.ExecuteScalar().ToString());



            this.chart1.Series[0].Points.AddXY("От 0 до 40", iduser14);
                this.chart1.Series[1].Points.AddXY(0, iduser13);
                this.chart1.Series[2].Points.AddXY(0, iduser12);
                this.chart1.Series[3].Points.AddXY(0, iduser11);
                this.chart1.Series[4].Points.AddXY(0, iduser10);

                this.chart1.Series[0].Points.AddXY("От 40 до 75", iduser5);
                this.chart1.Series[1].Points.AddXY(0, iduser6);
                this.chart1.Series[2].Points.AddXY(0, iduser7);
                this.chart1.Series[3].Points.AddXY(0, iduser8);
                this.chart1.Series[4].Points.AddXY(0, iduser9);

                this.chart1.Series[0].Points.AddXY("От 75 до 100 ", iduser);
                this.chart1.Series[1].Points.AddXY(0, iduser1);
                this.chart1.Series[2].Points.AddXY(0, iduser2);
                this.chart1.Series[3].Points.AddXY(0, iduser3);
                this.chart1.Series[4].Points.AddXY(0, iduser4);


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
            Menu avtorization = new Menu(); 
            avtorization.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
            
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(BD.connStr);
            connection.Open();
            SqlDataAdapter adapter3 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE  IdStudenta={BD.ID}", connection);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);
            int kol = Convert.ToInt32(adapter3.SelectCommand.ExecuteScalar().ToString());

            if (kol == 0)
            {
                MessageBox.Show("Вы не прошли ни одного тестирования для вывода результатов.");

            }
            else
            {
                SqlConnection connection2 = new SqlConnection(BD.connStr);
                DataTable dt = new DataTable();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT  Rezulitati.IdRezult as 'Номер результата', " +
                     $"[Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы' FROM Rezulitati WHERE IdStudenta = '{BD.ID}'", connection2);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dt = ds.Tables[0];
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 40;
                ExcelApp.Columns.HorizontalAlignment = HorizontalAlignment.Center;
                ExcelApp.Cells[1, 2] = BD.Familia + ' ' + BD.Imia + ' ' + BD.Otchestvo;
                ExcelApp.Cells[1, 1].Font.Bold = true;
                ExcelApp.Cells[2, 1].Font.Bold = true;
                ExcelApp.Cells[3, 1].Font.Bold = true;
                ExcelApp.Cells[5, 2].Font.Bold = true;
                ExcelApp.Cells[1, 1] = "ФИО:";
                ExcelApp.Cells[2, 1] = "Группа:";
                ExcelApp.Cells[2, 2] = BD.Gruppa;
                ExcelApp.Cells[3, 2] = BD.Pochta;
                ExcelApp.Cells[3, 1] = "Почта:";
                ExcelApp.Cells[5, 2] = "Результаты";
                ExcelApp.Cells[7, 1] = ds.Tables[0].Columns[0].ColumnName;
                ExcelApp.Cells[7, 2] = ds.Tables[0].Columns[1].ColumnName;
                ExcelApp.Cells[7, 3] = ds.Tables[0].Columns[2].ColumnName;
                ExcelApp.Cells[7, 1].Font.Bold = true;
                ExcelApp.Cells[7, 2].Font.Bold = true;
                ExcelApp.Cells[7, 3].Font.Bold = true;


                //Объеденение
                ExcelApp.get_Range("A5", "B5").Merge(Type.Missing);
                ExcelApp.get_Range("B5", "C5").Merge(Type.Missing);

                //Выравнивание по центру
                Microsoft.Office.Interop.Excel.Range r = ExcelApp.get_Range("A1", "S40");
                r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                //Заполнение
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ExcelApp.Cells[j + 8, i + 1] = dt.Rows[j].ItemArray[i].ToString();
                    }
                }
                ExcelApp.Visible = true;
            }
        }

    }
}

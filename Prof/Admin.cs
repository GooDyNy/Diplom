using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Prof
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadAdmin();
            GridStyle();
             
           button7.Enabled = false;
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
            SqlDataAdapter adapter = new SqlDataAdapter("Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', " +
                " [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы', Date as 'Дата' FROM Rezulitati inner join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta", connection);
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


            SqlConnection connection = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter("Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', [Rezulitati] as 'Результат'," +
                $" [Kolichestvo_ballov] as 'Баллы', Date as 'Дата' FROM Rezulitati inner  join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta WHERE Studenti.IdStudenta = {BD.ID}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            button7.Enabled = true;

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
            SqlDataAdapter adapter = new SqlDataAdapter($"Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', " +
                " [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы', Date as 'Дата' FROM Rezulitati inner join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta WHERE Rezulitati = 'Программист'", Connect);
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
            SqlDataAdapter adapter = new SqlDataAdapter($"Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', " +
                " [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы', Date as 'Дата' FROM Rezulitati inner join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta WHERE Rezulitati = 'Тестировщик'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', " +
                " [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы', Date as 'Дата' FROM Rezulitati inner join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta WHERE Rezulitati = 'Web-Дизайнер'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', " +
                " [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы', Date as 'Дата' FROM Rezulitati inner join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta WHERE Rezulitati = 'Специалист по информационным системам'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(BD.connStr);
            SqlDataAdapter adapter = new SqlDataAdapter($"Select Rezulitati.IdRezult as 'Номер результата', Studenti.Familia +' '+SUBSTRING(Studenti.Imia , 1,1)+'.'+SUBSTRING(Studenti.Otchestvo , 1,1) + '.' as 'Студент', " +
                " [Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы', Date as 'Дата', FROM Rezulitati inner join Studenti on Rezulitati.IdStudenta = Studenti.IdStudenta WHERE Rezulitati = 'Администратор баз данных'", Connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nastroiki nastroiki = new Nastroiki();
            nastroiki.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

                SqlConnection connection = new SqlConnection(BD.connStr);
                connection.Open();
                SqlDataAdapter adapter3 = new SqlDataAdapter($"SELECT COUNT (*) FROM Rezulitati WHERE  IdStudenta={BD.ID}", connection);
                DataSet ds3 = new DataSet();
                adapter3.Fill(ds3);
                int kol = Convert.ToInt32(adapter3.SelectCommand.ExecuteScalar().ToString());

            if (kol == 0)
            {
                MessageBox.Show("Данный студент не прошел ни одного тестирования.");

            }
            else
            {
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT  Studenti.IdStudenta as 'Номер студента', [Familia] as 'Фамилия', [Imia] as 'Имя', [Otchestvo] as " +
                        "'Отчество', [NomerGrupi] as 'Номер группы', [Pochta] as 'Email', [Login] as 'Логин', [Parol] as 'Пароль' FROM Studenti", connection);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT  Rezulitati.IdRezult as 'Номер результата', " +
                     $"[Rezulitati] as 'Результат', [Kolichestvo_ballov] as 'Баллы' FROM Rezulitati WHERE IdStudenta = '{BD.ID}'", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Nomer = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            var student = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            var rezult  = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            var ball  = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            int balls = Convert.ToInt32(ball);

           


            if (balls >= 30)
            {
                var application = new Word.Application();

                application.Visible = true;
                Word.Document document = application.Documents.Add();

                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range range = paragraph.Range;

                
                range.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                range = paragraph.Range;
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.Text = $@"

Сертификат";
                range.set_Style("Заголовок");
                range.Bold = 10;
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.InsertParagraphAfter();

                range = paragraph.Range;
                range.Text = $"данный сертификат подтверждает, что";
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.Font.Color = Word.WdColor.wdColorBlack;
                range.InsertParagraphAfter();

                range = paragraph.Range;
                range.Text = $"{student}";
                range.set_Style("Заголовок");
                range.Bold = 10;
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.Font.Color = Word.WdColor.wdColorBlack;
                range.InsertParagraphAfter();

                range = paragraph.Range;
                range.Text = $"успешно прошел(ла) тестирование.";
                range.set_Style("Обычный");
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.Font.Color = Word.WdColor.wdColorBlack;
                range.InsertParagraphAfter();

                range = paragraph.Range;
                range.Text = $"Результат: {ball}%";
                range.set_Style("Обычный");
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.Font.Color = Word.WdColor.wdColorBlack;
                range.InsertParagraphAfter();

                range = paragraph.Range;
                range.Text = $"Квалификация: {rezult}";
                range.set_Style("Обычный");
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.Font.Color = Word.WdColor.wdColorBlack;
                range.InsertParagraphAfter();


                range = paragraph.Range;
                range.Text = $"Подпись: ___________";
                range.set_Style("Обычный");
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                range.Font.Color = Word.WdColor.wdColorBlack;

                var date = DateTime.Now.Date.ToString();

                DateTime dt = DateTime.Now;
                string curDate = dt.ToShortDateString();

                range.Text = $"Дата: {curDate}                                                                                                                                            Подпись: ___________";
                paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                range.InsertParagraphAfter();

                application.Visible = true;

            } else if(balls < 50)
            {
                MessageBox.Show("Данный студент не прошел выбранное им тестирование.");
            }

        }

    }
}

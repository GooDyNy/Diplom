using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prof
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SqlConnection sqlConnection = new SqlConnection(BD.connStr);
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM Admin", sqlConnection);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //int admin = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar().ToString();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Avtorization());
        }
    }
}

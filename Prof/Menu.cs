using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prof
{
    public partial class Menu : Form
    {

        /// <summary>
        /// Метод загрузки главный
        /// </summary>
        public Menu()
        {

            InitializeComponent();
            //pictureBox2.Location = new Point(173, 280);
            //pictureBox2.Width = 839;
            //pictureBox2.Height = 365;
            label1.Location = new Point(540, 75);
            //label2.Location = new Point(1, 74);
            pictureBox2.Image = Image.FromFile($@"C:\Users\tsymb\Desktop\4 курс\Диплом\Prof\Prof\Картинки\прогр.jpeg");
            label1.Text = "Программист";
            label2.Text = " Данная специализация осуществляет подготовку классических разработчиков программного обеспечения. \n\t\r" +
                "На данном направлении изучают различные языки программирования для создания IT-решений под операционные системы Window и Linux. \n\t\r" +
                "В процессе обучения изучаются языки программирования, как C++, C# и Java для разработки консольных и оконных приложений. \n\t\r" +
                "В качестве инструментов рассматриваются среды Visual Studio и IntelliJ Idea. Программисты разрабатываю пользовательские библиотеки. \n\t\r" +
                "Осуществляют разработку мобильных и планшетных приложений под Android или IOS используя технологии Xamarine и Android Studio. \n\t\r" +
                "Занимаются системным программированием плат на примере Arduino.Работают с СУБД MS, MySql и PostGre.";


        }

        /// <summary>
        /// Методы загрузки информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(350, 520);
            pictureBox2.Width = 600;
            pictureBox2.Height = 220;
            pictureBox2.Image = Image.FromFile($@"C:\Users\tsymb\Desktop\4 курс\Диплом\Prof\Prof\Картинки\инфор.jpg");
            label1.Location = new Point(330, 80);
            label2.Location = new Point(155, 150);
            label1.Text = "Специалист по информационным системам";
            label2.Text = "Специалисты по информационным системам квалификация являются строителями фундамента баз данных и\n\t\r" +
                "клиент-серверных приложений. Они уделяют особое внимание механизмам проектирования информационных систем. \n\t\r" +
                "На данной специализации осваивают язык UML и работают в CA Process Modeler. \n\t\r" +
                "Специалисты по информационным системам осуществляют обеспечение проектной деятельности. \n\t\r" +
                "Обучаясь на данном направлении можно получить богатый опыт работая системе в MS Project. \n\t\r" +
                "На данной специализации изучают языки SQL и PL/ SQl в СУБД, как My SQL, MS SQL и ORACLE. \n\t\r" +
                "Специалисты по информационным системам являются высококвалифицированными программистами системы \n\t\r" +
                "«1С Предприятие». \n\t\r" +
                "Она разрабатывают клиентские приложения в среде Visual Studio.";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(400, 500);
            pictureBox2.Width = 520;
            pictureBox2.Height = 260;
            pictureBox2.Image = Image.FromFile($@"C:\Users\tsymb\Desktop\4 курс\Диплом\Prof\Prof\Картинки\бд.jpg");
            label1.Location = new Point(460, 75);
            label2.Location = new Point(100, 144);
            label1.Text = "Администратор баз данных";
            label2.Text = "На данной специализации обучают технологиям создания, модификации и сопровождения баз данных. \n\t\r" +
                "Данное направление позволяет получить профессиональный опыт в работе СУБД MS SQL Server и MySql. \n\t\r" +
                "Администраторы баз данных обеспечивает стабильную работу серверов, работают с операционными системами семейства Window, \n\t\r" +
                "преимущественно Windows Server. Осуществляют резервное копирование и восстановление данных после отказа систем. \n\t\r" +
                "Получают базовое представление работы с системой «1С: Предприятие».\n\t\r" +
                "В качестве базового языка программирования изучают C# в среде Visual Studio и знакомятся с языком программирования C++.\n\t\r " +
                "Создают консольные и оконные приложения под платформу Windows.\n\t\r" +
                "Администраторы баз дынных свободно ориентируются в CASE - средствах проектирования и документирования баз данных и \n\t\r " +
                "свободно пишут запросы на языке SQL.";

        }


        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(390, 500);
            pictureBox2.Width = 500;
            pictureBox2.Height = 220;
            pictureBox2.Image = Image.FromFile($@"C:\Users\tsymb\Desktop\4 курс\Диплом\Prof\Prof\Картинки\веб.jpg");
            label1.Location = new Point(540, 55);
            label2.Location = new Point(110, 135);
            label1.Text = "Web-Дизайнер";
            label2.Text = "Данная квалификация присевается FrontEnd и BackEnd разработчикам, \n\t\r" +
                "а именно Веб-дизайнерам и Веб-программистам.\n\t\r" +
                "На данном направление изучают современные технологии проектирования и создания макетов сайтов.\n\t\r" +
                "Изучаются инструменты 3D моделирования.\n\t\r" +
                "Разработчики WEB и мультимедийных приложений получают богаты опыт в реализации адаптивной верстки \n\t\r" +
                "сайтов под мобильные, планшетный и компьютерные устройства.\n\t\r" +
                "На данной специализации изучают языки, как HTML, CSS, JavaScript и PHP, включая различные популярные фреймворки и CMS.\n\t\r" +
                "Данная специализация позволяет стать профессиональным программистом для создания WEB - приложений, \n\t\r" +
                "корпоративных сайтов и Интернет-магазинов.\n\t\r";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(400, 460);
            pictureBox2.Width = 520;
            pictureBox2.Height = 270;
            pictureBox2.Image = Image.FromFile($@"C:\Users\tsymb\Desktop\4 курс\Диплом\Prof\Prof\Картинки\тестир2.jpg");
            label1.Location = new Point(550, 50);
            label1.Text = "Тестировщик";
            //label2.Location = new Point(30, 74);
            label2.Text = "Данная специализация осуществляет подготовку специалистов для обеспечения качества программных продуктов. \n\t\r" +
                    "Тестировщики тесно работают с программистами и их задача искать ошибки, отказы и дефекты в приложениях. \n\t\r" +
                    "Они осуществляют валидацию и верификацию программных продуктов. \n\t\r" +
                    "Учатся разработке программных средств, как и программисты, но их задача писать автоматизированные тесты \n\t\r" +
                    "для проверки работоспособности программ. \n\t\r" +
                    "Не зная программирования не Unit, не UI тесты написать невозможно.Специалисты по тестированию осваивают \n\t\r" +
                    "подход Test-Driven Development, программирование через тестирование. \n\t\r" +
                    "На данном направлении обучают создавать сценария тестов и проводить тестовые испытания используя современные технологии.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pictureBox2.Location = new Point(173, 280);
            //pictureBox2.Width = 493;
            //pictureBox2.Height = 234;
            label1.Location = new Point(540, 75);
            //label2.Location = new Point(1, 74);
            pictureBox2.Image = Image.FromFile($@"C:\Users\tsymb\Desktop\4 курс\Диплом\Prof\Prof\Картинки\прогр.jpeg");
            label1.Text = "Программист";
            label2.Text = " Данная специализация осуществляет подготовку классических разработчиков программного обеспечения. \n\t\r" +
                "На данном направлении изучают различные языки программирования для создания IT-решений под операционные системы Window и Linux. \n\t\r" +
                "В процессе обучения изучаются языки программирования, как C++, C# и Java для разработки консольных и оконных приложений. \n\t\r" +
                "В качестве инструментов рассматриваются среды Visual Studio и IntelliJ Idea. Программисты разрабатываю пользовательские библиотеки. \n\t\r" +
                "Осуществляют разработку мобильных и планшетных приложений под Android или IOS используя технологии Xamarine и Android Studio. \n\t\r" +
                "Занимаются системным программированием плат на примере Arduino.Работают с СУБД MS, MySql и PostGree.";
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            BD.Prof2 = label1.Text;
            if (label1.Text == "Программист")
                BD.Prof = 1;
            if (label1.Text == "Тестировщик")
                BD.Prof = 2;
            if (label1.Text == "Web-Дизайнер")
                BD.Prof = 3;
            if (label1.Text == "Специалист по информационным системам")
                BD.Prof = 4;
            if (label1.Text == "Администратор баз данных")
                BD.Prof = 5;
            Testirovanie testirovanie = new Testirovanie();
            testirovanie.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            avtorization.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Statistica statistica = new Statistica();
            statistica.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            avtorization.Show();
            Hide();
        }

       

        private void button9_Click_1(object sender, EventArgs e)
        {
            Profil profil = new Profil();
            profil.Show();
            Hide();
        }

       public void Style()
        {
            this.BackColor = Color.Moccasin;
            pictureBox1.BackColor = Color.CadetBlue;
            button1.BackColor = Color.CadetBlue;
            button3.BackColor = Color.CadetBlue;
            button2.BackColor = Color.CadetBlue;
            button6.BackColor = Color.CadetBlue;
            button5.BackColor = Color.CadetBlue;
            button7.BackColor = Color.CadetBlue;
            button4.BackColor = Color.Orange;
            button9.BackColor = Color.Orange;
            BD.style = 5;

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Style();

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}

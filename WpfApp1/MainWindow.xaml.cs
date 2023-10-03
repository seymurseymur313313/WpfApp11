using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace WpfApp1
{

    class DataAccess
    {

        SqlConnection? connect = null;
        public string? bookName;
        public string? bookPrice;
        public string? bookPages;

        public DataAccess()
        {


            string connectionString = @"Data Source=STHQ0126-05;Initial Catalog=Books;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;";
            connect = new SqlConnection(connectionString);

        }


        public void insertDatabase()
        {

            connect.Open();
            string insertData = $"INSERT INTO book ( name, pages ,price) VALUES ('{bookName}' ,'{bookPages}' ,'{bookPrice}')";
            using SqlCommand cmd = new SqlCommand(insertData, connect);
            cmd.ExecuteNonQuery();


        }

        public void ShowDatabase()
        {
            SqlDataReader reader = null;
            try
            {
                connect.Open();
                using SqlCommand command = new SqlCommand("SELECT * FROM book", connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine(reader["name"] + " " + reader["pages"] + " " + reader["price"]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                connect.Close();
            }
        }


    }


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataAccess access = new DataAccess();
            access = new DataAccess();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataAccess access = new DataAccess();
            access = new DataAccess();
            access.bookName = bkName.Text;
            access.bookPrice = bkPrice.Text;
            access.bookPages = bkPages.Text;
            access.insertDatabase();
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataAccess access1 = new DataAccess();
            access1 = new DataAccess();
            access1.bookName= bkName.Text;
            access1.bookPrice = bkPrice.Text;
            access1.bookPages = bkPages.Text;
            access1.ShowDatabase();
        }
    }


}


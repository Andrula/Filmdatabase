using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;




namespace LAX_Movie_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }

        // Funktion der udfylder data i Datagrid.
        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT Titel, Instructor, DateOfRelease FROM Movies";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Movies");
                sda.Fill(dt);
                DataGridXAML.ItemsSource = dt.DefaultView;

            }
        }
     
        // Tilføjer funktionen at applikationen kan bevæges rundt på skærmen.
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // Tilføjer funktionen at applikationen lukker ved tryk på "lukke knappen" 
        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Tilføjer funktionen at applikationen man minimeres
        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Tilføjer funktionen at applikationen kan gøres mindre, og større hvis den i forvejen er mindre.
        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.WindowState == System.Windows.WindowState.Maximized)
                    this.WindowState = System.Windows.WindowState.Normal;
                else
                    this.WindowState = System.Windows.WindowState.Maximized;
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Tilføjer funktionen at applikationen åbner "opretteleses" vinduet. Den kalder en anden metode.
        private void Button_Click_Opret(object sender, RoutedEventArgs e)
        {
            Dialog nytVindue = new Dialog();
            nytVindue.Show();
        }

        private void Button_Click_Detaljer(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Opdater(object sender, RoutedEventArgs e)
        {

        }
    }
}

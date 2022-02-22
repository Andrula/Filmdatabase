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
using LAX_Movie_Application;

namespace LAX_Movie_Application
{
    /// <summary>
    /// Interaction logic for Detaljer.xaml
    /// </summary>
    public partial class Detaljer : Window
    {
        public Detaljer()
        {
            InitializeComponent();
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

        // En try catch statement som tilføjer funktionen at applikationen kan minimeres
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

        // En try catch statement som gør at applikation kan gøres mindre, og større hvis den i forvejen er mindre.
        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.WindowState == System.Windows.WindowState.Maximized)
                    this.WindowState = System.Windows.WindowState.Normal;
                else
                    this.WindowState = System.Windows.WindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_Slet(object sender, RoutedEventArgs e)
        {
            
            
            
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Movies WHERE ID = '" + SletKnap + "';", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("Der opstod en fejl: {0}", ex.Message));
            }
        }
    }
}

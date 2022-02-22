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

    public partial class Dialog : Window
    {
        public Dialog()
        {
            InitializeComponent();
        }

        private void FlytApplikationRundt(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LukApplikation(object sender, MouseButtonEventArgs e)
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

        private void Minimer(object sender, MouseButtonEventArgs e)
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

        private void MinimerMaximer(object sender, MouseButtonEventArgs e)
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


        public void OpretNyFilm(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string Query = "Insert into Movies (ID, Titel,Instructor,DateOfRelease) Values('"+ IDTB.Text +"','"+ TitelTB.Text + "','" + InstructorTB.Text + "'," + YearTB.Text + ")";
                SqlCommand command = new SqlCommand(Query, con);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    Close();
                    MessageBox.Show("Film tilføjet til databasen");
                }
                catch (InvalidCastException)
                {
                    // recover from exception
                    MessageBox.Show("Noget gik galt, prøv igen!");
                }

            }
        }

        private void Fortryd(object sender, RoutedEventArgs e)
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
    }
}

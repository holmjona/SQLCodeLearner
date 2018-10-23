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

namespace CodeLearner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnGetNames_Click(object sender, RoutedEventArgs e) {
            List<Person> peops = GetPeopleFromDatabase();

            foreach (Person p in peops) {
                stkNames.Children.Add(new Label() {
                    Content = p.LastName
                });
            }



        }

        private List<Person> GetPeopleFromDatabase() {
            List<Person> peops = new List<Person>();
            SqlConnection conn = null;
            try {
                //the next three lines of code are to allow for relative paths 
                // and is based on code found at:
                // https://stackoverflow.com/questions/1833640/connection-string-with-relative-path-to-the-database-file
                string exeLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = (System.IO.Path.GetDirectoryName(exeLoc));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);

                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\data\MyData.mdf;Integrated Security=True");
                conn.Open();
                //MessageBox.Show("Dude, we're in.");
                SqlCommand comm =
                    new SqlCommand("SELECT  * FROM People");
                comm.Connection = conn;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read()) {
                    Person p = new Person();
                    p.FirstName = (String)dr["FirstName"];
                    p.LastName = (String)dr["LastName"];
                    peops.Add(p);
                }


            } catch (Exception ex) {
                MessageBox.Show("Oops; " + ex.Message);
            } finally {
                if (conn != null) conn.Close();
            }
            return peops;
        }
    }
}

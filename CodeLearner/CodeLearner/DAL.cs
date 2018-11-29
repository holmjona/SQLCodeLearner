using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLearner {
    static class DAL {
        private static string _ConnectionString = null;

        internal static string ConnectionString {
            get {
                if (_ConnectionString == null) {
                    //the next three lines of code are to allow for relative paths 
                    // and is based on code found at:
                    // https://stackoverflow.com/questions/1833640/connection-string-with-relative-path-to-the-database-file
                    string exeLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string path = (System.IO.Path.GetDirectoryName(exeLoc));
                    AppDomain.CurrentDomain.SetData("DataDirectory", path);
                    _ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\data\MyData.mdf;Integrated Security=True";
                }
                return _ConnectionString;
            }
        }

        public static List<Person> GetPeople() {
            List<Person> peops = new List<Person>();
            SqlConnection conn = null;
            try {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand comm =
                    new SqlCommand("SELECT * FROM People");
                comm.Connection = conn;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read()) {
                    Person p = new Person();
                    p.ID = (int)dr["PersonID"];
                    p.FirstName = (String)dr["FirstName"];
                    p.LastName = (String)dr["LastName"];
                    p.DateOfBirth = (DateTime)dr["DateOfBirth"];
                    p.IsManager = (bool)dr["IsManager"];
                    p.Email = (String)dr["Email"];
                    p.Phone = (string)dr["Phone"];
                    p.Prefix = (string)dr["PreFix"];
                    p.Postfix = (string)dr["PostFix"];
                    p.Homepage = (String)dr["HomePage"];
                    peops.Add(p);
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            } finally {
                if (conn != null) conn.Close();
            }
            return peops;
        }

        public static Person GetPerson(int id) {
            Person retPerson = null;
            SqlConnection conn = null;
            try {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                //SqlCommand comm =
                //    new SqlCommand("SELECT * FROM People WHERE PersonID = id"
                //    , conn);

                String qry = "SELECT * FROM People WHERE PersonID = @ID";
                SqlCommand comm = new SqlCommand(qry, conn);
                comm.Parameters.AddWithValue("@ID", id);

                //comm.Connection = conn;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read()) {
                    retPerson = new Person();
                    retPerson.ID = (int)dr["PersonID"];
                    retPerson.FirstName = (String)dr["FirstName"];
                    retPerson.LastName = (String)dr["LastName"];
                    retPerson.DateOfBirth = (DateTime)dr["DateOfBirth"];
                    retPerson.IsManager = (bool)dr["IsManager"];
                    retPerson.Email = (String)dr["Email"];
                    retPerson.Phone = (string)dr["Phone"];
                    retPerson.Prefix = (string)dr["PreFix"];
                    retPerson.Postfix = (string)dr["PostFix"];
                    retPerson.Homepage = (String)dr["HomePage"];
                }
            } catch(Exception ex) { 
            } finally {
                if (conn != null) conn.Close();
            }


            return retPerson;
        }



    }
}

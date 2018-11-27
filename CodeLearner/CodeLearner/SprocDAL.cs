using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLearner {
   static class  SprocDAL {

        private static string ConnectionString {
            get {
                return DAL.ConnectionString;
            }
        }

        public static List<Person> GetPeople() {
            List<Person> peops = new List<Person>();
            SqlConnection conn = null;
            try {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand comm =new SqlCommand();
                //comm.CommandText = "SELECT * FROM People";
                comm.CommandText = "sprocPeopleGetAll";
                comm.CommandType = System.Data.CommandType.StoredProcedure;
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
                    p.PreFix = (string)dr["PreFix"];
                    p.PostFix = (string)dr["PostFix"];
                    p.HomePage = (String)dr["HomePage"];
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

                //String qry = "SELECT * FROM People WHERE PersonID = @ID";
                SqlCommand comm = new SqlCommand("sprocPersonGet",conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sPara = new SqlParameter();
                sPara.ParameterName = "PersonID";
                sPara.Value = id;
                comm.Parameters.Add(sPara);

                //comm.Parameters.AddWithValue("@PersonID", id);

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
                    retPerson.PreFix = (string)dr["PreFix"];
                    retPerson.PostFix = (string)dr["PostFix"];
                    retPerson.HomePage = (String)dr["HomePage"];
                }
            } catch (Exception ex) {
            } finally {
                if (conn != null) conn.Close();
            }


            return retPerson;
        }

        public static int AddPerson(Person p) {
            int retInt = -1; // Did I pass
            SqlConnection conn = null;
            try {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                
                SqlCommand comm = new SqlCommand("sproc_PersonAdd", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@FirstName",p.FirstName);
                comm.Parameters.AddWithValue("@LastName", p.LastName);
                comm.Parameters.AddWithValue("@DateOfBirth", p.DateOfBirth);
                comm.Parameters.AddWithValue("@IsManager", p.IsManager);
                comm.Parameters.AddWithValue("@Email", p.Email);
                comm.Parameters.AddWithValue("@Phone", p.Phone);
                comm.Parameters.AddWithValue("@PreFix", p.PreFix);
                comm.Parameters.AddWithValue("@PostFix", p.PostFix);
                comm.Parameters.AddWithValue("@HomePage", p.HomePage);
                //comm.Connection = conn;

                int affectedRows = comm.ExecuteNonQuery();
                retInt = affectedRows;

            } catch (Exception ex) {
            } finally {
                if (conn != null) conn.Close();
            }


            return retInt;
        }

    }
}

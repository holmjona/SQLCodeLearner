﻿using System;
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
                    retPerson.Prefix = (string)dr["PreFix"];
                    retPerson.Postfix = (string)dr["PostFix"];
                    retPerson.Homepage = (String)dr["HomePage"];
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
                comm.Parameters.AddWithValue("@PreFix", p.Prefix);
                comm.Parameters.AddWithValue("@PostFix", p.Postfix);
                comm.Parameters.AddWithValue("@HomePage", p.Homepage);
                //comm.Connection = conn;

                SqlParameter outID = new SqlParameter();
                outID.ParameterName = "@PersonID";
                outID.DbType = System.Data.DbType.Int32;
                outID.Direction = System.Data.ParameterDirection.Output;
                comm.Parameters.Add(outID);

                int affectedRows = comm.ExecuteNonQuery();
                retInt = affectedRows;

                p.ID = (int)outID.Value;

            } catch (Exception ex) {
            } finally {
                if (conn != null) conn.Close();
            }


            return retInt;
        }

       
        internal enum dbAction {
            Read,
            Edit
        }

        #region Database Connections
        internal static void ConnectToDatabase(SqlCommand comm, dbAction action = dbAction.Read) {
            try {
              
                    comm.Connection = new SqlConnection(ConnectionString);

                comm.CommandType = System.Data.CommandType.StoredProcedure;
            } catch (Exception ex) { }
        }
        public static SqlDataReader GetDataReader(SqlCommand comm) {
            try {
                ConnectToDatabase(comm);
                comm.Connection.Open();
                return comm.ExecuteReader();
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }


        internal static int AddObject(SqlCommand comm, string parameterName) {
            int retInt = 0;
            try {
                comm.Connection = new SqlConnection(ConnectionString);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Connection.Open();
                SqlParameter retParameter;
                retParameter = comm.Parameters.Add(parameterName, System.Data.SqlDbType.Int);
                retParameter.Direction = System.Data.ParameterDirection.Output;
                comm.ExecuteNonQuery();
                retInt = (int)retParameter.Value;
                comm.Connection.Close();
            } catch (Exception ex) {
                if (comm.Connection != null)
                    comm.Connection.Close();

                retInt = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return retInt;
        }


        /// <summary>
        /// Sets Connection and Executes given comm on the database
        /// </summary>
        /// <param name="comm">SQLCommand to execute</param>
        /// <returns>number of rows affected; -1 on failure, positive value on success.</returns>
        /// <remarks>Must make sure to populate the command with sqltext and any parameters before passing to this function.
        ///       Edit Connection is set here.</remarks>
        internal static int UpdateObject(SqlCommand comm) {
            int retInt = 0;
            try {
                comm.Connection = new SqlConnection(ConnectionString);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Connection.Open();
                retInt = comm.ExecuteNonQuery();
                comm.Connection.Close();
            } catch (Exception ex) {
                if (comm.Connection != null)
                    comm.Connection.Close();

                retInt = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return retInt;
        }
        #endregion

        #region Person
        /// <summary>
        /// Gets the SQLCode.Person correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Person GetPerson(String idstring, Boolean retNewObject) {
            Person retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID)) {
                if (ID == -1 && retNewObject) {
                    retObject = new Person();
                    retObject.ID = -1;
                } else if (ID >= 0) {
                    retObject = GetPerson(ID);
                }
            }
            return retObject;
        }


      

        /// <summary>
        /// Gets a list of all SQLCode.Person objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Person> GetPersons() {
            SqlCommand comm = new SqlCommand("sprocPeoplesGetAll");
            List<Person> retList = new List<Person>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retList.Add(new Person(dr));
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }




        


        /// <summary>
        /// Attempts to the database entry corresponding to the given Person
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdatePerson(Person obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_PersonUpdate");
            try {
                comm.Parameters.AddWithValue("@" + Person.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + Person.db_FirstName, obj.FirstName);
                comm.Parameters.AddWithValue("@" + Person.db_LastName, obj.LastName);
                comm.Parameters.AddWithValue("@" + Person.db_DateOfBirth, obj.DateOfBirth);
                comm.Parameters.AddWithValue("@" + Person.db_IsManager, obj.IsManager);
                comm.Parameters.AddWithValue("@" + Person.db_Prefix, obj.Prefix);
                comm.Parameters.AddWithValue("@" + Person.db_Postfix, obj.Postfix);
                comm.Parameters.AddWithValue("@" + Person.db_Phone, obj.Phone);
                comm.Parameters.AddWithValue("@" + Person.db_Email, obj.Email);
                comm.Parameters.AddWithValue("@" + Person.db_Homepage, obj.Homepage);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the Person
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Removing items from the database should really just archive them.")]
        internal static int RemovePerson(Person obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try {
                //comm.CommandText = //Insert Sproc Name Here;
                comm.Parameters.AddWithValue("@" + Person.db_ID, obj.ID);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        #endregion


        #region ProjectType
        /// <summary>
        /// Gets the SQLCode.ProjectType correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static ProjectType GetProjectType(String idstring, Boolean retNewObject) {
            ProjectType retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID)) {
                if (ID == -1 && retNewObject) {
                    retObject = new ProjectType();
                    retObject.ID = -1;
                } else if (ID >= 0) {
                    retObject = GetProjectType(ID);
                }
            }
            return retObject;
        }


        /// <summary>
        /// Gets the SQLCode.ProjectTypecorresponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static ProjectType GetProjectType(int id) {
            SqlCommand comm = new SqlCommand("sprocProjectTypeGet");
            ProjectType retObj = null;
            try {
                comm.Parameters.AddWithValue("@" + ProjectType.db_ID, id);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retObj = new ProjectType(dr);
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retObj;
        }


        /// <summary>
        /// Gets a list of all SQLCode.ProjectType objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<ProjectType> GetProjectTypes() {
            SqlCommand comm = new SqlCommand("sprocProjectTypesGetAll");
            List<ProjectType> retList = new List<ProjectType>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retList.Add(new ProjectType(dr));
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }




        /// <summary>
        /// Attempts to add a database entry corresponding to the given ProjectType
        /// </summary>
        /// <remarks></remarks>

        internal static int AddProjectType(ProjectType obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_ProjectTypeAdd");
            try {
                comm.Parameters.AddWithValue("@" + ProjectType.db_Name, obj.Name);
                return AddObject(comm, "@" + ProjectType.db_ID);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to the database entry corresponding to the given ProjectType
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdateProjectType(ProjectType obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_ProjectTypeUpdate");
            try {
                comm.Parameters.AddWithValue("@" + ProjectType.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + ProjectType.db_Name, obj.Name);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the ProjectType
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Removing items from the database should really just archive them.")]
        internal static int RemoveProjectType(ProjectType obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try {
                //comm.CommandText = //Insert Sproc Name Here;
                comm.Parameters.AddWithValue("@" + ProjectType.db_ID, obj.ID);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        #endregion


        #region Project
        /// <summary>
        /// Gets the SQLCode.Project correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Project GetProject(String idstring, Boolean retNewObject) {
            Project retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID)) {
                if (ID == -1 && retNewObject) {
                    retObject = new Project();
                    retObject.ID = -1;
                } else if (ID >= 0) {
                    retObject = GetProject(ID);
                }
            }
            return retObject;
        }


        /// <summary>
        /// Gets the SQLCode.Projectcorresponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Project GetProject(int id) {
            SqlCommand comm = new SqlCommand("sprocProjectGet");
            Project retObj = null;
            try {
                comm.Parameters.AddWithValue("@" + Project.db_ID, id);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retObj = new Project(dr);
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retObj;
        }


        /// <summary>
        /// Gets a list of all SQLCode.Project objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Project> GetProjects() {
            SqlCommand comm = new SqlCommand("sprocProjectsGetAll");
            List<Project> retList = new List<Project>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retList.Add(new Project(dr));
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }

        /// <summary>
        /// Gets a list of all SQLCode.Project objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Project> GetProjects(ProjectType pt) {
            SqlCommand comm = new SqlCommand("sprocProjectsGetForType");
            List<Project> retList = new List<Project>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ProjectTypeID", pt.ID);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    Project p = new Project(dr);
                    p.ProjectType = pt;
                    retList.Add(p);
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }

        /// <summary>
        /// Gets a list of all SQLCode.Project objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Project> GetProjects(Person pr) {
            SqlCommand comm = new SqlCommand("sprocProjectsGetForPerson");
            List<Project> retList = new List<Project>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                comm.Parameters.AddWithValue("@PersonID", pr.ID);
                while (dr.Read()) {
                    retList.Add(new Project(dr));
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }


        /// <summary>
        /// Attempts to add a database entry corresponding to the given Project
        /// </summary>
        /// <remarks></remarks>

        internal static int AddProject(Project obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_ProjectAdd");
            try {
                comm.Parameters.AddWithValue("@" + Project.db_Name, obj.Name);
                comm.Parameters.AddWithValue("@" + Project.db_ProjectType, obj.ProjectTypeID);
                comm.Parameters.AddWithValue("@" + Project.db_DateStarted, obj.DateStarted);
                comm.Parameters.AddWithValue("@" + Project.db_DateEnded, obj.DateEnded);
                return AddObject(comm, "@" + Project.db_ID);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to the database entry corresponding to the given Project
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdateProject(Project obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_ProjectUpdate");
            try {
                comm.Parameters.AddWithValue("@" + Project.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + Project.db_Name, obj.Name);
                comm.Parameters.AddWithValue("@" + Project.db_ProjectType, obj.ProjectTypeID);
                comm.Parameters.AddWithValue("@" + Project.db_DateStarted, obj.DateStarted);
                comm.Parameters.AddWithValue("@" + Project.db_DateEnded, obj.DateEnded);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the Project
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Removing items from the database should really just archive them.")]
        internal static int RemoveProject(Project obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try {
                //comm.CommandText = //Insert Sproc Name Here;
                comm.Parameters.AddWithValue("@" + Project.db_ID, obj.ID);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        #endregion


        #region ProjectPerson
        /// <summary>
        /// Gets the SQLCode.ProjectPerson correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static ProjectPerson GetProjectPerson(String idstring, Boolean retNewObject) {
            ProjectPerson retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID)) {
                if (ID == -1 && retNewObject) {
                    retObject = new ProjectPerson();
                    retObject.ID = -1;
                } else if (ID >= 0) {
                    retObject = GetProjectPerson(ID);
                }
            }
            return retObject;
        }


        /// <summary>
        /// Gets the SQLCode.ProjectPersoncorresponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static ProjectPerson GetProjectPerson(int id) {
            SqlCommand comm = new SqlCommand("sprocProjectPersonGet");
            ProjectPerson retObj = null;
            try {
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_ID, id);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retObj = new ProjectPerson(dr);
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retObj;
        }


        /// <summary>
        /// Gets a list of all SQLCode.ProjectPerson objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<ProjectPerson> GetProjectPersons() {
            SqlCommand comm = new SqlCommand("sprocProjectPersonsGetAll");
            List<ProjectPerson> retList = new List<ProjectPerson>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retList.Add(new ProjectPerson(dr));
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }

        /// <summary>
        /// Gets a list of all SQLCode.ProjectPerson objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<ProjectPerson> GetProjectPersons(Project pj) {
            SqlCommand comm = new SqlCommand("sprocPeopleForProject");
            List<ProjectPerson> retList = new List<ProjectPerson>();
            try {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    retList.Add(new ProjectPerson(dr));
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }

        /// <summary>
        /// Gets a list of all SQLCode.ProjectPerson objects from the database for
        /// a given project.
        /// </summary>
        /// <remarks></remarks>
        public static List<ProjectPerson> GetProjectPerson(Project p) {
            SqlCommand comm = new SqlCommand("sprocProjectPersonsGetForProject");
            List<ProjectPerson> retList = new List<ProjectPerson>();
            try {
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_Project, p.ID);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    ProjectPerson pp = new ProjectPerson(dr);
                    pp.Person = new Person(dr);
                    pp.Project = p;
                    retList.Add(pp);
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }

        /// <summary>
        /// Gets a list of all SQLCode.ProjectPerson objects from the database for
        /// a given Person.
        /// </summary>
        /// <remarks></remarks>
        public static List<ProjectPerson> GetProjectPerson(Person p) {
            SqlCommand comm = new SqlCommand("sprocProjectPersonsGetForPerson");
            List<ProjectPerson> retList = new List<ProjectPerson>();
            try {
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_Person, p.ID);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read()) {
                    ProjectPerson pp = new ProjectPerson(dr);
                    pp.Project = new Project(dr);
                    pp.Person = p;
                    retList.Add(pp);
                }
                comm.Connection.Close();
            } catch (Exception ex) {
                comm.Connection.Close();
            }
            return retList;
        }




        /// <summary>
        /// Attempts to add a database entry corresponding to the given ProjectPerson
        /// </summary>
        /// <remarks></remarks>

        internal static int AddProjectPerson(ProjectPerson obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_ProjectPersonAdd");
            try {
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_Project, obj.ProjectID);
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_Person, obj.Person);
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_DateAssigned, obj.DateAssigned);
                return AddObject(comm, "@" + ProjectPerson.db_ID);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to the database entry corresponding to the given ProjectPerson
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdateProjectPerson(ProjectPerson obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_ProjectPersonUpdate");
            try {
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_Project, obj.ProjectID);
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_Person, obj.Person);
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_DateAssigned, obj.DateAssigned);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the ProjectPerson
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Removing items from the database should really just archive them.")]
        internal static int RemoveProjectPerson(ProjectPerson obj) {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try {
                //comm.CommandText = //Insert Sproc Name Here;
                comm.Parameters.AddWithValue("@" + ProjectPerson.db_ID, obj.ID);
                return UpdateObject(comm);
            } catch (Exception ex) {
            }
            return -1;
        }


        #endregion



    }
}

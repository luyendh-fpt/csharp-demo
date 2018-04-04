using System;
using MySql.Data.MySqlClient;

namespace HelloCSharp
{
    class DbConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DbConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "mydata_demo";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";CharSet=utf8;";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Error");
                        break;

                    case 1045:
                        Console.WriteLine("Error");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Message);
                return false;
            }
        }

        public bool Insert(Student student)
        {
            string query = "INSERT INTO students (name, rollNumber) VALUES ('" + student.Name + "', '" + student.RollNumber + "')";
            //open connection
            if (this.OpenConnection() == true)
            {
                try{
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                    return true;
                }catch(Exception ex){
                    Console.WriteLine("Error " + ex.Message);
                }
            }
            return false;
        }
                       
        static void Main(string[] args)
        {
            DbConnection p = new DbConnection();
            Student student = new Student("Tạ Quốc Đạt", "D00123");
            p.Insert(student);
        }
    }
}

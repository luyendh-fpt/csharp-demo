using System;
using MySql.Data.MySqlClient;

namespace HelloCSharp
{
    public class StudentModel
    {
        private DbConnection dbConnection = new DbConnection();

        public StudentModel()
        {
        }

        public bool Insert(Student student)
        {
            string query = "INSERT INTO students (name, rollNumber) VALUES ('" + student.Name + "', '" + student.RollNumber + "')";
            //open connection
            if (dbConnection.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    dbConnection.CloseConnection();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
            return false;
        }
        // Lấy danh sách student
    	public voajskdjaskldasjid Query(){
    		Console.WriteLine("Query from database.");
    	}
    }
}

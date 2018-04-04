using System;
using System.Collections.Generic;
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
        public List<Student> Query(){
            List<Student> list = new List<Student>();
            String query = "select * from students;";
            if(dbConnection.OpenConnection()){
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    MySqlDataReader reader =  cmd.ExecuteReader();
                    while(reader.Read()){
                        int id = reader.GetInt16("id");
                        String name = reader.GetString("name");
                        String rollNumber = reader.GetString("rollNumber");
                        Student st = new Student(id, name, rollNumber);
                        list.Add(st);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    		Console.WriteLine("Query from database.");
            return list;
    	}

        public void update(){
            
        }
    }
}

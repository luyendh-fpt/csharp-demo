using System;
namespace HelloCSharp
{
    public class Student
    {

        private int id;
        private string name;
        private string rollNumber;

        public Student()
        {
        }

        public Student(string name, string rollNumber)
        {
            this.name = name;
            this.rollNumber = rollNumber;
        }

        public Student(int id, string name, string rollNumber)
        {
            this.id = id;
            this.name = name;
            this.rollNumber = rollNumber;
        }

        public override string ToString(){
            return this.name + " - " + this.rollNumber;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string RollNumber { get => rollNumber; set => rollNumber = value; }
    }
}

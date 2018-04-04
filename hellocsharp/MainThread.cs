using System;
namespace HelloCSharp
{
    public class MainThread
    {
        public MainThread()
        {
        }

        static void Main(string[] args)
        {
            StudentModel model = new StudentModel();
            Student student = new Student("Lộc", "D00124");
            model.Insert(student);
        }
    }
}

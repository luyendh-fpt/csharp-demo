using System;
namespace hellocsharp
{
    public class HelloC
    {
        private string name;
        private string rollNumber;

        public HelloC()
        {
        }

        public string Name { get => name; set => name = value; }
        public string RollNumber { get => rollNumber; set => rollNumber = value; }

    }
}

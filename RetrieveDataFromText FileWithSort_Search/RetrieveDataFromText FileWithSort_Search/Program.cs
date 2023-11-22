using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveDataFromText_FileWithSort_Search
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // File path containing student data
            string filePath = "D:\\.net projects\\practice project-3\\RetrieveDataFromText FileWithSort_Search/student_data.txt";

            // Read student data from the file
            List<Student> students = ReadStudentData(filePath);

            if (students.Count == 0)
            {
                Console.WriteLine("No student data found.");
                return;
            }
            Console.WriteLine("UnSorted (or)Retrieved Data:");
            foreach (var studentData in students)
            {
                
                Console.WriteLine($"Name: { studentData.Name} Class:{ studentData.Class}");
            }
            Console.WriteLine("-----------------------------------------------------------");
            // Sort students by name
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.Ordinal));

            // Display sorted student data
            DisplayStudentData(students);
            Console.WriteLine("-----------------------------------------------------------");
            // Allow searching by name
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();

            Student foundStudent = SearchStudentByName(students, searchName);

            if (foundStudent != null)
            {
                Console.WriteLine("Student found: " + foundStudent.Name + ", Class: " + foundStudent.Class);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.ReadKey();
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        students.Add(new Student { Name = parts[0].Trim(), Class = parts[1].Trim() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading student data: " + ex.Message);
            }

            return students;
        }

        static void DisplayStudentData(List<Student> students)
        {
            Console.WriteLine("Sorted Student Data:");

            foreach (Student student in students)
            {
                Console.WriteLine("Name: " + student.Name + ", Class: " + student.Class);
            }
        }

        static Student SearchStudentByName(List<Student> students, string searchName)
        {
            return students.FirstOrDefault(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }
    }

   
}


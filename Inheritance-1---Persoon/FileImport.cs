using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1___Persoon
{
    public static class FileImport
    {
        public static List<Lector> ReadLector(string bestand)
        {
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
                throw new FileNotFoundException();

            List<Lector> lectors = new List<Lector>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');
                    Lector lect = new Lector()
                    {
                        Name = data[0],
                        FirstName = data[1],
                        BirthDate = DateTime.Parse(data[2]),
                        Street = data[3],
                        ZipCode = data[4],
                        Statute = data[5],
                        Department = data[6],
                        InService = DateTime.Parse(data[7])
                    };
                    lectors.Add(lect);
                }
            }
            return lectors;
        }

        public static List<Student> ReadStudent(string bestand)
        {
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
                throw new FileNotFoundException();

            List<Student> students = new List<Student>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');
                    Student stud = new Student()
                    {
                        Name = data[0],
                        FirstName = data[1],
                        Street = data[2],
                        ZipCode = data[3],
                        Paid = data[4][0], // dit is 1 char, dus 0de char van string is genoeg
                        Course = data[5],
                        StudentType = data[6]
                    };

                    if (stud.StudentType.Equals("I"))
                        stud.StudyPoints = int.Parse(data[7]);

                    students.Add(stud);
                }
            }

            return students;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1___Persoon
{
    public class Student : Person
    {
        // Read-­only properties (enkel get), hier als expression-bodied properties (=> notatie)
        private int studyPoints;

        public DateTime StartDate { get; set; }
        public char Paid { get; set; }
        public string StudentType { get; set; }
        public string Course { get; set; }
        public int StudyPoints
        {
            get { return studyPoints; }
            set
            {
                if (value < 0)
                    studyPoints = 0;
                else if (studyPoints > 99)
                    studyPoints = 99;
                else
                    studyPoints = value;
            }
        }
        public float SubscriptionAmount => (StudentType.Equals("I")) ? (50.0f + (8.666667f * studyPoints)) : 520.0f;
        public override string Data => $"{FullName()} - {StudentType} - {Paid} - {SubscriptionAmount:c}"; // eigen implementatie (override)

        public string PrintStartDate() => $"{FullName()} | {StartDate}";
        public string PrintAddress() => $"{FullName()}  {Street} {ZipCode}";

        // Read-­only properties (enkel get), hier als expression-bodied properties (=> notatie)
        public override string InfoHeader => "Info student"; // eigen implementatie (override)

        public Student() : base() // constructor van de base class eerst oproepen
        {
            StartDate = DateTime.Now;
        }

        public override string ToString()
            =>
                $"{FirstName} {Name} "
                +
                ((StudentType.Equals("I"))
                    ? $"Student met individueel traject: {StudyPoints} SP"
                    : $"Standaardstudent: 60 SP")
                +
                $"- Inschrijvingsgeld: {SubscriptionAmount:c} : Betaald: {Paid}";
    }
}

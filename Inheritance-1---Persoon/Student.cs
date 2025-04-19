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

        // Auto-implemented properties (zowel get als set)
        public char Paid { get; set; }
        public override string Data => $"{FullName()} - {StudentType} - {Paid} - {SubscriptionAmount:c}"; // eigen implementatie (override)
        public float SubscriptionAmount => (StudentType.Equals("I")) ? (50.0f + (8.666667f * studyPoints)) : 520.0f;
        public string Course { get; set; }
        public DateTime StartDate { get; set; }
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
        public string StudentType { get; set; }

        // Expression-bodied methods (=> notatie om te returnen)
        public string PrintAddress() => $"{FullName()}  {Street} {ZipCode}";
        public string PrintStartDate() => $"{FullName()} | {StartDate}";

        // Read-­only properties (enkel get), hier als expression-bodied properties (=> notatie)
        protected override string InfoHeader => "Gegevens van de student:\r\n\r\n"; // eigen implementatie (override)

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

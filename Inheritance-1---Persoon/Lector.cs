using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1___Persoon
{
    public class Lector : Person
    {
        private string department;
        public string Department
        {
            get { return department; }
            set { department = DepartmentName(value); }
        }
        public override string Data => $"{FullName()} - {Statute} - {Department}";
        public DateTime InService { get; set; }
        public string Statute { get; set; }

        private string DepartmentName(string dept)
        {
            switch (dept)
            {
                case "SNE":
                    return "Systemen en netwerken";
                case "PRO":
                    return "Programmeren";
                case "IOT":
                    return "Internet of things";
                case "DVG":
                    return "Digitale vormgeving";
            }
            return "Onbekende afdeling";
        }

        public string PrintAddress() => $"{FullName()}  {Street} {ZipCode}";
        public string AfdrukIndienst() => $"{FullName()} is in dienst sinds: {InService.ToShortDateString()}";
        protected override string InfoHeader => "Gegevens van de lector:\r\n\r\n";

        public Lector() : base()
        {
        }

        public override string ToString()
            => (Statute.Equals("DT")) ? "Lector is deeltijds actief" : "Lector is voltijds actief";
    }
}

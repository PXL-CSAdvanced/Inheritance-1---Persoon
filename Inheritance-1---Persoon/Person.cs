using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1___Persoon
{
    public class Person
    {
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        // Read­-only property
        public virtual string Data => $"{FullName()}\r\nGeboortedatum:{BirthDate.ToLongDateString()}";
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string FirstName { get; set; }

        protected virtual string InfoHeader => "Uw persoonlijke gegevens:\r\n\r\n";

        public string Info()
            => $"{InfoHeader}Naam: {FirstName} {Name}\r\n" +
            $"Adres: {Street} {ZipCode}\r\nGeboortedatum: {BirthDate.ToLongDateString()}\r\nE-mail: {Email}";

        public Person()
        {
            FirstName = "Hogeschool";
            Name = "PXL";
            Street = "Elfde ­Liniestraat 26";
            ZipCode = "3500";
            BirthDate = new DateTime(1992, 1, 12);
        }

        //public void Info() => System.Windows.MessageBox.Show(
        //            $"{InfoHeader}Naam: {Voornaam} {Naam}\r\n" +
        //            $"Adres: {Straat} {Postcode}\r\nGeboortedatum: {Geboortedatum.ToLongDateString()}\r\nE-mail: {Email}",
        //            "Info Klasse Persoon",
        //            System.Windows.MessageBoxButton.OK,
        //            System.Windows.MessageBoxImage.Information);
        public string FullName() => $"{FirstName} {Name}";
    }
}

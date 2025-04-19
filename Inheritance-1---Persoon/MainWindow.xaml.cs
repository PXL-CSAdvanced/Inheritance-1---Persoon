using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inheritance_1___Persoon;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void StudentButton_Click(object sender, RoutedEventArgs e)
    {
        InfoListBox.Items.Clear();
        try
        {
            List<Student> studenten = FileImport.ReadStudent(@"..\..\..\Bestanden\Studenten.csv");
            foreach (var student in studenten)
            {
                InfoListBox.Items.Add(student.ToString());
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Kan bestand Studenten.csv niet lezen!",
                "Fout",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    private void LectorButton_Click(object sender, RoutedEventArgs e)
    {
        Person p = new Person();
        p.Name = "Janssen";
        InfoListBox.Items.Clear();
        try
        {
            List<Lector> lectoren = FileImport.ReadLector(@"..\..\..\Bestanden\Lectoren.csv");
            foreach (var lector in lectoren)
            {
                InfoListBox.Items.Add(lector.Data);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Kan bestand Lectoren.csv niet lezen!",
                "Fout",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    private void PersonButton_Click(object sender, RoutedEventArgs e)
    {
        Person persoon = new Person();
        // Alle gegevens van de persoon zitten in de constructor maar 
        // enkel het e­mailadres moet uit het tekstvak opgehaald worden.
        // Controle
        if (Validator.IsPresent(EmailTextBox.Text) && Validator.IsValidEmail(EmailTextBox.Text))
        {
            persoon.Email = EmailTextBox.Text;
            MessageBox.Show(persoon.Info(),
                "Info Klasse Persoon",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }

    private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        EmailTextBox.Text = string.Empty;
    }
}
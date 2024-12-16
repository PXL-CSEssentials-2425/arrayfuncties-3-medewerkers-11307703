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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Medewerkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _employees = { "Kristof", "Sander", "Koen" };
        private string[] _employeeNumbers = { "M01", "M02", "M03" };
        private decimal[] _salaries = { 0, 0, 0 };
        StringBuilder _sb = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            salaryTextBox.IsEnabled = false;
            updateButton.IsEnabled = false;
            OutPut();
        }

        private void OutPut()
        { 
            namenListBox.Items.Clear();
            for (int i = 0; i < _employeeNumbers.Length; i++)
            {
              _sb.AppendLine($"{_employeeNumbers[i]} - {_employees[i]} - {_salaries[i]:c}");
              string result = _sb.ToString();
              ListBoxItem item = new ListBoxItem();
              item.Content = result;
              namenListBox.Items.Add(result);
              _sb.Clear();
            } 
        }

        private void namenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = namenListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < _salaries.Length)
            {
                updateButton.IsEnabled = true;
                salaryTextBox.IsEnabled = true;
                salaryTextBox.Text = _salaries[selectedIndex].ToString();
            }
            else
            {
                updateButton.IsEnabled = false;
                salaryTextBox.IsEnabled = false;
                salaryTextBox.Clear();
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(salaryTextBox.Text, out decimal number)) 
            {
                errorLabel.Content = "Kan tekst niet omzetten naar salaris";
            }
             else if (namenListBox.SelectedIndex != -1)
            {
                int amount = namenListBox.SelectedIndex;
                _salaries[amount] = decimal.Parse(salaryTextBox.Text);
            }
         
            OutPut();


            salaryTextBox.Clear();
            salaryTextBox.IsEnabled = false;
            updateButton.IsEnabled = false;
        }
    }
}
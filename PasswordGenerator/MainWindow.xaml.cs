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
using PasswordGenerator;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            bool useSymbols = (bool)chkSpecialCharacters.IsChecked ? true : false;
            bool useUpper = (bool)chkUpperCase.IsChecked ? true : false;
            bool useLower = (bool)chkLowerCase.IsChecked ? true : false;
            bool useNumbers = (bool)chkNumbers.IsChecked ? true : false;

            int length = int.Parse(txtPasswordLength.Text);

            HideOptions();

            string password = Generate.GetPassword(length, useSymbols, useUpper, useLower, useNumbers);

            txtPassword.Text = password;
        }

        private void HideOptions()
        {
            lblPassword.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            btnGenerate.Visibility = Visibility.Hidden;
            lblPasswordLength.Visibility = Visibility.Hidden;
            txtPasswordLength.Visibility = Visibility.Hidden;
            chkSpecialCharacters.Visibility = Visibility.Hidden;
            chkUpperCase.Visibility = Visibility.Hidden;
            chkLowerCase.Visibility = Visibility.Hidden;
            chkNumbers.Visibility = Visibility.Hidden;
        }
    }
}
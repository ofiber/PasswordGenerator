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

            if(!useSymbols && !useUpper && !useLower && !useNumbers)
            {
                MessageBox.Show("Please select at least one option.");
                return;
            }

            int length = int.Parse(txtPasswordLength.Text);

            HideOptions();

            string password = Generate.GetPassword(length, GetNumOptions(), useSymbols, useUpper, useLower, useNumbers);

            txtPassword.Text = password;

            if(txtPassword.Width < (10 * password.Length) + 4)
                txtPassword.Width = (10 * password.Length) + 4;
        }

        private void HideOptions()
        {
            lblPassword.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            btnCopy.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            btnGenerate.Visibility = Visibility.Hidden;
            lblPasswordLength.Visibility = Visibility.Hidden;
            txtPasswordLength.Visibility = Visibility.Hidden;
            chkSpecialCharacters.Visibility = Visibility.Hidden;
            chkUpperCase.Visibility = Visibility.Hidden;
            chkLowerCase.Visibility = Visibility.Hidden;
            chkNumbers.Visibility = Visibility.Hidden;
        }

        private void ShowOptions()
        {
            lblPassword.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            btnCopy.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Hidden;
            btnGenerate.Visibility = Visibility.Visible;
            lblPasswordLength.Visibility = Visibility.Visible;
            txtPasswordLength.Visibility = Visibility.Visible;
            chkSpecialCharacters.Visibility = Visibility.Visible;
            chkUpperCase.Visibility = Visibility.Visible;
            chkLowerCase.Visibility = Visibility.Visible;
            chkNumbers.Visibility = Visibility.Visible;

            txtPassword.Text = "";
            txtPassword.Width = 100;

            txtPasswordLength.Text = "";
            chkSpecialCharacters.IsChecked = false;
            chkUpperCase.IsChecked = false;
            chkLowerCase.IsChecked = false;
            chkNumbers.IsChecked = false;
        }

        private int[] GetNumOptions()
        {
            int[] numOptions = new int[4];

            if (chkLowerCase.IsChecked == true)
                numOptions[0] = 1;

            if(chkUpperCase.IsChecked == true)
                numOptions[1] = 1;

            if(chkNumbers.IsChecked == true)
                numOptions[2] = 1;

            if(chkSpecialCharacters.IsChecked == true)
                numOptions[3] = 1;

            return numOptions;
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtPassword.Text);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowOptions();
            Clipboard.Clear();
        }
    }
}
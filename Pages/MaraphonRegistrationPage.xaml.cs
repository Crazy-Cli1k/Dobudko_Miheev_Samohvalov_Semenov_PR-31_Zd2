using MaraphonSkills.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для MaraphonRegistrationPage.xaml
    /// </summary>
    public partial class MaraphonRegistrationPage : Page,INotifyPropertyChanged
    {
        private Runner userInSystem;
        Core.MarathonEntities context;
        private int totalPrice=0;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                RaisePropertyChanged();
            }
        }
        public List<string> TypesOfMarathon { get; set; } = new List<string>() { "5km (25 руб.)", "21km (75 руб.)", "42km (145 руб.)" };
        public MaraphonRegistrationPage()
        {
            context = new Core.MarathonEntities();
            userInSystem = context.Runner.FirstOrDefault(x => x.Email == Properties.Settings.Default.currentUserEmail);
            DataContext = this;
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вы успешно зарегестрированы","Успех");
            this.NavigationService.GoBack();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            switch (TypesOfMarathon.IndexOf(checkBox.Content.ToString()))
            {
                case 0:
                    TotalPrice += 25;
                    break;
                case 1:
                    TotalPrice += 75;
                    break;
                case 2:
                    TotalPrice += 145;
                    break;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            switch (TypesOfMarathon.IndexOf(checkBox.Content.ToString()))
            {
                case 0:
                    TotalPrice -= 25;
                    break;
                case 1:
                    TotalPrice -= 75;
                    break;
                case 2:
                    TotalPrice -= 145;
                    break;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            TotalPrice += int.Parse(radioButton.Tag.ToString());
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            TotalPrice -= int.Parse(radioButton.Tag.ToString());
        }
    }
}

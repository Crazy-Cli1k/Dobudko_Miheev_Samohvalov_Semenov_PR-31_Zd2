using MaraphonSkills.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        private Runner userInSystem;
        Core.MarathonEntities context;
        public ResultsPage()
        {
            context = new Core.MarathonEntities();
            userInSystem = context.Runner.FirstOrDefault(x => x.Email == Properties.Settings.Default.currentUserEmail);
            DataContext = userInSystem.RunnerMarathon;
            InitializeComponent();
        }

        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

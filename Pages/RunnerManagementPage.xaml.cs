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
    /// Логика взаимодействия для RunnerManagementPage.xaml
    /// </summary>
    public partial class RunnerManagementPage : Page
    {
        MarathonEntities context;
        public Runner Runner { get; set; }
        private RunnerMarathon runnerMarathon;
        public RunnerManagementPage(RunnerMarathon runnerMar)
        {
            context = new MarathonEntities();
            this.Runner = runnerMar.Runner;
            runnerMarathon = runnerMar;
            InitializeComponent();
            this.DataContext = this;
        }

        private void ProfileEditButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ShowSertificateButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SertificatePage(runnerMarathon));
        }
    }
}

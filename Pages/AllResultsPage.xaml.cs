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
    /// Логика взаимодействия для AllResultsPage.xaml
    /// </summary>
    public partial class AllResultsPage : Page
    {
        List<RunnerMarathon> dataGridContent;
        MarathonEntities context;
        public AllResultsPage()
        {
            context = new MarathonEntities();
            InitializeComponent();
            dataGridContent = context.RunnerMarathon.ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;

            MarathonComboBox.ItemsSource = context.user3.ToList();
            MarathonComboBox.SelectedValuePath = "MarathonId";
            MarathonComboBox.DisplayMemberPath = "MarathonName";

            GenderCombobox.ItemsSource = context.Gender.ToList();
            GenderCombobox.SelectedValuePath = "Gender1";
            GenderCombobox.DisplayMemberPath = "Gender1";

            TotalRunnersLabel.Content = String.Format("Всего бегунов: {0}", context.RunnerMarathon.Count());
            FinishingRunnersLabel.Content = String.Format("Всего бегунов финишировало: {0}", context.RunnerMarathon.Where(rm => rm.Position != null).Count());

            long ticks = 0;
            int count = 0;

            var avertime = context.RunnerMarathon.Select(rm => rm.Time).ToList();
            foreach (var item in avertime)
            {
                if (item != null)
                {
                    TimeSpan tempTs = (TimeSpan)item;
                    ticks += tempTs.Ticks;
                    count++;
                }

            }

            TimeSpan ts = new TimeSpan(ticks / count);



            AverageTimeLabel.Content = String.Format("Среднее время: 0{0}:{1}:{2}", ts.Hours, ts.Minutes, ts.Seconds);
        }
        private void DataGridSearchButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dataGridContent = context.RunnerMarathon.ToList();
            if (MarathonComboBox.SelectedValue != null)
            {
                MarathonFilter();
            }
            //CategoryFilter();
            if (GenderCombobox.SelectedValue != null)
            {
                GenderFilter();
            }
        }

        private void MarathonFilter()
        {
            int selectedMarathon = Convert.ToInt32(MarathonComboBox.SelectedValue);
            dataGridContent = dataGridContent.Where(x => x.MarathonId == selectedMarathon).ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;
            TotalRunnersLabel.Content = String.Format("Всего бегунов {0}", RunnersDataGrid.Items.Count - 1);
        }

        //private void CategoryFilter()
        //{
        //    int selectedMarathon = Convert.ToInt32(CategoryComboBox.SelectedValue);
        //    dataGridContent = dataGridContent.Where(x => x. == selectedMarathon).ToList();
        //    RunnersDataGrid.ItemsSource = dataGridContent;
        //    TotalRunnersLabel.Content = String.Format("Всего бегунов {0}", context.RunnerMarathon.Where(x => x.MarathonId == selectedMarathon).Count());
        //}

        private void GenderFilter()
        {
            string selectedMarathon = GenderCombobox.SelectedValue.ToString();
            dataGridContent = dataGridContent.Where(x => x.Runner.Gender1.Gender1 == selectedMarathon).ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;
            TotalRunnersLabel.Content = String.Format("Всего бегунов {0}", RunnersDataGrid.Items.Count - 1);
        }
    }
}

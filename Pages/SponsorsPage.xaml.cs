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
    /// Логика взаимодействия для SponsorsPage.xaml
    /// </summary>
    public partial class SponsorsPage : Page
    {
        Core.MarathonEntities context;
        public List<Core.Sponsor> Sponsors { get; set;}
        public decimal TotalPrice { 
            get
            {
                return Sponsors.Sum(x => x.Amount);
            } 
        }
        public SponsorsPage()
        {
            context=new Core.MarathonEntities();
            Sponsors = context.Sponsor.ToList();
            DataContext = this;
            InitializeComponent();
        }
    }
}

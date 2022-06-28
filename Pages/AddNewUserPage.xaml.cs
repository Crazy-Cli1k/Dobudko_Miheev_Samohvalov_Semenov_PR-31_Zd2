using MaraphonSkills.Core;
using MaraphonSkills.Core.ModelAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddNewUserPage.xaml
    /// </summary>
    public partial class AddNewUserPage : Page
    {
        Core.MarathonEntities context;
        Core.User user;
        bool isNew;
        public AddNewUserPage(Core.MarathonEntities context, Core.User user, bool isNew)
        {
            this.isNew = isNew;
            InitializeComponent();
            this.user = user;
            RoleComboBox.ItemsSource = context.Role.ToList();
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "RoleId";

            if (isNew)
            {
                PageLabel.Content = "Добавление нового пользователя";
                PasswordLabel.Content = "Новый пароль";
                PasswordTextBlock.Text = String.Empty;
                EmailTextBox.IsReadOnly = false;
                EmailTextBox.BorderThickness = new Thickness(1);


            }
            else
            {
                PageLabel.Content = "Редактирование пользователя";
                PasswordLabel.Content = "Смена пароля";
                PasswordTextBlock.Text = "Оставьте эти поля, незаполненными, если вы не хотите изменять пароль.";
                EmailTextBox.IsReadOnly = true;
                EmailTextBox.BorderThickness = new Thickness(0);
            }

            this.context = context;
            this.DataContext = user;


        }

        /// <summary>
        /// Кнопка для сохранения данных пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ErrorsTextBlock.Text = String.Empty;
            List<string> errorsList = new List<string>();



            if (!String.IsNullOrEmpty(PasswordTextBox.Password) || !String.IsNullOrEmpty(PasswordRepeatTextBox.Password) || !String.IsNullOrWhiteSpace(PasswordTextBox.Password) || !String.IsNullOrWhiteSpace(PasswordRepeatTextBox.Password))
            {
                if (PasswordTextBox.Password == PasswordRepeatTextBox.Password)
                {
                    PasswordValue.Text = PasswordTextBox.Password;
                    user.Password = PasswordValue.Text;
                }
                else
                {
                    errorsList.Add("Пароли не совпадают");
                }
            }
            else
            {
                if (isNew)
                {
                    errorsList.Add("Пароль не заполнен");
                }
            }

            if (errorsList.Count == 0)
            {
                //try
                //{
                user.FirstName = FirstNameTextBox.Text;
                user.LastName = LastNameTextBox.Text;
                user.Email = EmailTextBox.Text;
                user.RoleId = (int)RoleComboBox.SelectedValue;
                context.SaveChanges();

                //}
                //catch (DbEntityValidationException dbEx)
                //{
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            Trace.TraceInformation("Property: {0} Error: {1}",
                //                                    validationError.PropertyName,
                //                                    validationError.ErrorMessage);

                //        }
                //    }
                //}

                MessageBox.Show("Данные сохранены");
                this.NavigationService.GoBack();
            }
            else
            {
                ErrorsTextBlock.Text = String.Join(",", errorsList);
            }
        
        }

        /// <summary>
        /// Кнопка отмены редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

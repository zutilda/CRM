using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для PageSub.xaml
    /// </summary>
    public partial class PageSub : Page
    {
        public PageSub()
        {
            InitializeComponent();
            ComboEmployes.ItemsSource = ClassBase.entities.Employee.ToList();
            ComboEmployes.SelectedValuePath = "IDEmployee";
            ComboEmployes.DisplayMemberPath = "Surname";
            ComboEmployes.SelectedIndex = 0;

            GridSubscription.ItemsSource = ClassBase.entities.Subsriber.ToList();
            CheckBoxActiv.IsChecked = true;
            List<District> districts = ClassBase.entities.District.ToList();
            ComboBoxRaion.Items.Add("Все районы");
            foreach (District district in districts)
            {
                ComboBoxRaion.Items.Add(district.DistrictName);
            }
            ComboBoxRaion.SelectedIndex = 0;

            List<Subsriber> subscribers = ClassBase.entities.Subsriber.ToList();
            ComboBoxYlitsa.Items.Add("Все улицы");
            foreach (Subsriber subscribers1 in subscribers)
            {
                ComboBoxYlitsa.Items.Add(subscribers1.FactAdress.Substring(19));
            }
            ComboBoxYlitsa.SelectedIndex = 0;
        }
        int ii = 0;
        private void ComboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employees = ClassBase.entities.Employee.FirstOrDefault(x => x.IDEmployee == ComboEmployes.SelectedIndex + 1);

            if (employees != null)
            {
                if (employees.Photo != null)
                {
                   ImageEmployee.ImageSource = new BitmapImage(new Uri("" + employees.Photo, UriKind.Relative));
                }
                else
                {
                    ImageEmployee.ImageSource = new BitmapImage(new Uri("..\\image\\Фото для заглушки при отсутствии фото сотрудника.jpg", UriKind.Relative));
                }
                List<Meeting> meetings = ClassBase.entities.Meeting.Where(x => x.ID == employees.Role).ToList();
                ListEvents.ItemsSource = meetings.OrderBy(x => x.DataEvent);
                ii = meetings.Count;
            }
            if (employees.Role == 1)
            {
                ImgObor.Visibility = Visibility.Collapsed;
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
            }
            else if (employees.Role == 2)
            {
                ImgBilling.Visibility = Visibility.Collapsed;
                ImgObor.Visibility = Visibility.Collapsed;
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
            }
            else if (employees.Role == 3)
            {
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgBilling.Visibility = Visibility.Collapsed;
            }
            else if (employees.Role == 4)
            {
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgBilling.Visibility = Visibility.Collapsed;
            }
            else if (employees.Role == 5)
            {
                ImgObor.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
                ImgCRM.Visibility = Visibility.Collapsed;
            }
            else if (employees.Role == 6)
            {

            }
            else if (employees.Role == 7)
            {

            }
            else if (employees.Role == 10)
            {
                ImgBilling.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonBackward_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonForward_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// Метод для поиска и фильтрации
        /// </summary>
        public void Filter()
        {
            List<Subsriber> subsriber = new List<Subsriber>();

            subsriber = ClassBase.entities.Subsriber.ToList();

            //активные неактивные
            if (CheckBoxActiv.IsChecked == true && CheckBoxNoActiv.IsChecked == true)
            {
                subsriber = ClassBase.entities.Subsriber.ToList();
            }
            else if (CheckBoxActiv.IsChecked == true && CheckBoxNoActiv.IsChecked == false)
            {
                subsriber = ClassBase.entities.Subsriber.Where(x => x.ReasonForTermination == null).ToList();
            }
            else if (CheckBoxActiv.IsChecked == false && CheckBoxNoActiv.IsChecked == true)
            {
                subsriber = ClassBase.entities.Subsriber.Where(x => x.ReasonForTermination != null).ToList();
            }
            else
            {
                subsriber = new List<Subsriber>();
            }

            //поиск
            if (!string.IsNullOrWhiteSpace(TextBoxSurname.Text))
            {
                subsriber = subsriber.Where(x => x.Surname.ToLower().Contains(TextBoxSurname.Text.ToLower())).ToList();
            }

            //фильтрация по району
            if (ComboBoxRaion.SelectedIndex > 0)
            {
                District districts = ClassBase.entities.District.FirstOrDefault(x => x.DistrictName == ComboBoxRaion.SelectedValue);
                subsriber = subsriber.Where(x => x.District == districts.ID).ToList();
            }

            if (!string.IsNullOrWhiteSpace(TextBoxLichSchet.Text))
            {
                subsriber = subsriber.Where(x => Convert.ToString(x.PersonalAccount).ToLower().Contains(TextBoxLichSchet.Text.ToLower())).ToList();

            }

            //фильтрация по улице 
            if (ComboBoxYlitsa.SelectedIndex > 0)
            {

                subsriber = subsriber.Where(x => x.AdressUser.Substring(19) == ComboBoxYlitsa.SelectedItem.ToString()).ToList();

            }

            GridSubscription.ItemsSource = subsriber;
            if (subsriber.Count == 0)
            {
                MessageBox.Show("Данные отсутствуют", "Сообщение");
            }
        }

        // ввод первой заглавной буквы
        private void TextBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Filter();
                if (TextBoxSurname.Text.Length == 1)
                {
                    TextBoxSurname.Text = TextBoxSurname.Text.ToUpper();
                    TextBoxSurname.Select(TextBoxSurname.Text.Length, 0);
                }

            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }

        }

        private void ComboBoxRaion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TextBoxLichSchet_SelectionChanged(object sender, RoutedEventArgs e)
        {

            Filter();

        }

        private void GridSubscription_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Subsriber subscribers = new Subsriber();
            foreach (Subsriber subscribers1 in GridSubscription.SelectedItems)
            {
                subscribers = subscribers1;
            }

            if (subscribers != null)
            {
                ClassFrame.frame.Navigate(new SubInfo(subscribers));
            }
            else
            {
                return;
            }
        }

        private void ButtonBac_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImgAbon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = false;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Абоненты ТНС";
        }

        private void ImgObor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = false;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Управление оборудованием";
        }

        private void ImgActiv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = false;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Активы";
        }

        private void ImgBilling_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = false;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Биллинг";
        }

        private void ImgPodder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = false;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Поддержка пользователей";
        }

        private void ImgCRM_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = false;
            TextName.Text = "CRM";
            WindowCRM v = new WindowCRM();
            v.ShowDialog();
            ClassFrame.frame.Navigate(new PageSub());
        }

        // запрет ввода чисел
        private void TextBoxSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            try
            {
                Regex r1 = new Regex("^[0-9]+");
                e.Handled = r1.IsMatch(e.Text);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        //запрет ввода символов
        private void TextBoxLichSchet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        private void ComboBoxYlitsa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CheckBoxActiv_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CheckBoxNoActiv_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }
    }
    
}

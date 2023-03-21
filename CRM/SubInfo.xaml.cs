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

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для SubInfo.xaml
    /// </summary>
    public partial class SubInfo : Page
    {
        Subsriber sub;
        public SubInfo(Subsriber subscribers)
        {
            InitializeComponent();
            this.sub = subscribers;
            TextNomer.Text = "Номер абонента: " + subscribers.NumberSub;
            FIO.Text = "ФИО: " + subscribers.FullName;
            TextSeriesNomer.Text = "Серия и номер паспорта: " + subscribers.SeriasNumber;
            TextDateOfIssue.Text = "Дата выдачи: " + Convert.ToDateTime(subscribers.DateIssue).ToString("d");
            TextIssuesBy.Text = "Кем выдан: " + subscribers.WhomIssue;
            TextContractNumber.Text = "Номер договора: " + subscribers.Contract;
            TextDateConclusion.Text = "Дата заключения договора: " + Convert.ToDateTime(subscribers.DateCreateContract).ToString("d");
            TextContractType.Text = "Тип договора: " + Convert.ToString(subscribers.ContractType.NameType);
            if (subscribers.DateTermination != null)
            {
                TextTerminationDate.Text = "Дата расторжения: " + Convert.ToDateTime(subscribers.DateTermination).ToString("d");
            }
            if (subscribers.ReasonForTermination != null)
            {
                TextReason.Text = "Причина расторжения: " + subscribers.ReasonForTermination;
            }

            TextPersonalAccount.Text = "Лицевой счет: " + Convert.ToString(subscribers.PersonalAccount);

            TextAddress.Text = "Полный адрес: " + Convert.ToString(subscribers.AdressUser.Substring(8));
            TextDis.Text = "Район: " + Convert.ToString(subscribers.District1.DistrictName);

            TextServices.Text = Convert.ToString(subscribers.ConectedService);
            TextEquipment.Text = Convert.ToString(subscribers.Device.Name);

            DateTime dateTime = DateTime.Now.AddMonths(-12);
            List<ApplicationCRM> application = ClassBase.entities.ApplicationCRM.Where(x => x.Sub == subscribers.ID && x.DateCreate >= dateTime).ToList();
            int ii = 1;
            for (int i = 0; i < application.Count; i++)
            {
                if (i == application.Count - 1)
                {
                    TextCRM.Text = TextCRM.Text + "Номер " + $"{ii++}" + "\n";
                    TextCRM.Text = TextCRM.Text + "Номер заявки " + application[i].NumberApplication + "\n";
                    TextCRM.Text = TextCRM.Text + "Дата создания: " + application[i].DateCreate.ToString("d") + "\n";

                    TextCRM.Text = TextCRM.Text + "Услуга: " + application[i].Service1.NameServices + "\n";
                    TextCRM.Text = TextCRM.Text + "Вид услуги: " + application[i].KindServise.Name + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип услуги: " + application[i].TypeService1.NameType + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип проблемы: " + application[i].TypeOfProblem.NameProblem + "\n";
                    if (application[i].DescriptionProblem != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Описание проблемы: " + application[i].TypeOfProblem.NameProblem + "\n";
                    }
                    if (application[i].ClosingDate != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Дата закрытия: " + Convert.ToDateTime(application[i].ClosingDate).ToString("d") + "\n";
                    }
                    TextCRM.Text = TextCRM.Text + "Статус: " + application[i].Status.NameStatus;
                }
                else
                {
                    TextCRM.Text = TextCRM.Text + "Номер " + $"{ii++}" + "\n";
                    TextCRM.Text = TextCRM.Text + "Номер заявки " + application[i].NumberApplication + "\n";
                    TextCRM.Text = TextCRM.Text + "Дата создания: " + application[i].DateCreate + "\n";

                    TextCRM.Text = TextCRM.Text + "Услуга: " + application[i].Service1.NameServices + "\n";
                    TextCRM.Text = TextCRM.Text + "Вид услуги: " + application[i].KindServise.Name + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип услуги: " + application[i].TypeService1.NameType + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип проблемы: " + application[i].TypeOfProblem.NameProblem + "\n";
                    if (application[i].DescriptionProblem != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Описание проблемы: " + application[i].TypeOfProblem.NameProblem;
                    }
                    if (application[i].ClosingDate != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Дата закрытия: " + application[i].ClosingDate + "\n";
                    }
                    TextCRM.Text = TextCRM.Text + "Статус: " + application[i].Status.NameStatus + "\n\n";
                }
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFrame.frame.Navigate(new PageSub());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }

        }
    }
}

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

namespace Lab3
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

        private void CompetencySliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string[] levels = { "Новичок", "Уверенный", "Опытный", "Продвинутый", "Эксперт" };
            int index = (int)CompetencySlider.Value;
            CompetencyLevelText.Text = levels[index];
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (!AgreementBox.IsChecked ?? false)
            {
                MessageBox.Show("Вы должны согласиться с условиями использования.");
                return;
            }

            string name = NameBox.Text;
            string country = (CountryBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "не указана";
            string gender = MaleRadio.IsChecked == true ? "Мужской" :
                            FemaleRadio.IsChecked == true ? "Женский" : "не указан";

            string interests = "";
            foreach (var item in InterestsBox.SelectedItems)
            {
                interests += ((ListBoxItem)item).Content + ", ";
            }
            if (interests.EndsWith(", ")) interests = interests[..^2];

            string competency = CompetencyLevelText.Text;
            string birthdate = BirthDatePicker.SelectedDate?.ToShortDateString() ?? "не выбрана";

            string info = $"Имя: {name}\nПол: {gender}\nСтрана: {country}\nДата рождения: {birthdate}\nИнтересы: {interests}\nКомпетенция: {competency}";
            MessageBox.Show(info, "Информация о пользователе");
        }
    }
}
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

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush _originalBackground;
        private string _placeholderText = "Введите текст...";
        private bool _isPlaceholder = true;
        private Brush _originalRectBrush;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _originalBackground = InputBox.Background;
            _originalRectBrush = InteractiveRectangle.Fill;

            ShowPlaceholder();
            InputBox.Focus();
        }

        private void ShowPlaceholder()
        {
            InputBox.Text = _placeholderText;
            InputBox.Foreground = Brushes.Gray;
            _isPlaceholder = true;
        }

        private void RemovePlaceholder()
        {
            if (_isPlaceholder)
            {
                InputBox.Text = "";
                InputBox.Foreground = Brushes.Black;
                _isPlaceholder = false;
            }
        }


        private void InputBoxGotFocus(object sender, RoutedEventArgs e)
        {
            InputBox.Background = Brushes.LightYellow;

            if (_isPlaceholder)
            {
                RemovePlaceholder();
            }
        }

        private void InputBoxLostFocus(object sender, RoutedEventArgs e)
        {
            InputBox.Background = Brushes.White;

            if (string.IsNullOrWhiteSpace(InputBox.Text))
            {
                ShowPlaceholder();
            }
        }

        private void InputBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_isPlaceholder) return;

            if (e.Key == Key.Space && !_isPlaceholder)
            {
                e.Handled = true;
                InputBox.Clear();
            } 
            else if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(InputBox.Text))
            {
                OutputLabel.Content = InputBox.Text;
                e.Handled = true;
            }
        }

        private void RectangleMouseEnter(object sender, MouseEventArgs e)
        {
            InteractiveRectangle.Fill = Brushes.Red;
        }

        private void RectangleMouseLeave(object sender, MouseEventArgs e)
        {
            InteractiveRectangle.Fill = _originalRectBrush;
        }

        private void RectangleMouseDown(object sender, MouseButtonEventArgs e)
        {
            InteractiveRectangle.Width *= 1.2;
            InteractiveRectangle.Height *= 1.2;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы нажали кнопку!");
        }
    }
}
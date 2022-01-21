using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab2._5
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
        private void fontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void fontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textBox != null)
                textBox.FontSize = fontSize;
        }

        private void bold_Click(object sender, RoutedEventArgs e)
        {
            bool bold = (sender as Button).IsPressed;
            if (textBox != null)
            {
                if (bold)
                {
                    textBox.FontWeight = textBox.FontWeight != FontWeights.Bold
                        ? FontWeights.Bold
                        : FontWeights.Normal;
                }
            }
        }

        private void italic_Click(object sender, RoutedEventArgs e)
        {
            bool italic = (sender as Button).IsPressed;
            if (textBox != null)
            {
                if (italic)
                {
                    textBox.FontStyle = textBox.FontStyle != FontStyles.Italic
                        ? FontStyles.Italic
                        : FontStyles.Normal;
                }
            }
        }

        private void underline_Click(object sender, RoutedEventArgs e)
        {
            bool underline = (sender as Button).IsPressed;
            if (textBox != null)
            {
                if (underline)
                {
                    if (textBox.TextDecorations != TextDecorations.Underline)
                    {
                        textBox.TextDecorations = TextDecorations.Underline;
                    }
                    else
                    {
                        textBox.TextDecorations = null;
                    }
                }
            }
        }

        private void blackColor_Checked(object sender, RoutedEventArgs e)
        {
            bool isChecked = (bool)(sender as RadioButton).IsChecked;
            if (textBox != null)
            {
                if (isChecked)
                {
                    textBox.Foreground = Brushes.Black;
                }
            }
        }

        private void redColor_Checked(object sender, RoutedEventArgs e)
        {
            bool isChecked = (bool)(sender as RadioButton).IsChecked;
            if (textBox != null)
            {
                if (isChecked)
                {
                    textBox.Foreground = Brushes.Red;
                }
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

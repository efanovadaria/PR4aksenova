using System;
using System.Windows;
using System.Windows.Controls;

namespace PR4aksenova
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtX.Text);
                double y = Convert.ToDouble(txtY.Text);
                double z = Convert.ToDouble(txtZ.Text);
                double result = MathFunctions.CalculatePage1(x, y, z);
                txtResult.Text = result.ToString("F4");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения!",
                                "Ошибка ввода",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            txtResult.Clear();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}
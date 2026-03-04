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

                // Проверки области допустимых значений
                if (y < 0)
                    throw new Exception("Y не может быть отрицательным (корень из отрицательного числа).");

                if (x - 1 < 0)
                    throw new Exception("X должен быть ≥ 1 (корень из x-1).");

                if (x == y)
                    throw new Exception("X не должен быть равен Y (деление на 0).");

                double numerator = Math.Sqrt(y) + Math.Sqrt(x - 1);
                double denominator = Math.Pow(4 * Math.Abs(x - y), 1.0 / 3.0);

                double trigPart = Math.Pow(Math.Sin(z), 2) + Math.Tan(z);

                double f = (numerator / denominator) * trigPart;

                txtResult.Text = f.ToString("F4");
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
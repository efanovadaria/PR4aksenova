using System;
using System.Windows;
using System.Windows.Controls;

namespace PR4aksenova
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtX.Text);
                double y = Convert.ToDouble(txtY.Text);

                double fx = 0;

                // Выбор функции f(x)
                if (rbSinh.IsChecked == true)
                {
                    fx = Math.Sinh(x);
                }
                else if (rbSquare.IsChecked == true)
                {
                    fx = Math.Pow(x, 2);
                }
                else if (rbExp.IsChecked == true)
                {
                    fx = Math.Exp(x);
                }
                else
                {
                    MessageBox.Show("Выберите функцию f(x)!");
                    return;
                }

                double c;

                if (x - y == 0)
                {
                    c = Math.Pow(fx, 2) + Math.Pow(y, 2) + Math.Sin(y);
                }
                else if (x - y > 0)
                {
                    c = Math.Pow(fx - y, 2) + Math.Cos(y);
                }
                else
                {
                    c = Math.Pow(y - fx, 2) + Math.Tan(y);
                }

                txtResult.Text = c.ToString("F4");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtResult.Clear();

            rbSinh.IsChecked = false;
            rbSquare.IsChecked = false;
            rbExp.IsChecked = false;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}
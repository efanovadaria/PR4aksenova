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

                MathFunctions.FxKind? kind = null;
                if (rbSinh.IsChecked == true) kind = MathFunctions.FxKind.Sinh;
                else if (rbSquare.IsChecked == true) kind = MathFunctions.FxKind.Square;
                else if (rbExp.IsChecked == true) kind = MathFunctions.FxKind.Exp;

                if (kind is null)
                {
                    MessageBox.Show("Выберите функцию f(x)!");
                    return;
                }

                double result = MathFunctions.CalculatePage2(x, y, kind.Value);
                txtResult.Text = result.ToString("F4");
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
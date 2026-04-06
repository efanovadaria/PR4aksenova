using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace PR4aksenova
{
    public partial class Page3 : Page
    {
        private Chart chart1;

        public Page3()
        {
            InitializeComponent();

            // Создаём Chart и привязываем к WindowsFormsHost
            chart1 = new Chart();
            chart1.ChartAreas.Add(new ChartArea("MainArea"));
            ChartHost.Child = chart1;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x0 = Convert.ToDouble(txtX0.Text);
                double xk = Convert.ToDouble(txtXk.Text);
                double dx = Convert.ToDouble(txtDx.Text);
                double b = Convert.ToDouble(txtB.Text);

                if (dx <= 0)
                {
                    System.Windows.MessageBox.Show("Шаг dx должен быть больше 0!");
                    return;
                }

                txtOutput.Clear();
                chart1.Series.Clear();

                // Создаём серию для графика
                Series series = new Series("y(x)")
                {
                    ChartType = SeriesChartType.Line,
                    IsValueShownAsLabel = true
                };
                chart1.Series.Add(series);

                for (double x = x0; x <= xk; x += dx)
                {
                    double y;
                    try
                    {
                        y = MathFunctions.CalculatePage3(x, b);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                    txtOutput.AppendText($"x = {x:F3}   y = {y:F5}\n");

                    series.Points.AddXY(x, y);
                }
            }
            catch (FormatException)
            {
                System.Windows.MessageBox.Show("Введите корректные числовые значения!",
                               "Ошибка",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX0.Clear();
            txtXk.Clear();
            txtDx.Clear();
            txtB.Clear();
            txtOutput.Clear();
            chart1.Series.Clear();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            // Подтверждение выхода
            var result = System.Windows.MessageBox.Show(
                "Вы действительно хотите выйти из приложения?",
                "Подтверждение выхода",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Закрываем родительское окно, где находится Page
                Window parentWindow = Window.GetWindow(this);
                parentWindow?.Close();
            }
        }
    }
}
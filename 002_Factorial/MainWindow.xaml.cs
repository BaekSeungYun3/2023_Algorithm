using System.Windows;
using System.Windows.Controls;

namespace _002_Factorial
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(textbox.Text);
            
            ListBox.Items.Add("재귀적방법 Factorial");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            long rfact = 1;
            for (int i = 1; i < n; i++)
            {
                rfact = rFactorial(i);
                string s = string.Format("fact({0}) = {1}", i, rfact);
                ListBox.Items.Add(s);
            }

            watch.Stop();
            var elapsedTicks = watch.ElapsedTicks;      // 또는 watch.ElapsedMilliseconds

            string result = elapsedTicks + " Ticks = " + elapsedTicks / 10000.0 + " ms";
            // 1 Tick = 100 ns

            ListBox.Items.Add(result);

            ListBox.Items.Add("반복문 Factorial");
            watch = System.Diagnostics.Stopwatch.StartNew();

            long fact = 1;
            for (int i = 1; i < n; i++)
            {
                fact = Factorial(i);
                string s = string.Format("fact({0}) = {1}", i, fact);
                ListBox.Items.Add(s);
            }

            watch.Stop();
            elapsedTicks = watch.ElapsedTicks;     
            string result2 = elapsedTicks + " Ticks = " + elapsedTicks / 10000.0 + " ms";

            ListBox.Items.Add(result2);


            long Factorial(int x)
            {
                long f = 1;
                for (int i = 2; i <= x; i++)
                    f *= i;
                return f;

            }

            long rFactorial(int x)
            {
                if (x == 1)
                    return 1;       //끝나는 조건
                else
                    return rFactorial(x - 1) * x;       //3!일때 3*2!이런느낌으로 감
            }


        }

    }
}

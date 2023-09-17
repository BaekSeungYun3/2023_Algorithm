
using System;
using System.Windows;

namespace _003_Fibonacci
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtNum.Text);
            listBox.Items.Clear();

            listBox.Items.Add("재귀적 Fibonacci");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i <= n; i++)
            {
                listBox.Items.Add(Fibonacci(i));
            }
            watch.Stop();
            var elap = watch.ElapsedTicks;
            listBox.Items.Add("Ticks = " + elap + ", ms = " + watch.ElapsedMilliseconds);


            int[] fibo = new int[101];

            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == 2)
                    fibo[i] = 1;
                else
                    fibo[i] = fibo[i - 1] + fibo[i - 2];
            }
            watch.Stop();
            elap = watch.ElapsedTicks;

            listBox.Items.Add("반복문 Fibonacci");
            for (int i = 1; i <= n; i++)
            {
                listBox.Items.Add(fibo[i]);
            }
            listBox.Items.Add("Ticks = " + elap + ", ms = " + watch.ElapsedMilliseconds);
        }

        private int Fibonacci(int i)
        {
            if (i == 1 || i == 2)
                return 1;
            else
                return Fibonacci(i - 1) + Fibonacci(i - 2);
        }
    }
}
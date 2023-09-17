using System;
using System.Collections;
using System.Collections.Generic;
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

namespace _005_ClosestPair
{
    //IComparer는 Array.sort() 메소드에서 사용할 비교를 위한 인터페이스
    public class XCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).X - ((Point)y).X);
        }
    }
    public partial class MainWindow : Window
    {
        const int P = 10000;
        int noOfPoints;
        Point[] points = new Point[P];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            noOfPoints = int.Parse(txtNo.Text);
            MakePointArray();
            SortPointArray();
        }

        private void SortPointArray()
        {
            IComparer xComp = new XCompare();
            Array.Sort(points, xComp);
            PrintPoint();
        }

        private void PrintPoint()
        {
            //foreach(Point p in points)
            for(int i = 0; i < noOfPoints; i++) 
            {
                Console.WriteLine(points[i].X + ", " + points[i].Y); 
            }
        }

        //random하게 점의 좌표를 만들고 배열에 저장하는 함수 
        private void MakePointArray()
        {
            Random r = new Random();

            for(int i = 0; i< noOfPoints; i++)
            {
                points[i] = new Point(r.NextDouble()*can.Width, r.NextDouble() * can.Height);
            }

            foreach(var p in points)
            {
                Rectangle rect = new Rectangle();
                rect.Width = rect.Height = 3;
                rect.Stroke = Brushes.Black;
                Canvas.SetLeft(rect, p.X - 1);
                Canvas.SetTop(rect, p.Y - 1);
                can.Children.Add(rect);
            }
        }
        
        //Brute Force 방법
        private void btnBrute_Click(object sender, RoutedEventArgs e)
        {
            PointPair result = FindClosestPair(points, 0, noOfPoints - 1);

            HighLight(result);
            MessageBox.Show(String.Format("({0},{1}) - ({2},{3}) = {4}", result.P1.X, result.P1.Y, result.P2.X, result.P2.Y, result.Dist));
        }

        private void HighLight(PointPair result)
        {
            Line l = new Line();
            l.X1 = result.P1.X-1;
            l.Y1 = result.P1.Y;
            l.X2 = result.P2.X+1;
            l.Y2 = result.P2.Y;
            l.Stroke = Brushes.Red;
            l.StrokeThickness = 5;
            can.Children.Add(l);

        }

        private PointPair FindClosestPair(Point[] points, int start, int end)
        {
            double min = double.MaxValue;
            int minI = 0, minJ = 0;     //최근점 점 두개의 points[] 인덱스

            for(int i = 0; i < end - 1; i++)
                for(int j = i+1; j < end; j++)
                    if(Dist(i, j) < min)
                    {
                        min = Dist(i, j);
                        minI = i;
                        minJ = j;
                    }

            PointPair pp = new PointPair(points[minI], points[minJ], min);
            return pp;
        }

        private double Dist(int i, int j)
        {
            return Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));
        }


        private void btnDivde_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
//x좌표를 기준으로 정렬한거임 Array라는 클래스에 sort함수 써서 함 = 정수는 비교하는 방법이 정해져있지만 포인트는 정의해줘야함
//포인트 정의 = (우리가 만들던지 Array.sort를 사용하기 위해선 두개의 점의 크기를 비교할 수 있는 인터페이스를 만들어야함 그래서 만들거임)

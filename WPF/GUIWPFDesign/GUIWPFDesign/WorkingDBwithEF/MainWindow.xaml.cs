using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkingDBwithEF.DataAccess;

namespace WorkingDBwithEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Car> listCars;
        public List<Car> listCarsByYear;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Phương thức load dữ liệu từ Cars entity
        public void LoadCars()
        {
            lvCars.ItemsSource = new CarDAO().GetCars();
            listCars = new CarDAO().GetCars();
            listCarsByYear = listCars.GroupBy(car => car.ReleasedYear).Select(grp => grp.First()).OrderBy(car => car.ReleasedYear).ToList();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = new Car
                {
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
                new CarDAO().InsertCar(car);
                LoadCars();
                MessageBox.Show($"{car.CarName} inserted successfully", "Insert car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = new Car
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
                new CarDAO().UpdateCar(car);
                LoadCars();
                MessageBox.Show($"{car.CarName} updated successfully", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = new Car
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
                new CarDAO().RemoveCar(car);
                LoadCars();
                MessageBox.Show($"{car.CarName} deleted successfully", "Delete car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        public SolidColorBrush GenerateColor()
        {
            var random = new Random();

            var r = Convert.ToByte(random.Next(0, 255));
            var g = Convert.ToByte(random.Next(0, 255));
            var b = Convert.ToByte(random.Next(0, 255));

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        public void InitBarChart()
        {
            foreach (var item in listCarsByYear)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = ((xAxis.X2 / listCarsByYear.Count()) * 60) / 100;
                rectangle.Height = listCars.Where(car => car.ReleasedYear == item.ReleasedYear).Count() * 30;
                rectangle.Margin = new Thickness(((xAxis.X2 / listCarsByYear.Count()) * 20) / 100, xAxis.Y2 - rectangle.Height, 0, 0);
                rectangle.Fill = GenerateColor();
                wPanel.Children.Add(rectangle);

                //Adding animation and Effect
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, Convert.ToDouble(rectangle.Height), new TimeSpan(0, 0, 2));
                doubleAnimation.FillBehavior = FillBehavior.HoldEnd;
                rectangle.BeginAnimation(HeightProperty, doubleAnimation);
                //Add label to rectangle
                Label label = new Label();
                label.Content = item.ReleasedYear.ToString();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.Background = Brushes.Transparent;
                label.Foreground = Brushes.SkyBlue;
                label.Margin = new Thickness(((xAxis.X2 / listCarsByYear.Count()) * 20) / 100, xAxis.Y2 * 0.99, 0, 0);
                label.FontSize = 15;
                label.Height = 30;
                label.Width = rectangle.Width;
                stackPanel.Children.Add(label);
                //Add Scale line for axis,separate each of them by 20
                for (int i = 20; i < xAxis.Y2; i+=20)
                {
                    Line line = new Line();
                    line.X1 = 5;
                    line.Y1 = i;
                    line.X2 = 25;
                    line.Y2 = line.Y1;
                    line.Stroke = Brushes.SkyBlue;
                    line.StrokeThickness = 1;
                    grid.Children.Add(line);
                }

            }

        }

        public void InitPieChart()
        {
            float angle = 0, prevAngle = 0;
            var radius = pieContainer.Width / 2;
            var centerX = pieContainer.Width / 2;
            var centerY = xAxis.Y2 / 2;


            foreach (var item in listCarsByYear)
            {
                var percent = listCars.Where(car => car.ReleasedYear == item.ReleasedYear).Count() *100/ listCarsByYear.Count();
                //Starting point
                double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = percent * (float)360 / 100 + prevAngle;

                double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                bool isLargeArc = percent> 50;
                var arcSegment = new ArcSegment()
                {
                    Size = new Size(arcWidth, arcHeight),
                    Point = new Point(arcX, arcY),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc,
                };
                var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                var pathFigure = new PathFigure(
                    new Point(centerX, centerY),
                    new List<PathSegment>()
                    {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                    },
                    true);

                var pathFigures = new List<PathFigure>() { pathFigure, };
                var pathGeometry = new PathGeometry(pathFigures);
                var path = new Path()
                {
                    Fill = GenerateColor(),
                    Data = pathGeometry,
                };
                pieCanvas.Children.Add(path);
                prevAngle = angle;


                // draw outlines
                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };

                pieCanvas.Children.Add(outline1);
                pieCanvas.Children.Add(outline2);

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCars();
            InitBarChart();
            InitPieChart();
        }

      
    }
}

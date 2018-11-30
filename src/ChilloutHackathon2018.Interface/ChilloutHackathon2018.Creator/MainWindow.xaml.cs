using InterfaceModels.User;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChilloutHackathon2018.Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(UserInfo userInfo)
        {
            InitializeComponent();
            SetUserContext(userInfo);
            InitializeCanvas();
        }

        private void SetUserContext(UserInfo userContext)
        {
            userInfo = userContext;
            currentUserLabel.Content = $"{userContext.FirstName} {userContext.LastName}";
        }

        private void InitializeCanvas()
        {
            CanvasObject.Canvas = creatorCanvas;

            var ellipseArray = new CanvasDot[10, 10];

            for (int i = -3; i <= 3; i++)
            {
                for (int j = -3; j <= 3; j++)
                {
                    var ellipseModel = new Ellipse
                    {
                        Width = 20,
                        Height = 20,
                        Fill = Brushes.Blue,
                    };

                    var dot = new CanvasDot
                    {
                        CoordX = (j + 3) * 60 + 5,
                        CoordY = (i + 3) * 60 + 5,
                        IndexX = j,
                        IndexY = i,
                        Ellipse = ellipseModel
                    };

                    dot.Ellipse.MouseDown += dot.MouseDownWire;

                    ellipseArray[j + 3, i + 3] = dot;

                    Canvas.SetLeft(dot.Ellipse, dot.CoordX);
                    Canvas.SetTop(dot.Ellipse, dot.CoordY);

                    CanvasObject.Canvas.Children.Add(dot.Ellipse);
                }
            }

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        var ellipseModel = new Ellipse
            //        {
            //            Width = 20,
            //            Height = 20,
            //            Fill = new SolidColorBrush(Colors.Blue),
            //        };

            //        var dot = new CanvasDot
            //        {
            //            CoordX = j * 50 + 5,
            //            CoordY = i * 50 + 5,
            //            Ellipse = ellipseModel
            //        };

            //        dot.Ellipse.MouseDown += dot.MouseDownWire;

            //        ellipseArray[j, i] = dot;


            //        Canvas.SetLeft(dot.Ellipse, dot.CoordX);
            //        Canvas.SetTop(dot.Ellipse, dot.CoordY);

            //        CanvasObject.Canvas.Children.Add(dot.Ellipse);

            //    }
            //}
        }

        public class CanvasDot
        {

            public Ellipse Ellipse { get; set; }

            public long CoordX { get; set; }

            public long CoordY { get; set; }

            public int IndexX { get; set; }

            public int IndexY { get; set; }

            public void MouseDownWire(object sender, MouseButtonEventArgs e)
            {
                if (CanvasObject.First == null)
                {
                    this.Ellipse.Fill = new SolidColorBrush(Colors.Red);
                    CanvasObject.First = this;
                }
                else
                {
                    var strokeBrush = default(Brush);

                    switch (MainWindow.WallType)
                    {
                        case WallType.Wall:
                            strokeBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1B72AF"));
                            break;
                        case WallType.Door:
                            strokeBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#836890"));
                            break;
                        case WallType.Window:
                            strokeBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#BC342F"));
                            break;
                    }
                    var line = new Line
                    {
                        Stroke = strokeBrush,
                        X1 = CanvasObject.First.CoordX + 10,
                        Y1 = CanvasObject.First.CoordY + 10,
                        X2 = this.CoordX + 10,
                        Y2 = this.CoordY + 10,
                        StrokeThickness = 10
                    };

                    var canvasLine = new CanvasLine
                    {
                        CoordX1 = CanvasObject.First.CoordX,
                        CoordY1 = CanvasObject.First.CoordY,
                        CoordX2 = this.CoordX,
                        CoordY2 = this.CoordY,

                        IndexX1 = CanvasObject.First.IndexX,
                        IndexY1 = CanvasObject.First.IndexY,
                        IndexX2 = this.IndexX,
                        IndexY2 = this.IndexY,
                        WallType = MainWindow.WallType,
                        Line = line
                    };

                    CanvasObject.Canvas.Children.Add(canvasLine.Line);
                    CanvasObject.CanvasLines.Add(canvasLine);

                    CanvasObject.First.Ellipse.Fill = Brushes.Blue;
                    CanvasObject.First = null;
                }
            }
        }

        public class CanvasLine
        {
            public Line Line { get; set; }

            public int IndexX1 { get; set; }

            public int IndexX2 { get; set; }

            public int IndexY1 { get; set; }

            public int IndexY2 { get; set; }

            public long CoordX1 { get; set; }

            public long CoordX2 { get; set; }

            public long CoordY1 { get; set; }

            public long CoordY2 { get; set; }

            public WallType WallType { get; set; }
        }


        public class CanvasObject
        {
            public CanvasObject()
            {
            }

            public static CanvasDot[,] CanvasDots = new CanvasDot[10, 10];

            public static List<CanvasLine> CanvasLines = new List<CanvasLine>();

            public static CanvasDot First { get; set; }

            public static CanvasDot Second { get; set; }

            public static Canvas Canvas;
        }

        public static WallType WallType { get; set; } = WallType.Wall;

        private UserInfo userInfo;

        private void DoorButton_Checked(object sender, RoutedEventArgs e)
        {
            WallType = WallType.Door;
        }

        private void WallButton_Checked(object sender, RoutedEventArgs e)
        {
            WallType = WallType.Wall;
        }

        private void WindowButton_Checked(object sender, RoutedEventArgs e)
        {
            WallType = WallType.Window;
        }

        private void DoorButton_Clicked(object sender, RoutedEventArgs e)
        {
            WallType = WallType.Door;

            doorIconBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#836890"));
            wallIconBorder.BorderBrush = Brushes.Transparent;
            windowIconBorder.BorderBrush = Brushes.Transparent;
        }

        private void WallButton_Clicked(object sender, RoutedEventArgs e)
        {
            wallIconBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1B72AF"));
            WallType = WallType.Wall;
            doorIconBorder.BorderBrush = Brushes.Transparent;
            windowIconBorder.BorderBrush = Brushes.Transparent;
        }

        private void WindowButton_Clicked(object sender, RoutedEventArgs e)
        {
            windowIconBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#BC342F"));
            WallType = WallType.Window;
            doorIconBorder.BorderBrush = Brushes.Transparent;
            wallIconBorder.BorderBrush = Brushes.Transparent;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleGraph.Model
{
    public class DrawGraph
    {
        private List<Point> _nodesPoints;
        private List<Line> _lines;
        private Canvas _canvas;

        public List<Point> NodesPoints
        {
            get
            {
                return _nodesPoints;
            }
        }
        public List<Line> Lines
        {
            get
            {
                return _lines;
            }
        }
        public int NumberOfNodes { get; set; }
        public int Radius { get; set; }
        public int NodeRadius { get; set; }

        //konstruktory - na obiekcie Canvas rysowany jest graf
        public DrawGraph(Canvas canvas)
        {
            this._canvas = canvas;
            InitializeLists();
        }

        public DrawGraph(Canvas canvas, int numberOfNodes, int Radius, int NodeRadius)
        {
            this.NumberOfNodes = 16;
            this.Radius = 200;
            this.NodeRadius = 10;
            this._canvas = canvas;
            InitializeLists();
        }

        //inicjalizacja _nodesPoints oraz _lines
        private void InitializeLists()
        {
            _nodesPoints = new List<Point>();
            _lines = new List<Line>();
        }

        //rysowanie głównego koła
        public void DrawMainCircle(Brush Stroke, double StrokeThickness)
        {
            Ellipse mainEllipse = new Ellipse();
            mainEllipse.Stroke = Stroke;
            mainEllipse.StrokeThickness = StrokeThickness;
            mainEllipse.Height = mainEllipse.Width = 2 * Radius;

            //Ustawiane w ten sposób, gdyz punkt (0,0) elementu to lewy górny róg, a nie jego środek
            Canvas.SetLeft(mainEllipse, (_canvas.ActualWidth / 2) - Radius + (NodeRadius / 2));
            Canvas.SetTop(mainEllipse, (_canvas.ActualHeight / 2) - Radius + (NodeRadius / 2));

            _canvas.Children.Insert(0, mainEllipse);
        }

        //rysowanie punktów
        public void DrawNodes()
        {
            double a = _canvas.ActualWidth / 2;
            double b = _canvas.ActualHeight / 2;

            for (int i = 0; i < NumberOfNodes; i++)
            {
                double t = 2 * Math.PI * i / NumberOfNodes;
                int x = (int)Math.Round(a + Radius * Math.Cos(t));
                int y = (int)Math.Round(b + Radius * Math.Sin(t));

                _nodesPoints.Add(new Point(x, y));

                Ellipse ellipse = new Ellipse();
                ellipse.Fill = Brushes.Red;
                ellipse.Height = NodeRadius;
                ellipse.Width = NodeRadius;
                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);
                _canvas.Children.Add(ellipse);
            }
        }

        //rysowanie pełnego grafu
        public bool DrawFullGraphLines()
        {
            if (_nodesPoints.Count == 0)
                return false;

            for (int i = 0; i < NumberOfNodes; i++)
                for (int j = 0; j < NumberOfNodes; j++)
                    if (i != j)
                        DrawLine(_nodesPoints[i], _nodesPoints[j]);

            return true;
        }

        //rysowanie linii od punktu node1 do punktu node2
        public void DrawLine(Point node1, Point node2)
        {
            Line line = new Line();
            line.StrokeThickness = 1;
            line.Stroke = Brushes.Black;
            line.X1 = node1.X + NodeRadius / 2;
            line.X2 = node2.X + NodeRadius / 2;
            line.Y1 = node1.Y + NodeRadius / 2;
            line.Y2 = node2.Y + NodeRadius / 2;
            //Insert() zamiast Add(), aby linie były "pod spodem" - liczy się kolejność dodawania, im dalej na liście tym "wyżej"
            _canvas.Children.Insert(0, line);
        }

        public void ClearAll()
        {
            _nodesPoints.Clear();
            _lines.Clear();
            _canvas.Children.Clear();
        }
    }
    }

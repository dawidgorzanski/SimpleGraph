using SimpleGraph.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleGraph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawGraph draw;
        public MainWindow()
        {
            InitializeComponent();
            Label label = new Label();
            draw = new DrawGraph(mainCanvas);
        }

        private void btnDrawFullGraph_Click(object sender, RoutedEventArgs e)
        {
            draw.ClearAll();
            int radius, nodeRadius, numberOfNodes;

            if (!ValidateData(out numberOfNodes, out radius, out nodeRadius))
                return;

            draw.NumberOfNodes = numberOfNodes;
            draw.NodeRadius = nodeRadius;
            draw.Radius = radius;
            draw.DrawMainCircle(Brushes.Green, 1);
            draw.DrawNodes();
            draw.DrawFullGraphLines();
        }

        private bool ValidateData(out int numberOfNodes, out int radius, out int nodeRadius)
        {
            numberOfNodes = 0;
            radius = 0;
            nodeRadius = 0;

            if (!Int32.TryParse(tbNumberOfNodes.Text, out numberOfNodes))
            {
                MessageBox.Show("Niepoprawna ilość wierzchołków!");
                return false;
            }

            if (!Int32.TryParse(tbRadius.Text, out radius))
            {
                MessageBox.Show("Niepoprawny promień okręgu!");
                return false;
            }

            if (!Int32.TryParse(tbNodeRadius.Text, out nodeRadius))
            {
                MessageBox.Show("Niepoprawny promień punktu!");
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            draw.ClearAll();
        }
    }
}

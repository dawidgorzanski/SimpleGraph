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
            InitializeColorPickers();
            draw = new DrawGraph(mainCanvas, GraphCreator.CreateFullGraph());
        }

        private void InitializeColorPickers()
        {
            colorPickerCircle.SelectedColor = Colors.Green;
            colorPickerLines.SelectedColor = Colors.Black;
            colorPickerPoints.SelectedColor = Colors.Red;
        }

        private void btnDrawFullGraph_Click(object sender, RoutedEventArgs e)
        {
            draw.ClearAll();

            if (intUpDownPoints.Value != null)
                draw.CurrentGraph = GraphCreator.CreateFullGraph((int)intUpDownPoints.Value);
            else
            {
                MessageBox.Show("Niepoprawna ilość wierchołków!");
                return;
            }

            draw.NodeRadius = (int)sliderNodeRadius.Value;
            draw.Radius = (int)sliderRadius.Value;

            draw.DrawMainCircle();
            draw.Draw();
        }

        private void btnDrawRandomGraph_Click(object sender, RoutedEventArgs e)
        {
            draw.ClearAll();

            if (Graph.MaxConnections((int)intUpDownRandomPoints.Value) < (int)intUpDownRandomConnections.Value)
            {
                MessageBox.Show(String.Format("Przekroczono maksymalną liczbę połaczeń!\nMaksymalna liczba polaczen dla {0} wierzcholkow wynosi {1}.",
                    (int)intUpDownRandomPoints.Value, Graph.MaxConnections((int)intUpDownRandomPoints.Value)), "Błąd!");
                return;
            }

            if (intUpDownRandomPoints.Value != null && intUpDownRandomConnections.Value != null)
                draw.CurrentGraph = GraphCreator.CreateRandomGraph((int)intUpDownRandomPoints.Value, (int)intUpDownRandomConnections.Value);
            else
            {
                MessageBox.Show("Niepoprawna ilość wierchołków bądź połaczeń!", "Błąd!");
                return;
            }

            draw.NodeRadius = (int)sliderNodeRadius.Value;
            draw.Radius = (int)sliderRadius.Value;

            draw.DrawMainCircle();
            draw.Draw();
        }       

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            draw.ClearAll();
        }

        private void colorPickerPoints_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Resources["ColorPoints"] = new SolidColorBrush((Color)colorPickerPoints.SelectedColor);
        }

        private void colorPickerCircle_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Resources["ColorCircle"] = new SolidColorBrush((Color)colorPickerCircle.SelectedColor);
        }

        private void colorPickerLines_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Resources["ColorLines"] = new SolidColorBrush((Color)colorPickerLines.SelectedColor);
        }
    }
}

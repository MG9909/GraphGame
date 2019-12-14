using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp4
{
    public static class PeakShape
    {
        private static int turn = 0;
        private static Button peak { get; set; }
        private static int _peaks_quantity = 0;
        


        public static Button CreateEllipse(Thickness margin)
        {
            _peaks_quantity++;
            peak = new Button();
            peak.Click += MyClick;

            
            peak.Margin = margin;

            peak.Width = 50;
            peak.Height = 50;
 //           peak.Margin = new Thickness(left, top, 0, 500);


            ControlTemplate circleButtonTemplate = new ControlTemplate(typeof(Button));

            // Create the circle
            FrameworkElementFactory circle = new FrameworkElementFactory(typeof(Ellipse));

            FrameworkElementFactory txt = new FrameworkElementFactory(typeof(TextBlock));

            FrameworkElementFactory stack = new FrameworkElementFactory(typeof(Grid));


            circle.SetValue(Ellipse.FillProperty, Brushes.Gray);
            circle.SetValue(Ellipse.StrokeProperty, Brushes.RosyBrown);
            circle.SetValue(Ellipse.StrokeThicknessProperty, 3.0);

            circle.SetValue(Ellipse.OpacityProperty, 0.5);

            txt.SetValue(TextBlock.TextProperty, _peaks_quantity.ToString());
            txt.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Justify);
            txt.SetValue(TextBlock.ForegroundProperty, Brushes.White);

            /*    // Create the ContentPresenter to show the Button.Content
                FrameworkElementFactory presenter = new FrameworkElementFactory(typeof(ContentPresenter));
                presenter.SetValue(ContentPresenter.ContentProperty, new TemplateBindingExtension(Button.ContentProperty));
                presenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                presenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

                // Create the Grid to hold both of the elements
                FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
                grid.AppendChild(circle); 
                grid.AppendChild(presenter);
                */
            // Set the Grid as the ControlTemplate.VisualTree
            stack.AppendChild(circle);
            stack.AppendChild(txt);

            circleButtonTemplate.VisualTree = stack;

            // Set the ControlTemplate as the Button.Template
            peak.Template = circleButtonTemplate;
            return peak;
        }

        private static void MyClick(object sender, RoutedEventArgs e)
        {

            FrameworkElementFactory circle = new FrameworkElementFactory(typeof(Ellipse));

            if (turn % 2 == 0)
            {
                circle.SetValue(Ellipse.FillProperty, Brushes.Red);
                ((Button)sender).Foreground = null;
                ((Button)sender).Foreground = Brushes.Red;

            }
            else
            {
                circle.SetValue(Ellipse.FillProperty, Brushes.Blue);
                ((Button)sender).Foreground = null;
                ((Button)sender).Foreground = Brushes.Blue;
            }

            //            circle.SetValue(Ellipse.StrokeProperty, Brushes.RosyBrown);
            //            circle.SetValue(Ellipse.StrokeThicknessProperty, 1.0);

            ControlTemplate circleButtonTemplate = new ControlTemplate(typeof(Button));
            circleButtonTemplate.VisualTree = circle;

            ((Button)sender).Template = circleButtonTemplate;

            turn++;
        }
    }
}

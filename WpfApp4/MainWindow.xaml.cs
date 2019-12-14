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
using System.IO;
using System.Windows.Media.Animation;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> list = new List<string>();

        public static MainWindow Main;
        public MainWindow()
        {
            Main = this;
            InitializeComponent();
            intro.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/intro2.png")));
            intro2.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/intro2.png")));
            bg.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/bg.jpg")));
            Loaded += MyWindow_Loaded;

        }
        
        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePeak();
            for (int i = 0; i < 36; i++)
            {
                buttons[i].Click += Btn_Lines;
            }

        }
        public static List<Button> buttons = new List<Button>(36);

        public static string who_attacked;

        private int number = 0;
        public void CreatePeak()
        {
            int t = 0, k = 0;
            int z = 0;
            Thickness margin = new Thickness();
            margin.Left = 0;
            for (int i = 0; i < 6; i++)
            {
                margin.Top = -800 + (i * 150);
                for (k = 0; k <= i; k++)
                {
                    buttons.Add(PeakShape.CreateEllipse(margin));
                    main.Children.Add(buttons[number]);
                    margin.Left += 400;
                    number++;
                }
                margin.Left -= (600 + t * 100);
                t += 4;
                z++;
            }
            t = 8;
            margin.Left += 400;
            for (int i = 4; i >= 0; i--)
            {
                margin.Top = -800 + (z * 150);
                for (k = 0; k <= i; k++)
                {
                    buttons.Add(PeakShape.CreateEllipse(margin));
                    main.Children.Add(buttons[number]);
                    margin.Left += 400;
                    number++;
                }

                margin.Left -= (1000 + t * 100);
                t -= 4;
                z++;
            }

        }
        private static List<Line> ch = new List<Line>();
        


        private void Btn_Lines(object sender, RoutedEventArgs e)
        {
            int peak_chains = 0;   
            for (int i = 0; i < 36; i++)
            {
                if (((Button)sender).Margin.Top - buttons[i].Margin.Top <= 300 &&
                    ((Button)sender).Margin.Left - buttons[i].Margin.Left <= 300 &&
                    ((Button)sender).Margin.Top - buttons[i].Margin.Top >= -300 &&
                    ((Button)sender).Margin.Left - buttons[i].Margin.Left >= -300 &&
                    ((Button)sender).Foreground == buttons[i].Foreground)
                {
                    Line l = new Line();
                    Point btn1Point = ((Button)sender).TransformToAncestor(main).Transform(new Point(-25, 0));
                    Point btn2Point = buttons[i].TransformToAncestor(main).Transform(new Point(25, 0));


                    l.StrokeThickness = 3.0;
                    l.X1 = btn1Point.X + ((Button)sender).ActualWidth;
                    l.X2 = btn2Point.X;
                    l.Y1 = btn1Point.Y + ((Button)sender).ActualHeight / 2;
                    l.Y2 = btn2Point.Y + buttons[i].ActualHeight / 2;
                    ch.Add(l);
                    l.Stroke = ((Button)sender).Foreground;
                    peak_chains++;
                    main.Children.Add(l);


                    



                    if (((Button)sender).Foreground == Brushes.Red)
                    {
                        for (int z = 0; z < ch.Count; z++)
                        {
                            if (((l.X1 == ch[z].X1 && l.Y1 == ch[z].Y1) ||
                                (l.X2 == ch[z].X2 && l.Y2 == ch[z].Y2))
                                && ch[z].Stroke != Brushes.Red)
                            {
                                main.Children.Remove(ch[z]);
                                ch.RemoveAt(z);
                                z = 0;
                            }
                        }

                    }
                    else if (((Button)sender).Foreground == Brushes.Blue)
                    {
                        for (int z = 0; z < ch.Count; z++)
                        {
                            if (((l.X1 == ch[z].X1 && l.Y1 == ch[z].Y1) ||
                                (l.X2 == ch[z].X2 && l.Y2 == ch[z].Y2)) 
                                && ch[z].Stroke != Brushes.Blue)
                            {
                                main.Children.Remove(ch[z]);
                                ch.RemoveAt(z);
                                z = 0;
                            }
                        }

                    }
                }
            }
            if (peak_chains > 2 && ((Button)sender).Foreground == Brushes.Red)
            {

                Rectangle r = new Rectangle();
                r.Name = "snowball";
                r.Width = 80;
                r.Height = 80;
                r.Margin = (sender as Button).Margin;
                r.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/snowball-icon.png")))
                };

                ThicknessAnimation snowball_throw_animation = new ThicknessAnimation();

                who_attacked = "attack1";

                snowball_throw_animation.To = new Thickness(1250, -800, 0, 0);
                snowball_throw_animation.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                snowball_throw_animation.Completed += new EventHandler(snowball_throw_animation_Completed);

                snowball_throw_animation.Completed += (sende1r, e1) => {
                    switch(peak_chains)
                    {
                        case 4:
                            player2.Value -= 10;
                            player2_hp.Text = player2.Value.ToString() + "/100";
                            break;
                        case 5:
                            player2.Value -= 19;
                            player2_hp.Text = player2.Value.ToString() + "/100";
                            break;
                        case 6:
                            player2.Value -= 34;
                            player2_hp.Text = player2.Value.ToString() + "/100";
                            break;
                        case 7:
                            player2.Value -= 50;
                            player2_hp.Text = player2.Value.ToString() + "/100";
                            break;
                        default:
                            player2.Value -= 4;
                            player2_hp.Text = player2.Value.ToString() + "/100";
                            break;
                    }

                    if (player2.Value <= 0)
                    {
                        over_gif.Source = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/game_over.gif"));

                        DoubleAnimation da = new DoubleAnimation();
                        da.From = 1;
                        da.To = 0;
                        da.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                        DoubleAnimation da2 = new DoubleAnimation();
                        da2.From = 0;
                        da2.To = 1;
                        da2.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                        da.Completed += (obj, x) =>
                        {
                            over_gif.BeginAnimation(OpacityProperty, da2);
                            over_gif.Play();
                        };
                        main.BeginAnimation(OpacityProperty, da);
                        
                    }
                };

                snowball_throw_animation.Completed += (sende1r, e1) => main.Children.Remove(r);

                r.BeginAnimation(Rectangle.MarginProperty, snowball_throw_animation);

                main.Children.Add(r);



            }
            else if (peak_chains > 2 && ((Button)sender).Foreground == Brushes.Blue)
            {
                Rectangle r = new Rectangle();
                r.Name = "snowball";
                r.Width = 80;
                r.Height = 80;
                r.Margin = (sender as Button).Margin;
                r.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/snowball-icon.png")))
                };

                ThicknessAnimation snowball_throw_animation = new ThicknessAnimation();
                who_attacked = "attack2";
                snowball_throw_animation.To = new Thickness(-1050, -800, 0, 0);
                snowball_throw_animation.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                snowball_throw_animation.Completed += new EventHandler(snowball_throw_animation_Completed);
                snowball_throw_animation.Completed += (sende1r, e1) => main.Children.Remove(r);

                r.BeginAnimation(Rectangle.MarginProperty, snowball_throw_animation);

                main.Children.Add(r);


                snowball_throw_animation.Completed += (sende1r, e1) => {
                    switch (peak_chains)
                    {
                        case 4:
                            player1.Value -= 10;
                            player1_hp.Text = player1.Value.ToString() + "/100";
                            break;
                        case 5:
                            player1.Value -= 19;
                            player1_hp.Text = player1.Value.ToString() + "/100";
                            break;
                        case 6:
                            player1.Value -= 34;
                            player1_hp.Text = player1.Value.ToString() + "/100";
                            break;
                        case 7:
                            player1.Value -= 50;
                            player1_hp.Text = player1.Value.ToString() + "/100";
                            break;
                        default:
                            player1.Value -= 4;
                            player1_hp.Text = player1.Value.ToString() + "/100";
                            break;
                    }

                    if (player1.Value <= 0)
                    {
                        over_gif.Source = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/game_over.gif"));

                        DoubleAnimation da = new DoubleAnimation();
                        da.From = 1;
                        da.To = 0;
                        da.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                        DoubleAnimation da2 = new DoubleAnimation();
                        da2.From = 0;
                        da2.To = 1;
                        da2.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                        da.Completed += (obj, x) =>
                        {
                            over_gif.BeginAnimation(OpacityProperty, da2);
                            over_gif.Play();
                        };
                        main.BeginAnimation(OpacityProperty, da);
                    }
                };

            }

        }

        private void snowball_throw_animation_Completed(object sender, EventArgs e)
        {

            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0.5;
            da.Duration = new Duration(TimeSpan.FromSeconds(2.5));

            if (who_attacked == "attack1")
            {
                intro.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/smash.jpg")));

                da.Completed += (sende1r, e1) =>
                {
                    intro2.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/intro2.png")));
                    intro.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/intro2.png")));
                    intro.Opacity = 0.5;
                    intro2.Opacity = 0.5;

                };
                intro.BeginAnimation(ImageBrush.OpacityProperty, da);

            }
            else if (who_attacked == "attack2")
            {



                intro2.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/smash2.jpg")));

                da.Completed += (sende1r, e1) =>
                {
                    intro2.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/intro2.png")));
                    intro.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images/intro2.png")));

                };
                intro2.BeginAnimation(ImageBrush.OpacityProperty, da);
            }

            







        }


    }


}

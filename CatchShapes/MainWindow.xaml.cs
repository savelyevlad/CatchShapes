using CatchShapes.shapes;
using CatchShapes.shapes.circle.circles;
using CatchShapes.shapes.square.squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace CatchShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timerDrawer = new DispatcherTimer();
        private DispatcherTimer timerSpawner = new DispatcherTimer();
        private DispatcherTimer timerEnder = new DispatcherTimer();
        private DispatcherTimer timerTimeLeft = new DispatcherTimer();
        private Random random = new Random();
        private int score = 0;

        private int redCircles = 0;
        private int greenCircles = 0;
        private int redSquares = 0;
        private int greenSquares = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            timerDrawer.Interval = new TimeSpan(0, 0, 0, 0, 5); // redraw every 5 milisec
            timerDrawer.Tick += timerDrawer_Tick;
            timerDrawer.Start();

            timerEnder.Interval = new TimeSpan(0, 0, 0, 20, 0); // 20 second for a game
            timerEnder.Tick += timerEnder_Tick;
            timerSpawner.Interval = new TimeSpan(0, 0, 0, 0, 100); // spawn every 100 milisec
            timerSpawner.Tick += timerSpawner_Tick;

            timerTimeLeft.Interval = new TimeSpan(0, 0, 0, 1, 0); // renew every second
            timerTimeLeft.Tick += timerTimeLeft_Tick;
        }

        void timerDrawer_Tick(object sender, EventArgs e)
        {
            foreach (var item in shapes.ToList())
            {
                item.move();
            }
        }

        private HashSet<Movable> shapes = new HashSet<Movable>();

        public void deleteFromSet(Movable shape)
        {
            shapes.Remove(shape);
        }

        public void changeScore(int delta, MyShape shape)
        {
            if(shape is RedCircle) {
                ++redCircles;
                txtRedCircles.Text = redCircles.ToString();
            }
            else if(shape is RedSquare) {
                ++redSquares;
                txtRedSquares.Text = redSquares.ToString();
            }
            else if(shape is GreenCircle) {
                ++greenCircles;
                txtGreenCircles.Text = greenCircles.ToString();
            }
            else {
                ++greenSquares;
                txtGreenSquares.Text = greenSquares.ToString();
            }
            score += delta;
            txtScore.Text = score.ToString();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            buttonPlay.IsEnabled = false;
            timeLeft = 20;
            startGame();
            timerTimeLeft.Start();
        }

        private int timeLeft;

        private void timerTimeLeft_Tick(object sender, EventArgs e)
        {
            --timeLeft;
            txtTimeLeft.Text = timeLeft.ToString();
        }

        private void ButtonRules_Click(object sender, RoutedEventArgs e)
        {
            new RulesWindow().ShowDialog();
        }

        void startGame()
        {
            score = 0;
            redSquares = 0;
            redCircles = 0;
            greenSquares = 0;
            greenCircles = 0;
            txtScore.Text = "0";
            txtRedSquares.Text = "0";
            txtRedCircles.Text = "0";
            txtGreenSquares.Text = "0";
            txtGreenCircles.Text = "0";
            txtTimeLeft.Text = "20";
            timerSpawner.Start();
            timerEnder.Start();
        }

        private void timerEnder_Tick(object sender, EventArgs e)
        {
            timerSpawner.Stop();
            timerTimeLeft.Stop();
            MessageBox.Show("You scored: " + score.ToString());
            buttonPlay.IsEnabled = true;
        }

        private void timerSpawner_Tick(object sender, EventArgs e)
        {
            int minSpeed = 4;
            int maxSpeed = 7;
            int maxSpawnY = 800 - 200 - 35;
            int kek = random.Next(4);
            switch (kek)
            {
                case 1:
                    createShape(typeof(GreenCircle), random.Next(0, maxSpawnY), random.Next(minSpeed, maxSpeed));
                    break;
                case 2:
                    createShape(typeof(RedCircle), random.Next(0, maxSpawnY), random.Next(minSpeed, maxSpeed));
                    break;
                case 3:
                    createShape(typeof(GreenSquare), random.Next(0, maxSpawnY), random.Next(minSpeed, maxSpeed));
                    break;
                case 0:
                    createShape(typeof(RedSquare), random.Next(0, maxSpawnY), random.Next(minSpeed, maxSpeed));
                    break;
            }
        }

        private void createShape(Type type, int y, int speed)
        {
            object o = Activator.CreateInstance(type, new object[] { new Thickness(y, -35, 0, 0), this, speed });
            shapes.Add((Movable)o);
        }
    }
}

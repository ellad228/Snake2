using System.Runtime.CompilerServices;
using System.Windows.Forms.Design.Behavior;

namespace Snake2
{
    public partial class Form1 : Form
    {

        private List<Square> snake = new List<Square>();
        private Square food = new Square();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown;

        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;

            for (int i = 0; i < snake.Count; i++)
            {
                snakeColour = Brushes.Green;
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }

                canvas.FillRectangle(snakeColour, new Rectangle
                    (
                    snake[i].x * Settings.Width,
                    snake[i].y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));

            }
            canvas.FillRectangle(Brushes.Red, new Rectangle
                    (
                    food.x * Settings.Width,
                    food.y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            else if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            else if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }

            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left": snake[i].x--; break;
                        case "right": snake[i].x++; break;
                        case "up": snake[i].y--; break;
                        case "down": snake[i].y++; break;
                    }
                    if (snake[i].x < 0)
                    {
                        snake[i].x = maxWidth;
                    }
                    if (snake[i].x > maxWidth)
                    {
                        snake[i].x = 0;
                    }
                    if (snake[i].y < 0)
                    {
                        snake[i].y = maxHeight;
                    }
                    if (snake[i].y > maxHeight)
                    {
                        snake[i].y = 0;
                    }

                    if (snake[i].x == food.x && snake[i].y == food.y)
                    {
                        EatFood();
                    }
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].x == snake[j].x && snake[i].y == snake[j].y)
                        {
                            GameOver();
                        }
                    }

                }
                else
                {
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }
            }
            picCanvas.Invalidate();
        }
        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            snake.Clear();
            startButton.Enabled = false;

            score = 0;
            scoreLabel.Text = "Score: " + score;

            Square head = new Square { x = 20, y = 10 };
            snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Square body = new Square();
                snake.Add(body);
            }

            food = new Square { x = rand.Next(2, maxWidth), y = rand.Next(2, maxHeight) };

            GameTimer.Start();
        }
        private void EatFood()
        {
            score++;

            scoreLabel.Text = "Score: " + score;

            Square body = new Square
            {
                x = snake[snake.Count - 1].x,
                y = snake[snake.Count - 1].y
            };

            snake.Add(body);

            food = new Square { x = rand.Next(2, maxWidth), y = rand.Next(2, maxHeight) };
        }
        private void GameOver()
        {
            GameTimer.Stop();
            startButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                highScoreLabel.Text = "High score: " + highScore;
                highScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
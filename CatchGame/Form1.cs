using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchGame
{
    public partial class Form1 : Form
    {
        Rectangle hero = new Rectangle(280, 540, 40, 10);
        int heroSpeed = 10;

        List<Rectangle> balls = new List<Rectangle>();
        List<int> ballSpeeds = new List<int>();
        List<string> ballColours = new List<string>();

        int ballSize = 10;
        int ballSpeed = 7;

        int score = 0;
        int time = 500;

        bool leftDown = false;
        bool rightDown = false;

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Random randGen = new Random();
        int randValue = 0;

        int groundHeight = 50;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }

        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //move player
            if (leftDown == true && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }

            if (rightDown == true && hero.X < this.Width - hero.Width)
            {
                hero.X += heroSpeed;
            }

            //move ball objects
            for (int i = 0; i < balls.Count; i++)
            {
                int y = balls[i].Y + ballSpeeds[i];
                balls[i] = new Rectangle(balls[i].X, y, ballSize, ballSize);
            }

            //generate a random value
            randValue = randGen.Next(1, 101);

            //generate new ball if it is time
            if (randValue < 3)
            {
                balls.Add(new Rectangle(randGen.Next(0, this.Width - ballSize), 0, ballSize, ballSize));
                ballColours.Add("red");
                ballSpeeds.Add(16);
            }
            else if (randValue < 8)
            {
                balls.Add(new Rectangle(randGen.Next(0, this.Width - ballSize), 0, ballSize, ballSize));
                ballColours.Add("yellow");
                ballSpeeds.Add(12);
            }
            else if (randValue < 20)
            {
                balls.Add(new Rectangle(randGen.Next(0, this.Width - ballSize), 0, ballSize, ballSize));
                ballColours.Add("green");
                ballSpeeds.Add(4);
            }

            //remove ball if it goes off the screen, (test at y = 400)
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].Y >= this.Height)
                {
                    balls.RemoveAt(i);
                    ballColours.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                }
            }

            //check for collision between any ball and player
            for (int i = 0; i < balls.Count; i++)
            {
                if (hero.IntersectsWith(balls[i]))
                {
                    if (ballColours[i] == "green")
                    {
                        score = score + 5;  // score += 5;
                    }
                    else if (ballColours[i] == "yellow")
                    {
                        time = time + 50;
                    }
                    else if (ballColours[i] == "red")
                    {
                        score = score - 10;
                    }

                    balls.RemoveAt(i);
                    ballColours.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                    
                }
            }

            //decrease time
            time--;

            //end game if time runs out
            if (time <= 0)
            {
                gameLoop.Enabled = false;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //update labels
            timeLabel.Text = $"{time}";
            scoreLabel.Text = $"Score: {score}";

            //draw ground
            e.Graphics.FillRectangle(greenBrush, 0, this.Height - groundHeight,
                this.Width, groundHeight);

            //draw hero
            e.Graphics.FillRectangle(whiteBrush, hero);

            //draw balls
            for (int i = 0; i < balls.Count(); i++)
            {
                if (ballColours[i] == "green")
                {
                    e.Graphics.FillEllipse(greenBrush, balls[i]);
                }
                else if (ballColours[i] == "red")
                {
                    e.Graphics.FillEllipse(redBrush, balls[i]);
                }
                else if (ballColours[i] == "yellow")
                {
                    e.Graphics.FillEllipse(yellowBrush, balls[i]);
                }
            }

        }
    }
}

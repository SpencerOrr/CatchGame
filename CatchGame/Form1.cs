using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CatchGame
{
    public partial class Form1 : Form
    {
        Rectangle hero = new Rectangle(350, 200, 10, 20);
        Rectangle hero2 = new Rectangle(450, 350, 10, 20);

        int heroSpeed = 8;

        List<Rectangle> balls = new List<Rectangle>();
        List<Rectangle> balls2 = new List<Rectangle>();
        List<int> ballSpeeds = new List<int>();
        List<int> ballSpeeds2 = new List<int>();

        int ballSize = 10;
        int time = 378;
        int hero1score = 0;
        int hero2score = 0;

        bool upDown = false;
        bool downDown = false;
        bool wDown = false;
        bool sDown = false;
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();

        int randValue = 0;

        SoundPlayer crash = new SoundPlayer(Properties.Resources.Explosion__sound_effect_);
        SoundPlayer point = new SoundPlayer(Properties.Resources.mixkit_retro_game_notification_212);
        SoundPlayer over = new SoundPlayer(Properties.Resources.Game_Over_Sound_Effect);
        string gameState = "waiting";
        public Form1()
        {
            InitializeComponent();
        }
        public void GameSetup()
        {
            winLabel.Visible = false;
            gameState = "running";

            gameLoop.Enabled = true;

            hero.X = 200;
            hero.Y = 350;

            titleLabel.Text = "";
            subTitlelabel.Text = "";
            balls.Clear();
            ballSpeeds.Clear();
            balls2.Clear();
            ballSpeeds2.Clear();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameSetup();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        this.Close();
                    }
                    break;
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }

        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            time--;
            //move player            
            if (upDown == true)
            {
                hero2.Y -= heroSpeed;
            }
            if (downDown == true && hero2.Y < this.Height - hero2.Height)
            {
                hero2.Y += heroSpeed;
            }
            if (wDown == true)
            {
                hero.Y -= heroSpeed;
            }
            if (sDown == true && hero.Y < this.Height - hero.Height)
            {
                hero.Y += heroSpeed;
            }

            //move ball objects
            for (int i = 0; i < balls.Count; i++)
            {
                int x = balls[i].X + ballSpeeds[i];
                balls[i] = new Rectangle(x, balls[i].Y, ballSize, 5);
            }
            for (int i = 0; i < balls2.Count; i++)
            {
                int x = balls2[i].X - ballSpeeds[i];
                balls2[i] = new Rectangle(x, balls2[i].Y, ballSize, 5);
            }
            //generate a random value
            randValue = randGen.Next(1, 101);

            //generate new ball if it is time
            if (randValue > 80)
            {
                balls.Add(new Rectangle(0, randGen.Next(0, 340), ballSize, 5));
                ballSpeeds.Add(3);
            }
            if (randValue > 80)
            {
                balls2.Add(new Rectangle(this.Width, randGen.Next(0, 340), ballSize, 5));
                ballSpeeds2.Add(3);
            }
            //remove ball if it goes off the screen
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].X >= this.Width)
                {
                    balls.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                }
            }
            for (int i = 0; i < balls2.Count; i++)
            {
                if (balls2[i].X <= 0)
                {
                    balls2.RemoveAt(i);
                    ballSpeeds2.RemoveAt(i);
                }
            }

            //check for collision between any ball and player
            for (int i = 0; i < balls.Count; i++)
            {
                if (hero.IntersectsWith(balls[i]))
                {
                    hero.Y = 350;
                    crash.Play();
                }
                else if (hero2.IntersectsWith(balls[i]))
                {
                    hero2.Y = 350;
                    crash.Play();
                }
            }
            if (hero.Y <= -10)
            {
                hero1score++;
                hero1Points.Text = $"Points {hero1score}";
                hero.Y = 350;
                point.Play();

            }
            if (hero2.Y <= -10)
            {
                hero2score++;
                hero2Points.Text = $"Points {hero2score}";
                hero2.Y = 350;
                point.Play();

            }
            if (time <= 0)
            {
                gameState = "over";
                gameLoop.Enabled = false;
                over.Play();
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle timer = new Rectangle(300, 378 - time, 20, time);

            if (gameState == "waiting")
            {
                titleLabel.Text = "Space Race";
                subTitlelabel.Text = "Press Space to Start or Esc to Exit";
            }
            else if (gameState == "running")
            {
                //update labels
                //
                //draw hero
                e.Graphics.FillRectangle(whiteBrush, hero);
                e.Graphics.FillRectangle(whiteBrush, hero2);
                e.Graphics.FillRectangle(whiteBrush, timer);
                for (int i = 0; i < balls.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, balls[i]);
                }
                for (int i = 0; i < balls2.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, balls2[i]);
                }

            }
            else if (gameState == "over")
            {
                subTitlelabel.Text = "Press Space to Start or Esc to Exit";

                time = 500;
                winLabel.Visible = true;
                if (hero1score > hero2score)
                {
                    winLabel.Text = "Hero 1 Wins";
                }
                else if (hero1score < hero2score)
                {
                    winLabel.Text = "Hero 2 Wins";
                }
                else
                {
                    winLabel.Text = "Tie";
                }
                hero1score = 0;
                hero2score = 0;
                hero1Points.Text = $"Points {hero1score}";
            }
        }
    }
}

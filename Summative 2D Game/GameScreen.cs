using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Summative_2D_Game
{
    public partial class GameScreen : UserControl
    {
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, shiftDown;

        SolidBrush heroBrush = new SolidBrush(Color.Black);
        SolidBrush livesBrush = new SolidBrush(Color.Red);

        Hero hero;
        Enemy enemy1, enemy2;
        Attacks attackBall;
        Rectangle enemyRec1, enemyRec2, heroRec, attackRec;
        const int HEROSPEED = 5;
        const int ENEMYSPEED = 3;

        //animation variables
        Image heroSprite, enemySprite1, enemySprite2;
        int animationCounterH, animationCounterE;
        int frameCounter = 1;

        //border
        List<Rectangle> borders = new List<Rectangle>();
        List<Rectangle> lives = new List<Rectangle>();
        List<Image> heroAnimation = new List<Image>();
        List<Image> enemyAnimation = new List<Image>();

        //attack variables
        string direction;
        Boolean shoot = false;


        public GameScreen()
        {
            InitializeComponent();
            OnStart();

            #region initialize border rectangles
            //sides
            borders.Add(new Rectangle(0, 0, this.Width, 20));
            borders.Add(new Rectangle(0, this.Height - 20, this.Width, 20));
            borders.Add(new Rectangle(0, 0, 20, this.Height / 2 - 50));
            borders.Add(new Rectangle(0, this.Height / 2 + 50, 20, this.Height / 2 - 50));
            borders.Add(new Rectangle(this.Width - 20, 0, 20, this.Height / 2 - 50));
            borders.Add(new Rectangle(this.Width - 20, this.Height / 2 + 50, 20, this.Height / 2 - 50));

            //middle sections
            borders.Add(new Rectangle(130, 90, 70, 200));
            borders.Add(new Rectangle(420, 90, 70, 200));

            #endregion

            #region initializing lives rectangles
            lives.Add(new Rectangle(500, 5, 20, 20));
            lives.Add(new Rectangle(530, 5, 20, 20));
            lives.Add(new Rectangle(560, 5, 20, 20));

            #endregion

            #region initialize images/animation variables
            //putting hero sprites in a list
            heroSprite = Properties.Resources.heroWalkR1;
            heroAnimation.Add(Properties.Resources.heroWalkF1);
            heroAnimation.Add(Properties.Resources.heroWalkF2);
            heroAnimation.Add(Properties.Resources.heroWalkB1);
            heroAnimation.Add(Properties.Resources.heroWalkB2);
            heroAnimation.Add(Properties.Resources.heroWalkL1);
            heroAnimation.Add(Properties.Resources.heroWalkL2);
            heroAnimation.Add(Properties.Resources.heroWalkR1);
            heroAnimation.Add(Properties.Resources.heroWalkR2);

            //putting enemy sprites in a list
            enemySprite1 = Properties.Resources.walkL1;
            enemySprite2 = Properties.Resources.walkR1;
            enemyAnimation.Add(Properties.Resources.walkF1);
            enemyAnimation.Add(Properties.Resources.WalkF2);
            enemyAnimation.Add(Properties.Resources.walkB1);
            enemyAnimation.Add(Properties.Resources.walkB2);
            enemyAnimation.Add(Properties.Resources.walkL1);
            enemyAnimation.Add(Properties.Resources.walkL2);
            enemyAnimation.Add(Properties.Resources.walkR1);
            enemyAnimation.Add(Properties.Resources.walkR2);

            animationCounterH = 0;
            animationCounterE = 0;
            #endregion

            


        }
        public void OnStart()
        {
            hero = new Hero(20, 170, 40);

            enemy1 = new Enemy(100, 40, 40);
            enemy2 = new Enemy(this.Width - 100, this.Height - 60, 40);

            attackBall = new Attacks(hero.x, hero.y, 20);
            attackRec = new Rectangle(attackBall.x, attackBall.y, attackBall.size, attackBall.size);
            direction = "left";
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Shift:
                    shiftDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Shift:
                    shiftDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region update hero movement
            

            if (downArrowDown == true)
            {
                hero.MoveUpDown(HEROSPEED);
                direction = "down";
                animationCounterH++;
                if (animationCounterH == 3)
                {

                    if (frameCounter == 1)
                    {
                        heroSprite = heroAnimation[0];
                        animationCounterH = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        heroSprite = heroAnimation[1];
                        animationCounterH = 0;
                        frameCounter = 1;
                    }
                }


            }
            if (upArrowDown == true)
            {
                hero.MoveUpDown(-HEROSPEED);
                direction = "up";
                animationCounterH++;
                if (animationCounterH == 3)
                {

                    if (frameCounter == 1)
                    {
                        heroSprite = heroAnimation[2];
                        animationCounterH = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        heroSprite = heroAnimation[3];
                        animationCounterH = 0;
                        frameCounter = 1;
                    }
                }


            }
            if (leftArrowDown == true)
            {
                hero.MoveRightLeft(-HEROSPEED);
                direction = "left";
                animationCounterH++;
                if (animationCounterH == 3)
                {

                    if (frameCounter == 1)
                    {
                        heroSprite = heroAnimation[4];
                        animationCounterH = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        heroSprite = heroAnimation[5];
                        animationCounterH = 0;
                        frameCounter = 1;
                    }
                }


            }
            if (rightArrowDown)
            {
                hero.MoveRightLeft(HEROSPEED);
                direction = "right";
                animationCounterH++;
                if (animationCounterH == 3)
                {

                    if (frameCounter == 1)
                    {
                        heroSprite = heroAnimation[6];
                        animationCounterH = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        heroSprite = heroAnimation[7];
                        animationCounterH = 0;
                        frameCounter = 1;
                    }
                }

            }

            #endregion

            #region enemy move update
            if (enemy1.x >= 250 && enemy1.y <= this.Height - 60)
            {
                enemy1.Move(ENEMYSPEED, "down");
                enemy2.Move(-ENEMYSPEED, "down");
                animationCounterE++;
                if (animationCounterE == 7)
                {

                    if (frameCounter == 1)
                    {
                        enemySprite1 = enemyAnimation[0];
                        enemySprite2 = enemyAnimation[2];
                        animationCounterE = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        enemySprite1 = enemyAnimation[1];
                        enemySprite2 = enemyAnimation[3];
                        animationCounterE = 0;
                        frameCounter = 1;
                    }
                }
            }
            else if (enemy1.y <= 40)
            {
                enemy1.Move(ENEMYSPEED, "right");
                enemy2.Move(-ENEMYSPEED, "right");

                animationCounterE++;
                if (animationCounterE == 7)
                {
                    if (frameCounter == 1)
                    {
                        enemySprite1 = enemyAnimation[6];
                        enemySprite2 = enemyAnimation[4];
                        animationCounterE = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        enemySprite1 = enemyAnimation[7];
                        enemySprite2 = enemyAnimation[5];
                        animationCounterE = 0;
                        frameCounter = 1;
                    }
                }
            }
            else if (enemy1.x <= 80)
            {
                enemy1.Move(ENEMYSPEED, "up");
                enemy2.Move(-ENEMYSPEED, "up");

                animationCounterE++;
                if (animationCounterE == 7)
                {
                    if (frameCounter == 1)
                    {
                        enemySprite1 = enemyAnimation[2];
                        enemySprite2 = enemyAnimation[0];
                        animationCounterE = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        enemySprite1 = enemyAnimation[3];
                        enemySprite2 = enemyAnimation[1];
                        animationCounterE = 0;
                        frameCounter = 1;
                    }
                }
            }
            else if (enemy1.y >= this.Height - 60)
            {
                enemy1.Move(ENEMYSPEED, "left");
                enemy2.Move(-ENEMYSPEED, "left");

                animationCounterE++;
                if (animationCounterE == 7)
                {
                    if (frameCounter == 1)
                    {
                        enemySprite1 = enemyAnimation[4];
                        enemySprite2 = enemyAnimation[6];
                        animationCounterE = 0;
                        frameCounter = 2;
                    }
                    else
                    {
                        enemySprite1 = enemyAnimation[5];
                        enemySprite2 = enemyAnimation[7];
                        animationCounterE = 0;
                        frameCounter = 1;
                    }
                }
            }
                enemyRec1 = new Rectangle(enemy1.x, enemy1.y, enemy1.size, enemy1.size);
                enemyRec2 = new Rectangle(enemy2.x, enemy2.y, enemy2.size, enemy2.size);

                #endregion


            #region collision checks
            heroRec = new Rectangle(hero.x, hero.y, hero.size, hero.size);
            int lifeCount = lives.Count;
            if (heroRec.IntersectsWith(enemyRec1) && lifeCount > 0 || heroRec.IntersectsWith(enemyRec2) && lifeCount > 0)
            {
                if (leftArrowDown)
                {
                    hero.Stop("left", 15);
                }
                if (rightArrowDown)
                {
                    hero.Stop("right", 15);

                }
                if (upArrowDown)
                {
                    hero.Stop("up", 15);

                }
                if (downArrowDown)
                {
                    hero.Stop("down", 15);
                }

                lives.RemoveAt(lifeCount - 1);

                Thread.Sleep(1000);
            }


            foreach (Rectangle i in borders)
            {
                if (heroRec.IntersectsWith(i))
                {
                    if (leftArrowDown)
                    {
                        hero.Stop("left", HEROSPEED);
                    }
                    if (rightArrowDown)
                    {
                        hero.Stop("right", HEROSPEED);

                    }
                    if (upArrowDown)
                    {
                        hero.Stop("up", HEROSPEED);

                    }
                    if (downArrowDown)
                    {
                        hero.Stop("down", HEROSPEED);
                    }
                }
            }

            #endregion

            if (shiftDown == true)
            {
                attackBall.Shoot(10, direction);
                shoot = true;

            }

            Refresh();
            
        }
            private void GameScreen_Paint(object sender, PaintEventArgs e)
            {

                //redrawing hero
                e.Graphics.DrawImage(heroSprite, hero.x, hero.y, hero.size, hero.size);

                //redrawing enemies
                e.Graphics.DrawImage(enemySprite1, enemy1.x, enemy1.y, enemy1.size, enemy1.size);
                e.Graphics.DrawImage(enemySprite2, enemy2.x, enemy2.y, enemy2.size, enemy2.size);

                //drawing borders
                foreach (Rectangle i in borders)
                {
                    e.Graphics.FillRectangle(heroBrush, i);
                }

                //drawing lives
                foreach (Rectangle r in lives)
                {
                    e.Graphics.FillRectangle(livesBrush, r);
                }

                if (shoot == true)
                {
                e.Graphics.DrawImage(Properties.Resources.orb1, attackBall.x, attackBall.y, attackBall.size, attackBall.size);
                }


            }


        }
    }


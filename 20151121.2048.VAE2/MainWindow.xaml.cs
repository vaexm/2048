using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20151121._2048.VAE2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Image []coverimg=new Image[16];
        Random r = new Random();
        int m,n;
        MoveWay[] mov = new MoveWay[16];
        //用来存放有了数字的img的num
        List<int> laNum = new List<int>();
        //用来记录要移动的那一行或一列中本身就有数字的那个img的标号
        List<int> movNum = new List<int>();
        //用来存放要移动的那一列或一行
        List<MoveWay> movla = new List<MoveWay>();
        //记录分数的label
        Label laScore;
        int score;
        //用来判断按键是上下左右，在调用FindMoveimg方法时使用
        string temple = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main();
        }

        private void Main()
        {
            laScore = new Label();
            laScore.Width = 100;
            laScore.Height = 57;
            laScore.FontSize = 20;
            laScore.Foreground = Brushes.DeepPink;
            laScore.Content = score;
            laScore.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            laScore.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            Canvas.SetLeft(laScore, 367);
            Canvas.SetTop(laScore, 20);
            back.Children.Add(laScore);
            m = r.Next(0, 16);
            //m = 12;
            for (int i = 0; i < 16; i++)
            {
                mov[i] = new MoveWay(i);
                coverimg[i] = new Image();
                coverimg[i].Width = 60;
                coverimg[i].Height = 90;
                coverimg[i].Stretch = Stretch.Fill; coverimg[i].Tag = 0;
                coverimg[i].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
                Canvas.SetLeft(coverimg[i], i % 4 * coverimg[i].Width);
                Canvas.SetTop(coverimg[i], 30 + i / 4 * coverimg[i].Height);
                back.Children.Add(coverimg[i]);
                if (i == m)
                {
                    NewImg(i);
                }
            }
        }

        private void NewImg(int i)
        {
            n = r.Next(1,3);
           
                coverimg[i].Source = new BitmapImage(new Uri("images/"+1+".png", UriKind.Relative));
                coverimg[i].Tag = 1;
                mov[i].IsNum = true;
         
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Up)
            {
                temple = "上";
                movla.Clear();
                //找到要移动的第一列，按列移动
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsT1 == true)
                    {
                        movla.Add(mov[j]);

                    }

                }
                FindMoveimg();     
                movla.Clear();
                for (int i = 0; i < 16; i++)
                {
                    if (mov[i].IsT2 == true)
                    {
                        movla.Add(mov[i]);
                    }
                }
                FindMoveimg();
                movla.Clear();
                for (int i = 0; i < 16; i++)
                {
                    if (mov[i].IsT3 == true)
                    {
                        movla.Add(mov[i]);
                    }
                }
                FindMoveimg();
                movla.Clear();
                for (int i = 0; i < 16; i++)
                {
                    if (mov[i].IsT4 == true)
                    {
                        movla.Add(mov[i]);
                    }
                }
                FindMoveimg();              
            }
            if(e.Key==Key.Down)
            {
                temple = "下";
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsT1 == true)
                    {
                        movla.Add(mov[j]);
                    }

                }
                movla.Reverse();
                FindMoveimg();
                movla.Clear();
                for (int i = 0; i < 16; i++)
                {
                    if (mov[i].IsT2 == true)
                    {
                        movla.Add(mov[i]);
                    }
                }
                movla.Reverse();
                FindMoveimg();
                movla.Clear();
                for (int i = 0; i < 16; i++)
                {
                    if (mov[i].IsT3 == true)
                    {
                        movla.Add(mov[i]);
                    }
                }
                movla.Reverse();
                FindMoveimg();
                movla.Clear();
                for (int i = 0; i < 16; i++)
                {
                    if (mov[i].IsT4 == true)
                    {
                        movla.Add(mov[i]);
                    }
                }
                movla.Reverse();
                FindMoveimg();
               
            }
            if(e.Key==Key.Left)
            {
                temple = "左";
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL1 == true)
                    {
                        movla.Add(mov[j]);
                    }

                }
                FindMoveimg();
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL2 == true)
                    {
                        movla.Add(mov[j]);

                    }

                }
                FindMoveimg();
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL3 == true)
                    {
                        movla.Add(mov[j]);

                    }

                }
                FindMoveimg();
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL4 == true)
                    {
                        movla.Add(mov[j]);

                    }

                }
                FindMoveimg();
            }
            if(e.Key==Key.Right)
            {
                temple = "右";
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL1 == true)
                    {
                        movla.Add(mov[j]);
                    }

                }
                movla.Reverse();
                FindMoveimg();
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL2== true)
                    {
                        movla.Add(mov[j]);

                    }
                }
                movla.Reverse();
                FindMoveimg();
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL3 == true)
                    {
                        movla.Add(mov[j]);

                    }

                }
                movla.Reverse(); FindMoveimg();
                movla.Clear();
                for (int j = 0; j < 16; j++)
                {
                    if (mov[j].IsL4 == true)
                    {
                        movla.Add(mov[j]);

                    }

                }
                movla.Reverse(); FindMoveimg();
            }

            for (int i = 0; i < 16;i++ )
            {
                if(int.Parse(coverimg[i].Tag.ToString())==11)
                {
                    MessageBoxResult result = MessageBox.Show("你想要重新开始吗？", "恭喜你顺利通关", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        back.Children.Clear(); Main();
                        score = 0;
                     
                    } 
                }
            }
               bool GameOver = true;
               if (laNum.Count <16)
               {
                   IsSame();
                   NewImg(m);
                   laNum.Add(m);
               }
                //即16个格子里都有数字了
                if(laNum.Count>=16)
                {
                    //判断一个图片的上下左右是否有与它相同的图片，若没有，则游戏结束
                    for (int i = 0; i < 16; i++)
                    {
                        if ((mov[i].IsLinkT==true) && (coverimg[i].Source.ToString() == coverimg[i - 4].Source.ToString()))
                        {
                            GameOver = false;
                        }
                        if ((mov[i].IsLinkB==true) && (coverimg[i].Source.ToString() == coverimg[i + 4].Source.ToString()))
                        {
                            GameOver = false;
                        }
                        if ((mov[i].IsLinkL==true) &&(coverimg[i].Source.ToString() == coverimg[i - 1].Source.ToString()))
                        {
                            GameOver = false;
                        }
                        if ((mov[i].IsLinkR==true) && (coverimg[i].Source.ToString() == coverimg[i + 1].Source.ToString()))
                        {
                            GameOver = false;
                        }
                    }
                    if (GameOver == true)
                    {    
                         MessageBoxResult result = MessageBox.Show("你确定要重新开始吗？","GameOver",MessageBoxButton.YesNo);
                         if(result==MessageBoxResult.Yes)
                         {
                             back.Children.Clear();
                             score = 0;
                             Main();
                         }                      
                    }
                }            
            }

private void FindMoveimg()
{
            movNum.Clear();
            laNum.Clear();
            for (int k = 0; k < movla.Count; k++)
            {
                if (movla[k].IsNum)
                {
                    movNum.Add(movla[k].Num);
                }
            }
            if (movNum.Count > 1)
            {
                for (int i = 0; i < movNum.Count - 1; i++)
                {
                    if ((temple == "上") & (movNum[i + 1] - movNum[i] == 4) & (coverimg[movNum[i + 1]].Source.ToString() == coverimg[movNum[i]].Source.ToString()))
                    {
                        MoveTRLB(i);
                    }
                    else  if ((temple == "下") & (movNum[i] - movNum[i+1] == 4) & (coverimg[movNum[i + 1]].Source.ToString() == coverimg[movNum[i]].Source.ToString()))
                    {
                        MoveTRLB(i);
                    }
                    else  if ((temple == "左") & (movNum[i + 1] - movNum[i] == 1) & (coverimg[movNum[i + 1]].Source.ToString() == coverimg[movNum[i]].Source.ToString()))
                    {
                        MoveTRLB(i);
                    }
                    else if ((temple == "右") & (movNum[i] - movNum[i+1] == 1) & (coverimg[movNum[i + 1]].Source.ToString() == coverimg[movNum[i]].Source.ToString()))
                    {
                        MoveTRLB(i);
                    }
                }

            }
         
            for (int i = 0; i < movNum.Count; i++)
            {
                coverimg[movla[i].Num].Source = coverimg[movNum[i]].Source;
                mov[movla[i].Num].IsNum = true;
                coverimg[movla[i].Num].Tag = coverimg[movNum[i]].Tag;

            }
            if (movNum.Count < 4)
            {
                for (int i = movNum.Count; i < 4; i++)
                {

                    coverimg[movla[i].Num].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
                    mov[movla[i].Num].IsNum =false;
                    coverimg[movla[i].Num].Tag = 0;
                }
            }
            for (int i = 0; i < mov.Length; i++)
            {
                if (mov[i].IsNum == true)
                {
                    laNum.Add(i);
                 }

            }
}

private void MoveTRLB(int i)
{
    switch (int.Parse(coverimg[movNum[i]].Tag.ToString()))
    {
        case 1: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/2.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 2;
            score += 4;
            laScore.Content = score;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0;
            movNum.Remove(movNum[i + 1]);
            break;
        case 2: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/3.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i]].Tag = 3;
            mov[movNum[i]].IsNum = true; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
            score += 8;laScore.Content=score;
            break;
        case 3: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/4.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 4;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
              score += 16;laScore.Content=score;
            break;
        case 4: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/5.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 5;  score += 32;laScore.Content=score;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
            break;
        case 5: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/6.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 6;
              score += 64;laScore.Content=score;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
            break;
        case 6: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/7.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 7;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
              score += 128;laScore.Content=score;
            break;
        case 7: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/8.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 8;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
              score += 256;laScore.Content=score;
            break;
        case 8: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/9.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 9;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
              score += 512;laScore.Content=score;
            break;

        case 9: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/10.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 10;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
              score += 1024;laScore.Content=score;

            break;
        case 10: coverimg[movNum[i]].Source = new BitmapImage(new Uri("images/11.png", UriKind.Relative));
            coverimg[movNum[i + 1]].Source = new BitmapImage(new Uri("images/0.png", UriKind.Relative));
            mov[movNum[i]].IsNum = true; coverimg[movNum[i]].Tag = 11;
            mov[movNum[i + 1]].IsNum = false; coverimg[movNum[i + 1]].Tag = 0; movNum.Remove(movNum[i + 1]);
              score += 1024;laScore.Content=score;

            break;
    }
}       
        //利用递归，确保不能在已经有数字的label上再产生数字
        void IsSame()
        {
            m = r.Next(0, 16);
            foreach (int lanum in laNum)
            {
                if (m == lanum)
                {
                    IsSame();
                }
            }

        }
    }
}

using Microsoft.Win32;
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


namespace programmingContestDemo
{
    enum diceSize : int
    {
        large = 90,
        middle = 54,
        small = 36
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BitmapImage[] smallResource = new BitmapImage[6];
        BitmapImage[] middleResource = new BitmapImage[6];
        BitmapImage[] largeResource = new BitmapImage[6];

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] Sresource = new string[6] { @"/resource/sho1.png", @"/resource/sho2.png", @"/resource/sho3.png", @"/resource/sho4.png", @"/resource/sho5.png", @"/resource/sho6.png" };
            string[] Lresource = new string[6] { @"/resource/dai1.png", @"/resource/dai2.png", @"/resource/dai3.png", @"/resource/dai4.png", @"/resource/dai5.png", @"/resource/dai6.png" };
            string[] Mresource = new string[6] { @"/resource/chu1.png", @"/resource/chu2.png", @"/resource/chu3.png", @"/resource/chu4.png", @"/resource/chu5.png", @"/resource/chu6.png" };

            int i = 0 ;
            while(i<=Sresource.Length - 1 )
            {
                //リソースの割り振り
                smallResource[i] = new BitmapImage(new Uri(Sresource[i],UriKind.Relative));
                middleResource[i] = new BitmapImage(new Uri(Mresource[i],UriKind.Relative));
                largeResource[i] = new BitmapImage(new Uri(Lresource[i],UriKind.Relative));

                i++;

                //TextBoxを読み取り専用にする
                binaryData.IsReadOnly = true;
                
            }


        }        

        private void textOpen_Click(object sender, RoutedEventArgs e)
        {
            //ファイル選択ダイアログを出す
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.DefaultExt = "*.*";
            if (ofd.ShowDialog() == true)
            {
                //バイナリ読み出しクラス
                binread binRead = new binread(ofd.FileName);
                binaryData.Text = binRead.bindisplay();

                dicePreview();
            }
            else MessageBox.Show("テキストファイルを選択してください");
        }


        private void dicePreview()
        {
            //バイナリ値を読み出し
            string TextToDice = binaryData.Text;
            //行数を計算
            int Line = TextToDice.Length / 11 + 1;

            //サイコロを表示するためのUI配列を作成
            TextBlock[] LineNumber = new TextBlock[Line+1];
            StackPanel[] diceLinePanel = new StackPanel[Line+1];
            int nowLine = 0;

            while (nowLine <= Line)
            {


                diceLinePanel[nowLine] = new StackPanel();
                diceLinePanel[nowLine].Height = 100;
                diceLinePanel[nowLine].Orientation = Orientation.Horizontal;
                diceLinePanel[nowLine].MouseDown += MainWindow_MouseDown;
                diceLinePanel[nowLine].Tag = false;
                //diceLinePanel[nowLine].Background = new SolidColorBrush(Colors.Yellow);

                //行数
                LineNumber[nowLine] = new TextBlock();
                LineNumber[nowLine].Width = 40;
                LineNumber[nowLine].FontSize = 30;
                int stringNowLine = nowLine + 1;
                LineNumber[nowLine].Text = stringNowLine.ToString();

                //縦の長さを定義
                DiceLine.Height = nowLine * 100;

                DiceLine.Children.Add(diceLinePanel[nowLine]);
                diceLinePanel[nowLine].Children.Add(LineNumber[nowLine]);
                nowLine++;
            }


            //サイコロを格納するイメージ配列
            Image[] diceImg = new Image[TextToDice.Length];

            int i = 0;
            nowLine = 0;

            //一文字ずつバイナリ値を読み出し
            while (i < TextToDice.Length)
            {
                //サイコロの行パネル
 
                int pointx = 0;
                while (pointx < (int)diceSize.large * 9)
                {
                    //サイコロの画像を初期化
                    diceImg[i] = new Image();
                    diceImg[i].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    diceImg[i].VerticalAlignment = System.Windows.VerticalAlignment.Top;

                    switch (TextToDice[i].ToString())
                    {
                        case "0":
                            diceImg[i].Width = (int)diceSize.large;
                            diceImg[i].Source = largeResource[0];
                            //間隔
                            pointx = pointx + (int)diceSize.large;
                            break;

                        case "1":
                            diceImg[i].Width = (int)diceSize.large;
                            diceImg[i].Source = largeResource[1];
                            //間隔
                            pointx = pointx + (int)diceSize.large;
                            break;

                        case "2":
                            diceImg[i].Width = (int)diceSize.large;
                            diceImg[i].Source = largeResource[2];
                            //間隔
                            pointx = pointx + (int)diceSize.large;
                            break;

                        case "3":
                            diceImg[i].Width = (int)diceSize.large;
                            diceImg[i].Source = largeResource[3];
                            //間隔
                            pointx = pointx + (int)diceSize.large;
                            break;

                        case "4":
                            diceImg[i].Width = (int)diceSize.large;
                            diceImg[i].Source = largeResource[4];
                            //間隔
                            pointx = pointx + (int)diceSize.large;
                            break;

                        case "5":
                            diceImg[i].Width = (int)diceSize.large;
                            diceImg[i].Source = largeResource[5];
                            //間隔
                            pointx = pointx + (int)diceSize.large;
                            break;

                        case "6":
                            diceImg[i].Width = (int)diceSize.middle;
                            diceImg[i].Source = middleResource[0];
                            //間隔
                            pointx = pointx + (int)diceSize.middle;
                            break;

                        case "7":
                            diceImg[i].Width = (int)diceSize.middle;
                            diceImg[i].Source = middleResource[1];
                            //間隔
                            pointx = pointx + (int)diceSize.middle;
                            break;

                        case "8":
                            diceImg[i].Width = (int)diceSize.middle;
                            diceImg[i].Source = middleResource[2];
                            //間隔
                            pointx = pointx + (int)diceSize.middle;
                            break;

                        case "9":
                            diceImg[i].Width = (int)diceSize.middle;
                            diceImg[i].Source = middleResource[3];
                            //間隔
                            pointx = pointx + (int)diceSize.middle;
                            break;

                        case "a":
                            diceImg[i].Width = (int)diceSize.middle;
                            diceImg[i].Source = middleResource[4];
                            //間隔
                            pointx = pointx + (int)diceSize.middle;
                            break;

                        case "b":
                            diceImg[i].Width = (int)diceSize.middle;
                            diceImg[i].Source = middleResource[5];
                            //間隔
                            pointx = pointx + (int)diceSize.middle;
                            break;

                        case "c":
                            diceImg[i].Width = (int)diceSize.small;
                            diceImg[i].Source = smallResource[0];
                            //間隔\
                            pointx = pointx + (int)diceSize.small;
                            break;

                        case "d":
                            diceImg[i].Width = (int)diceSize.small;
                            diceImg[i].Source = smallResource[1];
                            //間隔
                            pointx = pointx + (int)diceSize.small;
                            break;

                        case "e":
                            diceImg[i].Width = (int)diceSize.small;
                            diceImg[i].Source = smallResource[2];
                            //間隔
                            pointx = pointx + (int)diceSize.small;
                            break;

                        case "f":
                            diceImg[i].Width = (int)diceSize.small;
                            diceImg[i].Source = smallResource[3];
                            //間隔
                            pointx = pointx + (int)diceSize.small;
                            break;
                    }

                    //サイコロをUIに追加
                    //サイコロを挿入するための行を追加
                    
                    
                    diceLinePanel[nowLine].Children.Add(diceImg[i]);
                    //diceImg[i] = null;
                    
                    i++;
                    //列の最後より先に終わりが来たら外に出る
                    if (i == TextToDice.Length) goto loopend;

                }

                nowLine++;

            }
        loopend: ;
            
        }

        //選択したところに色を付ける
        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = sender as StackPanel;
            
            if ((bool)s.Tag == false)
            {
                s.Tag = true;
                s.Background = new SolidColorBrush(Colors.Aqua);
            }
            else
            {
                s.Tag = false;
                s.Background = new SolidColorBrush(Colors.White);
            }
        }

        //サイコロの情報を消去する
        private void diceClear_Click_1(object sender, RoutedEventArgs e)
        {
            DiceLine.Children.Clear();
            binaryData.Text = "";
        }


        private void BindingCheck_Checked(object sender, RoutedEventArgs e)
        {
            OpenDialogMenu.IsEnabled = false;
            ttob.IsEnabled = true;
            BindingBox.IsEnabled = true;
        }

        private void ttob_Click(object sender, RoutedEventArgs e)
        {

            binread read = new binread(BindingBox.Text, 0);
            binaryData.Text = read.bindisplay();

            dicePreview();
        }

        private void BindingCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            OpenDialogMenu.IsEnabled = true;
            ttob.IsEnabled = false;
            BindingBox.IsEnabled = false;
        }

        


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace atcoderFileCreater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal string path = @"C:\";

        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileStream? fs = null;
            //string path = "";
            string category = categoryBox.Text;
            string text = TextBox1.Text;
            string lang = langBox.Text;

            if (category == null || text == null || lang == null)
            {
                text1.Text = "無効です";
                text1.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                string lang2 = "";
                //string path = "";
                switch (lang)
                {
                    case "C":
                        lang2 = ".c";
                        break;
                    case "Python":
                        lang2 = ".py";
                        break;
                    case "Java":
                        lang2 = ".java";
                        break;
                    default:
                        break;

                }

                

                if (category == "90")
                {
                    //category = "0";
                    string fileName = path + "/" + text.PadLeft(2, '0') + lang2;
                    FileInfo fileInfo = new FileInfo(fileName);
                    if (File.Exists(fileName))
                    {
                        text1.Text = "既に存在します";
                        text1.Foreground = new SolidColorBrush(Colors.Red);
                        //System.Diagnostics.Process p = System.Diagnostics.Process.Start(fileName);
                    }
                    else
                    {
                        fs = fileInfo.Create();
                        //System.Diagnostics.Process p = System.Diagnostics.Process.Start(fileName);
                        text1.Text = "完了";
                        fs.Close();
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        string fileName = path + "/" +category + text.PadLeft(3, '0') + "_" + i.ToString() + lang2;
                        FileInfo fileInfo = new FileInfo(fileName);
                        if (File.Exists(fileName))
                        {
                            text1.Text = "既に存在します";
                            text1.Foreground = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            fs = fileInfo.Create();
                            //System.Diagnostics.Process.Start(fileName);
                            text1.Text = "完了";
                        }
                    }
                    
                    if ( fs != null)
                    {
                        fs.Close();
                    }
                }

            }

        }

        private void save_Button_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = path;
                dialog.Description = "コードファイルの保存先を選んでください";

                dialog.ShowNewFolderButton = true;

                DialogResult result = dialog.ShowDialog();

                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.SelectedPath;

                    save_pos_name.Text = path;
                }
                else
                {
                    path = @"C:\";
                }
            }
        }
    }
}

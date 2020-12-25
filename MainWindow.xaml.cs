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
using System.Net;
using System.Diagnostics;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            InitializeComponent();
            string pathHist = @".\histoBar.txt";
            string pathHistMis = @".\histoMis.txt";
            File.CreateText(pathHist);
            File.CreateText(pathHistMis);
        }
        

        private async void netoyer_Click(object sender, RoutedEventArgs e)
        {

            DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath());
            FileInfo[] fiArr = di.GetFiles();
            foreach (FileInfo f in fiArr)
            {
                f.Delete();   
            }
        }

        private void finish_anylse_Click(object sender, RoutedEventArgs e)
        {
            anaylse_topBar.Visibility = Visibility.Visible;
            netoyer.Visibility = Visibility.Visible;
            historique1.Visibility = Visibility.Visible;
            mettre_jour.Visibility = Visibility.Visible;
            icon_nett.Visibility = Visibility.Visible;
            icon_hist.Visibility = Visibility.Visible;
            icon_mettre.Visibility = Visibility.Visible;
            datail_anylse.Visibility = Visibility.Visible;
            statusEspace_net.Visibility = Visibility.Visible;
            analyse_nes.Visibility = Visibility.Visible;
            statusAnalyse_date.Visibility = Visibility.Visible;
            statusMise_date.Visibility = Visibility.Visible;
            progres.Visibility = Visibility.Hidden;
            progressBar.Visibility = Visibility.Hidden;
            netoyer.Visibility = Visibility.Visible;
            //DirectoryInfo di = new DirectoryInfo(@"C:\Users\youcode\Desktop\minassatJadida");
            DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath());
            FileInfo[] fiArr = di.GetFiles();
            size_text.Content = "The directory " + di.Name + " contains the following files \n";
            long b = 0;
            foreach (FileInfo f in fiArr)
            {
                b += f.Length;
            }
            size_textInfo.Content = "The size of" + di.Name + "is " + b / 1000 + " MB.\n";
            statusEspace_net.Content = b / 1000 + " MB";


        }

        private async void analyse_bar_Click(object sender, RoutedEventArgs e)
        {
            progres.Visibility = Visibility.Visible;
            progressBar.Visibility = Visibility.Visible;
            progres.Width = 0;
            for (var i = progres.Width; i <= progressBar.Width; i += 15)
            {
                await Task.Delay(200);
                progres.Width += 15;
                netoyer.Visibility = Visibility.Hidden;
                historique1.Visibility = Visibility.Hidden;
                mettre_jour.Visibility = Visibility.Hidden;
                icon_nett.Visibility = Visibility.Hidden;
                icon_hist.Visibility = Visibility.Hidden;
                icon_mettre.Visibility = Visibility.Hidden;
                datail_anylse.Visibility = Visibility.Hidden;
                statusEspace_net.Visibility = Visibility.Hidden;
                analyse_nes.Visibility = Visibility.Hidden;
                statusAnalyse_date.Visibility = Visibility.Hidden;
                statusMise_date.Visibility = Visibility.Hidden;
                anaylse_topBar.Visibility = Visibility.Hidden;
            }
            string lines = DateTime.UtcNow.ToString("MM-dd-yyyy");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@".\histoBar.txt", true))
            {
                file.WriteLine(lines);
            }

        }

        private async void anaylse_topBar_Click_1(object sender, RoutedEventArgs e)
        {
            progres.Visibility = Visibility.Visible;
            progressBar.Visibility = Visibility.Visible;
            progres.Width = 0;
            for (var i = progres.Width; i <= progressBar.Width; i += 15)
            {
                await Task.Delay(200);
                progres.Width += 15;
                netoyer.Visibility = Visibility.Hidden;
                historique1.Visibility = Visibility.Hidden;
                mettre_jour.Visibility = Visibility.Hidden;
                icon_nett.Visibility = Visibility.Hidden;
                icon_hist.Visibility = Visibility.Hidden;
                icon_mettre.Visibility = Visibility.Hidden;
                datail_anylse.Visibility = Visibility.Hidden;
                statusEspace_net.Visibility = Visibility.Hidden;
                analyse_nes.Visibility = Visibility.Hidden;
                statusAnalyse_date.Visibility = Visibility.Hidden;
                statusMise_date.Visibility = Visibility.Hidden;
                anaylse_topBar.Visibility = Visibility.Hidden;
            }
            string lines =  DateTime.UtcNow.ToString("MM-dd-yyyy") ;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@".\histoBar.txt", true))
            {
                file.WriteLine(lines);
            }
        }

        private void historique1_Click(object sender, RoutedEventArgs e)
        {
            size_text.Visibility = Visibility.Hidden;
            size_textInfo.Visibility = Visibility.Hidden;
            string text = System.IO.File.ReadAllLines(@".\histoBar.txt").Last();
            statusAnalyse_date.Content = text;
        }

        private void mettre_jour_Click_1(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            
            try
            {
                if (!webClient.DownloadString("https://pastebin.com/ahUnw4Cf").Contains("1.0.0"))
                {
                    if (MessageBox.Show("Do yu want last update?", "Cleanner", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string lines = DateTime.UtcNow.ToString("MM-dd-yyyy");
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@".\histoMis.txt", true))
                        {
                            file.WriteLine(lines);
                        }
                        string text = System.IO.File.ReadAllLines(@".\histoMis.txt").Last();
                        statusMise_date.Content = text;
                        using (var client = new WebClient())
                        {
                            Process.Start(@".\instCleanner.exe");
                            this.Close();
                        }
                    }

                }
            }
            catch
            {

            }

        }
    }
}


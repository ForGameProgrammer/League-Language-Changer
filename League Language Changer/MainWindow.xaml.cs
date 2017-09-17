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
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace League_Language_Changer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] diller;
        string[] sunucular;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void textTamam_Click(object sender, RoutedEventArgs e)
        {
            string yol = textYol.Text + "\\Config\\LeagueClientSettings.yaml";
            if (!System.IO.File.Exists(yol))
            {
                System.Windows.MessageBox.Show("Seçilen Klasör Doğru Görünmüyor. Lütfen League of Legends'ın Kurulu Olduğu Klasörü Seçin");
                return;
            }
            System.IO.StreamReader reader = new System.IO.StreamReader(yol);
            string icerik = reader.ReadToEnd();
            reader.Close();
            string yeni = Regex.Replace(icerik, "locale: \"([A-Z,a-z])\\w+", "locale: \"" + diller[comboDil.SelectedIndex]);
            yeni = Regex.Replace(yeni, "region: \"([A-Z,a-z])\\w+", "region: \"" + sunucular[comboSunucu.SelectedIndex]);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(yol, false);
            writer.Write(yeni);
            writer.Close();
            System.Windows.MessageBox.Show("Başarı ile Değiştirildi.");

        }

        private void textGozat_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (System.IO.File.Exists(dialog.SelectedPath + "\\Config\\LeagueClientSettings.yaml"))
                {
                    textYol.Text = dialog.SelectedPath;
                    Properties.Settings.Default.yol = textYol.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    System.Windows.MessageBox.Show("Seçilen Klasör Doğru Görünmüyor. Lütfen League of Legends'ın Kurulu Olduğu Klasörü Seçin");
                }

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ekle();
        }
        private void Ekle()
        {
            diller = new string[] { "tr_TR", "en_US", "pt_BR", "en_GB", "de_DE", "es_ES", "fr_FR", "it_IT", "cs_CZ", "el_GR", "hu_HU", "pl_PL", "ro_RO", "ru_RU", "es_MX", "en_AU", "ja_JP", "ko_KR" };
            sunucular = new string[]  { "TR", "BR", "EUNE", "EUW", "LAN", "LAS", "NA", "OCE", "RU", "JP", "SEA", "KR", "PBE" };
            comboDil.Items.Add("Türkçe");
            comboDil.Items.Add("TEnglish (Amerikan İngilizcesi)");
            comboDil.Items.Add("Português (Portekizce)");
            comboDil.Items.Add("English (İngiliz İngilizcesi)");
            comboDil.Items.Add("Deutsch (Almanca)");
            comboDil.Items.Add("Español (İspanyolca)");
            comboDil.Items.Add("Français (Fransızca)");
            comboDil.Items.Add("Italiano (İtalyanca)");
            comboDil.Items.Add("Čeština (Çekce)");
            comboDil.Items.Add("Ελληνικά (Yunanca)");
            comboDil.Items.Add("Magyar (Macarca)");
            comboDil.Items.Add("Polski (Polonyaca)");
            comboDil.Items.Add("Română (Romanca)");
            comboDil.Items.Add("Русский (Rusca)");
            comboDil.Items.Add("Español (İspanyolca)");
            comboDil.Items.Add("English (İngilizce AU)");
            comboDil.Items.Add("日本語 (Japonca)");
            comboDil.Items.Add("한국의 (Korece)");

            comboSunucu.Items.Add("Türkiye");
            comboSunucu.Items.Add("Brazil");
            comboSunucu.Items.Add("Europe Nordic & East");
            comboSunucu.Items.Add("Europe West");
            comboSunucu.Items.Add("Latin America North");
            comboSunucu.Items.Add("Latin America South");
            comboSunucu.Items.Add("North America");
            comboSunucu.Items.Add("Oceania");
            comboSunucu.Items.Add("Russia");
            comboSunucu.Items.Add("Japan");
            comboSunucu.Items.Add("South East Asia");
            comboSunucu.Items.Add("Republic of Korea");
            comboSunucu.Items.Add("Public Beta Environment");
            comboDil.SelectedIndex = 0;
            comboSunucu.SelectedIndex = 0;
            textYol.Text = Properties.Settings.Default.yol;
        }
 
    }
}

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

namespace ListaAlunni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(File.Exists(file))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listanomi.Add(line);
                        txt_lista.Text += $"{line}\n";
                    }
                }
            }
        }

        List<string> listanomi = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listanomi.Add(txt_inserisci.Text);
            listanomi.Sort();
            txt_lista.Text = null;
            for (int i = 0; i < listanomi.Count; i++)
            {
                txt_lista.Text += $"{listanomi[i]}\n ";
            }
        }
        const string file = "lista.txt";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(txt_lista.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string ricercato = txt_cerca.Text;
            if(listanomi.Contains(ricercato))
            {
                lbl_ricerca.Content = "Il nome è \n presente";
            }else
            {
                lbl_ricerca.Content = "Il nome non \n è presente";
            }
        }
    }
}

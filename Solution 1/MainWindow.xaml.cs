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
using Microsoft.Win32;

namespace Solution_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|All files (*.*)";
            if(saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filepath = saveFileDialog.FileName;
                    TextRange textrange = new TextRange(richtext.Document.ContentStart, richtext.Document.ContentEnd);
                    using (FileStream fs = new FileStream(filepath, FileMode.Create))
                    {
                        textrange.Save(fs,DataFormats.Text);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filepath = openFileDialog.FileName;
                    string content = File.ReadAllText(filepath);
                    richtext.Document.Blocks.Clear();
                    richtext.Document.Blocks.Add(new Paragraph(new Run(content)));
                }
                catch(Exception ex)
                { 
                    MessageBox.Show(ex.Message); 
                }
            }
        }
    }
}

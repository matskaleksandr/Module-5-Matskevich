using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using Microsoft.Win32;

namespace Solution_1
{
    /// <summary>
    /// Главное окно приложения
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //инициализация компонентов окна
            InitializeComponent();
        }
        //обработчик нажатия на кнопку сохранения
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //создание диалогового окна для сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|Все файлы (*.*)";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filepath = saveFileDialog.FileName;
                    TextRange textrange = new TextRange(richtext.Document.ContentStart, richtext.Document.ContentEnd);
                    //сохранение содержимого в файл
                    using (FileStream fs = new FileStream(filepath, FileMode.Create))
                    {
                        textrange.Save(fs, DataFormats.Text);
                    }
                }
                catch (Exception ex)
                {
                    //вывод сообщения об ошибке в случае исключения
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //обработчик нажатия на кнопку открытия файла
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //создание диалогового окна для открытия файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filepath = openFileDialog.FileName;
                    string content = File.ReadAllText(filepath);
                    //очистка и заполнение RichTextBox с содержимым файла
                    richtext.Document.Blocks.Clear();
                    richtext.Document.Blocks.Add(new Paragraph(new Run(content)));
                }
                catch (Exception ex)
                {
                    //вывод сообщения об ошибке в случае исключения
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

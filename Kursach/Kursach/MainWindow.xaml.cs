using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Path;
        private string _decodeText;
        private string _encodeText;
        private string _message;
        private string _key;
        private bool _check;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Encode(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_Key.Text))
            {
                MessageBox.Show("Ключ не введен");
            }
            else if (string.IsNullOrEmpty(OriginalTextBox.Text))
            {
                MessageBox.Show("Не выбран файл или ничего не введено");
            }
            else
            {
                _check = true;
                _message = OriginalTextBox.Text.ToLower();
                _encodeText = new string(Encode(_message.ToCharArray(), _key.ToCharArray()));
                СonvertedTextBox.Text = _encodeText;
            }
        }

        public char[] Encode(char[] message, char[] key) //Метод шифрования 
        {
            int n;
            int d;
            int j, f;
            int t = 0;

            char[] alf = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            for (int i = 0; i < message.Length; i++)
            {
                for (j = 0; j < alf.Length; j++)
                {
                    if (message[i] == alf[j])
                    {
                        break;
                    }
                }

                if (j != 33)
                {
                    n = j;

                    if (t > key.Length - 1)
                    {
                        t = 0;
                    }

                    for (f = 0; f < alf.Length; f++)
                    {
                        if (key[t] == alf[f])
                        {
                            break;
                        }
                    }

                    t++;

                    if (f != 33)
                    {
                        d = n + f;
                    }
                    else
                    {
                        d = n;
                    }

                    if (d > 32)
                    {
                        d -= 33;
                    }
                    message[i] = alf[d];
                }
            }
            return message;
        }

        private void Button_Decode(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_Key.Text))
            {
                MessageBox.Show("Ключ не введен");
            }
            else if (string.IsNullOrEmpty(OriginalTextBox.Text))
            {
                MessageBox.Show("Не выбран файл или ничего не введено");
            }
            else
            {
                _check = false;
                _message = OriginalTextBox.Text.ToLower();
                char[] decodeMessage = Decode(_message.ToCharArray(), _key.ToCharArray());
                _decodeText = new string(decodeMessage);
                СonvertedTextBox.Text = _decodeText;
            }
        }

        public char[] Decode(char[] message, char[] key) //Метод дешифрования
        {
            int n;
            int d;
            int j, f;
            int t = 0;

            char[] alf = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            for (int i = 0; i < message.Length; i++)
            {
                for (j = 0; j < alf.Length; j++)
                {
                    if (message[i] == alf[j])
                    {
                        break;
                    }
                }

                if (j != 33)
                {
                    n = j;

                    if (t > key.Length - 1)
                    {
                        t = 0;
                    }

                    for (f = 0; f < alf.Length; f++)
                    {
                        if (key[t] == alf[f])
                        {
                            break;
                        }
                    }

                    t++;

                    if (f != 33)
                    {
                        d = n - f + alf.Length;
                    }
                    else
                    {
                        d = n;
                    }

                    if (d > 32)
                    {
                        d -= 33;
                    }

                    message[i] = alf[d];
                }
            }
            return message;
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {
            Path = ReadPath(Path);

            if (Path != System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Exeption.txt")
            {
                OriginalTextBox.Text = File.ReadAllText(Path, Encoding.Default);
                _message = File.ReadAllText(Path, Encoding.Default);
            }
        }

        public string ReadPath(string pathc) //Метод для получения пути
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt"
            };

            if (fileDialog.ShowDialog() == true)
            {
                Path = fileDialog.FileName;
                pathc = Path;
            }
            else //Обработка если закрыли диологовое окно
            {
                Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Exeption.txt";

                FileInfo info1 = new FileInfo(Path);
                if (info1.Exists == false)
                {
                    File.WriteAllText(Path, "", Encoding.Default);
                }

                pathc = Path;
                MessageBox.Show("Вы не открыли файл!!");
            }

            FileInfo info = new FileInfo(Path);

            if (info.Exists == false)
            {
                throw new Exception("This file can not be read. It not exists.\nPath: " + Path);
            }
            else
            {
                try
                {
                    return pathc;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void Button_SaveEncode(object sender, RoutedEventArgs e)
        {
            if (_check && string.IsNullOrEmpty(OriginalTextBox.Text))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == false)
                    return;

                SaveFile(_encodeText, saveFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Нечего сохранять!!!", "Пустота");
            }
        }

        private void Button_SaveDecode(object sender, RoutedEventArgs e)
        {
            if (!_check && _message != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == false)
                    return;

                SaveFile(_decodeText, saveFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Нечего сохранять!!!", "Пустота");
            }
        }

        public bool SaveFile(string text, string path) //Метод сохранения
        {
            FileInfo info = new FileInfo(path);

            if (info.Exists == false)
            {
                try
                {
                    File.WriteAllText(path + ".txt", text, Encoding.Default);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    File.WriteAllText(path, text, Encoding.Default);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void TextBox_TextKey(object sender, TextChangedEventArgs e)
        {
            _key = Convert.ToString(TextBox_Key.Text.ToLower());
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            OriginalTextBox.IsReadOnly = false;
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            OriginalTextBox.IsReadOnly = true;
        }
    }
}
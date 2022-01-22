using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Password_Generator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Generator gen;
        public MainWindow()
        {
            InitializeComponent();
            gen = new Generator();
        }
        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Size.Text == "")
            {
                MessageBox.Show("Введите поле длины пароля!");
            }
            else
            {
                if (UserSymbols.Text == "")
                {
                    if (int.Parse(Size.Text) <= 32 && int.Parse(Size.Text) >= 4)
                    {
                        bool num = false, sym = false, UpA = false, LowA = false;
                        if(checkBoxNum.IsChecked == true)
                        {
                            num = true;
                        }
                        if (checkBoxSym.IsChecked == true)
                        {
                            sym = true;
                        }
                        if (checkBoxUpA.IsChecked == true)
                        {
                            UpA = true;
                        }
                        if (checkBoxLowA.IsChecked == true)
                        {
                            LowA = true;
                        }
                        if(num == false && sym == false && UpA == false && LowA == false)
                        {
                            MessageBox.Show("Выберите параметры для пароля!");
                        }
                        else
                        {
                            PasswordBox.Text = gen.PasswordGenerate(int.Parse(Size.Text), num, sym, UpA, LowA);
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Длина пароля должна быть в диапазоне от 4 до 32 символов!");
                    }
                }
                else
                {
                    if (int.Parse(Size.Text) <= 32 && int.Parse(Size.Text) >= 4)
                    {
                        PasswordBox.Text = gen.UserPasswordGenerate(int.Parse(Size.Text), UserSymbols.Text);
                    }
                    else
                    {
                        MessageBox.Show("Длина пароля должна быть в диапазоне от 4 до 32 символов!");
                    }
                }
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|Word Documents|*.doc";
            saveFileDialog.FileName = "MyPassword";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, PasswordBox.Text);
            }
           
        }
    }
}

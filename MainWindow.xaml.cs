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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(saveCommand);

            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBindings.Add(openCommand);

            CommandBinding clearCommand = new CommandBinding(ApplicationCommands.Delete, execute_Clear, canExecute_Clear);
            CommandBindings.Add(clearCommand);
        }

        private void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtDocument.Text.Trim().Length > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("d:\\myFile.txt", txtDocument.Text);
            MessageBox.Show("The file was saved!");
        }

        private void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Тут міг би бути код відкриття файлу!");
        }

        private void canExecute_Clear(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtDocument.Text.Length > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Clear();
        }
    }
}
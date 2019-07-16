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

namespace CollegeReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DisplayFileName { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Reads in a user selected CollegeScoreCard_Raw_Data csv
        /// file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
           
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = " csv files (MERGED*PP.csv)| merged*pp.csv";

            if (dialog.ShowDialog() == true)
            {
                DisplayFileName = dialog.FileName;
                SelectedFileTextBox.Text = DisplayFileName;

            }
            
        }
        /// <summary>
        /// Opens a new window to process user selected csv file.
         /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileOpenButton_Click(object sender, RoutedEventArgs e)
        {
           
            
            SearchWindow searchWindow = new SearchWindow(DisplayFileName);
            searchWindow.Show();
            this.Close();
            
            
        }
    }
}

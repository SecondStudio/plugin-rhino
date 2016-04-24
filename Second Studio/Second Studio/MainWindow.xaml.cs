using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Second_Studio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   
    public partial class MainWindow : Window
    {
        private EventModel _event;
        
        public MainWindow()
        {
            InitializeComponent();
            // create a model object;
            _event = new EventModel()
            {
                Origin = SecondStudioCommand.LastCommandResult.ToString(),
                Spawn = SecondStudioCommand.LastCommandResult.ToString()
            };
            this.DataContext = _event;
           
        }
        
        private void OriginClick(object sender, RoutedEventArgs e)
        {
        // OriginClick initiated here
           SecondStudioCommand.GetOrigin();
          
           
        }

        private void SpawnClick(object sender, RoutedEventArgs e)
        {
            // SpawnClick initiated here
            SecondStudioCommand.GetSpawn();
            
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            // launch s2
            //LaunchS2.OpenApplication();
            //World.Main();
            SecondStudioCommand.ExportModel();
            string username = Environment.UserName;
            string path = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio\Second Studio.exe", username);
            Process.Start(path);
            this.Hide();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            string mode = button.Content.ToString();
            string username = Environment.UserName;
            string directory = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio", username);
            System.IO.Directory.CreateDirectory(directory);
            string path = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio\mode.xml", username);
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Mode");

                writer.WriteElementString("Type",mode);


                writer.WriteEndElement();
                writer.WriteEndDocument();

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            string field = button.Content.ToString();
            string username = Environment.UserName;
            string directory = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio", username);
            System.IO.Directory.CreateDirectory(directory);
            string path = String.Format(@"C:\Users\{0}\AppData\Roaming\SecondStudio\field.xml", username);
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Field");

                writer.WriteElementString("Type", field);


                writer.WriteEndElement();
                writer.WriteEndDocument();

            }
        }


        
    }
}

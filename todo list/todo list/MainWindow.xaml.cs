using Microsoft.Windows.Themes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using static todo_list.MainWindow;

namespace todo_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProjectsCount> projectsCount = new List<ProjectsCount>();
        List<Projects> project= new List<Projects>();
        List<Task> task= new List<Task>();
        public MainWindow()
        {            
            InitializeComponent();
            ExistingProjects.ItemsSource= projectsCount;
        }
        public class Task
        {
            public int Id { get; set; }
            public string? Description { get; set; }
        }
        public class Projects
        {
            public int Id { get; set; }            
        };
        public class ProjectsCount
        {            
            public int Id { get; set; }
            public string? Name { get; set; }
        };

        private void Open_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.Uid;
            int Id = int.Parse(id);
            MainGrid.Visibility = Visibility.Collapsed;
            Project.Visibility = Visibility.Visible;
            CurrentProject.ItemsSource = task;
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string Id = btn.Uid;
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            string b = "Test project";
            projectsCount.Add(new ProjectsCount { Id = a, Name = b });
            project.Add(new Projects { Id = a});          
            ExistingProjects.ItemsSource = null;
            ExistingProjects.ItemsSource = projectsCount;
        }

        private void DeleteTask_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string? id = btn.Uid;
            int d = int.Parse(id);
            task.Remove(task.Where(task => task.Id == d).First());
            CurrentProject.ItemsSource = null;
            CurrentProject.ItemsSource = task;                     
        }
        int Edit_id;
        string? Button_id;
        Button Button;
        Task editTask;
        private void EditTask_click(object sender, RoutedEventArgs e)
        {
            Button = (Button)sender;
            Button_id = Button.Uid;
            Edit_id = int.Parse(Button_id);
            editTask = task.Find(task => task.Id == Edit_id);
            EditTask.Text = editTask.Description.ToString();
            EditTask.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;
        }
        int c = 0;
        private void AddTask_click(object sender, RoutedEventArgs e)
        {            
            if (Description.Text.Length > 0)
            {
                task.Add(new Task { Id = c, Description = Description.Text });
                CurrentProject.ItemsSource = null;
                CurrentProject.ItemsSource = task;
                c++;
                Alert.Text = null;
                Description.Text = null;
                Description.Focus();
            }
            else
            {
                Alert.Text = "This field cannot be empty";
                Description.Focus();
            }
        }

        private void EditApply_click(object sender, RoutedEventArgs e)
        {
            editTask.Description = EditTask.Text;
            CurrentProject.ItemsSource = null;
            CurrentProject.ItemsSource = task;
            EditTask.Visibility = Visibility.Collapsed;
            EditButton.Visibility = Visibility.Collapsed;
        }
    }
}

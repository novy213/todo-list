﻿using Microsoft.Windows.Themes;
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
            string b = "test2";
            projectsCount.Add(new ProjectsCount { Id = a, Name = b });
            project.Add(new Projects { Id = a});          
            ExistingProjects.ItemsSource = null;
            ExistingProjects.ItemsSource = projectsCount;
        }

        private void DeleteTask_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string? id = btn.Uid;           
            task.Remove(new Task() { Id = int.Parse(id),Description="sa"});
            CurrentProject.ItemsSource = null;
            CurrentProject.ItemsSource = task;                     
        }

        private void EditTask_click(object sender, RoutedEventArgs e)
        {

        }
        int c = 0;
        string b = "test task";
        private void AddTask_click(object sender, RoutedEventArgs e)
        {                        
            task.Add(new Task { Id = c, Description = b });
            CurrentProject.ItemsSource = null;
            CurrentProject.ItemsSource = task;
            c++;
            b += "1";
        }
    }
}
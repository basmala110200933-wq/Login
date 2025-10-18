using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using login_Admin.Data;
using loginAdmin;

namespace login_Admin
{
    public partial class AdminWPF : Window
    {
        public AdminWPF()
        {
            InitializeComponent();
            LoadAllData();
        }

        public void LoadAllData()
        {
            LoadGrades();
            LoadStudents();
            LoadCourses();
        }

        public void LoadGrades()
        {
            using (var context = new ContextDegree())
            {
                var grades = context.studentscourses
                    .Select(sc => new
                    {
                        StudentID = sc.stid,
                        StudentName = sc.Students.STName,
                        CourseID = sc.coid,
                        CourseName = sc.courses.COName,
                        Grade = sc.grade
                    })
                    .ToList();

                gradesDataGrid.ItemsSource = grades;
            }
        }

        public void LoadStudents()
        {
            using (var context = new ContextDegree())
            {
                var students = context.students
                    .Select(s => new
                    {
                        s.STID,
                        s.STName,
                        s.SUsername
                    })
                    .ToList();

                studentsDataGrid.ItemsSource = students;
            }
        }

        public void LoadCourses()
        {
            using (var context = new ContextDegree())
            {
                var courses = context.courses
                    .Select(c => new{  c.COID,c.COName}).ToList();
                coursesDataGrid.ItemsSource = courses;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadStudents();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AdminAdd add = new AdminAdd();
            add.Show();
            this.Close();
        }
    }
}
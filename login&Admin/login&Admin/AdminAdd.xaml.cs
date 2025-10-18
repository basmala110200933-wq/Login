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
using System.Windows.Shapes;
using login_Admin.Data;
using login_Admin.Model;
namespace login_Admin
{
    public partial class AdminAdd : Window
    {
        public AdminAdd()
        {
            InitializeComponent();
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newStudentName.Text) || string.IsNullOrWhiteSpace(newStudentUsername.Text) || string.IsNullOrWhiteSpace(newStudentPassword.Text))
            {
                MessageBox.Show("Please enter all student data");
                return;
            }
            using (var context = new ContextDegree())
            {
                var newStudent = new Student
                {
                    STName = newStudentName.Text,
                    SUsername = newStudentUsername.Text,
                    SPassword = newStudentPassword.Text
                };
                context.students.Add(newStudent);
                context.SaveChanges();
                MessageBox.Show("Student added successfully!");
                newStudentName.Clear();
                newStudentUsername.Clear();
                newStudentPassword.Clear();
            }
        }
        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newCourseName.Text))
            {
                MessageBox.Show("Please enter course name");
                return;
            }
            using (var context = new ContextDegree())
            {
                var newCourse = new Courses
                {
                    COName = newCourseName.Text
                };
                context.courses.Add(newCourse);
                context.SaveChanges();
                MessageBox.Show("Done added ");
                newCourseName.Clear();
            }
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            AdminWPF wPF = new AdminWPF();
            wPF.Show();
            this.Close();
        }
    }
}
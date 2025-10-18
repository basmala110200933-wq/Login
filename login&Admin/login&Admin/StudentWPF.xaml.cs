using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.EntityFrameworkCore;

namespace loginAdmin
{
    public partial class StudentWPF : Window
    {
        private ContextDegree _context = new ContextDegree();

        public StudentWPF()
        {
            InitializeComponent();
            LoadStudentsComboBox();
        }

        private void LoadStudentsComboBox()
        {
            var students = _context.students.ToList();
            studentsComboBox.ItemsSource = students;

            if (students.Any())
            {
                studentsComboBox.SelectedIndex = 0; 
            }
        }

        private void StudentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentsComboBox.SelectedItem is Student selectedStudent)
            {
                DisplayStudentData(selectedStudent.STID);
            }
        }

        private void DisplayStudentData(int studentId)
        {
            using (var context = new ContextDegree())
            {
                var student = context.students.FirstOrDefault(s => s.STID == studentId);

                if (student != null)
                {
                    txtStudentId.Text = student.STID.ToString();
                    txtUsername.Text = student.SUsername;
                }

                var studentCourses = context.studentscourses
                    .Where(sc => sc.stid == studentId) .Include(sc => sc.courses).ToList();
                coursesDataGrid.ItemsSource = studentCourses;
                txtTotalCourses.Text = studentCourses.Count.ToString();

                if (studentCourses.Any() && studentCourses.All(sc => sc.grade > 0))
                {
                    var average = studentCourses.Average(sc => sc.grade);
                    txtAverageGrade.Text = average.ToString("F2");
                }
                else
                {
                    txtAverageGrade.Text = "N/A";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
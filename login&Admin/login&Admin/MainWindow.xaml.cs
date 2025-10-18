using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using login_Admin.Data;

namespace loginAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContextDegree degree=new ContextDegree();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernamebox.Text) && !string.IsNullOrWhiteSpace(Pbox.Text))
            {
               var username = usernamebox.Text.Trim();
                var password = Pbox.Text.Trim();

                using (var context = new ContextDegree())
                {
                    var admin = context.Administration.FirstOrDefault(a => a.AUsername == username && a.APassword == password);
                    if (admin != null)
                    {
                       login_Admin.AdminWPF adminWindow = new login_Admin.AdminWPF();
                        adminWindow.Show();
                        this.Close();
                        return;
                    }

                    var student = context.students.FirstOrDefault(s => s.SUsername == username && s.SPassword == password);
                    if (student != null)
                    {
                StudentWPF stu = new StudentWPF();
                        stu.Show();
                        this.Close();
                    }
                    else
                    {
                        myTextBlock_Copy.Text = "Invalid username or password!";
                        myTextBlock.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter all data");
            }
        }
    }
}

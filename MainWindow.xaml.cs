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

namespace WPFRegisterStudent
{
 
    public partial class MainWindow : Window
    {
        Course choice;
        int TotalCreditHours = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            choice = (Course)(this.comboBox.SelectedItem);
            string courseName = choice.ToString();
            // TO DO - Create code to validate user selection (the choice object)
            // and to display an error or a registation confirmation message accordinlgy
            // Also update the total credit hours textbox if registration is confirmed for a selected course
            switch (validateUserSelection(choice))
            {
                case 0://We need to establish an error in order to appeal to the display error requirement and incase it calls for it
                    label3.Content = "You have already registered for this course." + courseName;
                    break;
                case 1: 
                    label3.Content = "You cannot register for more than 9 credit hours.";
                    break;
                case 2:
                    choice.SetToRegistered(); 



                    listBox.Items.Add(choice); // What essentially these lines of code equates to would be that there are registered input confirming info
                    label3.Content = "Registration confirmed for course..." + courseName;
                    TotalCreditHours += 3; 
                    textBox.Text = TotalCreditHours.ToString();
                    break;
            }

        }

        private int validateUserSelection(Course selectedCourse) //This line of code is meant to verify output and limitation being set up that way nothing exceeds the epxpected amount

        {
            if (selectedCourse.IsRegisteredAlready()) 
            {
                return 0;
            }


            else if (TotalCreditHours > 8) 
            {
                return 1;
            }

            return 2;
        }


    }
}

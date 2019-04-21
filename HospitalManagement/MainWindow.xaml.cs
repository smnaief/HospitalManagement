using MySql.Data.MySqlClient;
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

using System.Data;

namespace HospitalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> list = new List<string>();
            list.Add("Male");
            list.Add("Female");
            list.Add("Others");

            p_gender_combobox.ItemsSource = list;

            List<string> list1 = new List<string>();
            list1.Add("Day");
            list1.Add("Night");

            nurse_shift_comboBox.ItemsSource = list1;

            List<string> list2 = new List<string>();
            list2.Add("Doctor");
            list2.Add("Nurse");
            

            


            doctorComboboxAdd();
            
        }
        string gender = "";
        string shift = "";
        string post = "";
        string doc = "";

        private void doctorComboboxAdd()
        {
            List<string> list3 = new List<string>();

            string q = "select * from hm_db.doctor";
            Database d = new Database();
            MySqlCommand com = d.show_data(q);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                list3.Add(reader["name"].ToString() +" -> "+ reader["specialization"].ToString());
            }

            
            p_doctor_entry_combobox.ItemsSource = list3;
            
        }

        private void p_doctor_combo(object sender, SelectionChangedEventArgs e)
        {
            try {
                ComboBox s = sender as ComboBox;
                doc = s.SelectedItem as string;
                //int index = s.SelectedIndex;

                //string q = "select * ROW_NUMBER() OVER (ORDER BY name) AS rn from hm_db.doctor";

                //Database d = new Database();
                //MySqlCommand com = d.show_data(q);
                //MySqlDataReader reader = com.ExecuteReader();

                //while (reader.Read())
                //{
                //    MessageBox.Show(reader["rn"].ToString());
                //}
            }
            catch(Exception r)
            {
                MessageBox.Show(r.ToString());
            }
        }


        private void patient_submit_click(object sender, RoutedEventArgs e)
        {
            string name = p_name_textbox.Text.ToString();
            string age = p_age_textbox.Text.ToString();
            string phone = p_phone_textbox.Text.ToString();
            string disease = p_disease_textbox.Text.ToString();
            string bloodgroup = p_blood_textbox.Text.ToString();

            if (name != "" && age!="" && gender!="" && phone!="" && disease!="" && doc!="")
            {
                string insert_q = "insert into hm_db.patient(id_auto,name,age,gender,phone,disease,doctor,appoint_date,bloodgroup) values('','" + name + "','" + age + "','"
                    + gender + "','" + phone + "','" + disease + "','" + doc + "',NOW() , '"+bloodgroup+"');";

                
                Database d = new Database();
                bool b = d.insert_data(insert_q);
                if (b)
                {
                    MessageBox.Show("Inserted");
                }
                else
                {
                    MessageBox.Show("Not inserted");
                }
                //MessageBox.Show(insert_q);
            }
            else
            {
                MessageBox.Show("FiLl all property");
            }

        }

        private void combo_change(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = sender as ComboBox;
            gender = s.SelectedItem as string;
        }

        private void patient_canvas_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Visible;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            home_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
        }

        private void doctor_canvas_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Visible;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            home_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
        }

        private void nurses_canvas_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Visible;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            home_entry_canvas.Visibility = System.Windows.Visibility.Hidden;

        }

        private void doctor_submit_click(object sender, RoutedEventArgs e)
        {
            string name = doctor_name_textbox.Text.ToString();
            string specialization = doctor_specialization_textbox.Text.ToString();
            string phone = doctor_phone_textbox.Text.ToString();
            string designation = doctor_designation_textbox.Text.ToString();

            if(name != "" && specialization != "" && phone != "" && designation != "")
            {
                string insert_q = "insert into hm_db.doctor(id_auto,name,phone,designation,specialization) values('','" + name + "','" + phone + "','"
                    + designation + "','" + specialization + "');";
                Database d = new Database();
                bool b = d.insert_data(insert_q);
                if (b)
                {
                    MessageBox.Show("Inserted");
                    doctorComboboxAdd();
                }
                else
                {
                    MessageBox.Show("Not inserted");
                }
            }
            else
            {
                MessageBox.Show("Fill all properties");
            }
        }

        private void nurse_submit_click(object sender, RoutedEventArgs e)
        {
            string name = nurse_name_textbox.Text.ToString();
            

            if (name != "" && shift != "")
            {
                string insert_q = "insert into hm_db.nurse(id_auto,name,shift) values('','" + name + "','" +shift + "');";
                Database d = new Database();
                bool b = d.insert_data(insert_q);
                if (b)
                {
                    MessageBox.Show("Inserted");
                }
                else
                {
                    MessageBox.Show("Not inserted");
                }
            }
            else
            {
                MessageBox.Show("Fill all properties");
            }
        }

        private void nurse_shift_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = sender as ComboBox;
            shift = s.SelectedItem as string;
        }

        private void employees_canvas_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;

        }


       

        private void employees_post_change_combobox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = sender as ComboBox;
            post = s.SelectedItem as string;
        }

        private void update_button_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Visible;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            home_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
        }


        private void view_button_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Visible;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            home_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
        }

        private void viewButtonClick(object sender, RoutedEventArgs e)
        {
            string tableName = (sender as Button).Tag.ToString();
            string q = "select * from hm_db." + tableName;
            Database d = new Database();

            DataTable dt = new DataTable(tableName);
            MySqlDataAdapter dtd = new MySqlDataAdapter(d.show_data(q));
            dtd.Fill(dt);
            showTable.ItemsSource = dt.DefaultView;

           
        }

        private void appointment_submit_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
        }

        private void up_search_open_click(object sender, RoutedEventArgs e)
        {
            string searchId = up_p_id_textbox.Text.ToString();

            string query = "select * from hm_db.patient where id_auto='" + searchId + "'";

            Database d = new Database();
            MySqlCommand com = d.show_data(query);
            MySqlDataReader reader = com.ExecuteReader();

            string name = "";
            string age = "";
            string phone = "";
            string disease = "";

            while (reader.Read())
            {
                name = reader["name"].ToString();
                age = reader["age"].ToString();
                phone = reader["phone"].ToString();
                disease= reader["disease"].ToString();
            }
            reader.Close();

            up_p_name_textbox.Text = name;
            up_p_age_textbox.Text = age;
            up_p_phone_textbox.Text = phone;
            up_p_disease_textbox.Text = disease;


        }

        private void update_patient_click(object sender, RoutedEventArgs e)
        {
            string name = up_p_name_textbox.Text.ToString();
            string age = up_p_age_textbox.Text.ToString();
            string phone = up_p_phone_textbox.Text.ToString();
            string disease = up_p_disease_textbox.Text.ToString();

            string searchId = up_p_id_textbox.Text.ToString();

            string updateQuery = "update hm_db.patient set name='" + name + "', age='" + age + "', phone='" 
                + phone + "', disease='" + disease + "' where id_auto='" + searchId + "'";

            Database d = new Database();
            if (d.update(updateQuery))
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("not");
            }
            
        }

        private void search_button_open_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Visible;
            home_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
        }

        

        private void blood_search_openclick(object sender, RoutedEventArgs e)
        {
            patient_show_label.Content = "";
            string bloodsearch = blood_search_textbox.Text.ToString();
            string q = "select * from hm_db.patient where bloodgroup='" + bloodsearch + "'";

            Database d3 = new Database();
            MySqlCommand com2 = d3.show_data(q);
            MySqlDataReader reader2 = com2.ExecuteReader();

            while (reader2.Read()) {
                patient_show_label.Content = patient_show_label.Content + reader2["name"].ToString() +" , "+ reader2["gender"].ToString() + " , " + reader2["phone"].ToString();
            }
        }

        private void home_button_click(object sender, RoutedEventArgs e)
        {
            patient_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            doctor_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            nurse_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            update_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            view_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            search_entry_canvas.Visibility = System.Windows.Visibility.Hidden;
            home_entry_canvas.Visibility = System.Windows.Visibility.Visible;
        }





        //private void databaseCheckClick(object sender, RoutedEventArgs e)
        //{
        //    Database d = new Database();
        //    string insert_q = "insert into hm_db.hospital(id_auto,name,location) values('','Appollo','Basundhara');";

        //    if (d.connection() && d.insert_data(insert_q))
        //    {
        //        MessageBox.Show("Clicked");

        //    }
        //    else
        //    {
        //        MessageBox.Show("not");
        //    }

        //}
    }
}

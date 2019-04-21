using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace HospitalManagement
{
    class Database
    {
        static string server_link = "server=localhost;user=root;pooling=true;default command timeout=5";
        MySqlConnection conn;

        public Database()
        {
            conn = new MySqlConnection(server_link);
            conn.Open();
        }

        public bool connection()
        {
            if (conn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool insert_data(string getQuery)
        {
            try
            {
                //conn.Open();
                //string insert_q = "insert into student.info(name,class,city) values('" + name + "','" + classs + "','" + city + "');";

                string insert_q = getQuery;
                MySqlCommand comm = new MySqlCommand(insert_q, conn);

                MySqlDataReader data = comm.ExecuteReader();
                //conn.Close();
                return true;


            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        public MySqlCommand show_data(string q)
        {
            string select_q = q;
            try
            {
                MySqlCommand com = new MySqlCommand(select_q, conn);
               // MySqlDataReader data = com.ExecuteReader();
                return com;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int size(string s)
        {
            try
            {
                //conn.Open();
                string count_q = s;
                MySqlCommand com = new MySqlCommand(count_q, conn);
                int data = Convert.ToInt32(com.ExecuteScalar().ToString());
                Console.WriteLine("hello its data " + data);
                //conn.Close();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 00;
            }
        }

        public bool update(string s)
        {
            try
            {
                //conn.Open();
                //string insert_q = "insert into student.info(name,class,city) values('" + name + "','" + classs + "','" + city + "');";
                string insert_q = s;
                MySqlCommand comm = new MySqlCommand(insert_q, conn);

                MySqlDataReader data = comm.ExecuteReader();
                //conn.Close();
                return true;


            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            //return false;
        }

        public string maxData(string s)
        {
            try
            {
                MySqlCommand com = new MySqlCommand(s, conn);
                string data = com.ExecuteScalar().ToString();
                return data.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public bool delete(string s)
        {
            try
            {
                MySqlCommand com = new MySqlCommand(s, conn);
                MySqlDataReader Reader1 = com.ExecuteReader();
                return true;
            }
            catch (Exception v)
            {
                return false;
            }
        }

    }
}

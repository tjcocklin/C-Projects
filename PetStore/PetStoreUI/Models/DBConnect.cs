using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetStoreUI.Models
{
    
    public class DBConnect
    {
        //properties

        private MySqlConnection connection;
        private string server;
        private string database;

        private string _table;

        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }


        private string uid;
        private string password;
        
       
        //Constructors
        
        public DBConnect()
        {
            
        }

        public DBConnect(string server, string database, string table,
            string userId, string password)
        {
            Table = table;
            Initialize(server, database, userId, password);
        }
        
        //Methods
        
        
        //Initialize connection values.

        private void Initialize(string selectedServer,string db, string user, string pass)
        {
            server = selectedServer; 
            database = db; 
            uid = user; 
            password = pass; 

            string connectionString;

            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        
        //Open connection to database

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
               
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator.");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again.");
                        break;

                    default:
                        MessageBox.Show($"Connection error {ex.Number} has occurred. Contact administrator.");
                        break;
                }
                return false;
            }
        }


        //Close connection

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Insert statement

        public void Insert(string columns, string values)
        {
            string query = $"INSERT INTO {Table} ({columns}) VALUES ({values})";
                                   

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
               

        //Select statement

        public List<string>[] SelectAll()
        {
            string query = $"SELECT * FROM {Table}";


            // List<string> list = new List<string>();

            List<string>[] result = new List<string>[6];

            result[0] = new List<string>(); //name
            result[1] = new List<string>(); //animaltype
            result[2] = new List<string>(); //price
            result[3] = new List<string>(); //id
            result[4] = new List<string>(); //description
            result[5] = new List<string>(); //picture




            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    result[0].Add($"{dataReader["name"]}");
                    result[1].Add($"{dataReader["animaltype"]}");
                    result[2].Add($"{dataReader["price"]}");
                    result[3].Add($"{dataReader["id"]}");
                    result[4].Add($"{dataReader["description"]}");
                    result[5].Add($"{dataReader["picture"]}");
                                        
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return result;
            }
            else
            {
                return result;
            }
        }

        
    }

}

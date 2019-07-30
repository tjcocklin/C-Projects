using Caliburn.Micro;
using PetStoreUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetStoreUI.ViewModels
{
    public class WindowLoginViewModel : Conductor<object>
    {
                            
        //Properties

        private string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                NotifyOfPropertyChange(() => User);
            }
        }


        private string _passWord;
        public string PassWord
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                NotifyOfPropertyChange(() => PassWord);
            }
        }



        private string _server;
        public string Server
        {
            get { return _server; }
            set
            {
                _server = value;
                NotifyOfPropertyChange(() => Server);
            }
        }


        private string _database;
        public string DataBase
        {
            get { return _database; }
            set
            {
                _database = value;
                NotifyOfPropertyChange(() => DataBase);
            }
        }


        private string _table;
        public string Table
        {
            get { return _table; }
            set
            {
                _table = value;
                NotifyOfPropertyChange(() => Table);
            }
        }


        private DBConnect _connection;
        public DBConnect Connect
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
                NotifyOfPropertyChange(() => Connect);
            }
        }

        //Constructor
        public WindowLoginViewModel()
        {
        }
        
        //Methods

         /// <summary>
         /// Clear Button- allows the user to clear out all fields.
         /// </summary>
        public void ClearButton()
        {
            User = "";
            PassWord = "";
            Server = "";
            DataBase = "";
            Table = "";
           
        }
        
        /// <summary>
        /// Readies the Database connection and takes the User to the welcome screen.
        /// </summary>
        public void LoginButton()
        {
                                   
            if(!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(PassWord) &&
                !string.IsNullOrEmpty(Server) && !string.IsNullOrEmpty(DataBase) &&
                !string.IsNullOrEmpty(Table))
            {

                Connect = new DBConnect(Server, DataBase, Table, User, PassWord);
                ActivateItem(new UserControlWelcomeViewModel(Connect));

            }
            else
            {
                MessageBox.Show("Please fill out all the fields first.");
            }
                                   

        }
    }
}

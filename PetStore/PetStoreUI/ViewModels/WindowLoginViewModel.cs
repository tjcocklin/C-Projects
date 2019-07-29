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


        public WindowLoginViewModel()
        {
        }

        public void ClearButton()
        {
            User = "";
            PassWord = "";
            Server = "";
            DataBase = "";
            Table = "";
            //MessageBox.Show("Clear Button clicked.");

        }


        public void LoginButton()
        {
             Connect = new DBConnect(Server, DataBase, Table, User, PassWord );

            //ActivateItem(new ShellViewModel(Connect));
            ActivateItem(new UserControlWelcomeViewModel(Connect));
            //MessageBox.Show("Login clicked");

        }
    }
}

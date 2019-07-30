using Caliburn.Micro;
using PetStoreUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreUI.ViewModels
{
    class UserControlWelcomeViewModel : Conductor<object>
    {

        //Properties

        private DBConnect _connection;
        public DBConnect Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;

            }
        }

        //Constructors

        public UserControlWelcomeViewModel()
        {
        }

        public UserControlWelcomeViewModel(DBConnect db)
        {
            Connection = db;
        }

        //Methods

        /// <summary>
        /// FindPetButton- changes the user control to FindPetView
        /// </summary>
        public void FindPetButton()
        {
            ActivateItem(new UserControlFindPetViewModel(Connection));
        }

        /// <summary>
        /// AddPetButton- changes the user control to AddPetView
        /// </summary>
        public void AddPetButton()
        {
            ActivateItem(new UserControlAddPetViewModel(Connection));
        }
    
    }
}

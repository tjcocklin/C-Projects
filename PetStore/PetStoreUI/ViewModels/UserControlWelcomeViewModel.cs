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


        public UserControlWelcomeViewModel()
        {
            //Connection = null;
        }

        public UserControlWelcomeViewModel(DBConnect db)
        {
            Connection = db;
        }

        public void FindPetButton()
        {
            ActivateItem(new UserControlFindPetViewModel(Connection));
        }


        public void AddPetButton()
        {
            ActivateItem(new UserControlAddPetViewModel(Connection));
        }
    
    }
}

using Caliburn.Micro;
using Microsoft.Win32;
using PetStoreUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetStoreUI.ViewModels
{
    public class UserControlAddPetViewModel :Conductor<object>
    {

        //properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }


        private string _animalType;
        public string AnimalType
        {
            get { return _animalType; }
            set
            {
                _animalType = value;
                NotifyOfPropertyChange(() => AnimalType);
            }
        }


        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                string input;
                string correction = "Numbers only!";

                double converted;
                bool result;
                input = value;

                result = double.TryParse(input, out converted);

                if (result == false)
                {
                    _price = correction;
                }
                else
                {
                    NumberPrice = converted;
                    _price = $"{converted}";
                    NotifyOfPropertyChange(() => NumberPrice);
                }
                NotifyOfPropertyChange(() => Price);
                
            }
        }
        public double NumberPrice { get; set; }


        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                string input;
                string correction = "Numbers only!";

                int converted;
                bool result;
                input = value;

                result= int.TryParse(input, out converted);

                if(result == false)
                {
                    _id = correction;
                }
                else
                {
                    NumberId = converted;
                    _id = $"{converted}";
                    NotifyOfPropertyChange(() => NumberId);
                }
                NotifyOfPropertyChange(() => Id);
                              
            }
        }
        public int NumberId { get; set; }
       

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

          
        private string _picture =$"/Images/RainbowPawPrint.png";
        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
                NotifyOfPropertyChange(() => Picture); 
            }
        }


        private AnimalRecord newPet;

        private DBConnect Connection;

        //Constructor
        public UserControlAddPetViewModel(DBConnect db)
        {
            Connection = db;
            newPet = new AnimalRecord();

        }

        //Methods

        /// <summary>
        /// PetImageButton-Allows the user to add a jpg or png of a pet.
        /// </summary>
        public void PetImageButton()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image files (*.png, *.jpg)|*.png;*.jpg";

            
            if (dialog.ShowDialog() == true)
            {
                Picture = dialog.FileName;
            }

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                MessageBox.Show($"Adding {dialog.FileName}");
            }
        }

        /// <summary>
        /// ClearButton-Clears the gui
        /// </summary>
        public void ClearButton()
        {
            Name = "";
            AnimalType = "";
            Price = "0";
            Id = "0";
            Description = "";
            Picture = $"/Images/RainbowPawPrint.png";
        }

        /// <summary>
        /// FillAnimalRecord-Creates a new animal Object to be added to the database.
        /// </summary>
        public void FillAnimalRecord() 
        {
            newPet.Name = Name;
            newPet.AnimalType = AnimalType;
            newPet.Price = NumberPrice;
            newPet.Id =NumberId;
            newPet.Description = Description;   
            newPet.Picture = Picture;
        }

        /// <summary>
        /// SaveButton-Saves the input to the Database 
        /// </summary>
        public void SaveButton()
        {
            //gather the Properties and put them in the object
            try
            {
                FillAnimalRecord();
            }
            catch (Exception)
            {
                MessageBox.Show("One or two of the number values you gave are incorrect");
            }

            try
            {
                string columns = "name, animaltype, price, id, " +
                                 "description, picture";

                string values = $"'{newPet.Name}', '{newPet.AnimalType}', " +
                    $"{newPet.Price}, {newPet.Id}, '{newPet.Description}', " +
                    $"'{newPet.Picture}'";
                                

                Connection.Insert(columns, values) ;
                
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}

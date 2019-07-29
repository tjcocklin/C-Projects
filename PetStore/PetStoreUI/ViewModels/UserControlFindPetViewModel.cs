using Caliburn.Micro;
using PetStoreUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreUI.ViewModels
{

    class UserControlFindPetViewModel : Conductor<object>
    {
        
        //properties
                    
        private BindableCollection<AnimalRecord> _animalList = new BindableCollection<AnimalRecord>();
        public BindableCollection<AnimalRecord> AnimalList
        {
            get
            {
                return _animalList;
            }
            set
            {
                _animalList = value;
                NotifyOfPropertyChange(() => AnimalList);
            }
        }


        private AnimalRecord _selectedAnimal;
        public AnimalRecord SelectedAnimal
        {
            get
            {
                return _selectedAnimal;
            }

            set
            {
                _selectedAnimal = value;
                NotifyOfPropertyChange(() => SelectedAnimal);
            }
        }


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

        private string _petImage;

        public string PetImage
        {
            get { return _petImage; }
            set
            {
                _petImage = value;
                NotifyOfPropertyChange(() => PetImage);
            }
        }

        //Constructors

        public UserControlFindPetViewModel()
        {
            LoadSampleData();
        }
        public UserControlFindPetViewModel(DBConnect db)
        {
            Connection = db;
            LoadDBData();
            
        }

        //methods

        private void LoadSampleData()
        {
            AnimalList.Add(new AnimalRecord
            {
                Name = "Ben",
                AnimalType = "Cat",
                Price = 20.00,
                Id = 1,
                Description = "asdfsldfsdjflsjdlfjsdjflsjdflsjdlfjsdlf",
                Picture = $"/Images/ShellViewBackgroundImage.png"
            });

            AnimalList.Add(new AnimalRecord
            {
                Name = "Jinn",
                AnimalType = "Dog",
                Price = 25.00,
                Id = 2,
                Description = "bsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdf"
            });
        }

        private void LoadDBData()
        {
            List<string>[] results = Connection.SelectAll();

            double price;
            int id;

            for (int i =0; i < results[3].Count; i++) //for the number of entries with listed id which is Pkey.
            {
                double.TryParse(results[2][i], out price);
                int.TryParse(results[3][i],out id);

                AnimalList.Add(new AnimalRecord
                {
                    Name = results[0][i],
                    AnimalType = results[1][i],
                    Price = price,
                    Id = id,
                    Description = results[4][i],
                    Picture =results[5][i]
                    
                });
                //PetImage = results[5][i];
                //Console.WriteLine("\n\n");
                //Console.WriteLine(PetImage);
            }
            
            

        }
              

    }
}   

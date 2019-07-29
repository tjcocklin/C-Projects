using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreUI.Models
{
    
    public class AnimalRecord
    {
        //properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _animalType;
        public string AnimalType
        {
            get { return _animalType; }
            set { _animalType = value; }
        }


        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }


        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        private string _picture;
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }


        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id= value; }
        }

        //Constructor
        public AnimalRecord()
        {
           this.Name = "Blank Name";
           this.AnimalType = "Blank Type";
           this.Price = 0.00;
           this.Description = "Blank Description";
           this.Picture = "No Photo available";
           this.Id = 0;

        }



    }
}

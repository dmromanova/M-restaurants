using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_reastaurants
{
    class Restaurant
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _decor;

        public int Decor
        {
            get { return _decor; }
            set { _decor = value; }
        }

        private int _service;

        public int Service
        {
            get { return _service; }
            set { _service = value; }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private string _foodType;

        public string FoodType
        {
            get { return _foodType; }
            set { _foodType = value; }
        }

        public Restaurant(string name, int decor, int service, int price, string location, string foodtype)
        {
            _name = name;
            _decor = decor;
            _service = service;
            _price = price;
            _location = location;
            _foodType = foodtype;
        }






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassesOOP
{
    class Car
    {
        private string _carName = "";
        private string _specs = "";
        

        public bool IsLuxury { get; set; }

        public string CarName { get => _carName; 
        
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("_carName can't be null!");

                _carName = value;
            }
        }
        
        public string Specs
        {
            get
            {
                if (IsLuxury)
                {
                    return _specs + " Lux Edition";
                }
                else
                {
                    return _specs;
                }
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("_specs can't be null!");

                _specs = value;
            }
        }

        // Constructor
        public Car(string carName, string specs, bool isLuxury)
        {
            CarName = carName;
            Specs = specs;
            IsLuxury = isLuxury;

            Console.WriteLine($"CarName: {CarName} | Spec: {Specs} | Luxury: {IsLuxury}");
            
        }

        public void TestDrive()
        {
            Console.WriteLine($"Driving the: {CarName} | Specs: {Specs}");
        }
    }
}

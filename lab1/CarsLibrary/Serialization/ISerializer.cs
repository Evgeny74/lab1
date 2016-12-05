using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsLibrary.Serialization
{
    interface ISerializer<T> where T : Automobile
    {
        void serialize(MyCollection<T> collection, String output);
        MyCollection<T> deSerialize(String input);
    }
}

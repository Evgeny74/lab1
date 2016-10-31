using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Serialization
{
    interface ISerializer<T>
    {
        void serialize(MyCollection<T> collection, String output);
        MyCollection<T> deSerialize(String input);
    }
}

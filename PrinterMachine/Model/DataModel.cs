using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterMachine.Model
{
    public class DataModel : IDataModel
    {
        public string Data { get; set; }
        public string? Reserse()
        {
            char[] charArray = Data.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public DataModel()
        {
            Data = "";
        }

        public DataModel(string data)
        {
            Data = data;
        }
    }
}

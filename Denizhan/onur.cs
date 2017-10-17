using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denizhan
{
    [Serializable()]
    public class kaynak_method
    {
        private string adres;
        private string adresyolu;



        public kaynak_method(string make, string model)
        {
            this.adres = make;
            this.adresyolu = model;

        }

        public string Make
        {
            get { return this.adres; }
        }

        public string Model
        {
            get { return this.adresyolu; }
        }
    }
}

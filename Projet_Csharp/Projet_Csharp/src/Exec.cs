using AppProjectS7.src.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjectS7
{
    class Exec
    {
        private static Restaurant res;
        static void Main(string[] args)
        {
            Clerk[] cler = { new Clerk("Julien","Delorme"), new Clerk("Mathieu","Adem") };
            Client[] cli = { new Client(false,"Jean", "Dupont", 0648592434, "146 rue test, Melun"), new Client(false,"Mattis", "Desvilles", 0648592434, "146 rue test, Melun") };
            DeliveryPerson[] del = { new DeliveryPerson("Jaques","Zyade") };
            res = new Restaurant(cler,cli,del);
        }
    }
}

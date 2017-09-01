using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp
{
    public class Product
    {
        public string Name       { get; set; }
        public int StockCount    { get; set; }
        public int OrderNumber   { get; set; }
        public string Supplier   { get; set; }
    }

    public class Client
    {
        public string Name                  { get; set; }
        public string MainContact           { get; set; }
        public string TelephoneNumber       { get; set; }
        public string RegistrationDate      { get; set; }
        public string Address               { get; set; }

        public ObservableCollection<Product> Products { get; set; }
    }
}

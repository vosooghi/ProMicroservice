using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Products.Commands.AddDiscounts
{
    public class AddDiscount:ICommand
    {
        public long Id { get; set; }
        public  string Title { get; set; }
        public  int Value { get; set; }
    }
}

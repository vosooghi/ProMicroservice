using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Products.Commands.CreateProducts
{
    public class CreateProdcut:ICommand
    {
        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int Price { get; set; }
        public  int  CategoryId { get; set; }
    }
}

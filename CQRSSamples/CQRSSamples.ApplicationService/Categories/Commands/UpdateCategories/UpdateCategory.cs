using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories
{
    public class UpdateCategory:ICommand
    {
        public  long CategoryId { get; set; }
        public  string CategoryName { get; set; }
    }
}

using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Categories.Commands.CreateCategories
{
    public class CreateCategory:ICommand
    {
        public string CategoryName { get; set; } = String.Empty;
    }
}

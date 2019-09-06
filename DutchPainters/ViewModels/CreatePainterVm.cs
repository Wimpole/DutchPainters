using DutchPainters.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchPainters.ViewModels
{
    public class CreatePainterVm
    {
        public Painter Painter { get; set; }
        public IEnumerable<SelectListItem> AllEpochs { get; set; }
    }
}

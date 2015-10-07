using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{
    public class BaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Result { get; set; }
        [ScaffoldColumn(false)]
        public string Keyword { get; set; }
        public BaseViewModel()
        {

            Keyword = string.Empty;

        }
    }


}

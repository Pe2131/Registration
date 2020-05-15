using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.ViewModels
{
    public class Home_ViewModel
    {
        public IEnumerable<Tb_Slider> tb_Sliders { get; set; }
        public Tb_Setting tb_Setting { get; set; }

    }
}

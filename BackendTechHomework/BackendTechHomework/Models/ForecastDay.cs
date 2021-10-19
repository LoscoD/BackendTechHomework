using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTechHomework.Models
{
    public class ForecastDay
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        public Day day { get; set; }
    }
}

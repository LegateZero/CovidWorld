using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19.Models;

namespace CV19.Services.Interface
{
    internal interface IDataService
    {
        IEnumerable<CountryInfo> GetData();
    }
}

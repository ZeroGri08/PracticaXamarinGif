using GifsXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GifsXamarin.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Movies>> GetMoviesAsync();
    }
}

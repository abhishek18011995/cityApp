using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.Services
{
    public interface ILocalMailService
    {
        void Send(string subject, string message);

    }
}

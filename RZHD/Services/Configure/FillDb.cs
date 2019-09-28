using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Configure.Models.Configure.Interfaces;

namespace RZHD.Services.Configure
{
    public class FillDb : IConfigureWork
    {
        public async Task Configure()
        {
            await AddDefaultUser();
        }

        private async Task AddDefaultUser()
        {
            //throw new NotImplementedException();
        }
    }
}

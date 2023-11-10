using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.DataAccess.Repository.IRepository
{
    public interface IApplicationRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser obj);

    }
}

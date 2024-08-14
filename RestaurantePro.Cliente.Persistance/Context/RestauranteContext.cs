using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Cliente.Persistance.Context
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)

        {









        }

        #region "DbSets"
        public DbSet<Domain.Entities.Cliente> Cliente { get; set; }
        #endregion

    }
}

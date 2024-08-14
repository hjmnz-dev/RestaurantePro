using RestauranteSol.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Cliente.Domain.Interface
{
    public interface IClienteRepository : IBaseRepository<Cliente.Domain.Entities.Cliente,int>
    {

        List<Cliente.Domain.Entities.Cliente> GetCliente(int id);
       
    }
}

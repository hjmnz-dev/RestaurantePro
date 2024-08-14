
using Microsoft.EntityFrameworkCore;
using RestauranteMaMonolitica.Web.Data.Models;
using RestaurantePro.Cliente.Domain.Entities;
using RestaurantePro.Cliente.Domain.Interface;
using RestaurantePro.Cliente.Persistance.Context;
using RestauranteSol.Common.Data.Repository;
using System.Linq.Expressions;
using System.Numerics;

namespace RestaurantePro.Cliente.Persistance.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly RestauranteContext _context;

        public ClienteRepository(RestauranteContext context)
        {
            _context = context;
        }

        public bool Exist(Expression<Func<Domain.Entities.Cliente, bool>> filter)
        {
            return _context.Cliente.Any(filter);
        }

        public List<Domain.Entities.Cliente> GetAll()
        {
            return _context.Cliente.ToList();
        }

        public Domain.Entities.Cliente GetEntityById(int Id)
        {
            return _context.Cliente.Find(Id);
        }

        public List<Domain.Entities.Cliente> GetCliente(int id)
        {
            return _context.Cliente.Where(f => f.id == id).ToList();
        }

        public void Remove(Domain.Entities.Cliente entity)
        {
            Domain.Entities.Cliente clienteRemove = this.GetEntityById(entity.id);
            if (clienteRemove == null)
            {
                throw new ArgumentNullException("El curso que desea Actualizar no se Encuentra Registrado");
            }
            _context.Entry(entity).State = EntityState.Deleted;

            clienteRemove.deleted =entity.deleted;
            clienteRemove.delete_date = entity.delete_date;
            clienteRemove.delete_user = entity.delete_user;

            _context.Cliente.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Domain.Entities.Cliente entity)
        {
         
            _context.Add(entity);
            _context.SaveChanges();

        }

        public void Update(Domain.Entities.Cliente entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("la entidad esta nula");
                }

                Domain.Entities.Cliente clienteToUpdate = this._context.Cliente.Find(entity.id);
                if (clienteToUpdate == null)
                {
                    throw new ArgumentNullException("El curso que desea Actualizar no se Encuentra Registrado");
                }
                clienteToUpdate.Total = entity.Total;
                clienteToUpdate.Fecha = entity.Fecha;
                clienteToUpdate.modify_date = entity.modify_date;
                clienteToUpdate.modify_user = entity.modify_user;

                _context.Cliente.Update(clienteToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            { 
              throw ex;
            }
        }
            
        }
    }


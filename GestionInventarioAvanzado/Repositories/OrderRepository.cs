using GestionInventarioAvanzado.Data;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionInventarioAvanzado.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order Add(Order order)
        {
            var orderSaved = _dbContext.Add(order);
            _dbContext.SaveChanges();

            return orderSaved.Entity;
        }

        public bool Delete(Order order)
        {
            EntityEntry entity = _dbContext.Remove(order);
            _dbContext.SaveChanges();

            return entity != null;
        }

        public IEnumerable<Order> FindAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order FindById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public Order Update(Order order)
        {
            var orderSaved = _dbContext.Update(order);
            _dbContext.SaveChanges();

            return orderSaved.Entity;
        }
    }
}

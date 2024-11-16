using GestionInventarioAvanzado.Data;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionInventarioAvanzado.Repositories
{
    public class InventoryMovementRepository : IInventoryMovementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryMovementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public InventoryMovement Add(InventoryMovement inventoryMovement)
        {
            var inventoryMovementSaved = _dbContext.Add(inventoryMovement);
            _dbContext.SaveChanges();

            return inventoryMovementSaved.Entity;
        }

        public bool Delete(InventoryMovement inventoryMovement)
        {
            EntityEntry entity = _dbContext.Remove(inventoryMovement);
            _dbContext.SaveChanges();

            return entity != null;
        }

        public IEnumerable<InventoryMovement> FindAll()
        {
            return _dbContext.InventoryMovements.ToList();
        }

        public InventoryMovement FindById(int id)
        {
            return _dbContext.InventoryMovements.FirstOrDefault(x => x.Id == id);
        }

        public InventoryMovement Update(InventoryMovement inventoryMovement)
        {
            var inventoryMovementSaved = _dbContext.Update(inventoryMovement);
            _dbContext.SaveChanges();

            return inventoryMovementSaved.Entity;
        }
    }
}

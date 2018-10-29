using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Models.Relational
{
    public class CustomerRelationalRepository
    {
        private readonly CustomerRelationalDBContext _context;
        public CustomerRelationalRepository (CustomerRelationalDBContext context)
        {
            _context = context;
        }

        public CustomerRecord Create(CustomerRecord customer)
        {
            EntityEntry<CustomerRecord> entry = _context.Customers.Add(customer);
            _context.SaveChanges();
            return entry.Entity;
        }

        public void Update(CustomerRecord customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            _context.Customers.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IQueryable<CustomerRecord> GetAll()
        {
            return _context.Customers;
        }

        private CustomerRecord GetById(long id)
        {
            return _context.Customers.Find(id);
        }
    }
}

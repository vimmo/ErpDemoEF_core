using ErpDemoEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpDemoEF.Services
{
    public interface IDBClientiService
    {
        public Clienti CreaCliente(Clienti cliente);
        public Clienti ModificaCliente(Clienti cliente);
        public IEnumerable<Clienti> GetClientiList();
        public Clienti GetCliente(int id);
    }
    public class DBClientiService : IDBClientiService
    {
        private readonly ErpDemoContext _context;
        public DBClientiService ()
        {
            _context = new ErpDemoContext();
        }
        public Clienti CreaCliente(Clienti cliente)
        {
            _context.Clienti.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }
        public Clienti ModificaCliente(Clienti cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return cliente;
        }
        public IEnumerable<Clienti> GetClientiList()
        {
            return _context.Clienti.Where(c => c.Citta == "Genova" );
        }
        public Clienti GetCliente(int id)
        {
            return _context.Clienti.Find(id);
        }
    }
}

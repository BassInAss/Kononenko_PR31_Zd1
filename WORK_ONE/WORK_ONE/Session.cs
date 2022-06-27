using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORK_ONE.Models;

namespace WORK_ONE
{
    public static class Session
    {
        private static BrowsEntities _context;
        public static BrowsEntities Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new BrowsEntities();
                    _context.Client.Load();
                    _context.Gender.Load();
                    _context.ClientService.Load();
                    _context.DocumentByService.Load();
                    _context.Manufacturer.Load();
                    _context.Product.Load();
                    _context.ProductPhoto.Load();
                    _context.ProductSale.Load();
                    _context.Service.Load();
                    _context.ServicePhoto.Load();
                    _context.Tag.Load();
                }
                return _context;
            }
        }
    }
}

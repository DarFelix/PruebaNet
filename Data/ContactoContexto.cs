using Microsoft.EntityFrameworkCore;
using PruebaNet.Models;

namespace PruebaNet.Data
{
    public class ContactoContexto : DbContext
    {
        public ContactoContexto(DbContextOptions<ContactoContexto> options) : base(options)
        {
        }

        public DbSet<Contacto> ContactoItems { get; set; } = null!;

    }
}

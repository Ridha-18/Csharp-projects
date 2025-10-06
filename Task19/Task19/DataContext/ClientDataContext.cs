using Microsoft.EntityFrameworkCore;
using Task19.Models;


namespace Task19.DataContext
{
    public class ClientDataContext :DbContext
    {

        public ClientDataContext(DbContextOptions<ClientDataContext> options) : base(options) { }


        public DbSet<Client> clients { get; set; }
    }
}

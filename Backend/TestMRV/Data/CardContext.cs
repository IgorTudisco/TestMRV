using Microsoft.EntityFrameworkCore;
using TestMRV.Models;

namespace TestMRV.Data
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> opts) :base(opts)
        {
            
        }

        public DbSet<Card> Cards { get; set; }

    }
}

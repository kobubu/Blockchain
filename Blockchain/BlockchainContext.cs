using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class BlockchainContext : DbContext
    {
        public BlockchainContext() : base ("BlockchainConnection2") 
        { 
        }

        public DbSet<Block> Blocks { get; set; }
    }
}

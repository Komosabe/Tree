using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Infrastructure.Persistence;

namespace Tree.Infrastructure.Seeders
{
    public class TreeSeeder
    {
        private readonly TreeDbContext _dbContext;
        public TreeSeeder(TreeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Nodes.Any())
                {
                    var parent1 = new Domain.Entities.Node()
                    {
                        Name = "Parent1",
                    };

                    var parent2 = new Domain.Entities.Node()
                    {
                        Name = "Parent2",
                    };

                    var parent3 = new Domain.Entities.Node()
                    {
                        Name = "Parent3",
                    };


                    var parent4 = new Domain.Entities.Node()
                    {
                        Name = "Parent4",
                    };


                    var parent5 = new Domain.Entities.Node()
                    {
                        Name = "Parent5",
                    };

                    _dbContext.Nodes.AddRange(parent1, parent2, parent3, parent4, parent5);

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

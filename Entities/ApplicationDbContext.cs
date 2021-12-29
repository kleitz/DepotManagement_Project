using DepotManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using SystemManagementService.Models;

namespace Entities
{
    
        public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

            public DbSet<LPN> LPN { get; set; }
            public DbSet<NodeEdges> NodeEdges { get; set; }
            public DbSet<Nodes> Nodes { get; set; }
            public DbSet<ProductBundles> ProductBundles { get; set; }
            public DbSet<Products> Products { get; set; }
            public DbSet<Customers> Customers { get; set; }
            public DbSet<InBoundOrders> InBoundOrders { get; set; }
            public DbSet<OutBoundOrders> OutBoundOrders { get; set; }
            public DbSet<Shipment> Shipments { get; set; }



        }
    }

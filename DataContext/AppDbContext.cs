using Code.Challenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace Code.Challenge.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductMappings> ProductMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("@\"Server=.\\;Database=ProductDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Products> productsInsert = new()
            {
                new Products() { Id = 1, Name = "Car",  IsAssembled = true },
                new Products() { Id = 2, Name = "Chassis", IsAssembled = true },
                new Products() { Id = 3, Name = "Body", IsAssembled = true },
                new Products() { Id = 4, Name = "Seat", Qty = 25, IsAssembled = false },
                new Products() { Id = 5, Name = "Door", Qty = 30, IsAssembled = false },
                new Products() { Id = 6, Name = "Window", Qty = 20, IsAssembled = false },
                new Products() { Id = 7, Name = "Dashboard", Qty = 5, IsAssembled = false },
                new Products() { Id = 8, Name = "Steering Wheel", Qty = 10, IsAssembled = false },
                new Products() { Id = 9, Name = "Interior", IsAssembled = true },
                new Products() { Id = 10, Name = "LED", Qty = 20, IsAssembled = false },
                new Products() { Id = 11, Name = "Engine", IsAssembled = true },
                new Products() { Id = 12, Name = "4 Stroke", Qty = 15, IsAssembled = false },
                new Products() { Id = 13, Name = "8 Stroke", Qty = 20, IsAssembled = false },
                new Products() { Id = 14, Name = "Tire", IsAssembled = true },
                new Products() { Id = 15, Name = "Tube", Qty = 50, IsAssembled = false },
                new Products() { Id = 16, Name = "Wheel", IsAssembled = true },
                new Products() { Id = 17, Name = "Axle", Qty = 60, IsAssembled = false },
                new Products() { Id = 18, Name = "Dish", Qty = 40, IsAssembled = false },


                new Products() { Id = 19, Name = "Bike", IsAssembled = true },
                new Products() { Id = 20, Name = "Seat", Qty = 30, IsAssembled = false },
                new Products() { Id = 21, Name = "Pedal", Qty = 40, IsAssembled = false },
                new Products() { Id = 22, Name = "Wheel", IsAssembled = true },
                new Products() { Id = 23, Name = "Frame", Qty = 60, IsAssembled = false },
                new Products() { Id = 24, Name = "Tube", Qty = 35, IsAssembled = false },


                new Products() { Id = 25, Name = "Smartphone", IsAssembled = true },
                new Products() { Id = 26, Name = "Screen Assembly", IsAssembled = true },
                new Products() { Id = 27, Name = "Screen Panel", Qty = 15, IsAssembled = false },
                new Products() { Id = 28, Name = "Up Panel", Qty = 25, IsAssembled = false },
                new Products() { Id = 29, Name = "Down Panel ", Qty = 30, IsAssembled = false },
                new Products() { Id = 30, Name = "Screen Body", IsAssembled = true },
                new Products() { Id = 31, Name = "Metal", Qty = 18, IsAssembled = false },
                new Products() { Id = 32, Name = "Battery Assembly", IsAssembled = true },
                new Products() { Id = 33, Name = "Battery Cell", Qty = 10, IsAssembled = false },
                new Products() { Id = 34, Name = "Connector", Qty = 20, IsAssembled = false },
                new Products() { Id = 35, Name = "Mainboard", IsAssembled = true },
                new Products() { Id = 36, Name = "Camera Module", Qty = 22, IsAssembled = false },
                new Products() { Id = 37, Name = "Processor", IsAssembled = true },
                new Products() { Id = 38, Name = "CPU", Qty = 40, IsAssembled = false },
                new Products() { Id = 39, Name = "Memory Chip", IsAssembled = true },
                new Products() { Id = 40, Name = "RAM", Qty = 12, IsAssembled = false },
                new Products() { Id = 41, Name = "ROM", Qty = 18, IsAssembled = false },
                new Products() { Id = 42, Name = "Casing", IsAssembled = true },
                new Products() { Id = 43, Name = "Plastic Shell", Qty = 25, IsAssembled = false },
                new Products() { Id = 44, Name = "Metal Frame", Qty = 30, IsAssembled = false },
                new Products() { Id = 45, Name = "Speaker", IsAssembled = true },
                new Products() { Id = 46, Name = "Diaphragm", Qty = 18, IsAssembled = false },
                new Products() { Id = 47, Name = "Magnet", Qty = 14, IsAssembled = false },
                new Products() { Id = 48, Name = "Voice Coil", Qty = 14, IsAssembled = false },
                new Products() { Id = 49, Name = "Microphone", IsAssembled = true },
                new Products() { Id = 50, Name = "Membrane", Qty = 25, IsAssembled = false },
                new Products() { Id = 51, Name = "Electret Condenser", Qty = 15, IsAssembled = false },
                new Products() { Id = 52, Name = "Button", IsAssembled = true },
                new Products() { Id = 53, Name = "Plastic Button", Qty = 40, IsAssembled = false },
                new Products() { Id = 54, Name = "Tactile Switch", Qty = 50, IsAssembled = false },
            };

            modelBuilder.Entity<Products>().HasData(productsInsert);

            List<ProductMappings> mappingsInsert = new()
            {
                new ProductMappings() { Id = 1, ParentProductId = 1, ChildProductId = 2, RequiredQty = 1 }, // Chassis for Car
                new ProductMappings() { Id = 2, ParentProductId = 1, ChildProductId = 11, RequiredQty = 1 }, // Engine for Car
                new ProductMappings() { Id = 3, ParentProductId = 1, ChildProductId = 14, RequiredQty = 4 }, // Tire for Car
                new ProductMappings() { Id = 4, ParentProductId = 2, ChildProductId = 3, RequiredQty = 1 }, // Body for Chassis
                new ProductMappings() { Id = 5, ParentProductId = 2, ChildProductId = 9, RequiredQty = 1 }, // Interior for Chassis
                new ProductMappings() { Id = 6, ParentProductId = 3, ChildProductId = 4, RequiredQty = 4 }, // Seat for Body
                new ProductMappings() { Id = 7, ParentProductId = 3, ChildProductId = 5, RequiredQty = 4 }, // Door for Body
                new ProductMappings() { Id = 8, ParentProductId = 3, ChildProductId = 6, RequiredQty = 4 }, // Window for Door
                new ProductMappings() { Id = 9, ParentProductId = 3, ChildProductId = 7, RequiredQty = 1 }, // Dashboard for Body
                new ProductMappings() { Id = 10, ParentProductId = 3, ChildProductId = 8, RequiredQty = 1 }, // Steering Wheel for Body
                new ProductMappings() { Id = 11, ParentProductId = 9, ChildProductId = 10, RequiredQty = 4 }, // LED for Interior
                new ProductMappings() { Id = 12, ParentProductId = 11, ChildProductId = 12, RequiredQty = 1 }, // 4 Stroke for Engine
                new ProductMappings() { Id = 13, ParentProductId = 11, ChildProductId = 13, RequiredQty = 1 }, // 8 Stroke for Engine
                new ProductMappings() { Id = 14, ParentProductId = 14, ChildProductId = 15, RequiredQty = 1 }, // Tube for Tire
                new ProductMappings() { Id = 15, ParentProductId = 14, ChildProductId = 16, RequiredQty = 4 }, // Wheel for Tire
                new ProductMappings() { Id = 16, ParentProductId = 16, ChildProductId = 17, RequiredQty = 1 }, // Axle for Wheel
                new ProductMappings() { Id = 17, ParentProductId = 16, ChildProductId = 18, RequiredQty = 1 }, // Dish for Wheel

                new ProductMappings() { Id = 18, ParentProductId = 19, ChildProductId = 20, RequiredQty = 1 }, // Seat for Bike
                new ProductMappings() { Id = 19, ParentProductId = 19, ChildProductId = 21, RequiredQty = 2 }, // Pedal for Bike
                new ProductMappings() { Id = 20, ParentProductId = 19, ChildProductId = 22, RequiredQty = 2 }, // Wheel for Bike
                new ProductMappings() { Id = 21, ParentProductId = 22, ChildProductId = 23, RequiredQty = 1 }, // Frame for Wheel
                new ProductMappings() { Id = 22, ParentProductId = 22, ChildProductId = 24, RequiredQty = 1 }, // Tube for Wheel

                new ProductMappings() { Id = 23, ParentProductId = 25, ChildProductId = 26, RequiredQty = 1 }, // Screen Assembly for Phone
                new ProductMappings() { Id = 24, ParentProductId = 25, ChildProductId = 30, RequiredQty = 1 }, // Screen Body for Phone
                new ProductMappings() { Id = 25, ParentProductId = 25, ChildProductId = 32, RequiredQty = 1 }, // Battery Assembly for Phone
                new ProductMappings() { Id = 26, ParentProductId = 25, ChildProductId = 35, RequiredQty = 1 }, // Mainboard for Phone
                new ProductMappings() { Id = 27, ParentProductId = 25, ChildProductId = 37, RequiredQty = 1 }, // Processor for Phone
                new ProductMappings() { Id = 28, ParentProductId = 25, ChildProductId = 42, RequiredQty = 1 }, // Casing for Phone
                new ProductMappings() { Id = 29, ParentProductId = 25, ChildProductId = 45, RequiredQty = 2 }, // Speaker for Phone
                new ProductMappings() { Id = 30, ParentProductId = 25, ChildProductId = 52, RequiredQty = 2 }, // Button for Phone
                new ProductMappings() { Id = 31, ParentProductId = 26, ChildProductId = 27, RequiredQty = 1 }, // Screen Panel for Screen Assembly
                new ProductMappings() { Id = 32, ParentProductId = 26, ChildProductId = 28, RequiredQty = 1 }, // Up Panel for Screen Assembly
                new ProductMappings() { Id = 33, ParentProductId = 26, ChildProductId = 29, RequiredQty = 1 }, // Down Panel for Screen Assembly
                new ProductMappings() { Id = 34, ParentProductId = 30, ChildProductId = 31, RequiredQty = 1 }, // Metal for Screen Body
                new ProductMappings() { Id = 35, ParentProductId = 32, ChildProductId = 33, RequiredQty = 1 }, // Battery Cell for Battery Assembly
                new ProductMappings() { Id = 36, ParentProductId = 32, ChildProductId = 34, RequiredQty = 1 }, // Connector for Battery Assembly
                new ProductMappings() { Id = 37, ParentProductId = 35, ChildProductId = 36, RequiredQty = 3 }, // Camera Module for Mainboard
                new ProductMappings() { Id = 38, ParentProductId = 37, ChildProductId = 38, RequiredQty = 1 }, // CPU for Processor
                new ProductMappings() { Id = 39, ParentProductId = 37, ChildProductId = 39, RequiredQty = 1 }, // Memory Chip for Processor
                new ProductMappings() { Id = 40, ParentProductId = 39, ChildProductId = 40, RequiredQty = 1 }, // RAM for Memory Chip
                new ProductMappings() { Id = 41, ParentProductId = 39, ChildProductId = 41, RequiredQty = 1 }, // ROM for Memory Chip
                new ProductMappings() { Id = 42, ParentProductId = 42, ChildProductId = 43, RequiredQty = 1 }, // Plastic Shell for Casing
                new ProductMappings() { Id = 43, ParentProductId = 42, ChildProductId = 44, RequiredQty = 1 }, // Metal Frame for Casing
                new ProductMappings() { Id = 44, ParentProductId = 45, ChildProductId = 46, RequiredQty = 1 }, // Diaphragm for Speaker
                new ProductMappings() { Id = 45, ParentProductId = 45, ChildProductId = 47, RequiredQty = 1 }, // Magnet for Speaker
                new ProductMappings() { Id = 46, ParentProductId = 45, ChildProductId = 48, RequiredQty = 1 }, // Voice Coil for Speaker
                new ProductMappings() { Id = 47, ParentProductId = 45, ChildProductId = 49, RequiredQty = 1 }, // Microphone for Speaker
                new ProductMappings() { Id = 48, ParentProductId = 49, ChildProductId = 50, RequiredQty = 1 }, // Membrane for Microphone
                new ProductMappings() { Id = 49, ParentProductId = 49, ChildProductId = 51, RequiredQty = 1 }, // Electret Condenser for Microphone
                new ProductMappings() { Id = 50, ParentProductId = 52, ChildProductId = 53, RequiredQty = 1 }, // Plastic Button for Button
                new ProductMappings() { Id = 51, ParentProductId = 52, ChildProductId = 54, RequiredQty = 1 }, // Tactile Switch for Button
            };

            modelBuilder.Entity<ProductMappings>().HasData(mappingsInsert);
        }
    }
}

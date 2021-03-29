namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static VehicleShowRoomManager.Models.Vehicle;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleShowRoomManager.Models.ShowRoomDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VehicleShowRoomManager.Models.ShowRoomDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(x => x.Id,
                       new Models.Brand()
                       {
                           Id = 1,
                           Name = "VinFast",
                           Description = "Xe VinFast",
                           Status = Models.Brand.BrandStatus.Active,
                           CreatedAt = DateTime.Now,
                           UpdatedAt = DateTime.Now
                       },
                       new Models.Brand()
                       {
                           Id = 2,
                           Name = "Kia Morning",
                           Description = "Xe Kia",
                           Status = Models.Brand.BrandStatus.Active,
                           CreatedAt = DateTime.Now,
                           UpdatedAt = DateTime.Now
                       }

                   );

            context.VehicleModels.AddOrUpdate(x => x.Id,
                new Models.VehicleModel()
                {
                    Id = 1,
                    BrandId = 1,
                    ModelName = "Vf-e34",
                    ModelNumber = "Vf-e34",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "electronic car vinfast",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 2,
                    BrandId = 1,
                    ModelName = "Vinfast LUX SA2.0",
                    ModelNumber = "LUX SA2.0",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "vinfast luxury",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 3,
                    BrandId = 2,
                    ModelName = "KIA QUORIS",
                    ModelNumber = "KIA QUORIS - GAT - 3.8",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "kia car",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 4,
                    BrandId = 2,
                    ModelName = "KIA SORENTO (ALL NEW) - 2.2D DELUXE",
                    ModelNumber = "KIA SORENTO (ALL NEW) - 2.2D DELUXE",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "kia car",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                }
            );

            context.Vehicles.AddOrUpdate(x => x.Id,
                new Models.Vehicle()
                {
                    Id = 1,
                    Color = "Blue",
                    Name = "Vinfast VFe34",
                    Cover = "https://image.thanhnien.vn/660/uploaded/vietduc/2021_03_24/vfe34_exterior1_akjn.jpg",
                    VIN = "RNYTD41M6BC023611",
                    FN = "123456789",
                    SalePrice = 30000,
                    Description = "The exterior of the Vinfast VFe34 electric SUV is considered neutral, gentle with gentle rounded lines like an MPV. DxRxC overall dimensions are 4,300x 1,793x 1,613 mm, wheelbase 2,611 mm, ground clearance 180mm and unladen weight 1,490 kg.",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Sold,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 2,
                    Color = "Black",
                    Name = "VinFast Lux SA2.0",
                    Cover = "https://www.vinfastotohaichau.vn/uploads/images/car_nahhr2sg-746-vinfast-lux-s2-0%20(1).png",
                    VIN = null,
                    FN = null,
                    SalePrice = 60000,
                    Description = "VinFast Lux SA2.0 still retains specific details and Vietnamese soul. Most notably, the daytime LED strip has an independent design with the V graphic that stretches most of the front of the car.",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Avaible,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 3,
                    Color = "Silver",
                    Name = "KIA QUORIS - GAT - 3.8",
                    Cover = "https://i.xeoto.com.vn/auto/w900/kia/quoris/2021/mau-xe-kia-quoris-panthera-metal.png",
                    VIN = "RRYTD41M6BC023612",
                    FN = "1234567810",
                    SalePrice = 120000,
                    Description = "Possessing an overall size of 5095 x 1900 x 1490 mm, the Kia Quoris 2021 has a superficial and longer design than the competition, making the car stand out when placed side by side. The highlight of the car lies in the plating, trim and silver trim around the car, helping the Korean model to stand out more, especially with the exterior color of glossy black paint.",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Sold,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 4,
                    Color = "White",
                    Name = "KIA SORENTO (ALL NEW) - 2.2D DELUXE",
                    Cover = "https://static.chotot.com/storage/chotot-kinhnghiem/xe/2019/12/xe-7-cho-kia-2.jpg",
                    VIN = null,
                    FN = null,
                    SalePrice = 50000,
                    Description = "This is a completely new model from Korea, so the car is applied with the latest technologies in the chassis as well as the engine or 8-speed dual-clutch transmission with other amenities.",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
                    VehicleModelId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );


        }
    }
}

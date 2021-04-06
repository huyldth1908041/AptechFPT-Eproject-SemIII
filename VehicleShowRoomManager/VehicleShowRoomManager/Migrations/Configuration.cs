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
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(VehicleShowRoomManager.Models.ShowRoomDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Brand seed
            context.Brands.AddOrUpdate(x => x.Id,
               new Models.Brand()
               {
                   Id = 1,
                   Name = "Kia",
                   Description = "Xe Kia",
                   Status = Models.Brand.BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 2,
                   Name = "Toyota",
                   Description = "Xe Toyota",
                   Status = Models.Brand.BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 3,
                   Name = "Mazda",
                   Description = "Xe Mazda",
                   Status = Models.Brand.BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               }
            );

            // VehicleModel seed
            context.VehicleModels.AddOrUpdate(x => x.Id,
                new Models.VehicleModel()
                {
                    Id = 1,
                    BrandId = 1,
                    ModelName = "Kia Morning",
                    ModelNumber = "Kia Morning",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "Kia Morning is a small car, many middle-income users choose",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 2,
                    BrandId = 2,
                    ModelName = "Toyota Innova",
                    ModelNumber = "Toyota Innova",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "The Toyota Innova features an elegant design",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 3,
                    BrandId = 3,
                    ModelName = "Mazda CX-5",
                    ModelNumber = "Mazda CX-5",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "Mazda CX-5 line of sport utility vehicle with high chassis",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                }
            );

            // ModelImage seed
            context.ModelImages.AddOrUpdate(x => x.Id,
                new Models.ModelImage()
                {
                    Id = 1,
                    Cover = "1.Kia-morning-white_tdmjbh",
                    Color = "White",
                    VehicleModelId = 1,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 2,
                    Cover = "2.mau-xe-kia-morning-shiny-red_m4t03j",
                    Color = "Red",
                    VehicleModelId = 1,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 3,
                    Cover = "3.mau-xe-kia-morning-xanh-la_fluagv",
                    Color = "Green",
                    VehicleModelId = 1,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 4,
                    Cover = "4.Toyota-Innova-2018-venturer-màu-đen_xcapz6",
                    Color = "Black",
                    VehicleModelId = 2,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 5,
                    Cover = "5.Toyota_Innova_bạc_neico2",
                    Color = "Gray",
                    VehicleModelId = 2,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 6,
                    Cover = "6.Toyota-innova-red_pe58lk",
                    Color = "Red",
                    VehicleModelId = 2,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 7,
                    Cover = "7.Mazda-CX-5-Xanh-đậm_hl6rlm",
                    Color = "Blue",
                    VehicleModelId = 3,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 8,
                    Cover = "8.Mazda-CX-5-2018-màu-nâu_db6vl2",
                    Color = "Brown",
                    VehicleModelId = 3,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 9,
                    Cover = "9.xe-mau-den-mazda-cx-5-2019-2020-muaxegiatot-com_hytppf",
                    Color = "Black",
                    VehicleModelId = 3,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                }
            );

            // Vehicle seed
            context.Vehicles.AddOrUpdate(x => x.Id,
                new Models.Vehicle()
                {
                    Id = 1,
                    Color = "White",
                    Name = "Kia Morning",
                    Cover = "1.Kia-morning-white_tdmjbh",
                    VIN = "RNYTD41M6BC023611",
                    FN = "0123456789",
                    SalePrice = 30000,
                    Description = "<ul><li>Vehicle name: Kia Morning</li><li>Dimensions: 3.595 mm D x 1.595-1.625 mm R x 1.485-1.500 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: White</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Pending,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 2,
                    Color = "Red",
                    Name = "Kia Morning",
                    Cover = "2.mau-xe-kia-morning-shiny-red_m4t03j",
                    VIN = "RRYTD41M6BC023612",
                    FN = "01234567810",
                    SalePrice = 30000,
                    Description = "<ul><li>Vehicle name: Kia Morning</li><li>Dimensions: 3.595 mm D x 1.595-1.625 mm R x 1.485-1.500 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Red</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 3,
                    Color = "Green",
                    Name = "Kia Morning",
                    Cover = "3.mau-xe-kia-morning-xanh-la_fluagv",
                    VIN = "LRYTD41M6BC044612",
                    FN = "12345678CRT0",
                    SalePrice = 30000,
                    Description = "<ul><li>Vehicle name: Kia Morning</li><li>Dimensions: 3.595 mm D x 1.595-1.625 mm R x 1.485-1.500 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Green</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 4,
                    Color = "Black",
                    Name = "Toyota Innova",
                    Cover = "4.Toyota-Innova-2018-venturer-màu-đen_xcapz6",
                    VIN = "RRYTD41M6BC023612",
                    FN = "00923339934",
                    SalePrice = 20000,
                    Description = "<ul><li>Vehicle name: Toyota Innova</li><li>Dimensions: 4.735 mm D x 1.830 mm R x 1.795 mm C</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 5,
                    Color = "Gray",
                    Name = "Toyota Innova",
                    Cover = "5.Toyota_Innova_bạc_neico2",
                    VIN = "RRYTD41M6BC02401",
                    FN = "00923339POM",
                    SalePrice = 20000,
                    Description = "<ul><li>Vehicle name: Toyota Innova</li><li>Dimensions: 4.735 mm D x 1.830 mm R x 1.795 mm C</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: Gray</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 6,
                    Color = "Red",
                    Name = "Toyota Innova",
                    Cover = "6.Toyota-innova-red_pe58lk",
                    VIN = "RRYTD41M6BC023620",
                    FN = "1234567800",
                    SalePrice = 20000,
                    Description = "<ul><li>Vehicle name: Toyota Innova</li><li>Dimensions: 4.735 mm D x 1.830 mm R x 1.795 mm C</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: Red</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 7,
                    Color = "Blue",
                    Name = "Mazda CX-5",
                    Cover = "7.Mazda-CX-5-Xanh-đậm_hl6rlm",
                    VIN = "RRYTD41M6BC023616",
                    FN = "12345678912",
                    SalePrice = 120000,
                    Description = "<ul><li>Vehicle name: Mazda CX-5</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Petrol</li><li>Control: Manual</li><li>Color: Blue</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Pending,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 8,
                    Color = "Brown",
                    Name = "Mazda CX-5",
                    Cover = "8.Mazda-CX-5-2018-màu-nâu_db6vl2",
                    VIN = "RRYTD41M6BC02002",
                    FN = "12345678993",
                    SalePrice = 120000,
                    Description = "<ul><li>Vehicle name: Mazda CX-5</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Petrol</li><li>Control: Manual</li><li>Color: Brown</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 9,
                    Color = "Black",
                    Name = "Mazda CX-5",
                    Cover = "9.xe-mau-den-mazda-cx-5-2019-2020-muaxegiatot-com_hytppf",
                    VIN = "RRYTD41M6BC02985",
                    FN = "2339ICP0WWE22",
                    SalePrice = 120000,
                    Description = "<ul><li>Vehicle name: Mazda CX-5</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Petrol</li><li>Control: Manual</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}

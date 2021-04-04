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
                           Name = "Kia",
                           Description = "Xe Kia",
                           Status = Models.Brand.BrandStatus.Active,
                           CreatedAt = DateTime.Now,
                           UpdatedAt = DateTime.Now
                       },
                       new Models.Brand()
                       {
                           Id = 3,
                           Name = "Toyota",
                           Description = "Xe Toyota",
                           Status = Models.Brand.BrandStatus.Active,
                           CreatedAt = DateTime.Now,
                           UpdatedAt = DateTime.Now
                       },
                       new Models.Brand()
                       {
                           Id = 4,
                           Name = "Lexus",
                           Description = "Xe Lexus",
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
                },
                new Models.VehicleModel()
                {
                    Id = 5,
                    BrandId = 3,
                    ModelName = "Toyota Innova",
                    ModelNumber = "Toyota Innova",
                    Status = Models.VehicleModel.VehicleModelStatus.Active,
                    Descriptions = "kia car",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 6,
                    BrandId = 4,
                    ModelName = "Lexus",
                    ModelNumber = "Lexus LS - Luxury Sedan",
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
                    Cover = "vfe34_exterior1_akjn_ghh6dn",
                    VIN = "RNYTD41M6BC023611",
                    FN = "123456789",
                    SalePrice = 30000,
                    Description = "<ul><li>Vehicle name: Vinfast Vf-e34</li><li>DxRxC overall dimensions are 4,300x 1,793x 1,613 mm, wheelbase 2,611 mm, ground clearance 180mm and unladen weight 1,490 kg.</li><li>Type: Electric car</li><li>Control: Automatic</li><li>Color: Blue</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 2,
                    Color = "Black",
                    Name = "VinFast Lux SA2.0",
                    Cover = "sa-orange-169_t981vy",
                    VIN = null,
                    FN = null,
                    SalePrice = 60000,
                    Description = "<ul><li>Vehicle name: VinFast Lux SA2.0</li><li>Length x width x height 4,940 x 1,960 x 1,773 (mm), wheelbase 2,933 mm, ground clearance 192 mm</li><li>Type: Petrol & Diesel</li><li>Control: Automatic</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 3,
                    Color = "Silver",
                    Name = "KIA QUORIS - GAT - 3.8",
                    Cover = "quoris_1wgfhLaP_aczktt",
                    VIN = "RRYTD41M6BC023612",
                    FN = "1234567810",
                    SalePrice = 120000,
                    Description = "<ul><li>Vehicle name: KIA QUORIS - GAT - 3.8</li><li>Possessing an overall size of 5095 x 1900 x 1490 mm</li><li>Type: Petrol & Diesel</li><li>Control: Automatic</li><li>Color: Silver</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 4,
                    Color = "White",
                    Name = "KIA SORENTO (ALL NEW) - 2.2D DELUXE",
                    Cover = "Kia-Sportage-2017-745158_aj0icj",
                    VIN = "LRYTD41M6BC044612",
                    FN = "12345678CRT0",
                    SalePrice = 50000,
                    Description = "<ul><li>Vehicle name: KIA SORENTO (ALL NEW) - 2.2D DELUXE</li><li>Kia Sorento 2021 has dimensions of 4,810 x 1,900 x 1,700 (mm) corresponding to length x width x height and a wheelbase of 2,815 mm.</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: White</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 5,
                    Color = "Red",
                    Name = "Vinfast Fadil",
                    Cover = "1_h624ox",
                    VIN = null,
                    FN = null,
                    SalePrice = 40000,
                    Description = "<ul><li>Vehicle name: KIA SORENTO (ALL NEW) - 2.2D DELUXE</li><li>Kia Sorento 2021 has dimensions of 3676 x 1632 x 1495 (mm) corresponding to length x width x height and a wheelbase of 2,815 mm.</li><li>Type: Petrol & Diesel</li><li>Control: Automatic</li><li>Color: Red</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 6,
                    Color = "Black",
                    Name = "Vinfast President",
                    Cover = "vinfast-presedent_xuagri",
                    VIN = "RRYTD41M6BC023612",
                    FN = "00923339934",
                    SalePrice = 10000,
                    Description = "<ul><li>Vehicle name: Vinfast President</li><li>Dimensions: 5,146 mm D x 1,987 mm W x 1,760 mm</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 7,
                    Color = "Red",
                    Name = "Vinfast VF32",
                    Cover = "VinFast-VF32-1-1611305150-5626-1611337603_at7fg1",
                    VIN = "RRYTD41M6BC02401",
                    FN = "00923339POM",
                    SalePrice = 100000,
                    Description = "<ul><li>Vehicle name: Vinfast VF32</li><li>Vinfast VF32 has an overall length of 4,750 mm and a wheelbase of 2,950 mm</li><li>Type: Petrol</li><li>Control: Automatic</li><li>Color: Red</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 8,
                    Color = "Black",
                    Name = "Vinfast VF33",
                    Cover = "8_t3x9hz",
                    VIN = "RRYTD41M6BC023620",
                    FN = "1234567800",
                    SalePrice = 300000,
                    Description = "<ul><li>Vehicle name: Vinfast VF33</li><li>Dimensions: 5,146 mm D x 1,987 mm W x 1,760 mm H</li><li>Type: Both</li><li>Control: Automatic</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 9,
                    Color = "Blue",
                    Name = "Kia Morning",
                    Cover = "kia-morning-phien-ban-si-at_nkdp5y",
                    VIN = "RRYTD41M6BC023616",
                    FN = "12345678912",
                    SalePrice = 120000,
                    Description = "<ul><li>Vehicle name: Kia Morning</li><li>Dimensions: 3.595 mm D x 1.595-1.625 mm R x 1.485-1.500 mm C</li><li>Type: Petrol</li><li>Control: Automatic</li><li>Color: Blue</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 10,
                    Color = "White",
                    Name = "Kia Soluto",
                    Cover = "kia-soluto-phien-ban-14mt-deluxe_ub4k1t",
                    VIN = "RRYTD41M6BC02002",
                    FN = "12345678912",
                    SalePrice = 500000,
                    Description = "<ul><li>Vehicle name: Kia Soluto</li><li>Dimensions: 4.300 mm D x 1.710 mm R x 1.460 mm C</li><li>Type: Both</li><li>Control: Automatic</li><li>Color: White</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 11,
                    Color = "Black",
                    Name = "Kia Cerato",
                    Cover = "Kia-Cerato_m9sktz",
                    VIN = null,
                    FN = null,
                    SalePrice = 450000,
                    Description = "<ul><li>Vehicle name: Kia Cerato</li><li>Dimensions: 4.640 mm D x 1.800 mm R x 1.440 mm C</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
                    VehicleModelId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 12,
                    Color = "Silver",
                    Name = "Toyota Innova",
                    Cover = "Toyota-Innova-_mydoy0",
                    VIN = "RRYTD41M6BC02985",
                    FN = "2339ICP0WWE22",
                    SalePrice = 250000,
                    Description = "<ul><li>Vehicle name: Toyota Innova</li><li>Dimensions: 4.735 mm D x 1.830 mm R x 1.795 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Silver</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 13,
                    Color = "Red",
                    Name = "Toyota Vios",
                    Cover = "toyota-vios_ubmzbw",
                    VIN = "RRUTD41M6BC02985",
                    FN = "2339ICP0WWE32",
                    SalePrice = 300000,
                    Description = "<ul><li>Vehicle name: Toyota Vios</li><li>Dimensions: 4.425 mm D x 1.730 mm R x 1.475 mm C</li><li>Type: Both</li><li>Control: Manual</li><li>Color: Red</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 14,
                    Color = "White",
                    Name = "Toyota Corolla Altis",
                    Cover = "Toyota-Altis_yxyq3t",
                    VIN = "RRYTD41M6BC02199",
                    FN = "0992388AADKCM",
                    SalePrice = 150000,
                    Description = "<ul><li>Vehicle name: Toyota Corolla Altis</li><li>Dimensions: 4.620 mm D x 1.775 mm R x 1.460 mm C</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: White</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 15,
                    Color = "Black",
                    Name = "Toyota Camry",
                    Cover = "toyota-camry-hybrid-2019_dx1no2",
                    VIN = "RRYTD41M6BC02199",
                    FN = "0992388AADKCM",
                    SalePrice = 600000,
                    Description = "<ul><li>Vehicle name: Toyota Camry</li><li>Dimensions: 4.885 mm D x 1.840 mm R x 1.445 mm C</li><li>Type: Both</li><li>Control: Manual</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 16,
                    Color = "Brown",
                    Name = "Lexus LS - Luxury Sedan",
                    Cover = "5b2ce5ed33c3e46cb7a5bcb7ad651b18_eh8p4d",
                    VIN = null,
                    FN = null,
                    SalePrice = 70000,
                    Description = "<ul><li>Vehicle name: Lexus LS - Luxury Sedan</li><li>Dimensions: 5.235  mm D x 1.900  mm R x 1.450 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Brown</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Pending,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 17,
                    Color = "Black",
                    Name = "Lexus ES – Executive Sedan",
                    Cover = "2bf118bf-20191230_043351_lerpnc",
                    VIN = "RRYTD41M6BC02109",
                    FN = "0992388AADBHM",
                    SalePrice = 80000,
                    Description = "<ul><li>Vehicle name: Lexus ES – Executive Sedan</li><li>DRC size: 4,975 x 1,865 x 1,445mm; wheelbase 2870mm; alloy wheels size 235/55 R18.</li><li>Type: Petrol</li><li>Control: Automatic</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 18,
                    Color = "Blue",
                    Name = "Lexus NX - Luxury Crossover",
                    Cover = "2017_lexus_nx_luxury_crossover-HD_caztpr",
                    VIN = "RRYTD41M6BC05000",
                    FN = "0992388AADBIXN",
                    SalePrice = 100000,
                    Description = "<ul><li>Vehicle name: Lexus NX - Luxury Crossover</li><li>The Lexus NX 300 2020 measures 4,630 x 1,845 x 1,645 (mm). The wheelbase of the car reaches 2,660 mm.</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: Blue</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 19,
                    Color = "Gray",
                    Name = "Lexus RX",
                    Cover = "c283f984-20191230_043428_zpytwl",
                    VIN = "IRYTD41M6BC05000",
                    FN = "0122388AADBIXN",
                    SalePrice = 250000,
                    Description = "<ul><li>Vehicle name: Lexus RX</li><li>Dimensions: 4.890 mm D x 1.895 mm R x 1.690 mm C</li><li>Type: Both</li><li>Control: Manual</li><li>Color: Gray</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 20,
                    Color = "White",
                    Name = "Lexus GX",
                    Cover = "8584ba57-20191230_043434_noee0a",
                    VIN = "IRYTD41M6BC05000",
                    FN = "0122388AAOBIXN",
                    SalePrice = 450000,
                    Description = "<ul><li>Vehicle name: Lexus GX</li><li>Dimensions: 4.880 mm D x 1.885 mm R x 1.845 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: White</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Available,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}

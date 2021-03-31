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
                    Description = "The exterior of the Vinfast VFe34 electric SUV is considered neutral, gentle with gentle rounded lines like an MPV. DxRxC overall dimensions are 4,300x 1,793x 1,613 mm, wheelbase 2,611 mm, ground clearance 180mm and unladen weight 1,490 kg.",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Avaible,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 2,
                    Color = "Black, Red, Orange",
                    Name = "VinFast Lux SA2.0",
                    Cover = "car_nahhr2sg-746-vinfast-lux-s2-0-_1__ffeshb,red-sa-1459517f29119_p3cyxb,sa-orange-169_t981vy",
                    VIN = null,
                    FN = null,
                    SalePrice = 60000,
                    Description = "VinFast Lux SA2.0 still retains specific details and Vietnamese soul. Most notably, the daytime LED strip has an independent design with the V graphic that stretches most of the front of the car.",
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
                    Cover = "Kia-Sportage-2017-745158_aj0icj",
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
                    Description = "As a small car in the A segment with competitors such as Kia Morning, Huydai I10, Toyota Wigo ... but VinFast Fadil is equipped with a 1.4L engine block and a CVT gearbox. The strength of the engine outperforming the cars in the same segment makes VinFast Fadil well received and the initial sales of the market are also quite impressive.",
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
                    Description = "In terms of vehicle design, the design language remains the same as the Lux SA2.0 but differs in many details such as the air cavity on the bonnet, the large lattice grille, the pit wind cavity combined with the 4 rear exhaust pipes. .",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Assigned,
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
                    VIN = null,
                    FN = null,
                    SalePrice = 100000,
                    Description = "The car is 4,750 mm long, the wheelbase is 2,950 mm. The car is 190 mm shorter than the Lux SA in the E segment, but the wheelbase is 17 mm shorter.",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 8,
                    Color = "Black",
                    Name = "Vinfast VF33",
                    Cover = "",
                    VIN = "RRYTD41M6BC023620",
                    FN = "1234567800",
                    SalePrice = 300000,
                    Description = "With a length of 5,120 mm, a wheelbase of 3,150 mm, VinFast VF33 is slightly higher than Lux SA (4,940 mm long) and Ford Exlorer (5,037 mm long). Inside the cockpit, the Vietnamese automaker is equipped with a button-shaped gear lever. A 15.4 inch infotainment screen, interior lights.",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
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
                    Description = "Morning has 3 other versions. In these 3 versions, 1 gearbox and 2 Automatic are equipped",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Sold,
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
                    Description = "This is Kia Soluto",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Assigned,
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
                    Description = "Kia Cerato is a line of high-end compact car (compact car) produced by Korea's leading car brand - Kia Motors.",
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
                    Description = "Innova retains the branding elements such as looks, engines and safety features.",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Assigned,
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
                    Description = "Toyota Vios 2021 is the most popular and popular name in the Vietnamese auto market today.",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Sold,
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
                    Description = "This is Toyota Corolla Altis",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Assigned,
                    VehicleModelId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 15,
                    Color = "White",
                    Name = "Toyota Camry",
                    Cover = "toyota-camry-hybrid-2019_dx1no2",
                    VIN = "RRYTD41M6BC02199",
                    FN = "0992388AADKCM",
                    SalePrice = 600000,
                    Description = "This is Toyota Camry",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Avaible,
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
                    Description = "This is Lexus LS - Luxury Sedan",
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
                    Description = "This is Lexus ES – Executive Sedan",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Avaible,
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
                    Description = "This is Lexus NX - Luxury Crossover",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Sold,
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
                    Description = "This is Lexus RX",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Sold,
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
                    Description = "This is Lexus GX",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Avaible,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}

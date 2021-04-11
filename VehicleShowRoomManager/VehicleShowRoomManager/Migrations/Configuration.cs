namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static VehicleShowRoomManager.Models.Bill;
    using static VehicleShowRoomManager.Models.Brand;
    using static VehicleShowRoomManager.Models.Customer;
    using static VehicleShowRoomManager.Models.Employee;
    using static VehicleShowRoomManager.Models.GoodsReceipt;
    using static VehicleShowRoomManager.Models.SaleOrder;
    using static VehicleShowRoomManager.Models.Vehicle;
    using static VehicleShowRoomManager.Models.VehicleModel;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ShowRoomDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Models.ShowRoomDataContext context)
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
                   Description = "Kia Brand",
                   Status = BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 2,
                   Name = "Toyota",
                   Description = "Toyota Brand",
                   Status = BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 3,
                   Name = "Mazda",
                   Description = "Mazda Brand",
                   Status = BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 4,
                   Name = "Lexus",
                   Description = "Lexus Brand",
                   Status = BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 5,
                   Name = "Mercedes",
                   Description = "Mercedes Brand",
                   Status = BrandStatus.Active,
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now
               },
               new Models.Brand()
               {
                   Id = 6,
                   Name = "Honda",
                   Description = "Honda Brand",
                   Status = BrandStatus.Active,
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
                    Status = VehicleModelStatus.Active,
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
                    Status = VehicleModelStatus.Active,
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
                    Status = VehicleModelStatus.Active,
                    Descriptions = "Mazda CX-5 line of sport utility vehicle with high chassis",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 4,
                    BrandId = 4,
                    ModelName = "Lexus LX 570",
                    ModelNumber = "Lexus LX 570",
                    Status = VehicleModelStatus.Active,
                    Descriptions = "This is Lexus LX 570",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 5,
                    BrandId = 5,
                    ModelName = "Mercedes C200",
                    ModelNumber = "Mercedes C200",
                    Status = VehicleModelStatus.Active,
                    Descriptions = "This is Mercedes C200",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.VehicleModel()
                {
                    Id = 6,
                    BrandId = 6,
                    ModelName = "Honda CR-V",
                    ModelNumber = "Honda CR-V",
                    Status = VehicleModelStatus.Active,
                    Descriptions = "This is Honda CR-V",
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
                },
                new Models.ModelImage()
                {
                    Id = 10,
                    Cover = "10.mau-xe-kia-morning-sparkling-silver_csdzjj",
                    Color = "Gray",
                    VehicleModelId = 1,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 11,
                    Cover = "11.innova-bronze-mica_jt8t2e",
                    Color = "Black",
                    VehicleModelId = 2,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 12,
                    Cover = "13.71dZrx4ejbL._UY560__awtouo",
                    Color = "Gray",
                    VehicleModelId = 4,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 13,
                    Cover = "14.xehay-Mercedes-Benz-C200-AMG-Line-191017-7_cyop4h",
                    Color = "Black",
                    VehicleModelId = 5,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Models.ModelImage()
                {
                    Id = 14,
                    Cover = "15.infographic-10-mau-xe-o-to-ban-chay-nhat-thang-1-2019-tai-viet-nam-155746_sb0xmq",
                    Color = "Blue",
                    VehicleModelId = 6,
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
                    VIN = "",
                    FN = "",
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
                    VIN = "",
                    FN = "",
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
                },
                new Models.Vehicle()
                {
                    Id = 10,
                    Color = "Gray",
                    Name = "Kia Morning",
                    Cover = "10.mau-xe-kia-morning-sparkling-silver_csdzjj",
                    VIN = "RRYTD41M6BC2294483",
                    FN = "2339ICP0WWE2882",
                    SalePrice = 30000,
                    Description = "<ul><li>Vehicle name: Kia Morning</li><li>Dimensions: 3.595 mm D x 1.595-1.625 mm R x 1.485-1.500 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Gray</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Used,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 11,
                    Color = "Brown",
                    Name = "Toyota Innova",
                    Cover = "11.innova-bronze-mica_jt8t2e",
                    VIN = "RRYTD41M6BC177985",
                    FN = "009ICP0WWE22",
                    SalePrice = 20000,
                    Description = "<ul><li>Vehicle name: Toyota Innova</li><li>Dimensions: 4.735 mm D x 1.830 mm R x 1.795 mm C</li><li>Type: Diesel</li><li>Control: Automatic</li><li>Color: Brown</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Used,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 12,
                    Color = "Black",
                    Name = "Mazda CX-5",
                    Cover = "9.xe-mau-den-mazda-cx-5-2019-2020-muaxegiatot-com_hytppf",
                    VIN = "RRYTD41M6BC02985",
                    FN = "2339ICP0W22359",
                    SalePrice = 120000,
                    Description = "<ul><li>Vehicle name: Mazda CX-5</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Petrol</li><li>Control: Manual</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Used,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 13,
                    Color = "Gray",
                    Name = "Lexus LX 570",
                    Cover = "9.xe-mau-den-mazda-cx-5-2019-2020-muaxegiatot-com_hytppf",
                    VIN = "",
                    FN = "",
                    SalePrice = 150000,
                    Description = "<ul><li>Vehicle name: Lexus LX 570</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Both</li><li>Control: Manual</li><li>Color: Gray</li></ul>",
                    Type = VehicleType.Both,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Pending,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 14,
                    Color = "Black",
                    Name = "Mercedes C200",
                    Cover = "14.xehay-Mercedes-Benz-C200-AMG-Line-191017-7_cyop4h",
                    VIN = "",
                    FN = "",
                    SalePrice = 70000,
                    Description = "<ul><li>Vehicle name: Mercedes C200</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Diesel</li><li>Control: Manual</li><li>Color: Black</li></ul>",
                    Type = VehicleType.Diesel,
                    Control = VehicleControlType.Manual,
                    Status = VehicleStatus.Pending,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Vehicle()
                {
                    Id = 15,
                    Color = "Blue",
                    Name = "Honda CR-V",
                    Cover = "15.infographic-10-mau-xe-o-to-ban-chay-nhat-thang-1-2019-tai-viet-nam-155746_sb0xmq",
                    VIN = "",
                    FN = "",
                    SalePrice = 80000,
                    Description = "<ul><li>Vehicle name: Honda CR-V</li><li>Dimensions: 4.550 mm D x 1.840 mm R x 1.680 mm C</li><li>Type: Petrol</li><li>Control: Automatic</li><li>Color: Blue</li></ul>",
                    Type = VehicleType.Petrol,
                    Control = VehicleControlType.Automatic,
                    Status = VehicleStatus.Pending,
                    Assets = VehicleAssets.Default,
                    VehicleModelId = 6,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // GoodReceipt seed
            context.GoodsReceipts.AddOrUpdate(x => x.Id,
                new Models.GoodsReceipt()
                {
                    Id = 1,
                    ReceiptPrice = 30000,
                    ReceivedAt = DateTime.ParseExact("2021-01-08 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 5000,
                    VehicleId = 2,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-01-08 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.GoodsReceipt()
                {
                    Id = 2,
                    ReceiptPrice = 30000,
                    ReceivedAt = DateTime.ParseExact("2021-02-15 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 7500,
                    VehicleId = 3,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-02-15 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.GoodsReceipt()
                {
                    Id = 3,
                    ReceiptPrice = 20000,
                    ReceivedAt = DateTime.ParseExact("2021-03-10 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 9000,
                    VehicleId = 4,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-03-10 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.GoodsReceipt()
                {
                    Id = 4,
                    ReceiptPrice = 20000,
                    ReceivedAt = DateTime.ParseExact("2021-03-24 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 10000,
                    VehicleId = 5,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-03-24 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.GoodsReceipt()
                {
                    Id = 5,
                    ReceiptPrice = 20000,
                    ReceivedAt = DateTime.ParseExact("2021-04-01 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 12000,
                    VehicleId = 6,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-04-01 00:00:00", "yyyy-MM-dd HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.GoodsReceipt()
                {
                    Id = 6,
                    ReceiptPrice = 120000,
                    ReceivedAt = DateTime.ParseExact("2021-04-05 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 85000,
                    VehicleId = 8,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-04-05 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.GoodsReceipt()
                {
                    Id = 7,
                    ReceiptPrice = 120000,
                    ReceivedAt = DateTime.ParseExact("2021-04-11 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    PrepaymentMoney = 65000,
                    VehicleId = 9,
                    Status = GoodsReceiptStatus.Prepayment,
                    CreatedAt = DateTime.ParseExact("2021-04-11 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                }
            );

            // Customer seed
            context.Customers.AddOrUpdate(x => x.Id,
                new Models.Customer()
                {
                    Id = 1,
                    Name = "Le Minh Hoang",
                    Phone = "0123456789",
                    Address = "12 Me Tri",
                    Email = "hoang@gmail.com",
                    Status = CustomerStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Customer()
                {
                    Id = 2,
                    Name = "Luu Duc Huy",
                    Phone = "0123883290",
                    Address = "20 Ho Tung Mau",
                    Email = "huy@gmail.com",
                    Status = CustomerStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Customer()
                {
                    Id = 3,
                    Name = "Do Thai Anh",
                    Phone = "0914366644",
                    Address = "10 Cau Giay",
                    Email = "thaianh@gmail.com",
                    Status = CustomerStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Customer()
                {
                    Id = 4,
                    Name = "Hoang Huy Truong",
                    Phone = "0914598775",
                    Address = "77 Nguyen Trai St",
                    Email = "truong@gmail.com",
                    Status = CustomerStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Models.Customer()
                {
                    Id = 5,
                    Name = "Cao Linh",
                    Phone = "0989734455",
                    Address = "34 Cau Giay",
                    Email = "caolinh@gmail.com",
                    Status = CustomerStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // SaleOrder seed
            context.SaleOrders.AddOrUpdate(x => x.Id,
                new Models.SaleOrder()
                {
                    Id = 1,
                    CustomerId = 1,
                    VehicleId = 2,
                    TotalPrice = 30000,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Status = SaleOrderStatus.Pending
                },
                new Models.SaleOrder()
                {
                    Id = 2,
                    CustomerId = 2,
                    VehicleId = 4,
                    TotalPrice = 20000,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Status = SaleOrderStatus.Pending
                },
                new Models.SaleOrder()
                {
                    Id = 3,
                    CustomerId = 3,
                    VehicleId = 5,
                    TotalPrice = 20000,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Status = SaleOrderStatus.Pending
                },
                new Models.SaleOrder()
                {
                    Id = 4,
                    CustomerId = 4,
                    VehicleId = 3,
                    TotalPrice = 30000,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Status = SaleOrderStatus.Pending
                },
                new Models.SaleOrder()
                {
                    Id = 5,
                    CustomerId = 5,
                    VehicleId = 7,
                    TotalPrice = 120000,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Status = SaleOrderStatus.Pending
                }
            );

            // Bill seed
            context.Bills.AddOrUpdate(x => x.Id,
                new Models.Bill()
                {
                    Id = 1,
                    PayedMoney = 50000,
                    SaleOrderId = 1,
                    PayMethod = BillPayMethod.Card,
                    Status = BillStatus.Done,
                    CreatedAt = DateTime.ParseExact("2021-01-03 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.Bill()
                {
                    Id = 2,
                    PayedMoney = 40000,
                    SaleOrderId = 2,
                    PayMethod = BillPayMethod.Direct,
                    Status = BillStatus.Done,
                    CreatedAt = DateTime.ParseExact("2021-01-19 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.Bill()
                {
                    Id = 3,
                    PayedMoney = 30000,
                    SaleOrderId = 3,
                    PayMethod = BillPayMethod.Direct,
                    Status = BillStatus.Done,
                    CreatedAt = DateTime.ParseExact("2021-02-08 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.Bill()
                {
                    Id = 4,
                    PayedMoney = 60000,
                    SaleOrderId = 4,
                    PayMethod = BillPayMethod.Card,
                    Status = BillStatus.Done,
                    CreatedAt = DateTime.ParseExact("2021-03-23 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                },
                new Models.Bill()
                {
                    Id = 5,
                    PayedMoney = 150000,
                    SaleOrderId = 5,
                    PayMethod = BillPayMethod.Card,
                    Status = BillStatus.Done,
                    CreatedAt = DateTime.ParseExact("2021-04-09 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    UpdatedAt = DateTime.Now
                }
            );

            // Employee seed
            context.Employees.AddOrUpdate(x => x.Id,
                new Models.Employee()
                {
                    Id = 1,
                    Name = "Duc Nguyen",
                    Email = "duc@gmail.com",
                    Phone = "0123456789",
                    Address = "Ha Noi",
                    Position = "Dealer",
                    Status = EmployeeStatus.ACTIVE
                },
                new Models.Employee()
                {
                    Id = 2,
                    Name = "Tuan Anh",
                    Email = "tuananh@gmail.com",
                    Phone = "0123456789",
                    Address = "Ha Noi",
                    Position = "Accountant",
                    Status = EmployeeStatus.ACTIVE
                },
                new Models.Employee()
                {
                    Id = 3,
                    Name = "Minh Vu",
                    Email = "minh@gmail.com",
                    Phone = "0914605779",
                    Address = "Ha Noi",
                    Position = "Dealer",
                    Status = EmployeeStatus.ACTIVE
                },
                new Models.Employee()
                {
                    Id = 4,
                    Name = "Trang Nguyen",
                    Email = "trang@gmail.com",
                    Phone = "0912456789",
                    Address = "Ha Noi",
                    Position = "Dealer",
                    Status = EmployeeStatus.ACTIVE
                },
                new Models.Employee()
                {
                    Id = 5,
                    Name = "Thao Le",
                    Email = "thao@gmail.com",
                    Phone = "0973884932",
                    Address = "Ha Noi",
                    Position = "Dealer",
                    Status = EmployeeStatus.ACTIVE
                }
            );
        }
    }
}

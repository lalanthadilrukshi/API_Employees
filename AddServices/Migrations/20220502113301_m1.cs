using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddServices.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_MainCategory_FKCategoryId",
                        column: x => x.FKCategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKProvinceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_FKProvinceId",
                        column: x => x.FKProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKDistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_District_FKDistrictId",
                        column: x => x.FKDistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Village_City_FKCityId",
                        column: x => x.FKCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKVillageId = table.Column<int>(type: "int", nullable: false),
                    FKSubCategoryId = table.Column<int>(type: "int", nullable: false),
                    FKUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rates = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_AspNetUsers_FKUserId",
                        column: x => x.FKUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_SubCategory_FKSubCategoryId",
                        column: x => x.FKSubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_Village_FKVillageId",
                        column: x => x.FKVillageId,
                        principalTable: "Village",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service_Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKServiceId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Image_Service_FKServiceId",
                        column: x => x.FKServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01B168FE-810B-432D-9010-233BA0B380E9", "3bf774ca-480f-4305-8d22-ed307fb66cc4", "Customer", "CUSTOMER" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "4d26659b-83e7-4be1-961f-8b453d1917ea", "Employee", "EMPLOYEE" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "09868c81-faa7-4e3c-981b-c55d86f0e582", "Administrator", "ADMINISTRATOR" },
                    { "2301D884-221A-4E7D-B509-0113DCC043E2", "252ba61c-5a42-4a3a-8b85-8a230e7f2205", "Viewer", "VIEWER" },
                    { "78A7570F-3CE5-48BA-9461-80283ED1D94D", "4602d2f3-a28e-443a-84cb-e8d9be4207f3", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", 0, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ead1eb46-6e0a-4595-9081-502d491e6aee", "Admin@Admin.com", true, "Master", null, "Admin", false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEI2vr2dS0aQYDXiGJZvgL7h4PSmDoV5mCcarev4CCxXAYz21HrVHA3BV3DzPDZ17KQ==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" },
                    { 2, "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "MainCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 22, "Office" },
                    { 21, "Mobile" },
                    { 20, "Plantation and landscape" },
                    { 19, "Labour" },
                    { 18, "Clerical" },
                    { 17, "Care" },
                    { 16, "Community services" },
                    { 14, "Advertising" },
                    { 13, "Video and Photography" },
                    { 15, "Events" },
                    { 11, "Transport" },
                    { 2, "Medical" },
                    { 3, "Hygien" },
                    { 5, "Sports" },
                    { 6, "Entertainment-music/performing-arts" },
                    { 4, "Education and Training" },
                    { 8, "Construction and house repairs" },
                    { 9, "Automobile" },
                    { 10, "Legal" },
                    { 7, "Mechanical" },
                    { 12, "Media" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Western" },
                    { 2, "North Western" },
                    { 3, "Northern" }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Location", "Name", "Position", "Salary" },
                values: new object[,]
                {
                    { 2, null, "Jana McLeaf", "Software developer", 0f },
                    { 1, null, "Sam Raiden", "Software developer", 0f },
                    { 3, null, "Kane Miller", "Administrator", 0f }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2301D884-221A-4E7D-B509-0113DCC043E1", "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "FKProvinceId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Colombo" },
                    { 3, 3, "Jafna" },
                    { 2, 1, "Gampaha" }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "FKCategoryId", "Name" },
                values: new object[,]
                {
                    { 2201, 22, "Office supplies" },
                    { 1103, 11, "Movers" },
                    { 1201, 12, "News reporting" },
                    { 1301, 13, "Photography" },
                    { 1302, 13, "Video" },
                    { 1501, 15, "Weddings" },
                    { 1502, 15, "Funerals" },
                    { 1503, 15, "Catering" },
                    { 1701, 17, "Home nursing" },
                    { 1702, 17, "ChiId care and baby sitting" },
                    { 1704, 17, "Pet care" },
                    { 1801, 18, "Type setting" },
                    { 1802, 18, "Translations" },
                    { 1901, 19, "Labour work" },
                    { 2001, 20, "Gardening services" },
                    { 2002, 20, "Tree felling" },
                    { 2101, 21, "Mobile repairs" },
                    { 1102, 11, "Drivers" },
                    { 1703, 17, "Aged care" },
                    { 1101, 11, "Vehicles for hire" },
                    { 902, 9, "Car detailing" },
                    { 102, 1, "Computer repairs" },
                    { 201, 2, "Doctor" },
                    { 202, 2, "Doctor-Telemedicine" },
                    { 301, 3, "Cleaning and genital services" },
                    { 302, 3, "Environment cleaning" },
                    { 401, 4, "Private tutor" },
                    { 402, 4, "Speach and hearing training" },
                    { 501, 5, "Training" },
                    { 502, 5, "Clubs" },
                    { 1001, 10, "Attorney at law" },
                    { 601, 6, "Music bands" },
                    { 603, 6, "Dance troupe" },
                    { 604, 6, "Drama and film" },
                    { 701, 7, "Mobile engine repairs" },
                    { 702, 7, "Machine repairs" },
                    { 801, 8, "Masonry" },
                    { 802, 8, "Wood work" }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "FKCategoryId", "Name" },
                values: new object[,]
                {
                    { 803, 8, "Electrical and wiring" },
                    { 804, 8, "Plumbing" },
                    { 901, 9, "Car wash" },
                    { 602, 6, "DJ" },
                    { 101, 1, "Software engineering" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "FKDistrictId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Colombo" },
                    { 25, 2, "Kelaniya" },
                    { 24, 2, "Dompe" },
                    { 23, 2, "Divulapitiya" },
                    { 22, 2, "Biyagama" },
                    { 21, 2, "Aththanagalla" },
                    { 20, 2, "Minuwangoda" },
                    { 19, 2, "Peliyagoda" },
                    { 18, 2, "Wattala-Maboal" },
                    { 17, 2, "Jaela" },
                    { 16, 2, "Katana-Seduwa" },
                    { 15, 2, "Negombo" },
                    { 26, 2, "Mahara" },
                    { 14, 2, "Gampaha" },
                    { 12, 1, "Seethawakapura" },
                    { 11, 1, "Kotikawatta Mulleriyawa" },
                    { 10, 1, "Boralesgamuwa" },
                    { 9, 1, "Kesbewa" },
                    { 8, 1, "Maharagama" },
                    { 7, 1, "Seethawaka" },
                    { 6, 1, "Kolonnawa" },
                    { 5, 1, "Sri Jayawardenapura Kotte" },
                    { 4, 1, "Moratuwa" },
                    { 3, 1, "Kaduwela" },
                    { 2, 1, "Dehiwala" },
                    { 13, 1, "Homagama" },
                    { 27, 2, "Meerigama" }
                });

            migrationBuilder.InsertData(
                table: "Village",
                columns: new[] { "Id", "FKCityId", "Name" },
                values: new object[,]
                {
                    { 101, 1, "Pettah" },
                    { 1402, 14, "Udugampola" },
                    { 1501, 15, "Negombo" },
                    { 1502, 15, "Sarukkuwa" },
                    { 1601, 16, "Katana-Seduwa" },
                    { 1701, 17, "Jaela" },
                    { 1801, 18, "Maboal" },
                    { 1802, 18, "Wattala" },
                    { 1803, 18, "Kandana" },
                    { 1901, 19, "Peliyagoda" },
                    { 2001, 20, "Minuwangoda" },
                    { 2101, 21, "Nittambuwa" },
                    { 2102, 21, "Aththanagalla" },
                    { 2103, 21, "Thihariya" },
                    { 2201, 22, "Biyagama" },
                    { 2301, 23, "Divulapitiya" },
                    { 2401, 24, "Dompe" },
                    { 2402, 24, "Kirindiwela" },
                    { 2501, 25, "Kelaniya" },
                    { 2502, 25, "Kelani Mulla" },
                    { 2601, 26, "Mahara" },
                    { 2602, 26, "Kadawatha" },
                    { 1401, 14, "Gampaha" },
                    { 1303, 13, "Kiriwanthuduwa" },
                    { 1302, 13, "Pitipana" },
                    { 1301, 13, "Homagama" },
                    { 102, 1, "Modera" },
                    { 103, 1, "Kotahena" },
                    { 201, 2, "Dehiwala" },
                    { 202, 2, "Mount-Lavinia" },
                    { 203, 2, "Pepiliyana" },
                    { 301, 3, "Malabe" },
                    { 302, 3, "Athurugiriya" },
                    { 401, 4, "Moratuwa" },
                    { 402, 4, "Lunawa" },
                    { 601, 6, "Kolonnawa" },
                    { 2603, 26, "Balummahara" },
                    { 602, 6, "Wellampitiya" },
                    { 801, 8, "Maharagama" },
                    { 802, 8, "Kottawa" },
                    { 901, 9, "Kesbewa" },
                    { 902, 9, "Piliyandala" }
                });

            migrationBuilder.InsertData(
                table: "Village",
                columns: new[] { "Id", "FKCityId", "Name" },
                values: new object[,]
                {
                    { 1001, 10, "Boralesgamuwa" },
                    { 1002, 10, "Delkanda" },
                    { 1101, 11, "Kotikawatta" },
                    { 1102, 11, "Mulleriyawa" },
                    { 1103, 11, "Himbutana" },
                    { 1201, 12, "Seethawakapura" },
                    { 701, 7, "Seethawaka" },
                    { 2701, 27, "Meerigama" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_FKDistrictId",
                table: "City",
                column: "FKDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_District_FKProvinceId",
                table: "District",
                column: "FKProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_FKSubCategoryId",
                table: "Service",
                column: "FKSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_FKUserId",
                table: "Service",
                column: "FKUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_FKVillageId",
                table: "Service",
                column: "FKVillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Image_FKServiceId",
                table: "Service_Image",
                column: "FKServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_FKCategoryId",
                table: "SubCategory",
                column: "FKCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Village_FKCityId",
                table: "Village",
                column: "FKCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Service_Image");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropTable(
                name: "MainCategory");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}

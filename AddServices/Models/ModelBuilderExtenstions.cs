using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddServices.Models;
using AddServices.Configuration;

namespace AddServices.Models
{
    public static class ModelBuilderExtenstions
    {
        public const int SubCategoryIdSoftwareEngineer = 101;
             public const int VillageIdPettah= 101;
        public static void Seed(this ModelBuilder modelBuiIder)
        {
            modelBuiIder.Entity<Province>().HasData(
            new Province { Id = 1, Name = "Western" },
            new Province { Id = 2, Name = "North Western" },
            new Province { Id = 3, Name = "Northern" }
        ) ;
            modelBuiIder.Entity<District>().HasData(
           new District { FKProvinceId=1, Id = 1, Name = "Colombo" },
            new District { FKProvinceId = 1, Id = 2, Name = "Gampaha" },
           new District { FKProvinceId = 3, Id = 3, Name = "Jafna" }
       );

            modelBuiIder.Entity<City>().HasData(


                 new City { FKDistrictId = 1, Id = 1, Name = "Colombo" },
                        new City { FKDistrictId = 1, Id = 2, Name = "Dehiwala" },
                       new City { FKDistrictId = 1, Id = 3, Name = "Kaduwela" },
                       new City { FKDistrictId = 1, Id = 4, Name = "Moratuwa" },
                        new City { FKDistrictId = 1, Id = 5, Name = "Sri Jayawardenapura Kotte" },
                       new City { FKDistrictId = 1, Id = 6, Name = "Kolonnawa" },
                        new City { FKDistrictId = 1, Id = 7, Name = "Seethawaka" },
                        new City { FKDistrictId = 1, Id = 8, Name = "Maharagama" },
                       new City { FKDistrictId = 1, Id = 9, Name = "Kesbewa" },
                       new City { FKDistrictId = 1, Id = 10, Name = "Boralesgamuwa" },
                        new City { FKDistrictId = 1, Id = 11, Name = "Kotikawatta Mulleriyawa" },
                       new City { FKDistrictId = 1, Id = 12, Name = "Seethawakapura" },
                       new City { FKDistrictId = 1, Id = 13, Name = "Homagama" },

                        new City { FKDistrictId = 2, Id = 14, Name = "Gampaha" },
                        new City { FKDistrictId = 2, Id = 15, Name = "Negombo" },
                       new City { FKDistrictId = 2, Id = 16, Name = "Katana-Seduwa" },
                       new City { FKDistrictId = 2, Id = 17, Name = "Jaela" },
                        new City { FKDistrictId = 2, Id = 18, Name = "Wattala-Maboal" },
                       new City { FKDistrictId = 2, Id = 19, Name = "Peliyagoda" },
                        new City { FKDistrictId = 2, Id = 20, Name = "Minuwangoda" },
                        new City { FKDistrictId = 2, Id = 21, Name = "Aththanagalla" },
                       new City { FKDistrictId = 2, Id = 22, Name = "Biyagama" },
                       new City { FKDistrictId = 2, Id = 23, Name = "Divulapitiya" },
                        new City { FKDistrictId = 2, Id = 24, Name = "Dompe" },
                         new City { FKDistrictId = 2, Id = 25, Name = "Kelaniya" },
                        new City { FKDistrictId = 2, Id = 26, Name = "Mahara" },
                       new City { FKDistrictId = 2, Id = 27, Name = "Meerigama" }

                       

                   );

            modelBuiIder.Entity<Village>().HasData(
                 // suburbs of Colombo  FKCityId = 1

                 //### if Id is not give the following error messaged is sent from the PackageManagerConsole when adding a migration
                 //### The seed entity for entity type 'Village' cannot be added because a non-zero value is required for property 'Id'. Consider providing a negative value to avoid collisions with non-seed data.



                 new Village { FKCityId = 1, Id = VillageIdPettah, Name = "Pettah" },
                  new Village { FKCityId = 1, Id = 102, Name = "Modera" },
                   new Village { FKCityId = 1, Id = 103, Name = "Kotahena" },

                        // suburbs of Colombo  FKCityId = 2 , Dehiwela
                        new Village { FKCityId = 2, Id = 201, Name = "Dehiwala" },
                        new Village { FKCityId = 2, Id = 202, Name = "Mount-Lavinia" },
                        new Village { FKCityId = 2, Id = 203, Name = "Pepiliyana" },

                       new Village { FKCityId = 3, Id = 301, Name = "Malabe" },
                       new Village { FKCityId = 3, Id = 302, Name = "Athurugiriya" },

                       new Village { FKCityId = 4, Id = 401, Name = "Moratuwa" },
                        new Village { FKCityId = 4, Id = 402, Name = "Lunawa" },

                       // new Village { FKCityId = 5, Id = 501, Name = "Sri Jayawardenapura Kotte" },
                       new Village { FKCityId = 6, Id = 601, Name = "Kolonnawa" },
                        new Village { FKCityId = 6, Id = 602, Name = "Wellampitiya" },

                        new Village { FKCityId = 7, Id = 701, Name = "Seethawaka" },
                        new Village { FKCityId = 8, Id = 801, Name = "Maharagama" },
                        new Village { FKCityId = 8, Id = 802, Name = "Kottawa" },

                       new Village { FKCityId = 9, Id = 901, Name = "Kesbewa" },
                       new Village { FKCityId = 9, Id = 902, Name = "Piliyandala" },

                       new Village { FKCityId = 10, Id = 1001, Name = "Boralesgamuwa" },
                       new Village { FKCityId = 10, Id = 1002, Name = "Delkanda" },

                        new Village { FKCityId = 11, Id = 1101, Name = "Kotikawatta" },
                        new Village { FKCityId = 11, Id = 1102, Name = "Mulleriyawa" },
                        new Village { FKCityId = 11, Id = 1103, Name = "Himbutana" },


                       new Village { FKCityId = 12, Id = 1201, Name = "Seethawakapura" },
                       new Village { FKCityId = 13, Id = 1301, Name = "Homagama" },
                       new Village { FKCityId = 13, Id = 1302, Name = "Pitipana" },
                       new Village { FKCityId = 13, Id = 1303, Name = "Kiriwanthuduwa" },


                        new Village { FKCityId = 14, Id = 1401, Name = "Gampaha" },
                        new Village { FKCityId = 14, Id = 1402, Name = "Udugampola" },

                        new Village { FKCityId = 15, Id = 1501, Name = "Negombo" },
                        new Village { FKCityId = 15, Id = 1502, Name = "Sarukkuwa" },

                       new Village { FKCityId = 16, Id = 1601, Name = "Katana-Seduwa" },
                       new Village { FKCityId = 17, Id = 1701, Name = "Jaela" },
                        new Village { FKCityId = 18, Id = 1801, Name = "Maboal" },
                         new Village { FKCityId = 18, Id = 1802, Name = "Wattala" },
                         new Village { FKCityId = 18, Id = 1803, Name = "Kandana" },

                       new Village { FKCityId = 19, Id = 1901, Name = "Peliyagoda" },
                        new Village{ FKCityId = 20, Id = 2001, Name = "Minuwangoda" },

                        new Village { FKCityId = 21, Id = 2101, Name = "Nittambuwa" },
                        new Village { FKCityId = 21, Id = 2102, Name = "Aththanagalla" },
                        new Village { FKCityId = 21, Id = 2103, Name = "Thihariya" },

                       new Village { FKCityId = 22, Id = 2201, Name = "Biyagama" },
                       new Village { FKCityId = 23, Id = 2301, Name = "Divulapitiya" },
                        new Village { FKCityId = 24, Id = 2401, Name = "Dompe" },
                        new Village { FKCityId = 24, Id = 2402, Name = "Kirindiwela" },

                         new Village { FKCityId = 25, Id = 2501, Name = "Kelaniya" },
                         new Village { FKCityId = 25, Id = 2502, Name = "Kelani Mulla" },

                        new Village { FKCityId = 26, Id = 2601, Name = "Mahara" },
                         new Village { FKCityId = 26, Id = 2602, Name = "Kadawatha" },
                         new Village { FKCityId = 26, Id = 2603, Name = "Balummahara" },

                       new Village { FKCityId = 27, Id = 2701, Name = "Meerigama" }


                     
                  );

            modelBuiIder.Entity<MainCategory>().HasData(
                    new MainCategory {  Id = 1, Name = "IT" },
                     new MainCategory { Id = 2, Name = "Medical" },
                     new MainCategory { Id = 3, Name = "Hygien" },
                     new MainCategory { Id = 4, Name = "Education and Training" },
                     new MainCategory { Id = 5, Name = "Sports" },
                     new MainCategory { Id = 6, Name = "Entertainment-music/performing-arts" },
                     new MainCategory { Id = 7, Name = "Mechanical" },
                     new MainCategory { Id = 8, Name = "Construction and house repairs" },
                     new MainCategory { Id = 9, Name = "Automobile" },
                     new MainCategory { Id = 10, Name = "Legal" },
                     new MainCategory { Id = 11, Name = "Transport" },
                     new MainCategory { Id = 12, Name = "Media" },
                     new MainCategory { Id = 13, Name = "Video and Photography" },
                     new MainCategory { Id = 14, Name = "Advertising" },
                     new MainCategory { Id = 15, Name = "Events" },
                     new MainCategory { Id = 16, Name = "Community services" },
                    new MainCategory {  Id = 17, Name = "Care" },
                    new MainCategory { Id = 18, Name = "Clerical" },
                    new MainCategory { Id = 19, Name = "Labour" },
                    new MainCategory { Id = 20, Name = "Plantation and landscape" },
                    new MainCategory { Id = 21, Name = "Mobile" },
                    new MainCategory { Id = 22, Name = "Office" }
                );
            modelBuiIder.Entity<SubCategory>().HasData(
                    // new SubCategory { FKCategoryId=1, Id = 1, Name = "Software Engineer" },
                    //  new SubCategory { FKCategoryId=1,Id = 2, Name = "Computer Repairs" },
                    // new SubCategory { FKCategoryId=2, Id = 3, Name = "Doctor" }
                    //### if Id is not give the following error messaged is sent from the PackageManagerConsole when adding a migration
                   //### The seed entity for entity type 'SubCategory' cannot be added because a non - zero value is required for property 'Id'.Consider providing a negative value to avoid collisions with non - seed data.
  

                      new SubCategory { FKCategoryId = 1, Id = SubCategoryIdSoftwareEngineer, Name = "Software engineering" },
                    new SubCategory { FKCategoryId = 1, Id = 102, Name = "Computer repairs" },

                     new SubCategory { FKCategoryId = 2, Id = 201, Name = "Doctor" },
                     new SubCategory { FKCategoryId = 2, Id = 202, Name = "Doctor-Telemedicine" },
                                        
                     new SubCategory { FKCategoryId = 3, Id = 301, Name = "Cleaning and genital services" },
                     new SubCategory { FKCategoryId = 3, Id = 302, Name = "Environment cleaning" },

                     new SubCategory { FKCategoryId = 4, Id = 401, Name = "Private tutor" },
                      new SubCategory { FKCategoryId = 4, Id = 402, Name = "Speach and hearing training" },
                     
                     new SubCategory { FKCategoryId = 5, Id = 501, Name = "Training" },
                      new SubCategory { FKCategoryId = 5, Id = 502, Name = "Clubs" },

                     new SubCategory { FKCategoryId = 6, Id = 601, Name = "Music bands" },
                      new SubCategory { FKCategoryId = 6, Id = 602, Name = "DJ" },
                       new SubCategory { FKCategoryId = 6, Id = 603, Name = "Dance troupe" },
                        new SubCategory { FKCategoryId = 6, Id = 604, Name = "Drama and film" },


                     new SubCategory { FKCategoryId = 7, Id = 701, Name = "Mobile engine repairs" },
                      new SubCategory { FKCategoryId = 7, Id = 702, Name = "Machine repairs" },
                      
                     new SubCategory { FKCategoryId = 8, Id = 801, Name = "Masonry" },
                        new SubCategory { FKCategoryId = 8, Id = 802, Name = "Wood work" },
                           new SubCategory { FKCategoryId = 8, Id = 803, Name = "Electrical and wiring" },
                              new SubCategory { FKCategoryId = 8, Id = 804, Name = "Plumbing" },

                     new SubCategory { FKCategoryId = 9, Id = 901, Name = "Car wash" },
                        new SubCategory { FKCategoryId = 9, Id = 902, Name = "Car detailing" },

                     new SubCategory { FKCategoryId = 10, Id = 1001, Name = "Attorney at law" },

                     new SubCategory { FKCategoryId = 11, Id = 1101, Name = "Vehicles for hire" },
                     new SubCategory { FKCategoryId = 11, Id = 1102, Name = "Drivers" },
                     new SubCategory { FKCategoryId = 11, Id = 1103, Name = "Movers" },


                     new SubCategory { FKCategoryId = 12, Id = 1201, Name = "News reporting" },
                     

                     new SubCategory { FKCategoryId = 13, Id = 1301, Name = "Photography" },
                     new SubCategory { FKCategoryId = 13, Id = 1302, Name = "Video" },

                     // new SubCategory { FKCategoryId = 14, Id = 1401,  Name = "Advertising" },
                     new SubCategory { FKCategoryId = 15, Id = 1501, Name = "Weddings" },
                      new SubCategory { FKCategoryId = 15, Id = 1502, Name = "Funerals" },
                       new SubCategory { FKCategoryId = 15, Id = 1503, Name = "Catering" },

                    //new SubCategory { FKCategoryId = 16, Id = 1,  Name = "Community services" },
                    new SubCategory { FKCategoryId = 17, Id = 1701, Name = "Home nursing" },
                    new SubCategory { FKCategoryId = 17, Id = 1702, Name = "ChiId care and baby sitting" },
                    new SubCategory { FKCategoryId = 17, Id = 1703, Name = "Aged care" },
                    new SubCategory { FKCategoryId = 17, Id = 1704, Name = "Pet care" },

                    new SubCategory { FKCategoryId = 18, Id = 1801, Name = "Type setting" },
                    new SubCategory { FKCategoryId = 18, Id = 1802, Name = "Translations" }, 

                    new SubCategory { FKCategoryId = 19, Id = 1901, Name = "Labour work" },
                    new SubCategory { FKCategoryId = 20, Id = 2001, Name = "Gardening services" },
                    new SubCategory { FKCategoryId = 20, Id = 2002, Name = "Tree felling" },
                    new SubCategory { FKCategoryId = 21, Id = 2101, Name = "Mobile repairs" },
                    new SubCategory { FKCategoryId = 22, Id = 2201, Name = "Office supplies" }

                   

               );
            modelBuiIder.ApplyConfiguration(new CompanyConfiguration());
            modelBuiIder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuiIder.ApplyConfiguration(new RoleConfiguration());

            //If you have alot of data configurations you can use this (works from ASP.Net core 2.2):

            //This will pick up all configurations that are defined in the assembly
           // modelBuiIder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Instead of this:
           // modelBuiIder.ApplyConfiguration(new RoleConfiguration());
            modelBuiIder.ApplyConfiguration(new AdminConfiguration());
            modelBuiIder.ApplyConfiguration(new UsersWithRolesConfig());


            /*   modelBuiIder.Entity<Service>().HasData(
                    // new Service { FKVillageId = 1, FKSubCategoryId = 1, Id = 1, Name = "Dilrukshi", BirthDate = new DateTime(1973, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), RegisterDate = DateTime.Today, LastUpdateDate = DateTime.Today });
               new Service { FKVillageId = 1, FKSubCategoryId = 1, Id = 1, Name = "Dilrukshi",  RegisterDate = DateTime.Today, LastUpdateDate = DateTime.Today });*/
        }
    }
}

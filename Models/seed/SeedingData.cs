using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Models;

// dotnet ef dbcontext scaffold 
// "data source=DESKTOP-3550K4L\HARMONY;database=rfid;user id=sa; password=123" 
// Microsoft.EntityFrameworkCore.SqlServer 
// -o Model 
// -c "RfidContext"

// dotnet add package Bogus
namespace seed
{
    public static class SeedingData
    {
        public static int i = 100;
        public static string lang = "fr";
        public static ModelBuilder Profils(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profil>().HasData(new Profil[]{
                new Profil {Id = 1, Label = "مدير"},
                new Profil {Id = 2, Label = "مشرف"},
                new Profil {Id = 3, Label = "لجنة الوطنية"},
                new Profil {Id = 4, Label = "لجنة التتبع"},
                new Profil {Id = 5, Label = "المخاطب الرئيسي"},
                // new Profil {Id = 5, Label = "مالك"},
            });

            return modelBuilder;
        }

         
        public static ModelBuilder Permissions(this ModelBuilder modelBuilder)
        {
            string Consultation = "Consultation";
            string Modification = "Modification";
            int id = 1;
            var route = new[] { "mesure-executif", "mesure-region", "mesure-programme"
            , "suivi", "rapport-litteraire", "rapport-qualitative", "commission", "suivi-indicateur"};

            var data = new List<Permission>() {
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[0], RouteScreenAr = route[0]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[1], RouteScreenAr = route[1]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[2], RouteScreenAr = route[2]},
                new Permission {Id = id++, IdProfil = 5, Action = Modification, RouteScreen = route[3], RouteScreenAr = route[3]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[4], RouteScreenAr = route[4]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[5], RouteScreenAr = route[5]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[7], RouteScreenAr = route[5]},

                new Permission {Id = id++, IdProfil = 3, Action = Modification, RouteScreen = route[6], RouteScreenAr = route[6]},
                new Permission {Id = id++, IdProfil = 4, Action = Modification, RouteScreen = route[6], RouteScreenAr = route[6]},

                // new Permission {Id = id++, IdProfil = 2, Action = Modification, RouteScreen = route[6], RouteScreenAr = route[6]},
                
            };

            foreach (var r in route)
            {
                data.Add(new Permission {Id = id++, IdProfil = 2, Action = Modification, RouteScreen = r, RouteScreenAr = r});
            }

            modelBuilder.Entity<Permission>().HasData(data);

            return modelBuilder;
        }

        public static ModelBuilder Organismes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisme>().HasData(new Organisme[]{
                new Organisme {Id = 1, Type = 1, Label = "وزارة الدولة المكلفة بحقوق الإنسان"},
                new Organisme {Id = 2, Type = 1, Label = "وزارة العدل"},
                new Organisme {Id = 3, Type = 1, Label = "المجلس الأعلى للسلطة القضائية "},
                new Organisme {Id = 4, Type = 1, Label = "المجلس الوطني لحقوق الإنسان"},
                new Organisme {Id = 5, Type = 3, Label = "الهيئات السياسية "},
                new Organisme {Id = 6, Type = 3, Label = "جمعيات المجتمع المدني"},
                new Organisme {Id = 7, Type = 1, Label = "وزارة الداخلية"},
                new Organisme {Id = 8, Type = 2, Label = "الجمعيات الترابية"},
            });

            return modelBuilder;
        }

        public static ModelBuilder Users(this ModelBuilder modelBuilder)
        {
            int id = 1;

            // var faker = new Faker<User>(SeedingData.lang)
            //     .CustomInstantiator(f => new User { Id = id++ })
            //     .RuleFor(o => o.Nom, f => f.Name.FirstName())
            //     .RuleFor(o => o.Prenom, f => f.Name.LastName())
            //     .RuleFor(o => o.Email, (f, u) => f.Internet.Email($"{u.Nom}{f.UniqueIndex}", u.Prenom))
            //     .RuleFor(o => o.Password, f => f.Internet.Password(6))
            //     .RuleFor(o => o.Adresse, f => f.Address.FullAddress())
            //     .RuleFor(o => o.Tel, f => f.Phone.PhoneNumber("(+212)6 ## ##-##-##"))
            //     .RuleFor(o => o.Fix, f => f.Phone.PhoneNumber("(+212)5 ## ##-##-##"))
            //     .RuleFor(o => o.Username, (f, u) => f.Internet.UserName(u.Nom, u.Prenom))
            //     .RuleFor(o => o.IdOrganisme, f => f.Random.Number(1, 3))
            //     .RuleFor(o => o.IdProfil, f => f.Random.Number(2, 4));
            // f.Company.CompanyName()

            // var users = faker.Generate(SeedingData.i);
            var users = new List<User>();
            users.Add(new User
            {
                Id = id++,
                Nom = "mourabit",
                Prenom = "mohamed",
                Email = "mourabit@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "mourabit",
                Password = "123",
                Actif = true,
                IdOrganisme = 1,
                IdProfil = 1
            });
            users.Add(new User
            {
                Id = id++,
                Nom = "mehdi",
                Prenom = "mehdi",
                Email = "mehdi@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "mehdi",
                Password = "123",
                Actif = true,
                IdOrganisme = 8,
                IdProfil = 2
            });

            users.Add(new User
            {
                Id = id++,
                Nom = "ahmed",
                Prenom = "ahmed",
                Email = "ahmed@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "ahmed",
                Password = "123",
                Actif = true,
                IdOrganisme = 5,
                IdProfil = 4
            });
            users.Add(new User
            {
                Id = id++,
                Nom = "soufiane",
                Prenom = "soufiane",
                Email = "soufiane@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "soufiane",
                Password = "123",
                Actif = true,
                IdOrganisme = 7,
                IdProfil = 3
            });
            

             for (int i = 1; i <= 8; i++)
             {
                var u = new User
                {
                Id = id++,
                Nom = $"fakri-{id-1}",
                Prenom = "mohamed",
                Email = $"fakri-{id-1}@angular.io",
                Adresse = "taza",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = $"fakri-{id-1}",
                Password = "123",
                Actif = true,
                IdOrganisme = i,
                IdProfil = 5
                };

                users.Add(u);
             }

            modelBuilder.Entity<User>().HasData(users);

            return modelBuilder;
        }



        public static ModelBuilder Cycles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cycle>().HasData(new List<Cycle>() {
                new Cycle {Id = 1, Label = "2018 - 2021"},
                new Cycle {Id = 2, Label = "2022 - 2025"},
                new Cycle {Id = 3, Label = "2026 - 2030"},
                new Cycle {Id = 4, Label = "2030 - 2035"},
            });

            return modelBuilder;
        }

        public static ModelBuilder Natures(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nature>().HasData(new List<Nature>() {
                new Nature {Id = 1, Label = "الجانب التشريعي والمؤسساتي"},
                new Nature {Id = 2, Label = "التواصل والتحسيس"},
                new Nature {Id = 3, Label = "تقوية القدرات"},
            });

            return modelBuilder;
        }

        static List<Axe> axes = new List<Axe>();


        public static ModelBuilder Axes(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new[]
            {
                "الديمقراطية والحكامة",
                "الحقــوق الاقتصاديــة والاجتماعيــة والثقافيــة والبيئيــة",
                "حماية الحقوق الفئوية والنهوض بها",
                "الإطار القانوني والمؤسساتي",
             };
            var faker = new Faker<Axe>(SeedingData.lang)
                .CustomInstantiator(f => new Axe { Id = id++ })
                .RuleFor(o => o.Label, f => list[id - 2]);
            SeedingData.axes = faker.Generate(4);
            modelBuilder.Entity<Axe>().HasData(axes);

            return modelBuilder;
        }

        public static ModelBuilder Commissions(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var faker = new Faker<Commission>(SeedingData.lang)
                .CustomInstantiator(f => new Commission { Id = id++ })
                .RuleFor(o => o.Type, f => $"اللجنة رقم {id - 1}")
                .RuleFor(o => o.Pv, f => $"محضر رقم {id - 1}")
                .RuleFor(o => o.DateEvenement, f => f.Date.Past())
                ;

            modelBuilder.Entity<Commission>().HasData(faker.Generate(20));

            return modelBuilder;
        }

        public static ModelBuilder MembreCommissions(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var numberList = Enumerable.Range(1, 20).ToList();
            var faker = new Faker<MembreCommission>(SeedingData.lang)
                .CustomInstantiator(f => new MembreCommission { Id = id++ })
                .RuleFor(o => o.NomComplete, f => f.Name.FullName())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.IdCommission, f => numberList[id - 2])
                ;

            modelBuilder.Entity<MembreCommission>().HasData(faker.Generate(20));

            return modelBuilder;
        }

        public static ModelBuilder SousAxes(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new List<SousAxe>();
            list.Add(new SousAxe { Id = 0, Label = "المشاركة السياسية ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = "المساواة والمناصفة وتكافؤ الفرص ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = " الحكامة الترابية ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = "الحكامة الأمنية ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = " مكافحة الإفلات من العقاب", IdAxe = 1 });

            list.Add(new SousAxe { Id = 0, Label = " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = "الحقوق الثقافية ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " الولوج إلى الخدمات الصحية ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " الشغل وتكريس المساواة ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " السياسة السكنية ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = "السياسة البيئية المندمجة ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " المقاولة وحقوق الإنسان ", IdAxe = 2 });

            list.Add(new SousAxe { Id = 0, Label = " الأبعاد المؤسساتية والتشريعية ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = " حقوق الطفل ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = "حقوق الشباب ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = " حقوق الأشخاص في وضعية إعاقة ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = " حقوق الأشخاص المسنين ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = "حقوق المهاجرين واللاجئين ", IdAxe = 3 });

            list.Add(new SousAxe { Id = 0, Label = " الحماية القانونية والقضائية لحقوق الإنسان ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = " الحماية القانونية والمؤسساتية لحقوق المرأة ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = "حريات التعبير والإعلام والصحافة والحق في المعلومة ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = "حماية التراث الثقافي ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = " حفظ الأرشيف وصيانته ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = "الحقوق والحريات والآليات المؤسساتية ", IdAxe = 4 });

            var idAxe = 0;
            var faker = new Faker<SousAxe>(SeedingData.lang)
                .CustomInstantiator(f => new SousAxe { Id = id++ })
                .RuleFor(o => o.Label, (f, o) =>
                {
                    var sa = list[id -2];
                    idAxe = sa.IdAxe;
                    return sa.Label;
                })
                .RuleFor(o => o.IdAxe, f => idAxe)
                ;
            modelBuilder.Entity<SousAxe>().HasData(faker.Generate(26));

            return modelBuilder;
        }

        public static ModelBuilder Mesures(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new[]
            {
                " إرتفاع نسبة التسجيل والتصويت",
                "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ",
                "إرتفاع نسب التمثيلية",
                "النشر في الجريدة الرسمية",
                "تنصيب رئيس واعضاء الهيئة ",
                "عدد عمليات التشاور العمومي",
             };
            var faker = new Faker<Mesure>(SeedingData.lang)
                .CustomInstantiator(f => new Mesure { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 1} : تدابير عشوائية لغايات تجريبية فقط")
                .RuleFor(o => o.Code, f => "Code : {id - 1}")
                .RuleFor(o => o.IdType, f => f.Random.Number(1, 3))
                .RuleFor(o => o.IdResponsable, f => f.Random.Number(5, 12))
                .RuleFor(o => o.IdAxe, f => f.Random.Number(1, 4))
                .RuleFor(o => o.IdSousAxe, f => f.Random.Number(1, 26))
                .RuleFor(o => o.IdCycle, f => f.Random.Number(1, 3))
                .RuleFor(o => o.IdNature, f => f.Random.Number(1, 3))
                .RuleFor(o => o.ResultatsAttendu, f => $"بعد النتائج المرتقبة : {id - 1}")
                .RuleFor(o => o.ObjectifGlobal, f => $"بعد الأهداف العامة  : {id - 1}")
                .RuleFor(o => o.ObjectifSpeciaux, f => $"بعد الأهداف الخاصة : {id - 1}")
                // .RuleFor(o => o.IdMesure, f => null)
                ;

            modelBuilder.Entity<Mesure>().HasData(faker.Generate(50));

            return modelBuilder;
        }

        public static ModelBuilder Activites(this ModelBuilder modelBuilder)
        {
            var id = 1;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var numberList = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Activite>(SeedingData.lang)
                .CustomInstantiator(f => new Activite { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الأنشطة لبعض التدابير")
                .RuleFor(o => o.Duree, f =>
                {
                    var y = f.PickRandom(numberList);
                    return $"[\"{y++}\", \"{y++}\", \"{y++}\"]";
                })
                .RuleFor(o => o.IdMesure, f => f.Random.Number(1, 50))
                ;

            modelBuilder.Entity<Activite>().HasData(faker.Generate(50));

            return modelBuilder;
        }

        public static ModelBuilder Indicateurs(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new[]
            {
                " إرتفاع نسبة التسجيل والتصويت",
                "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ",
                "إرتفاع نسب التمثيلية",
                "النشر في الجريدة الرسمية",
                "تنصيب رئيس واعضاء الهيئة ",
                "عدد عمليات التشاور العمومي",
             };
            var faker = new Faker<Indicateur>(SeedingData.lang)
                .CustomInstantiator(f => new Indicateur { Id = id++ })
                .RuleFor(o => o.Nom, f => list[id - 2])
                .RuleFor(o => o.Source, f => "غير معروف")
                // .RuleFor(o => o.IdMesure, f => null)
                ;

            modelBuilder.Entity<Indicateur>().HasData(faker.Generate(6));

            return modelBuilder;
        }

        public static ModelBuilder IndicateurMesures(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var isFirstRoundDone = false;
            var faker = new Faker<IndicateurMesure>(SeedingData.lang)
                // .CustomInstantiator(f => new IndicateurMesure { Id = id++ })
                .RuleFor(o => o.IdMesure, f =>
                {
                    if (id <= 50)
                    {
                        return id++;
                    }
                    else
                    {
                        id = 1;
                        isFirstRoundDone = true;
                        return id++;
                    }
                })
                .RuleFor(o => o.IdIndicateur, f => isFirstRoundDone ? f.Random.Number(1, 3) : f.Random.Number(4, 6))
                // .RuleFor(o => o.Value, f => $"{f.Random.Number(10, 100)}")
                // .RuleFor(o => o.Date, f => f.Date.Past())
                ;

            modelBuilder.Entity<IndicateurMesure>().HasData(faker.Generate(100));

            return modelBuilder;
        }

        public static ModelBuilder IndicateurMesureValues(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var isFirstRoundDone = false;
            var faker = new Faker<IndicateurMesureValue>(SeedingData.lang)
                .CustomInstantiator(f => new IndicateurMesureValue { Id = id++ })
                // .RuleFor(o => o.IdMesure, f =>
                // {
                //     if (id <= 50)
                //     {
                //         return id++;
                //     }
                //     else
                //     {
                //         id = 1;
                //         isFirstRoundDone = true;
                //         return id++;
                //     }
                // })
                // .RuleFor(o => o.IdIndicateur, f => isFirstRoundDone ? f.Random.Number(1, 3) : f.Random.Number(4, 6))
                .RuleFor(o => o.IdMesure, f => f.Random.Number(1, 50))
                .RuleFor(o => o.IdIndicateur, f => f.Random.Number(1, 6))
                .RuleFor(o => o.Value, f => $"{f.Random.Number(10, 100)}")
                .RuleFor(o => o.Date, f => f.Date.Past())
                ;

            modelBuilder.Entity<IndicateurMesureValue>().HasData(faker.Generate(200));

            return modelBuilder;
        }

        public static ModelBuilder Realisations(this ModelBuilder modelBuilder)
        {
            var id = 1;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var list = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(1, 50))
                ;

            modelBuilder.Entity<Realisation>().HasData(faker.Generate(50));

            return modelBuilder;
        }



    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin5.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Axes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Axes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Pv = table.Column<string>(nullable: true),
                    DateEvenement = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicateurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Natures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConcerner = table.Column<int>(nullable: false),
                    IdOrganisme = table.Column<int>(nullable: false),
                    TableConcerner = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Destinataire = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Vu = table.Column<bool>(nullable: false),
                    Priorite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organismes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SousAxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    IdAxe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousAxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousAxes_Axes_IdAxe",
                        column: x => x.IdAxe,
                        principalTable: "Axes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembreCommissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplete = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdCommission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembreCommissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembreCommissions_Commissions_IdCommission",
                        column: x => x.IdCommission,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfil = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    RouteScreen = table.Column<string>(nullable: true),
                    RouteScreenAr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Profils_IdProfil",
                        column: x => x.IdProfil,
                        principalTable: "Profils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Adresse = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: false),
                    Fix = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Actif = table.Column<bool>(nullable: true),
                    IdOrganisme = table.Column<int>(nullable: false),
                    IdProfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organismes_IdOrganisme",
                        column: x => x.IdOrganisme,
                        principalTable: "Organismes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Profils_IdProfil",
                        column: x => x.IdProfil,
                        principalTable: "Profils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    IdType = table.Column<int>(nullable: false),
                    IdResponsable = table.Column<int>(nullable: false),
                    IdAxe = table.Column<int>(nullable: false),
                    IdSousAxe = table.Column<int>(nullable: false),
                    IdCycle = table.Column<int>(nullable: false),
                    IdNature = table.Column<int>(nullable: false),
                    ResultatsAttendu = table.Column<string>(nullable: true),
                    ObjectifGlobal = table.Column<string>(nullable: true),
                    ObjectifSpeciaux = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesures_Axes_IdAxe",
                        column: x => x.IdAxe,
                        principalTable: "Axes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Cycles_IdCycle",
                        column: x => x.IdCycle,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Natures_IdNature",
                        column: x => x.IdNature,
                        principalTable: "Natures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Users_IdResponsable",
                        column: x => x.IdResponsable,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mesures_SousAxes_IdSousAxe",
                        column: x => x.IdSousAxe,
                        principalTable: "SousAxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Duree = table.Column<string>(nullable: true),
                    IdMesure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activites_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicateurMesures",
                columns: table => new
                {
                    IdMesure = table.Column<int>(nullable: false),
                    IdIndicateur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicateurMesures", x => new { x.IdMesure, x.IdIndicateur });
                    table.ForeignKey(
                        name: "FK_IndicateurMesures_Indicateurs_IdIndicateur",
                        column: x => x.IdIndicateur,
                        principalTable: "Indicateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicateurMesures_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicateurMesureValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMesure = table.Column<int>(nullable: false),
                    IdIndicateur = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicateurMesureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicateurMesureValues_Indicateurs_IdIndicateur",
                        column: x => x.IdIndicateur,
                        principalTable: "Indicateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicateurMesureValues_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partenariats",
                columns: table => new
                {
                    IdMesure = table.Column<int>(nullable: false),
                    IdOrganisme = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partenariats", x => new { x.IdMesure, x.IdOrganisme });
                    table.ForeignKey(
                        name: "FK_Partenariats_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partenariats_Organismes_IdOrganisme",
                        column: x => x.IdOrganisme,
                        principalTable: "Organismes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realisations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Situation = table.Column<string>(nullable: true),
                    Annee = table.Column<int>(nullable: false),
                    Taux = table.Column<string>(nullable: true),
                    Effet = table.Column<string>(nullable: true),
                    IdActivite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realisations_Activites_IdActivite",
                        column: x => x.IdActivite,
                        principalTable: "Activites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "الديمقراطية والحكامة" },
                    { 2, "الحقــوق الاقتصاديــة والاجتماعيــة والثقافيــة والبيئيــة" },
                    { 3, "حماية الحقوق الفئوية والنهوض بها" },
                    { 4, "الإطار القانوني والمؤسساتي" }
                });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[,]
                {
                    { 20, new DateTime(2019, 8, 28, 4, 8, 27, 201, DateTimeKind.Local).AddTicks(2076), "محضر رقم 20", "اللجنة رقم 20" },
                    { 19, new DateTime(2019, 11, 22, 11, 28, 25, 958, DateTimeKind.Local).AddTicks(9758), "محضر رقم 19", "اللجنة رقم 19" },
                    { 18, new DateTime(2019, 4, 11, 2, 10, 40, 218, DateTimeKind.Local).AddTicks(5316), "محضر رقم 18", "اللجنة رقم 18" },
                    { 17, new DateTime(2019, 11, 23, 11, 0, 7, 776, DateTimeKind.Local).AddTicks(9946), "محضر رقم 17", "اللجنة رقم 17" },
                    { 16, new DateTime(2019, 5, 14, 3, 51, 56, 958, DateTimeKind.Local).AddTicks(2126), "محضر رقم 16", "اللجنة رقم 16" },
                    { 15, new DateTime(2019, 12, 28, 9, 49, 35, 188, DateTimeKind.Local).AddTicks(6019), "محضر رقم 15", "اللجنة رقم 15" },
                    { 14, new DateTime(2019, 11, 21, 9, 39, 3, 217, DateTimeKind.Local).AddTicks(3349), "محضر رقم 14", "اللجنة رقم 14" },
                    { 13, new DateTime(2019, 3, 29, 22, 59, 6, 945, DateTimeKind.Local).AddTicks(4745), "محضر رقم 13", "اللجنة رقم 13" },
                    { 12, new DateTime(2019, 9, 30, 21, 44, 2, 915, DateTimeKind.Local).AddTicks(3849), "محضر رقم 12", "اللجنة رقم 12" },
                    { 11, new DateTime(2020, 1, 20, 0, 13, 35, 502, DateTimeKind.Local).AddTicks(7288), "محضر رقم 11", "اللجنة رقم 11" },
                    { 9, new DateTime(2019, 7, 24, 13, 16, 26, 370, DateTimeKind.Local).AddTicks(2850), "محضر رقم 9", "اللجنة رقم 9" },
                    { 8, new DateTime(2019, 4, 21, 1, 24, 58, 167, DateTimeKind.Local).AddTicks(6084), "محضر رقم 8", "اللجنة رقم 8" },
                    { 7, new DateTime(2019, 4, 20, 23, 22, 7, 395, DateTimeKind.Local).AddTicks(6727), "محضر رقم 7", "اللجنة رقم 7" },
                    { 6, new DateTime(2019, 12, 12, 17, 18, 56, 778, DateTimeKind.Local).AddTicks(9119), "محضر رقم 6", "اللجنة رقم 6" },
                    { 5, new DateTime(2019, 11, 29, 6, 27, 0, 459, DateTimeKind.Local).AddTicks(2165), "محضر رقم 5", "اللجنة رقم 5" },
                    { 4, new DateTime(2019, 12, 19, 18, 54, 50, 459, DateTimeKind.Local).AddTicks(2707), "محضر رقم 4", "اللجنة رقم 4" },
                    { 3, new DateTime(2019, 6, 30, 9, 49, 41, 624, DateTimeKind.Local).AddTicks(1552), "محضر رقم 3", "اللجنة رقم 3" },
                    { 2, new DateTime(2019, 9, 29, 10, 23, 53, 755, DateTimeKind.Local).AddTicks(3627), "محضر رقم 2", "اللجنة رقم 2" },
                    { 1, new DateTime(2019, 4, 23, 18, 50, 4, 182, DateTimeKind.Local).AddTicks(6024), "محضر رقم 1", "اللجنة رقم 1" },
                    { 10, new DateTime(2019, 6, 24, 16, 14, 12, 25, DateTimeKind.Local).AddTicks(5765), "محضر رقم 10", "اللجنة رقم 10" }
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 4, "2030 - 2035" },
                    { 3, "2026 - 2030" },
                    { 1, "2018 - 2021" },
                    { 2, "2022 - 2025" }
                });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[,]
                {
                    { 1, " إرتفاع نسبة التسجيل والتصويت", "غير معروف" },
                    { 2, "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ", "غير معروف" },
                    { 3, "إرتفاع نسب التمثيلية", "غير معروف" },
                    { 4, "النشر في الجريدة الرسمية", "غير معروف" },
                    { 5, "تنصيب رئيس واعضاء الهيئة ", "غير معروف" },
                    { 6, "عدد عمليات التشاور العمومي", "غير معروف" }
                });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 3, "تقوية القدرات" },
                    { 1, "الجانب التشريعي والمؤسساتي" },
                    { 2, "التواصل والتحسيس" }
                });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[,]
                {
                    { 7, null, "وزارة الداخلية", null, 1 },
                    { 6, null, "جمعيات المجتمع المدني", null, 3 },
                    { 5, null, "الهيئات السياسية ", null, 3 },
                    { 2, null, "وزارة العدل", null, 1 },
                    { 3, null, "المجلس الأعلى للسلطة القضائية ", null, 1 },
                    { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 },
                    { 8, null, "الجمعيات الترابية", null, 2 },
                    { 4, null, "المجلس الوطني لحقوق الإنسان", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 3, "لجنة الوطنية" },
                    { 4, "لجنة التتبع" },
                    { 1, "مدير" },
                    { 2, "مشرف" },
                    { 5, "المخاطب الرئيسي" }
                });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[,]
                {
                    { 11, "Mathis46@gmail.com", 11, "Arthur Masson" },
                    { 17, "Maxence.Renard59@yahoo.fr", 17, "Raphaël Perez" },
                    { 16, "Mael_Leroux@gmail.com", 16, "Juliette David" },
                    { 15, "Louna.Gautier@yahoo.fr", 15, "Laura Vasseur" },
                    { 14, "Zoe_Huet85@gmail.com", 14, "Léo Bourgeois" },
                    { 13, "Kylian9@hotmail.fr", 13, "Valentin Moreau" },
                    { 12, "Mael18@gmail.com", 12, "Nathan Louis" },
                    { 18, "Mathis.Roux32@yahoo.fr", 18, "Lola Nguyen" },
                    { 1, "Jeanne58@gmail.com", 1, "Julie Prevost" },
                    { 3, "Mohamed.Dasilva3@hotmail.fr", 3, "Mathilde Julien" },
                    { 4, "Paul93@hotmail.fr", 4, "Louis Picard" },
                    { 5, "Emilie.Barre72@hotmail.fr", 5, "Mathilde Lambert" },
                    { 6, "Pierre.Guillaume56@yahoo.fr", 6, "Alicia Cousin" },
                    { 7, "Adam36@gmail.com", 7, "Eva Guillaume" },
                    { 8, "Pauline44@yahoo.fr", 8, "Clara Lecomte" },
                    { 2, "Chloe.Blanchard12@yahoo.fr", 2, "Noa Moreau" },
                    { 19, "Paul99@hotmail.fr", 19, "Maxime Garcia" },
                    { 20, "Mathis.Fontaine13@yahoo.fr", 20, "Justine Baron" },
                    { 10, "Jade.Laurent12@gmail.com", 10, "Louise Morel" },
                    { 9, "Clement_Collet@gmail.com", 9, "Mélissa Dufour" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[,]
                {
                    { 6, "Consultation", 5, "rapport-qualitative", "rapport-qualitative" },
                    { 5, "Consultation", 5, "rapport-litteraire", "rapport-litteraire" },
                    { 4, "Modification", 5, "suivi", "suivi" },
                    { 3, "Consultation", 5, "mesure-programme", "mesure-programme" },
                    { 2, "Consultation", 5, "mesure-region", "mesure-region" },
                    { 1, "Consultation", 5, "mesure-executif", "mesure-executif" },
                    { 8, "Modification", 4, "commission", "commission" },
                    { 7, "Modification", 3, "commission", "commission" },
                    { 15, "Modification", 2, "rapport-qualitative", "rapport-qualitative" },
                    { 14, "Modification", 2, "rapport-litteraire", "rapport-litteraire" },
                    { 13, "Modification", 2, "suivi", "suivi" },
                    { 12, "Modification", 2, "mesure-programme", "mesure-programme" },
                    { 11, "Modification", 2, "mesure-region", "mesure-region" },
                    { 10, "Modification", 2, "mesure-executif", "mesure-executif" },
                    { 16, "Modification", 2, "commission", "commission" },
                    { 9, "Modification", 2, "commission", "commission" }
                });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[,]
                {
                    { 1, 1, "المشاركة السياسية " },
                    { 26, 4, "الحقوق والحريات والآليات المؤسساتية " },
                    { 3, 1, " الحكامة الترابية " },
                    { 4, 1, "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد " },
                    { 5, 1, "الحكامة الأمنية " },
                    { 6, 1, " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات " },
                    { 7, 1, " مكافحة الإفلات من العقاب" },
                    { 8, 2, " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي " },
                    { 9, 2, "الحقوق الثقافية " },
                    { 10, 2, " الولوج إلى الخدمات الصحية " },
                    { 11, 2, " الشغل وتكريس المساواة " },
                    { 12, 2, " السياسة السكنية " },
                    { 2, 1, "المساواة والمناصفة وتكافؤ الفرص " },
                    { 14, 2, " المقاولة وحقوق الإنسان " },
                    { 13, 2, "السياسة البيئية المندمجة " },
                    { 16, 3, " حقوق الطفل " },
                    { 17, 3, "حقوق الشباب " },
                    { 18, 3, " حقوق الأشخاص في وضعية إعاقة " },
                    { 19, 3, " حقوق الأشخاص المسنين " },
                    { 20, 3, "حقوق المهاجرين واللاجئين " },
                    { 21, 4, " الحماية القانونية والقضائية لحقوق الإنسان " },
                    { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " },
                    { 23, 4, "حريات التعبير والإعلام والصحافة والحق في المعلومة " },
                    { 24, 4, "حماية التراث الثقافي " },
                    { 25, 4, " حفظ الأرشيف وصيانته " },
                    { 15, 3, " الأبعاد المؤسساتية والتشريعية " }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[,]
                {
                    { 10, true, "taza", "fakri-10@angular.io", "05 ## ## ## ##", 6, 5, "fakri-10", "123", "mohamed", "06 ## ## ## ##", "fakri-10" },
                    { 9, true, "taza", "fakri-9@angular.io", "05 ## ## ## ##", 5, 5, "fakri-9", "123", "mohamed", "06 ## ## ## ##", "fakri-9" },
                    { 8, true, "taza", "fakri-8@angular.io", "05 ## ## ## ##", 4, 5, "fakri-8", "123", "mohamed", "06 ## ## ## ##", "fakri-8" },
                    { 7, true, "taza", "fakri-7@angular.io", "05 ## ## ## ##", 3, 5, "fakri-7", "123", "mohamed", "06 ## ## ## ##", "fakri-7" },
                    { 6, true, "taza", "fakri-6@angular.io", "05 ## ## ## ##", 2, 5, "fakri-6", "123", "mohamed", "06 ## ## ## ##", "fakri-6" },
                    { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 8, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" },
                    { 3, true, "Temara", "ahmed@angular.io", "05 ## ## ## ##", 5, 4, "ahmed", "123", "ahmed", "06 ## ## ## ##", "ahmed" },
                    { 4, true, "Temara", "soufiane@angular.io", "05 ## ## ## ##", 7, 3, "soufiane", "123", "soufiane", "06 ## ## ## ##", "soufiane" },
                    { 11, true, "taza", "fakri-11@angular.io", "05 ## ## ## ##", 7, 5, "fakri-11", "123", "mohamed", "06 ## ## ## ##", "fakri-11" },
                    { 1, true, "Temara", "mourabit@angular.io", "05 ## ## ## ##", 1, 1, "mourabit", "123", "mohamed", "06 ## ## ## ##", "mourabit" },
                    { 5, true, "taza", "fakri-5@angular.io", "05 ## ## ## ##", 1, 5, "fakri-5", "123", "mohamed", "06 ## ## ## ##", "fakri-5" },
                    { 12, true, "taza", "fakri-12@angular.io", "05 ## ## ## ##", 8, 5, "fakri-12", "123", "mohamed", "06 ## ## ## ##", "fakri-12" }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[,]
                {
                    { 7, "Code : {id - 1}", 2, 1, 1, 5, 5, 2, "7 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 7", "بعد الأهداف الخاصة : 7", "بعد النتائج المرتقبة : 7" },
                    { 46, "Code : {id - 1}", 1, 3, 1, 8, 1, 2, "46 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 46", "بعد الأهداف الخاصة : 46", "بعد النتائج المرتقبة : 46" },
                    { 4, "Code : {id - 1}", 3, 2, 1, 9, 11, 2, "4 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 4", "بعد الأهداف الخاصة : 4", "بعد النتائج المرتقبة : 4" },
                    { 5, "Code : {id - 1}", 4, 1, 3, 9, 1, 2, "5 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 5", "بعد الأهداف الخاصة : 5", "بعد النتائج المرتقبة : 5" },
                    { 12, "Code : {id - 1}", 4, 2, 1, 9, 5, 1, "12 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 12", "بعد الأهداف الخاصة : 12", "بعد النتائج المرتقبة : 12" },
                    { 18, "Code : {id - 1}", 3, 3, 1, 9, 2, 3, "18 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 18", "بعد الأهداف الخاصة : 18", "بعد النتائج المرتقبة : 18" },
                    { 23, "Code : {id - 1}", 4, 3, 3, 9, 13, 2, "23 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 23", "بعد الأهداف الخاصة : 23", "بعد النتائج المرتقبة : 23" },
                    { 24, "Code : {id - 1}", 2, 1, 3, 9, 24, 2, "24 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 24", "بعد الأهداف الخاصة : 24", "بعد النتائج المرتقبة : 24" },
                    { 45, "Code : {id - 1}", 1, 1, 1, 9, 3, 2, "45 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 45", "بعد الأهداف الخاصة : 45", "بعد النتائج المرتقبة : 45" },
                    { 20, "Code : {id - 1}", 4, 2, 3, 10, 23, 2, "20 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 20", "بعد الأهداف الخاصة : 20", "بعد النتائج المرتقبة : 20" },
                    { 1, "Code : {id - 1}", 2, 3, 3, 11, 11, 3, "1 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 1", "بعد الأهداف الخاصة : 1", "بعد النتائج المرتقبة : 1" },
                    { 35, "Code : {id - 1}", 1, 1, 3, 11, 13, 2, "35 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 35", "بعد الأهداف الخاصة : 35", "بعد النتائج المرتقبة : 35" },
                    { 38, "Code : {id - 1}", 2, 3, 3, 11, 5, 2, "38 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 38", "بعد الأهداف الخاصة : 38", "بعد النتائج المرتقبة : 38" },
                    { 41, "Code : {id - 1}", 1, 2, 3, 11, 12, 2, "41 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 41", "بعد الأهداف الخاصة : 41", "بعد النتائج المرتقبة : 41" },
                    { 6, "Code : {id - 1}", 3, 2, 1, 12, 16, 2, "6 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 6", "بعد الأهداف الخاصة : 6", "بعد النتائج المرتقبة : 6" },
                    { 8, "Code : {id - 1}", 3, 3, 2, 12, 10, 1, "8 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 8", "بعد الأهداف الخاصة : 8", "بعد النتائج المرتقبة : 8" },
                    { 25, "Code : {id - 1}", 1, 2, 2, 12, 6, 3, "25 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 25", "بعد الأهداف الخاصة : 25", "بعد النتائج المرتقبة : 25" },
                    { 27, "Code : {id - 1}", 1, 3, 2, 12, 8, 3, "27 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 27", "بعد الأهداف الخاصة : 27", "بعد النتائج المرتقبة : 27" },
                    { 31, "Code : {id - 1}", 3, 1, 2, 12, 20, 1, "31 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 31", "بعد الأهداف الخاصة : 31", "بعد النتائج المرتقبة : 31" },
                    { 36, "Code : {id - 1}", 4, 1, 1, 12, 18, 3, "36 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 36", "بعد الأهداف الخاصة : 36", "بعد النتائج المرتقبة : 36" },
                    { 40, "Code : {id - 1}", 3, 1, 1, 12, 6, 2, "40 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 40", "بعد الأهداف الخاصة : 40", "بعد النتائج المرتقبة : 40" },
                    { 42, "Code : {id - 1}", 1, 2, 2, 12, 15, 3, "42 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 42", "بعد الأهداف الخاصة : 42", "بعد النتائج المرتقبة : 42" },
                    { 44, "Code : {id - 1}", 1, 3, 3, 8, 5, 1, "44 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 44", "بعد الأهداف الخاصة : 44", "بعد النتائج المرتقبة : 44" },
                    { 43, "Code : {id - 1}", 1, 3, 2, 8, 20, 2, "43 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 43", "بعد الأهداف الخاصة : 43", "بعد النتائج المرتقبة : 43" },
                    { 28, "Code : {id - 1}", 1, 1, 3, 8, 13, 1, "28 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 28", "بعد الأهداف الخاصة : 28", "بعد النتائج المرتقبة : 28" },
                    { 26, "Code : {id - 1}", 3, 1, 3, 8, 10, 1, "26 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 26", "بعد الأهداف الخاصة : 26", "بعد النتائج المرتقبة : 26" },
                    { 14, "Code : {id - 1}", 4, 1, 1, 5, 11, 3, "14 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 14", "بعد الأهداف الخاصة : 14", "بعد النتائج المرتقبة : 14" },
                    { 29, "Code : {id - 1}", 4, 1, 1, 5, 8, 3, "29 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 29", "بعد الأهداف الخاصة : 29", "بعد النتائج المرتقبة : 29" },
                    { 47, "Code : {id - 1}", 2, 2, 3, 5, 11, 3, "47 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 47", "بعد الأهداف الخاصة : 47", "بعد النتائج المرتقبة : 47" },
                    { 2, "Code : {id - 1}", 4, 1, 3, 6, 7, 1, "2 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 2", "بعد الأهداف الخاصة : 2", "بعد النتائج المرتقبة : 2" },
                    { 9, "Code : {id - 1}", 2, 3, 3, 6, 6, 3, "9 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 9", "بعد الأهداف الخاصة : 9", "بعد النتائج المرتقبة : 9" },
                    { 15, "Code : {id - 1}", 1, 3, 1, 6, 22, 2, "15 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 15", "بعد الأهداف الخاصة : 15", "بعد النتائج المرتقبة : 15" },
                    { 17, "Code : {id - 1}", 1, 1, 1, 6, 6, 1, "17 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 17", "بعد الأهداف الخاصة : 17", "بعد النتائج المرتقبة : 17" },
                    { 19, "Code : {id - 1}", 2, 2, 3, 6, 20, 2, "19 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 19", "بعد الأهداف الخاصة : 19", "بعد النتائج المرتقبة : 19" },
                    { 30, "Code : {id - 1}", 1, 1, 2, 6, 19, 1, "30 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 30", "بعد الأهداف الخاصة : 30", "بعد النتائج المرتقبة : 30" },
                    { 32, "Code : {id - 1}", 2, 3, 3, 6, 3, 1, "32 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 32", "بعد الأهداف الخاصة : 32", "بعد النتائج المرتقبة : 32" },
                    { 48, "Code : {id - 1}", 4, 2, 2, 12, 22, 3, "48 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 48", "بعد الأهداف الخاصة : 48", "بعد النتائج المرتقبة : 48" },
                    { 34, "Code : {id - 1}", 4, 1, 2, 6, 5, 3, "34 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 34", "بعد الأهداف الخاصة : 34", "بعد النتائج المرتقبة : 34" },
                    { 3, "Code : {id - 1}", 2, 1, 3, 7, 5, 1, "3 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 3", "بعد الأهداف الخاصة : 3", "بعد النتائج المرتقبة : 3" },
                    { 11, "Code : {id - 1}", 4, 3, 1, 7, 5, 1, "11 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 11", "بعد الأهداف الخاصة : 11", "بعد النتائج المرتقبة : 11" },
                    { 21, "Code : {id - 1}", 3, 2, 1, 7, 19, 1, "21 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 21", "بعد الأهداف الخاصة : 21", "بعد النتائج المرتقبة : 21" },
                    { 22, "Code : {id - 1}", 2, 1, 3, 7, 5, 1, "22 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 22", "بعد الأهداف الخاصة : 22", "بعد النتائج المرتقبة : 22" },
                    { 33, "Code : {id - 1}", 3, 3, 3, 7, 2, 2, "33 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 33", "بعد الأهداف الخاصة : 33", "بعد النتائج المرتقبة : 33" },
                    { 37, "Code : {id - 1}", 2, 1, 1, 7, 11, 2, "37 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 37", "بعد الأهداف الخاصة : 37", "بعد النتائج المرتقبة : 37" },
                    { 50, "Code : {id - 1}", 4, 3, 3, 7, 3, 1, "50 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 50", "بعد الأهداف الخاصة : 50", "بعد النتائج المرتقبة : 50" },
                    { 10, "Code : {id - 1}", 2, 3, 1, 8, 3, 2, "10 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 10", "بعد الأهداف الخاصة : 10", "بعد النتائج المرتقبة : 10" },
                    { 13, "Code : {id - 1}", 1, 1, 2, 8, 12, 2, "13 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 13", "بعد الأهداف الخاصة : 13", "بعد النتائج المرتقبة : 13" },
                    { 16, "Code : {id - 1}", 1, 1, 1, 8, 5, 3, "16 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 16", "بعد الأهداف الخاصة : 16", "بعد النتائج المرتقبة : 16" },
                    { 39, "Code : {id - 1}", 2, 3, 3, 6, 5, 2, "39 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 39", "بعد الأهداف الخاصة : 39", "بعد النتائج المرتقبة : 39" },
                    { 49, "Code : {id - 1}", 2, 3, 3, 12, 4, 3, "49 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 49", "بعد الأهداف الخاصة : 49", "بعد النتائج المرتقبة : 49" }
                });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[,]
                {
                    { 18, "[\"2024\", \"2025\", \"2026\"]", 33, "17 بعد الأنشطة لبعض التدابير" },
                    { 7, "[\"2018\", \"2019\", \"2020\"]", 44, "6 بعد الأنشطة لبعض التدابير" },
                    { 42, "[\"2026\", \"2027\", \"2028\"]", 44, "41 بعد الأنشطة لبعض التدابير" },
                    { 15, "[\"2027\", \"2028\", \"2029\"]", 27, "14 بعد الأنشطة لبعض التدابير" },
                    { 11, "[\"2018\", \"2019\", \"2020\"]", 24, "10 بعد الأنشطة لبعض التدابير" },
                    { 6, "[\"2027\", \"2028\", \"2029\"]", 33, "5 بعد الأنشطة لبعض التدابير" },
                    { 19, "[\"2028\", \"2029\", \"2030\"]", 46, "18 بعد الأنشطة لبعض التدابير" },
                    { 8, "[\"2018\", \"2019\", \"2020\"]", 15, "7 بعد الأنشطة لبعض التدابير" },
                    { 13, "[\"2028\", \"2029\", \"2030\"]", 15, "12 بعد الأنشطة لبعض التدابير" },
                    { 50, "[\"2026\", \"2027\", \"2028\"]", 8, "49 بعد الأنشطة لبعض التدابير" },
                    { 46, "[\"2021\", \"2022\", \"2023\"]", 4, "45 بعد الأنشطة لبعض التدابير" },
                    { 34, "[\"2024\", \"2025\", \"2026\"]", 17, "33 بعد الأنشطة لبعض التدابير" },
                    { 12, "[\"2021\", \"2022\", \"2023\"]", 6, "11 بعد الأنشطة لبعض التدابير" },
                    { 35, "[\"2021\", \"2022\", \"2023\"]", 22, "34 بعد الأنشطة لبعض التدابير" },
                    { 29, "[\"2022\", \"2023\", \"2024\"]", 41, "28 بعد الأنشطة لبعض التدابير" },
                    { 14, "[\"2024\", \"2025\", \"2026\"]", 19, "13 بعد الأنشطة لبعض التدابير" },
                    { 28, "[\"2026\", \"2027\", \"2028\"]", 19, "27 بعد الأنشطة لبعض التدابير" },
                    { 37, "[\"2021\", \"2022\", \"2023\"]", 21, "36 بعد الأنشطة لبعض التدابير" },
                    { 1, "[\"2027\", \"2028\", \"2029\"]", 35, "0 بعد الأنشطة لبعض التدابير" },
                    { 22, "[\"2018\", \"2019\", \"2020\"]", 1, "21 بعد الأنشطة لبعض التدابير" },
                    { 21, "[\"2023\", \"2024\", \"2025\"]", 1, "20 بعد الأنشطة لبعض التدابير" },
                    { 39, "[\"2023\", \"2024\", \"2025\"]", 16, "38 بعد الأنشطة لبعض التدابير" },
                    { 45, "[\"2029\", \"2030\", \"2031\"]", 11, "44 بعد الأنشطة لبعض التدابير" },
                    { 48, "[\"2022\", \"2023\", \"2024\"]", 20, "47 بعد الأنشطة لبعض التدابير" },
                    { 43, "[\"2023\", \"2024\", \"2025\"]", 34, "42 بعد الأنشطة لبعض التدابير" },
                    { 36, "[\"2022\", \"2023\", \"2024\"]", 20, "35 بعد الأنشطة لبعض التدابير" },
                    { 49, "[\"2020\", \"2021\", \"2022\"]", 3, "48 بعد الأنشطة لبعض التدابير" },
                    { 24, "[\"2019\", \"2020\", \"2021\"]", 3, "23 بعد الأنشطة لبعض التدابير" },
                    { 41, "[\"2020\", \"2021\", \"2022\"]", 24, "40 بعد الأنشطة لبعض التدابير" },
                    { 5, "[\"2024\", \"2025\", \"2026\"]", 39, "4 بعد الأنشطة لبعض التدابير" },
                    { 23, "[\"2019\", \"2020\", \"2021\"]", 31, "22 بعد الأنشطة لبعض التدابير" },
                    { 38, "[\"2021\", \"2022\", \"2023\"]", 2, "37 بعد الأنشطة لبعض التدابير" },
                    { 9, "[\"2021\", \"2022\", \"2023\"]", 3, "8 بعد الأنشطة لبعض التدابير" },
                    { 26, "[\"2018\", \"2019\", \"2020\"]", 40, "25 بعد الأنشطة لبعض التدابير" },
                    { 4, "[\"2022\", \"2023\", \"2024\"]", 29, "3 بعد الأنشطة لبعض التدابير" },
                    { 31, "[\"2023\", \"2024\", \"2025\"]", 2, "30 بعد الأنشطة لبعض التدابير" },
                    { 33, "[\"2021\", \"2022\", \"2023\"]", 48, "32 بعد الأنشطة لبعض التدابير" },
                    { 27, "[\"2028\", \"2029\", \"2030\"]", 10, "26 بعد الأنشطة لبعض التدابير" },
                    { 44, "[\"2029\", \"2030\", \"2031\"]", 48, "43 بعد الأنشطة لبعض التدابير" },
                    { 47, "[\"2028\", \"2029\", \"2030\"]", 48, "46 بعد الأنشطة لبعض التدابير" },
                    { 25, "[\"2026\", \"2027\", \"2028\"]", 47, "24 بعد الأنشطة لبعض التدابير" },
                    { 20, "[\"2027\", \"2028\", \"2029\"]", 40, "19 بعد الأنشطة لبعض التدابير" },
                    { 16, "[\"2023\", \"2024\", \"2025\"]", 43, "15 بعد الأنشطة لبعض التدابير" },
                    { 32, "[\"2027\", \"2028\", \"2029\"]", 50, "31 بعد الأنشطة لبعض التدابير" },
                    { 2, "[\"2028\", \"2029\", \"2030\"]", 48, "1 بعد الأنشطة لبعض التدابير" },
                    { 17, "[\"2019\", \"2020\", \"2021\"]", 36, "16 بعد الأنشطة لبعض التدابير" },
                    { 40, "[\"2018\", \"2019\", \"2020\"]", 16, "39 بعد الأنشطة لبعض التدابير" },
                    { 3, "[\"2019\", \"2020\", \"2021\"]", 49, "2 بعد الأنشطة لبعض التدابير" },
                    { 10, "[\"2020\", \"2021\", \"2022\"]", 36, "9 بعد الأنشطة لبعض التدابير" },
                    { 30, "[\"2018\", \"2019\", \"2020\"]", 43, "29 بعد الأنشطة لبعض التدابير" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[,]
                {
                    { 61, new DateTime(2019, 2, 22, 13, 43, 48, 518, DateTimeKind.Local).AddTicks(9365), 2, 16, "71" },
                    { 138, new DateTime(2019, 12, 7, 10, 30, 35, 426, DateTimeKind.Local).AddTicks(5759), 4, 5, "58" },
                    { 6, new DateTime(2019, 5, 28, 6, 4, 39, 474, DateTimeKind.Local).AddTicks(1504), 4, 16, "31" },
                    { 25, new DateTime(2019, 11, 13, 22, 5, 29, 569, DateTimeKind.Local).AddTicks(3523), 1, 12, "69" },
                    { 9, new DateTime(2019, 9, 22, 16, 2, 23, 23, DateTimeKind.Local).AddTicks(8015), 2, 16, "98" },
                    { 68, new DateTime(2019, 3, 26, 11, 3, 40, 576, DateTimeKind.Local).AddTicks(9301), 5, 23, "84" },
                    { 86, new DateTime(2020, 1, 28, 20, 53, 53, 813, DateTimeKind.Local).AddTicks(3326), 5, 12, "64" },
                    { 166, new DateTime(2019, 11, 21, 17, 51, 39, 515, DateTimeKind.Local).AddTicks(3108), 2, 12, "10" },
                    { 110, new DateTime(2019, 5, 9, 14, 3, 58, 72, DateTimeKind.Local).AddTicks(6123), 3, 26, "36" },
                    { 50, new DateTime(2020, 1, 1, 10, 51, 10, 207, DateTimeKind.Local).AddTicks(5291), 3, 26, "37" },
                    { 143, new DateTime(2019, 7, 20, 4, 30, 5, 835, DateTimeKind.Local).AddTicks(5844), 4, 18, "87" },
                    { 21, new DateTime(2019, 6, 16, 2, 34, 58, 107, DateTimeKind.Local).AddTicks(9681), 2, 26, "91" },
                    { 118, new DateTime(2019, 4, 26, 5, 49, 51, 832, DateTimeKind.Local).AddTicks(5268), 2, 5, "92" },
                    { 57, new DateTime(2019, 4, 17, 7, 38, 11, 551, DateTimeKind.Local).AddTicks(6882), 3, 23, "100" },
                    { 155, new DateTime(2019, 2, 8, 23, 57, 14, 46, DateTimeKind.Local).AddTicks(7848), 3, 16, "67" },
                    { 183, new DateTime(2019, 4, 9, 9, 2, 12, 441, DateTimeKind.Local).AddTicks(4774), 6, 18, "49" },
                    { 164, new DateTime(2020, 1, 2, 20, 44, 49, 9, DateTimeKind.Local).AddTicks(1911), 1, 18, "53" },
                    { 42, new DateTime(2019, 12, 20, 16, 59, 17, 648, DateTimeKind.Local).AddTicks(1355), 5, 43, "66" },
                    { 168, new DateTime(2019, 4, 17, 8, 10, 18, 471, DateTimeKind.Local).AddTicks(1806), 3, 26, "11" },
                    { 54, new DateTime(2019, 4, 3, 2, 31, 23, 621, DateTimeKind.Local).AddTicks(645), 4, 5, "23" },
                    { 55, new DateTime(2019, 4, 2, 7, 40, 29, 306, DateTimeKind.Local).AddTicks(9231), 1, 43, "28" },
                    { 69, new DateTime(2019, 8, 14, 19, 2, 41, 441, DateTimeKind.Local).AddTicks(8938), 6, 43, "59" },
                    { 115, new DateTime(2019, 7, 29, 9, 22, 41, 754, DateTimeKind.Local).AddTicks(6943), 1, 43, "75" },
                    { 17, new DateTime(2019, 4, 2, 13, 20, 3, 891, DateTimeKind.Local).AddTicks(3990), 3, 43, "94" },
                    { 178, new DateTime(2019, 11, 4, 9, 51, 26, 160, DateTimeKind.Local).AddTicks(3936), 5, 43, "58" },
                    { 29, new DateTime(2019, 10, 21, 16, 33, 45, 250, DateTimeKind.Local).AddTicks(6759), 4, 44, "67" },
                    { 37, new DateTime(2019, 12, 27, 6, 28, 5, 613, DateTimeKind.Local).AddTicks(7806), 2, 44, "89" },
                    { 49, new DateTime(2019, 6, 2, 0, 53, 56, 876, DateTimeKind.Local).AddTicks(632), 6, 44, "84" },
                    { 112, new DateTime(2019, 4, 25, 12, 4, 30, 509, DateTimeKind.Local).AddTicks(7185), 2, 44, "32" },
                    { 170, new DateTime(2019, 6, 27, 8, 44, 52, 157, DateTimeKind.Local).AddTicks(5023), 5, 28, "25" },
                    { 89, new DateTime(2019, 11, 26, 7, 59, 26, 811, DateTimeKind.Local).AddTicks(7234), 3, 5, "95" },
                    { 31, new DateTime(2019, 9, 25, 9, 29, 42, 280, DateTimeKind.Local).AddTicks(1212), 6, 46, "51" },
                    { 117, new DateTime(2019, 7, 17, 20, 36, 24, 137, DateTimeKind.Local).AddTicks(7157), 4, 46, "48" },
                    { 160, new DateTime(2019, 11, 4, 7, 50, 55, 792, DateTimeKind.Local).AddTicks(6236), 4, 28, "97" },
                    { 32, new DateTime(2020, 1, 21, 22, 56, 34, 817, DateTimeKind.Local).AddTicks(9553), 1, 4, "71" },
                    { 122, new DateTime(2019, 8, 4, 5, 1, 10, 539, DateTimeKind.Local).AddTicks(7861), 2, 28, "81" },
                    { 43, new DateTime(2019, 3, 26, 2, 15, 22, 183, DateTimeKind.Local).AddTicks(9386), 2, 28, "12" },
                    { 109, new DateTime(2020, 1, 17, 5, 39, 22, 521, DateTimeKind.Local).AddTicks(4238), 5, 4, "52" },
                    { 184, new DateTime(2020, 1, 11, 9, 19, 35, 98, DateTimeKind.Local).AddTicks(1051), 4, 49, "30" },
                    { 145, new DateTime(2019, 12, 5, 18, 28, 58, 687, DateTimeKind.Local).AddTicks(847), 6, 4, "74" },
                    { 165, new DateTime(2019, 8, 2, 10, 37, 4, 799, DateTimeKind.Local).AddTicks(2344), 5, 4, "79" },
                    { 34, new DateTime(2019, 9, 4, 6, 25, 49, 187, DateTimeKind.Local).AddTicks(5602), 5, 5, "10" },
                    { 70, new DateTime(2020, 1, 21, 1, 19, 38, 723, DateTimeKind.Local).AddTicks(2516), 5, 46, "35" },
                    { 13, new DateTime(2019, 6, 29, 18, 42, 44, 14, DateTimeKind.Local).AddTicks(6764), 2, 28, "50" },
                    { 62, new DateTime(2019, 11, 19, 19, 17, 16, 782, DateTimeKind.Local).AddTicks(3787), 3, 20, "63" },
                    { 195, new DateTime(2019, 8, 8, 20, 36, 55, 262, DateTimeKind.Local).AddTicks(8186), 3, 23, "13" },
                    { 144, new DateTime(2019, 12, 21, 7, 17, 33, 883, DateTimeKind.Local).AddTicks(3626), 1, 27, "14" },
                    { 154, new DateTime(2019, 7, 8, 13, 41, 28, 755, DateTimeKind.Local).AddTicks(3066), 1, 27, "52" },
                    { 190, new DateTime(2020, 1, 14, 8, 4, 5, 267, DateTimeKind.Local).AddTicks(4809), 1, 27, "18" },
                    { 194, new DateTime(2019, 12, 19, 20, 19, 52, 521, DateTimeKind.Local).AddTicks(3918), 6, 27, "93" },
                    { 2, new DateTime(2019, 9, 16, 7, 44, 30, 179, DateTimeKind.Local).AddTicks(6500), 1, 31, "60" },
                    { 11, new DateTime(2019, 8, 5, 0, 0, 34, 44, DateTimeKind.Local).AddTicks(7400), 5, 31, "17" },
                    { 51, new DateTime(2019, 9, 7, 7, 16, 43, 92, DateTimeKind.Local).AddTicks(1222), 5, 31, "60" },
                    { 79, new DateTime(2019, 6, 19, 9, 31, 51, 280, DateTimeKind.Local).AddTicks(3314), 6, 31, "34" },
                    { 102, new DateTime(2019, 12, 22, 0, 11, 33, 113, DateTimeKind.Local).AddTicks(1862), 6, 31, "22" },
                    { 124, new DateTime(2019, 12, 17, 5, 22, 48, 429, DateTimeKind.Local).AddTicks(7522), 5, 31, "38" },
                    { 12, new DateTime(2019, 8, 27, 4, 0, 31, 318, DateTimeKind.Local).AddTicks(5374), 6, 36, "95" },
                    { 63, new DateTime(2019, 8, 15, 15, 25, 20, 463, DateTimeKind.Local).AddTicks(6506), 6, 36, "84" },
                    { 163, new DateTime(2019, 12, 4, 10, 29, 23, 227, DateTimeKind.Local).AddTicks(6857), 2, 36, "100" },
                    { 3, new DateTime(2019, 11, 6, 8, 22, 41, 11, DateTimeKind.Local).AddTicks(8496), 5, 40, "27" },
                    { 157, new DateTime(2019, 9, 30, 10, 0, 3, 258, DateTimeKind.Local).AddTicks(3455), 1, 40, "79" },
                    { 121, new DateTime(2019, 11, 11, 13, 16, 18, 834, DateTimeKind.Local).AddTicks(1814), 4, 42, "49" },
                    { 129, new DateTime(2019, 4, 18, 22, 45, 31, 636, DateTimeKind.Local).AddTicks(6499), 1, 42, "71" },
                    { 146, new DateTime(2019, 6, 20, 10, 19, 41, 939, DateTimeKind.Local).AddTicks(6864), 5, 42, "15" },
                    { 173, new DateTime(2019, 4, 17, 10, 33, 41, 263, DateTimeKind.Local).AddTicks(7971), 4, 42, "14" },
                    { 36, new DateTime(2019, 12, 7, 7, 17, 59, 887, DateTimeKind.Local).AddTicks(2197), 1, 48, "32" },
                    { 84, new DateTime(2019, 3, 29, 12, 47, 34, 993, DateTimeKind.Local).AddTicks(9133), 1, 48, "100" },
                    { 135, new DateTime(2019, 12, 19, 7, 29, 2, 521, DateTimeKind.Local).AddTicks(4984), 1, 48, "53" },
                    { 153, new DateTime(2019, 7, 18, 18, 59, 36, 185, DateTimeKind.Local).AddTicks(2773), 3, 48, "80" },
                    { 167, new DateTime(2019, 11, 11, 3, 32, 29, 612, DateTimeKind.Local).AddTicks(2380), 5, 48, "83" },
                    { 185, new DateTime(2019, 7, 11, 5, 12, 50, 169, DateTimeKind.Local).AddTicks(8728), 2, 48, "64" },
                    { 188, new DateTime(2019, 12, 24, 13, 12, 17, 379, DateTimeKind.Local).AddTicks(4960), 6, 48, "78" },
                    { 73, new DateTime(2019, 12, 14, 23, 0, 19, 602, DateTimeKind.Local).AddTicks(1869), 2, 49, "46" },
                    { 18, new DateTime(2019, 9, 29, 17, 13, 42, 496, DateTimeKind.Local).AddTicks(9222), 6, 25, "84" },
                    { 16, new DateTime(2020, 1, 28, 15, 24, 45, 78, DateTimeKind.Local).AddTicks(608), 1, 25, "54" },
                    { 1, new DateTime(2019, 8, 5, 17, 30, 46, 257, DateTimeKind.Local).AddTicks(2706), 4, 25, "58" },
                    { 158, new DateTime(2019, 12, 31, 10, 38, 29, 884, DateTimeKind.Local).AddTicks(5814), 5, 8, "59" },
                    { 8, new DateTime(2019, 5, 24, 15, 48, 36, 910, DateTimeKind.Local).AddTicks(4774), 5, 45, "86" },
                    { 75, new DateTime(2019, 12, 18, 1, 38, 32, 494, DateTimeKind.Local).AddTicks(7395), 2, 45, "82" },
                    { 88, new DateTime(2019, 10, 28, 9, 34, 50, 582, DateTimeKind.Local).AddTicks(6500), 2, 45, "62" },
                    { 108, new DateTime(2019, 9, 3, 6, 22, 45, 34, DateTimeKind.Local).AddTicks(2438), 5, 45, "70" },
                    { 120, new DateTime(2019, 7, 11, 1, 14, 19, 927, DateTimeKind.Local).AddTicks(1403), 4, 45, "32" },
                    { 134, new DateTime(2019, 12, 13, 20, 58, 2, 456, DateTimeKind.Local).AddTicks(8686), 6, 45, "83" },
                    { 23, new DateTime(2019, 5, 8, 23, 50, 40, 282, DateTimeKind.Local).AddTicks(5782), 1, 20, "95" },
                    { 39, new DateTime(2019, 12, 20, 8, 47, 50, 433, DateTimeKind.Local).AddTicks(8878), 1, 20, "38" },
                    { 92, new DateTime(2019, 8, 24, 10, 24, 5, 483, DateTimeKind.Local).AddTicks(1451), 4, 20, "43" },
                    { 176, new DateTime(2019, 9, 18, 16, 36, 51, 101, DateTimeKind.Local).AddTicks(8482), 6, 20, "23" },
                    { 196, new DateTime(2019, 8, 22, 6, 13, 12, 331, DateTimeKind.Local).AddTicks(7357), 3, 1, "14" },
                    { 100, new DateTime(2019, 8, 4, 11, 6, 25, 678, DateTimeKind.Local).AddTicks(7934), 5, 35, "67" },
                    { 161, new DateTime(2019, 4, 18, 12, 48, 11, 400, DateTimeKind.Local).AddTicks(9816), 2, 35, "94" },
                    { 169, new DateTime(2019, 6, 1, 0, 11, 2, 591, DateTimeKind.Local).AddTicks(5354), 3, 23, "36" },
                    { 71, new DateTime(2019, 6, 7, 13, 45, 34, 834, DateTimeKind.Local).AddTicks(4069), 5, 38, "18" },
                    { 126, new DateTime(2019, 9, 17, 23, 41, 50, 605, DateTimeKind.Local).AddTicks(6865), 5, 38, "72" },
                    { 127, new DateTime(2019, 12, 1, 5, 26, 43, 221, DateTimeKind.Local).AddTicks(7639), 3, 38, "58" },
                    { 172, new DateTime(2019, 6, 28, 11, 1, 51, 730, DateTimeKind.Local).AddTicks(2258), 3, 38, "78" },
                    { 174, new DateTime(2019, 9, 8, 2, 19, 40, 500, DateTimeKind.Local).AddTicks(4780), 3, 38, "12" },
                    { 28, new DateTime(2019, 5, 23, 17, 29, 16, 182, DateTimeKind.Local).AddTicks(5990), 2, 41, "34" },
                    { 80, new DateTime(2019, 10, 18, 11, 1, 10, 520, DateTimeKind.Local).AddTicks(7495), 4, 41, "28" },
                    { 14, new DateTime(2019, 4, 5, 18, 14, 19, 82, DateTimeKind.Local).AddTicks(4641), 2, 6, "85" },
                    { 83, new DateTime(2019, 6, 29, 1, 12, 15, 942, DateTimeKind.Local).AddTicks(2065), 1, 6, "62" },
                    { 105, new DateTime(2020, 1, 7, 16, 4, 9, 608, DateTimeKind.Local).AddTicks(3876), 2, 6, "27" },
                    { 132, new DateTime(2019, 12, 7, 12, 56, 45, 732, DateTimeKind.Local).AddTicks(491), 3, 6, "24" },
                    { 67, new DateTime(2019, 5, 28, 14, 3, 38, 321, DateTimeKind.Local).AddTicks(3838), 2, 8, "43" },
                    { 125, new DateTime(2019, 9, 30, 4, 57, 37, 753, DateTimeKind.Local).AddTicks(6177), 2, 8, "75" },
                    { 133, new DateTime(2019, 7, 6, 23, 51, 46, 914, DateTimeKind.Local).AddTicks(5116), 5, 8, "55" },
                    { 107, new DateTime(2019, 12, 25, 18, 42, 10, 568, DateTimeKind.Local).AddTicks(6774), 1, 38, "47" },
                    { 175, new DateTime(2019, 7, 27, 18, 59, 46, 720, DateTimeKind.Local).AddTicks(8361), 5, 13, "87" },
                    { 187, new DateTime(2019, 7, 1, 13, 29, 27, 128, DateTimeKind.Local).AddTicks(1645), 5, 49, "29" },
                    { 123, new DateTime(2019, 8, 24, 19, 48, 10, 895, DateTimeKind.Local).AddTicks(6806), 4, 13, "27" },
                    { 47, new DateTime(2020, 1, 18, 18, 31, 54, 349, DateTimeKind.Local).AddTicks(9301), 1, 34, "20" },
                    { 56, new DateTime(2019, 6, 4, 18, 13, 35, 578, DateTimeKind.Local).AddTicks(4322), 4, 34, "72" },
                    { 113, new DateTime(2019, 8, 17, 15, 57, 12, 232, DateTimeKind.Local).AddTicks(7098), 4, 34, "27" },
                    { 136, new DateTime(2019, 8, 27, 6, 44, 30, 978, DateTimeKind.Local).AddTicks(732), 4, 34, "87" },
                    { 76, new DateTime(2020, 1, 26, 22, 11, 10, 450, DateTimeKind.Local).AddTicks(9762), 6, 2, "79" },
                    { 74, new DateTime(2019, 9, 14, 4, 5, 56, 341, DateTimeKind.Local).AddTicks(7638), 1, 2, "86" },
                    { 152, new DateTime(2019, 12, 8, 14, 56, 2, 838, DateTimeKind.Local).AddTicks(2201), 6, 34, "67" },
                    { 60, new DateTime(2019, 11, 2, 20, 5, 49, 633, DateTimeKind.Local).AddTicks(9688), 6, 2, "26" },
                    { 149, new DateTime(2019, 10, 17, 20, 47, 4, 960, DateTimeKind.Local).AddTicks(3145), 2, 39, "88" },
                    { 193, new DateTime(2019, 9, 9, 3, 19, 5, 118, DateTimeKind.Local).AddTicks(5882), 3, 47, "24" },
                    { 24, new DateTime(2019, 8, 9, 1, 9, 49, 274, DateTimeKind.Local).AddTicks(9682), 2, 34, "71" },
                    { 181, new DateTime(2020, 1, 29, 20, 49, 35, 314, DateTimeKind.Local).AddTicks(784), 2, 47, "46" },
                    { 4, new DateTime(2019, 9, 8, 17, 52, 27, 392, DateTimeKind.Local).AddTicks(389), 3, 3, "43" },
                    { 65, new DateTime(2020, 1, 26, 7, 47, 33, 640, DateTimeKind.Local).AddTicks(2623), 6, 3, "97" },
                    { 198, new DateTime(2019, 4, 8, 9, 9, 45, 386, DateTimeKind.Local).AddTicks(2152), 1, 3, "58" },
                    { 119, new DateTime(2019, 6, 10, 23, 43, 25, 622, DateTimeKind.Local).AddTicks(1806), 3, 47, "92" },
                    { 93, new DateTime(2019, 5, 9, 8, 29, 22, 873, DateTimeKind.Local).AddTicks(799), 3, 47, "65" },
                    { 182, new DateTime(2019, 2, 6, 18, 36, 31, 414, DateTimeKind.Local).AddTicks(699), 2, 15, "14" },
                    { 78, new DateTime(2019, 10, 12, 5, 51, 44, 215, DateTimeKind.Local).AddTicks(3674), 6, 47, "22" },
                    { 33, new DateTime(2019, 8, 7, 1, 40, 3, 129, DateTimeKind.Local).AddTicks(1137), 6, 47, "44" },
                    { 46, new DateTime(2019, 7, 19, 23, 58, 33, 413, DateTimeKind.Local).AddTicks(4565), 4, 11, "47" },
                    { 98, new DateTime(2019, 7, 28, 11, 39, 57, 564, DateTimeKind.Local).AddTicks(4391), 5, 11, "70" },
                    { 156, new DateTime(2019, 9, 21, 17, 46, 3, 598, DateTimeKind.Local).AddTicks(2700), 3, 47, "67" },
                    { 7, new DateTime(2019, 8, 26, 0, 54, 48, 119, DateTimeKind.Local).AddTicks(7432), 3, 47, "69" },
                    { 85, new DateTime(2019, 11, 15, 13, 6, 45, 449, DateTimeKind.Local).AddTicks(2723), 1, 2, "55" },
                    { 114, new DateTime(2019, 4, 12, 21, 15, 28, 256, DateTimeKind.Local).AddTicks(8428), 4, 32, "52" },
                    { 148, new DateTime(2019, 5, 24, 18, 45, 12, 485, DateTimeKind.Local).AddTicks(2678), 6, 15, "77" },
                    { 19, new DateTime(2019, 7, 1, 4, 2, 52, 691, DateTimeKind.Local).AddTicks(1054), 4, 15, "49" },
                    { 22, new DateTime(2020, 1, 12, 7, 50, 31, 91, DateTimeKind.Local).AddTicks(5853), 2, 17, "63" },
                    { 99, new DateTime(2019, 10, 12, 8, 43, 0, 286, DateTimeKind.Local).AddTicks(3976), 1, 17, "17" },
                    { 142, new DateTime(2019, 3, 5, 20, 3, 48, 122, DateTimeKind.Local).AddTicks(9303), 2, 17, "43" },
                    { 199, new DateTime(2019, 3, 2, 19, 55, 37, 839, DateTimeKind.Local).AddTicks(4471), 4, 9, "49" },
                    { 52, new DateTime(2019, 3, 2, 11, 16, 9, 357, DateTimeKind.Local).AddTicks(9204), 3, 19, "74" },
                    { 53, new DateTime(2019, 9, 26, 5, 54, 23, 790, DateTimeKind.Local).AddTicks(2876), 3, 19, "55" },
                    { 192, new DateTime(2019, 2, 24, 21, 2, 46, 446, DateTimeKind.Local).AddTicks(1137), 5, 19, "34" },
                    { 139, new DateTime(2019, 4, 3, 7, 42, 42, 826, DateTimeKind.Local).AddTicks(2481), 1, 9, "65" },
                    { 87, new DateTime(2019, 12, 23, 18, 34, 14, 943, DateTimeKind.Local).AddTicks(1468), 1, 2, "59" },
                    { 111, new DateTime(2019, 6, 17, 19, 15, 18, 984, DateTimeKind.Local).AddTicks(500), 3, 9, "11" },
                    { 72, new DateTime(2019, 7, 28, 2, 26, 1, 627, DateTimeKind.Local).AddTicks(3820), 6, 9, "15" },
                    { 5, new DateTime(2020, 1, 21, 8, 52, 2, 857, DateTimeKind.Local).AddTicks(1753), 5, 30, "81" },
                    { 10, new DateTime(2019, 12, 2, 7, 1, 40, 320, DateTimeKind.Local).AddTicks(9818), 2, 30, "48" },
                    { 130, new DateTime(2019, 5, 18, 2, 30, 10, 623, DateTimeKind.Local).AddTicks(7762), 6, 30, "23" },
                    { 179, new DateTime(2019, 12, 21, 7, 0, 15, 691, DateTimeKind.Local).AddTicks(2940), 1, 30, "56" },
                    { 147, new DateTime(2019, 3, 17, 22, 25, 37, 399, DateTimeKind.Local).AddTicks(4979), 3, 13, "46" },
                    { 38, new DateTime(2019, 9, 24, 1, 2, 40, 166, DateTimeKind.Local).AddTicks(3908), 3, 32, "35" },
                    { 45, new DateTime(2019, 4, 7, 1, 10, 41, 661, DateTimeKind.Local).AddTicks(729), 2, 32, "54" },
                    { 58, new DateTime(2019, 11, 6, 2, 26, 21, 643, DateTimeKind.Local).AddTicks(8704), 6, 32, "39" },
                    { 106, new DateTime(2019, 12, 22, 19, 30, 39, 32, DateTimeKind.Local).AddTicks(7247), 6, 2, "31" },
                    { 77, new DateTime(2019, 11, 9, 4, 34, 36, 141, DateTimeKind.Local).AddTicks(502), 6, 9, "66" },
                    { 41, new DateTime(2019, 3, 23, 23, 17, 57, 717, DateTimeKind.Local).AddTicks(9898), 2, 21, "62" },
                    { 30, new DateTime(2019, 6, 25, 21, 52, 16, 54, DateTimeKind.Local).AddTicks(3306), 6, 11, "72" },
                    { 82, new DateTime(2019, 5, 25, 22, 21, 37, 796, DateTimeKind.Local).AddTicks(8878), 5, 14, "84" },
                    { 186, new DateTime(2020, 1, 22, 1, 21, 33, 78, DateTimeKind.Local).AddTicks(5717), 5, 33, "78" },
                    { 141, new DateTime(2019, 3, 21, 0, 40, 20, 508, DateTimeKind.Local).AddTicks(2957), 3, 14, "13" },
                    { 104, new DateTime(2019, 9, 1, 20, 27, 44, 568, DateTimeKind.Local).AddTicks(9206), 4, 14, "41" },
                    { 101, new DateTime(2019, 8, 16, 8, 19, 29, 356, DateTimeKind.Local).AddTicks(3741), 1, 37, "27" },
                    { 131, new DateTime(2019, 8, 26, 1, 54, 50, 535, DateTimeKind.Local).AddTicks(949), 6, 37, "36" },
                    { 137, new DateTime(2019, 8, 16, 12, 46, 18, 444, DateTimeKind.Local).AddTicks(2086), 6, 37, "66" },
                    { 66, new DateTime(2019, 9, 19, 15, 22, 27, 598, DateTimeKind.Local).AddTicks(9715), 6, 21, "36" },
                    { 159, new DateTime(2019, 12, 19, 4, 24, 38, 316, DateTimeKind.Local).AddTicks(2000), 2, 37, "63" },
                    { 35, new DateTime(2019, 11, 10, 19, 3, 22, 677, DateTimeKind.Local).AddTicks(3512), 3, 14, "28" },
                    { 26, new DateTime(2019, 7, 18, 16, 37, 19, 328, DateTimeKind.Local).AddTicks(5694), 1, 50, "96" },
                    { 59, new DateTime(2019, 8, 19, 10, 22, 30, 825, DateTimeKind.Local).AddTicks(9994), 3, 50, "29" },
                    { 171, new DateTime(2019, 3, 24, 5, 23, 15, 867, DateTimeKind.Local).AddTicks(6473), 1, 50, "67" },
                    { 197, new DateTime(2019, 5, 24, 15, 13, 29, 276, DateTimeKind.Local).AddTicks(6211), 2, 7, "58" },
                    { 191, new DateTime(2019, 2, 16, 5, 34, 31, 371, DateTimeKind.Local).AddTicks(4342), 5, 7, "64" },
                    { 64, new DateTime(2020, 1, 20, 13, 16, 29, 776, DateTimeKind.Local).AddTicks(3103), 3, 10, "49" },
                    { 81, new DateTime(2019, 10, 29, 23, 55, 16, 724, DateTimeKind.Local).AddTicks(4080), 6, 10, "75" },
                    { 90, new DateTime(2019, 8, 11, 16, 44, 30, 656, DateTimeKind.Local).AddTicks(5116), 4, 10, "77" },
                    { 96, new DateTime(2019, 3, 12, 18, 40, 43, 797, DateTimeKind.Local).AddTicks(8996), 5, 7, "83" },
                    { 94, new DateTime(2019, 9, 24, 16, 5, 25, 344, DateTimeKind.Local).AddTicks(308), 6, 7, "15" },
                    { 162, new DateTime(2019, 6, 6, 5, 3, 35, 226, DateTimeKind.Local).AddTicks(5632), 2, 10, "24" },
                    { 200, new DateTime(2019, 11, 1, 11, 42, 6, 855, DateTimeKind.Local).AddTicks(8901), 5, 10, "70" },
                    { 91, new DateTime(2019, 4, 28, 5, 9, 22, 628, DateTimeKind.Local).AddTicks(8476), 6, 7, "21" },
                    { 95, new DateTime(2019, 11, 26, 23, 31, 33, 69, DateTimeKind.Local).AddTicks(8669), 5, 13, "30" },
                    { 180, new DateTime(2019, 7, 10, 14, 26, 5, 573, DateTimeKind.Local).AddTicks(6943), 1, 33, "50" },
                    { 128, new DateTime(2019, 11, 3, 7, 48, 49, 131, DateTimeKind.Local).AddTicks(3077), 5, 33, "93" },
                    { 189, new DateTime(2019, 12, 2, 19, 5, 45, 967, DateTimeKind.Local).AddTicks(3073), 2, 15, "64" },
                    { 20, new DateTime(2020, 2, 2, 3, 15, 29, 823, DateTimeKind.Local).AddTicks(1225), 5, 29, "98" },
                    { 140, new DateTime(2019, 10, 18, 3, 21, 8, 769, DateTimeKind.Local).AddTicks(9070), 2, 21, "35" },
                    { 97, new DateTime(2019, 8, 22, 20, 40, 42, 987, DateTimeKind.Local).AddTicks(7430), 2, 29, "55" },
                    { 27, new DateTime(2019, 8, 2, 14, 56, 34, 215, DateTimeKind.Local).AddTicks(1088), 1, 22, "37" },
                    { 116, new DateTime(2019, 5, 26, 16, 43, 8, 49, DateTimeKind.Local).AddTicks(4311), 1, 22, "30" },
                    { 48, new DateTime(2019, 5, 31, 12, 15, 28, 882, DateTimeKind.Local).AddTicks(3633), 6, 22, "80" },
                    { 151, new DateTime(2019, 7, 15, 6, 29, 16, 392, DateTimeKind.Local).AddTicks(8712), 5, 29, "21" },
                    { 103, new DateTime(2019, 8, 10, 6, 45, 40, 619, DateTimeKind.Local).AddTicks(1316), 4, 22, "95" },
                    { 150, new DateTime(2019, 9, 9, 21, 29, 44, 659, DateTimeKind.Local).AddTicks(8107), 6, 29, "20" },
                    { 44, new DateTime(2019, 4, 6, 5, 29, 1, 349, DateTimeKind.Local).AddTicks(9709), 3, 33, "70" },
                    { 15, new DateTime(2019, 12, 9, 18, 32, 28, 942, DateTimeKind.Local).AddTicks(7384), 6, 22, "61" },
                    { 177, new DateTime(2019, 2, 19, 17, 31, 13, 94, DateTimeKind.Local).AddTicks(955), 2, 14, "75" },
                    { 40, new DateTime(2019, 9, 27, 15, 2, 17, 624, DateTimeKind.Local).AddTicks(5691), 4, 33, "54" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[,]
                {
                    { 40, 1 },
                    { 47, 1 },
                    { 42, 4 },
                    { 31, 2 },
                    { 49, 5 },
                    { 8, 3 },
                    { 8, 5 },
                    { 49, 1 },
                    { 15, 2 },
                    { 7, 2 },
                    { 47, 6 },
                    { 15, 4 },
                    { 25, 6 },
                    { 14, 5 },
                    { 36, 3 },
                    { 29, 5 },
                    { 2, 1 },
                    { 2, 4 },
                    { 29, 2 },
                    { 48, 5 },
                    { 27, 1 },
                    { 25, 1 },
                    { 48, 3 },
                    { 27, 4 },
                    { 14, 2 },
                    { 9, 5 },
                    { 9, 2 },
                    { 31, 6 },
                    { 36, 6 },
                    { 42, 3 },
                    { 40, 6 },
                    { 32, 5 },
                    { 6, 5 },
                    { 21, 4 },
                    { 21, 3 },
                    { 5, 1 },
                    { 5, 6 },
                    { 22, 5 },
                    { 22, 1 },
                    { 4, 2 },
                    { 4, 5 },
                    { 46, 1 },
                    { 46, 5 },
                    { 33, 6 },
                    { 33, 2 },
                    { 44, 1 },
                    { 44, 5 },
                    { 12, 4 },
                    { 37, 6 },
                    { 43, 3 },
                    { 43, 4 },
                    { 50, 6 },
                    { 50, 1 },
                    { 10, 5 },
                    { 28, 1 },
                    { 28, 6 },
                    { 10, 2 },
                    { 26, 1 },
                    { 26, 5 },
                    { 13, 4 },
                    { 13, 3 },
                    { 16, 1 },
                    { 16, 6 },
                    { 37, 3 },
                    { 12, 2 },
                    { 11, 1 },
                    { 11, 6 },
                    { 17, 6 },
                    { 17, 2 },
                    { 41, 2 },
                    { 41, 6 },
                    { 19, 6 },
                    { 19, 2 },
                    { 38, 1 },
                    { 38, 5 },
                    { 30, 6 },
                    { 30, 2 },
                    { 35, 3 },
                    { 35, 6 },
                    { 1, 1 },
                    { 1, 5 },
                    { 32, 3 },
                    { 20, 1 },
                    { 20, 4 },
                    { 18, 4 },
                    { 18, 1 },
                    { 23, 6 },
                    { 23, 2 },
                    { 3, 3 },
                    { 3, 6 },
                    { 6, 3 },
                    { 39, 3 },
                    { 24, 6 },
                    { 24, 1 },
                    { 45, 4 },
                    { 45, 3 },
                    { 34, 3 },
                    { 34, 6 },
                    { 39, 6 },
                    { 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[,]
                {
                    { 39, 2024, "38 التأثير لهدا الإنجاز", 4, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز" },
                    { 31, 2019, "30 التأثير لهدا الإنجاز", 11, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز" },
                    { 8, 2025, "7 التأثير لهدا الإنجاز", 48, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز" },
                    { 25, 2021, "24 التأثير لهدا الإنجاز", 21, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز" },
                    { 41, 2018, "40 التأثير لهدا الإنجاز", 21, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز" },
                    { 19, 2026, "18 التأثير لهدا الإنجاز", 22, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز" },
                    { 33, 2028, "32 التأثير لهدا الإنجاز", 29, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز" },
                    { 44, 2028, "43 التأثير لهدا الإنجاز", 29, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز" },
                    { 23, 2021, "22 التأثير لهدا الإنجاز", 12, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز" },
                    { 22, 2018, "21 التأثير لهدا الإنجاز", 15, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز" },
                    { 18, 2020, "17 التأثير لهدا الإنجاز", 23, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز" },
                    { 21, 2019, "20 التأثير لهدا الإنجاز", 23, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز" },
                    { 35, 2024, "34 التأثير لهدا الإنجاز", 10, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز" },
                    { 26, 2018, "25 التأثير لهدا الإنجاز", 17, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز" },
                    { 32, 2023, "31 التأثير لهدا الإنجاز", 2, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز" },
                    { 49, 2029, "48 التأثير لهدا الإنجاز", 2, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز" },
                    { 10, 2024, "9 التأثير لهدا الإنجاز", 33, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز" },
                    { 15, 2018, "14 التأثير لهدا الإنجاز", 44, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز" },
                    { 17, 2025, "16 التأثير لهدا الإنجاز", 44, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز" },
                    { 34, 2023, "33 التأثير لهدا الإنجاز", 47, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز" },
                    { 48, 2026, "47 التأثير لهدا الإنجاز", 47, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز" },
                    { 6, 2029, "5 التأثير لهدا الإنجاز", 3, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز" },
                    { 40, 2027, "39 التأثير لهدا الإنجاز", 46, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز" },
                    { 36, 2020, "35 التأثير لهدا الإنجاز", 46, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز" },
                    { 16, 2027, "15 التأثير لهدا الإنجاز", 19, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز" },
                    { 24, 2021, "23 التأثير لهدا الإنجاز", 7, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز" },
                    { 4, 2024, "3 التأثير لهدا الإنجاز", 25, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز" },
                    { 1, 2019, "0 التأثير لهدا الإنجاز", 38, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز" },
                    { 2, 2027, "1 التأثير لهدا الإنجاز", 13, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز" },
                    { 3, 2024, "2 التأثير لهدا الإنجاز", 34, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز" },
                    { 29, 2022, "28 التأثير لهدا الإنجاز", 34, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز" },
                    { 45, 2026, "44 التأثير لهدا الإنجاز", 34, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز" },
                    { 11, 2029, "10 التأثير لهدا الإنجاز", 28, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز" },
                    { 28, 2019, "27 التأثير لهدا الإنجاز", 28, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز" },
                    { 38, 2024, "37 التأثير لهدا الإنجاز", 28, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز" },
                    { 12, 2022, "11 التأثير لهدا الإنجاز", 5, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز" },
                    { 27, 2024, "26 التأثير لهدا الإنجاز", 3, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز" },
                    { 30, 2019, "29 التأثير لهدا الإنجاز", 9, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز" },
                    { 43, 2027, "42 التأثير لهدا الإنجاز", 24, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز" },
                    { 9, 2022, "8 التأثير لهدا الإنجاز", 45, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز" },
                    { 7, 2027, "6 التأثير لهدا الإنجاز", 37, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز" },
                    { 37, 2024, "36 التأثير لهدا الإنجاز", 37, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز" },
                    { 5, 2028, "4 التأثير لهدا الإنجاز", 35, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز" },
                    { 50, 2022, "49 التأثير لهدا الإنجاز", 35, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز" },
                    { 13, 2019, "12 التأثير لهدا الإنجاز", 18, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز" },
                    { 42, 2018, "41 التأثير لهدا الإنجاز", 32, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز" },
                    { 20, 2022, "19 التأثير لهدا الإنجاز", 40, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز" },
                    { 14, 2024, "13 التأثير لهدا الإنجاز", 16, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز" },
                    { 47, 2021, "46 التأثير لهدا الإنجاز", 9, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز" },
                    { 46, 2018, "45 التأثير لهدا الإنجاز", 3, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activites_IdMesure",
                table: "Activites",
                column: "IdMesure");

            migrationBuilder.CreateIndex(
                name: "IX_IndicateurMesures_IdIndicateur",
                table: "IndicateurMesures",
                column: "IdIndicateur");

            migrationBuilder.CreateIndex(
                name: "IX_IndicateurMesureValues_IdIndicateur",
                table: "IndicateurMesureValues",
                column: "IdIndicateur");

            migrationBuilder.CreateIndex(
                name: "IX_IndicateurMesureValues_IdMesure",
                table: "IndicateurMesureValues",
                column: "IdMesure");

            migrationBuilder.CreateIndex(
                name: "IX_MembreCommissions_IdCommission",
                table: "MembreCommissions",
                column: "IdCommission");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdAxe",
                table: "Mesures",
                column: "IdAxe");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdCycle",
                table: "Mesures",
                column: "IdCycle");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdNature",
                table: "Mesures",
                column: "IdNature");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdResponsable",
                table: "Mesures",
                column: "IdResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdSousAxe",
                table: "Mesures",
                column: "IdSousAxe");

            migrationBuilder.CreateIndex(
                name: "IX_Partenariats_IdOrganisme",
                table: "Partenariats",
                column: "IdOrganisme");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_IdProfil",
                table: "Permissions",
                column: "IdProfil");

            migrationBuilder.CreateIndex(
                name: "IX_Realisations_IdActivite",
                table: "Realisations",
                column: "IdActivite");

            migrationBuilder.CreateIndex(
                name: "IX_SousAxes_IdAxe",
                table: "SousAxes",
                column: "IdAxe");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdOrganisme",
                table: "Users",
                column: "IdOrganisme");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfil",
                table: "Users",
                column: "IdProfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicateurMesures");

            migrationBuilder.DropTable(
                name: "IndicateurMesureValues");

            migrationBuilder.DropTable(
                name: "MembreCommissions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Partenariats");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Realisations");

            migrationBuilder.DropTable(
                name: "Indicateurs");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Natures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SousAxes");

            migrationBuilder.DropTable(
                name: "Organismes");

            migrationBuilder.DropTable(
                name: "Profils");

            migrationBuilder.DropTable(
                name: "Axes");
        }
    }
}

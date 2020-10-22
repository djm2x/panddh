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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                values: new object[] { 1, "الديمقراطية والحكامة" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "الحقــوق الاقتصاديــة والاجتماعيــة والثقافيــة والبيئيــة" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "حماية الحقوق الفئوية والنهوض بها" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "الإطار القانوني والمؤسساتي" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 20, new DateTime(2020, 5, 23, 6, 11, 4, 886, DateTimeKind.Local).AddTicks(5188), "محضر رقم 20", "اللجنة رقم 20" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 19, new DateTime(2019, 9, 26, 18, 1, 51, 776, DateTimeKind.Local).AddTicks(7632), "محضر رقم 19", "اللجنة رقم 19" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 18, new DateTime(2019, 10, 7, 16, 18, 8, 260, DateTimeKind.Local).AddTicks(7670), "محضر رقم 18", "اللجنة رقم 18" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 17, new DateTime(2020, 2, 24, 10, 16, 35, 406, DateTimeKind.Local).AddTicks(2198), "محضر رقم 17", "اللجنة رقم 17" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 16, new DateTime(2020, 7, 23, 22, 21, 38, 724, DateTimeKind.Local).AddTicks(4082), "محضر رقم 16", "اللجنة رقم 16" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 15, new DateTime(2019, 11, 1, 15, 38, 17, 111, DateTimeKind.Local).AddTicks(1078), "محضر رقم 15", "اللجنة رقم 15" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 14, new DateTime(2020, 5, 12, 16, 13, 4, 763, DateTimeKind.Local).AddTicks(7145), "محضر رقم 14", "اللجنة رقم 14" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 13, new DateTime(2020, 4, 12, 23, 20, 51, 108, DateTimeKind.Local).AddTicks(9994), "محضر رقم 13", "اللجنة رقم 13" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 12, new DateTime(2019, 12, 31, 20, 40, 47, 262, DateTimeKind.Local).AddTicks(5135), "محضر رقم 12", "اللجنة رقم 12" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 11, new DateTime(2019, 11, 26, 4, 40, 41, 399, DateTimeKind.Local).AddTicks(1628), "محضر رقم 11", "اللجنة رقم 11" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 9, new DateTime(2020, 1, 11, 6, 26, 23, 269, DateTimeKind.Local).AddTicks(4915), "محضر رقم 9", "اللجنة رقم 9" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 8, new DateTime(2020, 5, 11, 9, 12, 45, 441, DateTimeKind.Local).AddTicks(2611), "محضر رقم 8", "اللجنة رقم 8" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 7, new DateTime(2019, 12, 17, 19, 9, 51, 546, DateTimeKind.Local).AddTicks(6115), "محضر رقم 7", "اللجنة رقم 7" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 6, new DateTime(2019, 11, 22, 20, 36, 16, 326, DateTimeKind.Local).AddTicks(4963), "محضر رقم 6", "اللجنة رقم 6" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 5, new DateTime(2019, 10, 5, 18, 52, 36, 33, DateTimeKind.Local).AddTicks(1340), "محضر رقم 5", "اللجنة رقم 5" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 4, new DateTime(2019, 10, 15, 16, 58, 48, 184, DateTimeKind.Local).AddTicks(6679), "محضر رقم 4", "اللجنة رقم 4" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 3, new DateTime(2020, 2, 2, 12, 34, 38, 704, DateTimeKind.Local).AddTicks(5839), "محضر رقم 3", "اللجنة رقم 3" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 2, new DateTime(2020, 3, 26, 5, 55, 44, 364, DateTimeKind.Local).AddTicks(9024), "محضر رقم 2", "اللجنة رقم 2" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 1, new DateTime(2020, 7, 1, 10, 4, 42, 957, DateTimeKind.Local).AddTicks(5697), "محضر رقم 1", "اللجنة رقم 1" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 10, new DateTime(2020, 3, 7, 1, 38, 45, 791, DateTimeKind.Local).AddTicks(2538), "محضر رقم 10", "اللجنة رقم 10" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "2030 - 2035" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "2026 - 2030" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "2018 - 2021" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "2022 - 2025" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 1, " إرتفاع نسبة التسجيل والتصويت", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 2, "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 3, "إرتفاع نسب التمثيلية", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 4, "النشر في الجريدة الرسمية", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 5, "تنصيب رئيس واعضاء الهيئة ", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 6, "عدد عمليات التشاور العمومي", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "تقوية القدرات" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "الجانب التشريعي والمؤسساتي" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "التواصل والتحسيس" });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 7, null, "وزارة الداخلية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 6, null, "جمعيات المجتمع المدني", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 5, null, "الهيئات السياسية ", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 2, null, "وزارة العدل", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 3, null, "المجلس الأعلى للسلطة القضائية ", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 8, null, "الجمعيات الترابية", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 4, null, "المجلس الوطني لحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "لجنة الوطنية" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "لجنة التتبع" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "مدير" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "مشرف" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 5, "المخاطب الرئيسي" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 12, "Maxime14@yahoo.fr", 12, "Mathéo Dumas" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 18, "Ethan_David@yahoo.fr", 18, "Evan Legrand" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 17, "Mathilde_Schneider@hotmail.fr", 17, "Julie Roux" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 16, "Matheo92@yahoo.fr", 16, "Ethan Lefebvre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 15, "Alexandre_Fleury27@hotmail.fr", 15, "Charlotte Aubert" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 14, "Lina.Gonzalez@yahoo.fr", 14, "Jules Arnaud" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 13, "Anais6@yahoo.fr", 13, "Mathilde Barbier" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 1, "Baptiste8@gmail.com", 1, "Elisa Robin" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 2, "Clemence.Vidal@hotmail.fr", 2, "Ambre Noel" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 3, "Lea39@hotmail.fr", 3, "Lola Lemaire" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 4, "Raphael.Martinez55@hotmail.fr", 4, "Maeva Lefevre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 5, "Sacha_Fontaine@yahoo.fr", 5, "Victor Garcia" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 6, "Romane_Gaillard62@yahoo.fr", 6, "Mathéo Fontaine" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 7, "Arthur.Lacroix@gmail.com", 7, "Romane Roux" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 8, "Ambre35@hotmail.fr", 8, "Carla Dumas" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 9, "Theo_Perrin10@yahoo.fr", 9, "Louis Mathieu" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 19, "Oceane92@hotmail.fr", 19, "Mélissa Girard" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 10, "Charlotte.Guerin@yahoo.fr", 10, "Raphaël Guerin" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 20, "Maxence.Dumont@yahoo.fr", 20, "Clara Marty" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 11, "Enzo99@yahoo.fr", 11, "Marie Marie" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 7, "Consultation", 5, "suivi-indicateur", "rapport-qualitative" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 6, "Consultation", 5, "rapport-qualitative", "rapport-qualitative" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 5, "Consultation", 5, "rapport-litteraire", "rapport-litteraire" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 4, "Modification", 5, "suivi", "suivi" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 3, "Consultation", 5, "mesure-programme", "mesure-programme" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 2, "Consultation", 5, "mesure-region", "mesure-region" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 1, "Consultation", 5, "mesure-executif", "mesure-executif" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 9, "Modification", 4, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 8, "Modification", 3, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 17, "Modification", 2, "suivi-indicateur", "suivi-indicateur" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 16, "Modification", 2, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 15, "Modification", 2, "rapport-qualitative", "rapport-qualitative" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 14, "Modification", 2, "rapport-litteraire", "rapport-litteraire" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 13, "Modification", 2, "suivi", "suivi" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 12, "Modification", 2, "mesure-programme", "mesure-programme" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 10, "Modification", 2, "mesure-executif", "mesure-executif" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 11, "Modification", 2, "mesure-region", "mesure-region" });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 1, 1, "المشاركة السياسية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 26, 4, "الحقوق والحريات والآليات المؤسساتية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 2, 1, "المساواة والمناصفة وتكافؤ الفرص " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 3, 1, " الحكامة الترابية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 4, 1, "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 5, 1, "الحكامة الأمنية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 6, 1, " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 7, 1, " مكافحة الإفلات من العقاب" });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 8, 2, " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 9, 2, "الحقوق الثقافية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 11, 2, " الشغل وتكريس المساواة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 12, 2, " السياسة السكنية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 13, 2, "السياسة البيئية المندمجة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 14, 2, " المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 10, 2, " الولوج إلى الخدمات الصحية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 16, 3, " حقوق الطفل " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 25, 4, " حفظ الأرشيف وصيانته " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 24, 4, "حماية التراث الثقافي " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 23, 4, "حريات التعبير والإعلام والصحافة والحق في المعلومة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 15, 3, " الأبعاد المؤسساتية والتشريعية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 21, 4, " الحماية القانونية والقضائية لحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 20, 3, "حقوق المهاجرين واللاجئين " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 19, 3, " حقوق الأشخاص المسنين " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 18, 3, " حقوق الأشخاص في وضعية إعاقة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 17, 3, "حقوق الشباب " });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 1, true, "Temara", "mourabit@angular.io", "05 ## ## ## ##", 1, 1, "mourabit", "123", "mohamed", "06 ## ## ## ##", "mourabit" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 4, true, "Temara", "soufiane@angular.io", "05 ## ## ## ##", 7, 3, "soufiane", "123", "soufiane", "06 ## ## ## ##", "soufiane" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 11, true, "taza", "fakri-11@angular.io", "05 ## ## ## ##", 7, 5, "fakri-11", "123", "mohamed", "06 ## ## ## ##", "fakri-11" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 8, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 5, true, "taza", "fakri-5@angular.io", "05 ## ## ## ##", 1, 5, "fakri-5", "123", "mohamed", "06 ## ## ## ##", "fakri-5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 6, true, "taza", "fakri-6@angular.io", "05 ## ## ## ##", 2, 5, "fakri-6", "123", "mohamed", "06 ## ## ## ##", "fakri-6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 7, true, "taza", "fakri-7@angular.io", "05 ## ## ## ##", 3, 5, "fakri-7", "123", "mohamed", "06 ## ## ## ##", "fakri-7" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 8, true, "taza", "fakri-8@angular.io", "05 ## ## ## ##", 4, 5, "fakri-8", "123", "mohamed", "06 ## ## ## ##", "fakri-8" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 9, true, "taza", "fakri-9@angular.io", "05 ## ## ## ##", 5, 5, "fakri-9", "123", "mohamed", "06 ## ## ## ##", "fakri-9" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 10, true, "taza", "fakri-10@angular.io", "05 ## ## ## ##", 6, 5, "fakri-10", "123", "mohamed", "06 ## ## ## ##", "fakri-10" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 3, true, "Temara", "ahmed@angular.io", "05 ## ## ## ##", 5, 4, "ahmed", "123", "ahmed", "06 ## ## ## ##", "ahmed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 12, true, "taza", "fakri-12@angular.io", "05 ## ## ## ##", 8, 5, "fakri-12", "123", "mohamed", "06 ## ## ## ##", "fakri-12" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 13, "Code : {id - 1}", 3, 2, 3, 5, 15, 1, "13 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 13", "بعد الأهداف الخاصة : 13", "بعد النتائج المرتقبة : 13" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 15, "Code : {id - 1}", 3, 3, 1, 9, 4, 2, "15 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 15", "بعد الأهداف الخاصة : 15", "بعد النتائج المرتقبة : 15" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 26, "Code : {id - 1}", 3, 3, 3, 9, 21, 2, "26 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 26", "بعد الأهداف الخاصة : 26", "بعد النتائج المرتقبة : 26" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 28, "Code : {id - 1}", 1, 2, 1, 9, 4, 1, "28 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 28", "بعد الأهداف الخاصة : 28", "بعد النتائج المرتقبة : 28" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 45, "Code : {id - 1}", 3, 2, 3, 9, 24, 1, "45 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 45", "بعد الأهداف الخاصة : 45", "بعد النتائج المرتقبة : 45" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 48, "Code : {id - 1}", 1, 3, 1, 9, 5, 2, "48 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 48", "بعد الأهداف الخاصة : 48", "بعد النتائج المرتقبة : 48" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 33, "Code : {id - 1}", 3, 3, 3, 10, 22, 3, "33 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 33", "بعد الأهداف الخاصة : 33", "بعد النتائج المرتقبة : 33" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 36, "Code : {id - 1}", 3, 1, 1, 10, 15, 1, "36 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 36", "بعد الأهداف الخاصة : 36", "بعد النتائج المرتقبة : 36" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 49, "Code : {id - 1}", 1, 3, 3, 10, 5, 2, "49 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 49", "بعد الأهداف الخاصة : 49", "بعد النتائج المرتقبة : 49" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 4, "Code : {id - 1}", 3, 2, 3, 11, 20, 3, "4 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 4", "بعد الأهداف الخاصة : 4", "بعد النتائج المرتقبة : 4" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 8, "Code : {id - 1}", 4, 1, 3, 11, 19, 2, "8 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 8", "بعد الأهداف الخاصة : 8", "بعد النتائج المرتقبة : 8" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 11, "Code : {id - 1}", 2, 3, 1, 11, 15, 2, "11 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 11", "بعد الأهداف الخاصة : 11", "بعد النتائج المرتقبة : 11" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 17, "Code : {id - 1}", 1, 3, 3, 11, 14, 3, "17 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 17", "بعد الأهداف الخاصة : 17", "بعد النتائج المرتقبة : 17" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 25, "Code : {id - 1}", 4, 2, 3, 11, 12, 2, "25 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 25", "بعد الأهداف الخاصة : 25", "بعد النتائج المرتقبة : 25" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 30, "Code : {id - 1}", 3, 3, 2, 11, 20, 2, "30 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 30", "بعد الأهداف الخاصة : 30", "بعد النتائج المرتقبة : 30" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 31, "Code : {id - 1}", 3, 3, 1, 11, 23, 3, "31 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 31", "بعد الأهداف الخاصة : 31", "بعد النتائج المرتقبة : 31" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 39, "Code : {id - 1}", 4, 1, 2, 11, 20, 1, "39 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 39", "بعد الأهداف الخاصة : 39", "بعد النتائج المرتقبة : 39" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 43, "Code : {id - 1}", 1, 3, 1, 11, 14, 3, "43 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 43", "بعد الأهداف الخاصة : 43", "بعد النتائج المرتقبة : 43" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 14, "Code : {id - 1}", 2, 3, 1, 12, 6, 3, "14 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 14", "بعد الأهداف الخاصة : 14", "بعد النتائج المرتقبة : 14" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 19, "Code : {id - 1}", 3, 2, 1, 12, 7, 3, "19 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 19", "بعد الأهداف الخاصة : 19", "بعد النتائج المرتقبة : 19" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 21, "Code : {id - 1}", 2, 1, 2, 12, 14, 2, "21 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 21", "بعد الأهداف الخاصة : 21", "بعد النتائج المرتقبة : 21" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 32, "Code : {id - 1}", 3, 3, 3, 12, 11, 3, "32 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 32", "بعد الأهداف الخاصة : 32", "بعد النتائج المرتقبة : 32" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 9, "Code : {id - 1}", 3, 3, 1, 9, 6, 1, "9 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 9", "بعد الأهداف الخاصة : 9", "بعد النتائج المرتقبة : 9" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 7, "Code : {id - 1}", 1, 1, 1, 9, 22, 3, "7 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 7", "بعد الأهداف الخاصة : 7", "بعد النتائج المرتقبة : 7" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 1, "Code : {id - 1}", 2, 2, 2, 9, 18, 3, "1 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 1", "بعد الأهداف الخاصة : 1", "بعد النتائج المرتقبة : 1" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 46, "Code : {id - 1}", 4, 2, 1, 8, 3, 3, "46 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 46", "بعد الأهداف الخاصة : 46", "بعد النتائج المرتقبة : 46" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 18, "Code : {id - 1}", 3, 3, 3, 5, 1, 1, "18 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 18", "بعد الأهداف الخاصة : 18", "بعد النتائج المرتقبة : 18" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 50, "Code : {id - 1}", 1, 1, 2, 5, 7, 2, "50 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 50", "بعد الأهداف الخاصة : 50", "بعد النتائج المرتقبة : 50" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 3, "Code : {id - 1}", 1, 1, 2, 6, 24, 1, "3 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 3", "بعد الأهداف الخاصة : 3", "بعد النتائج المرتقبة : 3" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 10, "Code : {id - 1}", 4, 1, 1, 6, 14, 2, "10 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 10", "بعد الأهداف الخاصة : 10", "بعد النتائج المرتقبة : 10" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 12, "Code : {id - 1}", 4, 3, 3, 6, 6, 1, "12 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 12", "بعد الأهداف الخاصة : 12", "بعد النتائج المرتقبة : 12" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 22, "Code : {id - 1}", 4, 3, 2, 6, 4, 1, "22 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 22", "بعد الأهداف الخاصة : 22", "بعد النتائج المرتقبة : 22" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 37, "Code : {id - 1}", 4, 1, 3, 6, 21, 1, "37 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 37", "بعد الأهداف الخاصة : 37", "بعد النتائج المرتقبة : 37" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 40, "Code : {id - 1}", 1, 1, 3, 6, 17, 1, "40 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 40", "بعد الأهداف الخاصة : 40", "بعد النتائج المرتقبة : 40" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 42, "Code : {id - 1}", 2, 3, 3, 6, 14, 1, "42 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 42", "بعد الأهداف الخاصة : 42", "بعد النتائج المرتقبة : 42" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 47, "Code : {id - 1}", 2, 1, 2, 6, 1, 1, "47 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 47", "بعد الأهداف الخاصة : 47", "بعد النتائج المرتقبة : 47" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 35, "Code : {id - 1}", 1, 1, 1, 12, 1, 3, "35 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 35", "بعد الأهداف الخاصة : 35", "بعد النتائج المرتقبة : 35" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 2, "Code : {id - 1}", 4, 3, 2, 7, 17, 3, "2 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 2", "بعد الأهداف الخاصة : 2", "بعد النتائج المرتقبة : 2" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 29, "Code : {id - 1}", 1, 2, 3, 7, 10, 3, "29 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 29", "بعد الأهداف الخاصة : 29", "بعد النتائج المرتقبة : 29" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 44, "Code : {id - 1}", 2, 3, 2, 7, 6, 3, "44 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 44", "بعد الأهداف الخاصة : 44", "بعد النتائج المرتقبة : 44" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 5, "Code : {id - 1}", 4, 3, 1, 8, 3, 2, "5 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 5", "بعد الأهداف الخاصة : 5", "بعد النتائج المرتقبة : 5" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 6, "Code : {id - 1}", 2, 2, 1, 8, 5, 3, "6 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 6", "بعد الأهداف الخاصة : 6", "بعد النتائج المرتقبة : 6" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 16, "Code : {id - 1}", 3, 1, 2, 8, 4, 1, "16 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 16", "بعد الأهداف الخاصة : 16", "بعد النتائج المرتقبة : 16" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 23, "Code : {id - 1}", 1, 1, 3, 8, 11, 3, "23 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 23", "بعد الأهداف الخاصة : 23", "بعد النتائج المرتقبة : 23" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 24, "Code : {id - 1}", 3, 2, 3, 8, 23, 2, "24 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 24", "بعد الأهداف الخاصة : 24", "بعد النتائج المرتقبة : 24" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 27, "Code : {id - 1}", 4, 3, 3, 8, 1, 2, "27 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 27", "بعد الأهداف الخاصة : 27", "بعد النتائج المرتقبة : 27" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 34, "Code : {id - 1}", 1, 2, 1, 8, 16, 2, "34 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 34", "بعد الأهداف الخاصة : 34", "بعد النتائج المرتقبة : 34" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 38, "Code : {id - 1}", 2, 2, 3, 8, 13, 2, "38 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 38", "بعد الأهداف الخاصة : 38", "بعد النتائج المرتقبة : 38" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 20, "Code : {id - 1}", 1, 1, 1, 7, 5, 3, "20 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 20", "بعد الأهداف الخاصة : 20", "بعد النتائج المرتقبة : 20" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 41, "Code : {id - 1}", 3, 1, 1, 12, 12, 1, "41 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 41", "بعد الأهداف الخاصة : 41", "بعد النتائج المرتقبة : 41" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 27, "[\"2028\", \"2029\", \"2030\"]", 13, "26 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 19, "[\"2025\", \"2026\", \"2027\"]", 44, "18 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 28, "[\"2028\", \"2029\", \"2030\"]", 29, "27 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 22, "[\"2029\", \"2030\", \"2031\"]", 29, "21 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 12, "[\"2023\", \"2024\", \"2025\"]", 36, "11 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 33, "[\"2024\", \"2025\", \"2026\"]", 36, "32 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 38, "[\"2025\", \"2026\", \"2027\"]", 36, "37 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 15, "[\"2025\", \"2026\", \"2027\"]", 20, "14 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 34, "[\"2027\", \"2028\", \"2029\"]", 44, "33 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 35, "[\"2024\", \"2025\", \"2026\"]", 2, "34 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 20, "[\"2029\", \"2030\", \"2031\"]", 42, "19 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 4, "[\"2027\", \"2028\", \"2029\"]", 42, "3 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 2, "[\"2027\", \"2028\", \"2029\"]", 25, "1 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 41, "[\"2019\", \"2020\", \"2021\"]", 25, "40 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 50, "[\"2018\", \"2019\", \"2020\"]", 25, "49 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 44, "[\"2028\", \"2029\", \"2030\"]", 37, "43 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 31, "[\"2025\", \"2026\", \"2027\"]", 37, "30 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 9, "[\"2028\", \"2029\", \"2030\"]", 17, "8 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 7, "[\"2026\", \"2027\", \"2028\"]", 37, "6 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 47, "[\"2019\", \"2020\", \"2021\"]", 48, "46 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 29, "[\"2027\", \"2028\", \"2029\"]", 5, "28 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 48, "[\"2020\", \"2021\", \"2022\"]", 34, "47 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 45, "[\"2029\", \"2030\", \"2031\"]", 34, "44 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 26, "[\"2020\", \"2021\", \"2022\"]", 34, "25 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 13, "[\"2026\", \"2027\", \"2028\"]", 34, "12 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 8, "[\"2029\", \"2030\", \"2031\"]", 46, "7 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 37, "[\"2022\", \"2023\", \"2024\"]", 27, "36 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 25, "[\"2029\", \"2030\", \"2031\"]", 27, "24 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 32, "[\"2020\", \"2021\", \"2022\"]", 48, "31 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 10, "[\"2022\", \"2023\", \"2024\"]", 1, "9 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 24, "[\"2024\", \"2025\", \"2026\"]", 7, "23 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 42, "[\"2019\", \"2020\", \"2021\"]", 7, "41 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 1, "[\"2027\", \"2028\", \"2029\"]", 16, "0 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 23, "[\"2020\", \"2021\", \"2022\"]", 26, "22 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 46, "[\"2019\", \"2020\", \"2021\"]", 28, "45 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 39, "[\"2021\", \"2022\", \"2023\"]", 45, "38 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 18, "[\"2020\", \"2021\", \"2022\"]", 48, "17 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 21, "[\"2022\", \"2023\", \"2024\"]", 1, "20 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 16, "[\"2021\", \"2022\", \"2023\"]", 39, "15 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 6, "[\"2023\", \"2024\", \"2025\"]", 38, "5 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 30, "[\"2027\", \"2028\", \"2029\"]", 50, "29 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 11, "[\"2026\", \"2027\", \"2028\"]", 12, "10 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 3, "[\"2025\", \"2026\", \"2027\"]", 12, "2 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 43, "[\"2019\", \"2020\", \"2021\"]", 32, "42 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 40, "[\"2024\", \"2025\", \"2026\"]", 12, "39 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 17, "[\"2029\", \"2030\", \"2031\"]", 41, "16 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 5, "[\"2022\", \"2023\", \"2024\"]", 43, "4 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 36, "[\"2021\", \"2022\", \"2023\"]", 50, "35 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 14, "[\"2025\", \"2026\", \"2027\"]", 3, "13 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 49, "[\"2028\", \"2029\", \"2030\"]", 50, "48 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 127, new DateTime(2020, 3, 13, 14, 38, 59, 174, DateTimeKind.Local).AddTicks(6385), 4, 26, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 5, new DateTime(2020, 4, 6, 18, 21, 38, 966, DateTimeKind.Local).AddTicks(3326), 5, 26, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 168, new DateTime(2019, 8, 18, 14, 49, 50, 622, DateTimeKind.Local).AddTicks(6240), 6, 15, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 108, new DateTime(2020, 3, 31, 18, 53, 34, 392, DateTimeKind.Local).AddTicks(1862), 4, 26, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 194, new DateTime(2019, 9, 15, 7, 30, 15, 699, DateTimeKind.Local).AddTicks(2836), 4, 9, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 81, new DateTime(2020, 5, 24, 0, 59, 31, 682, DateTimeKind.Local).AddTicks(8765), 2, 9, "55" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 51, new DateTime(2020, 8, 10, 10, 49, 30, 893, DateTimeKind.Local).AddTicks(6174), 5, 9, "90" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 91, new DateTime(2019, 9, 20, 18, 27, 56, 170, DateTimeKind.Local).AddTicks(9728), 3, 19, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 39, new DateTime(2019, 10, 27, 20, 27, 56, 291, DateTimeKind.Local).AddTicks(1295), 1, 9, "93" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 13, new DateTime(2019, 12, 14, 3, 17, 3, 854, DateTimeKind.Local).AddTicks(5546), 2, 45, "90" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 35, new DateTime(2019, 8, 24, 11, 15, 6, 49, DateTimeKind.Local).AddTicks(9431), 5, 45, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 135, new DateTime(2019, 10, 10, 12, 55, 42, 316, DateTimeKind.Local).AddTicks(41), 4, 45, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 137, new DateTime(2020, 2, 2, 4, 0, 13, 422, DateTimeKind.Local).AddTicks(5080), 2, 45, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 30, new DateTime(2019, 8, 31, 13, 26, 42, 777, DateTimeKind.Local).AddTicks(6159), 3, 19, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 130, new DateTime(2019, 11, 5, 13, 29, 44, 157, DateTimeKind.Local).AddTicks(5883), 1, 14, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 107, new DateTime(2020, 7, 8, 14, 21, 22, 72, DateTimeKind.Local).AddTicks(1948), 5, 14, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 78, new DateTime(2019, 11, 24, 2, 4, 11, 347, DateTimeKind.Local).AddTicks(8493), 4, 14, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 72, new DateTime(2019, 12, 12, 23, 12, 11, 963, DateTimeKind.Local).AddTicks(3339), 5, 48, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 132, new DateTime(2020, 7, 29, 5, 5, 3, 630, DateTimeKind.Local).AddTicks(882), 5, 48, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 182, new DateTime(2019, 10, 4, 0, 35, 19, 801, DateTimeKind.Local).AddTicks(4204), 6, 48, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 195, new DateTime(2020, 8, 4, 15, 9, 48, 266, DateTimeKind.Local).AddTicks(2184), 4, 48, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 84, new DateTime(2020, 5, 24, 1, 36, 23, 751, DateTimeKind.Local).AddTicks(284), 1, 28, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 120, new DateTime(2020, 3, 2, 6, 25, 28, 326, DateTimeKind.Local).AddTicks(3741), 4, 39, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 166, new DateTime(2020, 2, 25, 4, 10, 37, 317, DateTimeKind.Local).AddTicks(8192), 6, 7, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 180, new DateTime(2019, 11, 6, 0, 8, 7, 694, DateTimeKind.Local).AddTicks(2766), 4, 7, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 87, new DateTime(2020, 8, 10, 13, 14, 56, 253, DateTimeKind.Local).AddTicks(9521), 4, 38, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 113, new DateTime(2020, 6, 7, 15, 42, 12, 645, DateTimeKind.Local).AddTicks(3336), 5, 38, "35" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 117, new DateTime(2019, 12, 15, 3, 12, 9, 677, DateTimeKind.Local).AddTicks(1456), 4, 38, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 86, new DateTime(2019, 12, 7, 6, 46, 33, 948, DateTimeKind.Local).AddTicks(253), 6, 41, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 77, new DateTime(2019, 8, 18, 22, 25, 40, 576, DateTimeKind.Local).AddTicks(9918), 3, 41, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 10, new DateTime(2020, 7, 19, 13, 3, 3, 790, DateTimeKind.Local).AddTicks(7532), 1, 41, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 152, new DateTime(2019, 11, 23, 21, 56, 35, 406, DateTimeKind.Local).AddTicks(8042), 1, 38, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 159, new DateTime(2019, 12, 17, 23, 38, 36, 772, DateTimeKind.Local).AddTicks(5289), 1, 38, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 175, new DateTime(2019, 11, 18, 0, 40, 31, 542, DateTimeKind.Local).AddTicks(247), 5, 38, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 158, new DateTime(2019, 11, 3, 10, 15, 22, 306, DateTimeKind.Local).AddTicks(6563), 6, 35, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 2, new DateTime(2020, 3, 3, 14, 23, 44, 784, DateTimeKind.Local).AddTicks(3968), 3, 46, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 191, new DateTime(2020, 1, 24, 22, 56, 57, 840, DateTimeKind.Local).AddTicks(13), 2, 32, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 128, new DateTime(2019, 11, 29, 13, 23, 9, 683, DateTimeKind.Local).AddTicks(6838), 1, 32, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 61, new DateTime(2020, 3, 7, 10, 19, 2, 533, DateTimeKind.Local).AddTicks(9647), 3, 46, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 148, new DateTime(2019, 11, 10, 18, 26, 38, 618, DateTimeKind.Local).AddTicks(9121), 4, 41, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 188, new DateTime(2020, 6, 20, 19, 30, 31, 64, DateTimeKind.Local).AddTicks(5304), 5, 46, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 192, new DateTime(2020, 7, 18, 9, 19, 3, 449, DateTimeKind.Local).AddTicks(4734), 5, 46, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 153, new DateTime(2020, 5, 30, 7, 23, 56, 803, DateTimeKind.Local).AddTicks(5109), 4, 21, "37" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 100, new DateTime(2020, 2, 28, 16, 0, 10, 522, DateTimeKind.Local).AddTicks(3083), 4, 1, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 179, new DateTime(2019, 10, 3, 10, 27, 46, 118, DateTimeKind.Local).AddTicks(5048), 6, 19, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 112, new DateTime(2020, 7, 27, 16, 15, 23, 83, DateTimeKind.Local).AddTicks(7019), 5, 19, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 7, new DateTime(2020, 6, 6, 19, 47, 7, 118, DateTimeKind.Local).AddTicks(842), 5, 7, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 8, new DateTime(2019, 12, 16, 4, 4, 8, 344, DateTimeKind.Local).AddTicks(3983), 3, 7, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 17, new DateTime(2020, 1, 27, 11, 50, 11, 113, DateTimeKind.Local).AddTicks(2118), 6, 33, "73" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 176, new DateTime(2019, 8, 22, 7, 16, 39, 633, DateTimeKind.Local).AddTicks(4358), 4, 7, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 24, new DateTime(2020, 3, 12, 1, 11, 36, 287, DateTimeKind.Local).AddTicks(7126), 1, 9, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 32, new DateTime(2020, 3, 26, 19, 45, 11, 692, DateTimeKind.Local).AddTicks(3148), 2, 14, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 29, new DateTime(2020, 8, 7, 1, 16, 56, 601, DateTimeKind.Local).AddTicks(913), 2, 33, "54" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 26, new DateTime(2020, 2, 14, 5, 6, 13, 285, DateTimeKind.Local).AddTicks(2371), 5, 33, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 181, new DateTime(2020, 6, 13, 0, 34, 8, 551, DateTimeKind.Local).AddTicks(5539), 4, 11, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 187, new DateTime(2020, 1, 5, 5, 8, 17, 469, DateTimeKind.Local).AddTicks(1500), 6, 11, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 45, new DateTime(2020, 6, 24, 15, 43, 53, 864, DateTimeKind.Local).AddTicks(2775), 4, 43, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 41, new DateTime(2019, 8, 21, 11, 58, 47, 452, DateTimeKind.Local).AddTicks(3911), 5, 17, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 199, new DateTime(2020, 1, 6, 10, 59, 36, 486, DateTimeKind.Local).AddTicks(52), 2, 39, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 133, new DateTime(2020, 5, 23, 15, 33, 11, 767, DateTimeKind.Local).AddTicks(5475), 4, 17, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 198, new DateTime(2019, 11, 5, 22, 49, 23, 882, DateTimeKind.Local).AddTicks(8687), 1, 39, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 19, new DateTime(2019, 11, 27, 8, 14, 26, 522, DateTimeKind.Local).AddTicks(247), 3, 25, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 22, new DateTime(2019, 10, 12, 5, 15, 44, 470, DateTimeKind.Local).AddTicks(5050), 5, 25, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 48, new DateTime(2019, 8, 21, 9, 9, 6, 979, DateTimeKind.Local).AddTicks(4325), 2, 25, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 101, new DateTime(2019, 9, 11, 0, 6, 57, 481, DateTimeKind.Local).AddTicks(9480), 5, 25, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 145, new DateTime(2019, 12, 23, 10, 35, 20, 684, DateTimeKind.Local).AddTicks(3657), 5, 25, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 193, new DateTime(2020, 4, 16, 10, 21, 39, 898, DateTimeKind.Local).AddTicks(7453), 2, 25, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 21, new DateTime(2019, 10, 6, 12, 29, 0, 931, DateTimeKind.Local).AddTicks(785), 2, 30, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 52, new DateTime(2019, 9, 8, 16, 39, 0, 759, DateTimeKind.Local).AddTicks(8911), 3, 30, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 56, new DateTime(2019, 11, 11, 5, 47, 19, 270, DateTimeKind.Local).AddTicks(4184), 1, 30, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 186, new DateTime(2019, 10, 29, 23, 58, 35, 64, DateTimeKind.Local).AddTicks(7216), 2, 39, "74" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 151, new DateTime(2019, 9, 25, 17, 39, 38, 619, DateTimeKind.Local).AddTicks(8879), 4, 39, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 58, new DateTime(2019, 10, 19, 14, 46, 31, 332, DateTimeKind.Local).AddTicks(4545), 4, 30, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 136, new DateTime(2019, 9, 25, 3, 38, 16, 957, DateTimeKind.Local).AddTicks(6288), 1, 30, "83" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 167, new DateTime(2020, 8, 6, 20, 52, 8, 871, DateTimeKind.Local).AddTicks(1687), 4, 30, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 174, new DateTime(2020, 4, 19, 7, 54, 46, 466, DateTimeKind.Local).AddTicks(6143), 2, 30, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 38, new DateTime(2019, 11, 1, 20, 31, 52, 643, DateTimeKind.Local).AddTicks(547), 5, 31, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 111, new DateTime(2020, 7, 4, 8, 39, 11, 337, DateTimeKind.Local).AddTicks(8465), 4, 31, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 173, new DateTime(2020, 3, 18, 12, 33, 59, 826, DateTimeKind.Local).AddTicks(1620), 1, 31, "93" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 129, new DateTime(2020, 6, 25, 14, 27, 6, 270, DateTimeKind.Local).AddTicks(2801), 2, 11, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 6, new DateTime(2020, 2, 10, 13, 4, 2, 240, DateTimeKind.Local).AddTicks(8023), 6, 14, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 115, new DateTime(2020, 4, 28, 5, 18, 37, 316, DateTimeKind.Local).AddTicks(146), 3, 11, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 134, new DateTime(2019, 10, 28, 5, 27, 17, 716, DateTimeKind.Local).AddTicks(4786), 3, 8, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 42, new DateTime(2020, 5, 16, 4, 33, 35, 765, DateTimeKind.Local).AddTicks(3203), 6, 39, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 33, new DateTime(2020, 2, 9, 10, 31, 8, 135, DateTimeKind.Local).AddTicks(9026), 6, 33, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 54, new DateTime(2020, 7, 9, 17, 47, 54, 544, DateTimeKind.Local).AddTicks(6356), 1, 33, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 125, new DateTime(2019, 11, 8, 14, 51, 41, 975, DateTimeKind.Local).AddTicks(5679), 4, 33, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 1, new DateTime(2020, 7, 4, 13, 18, 35, 18, DateTimeKind.Local).AddTicks(5171), 6, 14, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 171, new DateTime(2020, 3, 9, 12, 47, 35, 166, DateTimeKind.Local).AddTicks(4563), 2, 43, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 170, new DateTime(2019, 12, 20, 8, 14, 56, 73, DateTimeKind.Local).AddTicks(8481), 5, 43, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 143, new DateTime(2019, 12, 8, 18, 15, 40, 7, DateTimeKind.Local).AddTicks(4698), 1, 43, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 80, new DateTime(2019, 10, 8, 21, 50, 50, 941, DateTimeKind.Local).AddTicks(3772), 2, 36, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 139, new DateTime(2019, 10, 27, 15, 56, 29, 931, DateTimeKind.Local).AddTicks(8099), 4, 36, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 142, new DateTime(2019, 11, 17, 18, 56, 19, 343, DateTimeKind.Local).AddTicks(7859), 6, 43, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 89, new DateTime(2019, 10, 3, 13, 3, 15, 820, DateTimeKind.Local).AddTicks(8196), 6, 49, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 93, new DateTime(2020, 7, 21, 18, 14, 34, 467, DateTimeKind.Local).AddTicks(6997), 3, 49, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 144, new DateTime(2020, 8, 3, 17, 24, 12, 881, DateTimeKind.Local).AddTicks(2252), 6, 49, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 3, new DateTime(2019, 12, 26, 23, 27, 37, 623, DateTimeKind.Local).AddTicks(5488), 1, 4, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 4, new DateTime(2019, 11, 28, 14, 53, 17, 687, DateTimeKind.Local).AddTicks(5225), 2, 4, "67" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 75, new DateTime(2020, 5, 12, 5, 30, 12, 230, DateTimeKind.Local).AddTicks(3922), 1, 4, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 96, new DateTime(2020, 6, 26, 17, 35, 49, 153, DateTimeKind.Local).AddTicks(8621), 1, 4, "37" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 99, new DateTime(2020, 3, 24, 9, 13, 5, 335, DateTimeKind.Local).AddTicks(43), 6, 4, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 79, new DateTime(2019, 8, 30, 6, 9, 7, 660, DateTimeKind.Local).AddTicks(9825), 2, 38, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 64, new DateTime(2020, 7, 16, 13, 8, 3, 362, DateTimeKind.Local).AddTicks(5341), 3, 43, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 200, new DateTime(2020, 2, 27, 15, 28, 22, 600, DateTimeKind.Local).AddTicks(9190), 1, 4, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 31, new DateTime(2020, 2, 6, 3, 40, 37, 168, DateTimeKind.Local).AddTicks(5826), 6, 8, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 76, new DateTime(2019, 11, 14, 1, 56, 54, 794, DateTimeKind.Local).AddTicks(6719), 4, 8, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 85, new DateTime(2020, 2, 14, 8, 41, 1, 377, DateTimeKind.Local).AddTicks(8869), 4, 8, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 189, new DateTime(2020, 2, 19, 17, 51, 10, 728, DateTimeKind.Local).AddTicks(793), 6, 8, "57" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 116, new DateTime(2020, 5, 26, 16, 0, 0, 112, DateTimeKind.Local).AddTicks(3305), 4, 4, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 138, new DateTime(2020, 2, 10, 22, 31, 44, 338, DateTimeKind.Local).AddTicks(4559), 6, 46, "74" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 185, new DateTime(2019, 9, 18, 5, 6, 33, 225, DateTimeKind.Local).AddTicks(2143), 5, 47, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 47, new DateTime(2019, 9, 26, 5, 3, 5, 844, DateTimeKind.Local).AddTicks(2811), 5, 40, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 119, new DateTime(2019, 9, 11, 19, 50, 19, 315, DateTimeKind.Local).AddTicks(1160), 3, 40, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 149, new DateTime(2020, 5, 17, 20, 29, 46, 633, DateTimeKind.Local).AddTicks(383), 3, 40, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 160, new DateTime(2019, 10, 24, 4, 19, 0, 359, DateTimeKind.Local).AddTicks(2987), 2, 40, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 183, new DateTime(2020, 6, 14, 13, 5, 26, 907, DateTimeKind.Local).AddTicks(1509), 4, 40, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 28, new DateTime(2019, 8, 16, 12, 0, 11, 258, DateTimeKind.Local).AddTicks(5155), 2, 42, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 71, new DateTime(2020, 7, 29, 13, 54, 7, 887, DateTimeKind.Local).AddTicks(2818), 4, 42, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 147, new DateTime(2020, 1, 22, 6, 26, 15, 938, DateTimeKind.Local).AddTicks(3859), 5, 42, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 163, new DateTime(2020, 5, 24, 9, 2, 48, 46, DateTimeKind.Local).AddTicks(9157), 2, 42, "11" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 9, new DateTime(2020, 5, 20, 2, 53, 26, 511, DateTimeKind.Local).AddTicks(7631), 4, 47, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 70, new DateTime(2020, 4, 2, 10, 9, 39, 671, DateTimeKind.Local).AddTicks(2899), 2, 47, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 172, new DateTime(2019, 10, 26, 9, 41, 28, 6, DateTimeKind.Local).AddTicks(6256), 5, 47, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 165, new DateTime(2020, 5, 11, 8, 59, 56, 784, DateTimeKind.Local).AddTicks(8823), 3, 37, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 12, new DateTime(2019, 12, 15, 4, 41, 21, 332, DateTimeKind.Local).AddTicks(2130), 3, 2, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 55, new DateTime(2020, 7, 11, 18, 37, 38, 583, DateTimeKind.Local).AddTicks(4117), 6, 2, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 65, new DateTime(2020, 3, 6, 12, 8, 47, 150, DateTimeKind.Local).AddTicks(5617), 1, 2, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 83, new DateTime(2019, 10, 9, 22, 51, 41, 31, DateTimeKind.Local).AddTicks(1404), 3, 2, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 98, new DateTime(2020, 8, 10, 19, 10, 27, 937, DateTimeKind.Local).AddTicks(6703), 3, 2, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 110, new DateTime(2020, 6, 2, 10, 58, 36, 694, DateTimeKind.Local).AddTicks(3650), 3, 2, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 27, new DateTime(2020, 2, 15, 13, 15, 40, 25, DateTimeKind.Local).AddTicks(6237), 4, 20, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 62, new DateTime(2020, 2, 18, 8, 25, 43, 421, DateTimeKind.Local).AddTicks(530), 1, 20, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 122, new DateTime(2020, 3, 9, 20, 3, 16, 83, DateTimeKind.Local).AddTicks(1464), 6, 20, "55" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 23, new DateTime(2019, 12, 9, 7, 21, 25, 779, DateTimeKind.Local).AddTicks(1126), 5, 29, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 49, new DateTime(2019, 11, 13, 19, 33, 29, 680, DateTimeKind.Local).AddTicks(5365), 2, 29, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 109, new DateTime(2020, 5, 19, 18, 14, 44, 929, DateTimeKind.Local).AddTicks(8267), 1, 29, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 14, new DateTime(2020, 4, 15, 10, 18, 47, 783, DateTimeKind.Local).AddTicks(8238), 1, 44, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 34, new DateTime(2019, 9, 25, 8, 10, 14, 225, DateTimeKind.Local).AddTicks(4078), 3, 2, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 20, new DateTime(2019, 11, 3, 8, 11, 49, 208, DateTimeKind.Local).AddTicks(4557), 1, 44, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 124, new DateTime(2019, 8, 22, 4, 15, 4, 201, DateTimeKind.Local).AddTicks(5646), 5, 37, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 40, new DateTime(2020, 6, 11, 18, 16, 33, 939, DateTimeKind.Local).AddTicks(1924), 6, 37, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 25, new DateTime(2020, 7, 18, 17, 24, 42, 869, DateTimeKind.Local).AddTicks(7016), 3, 13, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 37, new DateTime(2019, 8, 26, 5, 29, 23, 625, DateTimeKind.Local).AddTicks(72), 1, 13, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 97, new DateTime(2019, 12, 25, 5, 43, 26, 861, DateTimeKind.Local).AddTicks(372), 2, 13, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 162, new DateTime(2019, 12, 30, 2, 7, 24, 828, DateTimeKind.Local).AddTicks(3961), 4, 13, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 16, new DateTime(2019, 12, 2, 15, 12, 13, 648, DateTimeKind.Local).AddTicks(8709), 4, 18, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 60, new DateTime(2020, 4, 19, 2, 57, 50, 793, DateTimeKind.Local).AddTicks(3669), 5, 18, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 197, new DateTime(2020, 5, 4, 11, 47, 13, 577, DateTimeKind.Local).AddTicks(1249), 5, 18, "11" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 44, new DateTime(2019, 10, 6, 21, 16, 49, 411, DateTimeKind.Local).AddTicks(8612), 2, 50, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 118, new DateTime(2019, 11, 18, 7, 14, 8, 611, DateTimeKind.Local).AddTicks(1966), 6, 50, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 123, new DateTime(2020, 1, 9, 16, 15, 59, 480, DateTimeKind.Local).AddTicks(2213), 1, 50, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 140, new DateTime(2019, 10, 17, 3, 44, 48, 423, DateTimeKind.Local).AddTicks(3047), 1, 50, "83" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 150, new DateTime(2019, 9, 7, 4, 35, 52, 371, DateTimeKind.Local).AddTicks(3767), 5, 50, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 53, new DateTime(2020, 7, 19, 21, 7, 24, 180, DateTimeKind.Local).AddTicks(4601), 1, 37, "95" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 177, new DateTime(2020, 8, 8, 23, 39, 11, 189, DateTimeKind.Local).AddTicks(4678), 1, 50, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 46, new DateTime(2019, 9, 3, 1, 45, 34, 505, DateTimeKind.Local).AddTicks(2573), 2, 10, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 74, new DateTime(2019, 10, 19, 7, 56, 47, 250, DateTimeKind.Local).AddTicks(9662), 6, 10, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 82, new DateTime(2020, 1, 2, 10, 57, 42, 300, DateTimeKind.Local).AddTicks(2519), 4, 10, "16" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 169, new DateTime(2019, 12, 15, 16, 1, 40, 971, DateTimeKind.Local).AddTicks(444), 3, 10, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 18, new DateTime(2020, 4, 1, 9, 14, 38, 188, DateTimeKind.Local).AddTicks(8563), 3, 12, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 73, new DateTime(2020, 5, 24, 15, 59, 38, 912, DateTimeKind.Local).AddTicks(4625), 6, 12, "44" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 155, new DateTime(2020, 7, 12, 14, 59, 8, 762, DateTimeKind.Local).AddTicks(443), 5, 12, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 157, new DateTime(2019, 12, 30, 22, 10, 9, 977, DateTimeKind.Local).AddTicks(1276), 3, 12, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 161, new DateTime(2020, 6, 3, 8, 59, 36, 520, DateTimeKind.Local).AddTicks(6934), 5, 12, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 190, new DateTime(2020, 6, 20, 21, 59, 24, 478, DateTimeKind.Local).AddTicks(9669), 2, 12, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 92, new DateTime(2019, 12, 23, 16, 9, 52, 645, DateTimeKind.Local).AddTicks(6734), 2, 22, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 106, new DateTime(2020, 1, 4, 10, 41, 4, 860, DateTimeKind.Local).AddTicks(8364), 4, 22, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 94, new DateTime(2020, 6, 8, 16, 51, 14, 295, DateTimeKind.Local).AddTicks(9465), 4, 3, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 95, new DateTime(2020, 2, 2, 14, 38, 2, 251, DateTimeKind.Local).AddTicks(4641), 5, 44, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 196, new DateTime(2019, 8, 24, 15, 13, 33, 590, DateTimeKind.Local).AddTicks(6874), 5, 41, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 164, new DateTime(2019, 11, 9, 1, 40, 46, 888, DateTimeKind.Local).AddTicks(6045), 6, 24, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 68, new DateTime(2020, 5, 5, 23, 20, 57, 621, DateTimeKind.Local).AddTicks(276), 4, 6, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 105, new DateTime(2020, 7, 3, 3, 36, 24, 652, DateTimeKind.Local).AddTicks(968), 6, 6, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 121, new DateTime(2019, 12, 2, 4, 19, 6, 151, DateTimeKind.Local).AddTicks(24), 6, 24, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 50, new DateTime(2020, 4, 19, 12, 24, 15, 700, DateTimeKind.Local).AddTicks(6435), 1, 24, "59" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 131, new DateTime(2019, 9, 12, 18, 39, 25, 40, DateTimeKind.Local).AddTicks(5202), 2, 6, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 59, new DateTime(2020, 3, 15, 14, 45, 56, 205, DateTimeKind.Local).AddTicks(8711), 6, 6, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 15, new DateTime(2020, 7, 15, 9, 44, 14, 399, DateTimeKind.Local).AddTicks(9790), 1, 6, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 154, new DateTime(2020, 7, 24, 19, 27, 22, 383, DateTimeKind.Local).AddTicks(1463), 1, 6, "57" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 184, new DateTime(2020, 5, 27, 15, 24, 50, 140, DateTimeKind.Local).AddTicks(73), 2, 6, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 36, new DateTime(2020, 4, 18, 22, 44, 19, 161, DateTimeKind.Local).AddTicks(8924), 2, 27, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 69, new DateTime(2020, 6, 8, 3, 53, 3, 683, DateTimeKind.Local).AddTicks(9624), 6, 27, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 178, new DateTime(2020, 8, 11, 2, 41, 35, 239, DateTimeKind.Local).AddTicks(6285), 5, 5, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 90, new DateTime(2020, 5, 4, 3, 51, 19, 399, DateTimeKind.Local).AddTicks(9078), 1, 6, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 141, new DateTime(2020, 7, 13, 0, 5, 34, 644, DateTimeKind.Local).AddTicks(7976), 3, 27, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 156, new DateTime(2020, 4, 29, 23, 50, 40, 931, DateTimeKind.Local).AddTicks(2203), 6, 23, "93" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 66, new DateTime(2020, 7, 22, 6, 30, 44, 928, DateTimeKind.Local).AddTicks(1575), 1, 24, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 67, new DateTime(2019, 11, 24, 17, 52, 8, 897, DateTimeKind.Local).AddTicks(1676), 1, 34, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 104, new DateTime(2020, 4, 21, 4, 5, 45, 7, DateTimeKind.Local).AddTicks(1023), 1, 34, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 126, new DateTime(2019, 11, 8, 8, 24, 20, 475, DateTimeKind.Local).AddTicks(7918), 5, 5, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 88, new DateTime(2019, 11, 1, 15, 31, 19, 300, DateTimeKind.Local).AddTicks(2581), 6, 16, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 11, new DateTime(2019, 11, 13, 3, 19, 55, 395, DateTimeKind.Local).AddTicks(9669), 4, 5, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 146, new DateTime(2020, 4, 15, 0, 48, 11, 824, DateTimeKind.Local).AddTicks(6192), 3, 16, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 114, new DateTime(2019, 8, 29, 9, 41, 6, 569, DateTimeKind.Local).AddTicks(2802), 1, 44, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 43, new DateTime(2020, 1, 16, 2, 26, 28, 644, DateTimeKind.Local).AddTicks(6282), 4, 5, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 57, new DateTime(2019, 12, 1, 7, 15, 16, 133, DateTimeKind.Local).AddTicks(2104), 1, 23, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 103, new DateTime(2020, 4, 28, 8, 56, 28, 576, DateTimeKind.Local).AddTicks(9078), 6, 44, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 63, new DateTime(2020, 1, 20, 14, 51, 33, 625, DateTimeKind.Local).AddTicks(2096), 4, 16, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 102, new DateTime(2020, 4, 5, 10, 37, 4, 240, DateTimeKind.Local).AddTicks(4498), 1, 5, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 23, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 21, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 21, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 50, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 50, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 49, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 49, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 23, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 9, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 9, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 1 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 7, 2025, "6 التأثير لهدا الإنجاز", 27, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 8, 2027, "7 التأثير لهدا الإنجاز", 6, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 25, 2019, "24 التأثير لهدا الإنجاز", 6, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 23, 2022, "22 التأثير لهدا الإنجاز", 10, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 42, 2022, "41 التأثير لهدا الإنجاز", 10, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 12, 2029, "11 التأثير لهدا الإنجاز", 42, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 45, 2021, "44 التأثير لهدا الإنجاز", 42, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 14, 2028, "13 التأثير لهدا الإنجاز", 23, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 10, 2027, "9 التأثير لهدا الإنجاز", 46, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 4, 2021, "3 التأثير لهدا الإنجاز", 18, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 36, 2021, "35 التأثير لهدا الإنجاز", 18, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 50, 2024, "49 التأثير لهدا الإنجاز", 18, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 1, 2026, "0 التأثير لهدا الإنجاز", 32, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 6, 2021, "5 التأثير لهدا الإنجاز", 47, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 15, 2021, "14 التأثير لهدا الإنجاز", 47, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 37, 2019, "36 التأثير لهدا الإنجاز", 47, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 44, 2019, "43 التأثير لهدا الإنجاز", 38, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 9, 2025, "8 التأثير لهدا الإنجاز", 2, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 22, 2019, "21 التأثير لهدا الإنجاز", 41, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 26, 2018, "25 التأثير لهدا الإنجاز", 41, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 31, 2022, "30 التأثير لهدا الإنجاز", 41, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 39, 2029, "38 التأثير لهدا الإنجاز", 5, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 20, 2028, "19 التأثير لهدا الإنجاز", 45, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 2, 2025, "1 التأثير لهدا الإنجاز", 45, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 38, 2024, "37 التأثير لهدا الإنجاز", 13, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 19, 2028, "18 التأثير لهدا الإنجاز", 13, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 18, 2024, "17 التأثير لهدا الإنجاز", 27, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 13, 2028, "12 التأثير لهدا الإنجاز", 36, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 32, 2018, "31 التأثير لهدا الإنجاز", 36, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 3, 2021, "2 التأثير لهدا الإنجاز", 14, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 16, 2028, "15 التأثير لهدا الإنجاز", 14, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 11, 2027, "10 التأثير لهدا الإنجاز", 3, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 43, 2028, "42 التأثير لهدا الإنجاز", 3, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 29, 2026, "28 التأثير لهدا الإنجاز", 40, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 5, 2025, "4 التأثير لهدا الإنجاز", 7, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 27, 2020, "26 التأثير لهدا الإنجاز", 7, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 41, 2027, "40 التأثير لهدا الإنجاز", 17, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 46, 2027, "45 التأثير لهدا الإنجاز", 4, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 21, 2022, "20 التأثير لهدا الإنجاز", 28, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 30, 2029, "29 التأثير لهدا الإنجاز", 28, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 49, 2023, "48 التأثير لهدا الإنجاز", 19, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 28, 2026, "27 التأثير لهدا الإنجاز", 34, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 24, 2029, "23 التأثير لهدا الإنجاز", 29, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 34, 2018, "33 التأثير لهدا الإنجاز", 29, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 48, 2024, "47 التأثير لهدا الإنجاز", 29, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 17, 2028, "16 التأثير لهدا الإنجاز", 1, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 33, 2021, "32 التأثير لهدا الإنجاز", 1, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 40, 2023, "39 التأثير لهدا الإنجاز", 37, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 35, 2018, "34 التأثير لهدا الإنجاز", 15, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 47, 2021, "46 التأثير لهدا الإنجاز", 17, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز" });

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

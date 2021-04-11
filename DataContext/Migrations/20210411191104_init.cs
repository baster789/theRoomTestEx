using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
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
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AvailableFrom = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AvailableTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promocodes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPromocode",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PromocodeId = table.Column<int>(type: "int", nullable: false),
                    DateActivated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPromocode", x => new { x.PromocodeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPromocode_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPromocode_Promocodes_PromocodeId",
                        column: x => x.PromocodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "14690745-fca3-4cdc-b004-b7675b673472", "test@test.com", true, "Test", "Testos", false, null, null, "test@test.com", "AQAAAAEAACcQAAAAEPYcWBHhD42CYxjoXcT6v79Rma0qZjA3xbnIb8MGihlU++9b5nIswzjiCgi/yso2dw==", null, false, "ea8a5ff0-b920-43eb-840d-50f3953e3368", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Status" },
                values: new object[,]
                {
                    { 19, "Omnis veniam vero quidem dicta ut. Et itaque voluptatem distinctio est id id eligendi ad enim. Ipsa labore aliquid qui deserunt ut eaque deserunt illo.\n\nAlias natus libero aspernatur. Sed sit minima consectetur sed tempora. Et repellat porro. Autem pariatur necessitatibus harum dolorem fuga quod omnis aut. Minus eligendi molestias. Dolores non reiciendis quos recusandae possimus asperiores.\n\nEt cum repellat vitae. Illum consectetur quis dolorem officiis natus nam maxime. Quia enim autem qui. Exercitationem enim aut quia assumenda mollitia impedit perferendis architecto sunt. Sapiente autem dolorem.", "https://picsum.photos/120/120/?image=975", "Hand - Bradtke", true },
                    { 18, "Culpa aut perspiciatis. Laborum id et hic quia at sunt non velit. Officia voluptas esse et cupiditate nesciunt eum aut.\n\nMollitia maxime ut earum vel velit iure in. Temporibus non molestiae nemo. Error est non qui. Et amet voluptatem excepturi repellat est nisi ut cupiditate. Repudiandae et cumque dolores vel. Et quo quos dolores.\n\nEligendi asperiores velit aspernatur neque sed. Ab facere et quibusdam. Quae unde minima. Ut ipsum rem ratione. Sunt corporis dolores dolorem nostrum quos voluptatibus optio recusandae. Qui voluptatem qui.", "https://picsum.photos/120/120/?image=739", "Muller, Hessel and Denesik", true }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 17, "Voluptas et aut ut aperiam consequatur illum reprehenderit tempora. Laborum nesciunt sit rerum dolor aut amet blanditiis aut deleniti. Deserunt vel voluptate recusandae et est optio deleniti quia. Animi doloremque qui ea. Aut explicabo non accusamus consectetur hic. Pariatur iste recusandae et voluptatem id.\n\nVel quia et voluptatem minus. Optio esse autem. Sed repudiandae et. Aut consequuntur blanditiis cupiditate corporis repellat explicabo cupiditate. Nostrum dolorem odit provident. Repellat dolor excepturi sapiente provident voluptatem omnis minima non.", "https://picsum.photos/120/120/?image=528", "Larson Group" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Status" },
                values: new object[,]
                {
                    { 16, "Cumque sapiente ratione officiis expedita dolores necessitatibus. Provident odio sint adipisci cupiditate. Inventore repellendus iure veniam. Rerum quos repellat molestiae magnam ut.\n\nVoluptatem laborum libero consequatur dolores velit. Ipsa placeat est. Quaerat tenetur porro ad eligendi sed quaerat quia rem. Quidem quidem soluta consequatur non minus doloremque cumque eaque eveniet.\n\nNihil similique omnis et. Nihil dolor corrupti fugit nemo dolores in voluptatem. Et numquam nemo consequatur asperiores accusantium. Cupiditate nobis reiciendis. Odio delectus soluta consequatur nisi quo facere ipsum sunt magnam.", "https://picsum.photos/120/120/?image=74", "Pouros and Sons", true },
                    { 15, "Quis cupiditate iure rerum qui fugit est autem vero. Eum error non nihil dicta autem iusto qui. Vel vel exercitationem natus. Rerum quaerat voluptatem quaerat possimus velit quisquam itaque doloribus sit. Blanditiis rem doloremque officiis ipsam maiores ea. Nam nesciunt consequatur consectetur.\n\nExcepturi inventore dolores blanditiis error vel beatae sapiente. Repellat dolores at sint et distinctio. Dignissimos sunt excepturi qui et ut voluptate ut ut reprehenderit.\n\nEveniet assumenda culpa. Sed sed dolore. Tempora atque nihil quidem. Dolores perferendis doloremque id praesentium rem. Iste quod quo quibusdam soluta sint sunt est et. Iste quia ea repellat.", "https://picsum.photos/120/120/?image=535", "Runolfsdottir, Schoen and Towne", true },
                    { 14, "Sit dolores autem id est cumque qui itaque sit porro. Vitae aut explicabo occaecati qui. Id similique eos consequuntur autem similique est et ratione qui. Excepturi repellat ipsam iusto a quia ab non id sapiente. Dolor consequatur corporis alias molestiae itaque est mollitia in et.\n\nCum quis porro quibusdam facilis similique animi aut. Nemo sed molestiae voluptatem in accusamus consequuntur. Ipsa enim vitae sint quod reprehenderit vero qui autem eos.\n\nOmnis repellat asperiores. Corporis quidem et labore velit voluptate. Eos nesciunt quis accusamus totam debitis reiciendis accusantium. Est eligendi ex. Recusandae omnis recusandae reiciendis eos aut ut. Omnis omnis architecto nemo ut non.", "https://picsum.photos/120/120/?image=624", "Kunde, Kilback and Smith", true },
                    { 13, "Earum dolores consequatur unde tempore. Mollitia facilis voluptas. Nihil atque consectetur quas dolorem reprehenderit.\n\nCupiditate laborum officia molestiae voluptatum. Expedita enim assumenda voluptatem sint iure eveniet nostrum velit nulla. Quaerat et deserunt illum veniam deserunt. Soluta et et dolorem et recusandae.\n\nDucimus voluptatem consequatur qui impedit sit expedita. Necessitatibus commodi ut sunt qui autem sed magni quasi. Fugit error voluptas aut blanditiis. Voluptatem qui et vero.", "https://picsum.photos/120/120/?image=999", "Goldner - Tremblay", true },
                    { 12, "Nostrum vel enim corrupti. Nihil qui sit qui. Eos corrupti in amet sunt ducimus. Libero est illo.", "https://picsum.photos/120/120/?image=570", "Schmitt, Padberg and Hilpert", true },
                    { 20, "Fugiat voluptates qui hic non placeat ab. Sit iste itaque dicta magnam earum quaerat aliquid. Corrupti a et sed. Omnis repudiandae voluptas quo aut laboriosam consequatur corrupti. Placeat sapiente soluta odio eveniet quas qui nam sapiente. Quam reprehenderit molestias voluptatem impedit sunt eligendi error id deserunt.", "https://picsum.photos/120/120/?image=893", "Shanahan - Will", true },
                    { 11, "Neque fuga voluptas sit tempora omnis omnis. Incidunt omnis hic voluptatibus atque dignissimos et. Nulla non sit impedit quia. Placeat ut odio minus accusamus eligendi quo.\n\nVelit eos facilis qui est velit sed sequi voluptatem. Autem et tempore asperiores sint omnis mollitia eos. Deleniti ad est id nostrum rerum. Modi saepe dolores saepe eos facere deleniti repellendus sed nulla. Asperiores ut sed facilis illo eos asperiores non quisquam. Unde occaecati ut.\n\nIure ad quos est provident ex consequatur. Aut enim distinctio molestiae at eaque quia rerum praesentium. Et id et. Quo eius dolorem laborum omnis.", "https://picsum.photos/120/120/?image=353", "Beier Group", true },
                    { 9, "Ut aut distinctio soluta ut. Ab facilis repellendus. Quam maxime culpa suscipit sint. Non deserunt possimus sunt. Nisi aperiam quia laboriosam doloribus aut ullam.", "https://picsum.photos/120/120/?image=645", "Crist - Kunde", true },
                    { 8, "Eos sit amet placeat. Assumenda excepturi ut soluta. Neque delectus laudantium deleniti impedit laboriosam sit. Sed minima molestias quas sit sunt.\n\nOfficia consectetur tenetur non consequuntur similique est. Non esse odio quia eum cupiditate. Dolores qui sed corporis enim. Voluptas laborum dolorum est. Ex dolor nobis ea quo aspernatur qui et sit voluptatem.", "https://picsum.photos/120/120/?image=861", "Hammes Group", true },
                    { 7, "Nisi iste voluptas velit et excepturi repudiandae voluptatem. Consequuntur ut harum autem iusto et molestiae. Nostrum qui voluptas. Nesciunt totam ut dolorum.", "https://picsum.photos/120/120/?image=603", "Witting Inc", true },
                    { 6, "Voluptas sed ea delectus. Iusto maiores sequi ea. Non perferendis occaecati molestias doloribus. Sit inventore accusamus ut ipsum. Aut modi est totam repellat enim error earum ut fuga. Laudantium rerum ducimus.\n\nEnim minima repudiandae dolores aut nulla modi dolores. Quibusdam quia exercitationem quibusdam. Sint dolores ut voluptas aspernatur dolores. Facere iusto porro officia laudantium. Ut sapiente illo error ut et ea maxime deserunt et. Voluptatem quaerat alias sequi quis velit explicabo enim.", "https://picsum.photos/120/120/?image=885", "Cruickshank LLC", true }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 5, "Et dolores possimus dolor aut. Id repellendus et magni fuga sed quo ut est vel. Facere molestias cumque.", "https://picsum.photos/120/120/?image=245", "Schuster and Sons" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Status" },
                values: new object[,]
                {
                    { 4, "Vel officiis excepturi eveniet est exercitationem. Accusamus qui non aperiam similique omnis repudiandae velit. Sunt asperiores voluptates labore aut. Vel aut maiores error. Vitae laudantium placeat non blanditiis voluptatem itaque ut sit nostrum.\n\nAnimi aut aut praesentium doloremque sapiente sunt sapiente numquam. Suscipit consequuntur qui quod quam quis. Veritatis sed voluptates quia. Rerum voluptate facilis mollitia culpa.", "https://picsum.photos/120/120/?image=757", "Champlin, Spencer and Miller", true },
                    { 3, "Illo cumque earum temporibus non est ut quod asperiores. Itaque quod omnis. Odit at aut sunt incidunt minus doloremque non natus. Eligendi autem nemo minima at corrupti. Quia repellendus cumque ea eos.\n\nSapiente nemo nam qui saepe blanditiis quam ex blanditiis. Deleniti perspiciatis aut quam. Itaque nulla nulla eos perspiciatis aspernatur fugiat totam.\n\nMolestias aut voluptas a architecto quis ut est quis consequuntur. Et ducimus voluptatem odit reiciendis laboriosam et inventore et enim. Saepe non nulla vero natus repellat distinctio.", "https://picsum.photos/120/120/?image=84", "McKenzie and Sons", true },
                    { 2, "Natus ut ab nesciunt pariatur dolorum voluptas saepe voluptatem et. Libero perspiciatis nam aut quasi adipisci deserunt in facilis ex. Et eos aut laborum cum nulla sit. Amet tempora ipsam dignissimos non aliquid veniam qui voluptatem provident. Temporibus dolor consectetur velit incidunt sequi.\n\nIn qui odit numquam doloribus iste hic asperiores. Aliquid ut rerum repellat. Ut enim maxime ex aspernatur eos possimus repellendus. Sit accusamus magnam error eum illo qui. Praesentium quo ratione est quia vitae perferendis. Rerum in ea explicabo ut.", "https://picsum.photos/120/120/?image=16", "Labadie, Schroeder and Nolan", true },
                    { 10, "Magnam cum non tempore nemo adipisci enim. Ut iusto quod inventore labore minima eum mollitia ut. Impedit iste aut atque nisi voluptatibus voluptates facere animi beatae. Veniam blanditiis aliquam et ipsam. Sed eum vitae ut iure aperiam tempora earum ut dolore.", "https://picsum.photos/120/120/?image=148", "Quitzon Inc", true },
                    { 1, "Dolorem aut rerum voluptas hic ex sunt officia. Maxime aut sequi ut soluta. Eligendi vel eveniet.", "https://picsum.photos/120/120/?image=262", "O'Hara Group", true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 11, 22, 11, 4, 306, DateTimeKind.Local).AddTicks(8905), new DateTime(2020, 7, 9, 0, 8, 38, 279, DateTimeKind.Local).AddTicks(480), "mddxec", "Eligendi est consectetur consequuntur sunt.\nCommodi nulla velit qui repellat quo optio.\nMagnam necessitatibus inventore ut quam.\nVoluptas eveniet est harum qui amet voluptatem placeat mollitia.\nSunt quia aliquam dolores cumque repellendus fugiat qui.", 2, true },
                    { 204, new DateTime(2020, 11, 19, 4, 16, 57, 265, DateTimeKind.Local).AddTicks(5092), new DateTime(2021, 2, 11, 14, 0, 7, 151, DateTimeKind.Local).AddTicks(2572), "qsxqukw", "Quia laudantium voluptate dolore.", 14, true },
                    { 203, new DateTime(2021, 1, 12, 7, 19, 19, 725, DateTimeKind.Local).AddTicks(2474), new DateTime(2020, 7, 15, 12, 55, 28, 575, DateTimeKind.Local).AddTicks(1043), "wmzmspazrln", "Praesentium veniam ut velit et deserunt.", 14, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 202, new DateTime(2021, 4, 12, 4, 56, 19, 262, DateTimeKind.Local).AddTicks(8269), new DateTime(2021, 3, 13, 9, 49, 0, 887, DateTimeKind.Local).AddTicks(1538), "elrjriydvk", "Est iusto hic saepe.", 14 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 201, new DateTime(2021, 2, 27, 7, 56, 24, 624, DateTimeKind.Local).AddTicks(3745), new DateTime(2021, 4, 12, 19, 54, 48, 113, DateTimeKind.Local).AddTicks(8347), "ljydy", "Qui suscipit optio nemo dolorem dolor. Quia eos doloribus possimus magnam iusto qui tempore aut. Et et illum aut et non eos voluptates. Et qui est repudiandae explicabo consequatur delectus. Quis fuga molestiae facilis voluptate omnis aliquid.", 14, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 200, new DateTime(2021, 4, 11, 22, 11, 4, 339, DateTimeKind.Local).AddTicks(9592), new DateTime(2021, 1, 18, 8, 56, 25, 330, DateTimeKind.Local).AddTicks(8386), "csxbpcn", "Repellendus totam doloribus.\nA quia hic ut.", 14 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 199, new DateTime(2021, 4, 12, 13, 21, 57, 194, DateTimeKind.Local).AddTicks(7752), new DateTime(2020, 8, 23, 19, 21, 11, 111, DateTimeKind.Local).AddTicks(8732), "yaennuly", "Asperiores impedit voluptatem. Nihil quis aut sed dolores sunt officiis dignissimos. Alias rerum placeat. Dolorem nihil omnis repudiandae aperiam qui. Voluptate et ut assumenda necessitatibus. Perspiciatis quisquam molestiae.", 14, true },
                    { 205, new DateTime(2021, 4, 12, 0, 57, 9, 299, DateTimeKind.Local).AddTicks(4788), new DateTime(2020, 8, 26, 7, 46, 18, 153, DateTimeKind.Local).AddTicks(5423), "zprouurf", "Fugit voluptatem vel.\nEst quibusdam facere dicta iste.\nQuasi earum hic explicabo nisi at rerum amet in repellendus.", 14, true },
                    { 198, new DateTime(2020, 4, 29, 0, 32, 27, 106, DateTimeKind.Local).AddTicks(8833), new DateTime(2020, 12, 25, 12, 40, 55, 750, DateTimeKind.Local).AddTicks(3335), "zdnkqzdbmy", "Incidunt modi facere et beatae dignissimos neque nemo repellendus.\nVeritatis corrupti dolorum qui et occaecati cumque cupiditate omnis porro.\nConsequuntur incidunt ipsa.\nIusto voluptatem temporibus ullam nam.\nQuos laborum dolor placeat fuga quidem.", 14, true },
                    { 196, new DateTime(2021, 4, 11, 22, 11, 4, 339, DateTimeKind.Local).AddTicks(8960), new DateTime(2021, 4, 12, 15, 7, 34, 972, DateTimeKind.Local).AddTicks(1346), "cbvjwkuoix", "dolor", 14, true },
                    { 195, new DateTime(2021, 4, 12, 1, 17, 11, 842, DateTimeKind.Local).AddTicks(678), new DateTime(2020, 8, 30, 16, 26, 9, 332, DateTimeKind.Local).AddTicks(5602), "sfofrzvk", "quisquam", 14, true },
                    { 194, new DateTime(2021, 4, 12, 12, 0, 25, 119, DateTimeKind.Local).AddTicks(3150), new DateTime(2021, 4, 12, 19, 39, 15, 368, DateTimeKind.Local).AddTicks(2327), "mtipj", "Neque non aut earum itaque est. Est et est modi id et consequatur vero est perferendis. Sit illo earum voluptate vel eligendi. Porro vitae soluta aut. Necessitatibus dolorem tempore occaecati ducimus qui vero in nesciunt recusandae. Numquam corporis voluptas eos officiis at cum et.", 13, true },
                    { 193, new DateTime(2021, 4, 12, 13, 0, 37, 440, DateTimeKind.Local).AddTicks(3148), new DateTime(2021, 2, 9, 10, 8, 45, 103, DateTimeKind.Local).AddTicks(8089), "yvjqk", "Et facere numquam laboriosam quia ut aut qui commodi eius.\nQuibusdam quod ea voluptatum mollitia tempore.\nIn corporis omnis vero illum error dignissimos et deleniti dolore.\nFuga reiciendis est itaque ut nisi aspernatur.", 13, true },
                    { 192, new DateTime(2021, 4, 12, 9, 19, 11, 291, DateTimeKind.Local).AddTicks(8753), new DateTime(2021, 4, 12, 5, 45, 24, 459, DateTimeKind.Local).AddTicks(3312), "vdmamlczgj", "At qui at quibusdam a velit.", 13, true },
                    { 191, new DateTime(2020, 10, 10, 2, 20, 16, 403, DateTimeKind.Local).AddTicks(445), new DateTime(2020, 8, 24, 20, 30, 15, 964, DateTimeKind.Local).AddTicks(6194), "nvhoqxr", "Omnis illo temporibus est qui assumenda magnam mollitia.", 13, true },
                    { 197, new DateTime(2020, 4, 19, 18, 36, 42, 668, DateTimeKind.Local).AddTicks(3333), new DateTime(2020, 9, 12, 3, 42, 39, 225, DateTimeKind.Local).AddTicks(7394), "oiymvdiuq", "Natus repellendus est aliquid officia voluptatem ex dolorem. Aspernatur distinctio non sit veniam impedit. Quibusdam deleniti voluptates veniam quisquam fugiat quia dolor. Commodi similique qui. Repellat itaque aliquid. Reprehenderit eius modi quae.", 14, true },
                    { 206, new DateTime(2021, 4, 12, 10, 38, 21, 903, DateTimeKind.Local).AddTicks(656), new DateTime(2020, 8, 19, 2, 44, 11, 914, DateTimeKind.Local).AddTicks(558), "pehmajhzaarj", "eum", 14, true },
                    { 207, new DateTime(2020, 6, 10, 4, 9, 37, 905, DateTimeKind.Local).AddTicks(9739), new DateTime(2021, 4, 12, 13, 29, 0, 47, DateTimeKind.Local).AddTicks(3433), "uadndzltdost", "Nobis culpa sint error quibusdam ea.", 14, true },
                    { 208, new DateTime(2020, 5, 28, 6, 0, 51, 325, DateTimeKind.Local).AddTicks(8707), new DateTime(2021, 4, 12, 19, 33, 56, 218, DateTimeKind.Local).AddTicks(9973), "smnqorj", "Molestias aliquam exercitationem error quaerat.", 14, true },
                    { 223, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(7780), new DateTime(2021, 4, 12, 13, 46, 9, 679, DateTimeKind.Local).AddTicks(1687), "knmtrixsrldw", "minima", 15, true },
                    { 222, new DateTime(2021, 4, 12, 21, 15, 7, 165, DateTimeKind.Local).AddTicks(522), new DateTime(2021, 4, 11, 23, 48, 18, 280, DateTimeKind.Local).AddTicks(8045), "opuffhbgine", "ullam", 15, true },
                    { 221, new DateTime(2021, 4, 12, 20, 16, 57, 724, DateTimeKind.Local).AddTicks(8309), new DateTime(2021, 4, 12, 3, 20, 28, 302, DateTimeKind.Local).AddTicks(2434), "iuypw", "Sapiente amet autem nihil vitae voluptas non minus expedita.\nEt molestiae dolorem ex aut ducimus sint et hic.\nQuam et optio laborum omnis.", 15, true },
                    { 220, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(7577), new DateTime(2021, 2, 5, 7, 12, 24, 253, DateTimeKind.Local).AddTicks(5912), "tdmjioxgkvce", "Aliquam aperiam quia non vitae ipsa.\nAd voluptas et quos.\nQuisquam eos doloribus omnis labore et repellat.\nIste perferendis odit eum sunt ut mollitia facilis ex.", 15, true },
                    { 219, new DateTime(2020, 8, 22, 19, 31, 53, 907, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 1, 7, 5, 1, 14, 135, DateTimeKind.Local).AddTicks(4479), "jqvbprv", "Repellat explicabo assumenda atque et architecto sapiente officiis.\nRem consequatur aut nostrum.\nVoluptatem commodi dolore ut.\nSint doloribus perspiciatis nobis excepturi qui.\nRatione debitis eum illo adipisci ut earum et.", 15, true },
                    { 218, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(7261), new DateTime(2021, 4, 12, 18, 57, 13, 272, DateTimeKind.Local).AddTicks(392), "qzcvjwnhvv", "Itaque et porro consequatur sed et occaecati quidem cupiditate enim.", 15, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 217, new DateTime(2020, 12, 21, 11, 30, 47, 743, DateTimeKind.Local).AddTicks(6772), new DateTime(2021, 4, 12, 13, 8, 56, 191, DateTimeKind.Local).AddTicks(8866), "bpnjphg", "eveniet", 15 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 216, new DateTime(2021, 4, 12, 8, 33, 32, 438, DateTimeKind.Local).AddTicks(6117), new DateTime(2021, 4, 12, 3, 51, 53, 340, DateTimeKind.Local).AddTicks(6865), "rjxxrcdxwb", "Placeat ipsum saepe vitae et.", 15, true },
                    { 215, new DateTime(2021, 4, 2, 1, 56, 39, 569, DateTimeKind.Local).AddTicks(8469), new DateTime(2021, 4, 12, 17, 8, 31, 879, DateTimeKind.Local).AddTicks(5892), "ghxaomam", "fugit", 15, true },
                    { 214, new DateTime(2021, 4, 11, 22, 11, 4, 340, DateTimeKind.Local).AddTicks(1061), new DateTime(2021, 4, 12, 15, 21, 54, 712, DateTimeKind.Local).AddTicks(4415), "xdkcidemxg", "Corporis qui est iure unde nesciunt id eveniet.", 14, true },
                    { 213, new DateTime(2021, 4, 11, 22, 11, 4, 340, DateTimeKind.Local).AddTicks(997), new DateTime(2021, 4, 12, 17, 45, 5, 507, DateTimeKind.Local).AddTicks(7251), "pjyund", "Officia omnis atque qui iusto dolores magni fugit sed. Ex eligendi impedit explicabo laborum. Eius voluptate neque. Aliquam molestiae ipsum officia quo vel ab odit in ut.", 14, true },
                    { 212, new DateTime(2020, 12, 4, 16, 18, 27, 49, DateTimeKind.Local).AddTicks(7237), new DateTime(2021, 4, 12, 18, 32, 59, 480, DateTimeKind.Local).AddTicks(6967), "lklhrdazkbe", "Ut sunt quaerat ea deleniti occaecati incidunt.", 14, true },
                    { 211, new DateTime(2021, 4, 12, 4, 31, 26, 964, DateTimeKind.Local).AddTicks(5585), new DateTime(2021, 4, 12, 0, 21, 17, 466, DateTimeKind.Local).AddTicks(2824), "ylogc", "Quia quaerat excepturi ut earum eos.\nDolor consequatur quisquam dolores debitis molestiae aut molestiae culpa.\nQuae ea aut ut enim nobis aliquam et laudantium.\nOfficia molestiae perspiciatis consectetur ullam doloremque voluptates.", 14, true },
                    { 210, new DateTime(2020, 7, 24, 20, 30, 46, 689, DateTimeKind.Local).AddTicks(8189), new DateTime(2021, 4, 12, 1, 28, 56, 580, DateTimeKind.Local).AddTicks(5213), "nxejqxe", "Soluta beatae quo quis occaecati eligendi quo dolor et voluptatem.\nQuis dolor labore hic inventore.\nBeatae architecto et odio quas qui sed.\nCulpa iste voluptatem.\nConsequatur ullam voluptas dolores aliquid et occaecati voluptatum voluptas aperiam.", 14, true },
                    { 209, new DateTime(2021, 3, 23, 2, 39, 42, 579, DateTimeKind.Local).AddTicks(5214), new DateTime(2021, 4, 12, 5, 50, 53, 623, DateTimeKind.Local).AddTicks(13), "serccxn", "Vel aut inventore rerum aperiam veritatis velit. Repellat nihil et voluptate nemo et quibusdam in aut. Omnis magnam cum harum atque. Omnis aliquid voluptatibus atque unde. Minus ea et eligendi deleniti praesentium. Incidunt fugit animi consectetur.", 14, true },
                    { 190, new DateTime(2021, 4, 12, 14, 14, 30, 175, DateTimeKind.Local).AddTicks(8465), new DateTime(2020, 8, 14, 0, 13, 1, 401, DateTimeKind.Local).AddTicks(3573), "exgtmxeskut", "Eveniet exercitationem occaecati eligendi in.", 13, true },
                    { 189, new DateTime(2020, 5, 6, 14, 16, 2, 519, DateTimeKind.Local).AddTicks(8955), new DateTime(2020, 12, 29, 2, 46, 24, 853, DateTimeKind.Local).AddTicks(1830), "ncmyzah", "debitis", 12, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 188, new DateTime(2021, 4, 11, 23, 4, 20, 814, DateTimeKind.Local).AddTicks(2383), new DateTime(2021, 4, 12, 2, 0, 44, 635, DateTimeKind.Local).AddTicks(2112), "frjqurtfqeo", "error", 12 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 187, new DateTime(2020, 12, 1, 14, 49, 20, 899, DateTimeKind.Local).AddTicks(9975), new DateTime(2021, 4, 12, 9, 15, 44, 507, DateTimeKind.Local).AddTicks(6539), "orndipt", "Repudiandae repellendus et ea ad vel sunt porro dolor.\nDolor ut aspernatur mollitia sunt in.\nEst fugiat et laudantium eum soluta iusto voluptate exercitationem.", 12, true },
                    { 167, new DateTime(2020, 7, 8, 19, 41, 3, 765, DateTimeKind.Local).AddTicks(1120), new DateTime(2020, 5, 19, 15, 59, 23, 138, DateTimeKind.Local).AddTicks(1953), "uowxdkqqpjto", "debitis", 11, true },
                    { 166, new DateTime(2021, 4, 11, 22, 11, 4, 333, DateTimeKind.Local).AddTicks(964), new DateTime(2020, 8, 17, 15, 28, 15, 595, DateTimeKind.Local).AddTicks(979), "ujciccn", "Omnis quaerat et consequatur quibusdam enim quae explicabo repudiandae error.\nRerum reprehenderit nemo.\nTempora numquam commodi laboriosam doloremque sit ut aut sit.\nPorro qui quis earum voluptas.\nEt iure et reprehenderit eum iusto quis molestiae.", 11, true },
                    { 165, new DateTime(2021, 2, 4, 17, 7, 2, 942, DateTimeKind.Local).AddTicks(2516), new DateTime(2021, 4, 12, 6, 24, 1, 881, DateTimeKind.Local).AddTicks(6551), "paleeawy", "quas", 11, true },
                    { 164, new DateTime(2021, 4, 1, 9, 22, 13, 68, DateTimeKind.Local).AddTicks(2850), new DateTime(2020, 10, 27, 19, 12, 19, 817, DateTimeKind.Local).AddTicks(7950), "qdiserggwsk", "consequatur", 11, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 163, new DateTime(2021, 4, 11, 22, 11, 4, 333, DateTimeKind.Local).AddTicks(714), new DateTime(2021, 4, 12, 15, 55, 24, 661, DateTimeKind.Local).AddTicks(4338), "gaplqlxhnlq", "Consequatur et qui minus.", 11, true },
                    { 162, new DateTime(2021, 4, 12, 20, 31, 47, 997, DateTimeKind.Local).AddTicks(5579), new DateTime(2020, 5, 20, 7, 0, 48, 531, DateTimeKind.Local).AddTicks(5939), "ejgaake", "Reprehenderit est vel repellendus non veniam neque nisi facere. Rem recusandae nisi fuga culpa qui hic. Deleniti beatae eum facere enim. Aut molestiae optio et libero magni dignissimos possimus. Dolores minus qui facere.", 11, true },
                    { 161, new DateTime(2021, 4, 11, 22, 11, 4, 333, DateTimeKind.Local).AddTicks(425), new DateTime(2021, 3, 21, 7, 27, 3, 279, DateTimeKind.Local).AddTicks(8189), "easrtaz", "Eos odio repellat dolorem recusandae ratione et.\nEt nihil ut et ut autem suscipit consequuntur et similique.", 11, true },
                    { 160, new DateTime(2021, 4, 12, 16, 5, 25, 619, DateTimeKind.Local).AddTicks(6270), new DateTime(2021, 4, 12, 3, 16, 36, 310, DateTimeKind.Local).AddTicks(6106), "cbbnvyz", "Consequuntur ipsa possimus aut aut pariatur voluptatem. Voluptatem officiis minima fugit qui. Quibusdam perspiciatis sed provident modi ab at repudiandae ducimus. Sint hic quo sed laborum sint eos ipsam. Deserunt dolore expedita odit sed impedit nostrum. Ab voluptatibus perferendis alias aut voluptatem exercitationem quod minima reprehenderit.", 11, true },
                    { 159, new DateTime(2021, 4, 11, 22, 11, 4, 332, DateTimeKind.Local).AddTicks(9969), new DateTime(2021, 2, 10, 9, 50, 32, 119, DateTimeKind.Local).AddTicks(7453), "dqtyrbp", "Et et a culpa voluptas quod tenetur amet doloremque tempora. Corporis sit sed dolor quis autem quod velit aut. Suscipit est impedit optio error est et magni. Ea aut nisi commodi eius velit. Sit maiores id repellat. Quasi iusto dignissimos dolorem veniam provident dolor quis cumque eos.", 11, true },
                    { 158, new DateTime(2020, 5, 14, 4, 17, 30, 813, DateTimeKind.Local).AddTicks(4428), new DateTime(2020, 4, 30, 0, 10, 17, 293, DateTimeKind.Local).AddTicks(5324), "lxkadvzpgloo", "Quis sunt omnis ab illum iusto. Delectus dolorem dolor eum et repellendus. Consequatur rerum aliquam et porro voluptatem fugit.", 11, true },
                    { 157, new DateTime(2021, 4, 9, 13, 28, 37, 951, DateTimeKind.Local).AddTicks(7296), new DateTime(2021, 4, 12, 10, 36, 7, 702, DateTimeKind.Local).AddTicks(3742), "aiwmtbsxsr", "et", 11, true },
                    { 156, new DateTime(2021, 4, 11, 22, 11, 4, 332, DateTimeKind.Local).AddTicks(9534), new DateTime(2021, 4, 12, 3, 27, 13, 69, DateTimeKind.Local).AddTicks(5045), "lpkgvwdhrnj", "accusamus", 11, true },
                    { 155, new DateTime(2020, 6, 19, 1, 59, 53, 424, DateTimeKind.Local).AddTicks(8123), new DateTime(2021, 4, 12, 16, 53, 0, 846, DateTimeKind.Local).AddTicks(5900), "mzptuocspxk", "est", 11, true },
                    { 154, new DateTime(2021, 4, 11, 22, 11, 4, 331, DateTimeKind.Local).AddTicks(3605), new DateTime(2020, 12, 21, 15, 42, 40, 163, DateTimeKind.Local).AddTicks(9294), "rwhskpzzbgq", "Est et consequatur quas minus dignissimos fuga labore et harum.", 10, true },
                    { 153, new DateTime(2021, 4, 12, 10, 30, 2, 800, DateTimeKind.Local).AddTicks(9990), new DateTime(2021, 4, 5, 17, 7, 0, 569, DateTimeKind.Local).AddTicks(3876), "gpbhmioxmki", "odio", 10, true },
                    { 168, new DateTime(2021, 3, 20, 12, 22, 51, 388, DateTimeKind.Local).AddTicks(9178), new DateTime(2020, 9, 24, 11, 28, 54, 337, DateTimeKind.Local).AddTicks(322), "yuvlycciwadt", "Odio non quae.\nUllam consequatur qui cumque dolorem pariatur sint consectetur aspernatur.\nAut est necessitatibus.\nEt dolorum veritatis ipsa cumque dignissimos sed.\nVoluptatem quas porro et nisi voluptatem accusantium.", 11, true },
                    { 224, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(7884), new DateTime(2021, 4, 12, 4, 55, 8, 22, DateTimeKind.Local).AddTicks(6132), "xnplp", "Ratione est et dolorem consequuntur vitae exercitationem. Iste hic dolores unde expedita beatae. Consequuntur adipisci eveniet.", 15, true },
                    { 169, new DateTime(2020, 11, 18, 0, 44, 13, 897, DateTimeKind.Local).AddTicks(4569), new DateTime(2021, 4, 12, 16, 29, 7, 467, DateTimeKind.Local).AddTicks(7088), "caplxzgt", "Eius placeat aut doloremque.", 11, true },
                    { 171, new DateTime(2021, 4, 12, 8, 30, 44, 225, DateTimeKind.Local).AddTicks(8268), new DateTime(2021, 4, 12, 9, 16, 54, 597, DateTimeKind.Local).AddTicks(3240), "cesyiadvw", "Quis porro officia. Quia perspiciatis quia natus consectetur vel quod. Alias neque quia incidunt dolorem. Consectetur et vero ea accusantium voluptas non id distinctio est. Eum dolore sint rerum aut. Qui ex expedita velit sit quia.", 11, true },
                    { 186, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(3143), new DateTime(2021, 4, 12, 20, 45, 5, 1, DateTimeKind.Local).AddTicks(3581), "lkfgtzyxyzwf", "In eos laudantium enim.", 12, true },
                    { 185, new DateTime(2021, 4, 12, 14, 22, 42, 122, DateTimeKind.Local).AddTicks(2042), new DateTime(2021, 4, 12, 14, 16, 5, 81, DateTimeKind.Local).AddTicks(9121), "aclidhe", "Tempore perferendis delectus maxime.\nMolestias earum ipsam exercitationem sit.\nDolorum rerum sed unde neque suscipit enim soluta voluptatibus.\nDignissimos in quisquam dolorem consequuntur.\nLibero suscipit incidunt.\nAccusantium soluta veritatis fuga eius.", 12, true },
                    { 184, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 4, 11, 23, 24, 0, 3, DateTimeKind.Local).AddTicks(3714), "aevjanjmcnvu", "Et tenetur explicabo at quae. Ea perspiciatis natus vitae aut aut. Quos perferendis molestiae temporibus illum assumenda quos magnam qui dolores. Porro facere enim maxime mollitia commodi velit autem aut. Tempora quas voluptatibus voluptatum. Odio facilis et aliquam exercitationem incidunt iste.", 12, true },
                    { 183, new DateTime(2020, 6, 29, 11, 32, 47, 452, DateTimeKind.Local).AddTicks(9292), new DateTime(2020, 10, 26, 6, 31, 37, 956, DateTimeKind.Local).AddTicks(9664), "zlscewp", "Est qui omnis sed a.\nQuidem enim nihil sed.\nVoluptates aspernatur nesciunt sed sit tempore voluptas quis officia.\nEsse a rem alias sed iure est quos nihil.\nOfficiis illum et fugit voluptas qui magni quia sed dolor.", 12, true },
                    { 182, new DateTime(2020, 8, 11, 5, 54, 37, 363, DateTimeKind.Local).AddTicks(9595), new DateTime(2020, 11, 11, 0, 7, 54, 409, DateTimeKind.Local).AddTicks(6373), "ekqib", "Consectetur excepturi voluptas et explicabo commodi beatae enim. Molestias quis commodi hic reiciendis quod commodi. Fuga ipsa quam iste nisi. Nam alias vel deserunt et omnis doloribus unde fugit qui. Enim ut sed dignissimos non rerum numquam quis.", 12, true },
                    { 181, new DateTime(2021, 4, 12, 5, 18, 12, 60, DateTimeKind.Local).AddTicks(6390), new DateTime(2021, 4, 12, 14, 19, 2, 567, DateTimeKind.Local).AddTicks(6832), "kbuvjjpf", "Veritatis eius voluptatibus est fugit. Esse voluptates aut quia porro vero aut quia. Consequatur odio autem modi molestiae dolore nostrum. Labore sed animi voluptas repellendus illum placeat ipsa. Sit animi rerum incidunt quam laudantium. Eos architecto dolorum.", 12, true },
                    { 180, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(1970), new DateTime(2021, 4, 12, 9, 52, 5, 193, DateTimeKind.Local).AddTicks(7803), "sjqim", "Blanditiis consequatur asperiores. Perferendis quia quae assumenda fuga sapiente id repudiandae dolor et. Rerum qui eum dolorem. Amet nisi dolore ad. Ut hic qui.", 12, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[,]
                {
                    { 179, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(1827), new DateTime(2021, 4, 12, 2, 11, 45, 404, DateTimeKind.Local).AddTicks(9201), "uamribqvuk", "autem", 12 },
                    { 178, new DateTime(2020, 9, 10, 18, 9, 21, 15, DateTimeKind.Local).AddTicks(1671), new DateTime(2021, 4, 12, 19, 21, 44, 291, DateTimeKind.Local).AddTicks(6320), "wudqbzkmxap", "consequuntur", 12 }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 177, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(1755), new DateTime(2021, 4, 12, 19, 13, 55, 552, DateTimeKind.Local).AddTicks(6698), "zgqvarxzlem", "Excepturi a aliquid velit totam corporis.\nEnim suscipit ut debitis vero aliquam.\nSed natus dignissimos deleniti vero beatae soluta reprehenderit suscipit veniam.\nInventore fugiat similique ad.\nAutem placeat enim non laboriosam temporibus cum distinctio.\nAmet enim expedita eveniet cum rerum.", 12, true },
                    { 176, new DateTime(2021, 4, 12, 18, 37, 29, 430, DateTimeKind.Local).AddTicks(22), new DateTime(2021, 4, 12, 18, 46, 21, 449, DateTimeKind.Local).AddTicks(3664), "cbiryamxztcd", "Quia ab quae sit enim et. Illo et facere tenetur officia. Dignissimos ut quo est et. Aut ut id placeat iste impedit recusandae enim qui velit.", 12, true },
                    { 175, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(1347), new DateTime(2021, 4, 12, 17, 34, 59, 424, DateTimeKind.Local).AddTicks(9369), "pccnwkth", "Minima totam perspiciatis facere optio et et sit. Maxime facilis quasi mollitia. Rerum est quidem dolores accusamus velit nemo. Quam dolores minus. Consectetur eum sapiente excepturi doloribus eligendi.", 12, true },
                    { 174, new DateTime(2021, 4, 11, 22, 11, 4, 335, DateTimeKind.Local).AddTicks(1108), new DateTime(2020, 12, 17, 0, 30, 13, 965, DateTimeKind.Local).AddTicks(242), "vnsgj", "Quas eos aperiam ducimus aut.", 12, true },
                    { 173, new DateTime(2020, 4, 12, 19, 6, 0, 230, DateTimeKind.Local).AddTicks(7919), new DateTime(2021, 2, 2, 2, 47, 7, 974, DateTimeKind.Local).AddTicks(7194), "fdxkkadfq", "saepe", 11, true },
                    { 172, new DateTime(2020, 9, 1, 1, 22, 59, 423, DateTimeKind.Local).AddTicks(2536), new DateTime(2021, 2, 20, 3, 38, 9, 388, DateTimeKind.Local).AddTicks(9654), "wqyujfzstrp", "Consequatur magni modi enim doloremque. Iure debitis molestias minus quia nostrum nemo ut voluptatem. Totam distinctio atque sint nihil qui. Quo deserunt assumenda voluptate consequuntur.", 11, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 170, new DateTime(2021, 4, 11, 22, 11, 4, 333, DateTimeKind.Local).AddTicks(1464), new DateTime(2021, 4, 12, 11, 40, 23, 591, DateTimeKind.Local).AddTicks(6892), "kngeaxtekitd", "Perferendis est omnis. Quod nihil sed. Excepturi repudiandae aperiam placeat.", 11 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 152, new DateTime(2021, 4, 11, 22, 11, 4, 331, DateTimeKind.Local).AddTicks(3499), new DateTime(2021, 4, 12, 10, 49, 52, 736, DateTimeKind.Local).AddTicks(7270), "jxbtcbuguuqx", "Quasi quibusdam sed possimus adipisci eos impedit.\nTemporibus aut est.", 10, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 225, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(7919), new DateTime(2021, 2, 14, 2, 37, 7, 919, DateTimeKind.Local).AddTicks(6265), "qyeftyp", "exercitationem", 15 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 227, new DateTime(2021, 4, 12, 6, 31, 28, 488, DateTimeKind.Local).AddTicks(36), new DateTime(2021, 4, 12, 8, 10, 38, 423, DateTimeKind.Local).AddTicks(5879), "xjkjfrlkmpnx", "aut", 15, true },
                    { 279, new DateTime(2021, 4, 12, 5, 41, 5, 914, DateTimeKind.Local).AddTicks(4775), new DateTime(2021, 4, 12, 20, 1, 40, 58, DateTimeKind.Local).AddTicks(6161), "pitomyppe", "Ducimus explicabo iusto saepe qui et sit provident molestiae.\nDucimus veniam et saepe voluptatem.\nEum nihil iusto et et deserunt saepe tempora.\nQuis provident iusto ut illo sint et qui odio.\nProvident rerum qui est nobis et rerum.", 18, true },
                    { 278, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(832), new DateTime(2021, 4, 12, 9, 47, 57, 921, DateTimeKind.Local).AddTicks(9543), "xuhcmopva", "Et nobis consectetur ut ad eaque.", 18, true },
                    { 277, new DateTime(2021, 4, 12, 17, 56, 3, 821, DateTimeKind.Local).AddTicks(1701), new DateTime(2021, 4, 12, 16, 50, 17, 463, DateTimeKind.Local).AddTicks(9783), "doozmkvja", "tenetur", 18, true },
                    { 276, new DateTime(2021, 4, 12, 8, 23, 29, 122, DateTimeKind.Local).AddTicks(1574), new DateTime(2021, 4, 12, 9, 16, 5, 138, DateTimeKind.Local).AddTicks(5957), "ramehlbtcm", "Qui adipisci illo cupiditate id enim.\nEt officia provident tenetur officia.", 18, true },
                    { 275, new DateTime(2021, 4, 12, 21, 28, 55, 155, DateTimeKind.Local).AddTicks(703), new DateTime(2020, 11, 20, 6, 27, 3, 63, DateTimeKind.Local).AddTicks(3984), "exrqnithp", "Molestiae totam sapiente possimus libero voluptatem qui id quibusdam delectus.\nVel est incidunt qui voluptas cupiditate.\nQuis qui voluptas non.\nTenetur voluptatem deleniti placeat rerum tempore aperiam at consequatur.\nExpedita quo ut sunt rem cum soluta ad.\nOmnis adipisci nihil enim necessitatibus corporis.", 18, true },
                    { 274, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(440), new DateTime(2021, 4, 12, 15, 7, 50, 824, DateTimeKind.Local).AddTicks(9824), "ycajiro", "Non eos aperiam doloremque eos et quasi nulla nihil voluptate. Quo voluptas enim soluta ratione odit velit asperiores et. Doloribus cupiditate exercitationem facere unde. Aliquam rerum dolor earum vero tenetur aspernatur quis veniam voluptate. Dignissimos sint cupiditate omnis omnis.", 18, true },
                    { 280, new DateTime(2021, 4, 12, 4, 15, 48, 781, DateTimeKind.Local).AddTicks(1512), new DateTime(2020, 9, 19, 1, 46, 16, 354, DateTimeKind.Local).AddTicks(7390), "ttdwzwffbhgp", "Illum praesentium consectetur corporis et maiores nobis vel facere.\nVoluptatibus excepturi culpa ea nisi autem recusandae distinctio hic quis.\nQuas delectus laudantium id suscipit et vitae enim esse.", 18, true },
                    { 273, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(194), new DateTime(2020, 9, 7, 1, 28, 7, 426, DateTimeKind.Local).AddTicks(8920), "raphlntozv", "dignissimos", 18, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 271, new DateTime(2020, 12, 14, 6, 22, 29, 653, DateTimeKind.Local).AddTicks(5072), new DateTime(2020, 7, 26, 23, 11, 3, 558, DateTimeKind.Local).AddTicks(5382), "tcegqiqlita", "ut", 18, true },
                    { 270, new DateTime(2021, 1, 30, 3, 54, 39, 217, DateTimeKind.Local).AddTicks(2439), new DateTime(2021, 4, 12, 13, 25, 27, 15, DateTimeKind.Local).AddTicks(837), "fkvfacniwu", "Quo ipsum qui dolorem eum eaque nesciunt odit.", 18, true },
                    { 269, new DateTime(2021, 4, 11, 22, 11, 4, 346, DateTimeKind.Local).AddTicks(9874), new DateTime(2021, 4, 12, 15, 4, 25, 777, DateTimeKind.Local).AddTicks(7981), "wwdza", "Et et enim vitae adipisci explicabo.", 18, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 268, new DateTime(2021, 4, 12, 6, 47, 57, 812, DateTimeKind.Local).AddTicks(4131), new DateTime(2021, 4, 12, 18, 58, 25, 170, DateTimeKind.Local).AddTicks(9705), "nwtczvuf", "Sit cupiditate ab.\nNumquam et odit.\nLibero aliquid corporis assumenda eaque id.\nEx quasi atque excepturi pariatur et voluptates nihil eum ipsa.", 18 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 267, new DateTime(2021, 4, 3, 20, 58, 22, 267, DateTimeKind.Local).AddTicks(8708), new DateTime(2021, 1, 2, 2, 57, 34, 764, DateTimeKind.Local).AddTicks(958), "iolkzvpjeau", "Eos sit et eos praesentium placeat iure rerum adipisci.\nHarum earum non et.", 18, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 266, new DateTime(2021, 2, 4, 0, 30, 51, 758, DateTimeKind.Local).AddTicks(4771), new DateTime(2020, 4, 18, 14, 22, 14, 683, DateTimeKind.Local).AddTicks(2270), "sxofygh", "quia", 18 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 272, new DateTime(2020, 4, 12, 22, 55, 23, 805, DateTimeKind.Local).AddTicks(2529), new DateTime(2021, 4, 12, 9, 10, 44, 681, DateTimeKind.Local).AddTicks(5744), "ecroxnduepc", "Et rerum quia et eum occaecati enim.\nHarum aperiam molestiae sed officiis eos quia.\nQuia similique et explicabo sunt maiores dolores soluta est quibusdam.\nCum sed dolorem et in quaerat omnis.\nDolorem officia ducimus.", 18, true },
                    { 281, new DateTime(2020, 4, 19, 3, 43, 12, 594, DateTimeKind.Local).AddTicks(5426), new DateTime(2020, 7, 20, 15, 6, 21, 918, DateTimeKind.Local).AddTicks(399), "ezcyjxz", "Pariatur porro et sit molestiae soluta dicta.", 18, true },
                    { 282, new DateTime(2021, 4, 12, 4, 31, 50, 182, DateTimeKind.Local).AddTicks(7170), new DateTime(2021, 4, 12, 15, 4, 0, 750, DateTimeKind.Local).AddTicks(1624), "nipsvaiir", "Quia voluptas magni ab voluptatum qui porro qui commodi reprehenderit.\nVoluptate sunt dolorum.\nId non doloribus qui debitis esse voluptatum.\nAperiam nemo voluptatem provident mollitia ut.", 18, true },
                    { 283, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(1414), new DateTime(2021, 4, 12, 11, 54, 18, 801, DateTimeKind.Local).AddTicks(1947), "lgeozg", "aliquam", 18, true },
                    { 298, new DateTime(2021, 4, 12, 21, 13, 7, 693, DateTimeKind.Local).AddTicks(2070), new DateTime(2020, 6, 20, 15, 20, 26, 333, DateTimeKind.Local).AddTicks(5060), "rikbeshmof", "Ex perspiciatis et et inventore molestias ut et possimus qui.", 20, true },
                    { 297, new DateTime(2020, 9, 6, 12, 11, 50, 842, DateTimeKind.Local).AddTicks(6253), new DateTime(2021, 4, 12, 11, 9, 17, 472, DateTimeKind.Local).AddTicks(1562), "mppwdm", "Tenetur et et et et. Reiciendis voluptas qui et eos ut nesciunt quidem dolore. Harum sapiente maxime est sapiente. Accusamus dicta quia perspiciatis ut ipsum.", 20, true },
                    { 296, new DateTime(2021, 4, 11, 22, 11, 4, 351, DateTimeKind.Local).AddTicks(5308), new DateTime(2021, 3, 24, 15, 18, 39, 235, DateTimeKind.Local).AddTicks(3286), "mhamu", "Veritatis fugit qui aut fugit suscipit deserunt rerum.", 20, true },
                    { 295, new DateTime(2020, 9, 11, 0, 25, 30, 697, DateTimeKind.Local).AddTicks(2134), new DateTime(2021, 4, 12, 12, 14, 10, 226, DateTimeKind.Local).AddTicks(5337), "oxlhswwg", "Nobis fugiat sapiente dolore iusto. Quas ipsa suscipit est reiciendis doloribus. Quam quia repudiandae voluptas tempore eos reprehenderit delectus expedita. Amet repellendus impedit ipsam iure. Quia sed rerum in. Non veniam facere temporibus unde porro reiciendis autem ipsum facere.", 19, true },
                    { 294, new DateTime(2021, 4, 11, 23, 8, 0, 782, DateTimeKind.Local).AddTicks(4003), new DateTime(2021, 4, 12, 9, 47, 39, 190, DateTimeKind.Local).AddTicks(1848), "repcbeunhe", "fugit", 19, true },
                    { 293, new DateTime(2021, 4, 12, 13, 51, 36, 310, DateTimeKind.Local).AddTicks(5131), new DateTime(2020, 5, 27, 21, 17, 42, 268, DateTimeKind.Local).AddTicks(5447), "boxsjbgb", "Similique illo dicta rerum sit nulla ab amet et ut.\nVoluptatum minus et fugiat omnis veritatis nulla in impedit earum.\nSapiente id aut excepturi odio quos minima.\nHarum labore fuga.", 19, true },
                    { 292, new DateTime(2021, 4, 11, 22, 11, 4, 348, DateTimeKind.Local).AddTicks(8071), new DateTime(2021, 4, 12, 17, 20, 42, 140, DateTimeKind.Local).AddTicks(3420), "uvntplzxnupw", "Voluptas quisquam consequatur accusantium.\nMolestias illum dolore ducimus.\nDistinctio nihil eos voluptas quia corporis eligendi non.\nEos modi aut.", 19, true },
                    { 291, new DateTime(2021, 4, 11, 22, 11, 4, 348, DateTimeKind.Local).AddTicks(7928), new DateTime(2020, 7, 5, 11, 20, 18, 570, DateTimeKind.Local).AddTicks(178), "uuzrans", "Sunt est iure praesentium vitae sint quasi.", 19, true },
                    { 290, new DateTime(2020, 7, 28, 12, 54, 37, 464, DateTimeKind.Local).AddTicks(4750), new DateTime(2021, 4, 12, 20, 30, 55, 535, DateTimeKind.Local).AddTicks(3006), "jrmgej", "Rerum quod adipisci quia.", 18, true },
                    { 289, new DateTime(2021, 3, 31, 5, 12, 20, 714, DateTimeKind.Local).AddTicks(8016), new DateTime(2021, 4, 12, 20, 59, 36, 94, DateTimeKind.Local).AddTicks(3401), "otzoefspd", "occaecati", 18, true },
                    { 288, new DateTime(2020, 8, 2, 21, 13, 6, 343, DateTimeKind.Local).AddTicks(4918), new DateTime(2021, 4, 12, 22, 1, 13, 468, DateTimeKind.Local).AddTicks(2084), "qgvfizdhszp", "Quas iure aspernatur libero iste unde repellat.", 18, true },
                    { 287, new DateTime(2020, 5, 27, 0, 31, 4, 340, DateTimeKind.Local).AddTicks(8628), new DateTime(2021, 4, 12, 15, 31, 57, 114, DateTimeKind.Local).AddTicks(3304), "thqudmwe", "Beatae optio ipsam omnis laudantium vel soluta aperiam debitis expedita.\nMagnam doloremque debitis ea error dignissimos voluptas ab iusto.\nDebitis consequatur sit.\nNeque nobis porro qui mollitia architecto ex et.\nQuia pariatur perferendis ducimus quidem veritatis repudiandae quas aut maxime.", 18, true },
                    { 286, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(1733), new DateTime(2021, 4, 12, 12, 21, 56, 192, DateTimeKind.Local).AddTicks(7204), "mciqc", "Ea non est.\nEst officia quo totam.\nCumque magnam et cupiditate tenetur sit.\nEveniet vel saepe neque hic saepe libero molestiae dolores accusantium.\nQuidem est et molestiae temporibus atque nulla et.\nAliquam eaque error eos veniam unde.", 18, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 285, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(1540), new DateTime(2020, 7, 26, 2, 24, 27, 938, DateTimeKind.Local).AddTicks(2032), "puuddscsa", "Et minima maiores et numquam nostrum.", 18 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 284, new DateTime(2021, 4, 11, 22, 11, 4, 347, DateTimeKind.Local).AddTicks(1484), new DateTime(2021, 3, 5, 4, 26, 18, 285, DateTimeKind.Local).AddTicks(308), "qoskctfwdbzd", "Accusamus quod odio iste vitae quod natus enim ducimus ut.", 18, true },
                    { 265, new DateTime(2021, 3, 9, 16, 42, 53, 304, DateTimeKind.Local).AddTicks(3202), new DateTime(2020, 8, 28, 23, 30, 11, 729, DateTimeKind.Local).AddTicks(2505), "vmvdmzfwrkih", "Facilis nihil dolor quam. Aut officiis eius explicabo non sint dolor enim quidem iure. Voluptatem aut fugit enim. Sunt vel quia animi. Molestiae iusto qui sed qui enim ea.", 17, true },
                    { 264, new DateTime(2021, 4, 11, 22, 11, 4, 345, DateTimeKind.Local).AddTicks(3249), new DateTime(2020, 12, 22, 7, 26, 29, 807, DateTimeKind.Local).AddTicks(9941), "vyjamv", "Ducimus hic ut voluptas id aut.\nNon doloribus perferendis.\nUt repellat praesentium ut necessitatibus consequatur quo excepturi.\nEst doloremque fuga quaerat veritatis vitae et vel molestias consequatur.\nQui exercitationem quia labore dignissimos cum sunt.", 17, true },
                    { 263, new DateTime(2021, 4, 11, 22, 11, 4, 345, DateTimeKind.Local).AddTicks(3073), new DateTime(2020, 10, 5, 23, 16, 8, 687, DateTimeKind.Local).AddTicks(8823), "snhlobmrk", "non", 17, true },
                    { 262, new DateTime(2021, 4, 12, 3, 4, 43, 683, DateTimeKind.Local).AddTicks(4591), new DateTime(2021, 3, 2, 11, 57, 19, 498, DateTimeKind.Local).AddTicks(1549), "chdlmhy", "Soluta quia harum.\nFacere id exercitationem ducimus veniam voluptas.\nRatione non aut recusandae harum natus.", 17, true },
                    { 242, new DateTime(2021, 4, 11, 22, 11, 4, 343, DateTimeKind.Local).AddTicks(5434), new DateTime(2021, 4, 12, 3, 32, 5, 189, DateTimeKind.Local).AddTicks(4738), "hktfshopugt", "provident", 16, true },
                    { 241, new DateTime(2021, 4, 12, 19, 16, 12, 327, DateTimeKind.Local).AddTicks(6624), new DateTime(2020, 10, 13, 17, 47, 26, 520, DateTimeKind.Local).AddTicks(2574), "awjesgtnxx", "Qui quia sit.", 16, true },
                    { 240, new DateTime(2021, 4, 11, 22, 11, 4, 343, DateTimeKind.Local).AddTicks(5330), new DateTime(2020, 5, 3, 14, 25, 3, 343, DateTimeKind.Local).AddTicks(7457), "agksh", "Magnam perspiciatis doloribus.\nVoluptas aut ab.\nUt in atque dolorum dolor doloribus velit.\nEum mollitia optio vel.\nSapiente aliquid quod ipsam ut voluptatum enim.", 16, true },
                    { 239, new DateTime(2021, 4, 11, 23, 8, 7, 805, DateTimeKind.Local).AddTicks(6694), new DateTime(2020, 6, 15, 21, 36, 24, 482, DateTimeKind.Local).AddTicks(1480), "qmouxpnvczf", "rerum", 15, true },
                    { 238, new DateTime(2020, 6, 17, 13, 34, 7, 376, DateTimeKind.Local).AddTicks(2020), new DateTime(2020, 11, 17, 14, 24, 17, 340, DateTimeKind.Local).AddTicks(5256), "uealwzq", "voluptas", 15, true },
                    { 237, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(9120), new DateTime(2020, 5, 10, 13, 35, 56, 397, DateTimeKind.Local).AddTicks(7765), "vjfndyoarnu", "Quam earum eligendi eum non unde.\nAdipisci quia accusamus nobis voluptate commodi quia odio ut.\nA earum ut et rerum ipsa.\nIpsam vel totam.", 15, true },
                    { 236, new DateTime(2021, 4, 12, 16, 44, 15, 594, DateTimeKind.Local).AddTicks(3352), new DateTime(2021, 4, 12, 18, 9, 35, 175, DateTimeKind.Local).AddTicks(3001), "szgplibxqqs", "qui", 15, true },
                    { 235, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(8942), new DateTime(2021, 4, 12, 3, 24, 46, 272, DateTimeKind.Local).AddTicks(5628), "vigjcav", "Aut eum ea aut non aperiam aspernatur. Sint voluptatem quia adipisci. Dolores distinctio odit assumenda quia autem nemo occaecati numquam maxime. In voluptates non aspernatur esse dolor corporis quis. Officia impedit fugiat placeat sunt nihil incidunt.", 15, true },
                    { 234, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(8757), new DateTime(2020, 10, 26, 20, 14, 56, 344, DateTimeKind.Local).AddTicks(8260), "bfgllneddedv", "odit", 15, true },
                    { 233, new DateTime(2021, 4, 12, 8, 50, 4, 416, DateTimeKind.Local).AddTicks(7321), new DateTime(2021, 4, 12, 16, 34, 37, 408, DateTimeKind.Local).AddTicks(4298), "liemosc", "Consequatur ratione nemo debitis.", 15, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 232, new DateTime(2020, 12, 16, 19, 50, 31, 992, DateTimeKind.Local).AddTicks(7909), new DateTime(2020, 10, 20, 13, 55, 42, 26, DateTimeKind.Local).AddTicks(7468), "csynfotbvyn", "Et nam ea est molestias sint deleniti et.\nMaxime sit soluta quo rerum est.\nIn quis modi culpa sed doloribus qui.\nConsequatur pariatur quia et qui sit quos iste tempora.", 15 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 231, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(8510), new DateTime(2021, 4, 12, 2, 23, 53, 529, DateTimeKind.Local).AddTicks(3453), "gkyolda", "nobis", 15, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 230, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(8477), new DateTime(2021, 4, 12, 12, 54, 3, 371, DateTimeKind.Local).AddTicks(8730), "acntcjxn", "voluptatum", 15 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 229, new DateTime(2021, 4, 11, 22, 11, 4, 341, DateTimeKind.Local).AddTicks(8441), new DateTime(2020, 11, 10, 23, 9, 18, 11, DateTimeKind.Local).AddTicks(6516), "wovts", "Autem accusamus non suscipit unde.\nAccusantium recusandae quod iste exercitationem assumenda recusandae iusto necessitatibus.\nVero incidunt cum maxime qui fuga assumenda similique molestiae.\nId omnis amet.\nEa accusamus sequi ut soluta et deserunt blanditiis.\nDolores voluptatem optio et nobis.", 15, true },
                    { 228, new DateTime(2020, 4, 24, 4, 37, 30, 665, DateTimeKind.Local).AddTicks(3159), new DateTime(2020, 12, 1, 14, 34, 25, 952, DateTimeKind.Local).AddTicks(7833), "ujwrxqkdydrw", "Autem aliquid est illo facilis sunt.\nMaiores aut maxime natus dicta officia.\nVoluptatem voluptate odit.\nReiciendis culpa inventore corrupti cupiditate autem qui.", 15, true },
                    { 243, new DateTime(2021, 4, 11, 22, 11, 4, 343, DateTimeKind.Local).AddTicks(5564), new DateTime(2021, 4, 12, 18, 51, 35, 226, DateTimeKind.Local).AddTicks(1757), "gmmfwpbb", "Omnis quasi vitae facere voluptatibus quae.\nNumquam ex nemo.\nPlaceat dicta a quibusdam atque laboriosam necessitatibus.\nEt ut voluptate aliquid.", 16, true },
                    { 226, new DateTime(2021, 4, 12, 14, 18, 52, 639, DateTimeKind.Local).AddTicks(5815), new DateTime(2021, 4, 12, 3, 20, 46, 498, DateTimeKind.Local).AddTicks(8001), "stmlvnmgrt", "Quos nulla at temporibus laudantium laboriosam. Ex quia quia ut cupiditate. Quidem eveniet sint quod omnis laboriosam excepturi doloremque culpa. Quos voluptates temporibus.", 15, true },
                    { 244, new DateTime(2021, 4, 12, 1, 4, 41, 272, DateTimeKind.Local).AddTicks(4586), new DateTime(2020, 7, 25, 4, 41, 29, 132, DateTimeKind.Local).AddTicks(7084), "gvglmduch", "harum", 16, true },
                    { 246, new DateTime(2020, 5, 8, 4, 43, 56, 36, DateTimeKind.Local).AddTicks(6196), new DateTime(2021, 4, 12, 8, 43, 30, 975, DateTimeKind.Local).AddTicks(8365), "xwsxgifwtup", "Rem quia aspernatur placeat odit voluptatibus autem ut eaque fugit. Suscipit ducimus aut sunt quod quisquam placeat. Iure laudantium et quam. Atque cum culpa aut veniam ex.", 16, true },
                    { 261, new DateTime(2021, 4, 11, 22, 11, 4, 345, DateTimeKind.Local).AddTicks(2931), new DateTime(2021, 3, 12, 8, 29, 43, 962, DateTimeKind.Local).AddTicks(1982), "aqtxwacylx", "nihil", 17, true },
                    { 260, new DateTime(2021, 4, 12, 9, 7, 25, 83, DateTimeKind.Local).AddTicks(4251), new DateTime(2021, 4, 12, 5, 31, 34, 470, DateTimeKind.Local).AddTicks(5827), "iocjaz", "consequatur", 17, true },
                    { 259, new DateTime(2021, 4, 11, 22, 11, 4, 345, DateTimeKind.Local).AddTicks(2861), new DateTime(2020, 7, 10, 2, 56, 5, 771, DateTimeKind.Local).AddTicks(2243), "thmrfy", "Provident aut aspernatur perferendis voluptatem. Nihil beatae et distinctio temporibus voluptatem esse. Neque fugit sed iste. Alias aliquam non autem rerum aut ad nemo debitis debitis. Expedita eos esse occaecati. Nesciunt aperiam dolorem aut maiores.", 17, true },
                    { 258, new DateTime(2020, 11, 7, 17, 6, 56, 20, DateTimeKind.Local).AddTicks(9837), new DateTime(2020, 5, 15, 22, 25, 30, 52, DateTimeKind.Local).AddTicks(1800), "vhapjo", "Eaque ea eum fugiat ipsum magni sit.", 17, true },
                    { 257, new DateTime(2021, 4, 12, 5, 22, 25, 238, DateTimeKind.Local).AddTicks(8511), new DateTime(2020, 10, 15, 4, 13, 50, 659, DateTimeKind.Local).AddTicks(350), "xhjfbq", "Eum iste dolore doloribus sit.", 17, true },
                    { 256, new DateTime(2021, 4, 12, 10, 32, 0, 313, DateTimeKind.Local).AddTicks(8810), new DateTime(2020, 11, 20, 19, 27, 52, 242, DateTimeKind.Local).AddTicks(6207), "kdhdetg", "Est exercitationem repellendus omnis ipsam iure impedit est rerum.\nVoluptatem ipsa ut adipisci et repudiandae excepturi molestiae ab.\nVoluptas reprehenderit ab atque dolor.\nQui unde numquam tempore consequatur minus consequatur nostrum dolorem.", 17, true },
                    { 255, new DateTime(2021, 4, 11, 22, 11, 4, 345, DateTimeKind.Local).AddTicks(2383), new DateTime(2021, 2, 5, 20, 23, 43, 105, DateTimeKind.Local).AddTicks(5811), "eyarklgiodo", "ullam", 17, true },
                    { 254, new DateTime(2021, 4, 11, 22, 11, 4, 345, DateTimeKind.Local).AddTicks(2345), new DateTime(2020, 10, 20, 1, 6, 37, 410, DateTimeKind.Local).AddTicks(5386), "kqaomuixqzk", "Eum eligendi maiores ratione sit accusamus.\nA eum nobis voluptatem consequatur eius.\nAnimi earum quaerat.\nIn vitae voluptas dicta commodi officia.\nMaxime qui numquam.", 17, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 253, new DateTime(2020, 5, 7, 2, 36, 36, 42, DateTimeKind.Local).AddTicks(1530), new DateTime(2021, 2, 10, 16, 24, 4, 353, DateTimeKind.Local).AddTicks(9325), "stkennbcvcn", "ipsam", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 252, new DateTime(2021, 4, 12, 1, 49, 32, 999, DateTimeKind.Local).AddTicks(6562), new DateTime(2021, 3, 4, 5, 31, 51, 461, DateTimeKind.Local).AddTicks(4121), "rnxntm", "beatae", 16, true },
                    { 251, new DateTime(2020, 12, 18, 8, 6, 27, 843, DateTimeKind.Local).AddTicks(4847), new DateTime(2021, 4, 12, 2, 5, 57, 579, DateTimeKind.Local).AddTicks(9905), "fqexa", "est", 16, true },
                    { 250, new DateTime(2021, 4, 12, 5, 41, 6, 120, DateTimeKind.Local).AddTicks(4769), new DateTime(2020, 9, 20, 10, 12, 22, 720, DateTimeKind.Local).AddTicks(3511), "wpvrlbdnkipz", "sit", 16, true },
                    { 249, new DateTime(2020, 5, 21, 18, 31, 12, 126, DateTimeKind.Local).AddTicks(4791), new DateTime(2021, 3, 6, 16, 34, 11, 989, DateTimeKind.Local).AddTicks(4184), "gcnmxma", "Dolorem repudiandae optio qui velit et maiores vel veritatis.\nSoluta tenetur laboriosam aut maiores fuga.\nAut cupiditate cum est dolore.", 16, true },
                    { 248, new DateTime(2021, 4, 11, 22, 11, 4, 343, DateTimeKind.Local).AddTicks(5919), new DateTime(2020, 9, 9, 9, 35, 22, 910, DateTimeKind.Local).AddTicks(4877), "yrenxcjw", "Et est voluptatibus illum.", 16, true },
                    { 247, new DateTime(2021, 4, 12, 21, 30, 44, 662, DateTimeKind.Local).AddTicks(3232), new DateTime(2020, 8, 13, 13, 31, 43, 68, DateTimeKind.Local).AddTicks(2968), "gokqvphxx", "Sit dicta voluptas culpa delectus.", 16, true },
                    { 245, new DateTime(2021, 4, 12, 20, 2, 13, 413, DateTimeKind.Local).AddTicks(6592), new DateTime(2020, 10, 11, 7, 44, 10, 856, DateTimeKind.Local).AddTicks(5659), "sejjd", "Voluptatem consequatur minus quae neque occaecati officiis repellendus.", 16, true },
                    { 151, new DateTime(2021, 4, 11, 22, 57, 42, 237, DateTimeKind.Local).AddTicks(686), new DateTime(2021, 4, 12, 10, 22, 19, 157, DateTimeKind.Local).AddTicks(331), "qndaojjdgfy", "voluptatem", 10, true },
                    { 150, new DateTime(2021, 4, 11, 22, 11, 4, 331, DateTimeKind.Local).AddTicks(3374), new DateTime(2021, 4, 11, 23, 1, 7, 562, DateTimeKind.Local).AddTicks(4049), "hbqbzs", "Nesciunt ipsa voluptatum animi accusantium quas. Et et vitae illo rerum quaerat odit eum. Ut dolor aut temporibus sint. Nam laboriosam suscipit qui iste cumque quas et ab. Eum facere eos sunt. Aut quaerat id ab quo.", 10, true },
                    { 149, new DateTime(2021, 4, 12, 3, 59, 17, 547, DateTimeKind.Local).AddTicks(7552), new DateTime(2021, 4, 12, 11, 52, 0, 699, DateTimeKind.Local).AddTicks(958), "jmulcbxezkw", "Aut qui aut vitae quia quos voluptas adipisci nostrum voluptatum.\nDignissimos aut et laudantium quae culpa.\nNisi id et excepturi fugit id.\nOmnis et omnis eos et.\nUllam laborum placeat in.", 10, true },
                    { 53, new DateTime(2021, 4, 12, 19, 53, 14, 467, DateTimeKind.Local).AddTicks(7945), new DateTime(2021, 4, 12, 0, 0, 34, 25, DateTimeKind.Local).AddTicks(9356), "bjvqbztsbkry", "beatae", 4, true },
                    { 52, new DateTime(2021, 4, 11, 22, 11, 4, 319, DateTimeKind.Local).AddTicks(961), new DateTime(2021, 4, 12, 5, 3, 21, 508, DateTimeKind.Local).AddTicks(4492), "ewrwtmliaiei", "perspiciatis", 4, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 51, new DateTime(2021, 4, 11, 22, 11, 4, 319, DateTimeKind.Local).AddTicks(924), new DateTime(2021, 4, 12, 2, 8, 48, 165, DateTimeKind.Local).AddTicks(8522), "payrgbyf", "Laudantium quasi debitis ut. Sapiente corporis officia totam error esse dolores magnam fugiat. Similique dolores ut earum labore tenetur eos. Sit a suscipit possimus praesentium corporis quas sit dignissimos. Officiis alias saepe.", 4 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 50, new DateTime(2021, 4, 12, 19, 7, 40, 113, DateTimeKind.Local).AddTicks(9419), new DateTime(2021, 1, 27, 12, 15, 3, 107, DateTimeKind.Local).AddTicks(3975), "jwdsbciyzgls", "Ut velit quidem alias totam sapiente.", 4, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 49, new DateTime(2021, 4, 12, 17, 20, 4, 676, DateTimeKind.Local).AddTicks(9294), new DateTime(2020, 7, 4, 17, 10, 21, 42, DateTimeKind.Local).AddTicks(4368), "bcgfoku", "Ea sit recusandae.", 4 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 48, new DateTime(2021, 4, 12, 8, 21, 58, 376, DateTimeKind.Local).AddTicks(2729), new DateTime(2021, 4, 12, 21, 45, 16, 68, DateTimeKind.Local).AddTicks(7215), "rlhwdow", "Voluptates laborum aliquid maxime. Nihil blanditiis voluptas quisquam ullam cupiditate. Quia aut consequatur dolor amet perferendis est atque illo fugiat.", 4, true },
                    { 54, new DateTime(2021, 4, 11, 22, 11, 4, 320, DateTimeKind.Local).AddTicks(6991), new DateTime(2021, 4, 12, 9, 6, 50, 973, DateTimeKind.Local).AddTicks(4050), "rrydraignj", "dolorem", 5, true },
                    { 47, new DateTime(2021, 4, 12, 10, 26, 47, 53, DateTimeKind.Local).AddTicks(9721), new DateTime(2021, 4, 12, 4, 29, 11, 663, DateTimeKind.Local).AddTicks(6390), "lqhpcwywlil", "nesciunt", 4, true },
                    { 45, new DateTime(2020, 10, 19, 15, 32, 51, 132, DateTimeKind.Local).AddTicks(3036), new DateTime(2020, 7, 27, 13, 39, 10, 91, DateTimeKind.Local).AddTicks(7693), "lyclqyvfff", "Non voluptatem enim in nobis velit aut dolor reiciendis ullam. Fuga vitae corporis. Nesciunt fuga qui repellat optio est tempore. Est debitis doloribus modi omnis odio tenetur nemo. Iure fuga quas quia aut.", 4, true },
                    { 44, new DateTime(2021, 4, 11, 22, 11, 4, 319, DateTimeKind.Local).AddTicks(87), new DateTime(2020, 5, 27, 6, 26, 9, 300, DateTimeKind.Local).AddTicks(7304), "qejqenc", "natus", 4, true },
                    { 43, new DateTime(2021, 4, 11, 22, 11, 4, 319, DateTimeKind.Local).AddTicks(52), new DateTime(2021, 4, 12, 1, 14, 50, 827, DateTimeKind.Local).AddTicks(8613), "jwzhbzesip", "Sequi eum eos porro facilis quod tenetur dignissimos et.", 4, true },
                    { 42, new DateTime(2021, 4, 11, 22, 11, 4, 318, DateTimeKind.Local).AddTicks(9985), new DateTime(2021, 4, 12, 14, 54, 8, 690, DateTimeKind.Local).AddTicks(4320), "gjxcdrdw", "Dolores sint debitis.\nUllam ut necessitatibus tenetur.\nVoluptas quos velit.\nId consequatur rerum at non est.", 4, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 41, new DateTime(2021, 4, 11, 22, 11, 4, 318, DateTimeKind.Local).AddTicks(9868), new DateTime(2021, 3, 21, 23, 39, 16, 689, DateTimeKind.Local).AddTicks(8816), "ydovnodduki", "incidunt", 4 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 40, new DateTime(2021, 3, 3, 5, 4, 54, 502, DateTimeKind.Local).AddTicks(7617), new DateTime(2020, 8, 11, 12, 34, 15, 463, DateTimeKind.Local).AddTicks(4776), "lnkxlmruiws", "Non asperiores nostrum et dolor eum labore.", 4, true },
                    { 46, new DateTime(2021, 1, 12, 3, 57, 0, 594, DateTimeKind.Local).AddTicks(1239), new DateTime(2020, 4, 27, 18, 33, 16, 531, DateTimeKind.Local).AddTicks(4649), "voqib", "Consequatur quis quaerat mollitia ut occaecati eligendi amet sit.\nAccusantium asperiores assumenda ut blanditiis et iure amet.\nOdio ea doloribus magni.\nDicta quo ab et.\nIncidunt iure ex sed laudantium eum laboriosam.", 4, true },
                    { 55, new DateTime(2021, 4, 12, 5, 8, 26, 906, DateTimeKind.Local).AddTicks(1902), new DateTime(2021, 2, 13, 21, 55, 13, 4, DateTimeKind.Local).AddTicks(7649), "trhkiu", "Laudantium necessitatibus voluptas.", 5, true },
                    { 56, new DateTime(2021, 4, 12, 10, 20, 55, 871, DateTimeKind.Local).AddTicks(3452), new DateTime(2020, 10, 13, 20, 2, 14, 195, DateTimeKind.Local).AddTicks(6784), "rteeo", "Aut dolorum quam dolorum eos. Sint earum sit. Iste qui rerum id sed dolor. Provident facilis sed et et voluptatem veniam.", 5, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 57, new DateTime(2021, 4, 12, 19, 12, 31, 577, DateTimeKind.Local).AddTicks(4301), new DateTime(2021, 4, 12, 15, 21, 13, 839, DateTimeKind.Local).AddTicks(9036), "blknbgsm", "Similique similique sit quia. Omnis qui ut accusantium corporis porro id sit rem eos. Harum quam voluptatem. Occaecati nam fugit omnis iusto. Cumque quod aliquid eum quia.", 5, true },
                    { 72, new DateTime(2020, 11, 30, 3, 2, 15, 588, DateTimeKind.Local).AddTicks(4367), new DateTime(2020, 6, 14, 18, 35, 8, 958, DateTimeKind.Local).AddTicks(4881), "zwabgkkejt", "In commodi omnis reprehenderit recusandae soluta explicabo.", 6, true },
                    { 71, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(4551), new DateTime(2021, 2, 22, 19, 2, 29, 403, DateTimeKind.Local).AddTicks(9802), "nexhaagfppo", "Nemo qui sint sit consequuntur.\nVitae molestiae autem quis illum quia dolore sit dolorum.", 6, true },
                    { 70, new DateTime(2021, 4, 12, 20, 29, 36, 694, DateTimeKind.Local).AddTicks(7906), new DateTime(2021, 4, 12, 20, 49, 49, 49, DateTimeKind.Local).AddTicks(7529), "jphwaimzat", "quibusdam", 6, true },
                    { 69, new DateTime(2021, 3, 1, 16, 29, 47, 199, DateTimeKind.Local).AddTicks(213), new DateTime(2021, 4, 12, 11, 44, 18, 3, DateTimeKind.Local).AddTicks(4507), "kvwrayawmb", "Libero repellat soluta aut nemo recusandae.\nDoloremque quia aut nulla vel error ut voluptatibus consequuntur voluptatum.\nMaiores est quod temporibus illo.\nSunt perspiciatis velit qui.\nQui aut nulla.", 6, true },
                    { 68, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(4249), new DateTime(2021, 4, 12, 10, 16, 50, 56, DateTimeKind.Local).AddTicks(6804), "uojvz", "Molestiae qui et.", 6, true },
                    { 67, new DateTime(2021, 2, 25, 6, 56, 9, 264, DateTimeKind.Local).AddTicks(817), new DateTime(2021, 3, 26, 3, 39, 28, 140, DateTimeKind.Local).AddTicks(2784), "jgpvervwxspw", "Sit esse alias ad aut consequatur aperiam ex quis.", 6, true },
                    { 66, new DateTime(2020, 5, 13, 9, 53, 42, 920, DateTimeKind.Local).AddTicks(933), new DateTime(2020, 6, 19, 16, 48, 23, 829, DateTimeKind.Local).AddTicks(6484), "xkfoexdsahky", "Sapiente eligendi officiis voluptas pariatur facilis et dolorem nulla distinctio. Et ipsam pariatur aut quas repellat hic et laboriosam ea. Excepturi non perferendis asperiores. Velit qui delectus ea consectetur tempora eveniet nulla. Reprehenderit harum sint ad delectus ut vel.", 5, true },
                    { 65, new DateTime(2021, 4, 12, 18, 48, 52, 507, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 12, 23, 6, 24, 46, 263, DateTimeKind.Local).AddTicks(7464), "tjcjxd", "Rerum commodi ullam amet.", 5, true },
                    { 64, new DateTime(2021, 4, 11, 22, 11, 4, 320, DateTimeKind.Local).AddTicks(7969), new DateTime(2021, 4, 12, 9, 33, 43, 579, DateTimeKind.Local).AddTicks(4405), "tzcebfy", "ab", 5, true },
                    { 63, new DateTime(2020, 5, 29, 16, 45, 1, 405, DateTimeKind.Local).AddTicks(3296), new DateTime(2020, 6, 22, 10, 27, 11, 963, DateTimeKind.Local).AddTicks(6854), "alxxrtugh", "Ut tempora et et qui voluptas nihil.\nQui sapiente incidunt a qui est officia dolores beatae.\nEius id consequatur ipsa praesentium et provident.\nEarum ullam ut numquam architecto.", 5, true },
                    { 62, new DateTime(2020, 4, 29, 1, 57, 38, 601, DateTimeKind.Local).AddTicks(9467), new DateTime(2020, 4, 19, 6, 49, 0, 390, DateTimeKind.Local).AddTicks(4567), "dmjoc", "quasi", 5, true },
                    { 61, new DateTime(2020, 5, 23, 13, 13, 11, 1, DateTimeKind.Local).AddTicks(5854), new DateTime(2020, 5, 29, 22, 22, 25, 733, DateTimeKind.Local).AddTicks(523), "zlmyy", "Quasi eum soluta ut voluptatem voluptatum et consequatur magni.", 5, true },
                    { 60, new DateTime(2020, 6, 27, 6, 22, 27, 864, DateTimeKind.Local).AddTicks(8648), new DateTime(2021, 4, 12, 20, 8, 45, 977, DateTimeKind.Local).AddTicks(8695), "tnakwcdmw", "Adipisci inventore itaque rem voluptas aut eligendi dolor. Aspernatur iusto aut earum commodi sit numquam nesciunt et. Perspiciatis maiores expedita quibusdam laudantium aut doloremque debitis. Provident ut incidunt maiores maxime nisi corporis ab id.", 5, true },
                    { 59, new DateTime(2021, 4, 11, 22, 11, 4, 320, DateTimeKind.Local).AddTicks(7506), new DateTime(2020, 12, 8, 12, 4, 38, 508, DateTimeKind.Local).AddTicks(7589), "efdywhxkkh", "Error delectus reiciendis quam.\nSint tempore fugiat sunt omnis sed perferendis dolores.", 5, true },
                    { 58, new DateTime(2020, 8, 28, 12, 25, 50, 572, DateTimeKind.Local).AddTicks(6202), new DateTime(2021, 4, 12, 15, 51, 34, 842, DateTimeKind.Local).AddTicks(8667), "yeysdiskax", "Illo placeat vel.", 5, true },
                    { 39, new DateTime(2021, 4, 9, 2, 3, 27, 471, DateTimeKind.Local).AddTicks(3175), new DateTime(2021, 4, 12, 14, 50, 16, 935, DateTimeKind.Local).AddTicks(792), "jorfhurxhtzu", "animi", 4, true },
                    { 38, new DateTime(2021, 4, 11, 22, 11, 4, 318, DateTimeKind.Local).AddTicks(9734), new DateTime(2020, 10, 28, 10, 52, 46, 397, DateTimeKind.Local).AddTicks(6793), "flnawbued", "Sed minima iusto laudantium est sequi. Aliquam et qui. Sit qui quia vero quas in iusto. Quaerat harum quia quos enim eos voluptas tempore corrupti sunt. Occaecati neque eum doloremque est blanditiis id.", 4, true },
                    { 37, new DateTime(2020, 7, 17, 20, 2, 5, 720, DateTimeKind.Local).AddTicks(8540), new DateTime(2020, 7, 14, 1, 35, 57, 545, DateTimeKind.Local).AddTicks(9461), "casmibq", "Sit reiciendis corporis numquam quaerat culpa maxime doloribus. Eos perspiciatis nobis natus. Delectus explicabo culpa aspernatur. Earum deserunt perspiciatis aut dolor aliquid est sed et. Assumenda qui assumenda non unde debitis quisquam facilis. Sint ea voluptas.", 4, true },
                    { 36, new DateTime(2021, 4, 12, 2, 25, 35, 926, DateTimeKind.Local).AddTicks(9558), new DateTime(2020, 10, 7, 0, 50, 49, 460, DateTimeKind.Local).AddTicks(4327), "ramvaaxeati", "Ad voluptas qui ipsam temporibus quasi totam dignissimos facere.\nAspernatur voluptatem consequatur doloremque quidem quia velit non cumque rerum.", 4, true },
                    { 16, new DateTime(2021, 4, 12, 1, 22, 13, 888, DateTimeKind.Local).AddTicks(4616), new DateTime(2020, 8, 5, 5, 43, 50, 256, DateTimeKind.Local).AddTicks(6004), "hnrhppt", "Blanditiis quisquam aut possimus alias et laboriosam aliquid facilis eveniet.\nMolestias ratione tempora aut ut odit velit.\nAut est ratione voluptas quia vitae commodi accusamus.", 3, true },
                    { 15, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(1844), new DateTime(2021, 4, 12, 9, 54, 2, 725, DateTimeKind.Local).AddTicks(9597), "wljxo", "Velit nihil in iste ipsa qui culpa nihil.", 3, true },
                    { 14, new DateTime(2020, 8, 6, 4, 17, 16, 199, DateTimeKind.Local).AddTicks(7768), new DateTime(2020, 4, 24, 15, 53, 50, 778, DateTimeKind.Local).AddTicks(2911), "fbceal", "Error a nulla reprehenderit nisi quo dolores sapiente provident eaque.\nRerum expedita perferendis quas in ipsam sed saepe.\nCum architecto inventore voluptatem.\nVeritatis amet vel.", 3, true },
                    { 13, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(1630), new DateTime(2020, 12, 24, 17, 13, 56, 618, DateTimeKind.Local).AddTicks(9181), "ykumyiaas", "Dolorem quos modi aut.\nMolestias ducimus ullam ad et.\nQuo sapiente ut fuga vel consequatur cumque consequatur optio dolorem.", 3, true },
                    { 12, new DateTime(2021, 4, 12, 14, 22, 4, 371, DateTimeKind.Local).AddTicks(2345), new DateTime(2020, 5, 19, 8, 21, 44, 868, DateTimeKind.Local).AddTicks(517), "ebrbcxxnna", "Sit est illo nemo.\nVoluptatum doloribus sint voluptas omnis ducimus explicabo.\nIure qui labore labore assumenda animi et neque veniam.", 3, true },
                    { 11, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(1386), new DateTime(2021, 4, 12, 5, 37, 53, 903, DateTimeKind.Local).AddTicks(7762), "leiazjefdzx", "dolorum", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 10, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(1350), new DateTime(2021, 4, 12, 0, 2, 56, 639, DateTimeKind.Local).AddTicks(40), "ipvetmnj", "quis", 3 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(1313), new DateTime(2021, 4, 12, 20, 57, 15, 962, DateTimeKind.Local).AddTicks(5892), "toapvvroie", "Autem modi ut voluptate qui tempora illo. Commodi labore odio assumenda facilis vitae modi ab. Doloremque similique quod inventore voluptatum et necessitatibus qui ducimus ea. Iste sit incidunt blanditiis voluptate qui at.", 3, true },
                    { 8, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(1131), new DateTime(2020, 10, 13, 13, 57, 41, 839, DateTimeKind.Local).AddTicks(3984), "wsrvlst", "Eos maxime esse assumenda et quia.\nMolestiae enim incidunt corporis sed aliquid quam in distinctio veritatis.", 3, true },
                    { 7, new DateTime(2020, 11, 24, 2, 17, 23, 653, DateTimeKind.Local).AddTicks(1130), new DateTime(2020, 5, 25, 20, 48, 55, 215, DateTimeKind.Local).AddTicks(40), "kytdkgbvrjli", "Laudantium aut autem sint temporibus neque facere dicta quia.\nNobis id recusandae sit cupiditate harum.\nIn deleniti numquam.\nAperiam provident natus numquam libero consequatur sit nobis nam.", 3, true },
                    { 6, new DateTime(2020, 7, 8, 7, 36, 34, 892, DateTimeKind.Local).AddTicks(8300), new DateTime(2020, 12, 23, 21, 59, 6, 379, DateTimeKind.Local).AddTicks(7645), "uurzmsqzb", "est", 2, true },
                    { 5, new DateTime(2021, 4, 12, 13, 15, 23, 629, DateTimeKind.Local).AddTicks(1860), new DateTime(2020, 5, 23, 3, 45, 31, 13, DateTimeKind.Local).AddTicks(7479), "wwqlkgi", "Natus aliquam corrupti.\nAlias dolores dolor maxime voluptatem et dolorem ducimus qui.", 2, true },
                    { 4, new DateTime(2021, 4, 11, 22, 11, 4, 309, DateTimeKind.Local).AddTicks(3326), new DateTime(2020, 8, 14, 6, 39, 45, 423, DateTimeKind.Local).AddTicks(3016), "ujauwzaviibk", "Ullam nulla necessitatibus non omnis impedit.", 2, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 3, new DateTime(2021, 4, 11, 22, 11, 4, 309, DateTimeKind.Local).AddTicks(2854), new DateTime(2020, 10, 20, 17, 18, 45, 144, DateTimeKind.Local).AddTicks(9466), "ozjnckbuzr", "Molestias error quaerat rerum quo. Dolor velit est numquam voluptatibus dolores corporis omnis. Temporibus sequi voluptas. Et eos dolor fugit a aut. Quam incidunt corrupti dolorum nisi eum quo ratione voluptatum.", 2 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 4, 12, 8, 53, 13, 334, DateTimeKind.Local).AddTicks(168), new DateTime(2021, 1, 16, 2, 4, 39, 122, DateTimeKind.Local).AddTicks(923), "uuxadvf", "Hic natus corporis iure sit laborum magnam est magnam. Culpa natus et totam inventore voluptatum voluptatem tempora. Consequatur quo sed excepturi sint iure sint. In excepturi maxime odit voluptatem et et fugiat ad. Et aut officia molestias voluptate.", 2, true },
                    { 17, new DateTime(2021, 4, 12, 17, 38, 27, 681, DateTimeKind.Local).AddTicks(4268), new DateTime(2020, 11, 24, 18, 45, 31, 770, DateTimeKind.Local).AddTicks(26), "wvptry", "aliquam", 3, true },
                    { 73, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(4646), new DateTime(2020, 7, 16, 23, 4, 51, 170, DateTimeKind.Local).AddTicks(1021), "enmqe", "praesentium", 6, true },
                    { 18, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(2195), new DateTime(2020, 9, 16, 21, 28, 59, 842, DateTimeKind.Local).AddTicks(2727), "obdfhktr", "Eius eum numquam quidem quia.\nExplicabo et voluptate non iusto voluptatibus neque excepturi necessitatibus cumque.\nNemo maiores velit aut est.\nQui et sequi itaque dolorem.\nVeritatis ut quia et nam et.", 3, true },
                    { 20, new DateTime(2021, 2, 7, 2, 45, 33, 598, DateTimeKind.Local).AddTicks(81), new DateTime(2021, 4, 12, 12, 47, 45, 299, DateTimeKind.Local).AddTicks(9736), "tpbyvj", "quo", 3, true },
                    { 35, new DateTime(2021, 4, 12, 20, 0, 56, 385, DateTimeKind.Local).AddTicks(3310), new DateTime(2021, 1, 11, 2, 32, 46, 980, DateTimeKind.Local).AddTicks(7729), "yioeitsxem", "Voluptatem sequi totam aut repellendus ab eos ex.", 4, true },
                    { 34, new DateTime(2021, 1, 20, 16, 50, 35, 584, DateTimeKind.Local).AddTicks(8234), new DateTime(2020, 9, 27, 4, 57, 39, 501, DateTimeKind.Local).AddTicks(5955), "pyrktsmiv", "illo", 4, true },
                    { 33, new DateTime(2021, 1, 25, 11, 19, 17, 529, DateTimeKind.Local).AddTicks(6850), new DateTime(2021, 4, 12, 7, 21, 41, 377, DateTimeKind.Local).AddTicks(4741), "fxggr", "Ipsam ex harum dolor molestias. Nihil fugit quod. Dignissimos fugit tenetur voluptatibus voluptatibus nobis quo est iste fugit. Autem perferendis inventore perferendis quia enim nihil.", 4, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 32, new DateTime(2021, 4, 12, 2, 33, 25, 554, DateTimeKind.Local).AddTicks(5063), new DateTime(2021, 1, 26, 16, 30, 26, 986, DateTimeKind.Local).AddTicks(1700), "vxzhlpgieemq", "Magni debitis accusamus a qui accusamus numquam odit sit.", 4, true },
                    { 31, new DateTime(2021, 4, 11, 22, 11, 4, 318, DateTimeKind.Local).AddTicks(8901), new DateTime(2020, 4, 18, 1, 4, 51, 792, DateTimeKind.Local).AddTicks(5318), "fdvruhldk", "Culpa dolorem quia inventore minima repellendus repudiandae cupiditate. Sit occaecati rerum quia odit aut reprehenderit sunt accusamus. Distinctio et nam eaque totam nesciunt laudantium officiis. Tempora in placeat ad sunt ratione et sit assumenda magni. Deserunt dolor dolor. Saepe mollitia rerum ex eligendi quos quae iste.", 4, true },
                    { 30, new DateTime(2021, 4, 11, 22, 11, 4, 318, DateTimeKind.Local).AddTicks(8574), new DateTime(2021, 4, 12, 7, 16, 8, 150, DateTimeKind.Local).AddTicks(3023), "hukpyxqwip", "Ab nihil praesentium dolores amet quis quos similique odio aut. Corporis corrupti voluptas eius aut ex tenetur. Voluptatem qui doloribus qui. Modi nam provident neque ab iste dolor quas.", 4, true },
                    { 29, new DateTime(2021, 4, 12, 4, 1, 26, 245, DateTimeKind.Local).AddTicks(8482), new DateTime(2020, 6, 9, 22, 54, 27, 293, DateTimeKind.Local).AddTicks(8443), "vkxqvna", "Ipsam ut perspiciatis tenetur. Quibusdam veniam dolores sit totam ut incidunt corrupti aut. Earum dolor dignissimos quia voluptatibus enim voluptatem et dicta qui. Molestiae temporibus non necessitatibus consequatur nostrum molestiae.", 3, true },
                    { 28, new DateTime(2021, 4, 12, 4, 34, 37, 896, DateTimeKind.Local).AddTicks(9089), new DateTime(2021, 4, 12, 2, 31, 45, 403, DateTimeKind.Local).AddTicks(1190), "svzlwekqzikt", "Velit laboriosam dolor iste fugit eum.", 3, true },
                    { 27, new DateTime(2020, 5, 29, 0, 53, 18, 567, DateTimeKind.Local).AddTicks(9185), new DateTime(2020, 8, 12, 11, 8, 17, 421, DateTimeKind.Local).AddTicks(5066), "nypudr", "id", 3, true },
                    { 26, new DateTime(2020, 7, 23, 7, 2, 30, 294, DateTimeKind.Local).AddTicks(6855), new DateTime(2020, 7, 13, 18, 14, 5, 259, DateTimeKind.Local).AddTicks(8083), "ikbvrlidkk", "rem", 3, true },
                    { 25, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(2713), new DateTime(2021, 4, 12, 15, 43, 38, 774, DateTimeKind.Local).AddTicks(9045), "vmkbnkvtrwy", "Sit ipsa ullam totam nemo id et. Facere tempore tempore debitis quia. Consequatur ab architecto aut consequuntur.", 3, true },
                    { 24, new DateTime(2020, 4, 25, 17, 36, 42, 294, DateTimeKind.Local).AddTicks(4075), new DateTime(2021, 4, 12, 11, 14, 8, 859, DateTimeKind.Local).AddTicks(5341), "gtqppssq", "Nemo magni ducimus beatae ab saepe est molestias error.", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 23, new DateTime(2020, 7, 18, 14, 57, 35, 534, DateTimeKind.Local).AddTicks(3500), new DateTime(2020, 10, 30, 17, 23, 55, 260, DateTimeKind.Local).AddTicks(7021), "gakmnkvir", "Omnis iusto sit.", 3 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 22, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(2483), new DateTime(2021, 2, 17, 19, 44, 59, 183, DateTimeKind.Local).AddTicks(4103), "rrcljhx", "Aut at autem voluptatem numquam.", 3, true },
                    { 21, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(2420), new DateTime(2020, 4, 30, 0, 53, 27, 355, DateTimeKind.Local).AddTicks(3228), "gmyjinjce", "Accusantium atque consequuntur hic voluptate ipsam fuga et quis.\nDolorum magni accusantium quia debitis dolorem.\nAut quod sunt nulla totam labore fugit ut itaque.", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 19, new DateTime(2021, 4, 11, 22, 11, 4, 311, DateTimeKind.Local).AddTicks(2257), new DateTime(2020, 10, 11, 23, 44, 23, 826, DateTimeKind.Local).AddTicks(9847), "ycczsksljqik", "Quasi quo ab ipsa enim dolor ut.", 3 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 74, new DateTime(2020, 9, 19, 23, 30, 33, 183, DateTimeKind.Local).AddTicks(2781), new DateTime(2021, 4, 12, 5, 22, 4, 650, DateTimeKind.Local).AddTicks(5814), "llzobd", "Facere veritatis vero qui.\nQuae minima a quidem nisi dolore.\nOfficiis fugit magni provident sed illum dignissimos ullam.\nVoluptas architecto doloribus aliquid.\nIure temporibus occaecati.", 6, true },
                    { 75, new DateTime(2020, 10, 29, 20, 8, 47, 971, DateTimeKind.Local).AddTicks(5313), new DateTime(2020, 11, 2, 23, 8, 11, 303, DateTimeKind.Local).AddTicks(2990), "ibgvuf", "Sunt quia eum doloremque molestiae suscipit tempora.\nAlias repudiandae doloribus accusamus temporibus.", 6, true },
                    { 76, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(5082), new DateTime(2021, 2, 17, 23, 38, 23, 796, DateTimeKind.Local).AddTicks(4460), "ogbhutemkqk", "Et a quos quidem in enim. Ullam tenetur aut commodi non laborum laborum. Laboriosam quia et eum quo. Architecto autem qui quia culpa ab officiis qui ad deserunt. A maiores deserunt. Rerum dignissimos at voluptatum nemo minima nostrum.", 6, true },
                    { 129, new DateTime(2021, 4, 11, 22, 11, 4, 329, DateTimeKind.Local).AddTicks(4991), new DateTime(2020, 12, 20, 0, 25, 10, 675, DateTimeKind.Local).AddTicks(1579), "lhtgbe", "Minima quae commodi pariatur quia aperiam officiis optio.", 9, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[,]
                {
                    { 128, new DateTime(2021, 4, 12, 4, 56, 32, 340, DateTimeKind.Local).AddTicks(7379), new DateTime(2021, 4, 12, 13, 6, 25, 714, DateTimeKind.Local).AddTicks(3728), "oxxrxkthjffl", "Sunt aliquid velit nisi minima nisi eos est.\nReprehenderit sequi neque tempore aut vitae.\nEt ea ex illum molestias sed.\nQuo consequatur sunt et eum et.\nConsequatur repellat autem minima.", 9 },
                    { 127, new DateTime(2021, 4, 11, 22, 11, 4, 329, DateTimeKind.Local).AddTicks(4757), new DateTime(2020, 8, 24, 9, 33, 50, 372, DateTimeKind.Local).AddTicks(3108), "dlbmu", "Non repellendus fuga ipsam quas beatae beatae qui. Doloribus ipsa ipsa repellat quas eaque voluptas officia rerum. Eos eos pariatur officiis quia. Quia quo eos adipisci nemo enim quis. Nihil sequi fuga nihil nemo perspiciatis. Eos esse blanditiis quisquam.", 9 }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 126, new DateTime(2021, 4, 12, 3, 24, 50, 302, DateTimeKind.Local).AddTicks(7487), new DateTime(2021, 1, 22, 12, 30, 34, 801, DateTimeKind.Local).AddTicks(9218), "eelvfy", "Et qui nostrum non exercitationem pariatur nostrum incidunt.\nQuasi voluptatem sit ipsum nobis velit ab fuga ab.", 9, true },
                    { 125, new DateTime(2020, 6, 23, 3, 22, 22, 263, DateTimeKind.Local).AddTicks(3875), new DateTime(2020, 8, 25, 18, 17, 29, 603, DateTimeKind.Local).AddTicks(9264), "zmwfplutkeg", "Vero nihil id et pariatur esse mollitia consequatur sint voluptas.", 9, true },
                    { 124, new DateTime(2021, 4, 12, 10, 13, 31, 993, DateTimeKind.Local).AddTicks(3509), new DateTime(2021, 4, 11, 22, 53, 29, 290, DateTimeKind.Local).AddTicks(1670), "aucqjnin", "Deserunt perspiciatis ea odit sed porro veritatis et.\nMagnam possimus rem.\nRepellendus cum temporibus vel.\nOdit voluptas aliquid cum cumque iste dolor dolorem.", 9, true },
                    { 123, new DateTime(2021, 4, 11, 22, 11, 4, 327, DateTimeKind.Local).AddTicks(8276), new DateTime(2021, 4, 12, 1, 53, 42, 564, DateTimeKind.Local).AddTicks(6529), "yculyfduwe", "Alias quia temporibus voluptatem soluta maiores quia consequuntur.\nReiciendis ut qui aut suscipit quasi perspiciatis.\nPorro et iste.", 8, true },
                    { 122, new DateTime(2021, 4, 11, 22, 11, 4, 327, DateTimeKind.Local).AddTicks(8163), new DateTime(2021, 4, 12, 1, 0, 59, 374, DateTimeKind.Local).AddTicks(7165), "csywnwxvfhrd", "Animi dolor quo culpa modi aut maiores eum voluptatibus quasi.", 8, true },
                    { 121, new DateTime(2020, 7, 25, 7, 27, 23, 936, DateTimeKind.Local).AddTicks(8339), new DateTime(2020, 6, 16, 2, 23, 7, 615, DateTimeKind.Local).AddTicks(5316), "sssnlvtr", "Est perferendis facere mollitia odio nam rerum sit est. Cupiditate quam sit vel quae ut sequi. Et quidem est assumenda accusantium molestiae et quis eos sint.", 8, true },
                    { 120, new DateTime(2020, 6, 5, 4, 44, 57, 587, DateTimeKind.Local).AddTicks(3467), new DateTime(2021, 4, 12, 8, 58, 58, 503, DateTimeKind.Local).AddTicks(1583), "ibryoqdsxf", "reiciendis", 8, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 119, new DateTime(2020, 10, 25, 3, 9, 42, 435, DateTimeKind.Local).AddTicks(9218), new DateTime(2021, 3, 11, 21, 56, 35, 925, DateTimeKind.Local).AddTicks(8232), "ixogsgigm", "facere", 8 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 118, new DateTime(2020, 10, 10, 19, 19, 55, 54, DateTimeKind.Local).AddTicks(8172), new DateTime(2020, 4, 23, 21, 0, 31, 450, DateTimeKind.Local).AddTicks(7661), "zbyzmo", "delectus", 8, true },
                    { 117, new DateTime(2021, 4, 12, 3, 23, 19, 190, DateTimeKind.Local).AddTicks(5272), new DateTime(2020, 6, 5, 15, 51, 46, 715, DateTimeKind.Local).AddTicks(7467), "jaqkcvcffp", "et", 8, true },
                    { 116, new DateTime(2020, 8, 6, 23, 39, 17, 534, DateTimeKind.Local).AddTicks(6786), new DateTime(2020, 11, 2, 18, 5, 33, 101, DateTimeKind.Local).AddTicks(3000), "sxieqhdbbnc", "Laboriosam cumque qui ut. Sapiente recusandae ipsum qui. Voluptatum molestiae qui cum aspernatur. Hic blanditiis id dolor unde sint officia eveniet neque hic. Sit aspernatur voluptatem ipsa quaerat occaecati aut quia. Aspernatur qui deleniti similique voluptas unde blanditiis aut.", 8, true },
                    { 115, new DateTime(2021, 2, 8, 4, 43, 15, 32, DateTimeKind.Local).AddTicks(6068), new DateTime(2021, 4, 12, 0, 16, 13, 963, DateTimeKind.Local).AddTicks(3136), "fcjmepubk", "Repellat et eligendi id asperiores. Voluptatum quod eaque aut eos. Ut dolorem ut ab repellendus eius vero. Ratione perspiciatis magni numquam enim.", 8, true },
                    { 130, new DateTime(2021, 4, 11, 22, 11, 4, 329, DateTimeKind.Local).AddTicks(5206), new DateTime(2020, 11, 19, 14, 42, 28, 582, DateTimeKind.Local).AddTicks(1601), "ukpumz", "Quia explicabo amet sapiente placeat excepturi. Perspiciatis ipsum recusandae. Quidem cupiditate sequi corrupti voluptate minima deserunt repudiandae rem odit. Non ut mollitia totam libero animi. Aliquam quis voluptatem culpa qui quibusdam. Est id officia adipisci ipsa voluptas harum exercitationem et occaecati.", 9, true },
                    { 114, new DateTime(2020, 7, 13, 17, 53, 16, 499, DateTimeKind.Local).AddTicks(9090), new DateTime(2021, 4, 12, 9, 10, 16, 737, DateTimeKind.Local).AddTicks(3710), "ciirqvzpdbjc", "et", 8, true },
                    { 131, new DateTime(2021, 3, 22, 16, 19, 15, 590, DateTimeKind.Local).AddTicks(4602), new DateTime(2021, 4, 12, 15, 27, 39, 673, DateTimeKind.Local).AddTicks(1945), "hywhjhv", "Repudiandae est eligendi.", 9, true },
                    { 133, new DateTime(2021, 4, 12, 14, 19, 52, 590, DateTimeKind.Local).AddTicks(6523), new DateTime(2021, 4, 12, 1, 45, 4, 893, DateTimeKind.Local).AddTicks(3256), "jpssqtm", "aut", 9, true },
                    { 148, new DateTime(2020, 7, 21, 21, 27, 15, 112, DateTimeKind.Local).AddTicks(7306), new DateTime(2021, 4, 12, 19, 8, 27, 101, DateTimeKind.Local).AddTicks(6933), "oulnjnc", "Laboriosam expedita repellendus temporibus et quasi eum vero voluptatibus.\nAperiam eum sunt doloremque neque quas illum perferendis omnis voluptatem.\nSimilique quia nihil minus id.\nIn blanditiis odit voluptate iure at reiciendis rerum illo nihil.\nOccaecati recusandae consequuntur illo sunt et quaerat.", 10, true },
                    { 147, new DateTime(2021, 4, 11, 22, 11, 4, 331, DateTimeKind.Local).AddTicks(2802), new DateTime(2020, 10, 8, 19, 1, 26, 989, DateTimeKind.Local).AddTicks(8488), "czpubwlhr", "Ea rerum quaerat debitis quo numquam aperiam repellendus eum voluptatem.\nEt alias veniam vel ea repudiandae fugiat fuga.\nHic provident quibusdam tempora quo non.", 10, true },
                    { 146, new DateTime(2020, 8, 13, 15, 55, 10, 812, DateTimeKind.Local).AddTicks(1471), new DateTime(2021, 3, 8, 23, 47, 49, 445, DateTimeKind.Local).AddTicks(9505), "bodyiqbg", "Et a asperiores quis qui omnis voluptatum. Impedit est non modi. Et voluptas eaque veniam adipisci ipsa beatae nemo. Aliquid mollitia ullam aperiam debitis numquam exercitationem asperiores rem eveniet. Aut id soluta fugit veniam voluptates.", 10, true },
                    { 145, new DateTime(2021, 4, 11, 22, 11, 4, 331, DateTimeKind.Local).AddTicks(2478), new DateTime(2021, 4, 12, 2, 50, 43, 141, DateTimeKind.Local).AddTicks(321), "qwevnxbtvyk", "rerum", 10, true },
                    { 144, new DateTime(2021, 2, 16, 7, 26, 18, 147, DateTimeKind.Local).AddTicks(1442), new DateTime(2021, 4, 12, 4, 42, 38, 12, DateTimeKind.Local).AddTicks(1134), "eopaculteb", "delectus", 10, true },
                    { 143, new DateTime(2020, 5, 9, 15, 53, 1, 858, DateTimeKind.Local).AddTicks(5661), new DateTime(2020, 7, 1, 14, 7, 55, 732, DateTimeKind.Local).AddTicks(8008), "hpkpjwurz", "Rerum similique consequatur quod est officiis consequatur adipisci.\nIn nulla dolor id quia aperiam minima assumenda.", 10, true },
                    { 142, new DateTime(2021, 4, 12, 6, 11, 3, 768, DateTimeKind.Local).AddTicks(4757), new DateTime(2020, 9, 12, 14, 33, 34, 622, DateTimeKind.Local).AddTicks(97), "qbzwfsum", "Velit laboriosam repellendus. Fuga aut est laborum distinctio quas qui at. Asperiores est nisi ab. Repudiandae iusto consequatur voluptas omnis itaque earum necessitatibus molestiae.", 10, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 141, new DateTime(2021, 4, 11, 22, 11, 4, 329, DateTimeKind.Local).AddTicks(6083), new DateTime(2021, 4, 12, 8, 56, 44, 165, DateTimeKind.Local).AddTicks(3666), "zmdkfnpj", "Iste expedita nisi similique ullam omnis porro non nostrum quod.\nDoloribus ea aut tempora.\nAliquam officia asperiores.\nAut accusamus ipsa soluta veritatis nesciunt voluptates rem recusandae.", 9, true },
                    { 140, new DateTime(2021, 4, 11, 23, 35, 38, 737, DateTimeKind.Local).AddTicks(3167), new DateTime(2021, 4, 12, 14, 40, 21, 249, DateTimeKind.Local).AddTicks(7914), "hislguwsj", "architecto", 9, true },
                    { 139, new DateTime(2020, 9, 27, 14, 54, 16, 309, DateTimeKind.Local).AddTicks(4704), new DateTime(2020, 8, 30, 9, 8, 3, 194, DateTimeKind.Local).AddTicks(2541), "xceazbewm", "Voluptates cupiditate doloremque cupiditate recusandae voluptatem aut odit animi dicta.\nEum occaecati excepturi illo nihil porro.\nUllam autem enim.", 9, true },
                    { 138, new DateTime(2021, 4, 12, 16, 0, 19, 774, DateTimeKind.Local).AddTicks(7462), new DateTime(2021, 4, 12, 3, 31, 8, 548, DateTimeKind.Local).AddTicks(6986), "quklssevfu", "soluta", 9, true },
                    { 137, new DateTime(2021, 4, 11, 22, 11, 4, 329, DateTimeKind.Local).AddTicks(5748), new DateTime(2020, 10, 3, 10, 59, 27, 473, DateTimeKind.Local).AddTicks(2950), "griipsvtxqdr", "dignissimos", 9, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 136, new DateTime(2020, 10, 17, 12, 54, 21, 864, DateTimeKind.Local).AddTicks(617), new DateTime(2021, 4, 11, 23, 24, 21, 290, DateTimeKind.Local).AddTicks(6776), "ewbwumjxmk", "Dicta est amet aliquid.\nQui minima in occaecati cum dolorum quam.\nCommodi dolorem voluptate asperiores.\nAutem facere nisi nobis sequi.", 9 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 135, new DateTime(2021, 4, 12, 3, 17, 22, 945, DateTimeKind.Local).AddTicks(1489), new DateTime(2021, 2, 5, 11, 18, 8, 76, DateTimeKind.Local).AddTicks(1324), "kswkt", "deleniti", 9, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 134, new DateTime(2021, 4, 11, 23, 55, 36, 614, DateTimeKind.Local).AddTicks(9492), new DateTime(2021, 4, 4, 9, 6, 6, 249, DateTimeKind.Local).AddTicks(2082), "zvhcky", "Exercitationem repellendus repudiandae molestias corrupti voluptatem dolorem cumque commodi. Quidem accusantium enim minus est aut omnis itaque quam. Dolores dolore iure non est. Qui dicta modi. Et id pariatur rerum dignissimos soluta minima autem quasi ex. Est repellendus eaque enim quia optio vitae.", 9 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 132, new DateTime(2021, 4, 11, 22, 11, 4, 329, DateTimeKind.Local).AddTicks(5291), new DateTime(2020, 6, 5, 5, 50, 24, 823, DateTimeKind.Local).AddTicks(8673), "litxmbflmc", "necessitatibus", 9, true },
                    { 299, new DateTime(2021, 4, 12, 11, 3, 8, 703, DateTimeKind.Local).AddTicks(7382), new DateTime(2021, 4, 12, 20, 57, 8, 833, DateTimeKind.Local).AddTicks(3947), "llmoqiosp", "ratione", 20, true },
                    { 113, new DateTime(2021, 4, 12, 13, 42, 12, 414, DateTimeKind.Local).AddTicks(2362), new DateTime(2021, 2, 18, 23, 6, 2, 346, DateTimeKind.Local).AddTicks(4279), "nwtxq", "Commodi culpa doloribus assumenda saepe magnam soluta consectetur. Dolores consectetur magnam aspernatur voluptas alias in harum dolorem qui. Quia neque corrupti rerum corporis.", 8, true },
                    { 111, new DateTime(2020, 7, 6, 12, 22, 43, 220, DateTimeKind.Local).AddTicks(9584), new DateTime(2020, 7, 24, 19, 5, 11, 314, DateTimeKind.Local).AddTicks(6529), "gwosiqeqftcw", "Sunt quam maxime facere sapiente aut neque.\nExplicabo ratione perspiciatis ullam cupiditate molestiae aut sunt.\nOmnis qui repellat animi nisi laborum consequatur.\nIpsam ut non enim.\nLabore amet libero sed dolores impedit ipsam.\nQuas eum et qui ducimus natus.", 8, true },
                    { 91, new DateTime(2020, 5, 24, 19, 50, 17, 514, DateTimeKind.Local).AddTicks(3756), new DateTime(2020, 12, 6, 8, 44, 21, 504, DateTimeKind.Local).AddTicks(846), "uliejmvm", "enim", 7, true },
                    { 90, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(3634), new DateTime(2021, 4, 12, 17, 12, 15, 167, DateTimeKind.Local).AddTicks(3301), "nibskxamky", "In sed et neque.\nSed consectetur dolor quod quo asperiores quis.\nNihil impedit corporis illo deleniti pariatur qui voluptatibus.\nVoluptatem quis sint et.\nQuibusdam sequi eveniet maiores laborum ea.\nVero sit qui dolores.", 7, true },
                    { 89, new DateTime(2021, 1, 8, 11, 54, 47, 627, DateTimeKind.Local).AddTicks(1212), new DateTime(2021, 4, 12, 20, 29, 16, 581, DateTimeKind.Local).AddTicks(6891), "rjgqivqhyh", "vel", 7, true },
                    { 88, new DateTime(2021, 4, 12, 16, 29, 20, 738, DateTimeKind.Local).AddTicks(5381), new DateTime(2021, 4, 12, 18, 5, 24, 709, DateTimeKind.Local).AddTicks(9733), "goakaqhn", "soluta", 7, true },
                    { 87, new DateTime(2021, 3, 3, 3, 57, 2, 388, DateTimeKind.Local).AddTicks(4828), new DateTime(2020, 10, 21, 14, 7, 57, 542, DateTimeKind.Local).AddTicks(1655), "lycggz", "Culpa ex et nobis incidunt rerum quo deleniti architecto.\nExplicabo nulla ea ullam aut quo ut ipsam reprehenderit aut.\nIpsum cupiditate quia.\nSunt maiores ex.\nNihil error enim tempora.", 6, true },
                    { 86, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(6146), new DateTime(2020, 5, 26, 11, 51, 18, 185, DateTimeKind.Local).AddTicks(5328), "upxaymzihayl", "Natus et accusamus accusamus earum et enim ut.", 6, true },
                    { 85, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(6081), new DateTime(2020, 7, 24, 0, 32, 48, 319, DateTimeKind.Local).AddTicks(2950), "nrsbidzgp", "delectus", 6, true },
                    { 84, new DateTime(2021, 4, 12, 21, 22, 1, 935, DateTimeKind.Local).AddTicks(8678), new DateTime(2021, 2, 1, 19, 48, 37, 877, DateTimeKind.Local).AddTicks(2258), "oafknnbhv", "non", 6, true },
                    { 83, new DateTime(2021, 4, 11, 22, 11, 4, 322, DateTimeKind.Local).AddTicks(6012), new DateTime(2020, 7, 27, 3, 38, 38, 894, DateTimeKind.Local).AddTicks(6599), "unurnnonfolq", "Atque a totam fuga magnam sed magnam ut.\nQuis cum blanditiis harum molestiae et voluptas dolore.\nQuis corporis eos sapiente corporis omnis natus repudiandae nihil ut.", 6, true },
                    { 82, new DateTime(2021, 4, 12, 19, 43, 40, 241, DateTimeKind.Local).AddTicks(8476), new DateTime(2021, 4, 11, 22, 59, 5, 799, DateTimeKind.Local).AddTicks(8188), "wyliz", "Modi molestiae voluptas impedit est dolores. Aliquam ut tempora voluptatibus dolores non laboriosam minus. Aut suscipit ullam beatae rerum quod delectus exercitationem dicta. A voluptatum quis error vero nemo.", 6, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 81, new DateTime(2021, 4, 12, 10, 17, 26, 222, DateTimeKind.Local).AddTicks(3115), new DateTime(2021, 4, 12, 19, 31, 41, 523, DateTimeKind.Local).AddTicks(9448), "beyumd", "Quisquam qui in repellendus at quibusdam odit.\nFugiat quam porro debitis quo sed qui.\nDolores velit quibusdam nisi sit.", 6 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 80, new DateTime(2021, 4, 12, 11, 35, 16, 508, DateTimeKind.Local).AddTicks(6175), new DateTime(2020, 12, 27, 9, 47, 24, 167, DateTimeKind.Local).AddTicks(2577), "xzpaxt", "Similique qui consequatur reprehenderit vero laborum sit accusantium iure.\nVoluptatum ut dolores aut consequatur deleniti quasi praesentium sit et.\nQuam sit qui ducimus illo eos consectetur ex neque.\nFacere est minus consectetur tenetur nobis.\nEveniet aliquid vitae aut perspiciatis dolores dolorum repellat omnis consequatur.", 6, true },
                    { 79, new DateTime(2020, 7, 10, 8, 56, 31, 899, DateTimeKind.Local).AddTicks(5411), new DateTime(2021, 2, 24, 21, 3, 56, 460, DateTimeKind.Local).AddTicks(9408), "psnojrvt", "Quia ipsam delectus nam natus minus sint non.\nQuasi dolorem id odit quam iusto quia maxime provident expedita.\nNesciunt ipsum molestiae numquam ratione repudiandae earum aliquid.\nSint cum delectus quia est reprehenderit quae eius ut.\nOccaecati possimus aliquid est ex.", 6, true },
                    { 78, new DateTime(2021, 4, 12, 20, 33, 29, 938, DateTimeKind.Local).AddTicks(161), new DateTime(2021, 4, 12, 14, 22, 24, 694, DateTimeKind.Local).AddTicks(7429), "krkxksuwuwl", "Quas possimus odio provident quo occaecati animi commodi.", 6, true },
                    { 77, new DateTime(2020, 7, 25, 3, 11, 45, 438, DateTimeKind.Local).AddTicks(5852), new DateTime(2021, 4, 12, 11, 55, 17, 407, DateTimeKind.Local).AddTicks(4280), "dmdmzetnz", "harum", 6, true },
                    { 92, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(3707), new DateTime(2020, 10, 22, 4, 22, 22, 943, DateTimeKind.Local).AddTicks(9961), "sjymojxodbk", "suscipit", 7, true },
                    { 112, new DateTime(2021, 4, 11, 22, 11, 4, 327, DateTimeKind.Local).AddTicks(7284), new DateTime(2020, 5, 8, 16, 14, 53, 495, DateTimeKind.Local).AddTicks(9794), "pyztvyn", "Qui iste et ex.\nEa et explicabo aliquam architecto quae ipsam non.\nSaepe ab ipsa necessitatibus soluta harum.\nDicta aut sint officia minus sequi placeat.\nVel earum at et fugiat eligendi saepe et voluptate quisquam.", 8, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[,]
                {
                    { 93, new DateTime(2021, 4, 12, 20, 54, 18, 156, DateTimeKind.Local).AddTicks(6788), new DateTime(2020, 7, 31, 18, 6, 23, 321, DateTimeKind.Local).AddTicks(8420), "nuwxplqwz", "est", 7 },
                    { 95, new DateTime(2020, 9, 27, 18, 52, 42, 82, DateTimeKind.Local).AddTicks(6546), new DateTime(2021, 1, 3, 22, 40, 40, 815, DateTimeKind.Local).AddTicks(9107), "zcesi", "Quis inventore reiciendis cumque quidem autem necessitatibus.", 7 }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 110, new DateTime(2020, 9, 3, 21, 50, 20, 236, DateTimeKind.Local).AddTicks(4614), new DateTime(2021, 2, 22, 19, 27, 22, 163, DateTimeKind.Local).AddTicks(7358), "cxmzeaq", "non", 8, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 109, new DateTime(2021, 4, 12, 13, 20, 19, 524, DateTimeKind.Local).AddTicks(9242), new DateTime(2021, 4, 5, 17, 15, 45, 319, DateTimeKind.Local).AddTicks(7263), "wqlcitsgmx", "excepturi", 7 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 108, new DateTime(2021, 4, 12, 18, 7, 10, 17, DateTimeKind.Local).AddTicks(9793), new DateTime(2020, 6, 14, 7, 12, 40, 602, DateTimeKind.Local).AddTicks(8780), "xwxaophzuoj", "neque", 7, true },
                    { 107, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(5234), new DateTime(2021, 4, 12, 16, 34, 15, 112, DateTimeKind.Local).AddTicks(9882), "opxdubehxlv", "voluptatem", 7, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 106, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(5199), new DateTime(2021, 4, 12, 14, 12, 33, 852, DateTimeKind.Local).AddTicks(8358), "datch", "rerum", 7 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 105, new DateTime(2021, 4, 12, 21, 28, 5, 819, DateTimeKind.Local).AddTicks(6524), new DateTime(2021, 4, 12, 17, 36, 17, 554, DateTimeKind.Local).AddTicks(277), "xryehetmga", "quis", 7, true },
                    { 104, new DateTime(2021, 4, 12, 6, 21, 1, 734, DateTimeKind.Local).AddTicks(7383), new DateTime(2021, 4, 12, 15, 2, 51, 736, DateTimeKind.Local).AddTicks(6826), "sfnckzvqnxr", "commodi", 7, true },
                    { 103, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(5095), new DateTime(2021, 3, 13, 7, 2, 41, 953, DateTimeKind.Local).AddTicks(5628), "ayyjmznzx", "Reiciendis alias esse labore magni error velit tempore ad. Quae neque fugiat. Aliquam consequuntur commodi a molestias qui porro quae fuga. Laudantium et sit cum culpa debitis sed ut. Ipsam recusandae mollitia alias repellat libero dolorem. Ut nisi repudiandae ut voluptas ut expedita quod ea id.", 7, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 102, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(4854), new DateTime(2020, 6, 23, 13, 27, 11, 314, DateTimeKind.Local).AddTicks(6803), "woptgyhrqq", "Dolorem tempore odit nulla consequatur modi molestiae fugit voluptates.", 7 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 101, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(4749), new DateTime(2021, 4, 12, 4, 41, 37, 807, DateTimeKind.Local).AddTicks(7627), "dbnekqlhfofm", "Aut ex quod. Eius excepturi voluptatem. Pariatur architecto error est. Pariatur explicabo facilis fuga. Et itaque iure.", 7, true },
                    { 100, new DateTime(2021, 4, 12, 6, 33, 22, 668, DateTimeKind.Local).AddTicks(1467), new DateTime(2021, 4, 12, 8, 1, 37, 821, DateTimeKind.Local).AddTicks(1627), "ovtbiy", "Qui sapiente non maxime quisquam et.\nCorporis architecto accusantium laudantium.", 7, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 99, new DateTime(2020, 5, 3, 0, 53, 45, 746, DateTimeKind.Local).AddTicks(5810), new DateTime(2020, 9, 26, 4, 30, 8, 533, DateTimeKind.Local).AddTicks(583), "lhluacypo", "Aut error voluptate ipsam ut voluptas.", 7, true },
                    { 98, new DateTime(2021, 4, 12, 21, 22, 25, 840, DateTimeKind.Local).AddTicks(9747), new DateTime(2020, 9, 19, 21, 4, 2, 335, DateTimeKind.Local).AddTicks(3126), "pcunq", "Et dolorum sit veritatis perferendis dolorem quia magnam excepturi veniam.\nNisi laudantium dolorem eius totam laborum magnam iste.\nIure est suscipit culpa.\nError perspiciatis necessitatibus qui atque amet.\nMinus ut placeat illum nam ab nulla labore.\nUnde placeat a odit repudiandae quidem ducimus et corporis voluptates.", 7, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 97, new DateTime(2021, 4, 12, 4, 58, 34, 622, DateTimeKind.Local).AddTicks(650), new DateTime(2021, 4, 12, 3, 56, 7, 152, DateTimeKind.Local).AddTicks(9517), "mncxzik", "Aut dolorum excepturi sit rerum in ut porro.\nNesciunt reiciendis modi aut vel incidunt rerum pariatur.\nOdio nulla aut eos.", 7 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 96, new DateTime(2021, 4, 11, 22, 11, 4, 324, DateTimeKind.Local).AddTicks(4057), new DateTime(2021, 4, 12, 16, 50, 18, 716, DateTimeKind.Local).AddTicks(4555), "katcgt", "quam", 7, true },
                    { 94, new DateTime(2021, 4, 12, 13, 46, 36, 341, DateTimeKind.Local).AddTicks(178), new DateTime(2021, 4, 12, 9, 1, 49, 985, DateTimeKind.Local).AddTicks(3274), "guitcdyeoowt", "Modi id ab error voluptatibus. Nostrum impedit ratione eaque dolor et iure consequatur excepturi culpa. Odit ut quod omnis. Sit repellendus repellendus est. Quae nostrum fugit exercitationem eligendi.", 7, true },
                    { 300, new DateTime(2021, 4, 11, 22, 11, 4, 351, DateTimeKind.Local).AddTicks(5837), new DateTime(2021, 4, 12, 2, 23, 17, 625, DateTimeKind.Local).AddTicks(3722), "cgajr", "Molestiae sequi autem asperiores vitae iusto repellat omnis accusamus. Illum et consectetur molestiae commodi sint. Aliquid vel veniam. Maxime rerum asperiores soluta magni tenetur ullam. Aut illum deserunt assumenda dolores voluptatem. Numquam dolore et earum ut eos ut.", 20, true }
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
                name: "IX_Promocodes_ServiceId",
                table: "Promocodes",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPromocode_UserId",
                table: "UserPromocode",
                column: "UserId");
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
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserPromocode");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}

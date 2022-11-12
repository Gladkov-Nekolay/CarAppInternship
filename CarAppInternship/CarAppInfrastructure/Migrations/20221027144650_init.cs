using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAppInfrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EngineTypes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelsOfCars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsOfCars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<long>(type: "bigint", nullable: false),
                    ModelID = table.Column<long>(type: "bigint", nullable: false),
                    modelOfCarID = table.Column<long>(type: "bigint", nullable: true),
                    ManufacturingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Miliage = table.Column<int>(type: "int", nullable: false),
                    BodyTypeID = table.Column<long>(type: "bigint", nullable: false),
                    EngineTypeID = table.Column<long>(type: "bigint", nullable: false),
                    EngineVolume = table.Column<double>(type: "float", nullable: false),
                    DriveTypeID = table.Column<long>(type: "bigint", nullable: false),
                    TransmissionTypeID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cars_BodyTypes_BodyTypeID",
                        column: x => x.BodyTypeID,
                        principalTable: "BodyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_DriveTypes_DriveTypeID",
                        column: x => x.DriveTypeID,
                        principalTable: "DriveTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_EngineTypes_EngineTypeID",
                        column: x => x.EngineTypeID,
                        principalTable: "EngineTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_ModelsOfCars_modelOfCarID",
                        column: x => x.modelOfCarID,
                        principalTable: "ModelsOfCars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_TransmissionTypes_TransmissionTypeID",
                        column: x => x.TransmissionTypeID,
                        principalTable: "TransmissionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyTypeID",
                table: "Cars",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandID",
                table: "Cars",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriveTypeID",
                table: "Cars",
                column: "DriveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineTypeID",
                table: "Cars",
                column: "EngineTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_modelOfCarID",
                table: "Cars",
                column: "modelOfCarID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionTypeID",
                table: "Cars",
                column: "TransmissionTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "EngineTypes");

            migrationBuilder.DropTable(
                name: "ModelsOfCars");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");
        }
    }
}

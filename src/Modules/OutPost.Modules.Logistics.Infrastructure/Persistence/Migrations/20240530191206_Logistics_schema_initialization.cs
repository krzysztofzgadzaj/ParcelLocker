using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutPost.Modules.Logistics.Infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class Logistics_schema_initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediativeDeliveryPointsPoints",
                columns: table => new
                {
                    MdpId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediativeDeliveryPointsPoints", x => x.MdpId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediativeDeliveryPointsPoints");
        }
    }
}

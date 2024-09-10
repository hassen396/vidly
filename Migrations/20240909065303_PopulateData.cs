using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateData : Migration
    {
        /// <inheritdoc />
 protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert data into Genres table
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" }
                });

            // Insert data into MembershipType table
            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new[] { "Id", "Name", "SignUpFee", "DurationInMonths", "DiscountRate" },
                values: new object[,]
                {
                    { 1, "Pay As You Go", 0, 0, 0 },
                    { 2, "Monthly", 30, 1, 10 },
                    { 3, "Quarterly", 90, 3, 15 },
                    { 4, "Yearly", 300, 12, 20 }
                });

            // Insert data into Movies table
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "GenreId", "DateAdded", "ReleaseDate", "Stock" },
                values: new object[,]
                {
                    { 1, "Inception", 1, DateTime.UtcNow, new DateTime(2010, 7, 16, 0, 0, 0, DateTimeKind.Utc), (byte)5 },
                    { 2, "The Hangover", 2, DateTime.UtcNow, new DateTime(2009, 6, 5, 0, 0, 0, DateTimeKind.Utc), (byte)10 },
                    { 3, "The Dark Knight", 1, DateTime.UtcNow, new DateTime(2008, 7, 18, 0, 0, 0, DateTimeKind.Utc), (byte)7 },
                    { 4, "Titanic", 3, DateTime.UtcNow, new DateTime(1997, 12, 19, 0, 0, 0, DateTimeKind.Utc), (byte)8 },
                    { 5, "A Quiet Place", 4, DateTime.UtcNow, new DateTime(2018, 4, 6, 0, 0, 0, DateTimeKind.Utc), (byte)6 }
                });

            // Insert data into Customers table
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "DateOfBirth", "IsSubscribedToNewsletter", "MembershipTypeId" },
                values: new object[,]
                {
                    { 1, "John Smith", new DateTime(1985, 5, 23, 0, 0, 0, DateTimeKind.Utc), true, 1 },
                    { 2, "Mary Williams", new DateTime(1990, 3, 12, 0, 0, 0, DateTimeKind.Utc), false, 2 },
                    { 3, "James Brown", new DateTime(1977, 7, 30, 0, 0, 0, DateTimeKind.Utc), true, 3 },
                    { 4, "Patricia Johnson", new DateTime(2000, 1, 14, 0, 0, 0, DateTimeKind.Utc), true, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove data in reverse order if needed
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });
        }
    }
}

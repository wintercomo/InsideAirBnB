using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBnBV5.Data.Migrations
{
    public partial class AddedModelBuilderData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_calendar_listings",
                table: "calendar");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_listings",
                table: "reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims1");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims1");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins1");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles1");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens1");

            migrationBuilder.DropTable(
                name: "AspNetRoles1");

            migrationBuilder.DropTable(
                name: "AspNetUsers1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reviews",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_neighbourhoods",
                table: "neighbourhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_listings",
                table: "listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calendar",
                table: "calendar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_summary-reviews",
                table: "summary-reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_summary-listings",
                table: "summary-listings");

            migrationBuilder.RenameTable(
                name: "reviews",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "neighbourhoods",
                newName: "Neighbourhoods");

            migrationBuilder.RenameTable(
                name: "listings",
                newName: "Listings");

            migrationBuilder.RenameTable(
                name: "calendar",
                newName: "Calendar");

            migrationBuilder.RenameTable(
                name: "summary-reviews",
                newName: "SummaryReviews");

            migrationBuilder.RenameTable(
                name: "summary-listings",
                newName: "SummaryListings");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Reviews",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "comments",
                table: "Reviews",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "reviewer_name",
                table: "Reviews",
                newName: "ReviewerName");

            migrationBuilder.RenameColumn(
                name: "reviewer_id",
                table: "Reviews",
                newName: "ReviewerId");

            migrationBuilder.RenameColumn(
                name: "listing_id",
                table: "Reviews",
                newName: "ListingId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_listing_id",
                table: "Reviews",
                newName: "IX_Reviews_ListingId");

            migrationBuilder.RenameColumn(
                name: "neighbourhood",
                table: "Neighbourhoods",
                newName: "Neighbourhood");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Neighbourhoods",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zipcode",
                table: "Listings",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "transit",
                table: "Listings",
                newName: "Transit");

            migrationBuilder.RenameColumn(
                name: "summary",
                table: "Listings",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Listings",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Listings",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "space",
                table: "Listings",
                newName: "Space");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Listings",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "Listings",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "neighbourhood",
                table: "Listings",
                newName: "Neighbourhood");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Listings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "market",
                table: "Listings",
                newName: "Market");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Listings",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Listings",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "interaction",
                table: "Listings",
                newName: "Interaction");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Listings",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Listings",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Listings",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "beds",
                table: "Listings",
                newName: "Beds");

            migrationBuilder.RenameColumn(
                name: "bedrooms",
                table: "Listings",
                newName: "Bedrooms");

            migrationBuilder.RenameColumn(
                name: "bathrooms",
                table: "Listings",
                newName: "Bathrooms");

            migrationBuilder.RenameColumn(
                name: "amenities",
                table: "Listings",
                newName: "Amenities");

            migrationBuilder.RenameColumn(
                name: "accommodates",
                table: "Listings",
                newName: "Accommodates");

            migrationBuilder.RenameColumn(
                name: "access",
                table: "Listings",
                newName: "Access");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Listings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "xl_picture_url",
                table: "Listings",
                newName: "XlPictureUrl");

            migrationBuilder.RenameColumn(
                name: "weekly_price",
                table: "Listings",
                newName: "WeeklyPrice");

            migrationBuilder.RenameColumn(
                name: "thumbnail_url",
                table: "Listings",
                newName: "ThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "square_feet",
                table: "Listings",
                newName: "SquareFeet");

            migrationBuilder.RenameColumn(
                name: "smart_location",
                table: "Listings",
                newName: "SmartLocation");

            migrationBuilder.RenameColumn(
                name: "security_deposit",
                table: "Listings",
                newName: "SecurityDeposit");

            migrationBuilder.RenameColumn(
                name: "scrape_id",
                table: "Listings",
                newName: "ScrapeId");

            migrationBuilder.RenameColumn(
                name: "room_type",
                table: "Listings",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "reviews_per_month",
                table: "Listings",
                newName: "ReviewsPerMonth");

            migrationBuilder.RenameColumn(
                name: "review_scores_value",
                table: "Listings",
                newName: "ReviewScoresValue");

            migrationBuilder.RenameColumn(
                name: "review_scores_rating",
                table: "Listings",
                newName: "ReviewScoresRating");

            migrationBuilder.RenameColumn(
                name: "review_scores_location",
                table: "Listings",
                newName: "ReviewScoresLocation");

            migrationBuilder.RenameColumn(
                name: "review_scores_communication",
                table: "Listings",
                newName: "ReviewScoresCommunication");

            migrationBuilder.RenameColumn(
                name: "review_scores_cleanliness",
                table: "Listings",
                newName: "ReviewScoresCleanliness");

            migrationBuilder.RenameColumn(
                name: "review_scores_checkin",
                table: "Listings",
                newName: "ReviewScoresCheckin");

            migrationBuilder.RenameColumn(
                name: "review_scores_accuracy",
                table: "Listings",
                newName: "ReviewScoresAccuracy");

            migrationBuilder.RenameColumn(
                name: "requires_license",
                table: "Listings",
                newName: "RequiresLicense");

            migrationBuilder.RenameColumn(
                name: "require_guest_profile_picture",
                table: "Listings",
                newName: "RequireGuestProfilePicture");

            migrationBuilder.RenameColumn(
                name: "require_guest_phone_verification",
                table: "Listings",
                newName: "RequireGuestPhoneVerification");

            migrationBuilder.RenameColumn(
                name: "property_type",
                table: "Listings",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "picture_url",
                table: "Listings",
                newName: "PictureUrl");

            migrationBuilder.RenameColumn(
                name: "number_of_reviews",
                table: "Listings",
                newName: "NumberOfReviews");

            migrationBuilder.RenameColumn(
                name: "neighbourhood_group_cleansed",
                table: "Listings",
                newName: "NeighbourhoodGroupCleansed");

            migrationBuilder.RenameColumn(
                name: "neighbourhood_cleansed",
                table: "Listings",
                newName: "NeighbourhoodCleansed");

            migrationBuilder.RenameColumn(
                name: "neighborhood_overview",
                table: "Listings",
                newName: "NeighborhoodOverview");

            migrationBuilder.RenameColumn(
                name: "monthly_price",
                table: "Listings",
                newName: "MonthlyPrice");

            migrationBuilder.RenameColumn(
                name: "minimum_nights",
                table: "Listings",
                newName: "MinimumNights");

            migrationBuilder.RenameColumn(
                name: "medium_url",
                table: "Listings",
                newName: "MediumUrl");

            migrationBuilder.RenameColumn(
                name: "maximum_nights",
                table: "Listings",
                newName: "MaximumNights");

            migrationBuilder.RenameColumn(
                name: "listing_url",
                table: "Listings",
                newName: "ListingUrl");

            migrationBuilder.RenameColumn(
                name: "last_scraped",
                table: "Listings",
                newName: "LastScraped");

            migrationBuilder.RenameColumn(
                name: "last_review",
                table: "Listings",
                newName: "LastReview");

            migrationBuilder.RenameColumn(
                name: "jurisdiction_names",
                table: "Listings",
                newName: "JurisdictionNames");

            migrationBuilder.RenameColumn(
                name: "is_location_exact",
                table: "Listings",
                newName: "IsLocationExact");

            migrationBuilder.RenameColumn(
                name: "is_business_travel_ready",
                table: "Listings",
                newName: "IsBusinessTravelReady");

            migrationBuilder.RenameColumn(
                name: "instant_bookable",
                table: "Listings",
                newName: "InstantBookable");

            migrationBuilder.RenameColumn(
                name: "house_rules",
                table: "Listings",
                newName: "HouseRules");

            migrationBuilder.RenameColumn(
                name: "host_verifications",
                table: "Listings",
                newName: "HostVerifications");

            migrationBuilder.RenameColumn(
                name: "host_url",
                table: "Listings",
                newName: "HostUrl");

            migrationBuilder.RenameColumn(
                name: "host_total_listings_count",
                table: "Listings",
                newName: "HostTotalListingsCount");

            migrationBuilder.RenameColumn(
                name: "host_thumbnail_url",
                table: "Listings",
                newName: "HostThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "host_since",
                table: "Listings",
                newName: "HostSince");

            migrationBuilder.RenameColumn(
                name: "host_response_time",
                table: "Listings",
                newName: "HostResponseTime");

            migrationBuilder.RenameColumn(
                name: "host_response_rate",
                table: "Listings",
                newName: "HostResponseRate");

            migrationBuilder.RenameColumn(
                name: "host_picture_url",
                table: "Listings",
                newName: "HostPictureUrl");

            migrationBuilder.RenameColumn(
                name: "host_neighbourhood",
                table: "Listings",
                newName: "HostNeighbourhood");

            migrationBuilder.RenameColumn(
                name: "host_name",
                table: "Listings",
                newName: "HostName");

            migrationBuilder.RenameColumn(
                name: "host_location",
                table: "Listings",
                newName: "HostLocation");

            migrationBuilder.RenameColumn(
                name: "host_listings_count",
                table: "Listings",
                newName: "HostListingsCount");

            migrationBuilder.RenameColumn(
                name: "host_is_superhost",
                table: "Listings",
                newName: "HostIsSuperhost");

            migrationBuilder.RenameColumn(
                name: "host_identity_verified",
                table: "Listings",
                newName: "HostIdentityVerified");

            migrationBuilder.RenameColumn(
                name: "host_id",
                table: "Listings",
                newName: "HostId");

            migrationBuilder.RenameColumn(
                name: "host_has_profile_pic",
                table: "Listings",
                newName: "HostHasProfilePic");

            migrationBuilder.RenameColumn(
                name: "host_acceptance_rate",
                table: "Listings",
                newName: "HostAcceptanceRate");

            migrationBuilder.RenameColumn(
                name: "host_about",
                table: "Listings",
                newName: "HostAbout");

            migrationBuilder.RenameColumn(
                name: "has_availability",
                table: "Listings",
                newName: "HasAvailability");

            migrationBuilder.RenameColumn(
                name: "guests_included",
                table: "Listings",
                newName: "GuestsIncluded");

            migrationBuilder.RenameColumn(
                name: "first_review",
                table: "Listings",
                newName: "FirstReview");

            migrationBuilder.RenameColumn(
                name: "extra_people",
                table: "Listings",
                newName: "ExtraPeople");

            migrationBuilder.RenameColumn(
                name: "experiences_offered",
                table: "Listings",
                newName: "ExperiencesOffered");

            migrationBuilder.RenameColumn(
                name: "country_code",
                table: "Listings",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "cleaning_fee",
                table: "Listings",
                newName: "CleaningFee");

            migrationBuilder.RenameColumn(
                name: "cancellation_policy",
                table: "Listings",
                newName: "CancellationPolicy");

            migrationBuilder.RenameColumn(
                name: "calendar_updated",
                table: "Listings",
                newName: "CalendarUpdated");

            migrationBuilder.RenameColumn(
                name: "calendar_last_scraped",
                table: "Listings",
                newName: "CalendarLastScraped");

            migrationBuilder.RenameColumn(
                name: "calculated_host_listings_count",
                table: "Listings",
                newName: "CalculatedHostListingsCount");

            migrationBuilder.RenameColumn(
                name: "bed_type",
                table: "Listings",
                newName: "BedType");

            migrationBuilder.RenameColumn(
                name: "availability_90",
                table: "Listings",
                newName: "Availability90");

            migrationBuilder.RenameColumn(
                name: "availability_60",
                table: "Listings",
                newName: "Availability60");

            migrationBuilder.RenameColumn(
                name: "availability_365",
                table: "Listings",
                newName: "Availability365");

            migrationBuilder.RenameColumn(
                name: "availability_30",
                table: "Listings",
                newName: "Availability30");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Calendar",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Calendar",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "available",
                table: "Calendar",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Calendar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "listing_id",
                table: "Calendar",
                newName: "ListingId");

            migrationBuilder.RenameIndex(
                name: "IX_calendar_listing_id",
                table: "Calendar",
                newName: "IX_Calendar_ListingId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "SummaryReviews",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SummaryReviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "listing_id",
                table: "SummaryReviews",
                newName: "ListingId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "SummaryListings",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "neighbourhood",
                table: "SummaryListings",
                newName: "Neighbourhood");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "SummaryListings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "SummaryListings",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "SummaryListings",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SummaryListings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "room_type",
                table: "SummaryListings",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "reviews_per_month",
                table: "SummaryListings",
                newName: "ReviewsPerMonth");

            migrationBuilder.RenameColumn(
                name: "number_of_reviews",
                table: "SummaryListings",
                newName: "NumberOfReviews");

            migrationBuilder.RenameColumn(
                name: "neighbourhood_group",
                table: "SummaryListings",
                newName: "NeighbourhoodGroup");

            migrationBuilder.RenameColumn(
                name: "minimum_nights",
                table: "SummaryListings",
                newName: "MinimumNights");

            migrationBuilder.RenameColumn(
                name: "last_review",
                table: "SummaryListings",
                newName: "LastReview");

            migrationBuilder.RenameColumn(
                name: "host_name",
                table: "SummaryListings",
                newName: "HostName");

            migrationBuilder.RenameColumn(
                name: "host_id",
                table: "SummaryListings",
                newName: "HostId");

            migrationBuilder.RenameColumn(
                name: "calculated_host_listings_count",
                table: "SummaryListings",
                newName: "CalculatedHostListingsCount");

            migrationBuilder.RenameColumn(
                name: "availability_365",
                table: "SummaryListings",
                newName: "Availability365");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerName",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Neighbourhood",
                table: "Neighbourhoods",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Transit",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Space",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Interaction",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Access",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "RequiresLicense",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RequireGuestProfilePicture",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RequireGuestPhoneVerification",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NeighborhoodOverview",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ListingUrl",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IsBusinessTravelReady",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "InstantBookable",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "HouseRules",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "HostUrl",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ExperiencesOffered",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CancellationPolicy",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Calendar",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Available",
                table: "Calendar",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SummaryListings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SummaryListings",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NeighbourhoodGroup",
                table: "SummaryListings",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Neighbourhoods",
                table: "Neighbourhoods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SummaryReviews",
                table: "SummaryReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SummaryListings",
                table: "SummaryListings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_Listings_ListingId",
                table: "Calendar",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Listings_ListingId",
                table: "Reviews",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

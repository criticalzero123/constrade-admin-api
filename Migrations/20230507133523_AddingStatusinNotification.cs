using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConstradeApi_Admin.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusinNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Address_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Barangay = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Postal_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    House_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Updated_at = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Address_id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Person_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressRef_id = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Person_id);
                    table.ForeignKey(
                        name: "FK_person_address_AddressRef_id",
                        column: x => x.AddressRef_id,
                        principalTable: "address",
                        principalColumn: "Address_id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uid = table.Column<string>(type: "text", nullable: false),
                    person_ref_id = table.Column<int>(type: "integer", nullable: false),
                    user_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    auth_provider_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    user_status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_active_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    count_post = table.Column<int>(type: "integer", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_person_person_ref_id",
                        column: x => x.person_ref_id,
                        principalTable: "person",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "community",
                columns: table => new
                {
                    community_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_user_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    visibility = table.Column<string>(type: "text", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_members = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_community", x => x.community_id);
                    table.ForeignKey(
                        name: "FK_community_user_owner_user_id",
                        column: x => x.owner_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    poster_user_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    model_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    serial_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    game_genre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    platform = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    thumbnail_url = table.Column<string>(type: "text", nullable: false),
                    cash = table.Column<decimal>(type: "numeric", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    item = table.Column<string>(type: "text", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    count_favorite = table.Column<int>(type: "integer", nullable: false),
                    condition = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    prefer_trade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_meetup = table.Column<bool>(type: "boolean", nullable: false),
                    is_delivery = table.Column<bool>(type: "boolean", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    product_status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    has_receipts = table.Column<bool>(type: "boolean", nullable: false),
                    has_warranty = table.Column<bool>(type: "boolean", nullable: false),
                    is_generated = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_product_user_poster_user_id",
                        column: x => x.poster_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reported_by = table.Column<int>(type: "integer", nullable: false),
                    id_reported = table.Column<int>(type: "integer", nullable: false),
                    report_type = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    date_submitted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_report_user_reported_by",
                        column: x => x.reported_by,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    subscription_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    subscription_type = table.Column<string>(type: "text", nullable: false),
                    date_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.subscription_id);
                    table.ForeignKey(
                        name: "FK_subscription_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "system_feedback",
                columns: table => new
                {
                    system_feedback_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    report_type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: false),
                    status = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    date_submitted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_feedback", x => x.system_feedback_id);
                    table.ForeignKey(
                        name: "FK_system_feedback_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_deactivate",
                columns: table => new
                {
                    user_deactivate_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    date_started = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_deactivate", x => x.user_deactivate_id);
                    table.ForeignKey(
                        name: "FK_user_deactivate_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_notification",
                columns: table => new
                {
                    user_notification_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    to_id = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    notification_type = table.Column<string>(type: "text", nullable: false),
                    notification_message = table.Column<string>(type: "text", nullable: false),
                    notification_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_notification", x => x.user_notification_id);
                    table.ForeignKey(
                        name: "FK_user_notification_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_wallet",
                columns: table => new
                {
                    wallet_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_wallet", x => x.wallet_id);
                    table.ForeignKey(
                        name: "FK_user_wallet_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "community_post",
                columns: table => new
                {
                    community_post_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    community_id = table.Column<int>(type: "integer", nullable: false),
                    poster_user_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    like_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_community_post", x => x.community_post_id);
                    table.ForeignKey(
                        name: "FK_community_post_community_community_id",
                        column: x => x.community_id,
                        principalTable: "community",
                        principalColumn: "community_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_community_post_user_poster_user_id",
                        column: x => x.poster_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "boost_product",
                columns: table => new
                {
                    boost_product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    days_boosted = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    date_time_expired = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_boosted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boost_product", x => x.boost_product_id);
                    table.ForeignKey(
                        name: "FK_boost_product_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    buyer_user_id = table.Column<int>(type: "integer", nullable: false),
                    seller_user_id = table.Column<int>(type: "integer", nullable: false),
                    in_app_transaction = table.Column<bool>(type: "boolean", nullable: false),
                    get_wanted = table.Column<bool>(type: "boolean", nullable: false),
                    is_reviewed = table.Column<bool>(type: "boolean", nullable: false),
                    date_transaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_transactions_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_user_buyer_user_id",
                        column: x => x.buyer_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_user_seller_user_id",
                        column: x => x.seller_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription_history",
                columns: table => new
                {
                    subscription_history_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subscription_id = table.Column<int>(type: "integer", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    previous_subscription_type = table.Column<string>(type: "text", nullable: false),
                    new_subscription_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    previous_date_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    new_date_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    previous_date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    new_date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    previous_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    new_amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_history", x => x.subscription_history_id);
                    table.ForeignKey(
                        name: "FK_subscription_history_subscription_subscription_id",
                        column: x => x.subscription_id,
                        principalTable: "subscription",
                        principalColumn: "subscription_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "send_money_transaction",
                columns: table => new
                {
                    send_money_transaction = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_wallet_id = table.Column<int>(type: "integer", nullable: false),
                    receiver_wallet_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    date_send = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_send_money_transaction", x => x.send_money_transaction);
                    table.ForeignKey(
                        name: "FK_send_money_transaction_user_wallet_receiver_wallet_id",
                        column: x => x.receiver_wallet_id,
                        principalTable: "user_wallet",
                        principalColumn: "wallet_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_send_money_transaction_user_wallet_sender_wallet_id",
                        column: x => x.sender_wallet_id,
                        principalTable: "user_wallet",
                        principalColumn: "wallet_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "community_post_comment",
                columns: table => new
                {
                    community_post_comment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    community_post_id = table.Column<int>(type: "integer", nullable: false),
                    commented_by_user = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    date_commented = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_community_post_comment", x => x.community_post_comment_id);
                    table.ForeignKey(
                        name: "FK_community_post_comment_community_post_community_post_id",
                        column: x => x.community_post_id,
                        principalTable: "community_post",
                        principalColumn: "community_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_community_post_comment_user_commented_by_user",
                        column: x => x.commented_by_user,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transaction_ref_id = table.Column<int>(type: "integer", nullable: false),
                    rate = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_reviews_transactions_transaction_ref_id",
                        column: x => x.transaction_ref_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_boost_product_product_id",
                table: "boost_product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_community_owner_user_id",
                table: "community",
                column: "owner_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_community_post_community_id",
                table: "community_post",
                column: "community_id");

            migrationBuilder.CreateIndex(
                name: "IX_community_post_poster_user_id",
                table: "community_post",
                column: "poster_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_community_post_comment_commented_by_user",
                table: "community_post_comment",
                column: "commented_by_user");

            migrationBuilder.CreateIndex(
                name: "IX_community_post_comment_community_post_id",
                table: "community_post_comment",
                column: "community_post_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_AddressRef_id",
                table: "person",
                column: "AddressRef_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_FirstName_LastName",
                table: "person",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_product_poster_user_id",
                table: "product",
                column: "poster_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_report_reported_by",
                table: "report",
                column: "reported_by");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_transaction_ref_id",
                table: "reviews",
                column: "transaction_ref_id");

            migrationBuilder.CreateIndex(
                name: "IX_send_money_transaction_receiver_wallet_id",
                table: "send_money_transaction",
                column: "receiver_wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_send_money_transaction_sender_wallet_id",
                table: "send_money_transaction",
                column: "sender_wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_user_id",
                table: "subscription",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_history_subscription_id",
                table: "subscription_history",
                column: "subscription_id");

            migrationBuilder.CreateIndex(
                name: "IX_system_feedback_user_id",
                table: "system_feedback",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_buyer_user_id",
                table: "transactions",
                column: "buyer_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_product_id",
                table: "transactions",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_seller_user_id",
                table: "transactions",
                column: "seller_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_email_uid",
                table: "user",
                columns: new[] { "email", "uid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_person_ref_id",
                table: "user",
                column: "person_ref_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_deactivate_user_id",
                table: "user_deactivate",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_notification_user_id",
                table: "user_notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_wallet_user_id",
                table: "user_wallet",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boost_product");

            migrationBuilder.DropTable(
                name: "community_post_comment");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "send_money_transaction");

            migrationBuilder.DropTable(
                name: "subscription_history");

            migrationBuilder.DropTable(
                name: "system_feedback");

            migrationBuilder.DropTable(
                name: "user_deactivate");

            migrationBuilder.DropTable(
                name: "user_notification");

            migrationBuilder.DropTable(
                name: "community_post");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "user_wallet");

            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "community");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}

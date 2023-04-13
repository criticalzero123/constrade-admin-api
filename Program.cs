using ConstradeApi_Admin.Data;
using ConstradeApi_Admin.Model.MBoostProduct.Repository;
using ConstradeApi_Admin.Model.MCommunity.Repository;
using ConstradeApi_Admin.Model.MCommunityPost.Repository;
using ConstradeApi_Admin.Model.MCommunityPostComment.Repository;
using ConstradeApi_Admin.Model.MNotification.Repository;
using ConstradeApi_Admin.Model.MProduct.Repository;
using ConstradeApi_Admin.Model.MReport.Repository;
using ConstradeApi_Admin.Model.MSubscriptionHistory.Repository;
using ConstradeApi_Admin.Model.MSystemFeedback.Repository;
using ConstradeApi_Admin.Model.MUser.Repository;
using ConstradeApi_Admin.Model.MWallet.Repository;
using ConstradeApi_Admin.VerificationEntity;
using ConstradeApi_Admin.VerificationModel.MAuth.Repository;
using ConstradeApi_Admin.VerificationModel.MValidIdRequest.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConstradeApi_Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         
             builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Secrets.json", optional: true);
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddDbContext<AdminDataContext>(option => option.UseNpgsql(builder.Configuration["ConnectionString:PostgresDBDev"]));
            builder.Services.AddDbContext<AdminVerificationDataContext>(option => option.UseNpgsql(builder.Configuration["ConnectionString:PostgresDBVerificationDev"]));

            //builder.Services.AddDbContext<AdminDataContext>(option => option.UseNpgsql(builder.Configuration["ConnectionString:PostgresDBProd"]));
            //builder.Services.AddDbContext<AdminVerificationDataContext>(option => option.UseNpgsql(builder.Configuration["ConnectionString:PostgresDBVerificationProd"]));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<ICommunityPostCommentRepository, CommunityPostCommentRepository>();
            builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
            builder.Services.AddScoped<ICommunityPostRepository, CommunityPostRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ISystemFeedbackRepository, SystemFeedbackRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<ISubscriptionHistoryRepository, SubscriptionHistoryRepository>();
            builder.Services.AddScoped<IBoostProductRepository, BoostProductRepository>();

            builder.Services.AddScoped<IValidIdRequestRepository, ValidIdRequestRepository>();
            builder.Services.AddTransient<IAuthRepository, AuthRepository>();




            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
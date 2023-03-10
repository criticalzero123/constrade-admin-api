using ConstradeApi_Admin.Data;
using ConstradeApi_Admin.Model.MCommunity.Repository;
using ConstradeApi_Admin.Model.MCommunityPost.Repository;
using ConstradeApi_Admin.Model.MCommunityPostComment.Repository;
using ConstradeApi_Admin.Model.MProduct.Repository;
using ConstradeApi_Admin.Model.MReport.Repository;
using ConstradeApi_Admin.Model.MSystemFeedback.Repository;
using ConstradeApi_Admin.Model.MUser.Repository;
using ConstradeApi_Admin.Model.MWallet.Repository;
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
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<ICommunityPostCommentRepository, CommunityPostCommentRepository>();
            builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
            builder.Services.AddScoped<ICommunityPostRepository, CommunityPostRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ISystemFeedbackRepository, SystemFeedbackRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();


            builder.Services.AddDbContext<AdminDataContext>(option => option.UseNpgsql(builder.Configuration["ConnectionString:PostgressDB"]));

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
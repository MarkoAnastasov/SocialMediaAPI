using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShareITAPI.Interfaces;
using ShareITAPI.Interfaces.FriendRequest;
using ShareITAPI.Interfaces.FriendsInterface;
using ShareITAPI.Models;
using ShareITAPI.Repositories;
using ShareITAPI.Services;
using System;

namespace ShareITAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            });

            services.AddDbContext<DB_A57889_shareITContext>(options => options.UseSqlServer("Name=ShareITAPI"));

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPostsRepository, PostsRepository>();
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddScoped<ILikesService, LikesService>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<IFriendRequestsRepository, FriendRequestsRepository>();
            services.AddScoped<IFriendRequestsService, FriendRequestsService>();
            services.AddScoped<IFriendsRepository, FriendsRepository>();
            services.AddScoped<IFriendsService, FriendsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Chat.Business;
using Chat.Business.Interfaces;
using Chat.Data.Repositories;
using Chat.Data.Repositories.Interfaces;
using Chat.Hubs;
using Chat.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<ChatDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageHandler, MessageHandler>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoomHandler, RoomHandler>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000", "https://reenbit-chat-front.azurewebsites.net").AllowAnyMethod()
                   .AllowAnyHeader().AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("hubs/message").RequireCors(options => options.WithOrigins("http://localhost:3000", "https://reenbit-chat-front.azurewebsites.net").AllowAnyMethod()
                   .AllowAnyHeader().AllowCredentials());
            });
        }
    }
}

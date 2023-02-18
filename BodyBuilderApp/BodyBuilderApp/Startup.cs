using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.BodyStatusModule;
using BodyBuilderApp.Modules.BodyStatusModule.Interface;
using BodyBuilderApp.Modules.CustomerModule;
using BodyBuilderApp.Modules.CustomerModule.Interface;
using BodyBuilderApp.Modules.DailyFoodDetailModule;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Interface;
using BodyBuilderApp.Modules.ExerciseModule.Interface;
using BodyBuilderApp.Modules.ExerciseModule;
using BodyBuilderAppApp.Modules.BodyStatusModule;
using BodyBuilderAppApp.Modules.CustomerModule;
using BodyBuilderAppApp.Modules.DailyFoodDetailModule;
using BodyBuilderAppApp.Modules.ExerciseModule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.FoodDetailModule.Interface;
using BodyBuilderApp.Modules.FoodDetailModule;
using BodyBuilderAppApp.Modules.FoodDetailModule;
using BodyBuilderApp.Modules.ScheduleModule.Interface;
using BodyBuilderApp.Modules.ScheduleModule;
using BodyBuilderAppApp.Modules.ScheduleModule;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Interface;
using BodyBuilderApp.Modules.ScheduleExerciseModule;
using BodyBuilderAppApp.Modules.ScheduleExerciseModule;
using BodyBuilderApp.Modules.TargetModule.Interface;
using BodyBuilderApp.Modules.TargetModule;
using BodyBuilderAppApp.Modules.TargetModule;
using BodyBuilderApp.Modules.TrainerModule.Interface;
using BodyBuilderApp.Modules.TrainerModule;
using BodyBuilderAppApp.Modules.TrainerModule;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BodyBuilderApp
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

            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BodyBuilderApp", Version = "v1" });
            });
            services.AddDbContext<BodyBuilderAppContext>(
               opt => opt.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")
               )
           );
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            //BodyStatus Module
            services.AddScoped<IBodyStatusRepository, BodyStatusRepository>();
            services.AddScoped<IBodyStatusService, BodyStatusService>();
            //Customer Module
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            //DailyFoodDetail Module
            services.AddScoped<IDailyFoodDetailRepository, DailyFoodDetailRepository>();
            services.AddScoped<IDailyFoodDetailService, DailyFoodDetailService>();
            //Exercise Module
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IExerciseService, ExerciseService>();
            //FoodDetail Module
            services.AddScoped<IFoodDetailRepository, FoodDetailRepository>();
            services.AddScoped<IFoodDetailService, FoodDetailService>();
            //Schedule Module
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IScheduleService, ScheduleService>();
            //ScheduleExercise Module
            services.AddScoped<IScheduleExerciseRepository, ScheduleExerciseRepository>();
            services.AddScoped<IScheduleExerciseService, ScheduleExerciseService>();
            //Target Module
            services.AddScoped<ITargetRepository, TargetRepository>();
            services.AddScoped<ITargetService, TargetService>();
            //Trainer Module
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<ITrainerService, TrainerService>();
            //Trainer Module
            services.AddScoped<ITokenHandler,BodyBuilderApp.Modules.CustomerModule.TokenHandler>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BodyBuilderApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using ClassLibraryEF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RbacApplication;
using RbacApplication.Admins;
using RbacApplication.Role;
using RbacRepository;
using RbacRepository.AdminRole;
using RbacRepository.MenuRoles;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
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
            services.AddAutoMapper(Assembly.Load("RbacApplication"));
            //上下文
            services.AddDbContext<MyDbContext>(s => s.UseSqlServer(Configuration.GetConnectionString("sqlserver")));
            //注册
            services.AddScoped<Irepository,Repository>();
            services.AddScoped<Iapplication, Application>();
            services.AddScoped<IRoleDto, RbacRepository.Role.RoleDto>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdminRepository,AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IMenuRoleRepository, MenuRoleRepository>();
            services.AddScoped<IAdminRoleRepository, AdminRoleRepository>();

            services.AddCors(s => {
                s.AddPolicy("cors", a =>
                {
                    a.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
           option =>
           {
                //Token验证参数
                option.TokenValidationParameters = new TokenValidationParameters
               {
                    //是否验证发行人
                    ValidateIssuer = true,
                   ValidIssuer = Configuration["JwtConfig:Issuer"],//发行人

                    //是否验证受众人
                    ValidateAudience = true,
                   ValidAudience = Configuration["JwtConfig:Audience"],//受众人

                    //是否验证密钥
                    ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:key"])),

                   ValidateLifetime = true, //验证生命周期

                    RequireExpirationTime = true, //过期时间

                    ClockSkew = TimeSpan.Zero   //平滑过期偏移时间
                };
           }
);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });

                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //在header中添加token，传递到后台
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }
            app.UseCors("cors");

            app.UseHttpsRedirection();

            app.UseRouting();
            //认证中间件
            app.UseAuthentication();

            //授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

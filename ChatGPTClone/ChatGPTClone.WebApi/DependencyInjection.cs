using System.Globalization;
using System.Text;
using ChatGPTClone.Application.Common.Interfaces;
using ChatGPTClone.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ChatGPTClone.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            // Bellek önbelleğini ekler
            services.AddMemoryCache(); 

            // CORS politikasını yapılandırır
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });

            // HTTP bağlamı erişimcisini ekler
            services.AddHttpContextAccessor();

            // Mevcut kullanıcı hizmetini ekler
            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            // Çevre yöneticisini ekler
            services.AddSingleton<IEnvironmentService, EnvironmentManager>(sp => new EnvironmentManager(environment.WebRootPath));

            // Yerelleştirme ayarları
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Varsayılan kültürü ayarla
                var defaultCulture = new CultureInfo("tr-TR");

                // Desteklenen kültürleri ayarla
                var supportedCultures = new List<CultureInfo>
                {
                    defaultCulture,
                    new CultureInfo("en-GB")
                };

                // Desteklenen kültürleri ekle
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.ApplyCurrentCultureToResponseHeaders = true;
            });

            // Kimlik doğrulama ayarları
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var secretKey = configuration["JwtSettings:SecretKey"];

                if (string.IsNullOrEmpty(secretKey))
                    throw new ArgumentNullException("JwtSettings:SecretKey is not set.");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Swagger yapılandırması
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "ChatGPTClone Web API",
                        Version = "1",
                        Description = "Through this API you can access ChatGPTClone App's details",
                        Contact = new OpenApiContact()
                        {
                            Email = "berkcan.gumusisik@yazilim.academy",
                            Name = "Alper Tunga",
                            Url = new Uri("https://yazilim.academy/")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "© 2024 Yazılım Academy Tüm Hakları Saklıdır",
                            Url = new Uri("https://yazilim.academy/")
                        }
                    });

                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                // JWT kimlik doğrulama için güvenlik tanımı
                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

            return services;
        }
    }
}
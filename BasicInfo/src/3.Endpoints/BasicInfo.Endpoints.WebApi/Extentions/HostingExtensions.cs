using Ground.Endpoints.WebApi.Extentions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ground.Extensions.DependencyInjection;
using Ground.Endpoints.WebApi.Extentions.ModelBinding;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Ground.Infra.Data.Sql.Commands.Interceptors;
using BasicInfo.Infra.Data.Sql.Queries.Common;
using Ground.Extensions.Events.PollingPublisher.Dal.Dapper.Extensions.DependencyInjection;
using Ground.Extensions.MessageBus.MessageInbox.Dal.Dapper.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Ground.Extensions.Events.Outbox.Dal.EF.Interceptors;
using Steeltoe.Discovery.Client;
using BasicInfo.Endpoints.WebApi.BackgroundTasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace BasicInfo.Endpoints.WebApi.Extentions
{
    /// <summary>
    /// this class is used for injecting dependencies
    /// </summary>
    public static class HostingExtensions
    {
        /// <summary>
        /// Dependencies
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;

            //OpenTelemetry
            const string serviceName = "NewsCMS.BasicInfo";
            const string serviceVersion = "1.0.0";

            builder.Services.AddOpenTelemetry()
                  .ConfigureResource(resource =>
                  resource.AddService(serviceName, serviceVersion))
                  .WithTracing(tracing => tracing
                      .AddAspNetCoreInstrumentation()
                      .AddSqlClientInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddConsoleExporter().AddJaegerExporter());

            //Eureka Discovery
            builder.Services.AddDiscoveryClient();

            //Ground
            builder.Services.AddGroundApiCore("Ground");//= AddControllers(); FluentValidation();

            //microsoft
            builder.Services.AddEndpointsApiExplorer();

            //Ground
            builder.Services.AddGroundWebUserInfoService(builder.Configuration, true);//fake version
            //builder.Services.AddGroundWebUserInfoService(configuration, "WebUserInfo", true);

            //Ground            
            //builder.Services.AddGroundTraniTranslator(configuration, "TraniTranslator");
            string conn = builder.Configuration.GetConnectionString("CommandDb_ConnectionString");
            builder.Services.AddGroundTraniTranslator(c =>

            {
                c.ConnectionString = conn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "TraniTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });

            //Identity Server
            builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", c =>
            {
                c.Authority = "https://localhost:4001";
                c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = false,
                };
            });
            builder.Services.AddAuthorization(c =>
                c.AddPolicy("BasicInfoPolicy", p =>
                {
                    p.RequireAuthenticatedUser();
                    p.RequireClaim("scope", "basicinfo");
                })
            );

            //Ground
            builder.Services.AddNonValidatingValidator();

            //Ground
            builder.Services.AddGroundNewtonSoftSerializer();
            //builder.Services.AddGroundMicrosoftSerializer();

            //Ground
            builder.Services.AddGroundAutoMapperProfiles(configuration, "AutoMapper");
            /*builder.Services.AddGroundAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "Ground.Samples";
            });*/

            //Ground
            builder.Services.AddGroundInMemoryCaching();

            //CommandDbContext            
            //if you don't need to use OutBox, remove new AddOutBoxEventItemInterceptor() and BasicInfoCommandDbContext must inherit from BaseCommandDbContext
            builder.Services.AddDbContext<BasicInfoCommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));//new AddOutBoxEventItemInterceptor For adding OutboxEventItem without inheriting BasicInfoCommandDbContext from BaseOutBoxCommandDbContext

            //QueryDbContext
            builder.Services.AddDbContext<BasicInfoQueryDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("QueryDb_ConnectionString")));

            //PollingPublisher
            builder.Services.AddGroundPollingPublisherDalSql(configuration, "PollingPublisherSqlStore");

            //MessageInbox
            builder.Services.AddGroundMessageInboxDalSql(configuration, "MessageInboxSqlStore");

            //PollingPublisher
            builder.Services.AddHostedService<EventPublisher>();

            //Health Check
            builder.Services.AddHealthChecks().AddDbContextCheck<BasicInfoCommandDbContext>();

            builder.Services.AddSwaggerGen();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseGroundApiExceptionHandler();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePages();

            app.UseCors(delegate (CorsPolicyBuilder builder)
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            //app.UseHttpsRedirection();


            //health check            
            app.MapHealthChecks("health/live", new HealthCheckOptions
            {
                Predicate = _ => false
            }); ;
            app.MapHealthChecks("health/ready");


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers().RequireAuthorization("BasicInfoPolicy");


            return app;
        }
    }
}

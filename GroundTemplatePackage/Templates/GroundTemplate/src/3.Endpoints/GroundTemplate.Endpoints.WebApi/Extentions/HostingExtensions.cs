using Ground.Endpoints.WebApi.Extentions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ground.Extensions.DependencyInjection;
using Ground.Endpoints.WebApi.Extentions.ModelBinding;
using GroundTemplate.Infra.Data.Sql.Commands.Common;
using Ground.Infra.Data.Sql.Commands.Interceptors;
using GroundTemplate.Infra.Data.Sql.Queries.Common;
using Ground.Extensions.Events.PollingPublisher.Dal.Dapper.Extensions.DependencyInjection;
using Ground.Extensions.MessageBus.MessageInbox.Dal.Dapper.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Ground.Extensions.Events.Outbox.Dal.EF.Interceptors;

namespace GroundTemplate.Endpoints.WebApi.Extentions
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

            //Ground
            builder.Services.AddGroundApiCore("Ground");//= AddControllers(); FluentValidation();

            //microsoft
            builder.Services.AddEndpointsApiExplorer();

            //Ground
            builder.Services.AddGroundWebUserInfoService(builder.Configuration, true);//fake version
            //builder.Services.AddGroundWebUserInfoService(configuration, "WebUserInfo", true);

            //Ground
            builder.Services.AddGroundTraniTranslator(configuration, "TraniTranslator");
            /*string conn = "Server=.; Initial Catalog=GroundSample; User Id=sa; Password=P@ssw0rd;encrypt=false";
            builder.Services.AddGroundTraniTranslator(c =>

            {
                c.ConnectionString = conn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "TraniTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });*/

            //Ground
            builder.Services.AddNonValidatingValidator();

            //Ground
            builder.Services.AddGroundNewtonSoftSerializer();
            //builder.Services.AddZaminMicrosoftSerializer();

            //Ground
            builder.Services.AddGroundAutoMapperProfiles(configuration, "AutoMapper");
            /*builder.Services.AddGroundAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "Ground.Samples";
            });*/
            
            //Ground
            builder.Services.AddGroundInMemoryCaching();

            //CommandDbContext            
            //if you don't need to use OutBox, remove new AddOutBoxEventItemInterceptor() and DbContextNameCommandDbContext must inherit from BaseCommandDbContext
            builder.Services.AddDbContext<DbContextNameCommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddOutBoxEventItemInterceptor(), new AddAuditDataInterceptor()));

            //QueryDbContext
            builder.Services.AddDbContext<DbContextNameQueryDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("QueryDb_ConnectionString")));

            //PollingPublisher
            builder.Services.AddGroundPollingPublisherDalSql(configuration, "PollingPublisherSqlStore");

            //MessageInbox
            builder.Services.AddGroundMessageInboxDalSql(configuration, "MessageInboxSqlStore");

            builder.Services.AddSwaggerGen();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseGroundApiExceptionHandler();

            //app.UseSerilogRequestLogging();

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

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();


            return app;
        }
    }
}

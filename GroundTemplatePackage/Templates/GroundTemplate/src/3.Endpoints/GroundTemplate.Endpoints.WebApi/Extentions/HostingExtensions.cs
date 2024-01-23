using Ground.Endpoints.WebApi.Extentions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ground.Extensions.DependencyInjection;
using Ground.Endpoints.WebApi.Extentions.ModelBinding;
using GroundTemplate.Infra.Data.Sql.Commands.Common;

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

            //Ground
            builder.Services.AddGroundAutoMapperProfiles(configuration, "AutoMapper");
            /*builder.Services.AddGroundAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "Ground.Samples";
            });*/
            
            //Ground
            builder.Services.AddGroundInMemoryCaching();

            //CommandDbContext
            builder.Services.AddDbContext<DbContextNameCommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));
            builder.Services.AddDbContext<SampleQueryDbContext>(c => c.UseSqlServer(conn));

            

            
            builder.Services.AddSwaggerGen();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseGroundApiExceptionHandler();//missing

            //app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            return app;
        }
    }
}

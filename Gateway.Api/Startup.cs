using Gateway.Api.Data.Entities;
using Gateway.Api.Data.MongoDB;
using Gateway.Api.Data.Repositories;
using Gateway.Api.Data.Repositories.JournalsRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
#if DEBUG
            services.AddCors();
#endif
            services.AddControllers(setupAction => {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            // Setup MongoDB Service
            services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDB"));

            // Dependency Injection
            // TODO: Use either ninject or light inject
            services.AddScoped<IRepository<JournalEntity>, JournalsRepository>();
            services.AddScoped<IRepository<JournalEntryEntity>, JournalEntriesRepository>();
            services.AddTransient(typeof(IMongoDBService<>), typeof(MongoDBService<>));

            // Setup AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                // setup exception handling
                app.UseExceptionHandler(builder => {
                    // TODO: Turn this into exception handling middle ware
                    builder.Run(async context => {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault occurred. Try again later.");
                        // TODO: add logging 
                    });
                });
            }

#if DEBUG 
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
#endif

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

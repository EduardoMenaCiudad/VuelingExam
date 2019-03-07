using System.Collections.Generic;
using DFSLibrary.AdjacencyLists.Factories;
using DFSLibrary.Algorithms.Factories;
using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Controllers;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.ExchangeAlgorithm.AdjacencyLists.Factories;
using GNB_EduardoMenaCiudad.FileReaders;
using GNB_EduardoMenaCiudad.Middleware;
using GNB_EduardoMenaCiudad.Repositories;
using GNB_EduardoMenaCiudad.RequestClient;
using GNB_EduardoMenaCiudad.Serializers;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GNB_EduardoMenaCiudad
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(Configuration);
            services.AddScoped<IConfigurationGetter, ConfigConfigurationGetter>();
            services.AddScoped<ISerializer<IEnumerable<ExchangeRate>, string>, RateToJsonSerializer>();
            services.AddScoped<ISerializer<IEnumerable<Transaction>, string>, TransactionToJsonSerializer>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddHttpClient();
            services.AddScoped<IRequestClient, HttpFactoryRequestClient>();

            // Rates service
            services.AddScoped<IReadRepository<ExchangeRate>, ExchangeRateRemoteRepository>();
            services.AddScoped<IRepository<ExchangeRate>, ExchangeRateFileRepository>();
            services.AddScoped<IReadService<ExchangeRate>, RatesService>();
            services.AddScoped<IBaseService<ExchangeRate>, RatesCacheService>();
            
            // Transactions service
            services.AddScoped<IReadRepository<Transaction>, TransactionRemoteRepository>();
            services.AddScoped<IRepository<Transaction>, TransactionFileRepository>();
            services.AddScoped<IReadService<Transaction>, TransactionService>();
            services.AddScoped<IBaseService<Transaction>, TransactionCacheService>();

            services.AddScoped<IReadController<Transaction>, TransactionCacheController>();
            services.AddScoped<IReadController<ExchangeRate>, RatesCacheController>();
            //services.AddScoped<IReadController<ExchangeRate>, RatesController>();
            //services.AddScoped<IReadController<Transaction>, TransactionsController>();

            // registrar factoria de adjacencyList
            services.AddScoped<IAdjacencyListFactory<ExchangeRate>, ExchangeRateAdjacencyListFactory>();
            //registrar  factoria de algoritmo
            services.AddScoped<IFactoryDFS<ExchangeRate>, FactoryExchangeRateDFS>();

            services.AddScoped<IConversionController, ConversionController>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                // In production uncomment this and comment/delete the one executing now
                //app.ConfigureExceptionCustomMiddleware();
            }
            // Custom exception middleware extension method
            app.ConfigureExceptionCustomMiddleware();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

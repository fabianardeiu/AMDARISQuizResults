using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmdarisQuizResults.Services;
using AmdarisQuizResultsApi.Models;
using AmdarisQuizResultsApi.Repositories;
using AmdarisQuizResultsApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AmdarisQuizResults
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            services.AddDbContext<AmdarisQuizContext>();
            services.AddScoped<IQuizResultService, QuizResultService>();
            services.AddScoped<IRepository<Answer>, BaseRepository<Answer>>();
            services.AddScoped<IRepository<Question>, BaseRepository<Question>>();
            services.AddScoped<IRepository<Quiz>, BaseRepository<Quiz>>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
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
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

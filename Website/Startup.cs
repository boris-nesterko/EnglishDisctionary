﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using EnglishDictionary.Domain;

namespace EnglishDictionary.Website
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				 .SetBasePath(env.ContentRootPath)
				 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				 .AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();
			services.AddSingleton<IConfiguration>(Configuration);
			services.AddSingleton<IWordsDB>(InitializeWordsDB);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					 name: "default",
					 template: "{controller=Words}/{action=Get}/");
			});
			app.UseDefaultFiles();
			app.UseStaticFiles();
		}

		private IWordsDB InitializeWordsDB(IServiceProvider arg)
		{
			var url = Configuration.GetValue<string>("OnlineDictionary");
			HttpClient client = new HttpClient();
			var data = client.GetStringAsync(url).Result;
			var words = data.Split(Environment.NewLine.ToCharArray());

			return new WordsDB(words);
		}
	}
}

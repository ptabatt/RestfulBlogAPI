namespace RestfulBlogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var builder = WebApplication.CreateBuilder(args);

    //        // Add services to the container.

    //        builder.Services.AddControllers();
    //        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //        builder.Services.AddEndpointsApiExplorer();
    //        builder.Services.AddSwaggerGen();

    //        var app = builder.Build();

    //        // Configure the HTTP request pipeline.
    //        if (app.Environment.IsDevelopment())
    //        {
    //            app.UseSwagger();
    //            app.UseSwaggerUI();

    //            app.UseDeveloperExceptionPage();
    //        }
    //        else
    //        {
    //            app.UseCors(builder =>
    //            {
    //                builder.WithOrigins("https://your-production-frontend-app.com")
    //                       .AllowAnyMethod()
    //                       .AllowAnyHeader();
    //            });

    //            app.UseExceptionHandler("/Home/Error");
    //            app.UseHsts();
    //        }

    //        app.UseHttpsRedirection();

    //        app.UseAuthentication();

    //        app.UseAuthorization();

    //        app.MapControllers();

    //        app.Run();
    //    }
    //}
}
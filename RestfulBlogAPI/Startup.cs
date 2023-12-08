//using Microsoft.EntityFrameworkCore;

//public class Startup
//{
//    public IConfiguration Configuration { get; }

//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        // Configure DbContext
//        services.AddDbContext<ApplicationDbContext>(options =>
//            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

//        // Add services
//        //services.AddScoped<IAuthService, AuthService>();
//        //services.AddScoped<IPostService, PostService>(); 

//        services.AddControllers();
//    }

//    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//    {
//        if (env.IsDevelopment())
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
        
//        app.UseStaticFiles();

//        app.UseAuthentication();

//        app.UseRouting();

//        app.UseAuthorization();

//        app.UseEndpoints(endpoints =>
//        {
//            endpoints.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");
//        });
//    }
//}

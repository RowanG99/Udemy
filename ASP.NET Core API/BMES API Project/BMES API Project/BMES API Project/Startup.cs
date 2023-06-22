using BMES_API_Project.Database;
using BMES_API_Project.Models.Shared;
using BMES_API_Project.Repository;
using BMES_API_Project.Repository.Implementations;
using BMES_API_Project.Services;
using BMES_API_Project.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BMES_API_Project
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Building Materials E-Store", Version = "v1" });
            });

            services.AddDbContext<dbContext>(optionsAction: options => options.UseSqlite(Configuration["Data:BMESAPIProject:ConnectionString"]));
            services.AddDbContext<IdentitydbContext>(options =>
                options.UseSqlite(
                    Configuration["Data:BmesIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentitydbContext>();

            services.AddTransient<iAddressRepo, AddressRepo>();
            services.AddTransient<iBrandRepo, BrandRepo>();
            
            services.AddTransient<iCartItemRepo, CartItemRepo>();
            services.AddTransient<iCartRepo, CartRepo>();
            services.AddTransient<iCategoryRepo, CategoryRepo>();
            services.AddTransient<iCustomerRepo, CustomerRepo>();
            services.AddTransient<iOrderItemRepo, OrderItemRepo>();
            services.AddTransient<iOrderRepo, OrderRepo>();
            services.AddTransient<iPersonRepo, PersonRepo>();
            services.AddTransient<iProductRepo, ProductRepo>();
            services.AddTransient<iPersonRepo, PersonRepo>();
            services.AddTransient<iAuthRepo, AuthRepo>();

            services.AddTransient<iBrandService, BrandService>();
            services.AddTransient<iCartSevice, CartService>();
            services.AddTransient<iCatalogueService, CatalogueService>();
            services.AddTransient<iCategoryService, CatergoryService>();
            services.AddTransient<iCheckoutService, CheckoutService>();
            services.AddTransient<iOrderService, OrderService>();
            services.AddTransient<iProductService, ProductService>();
            services.AddTransient<iAuthService, AuthService>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Building Materials E-Store V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

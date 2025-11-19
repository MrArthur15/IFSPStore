
using AutoMapper;
using IFSPStore.app.Others;
using IFSPStore.app.Register;
using IFSPStore.app.ViewModel;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using IFSPStore.Repository.Repository;
using IFSPStore.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net.NetworkInformation;

namespace IFSPStore.app.Infra
{
    public static class ConfigureDI
    {
        public static ServiceCollection services;
        public static IServiceProvider? serviceProvider;
        public static void ConfigureServices()
        {
            // data base config
            var dbConfigFile = "Config/DBCOnfig.txt";
            var strCon=File.ReadAllText(dbConfigFile);
            services = new ServiceCollection();
            services.AddDbContext<IFSPStoreContext>(
                options =>
                {
                    options.LogTo(Console.WriteLine);
                    options.UseMySQL(strCon);
                }
            );
            #region Repositories
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseRepository<City>, BaseRepository<City>>();
            services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
            services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBaseRepository<Sale>, BaseRepository<Sale>>();
            services.AddScoped<IBaseRepository<SaleItem>, BaseRepository<SaleItem>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            #endregion

            #region Services
            services.AddScoped<IBaseService<Category>, BaseService<Category>>();
            services.AddScoped<IBaseService<City>, BaseService<City>>();
            services.AddScoped<IBaseService<Customer>, BaseService<Customer>>();
            services.AddScoped<IBaseService<Product>, BaseService<Product>>();
            services.AddScoped<IBaseService<Sale>, BaseService<Sale>>();
            services.AddScoped<IBaseService<SaleItem>, BaseService<SaleItem>>();
            services.AddScoped<IBaseService<User>, BaseService<User>>();
            #endregion

            #region Forms
            services.AddTransient<Login, Login>();
            services.AddTransient<CategoryForm, CategoryForm>();
            services.AddTransient<CityForm, CityForm>();
            services.AddTransient<UserForm, UserForm>();
            #endregion

            services.AddSingleton(
                new MapperConfiguration(
                    config => {
                        config.CreateMap<User, UserViewModel>();
                        config.CreateMap<Category, CategoryViewModel>();
                        config.CreateMap<City, CityViewModel>();
                    },
                    NullLoggerFactory.Instance).CreateMapper()
                );
            serviceProvider = services.BuildServiceProvider();

        }
    }
}

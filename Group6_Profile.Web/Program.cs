using Group6_Profile.Service.Attributes;
using Group6_Profile.Service.Service;
using Group6_Profile.web.WebExtends;
using Snowflake.Core;
using System.Net;
using System.Reflection;

namespace Group6_Profile.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var worker = new IdWorker(1, 1);
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews().AddJsonOptions(ops =>
            {
                ops.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateTimeConverter());
                ops.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateTimeNullableConverter());
                ops.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.LongConverter());
                ops.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.LongNullableConverter());
            }).AddRazorRuntimeCompilation(); ;
            builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromDays(10); });
            // add user session service

            builder.Services.AddDistributedMemoryCache();
            #region  freesql
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                  .UseConnectionString((FreeSql.DataType)(Convert.ToInt32(builder.Configuration.GetConnectionString("DBType"))), builder.Configuration.GetConnectionString(builder.Configuration.GetConnectionString("ConnectionName")))
                 .UseAutoSyncStructure(true)
                .UseLazyLoading(false).UseGenerateCommandParameterWithLambda(true).Build();

            fsql.Aop.CurdAfter += (sender, e) =>
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd")} use {e.ElapsedMilliseconds} ms , sql: {e.Sql}");

            };
            // 
            fsql.Aop.AuditValue += (s, e) =>
            {
                if (e.Column.CsType == typeof(long?) &&
                    e.Property.GetCustomAttribute<SnowflakeAttribute>(false) != null &&
                    (e.Value == null || e.Value?.ToString() == "0"))
                    e.Value = worker.NextId();

            };

            builder.Services.AddSingleton<IFreeSql>(fsql);
            #endregion
            #region  
            var serviceAsm = Assembly.Load(new AssemblyName("Group6_Profile.Service"));

            foreach (Type serviceType in serviceAsm.GetTypes()
            .Where(t => typeof(IServiceTag).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract))
            {
                builder.Services.AddSingleton(serviceType);
            }
            builder.Services.AddAutoMapper(serviceAsm);// add Automapper
            #endregion

            // Add services to the container.

            builder.Services.AddRazorPages();
            builder.WebHost.UseKestrel(p =>
            {
                p.Listen(IPAddress.Any, 8111);
            });
            builder.Services.AddMemoryCache();//user memory
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
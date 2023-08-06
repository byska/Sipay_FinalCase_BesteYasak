using Hangfire;
using Sipay_Final.Api.Controllers;

namespace Sipay_Final.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            RecurringJob.AddOrUpdate<AdminController>(x => x.SchedulePaymentReminderJob(), Cron.Daily(10));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

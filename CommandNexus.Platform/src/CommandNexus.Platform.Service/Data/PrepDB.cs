using CommandNexus.Platform.Service.Models;

namespace CommandNexus.Platform.Service.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScoper = app.ApplicationServices.CreateScope())
            {
                var context = serviceScoper.ServiceProvider.GetRequiredService<AppDBContext>();

                DataSeed(context);
            }

            
        }

        public static void DataSeed(AppDBContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("Seeding Data....");
                context.Platforms.AddRange(
                    new PlatformModel
                    {
                        Name = ".NET",
                        Publisher = "Microsoft",
                        Cost = "Free"
                    },

                    new PlatformModel
                    {
                        Name = "Docker",
                        Publisher = "Docker INC.",
                        Cost = "Free/Paid"
                    },
                    new PlatformModel
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud Native Computing Foundation (CNCF)",
                        Cost = "Free, Open Source"
                    },
                    new PlatformModel
                    {
                        Name = "Azure",
                        Publisher = "Microsoft",
                        Cost = "Pay as you go"
                    });
                context.SaveChanges();
            }

            else
            {
                Console.WriteLine("Data already present");
            }
        }
    }
}

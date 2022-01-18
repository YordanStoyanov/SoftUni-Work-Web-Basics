using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web_Server_Asynchronous_Processing
{
    public class AsyncCooker
    {
        public async Task Work()
        {
            await Task.WhenAll(
                UnfreezeMincedMeat(),
                HeatPans(),
                YolksAreSeparated(),
                FryingMeatballs(),
                AssemblyTheBudgers()
                );

            await Task.WhenAll(
                MixMincedMeatWhitMustardEggYolksChoppedRedOnions(),
                CuttingTheCakes(),
                MadeTheMeatballs()
                );

            await ServeAndEat();

        }
        public static async Task AssemblyTheBudgers()
        {
            await Task.Delay(500);
            Console.WriteLine("The burgers are assebled");
        }
        public static async Task FryingMeatballs()
        {
            await Task.Delay(1000);
            Console.WriteLine("Frying the meatballs 10 min");
        }

        public static async Task MadeTheMeatballs()
        {
            await Task.Delay(200);
            Console.WriteLine("Made the meatballs for the cakes 2 min");
        }
        public static async Task CuttingTheCakes()
        {
            await Task.Delay(100);
            Console.WriteLine("Citting the cakes 1 min");
        }

        public static async Task UnfreezeMincedMeat()
        {
            await Task.Delay(2000);
            Console.WriteLine("Unfreeze 20 min");
        }
        public static async Task HeatPans()
        {
            await Task.Delay(1000);
            Console.WriteLine("Heat the pans 10 min");
        }
        public static async Task MixMincedMeatWhitMustardEggYolksChoppedRedOnions()
        {
            await Task.Delay(1000);
            Console.WriteLine("Mix 10 min");
        }
        public static async Task YolksAreSeparated()
        {
            await Task.Delay(100);
            Console.WriteLine("The yolks are separated 1 min");
        }
        public static async Task ServeAndEat()
        {
            await Task.Delay(5000);
            Console.WriteLine("Eating the budgers");
        }
    }
}

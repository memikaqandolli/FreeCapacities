using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FreeCapacities
{
    class Program
    {
        static void Main(string[] args)
        {
            //e mbushim listen e capacity dhe utilizations manualisht me te dhena
            // sikurse shembulli ne email
            List<Capacity> capacities = new List<Capacity>();
            capacities.Add(new Capacity(DateTime.Parse("01/01/2019 06:00:00"),DateTime.Parse( "01/01/2019 13:00:00")));
            capacities.Add(new Capacity(DateTime.Parse("01/01/2019 14:00:00"), DateTime.Parse("01/01/2019 22:00:00")));

            List<Utilization> utilizations = new List<Utilization>();
            utilizations.Add(new Utilization(DateTime.Parse("01/01/2019 08:00:00"), DateTime.Parse("01/01/2019 09:00:00")));
            utilizations.Add(new Utilization(DateTime.Parse("01/01/2019 11:00:00"), DateTime.Parse("01/01/2019 16:00:00")));

            DisplayFreeCapacities(capacities, utilizations);

            Console.ReadLine();
        }

        public static List<Capacity> GetFreeCapacities(List<Capacity> capacities, List<Utilization> utilizations)
        {
            List<Capacity> freeCapacities = new List<Capacity>();
            Capacity freeCapacity = new Capacity();

            for (int i = 0; i < utilizations.Count; i++)
            {
                //Nese kemi shum orare te lira, fundi i orarit te pare do te jete fillimi i perdorimit te pare
                // fundi i orarit te dyte fillmi i perdorimit te dyte e keshtu me rradhe deri te e parafundit
                freeCapacity.end = utilizations[i].start;
                if (i == 0)
                {
                    //Fillimi i orarit te lire eshte fillimi i capacity-t te pare 
                    freeCapacity.start = capacities[i].start;
                    freeCapacities.Add(freeCapacity); // Shtohet orari i pare i lire
                    freeCapacity = new Capacity();
                }
                if (i > 0)
                {
                    freeCapacities.Add(freeCapacity);
                    freeCapacity = new Capacity();
                }
                //Pastaj nese kemi shume orare te lira, fillmi i orarit te dyte do te jete fundi i perdorimit te pare
                // e keshtu me rradhe deri ne fund.
                freeCapacity.start = utilizations[i].end;
                
                
            }
            // Fundi i orarit te lire eshte fundi i capacity-t te fundit
                freeCapacity.end = capacities[capacities.Count - 1].end;
            freeCapacities.Add(freeCapacity);
            return freeCapacities;
        }
    
        public static void DisplayFreeCapacities(List<Capacity> capacities, List<Utilization> utilizations)
        {
            List<Capacity> freeCapacities = GetFreeCapacities(capacities,utilizations);

            Console.WriteLine("Capacities [");
            foreach (Capacity capacity in freeCapacities)
            {
                Console.WriteLine("\t{");
                Console.WriteLine($"\tStart: ,, {capacity.start} \"");
                Console.WriteLine($"\tEnd: ,, {capacity.end} \"");
                Console.WriteLine("}");
            }
            Console.WriteLine("]");
        }
    }
}

using System.Text.Json;

namespace Lab9_LINQ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string json = File.ReadAllText("C:\\Users\\KDots\\OneDrive\\Documents\\GitHub\\Lab9-LINQ\\Data.json");
            Console.WriteLine("Read file into stringring");

            FeatureCollection featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json);
            Console.WriteLine("Deserialized the json data");

            Location[] locations = featureCollection.features;
            Console.WriteLine(locations);

            Part1WithLINQ(locations);

            Part2WithLINQ(locations);

            Part3WithLINQ(locations);

            Part4WithLINQ(locations);




        }
        public static void Part1(Location[] items)
        {
            Dictionary<string, int> locationAppearances = new Dictionary<string, int>();
            for (int i = 0; i < items.Length; i++)
            {
                Location currentLocation = items[i];
                string neighborhood = currentLocation.properties.neighborhood;
                bool neighborhoodAlreadyInDictionary = locationAppearances.ContainsKey(neighborhood);
                if (neighborhoodAlreadyInDictionary == false)
                {
                    locationAppearances.Add(neighborhood, 1);
                }
                else
                {
                    int currentValue = locationAppearances.GetValueOrDefault(neighborhood);
                    int newValue = currentValue + 1;
                    locationAppearances[neighborhood] = newValue;

                }
            }

            foreach (var location in locationAppearances)
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }

        }

        public static void Part1WithLINQ(Location[] items)
        {
            var neighborHoodQuery = from item in items
                                        //where item.properties.neighborhood != ""
                                        //where !string.IsNullOrEmpty(item.properties.neighborhood)
                                    group item by item.properties.neighborhood into grouped
                                    select new { Key = grouped.Key, Value = grouped.Count() };

            foreach (var location in neighborHoodQuery)
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }

        public static void Part2WithLINQ(Location[] items)
        {
            var neighborHoodQuery = from item in items
                                    where item.properties.neighborhood != ""
                                    //where !string.IsNullOrEmpty(item.properties.neighborhood)
                                    //group item by item.properties.neighborhood into grouped
                                    select item;
            foreach (var location in neighborHoodQuery)
            {
                Console.WriteLine(location.properties.neighborhood);
                //Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }

        public static void Part3WithLINQ(Location[] items)
        {
            /* var neighborHoodQuery = from item in items
                                         //where item.properties.neighborhood != ""
                                     where !string.IsNullOrEmpty(item.properties.neighborhood)
                                     group item by item.properties.neighborhood into grouped
                                     select new { Key = grouped.Key, Value = grouped.Count() };*/

            var distinctQuery = (from item in items
                                 where !string.IsNullOrEmpty(item.properties.neighborhood)
                                 select item.properties.neighborhood).Distinct();
            var distinctMethod = items
                                .Where(item => !string.IsNullOrEmpty(item.properties.neighborhood))
                                .Select(item => item.properties.neighborhood)
                                .Distinct();

            foreach (string n in distinctMethod)
            {
                Console.WriteLine(n);
            }
        }

        public static void Part4WithLINQ(Location[] items)
        {
            
                var neighborhoodQuery = items
                    .Where(item => !string.IsNullOrEmpty(item.properties.neighborhood))
                    .Select(item => item.properties.neighborhood)
                    .Distinct();

                foreach (var neighborhood in neighborhoodQuery)
                {
                    Console.WriteLine(neighborhood);
                }
            
        }

    }
}
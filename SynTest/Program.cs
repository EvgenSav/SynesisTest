using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SynTest.InstanceServices;
using SynTest.Vehicles;
using SynTest.MyStrings;
using SynTest.MissingElements;

namespace SynTest {
    class Program {
        static void Main(string[] args) {
            //Task 2 - Get instances of Vehicle
            IEnumerable<Vehicle> vehicles = InstanceService.GetInstances<Vehicle>();
            Console.WriteLine("Vehicle names:");
            //Task 3.1 - Writing vehicle types sorted alphabetically
            foreach (var vehicle in vehicles.OrderBy(key => key.Name).Select(v => v)) {
                Type vehicleType = vehicle.GetType();
                Console.WriteLine(vehicleType.Name);
            }
            //Task 3.2 - Search for types by specifying part of the name
            string partName = "CaR";
            Console.WriteLine("Method for searching types by part of name: {0}", partName);
            IEnumerable<Vehicle> startsWithBiVehicles = vehicles.SearchType(partName);
            foreach (var vehicle in startsWithBiVehicles) {
                Type vehicleType = vehicle.GetType();
                Console.WriteLine(vehicleType.Name);
            }
            //Task 3.3 - Save vehicles to disk
            vehicles.WriteInstancesToDisk();
            //Task 4.1 - ReverseString
            string str1 = "1234";
            Console.WriteLine("Reversed string {0}: {1}", str1, MyString.ReverseString(str1));
            Console.WriteLine("Reversed string (extension) {0}: {1}", str1, str1.ReverseString());
            //Task 4.2 - Using IsPalindrome
            str1 = "lol";
            Console.WriteLine("IsPalindrome {0}: {1}", str1, MyString.IsPalindrome(str1));
            Console.WriteLine("IsPalindrome (extension) {0}: {1}", str1, str1.IsPalindrome());
            //Task 4.3 - MissingElements
            int[] inputarr = new int[] { 1, 3, 4 };
            Console.Write("Missing elements for input: ");
            foreach (var item in inputarr) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var missing in MissingElems.MissingElements(inputarr)) {
                Console.Write(missing + " ");
            }
            Console.ReadKey();
        }
    }
}

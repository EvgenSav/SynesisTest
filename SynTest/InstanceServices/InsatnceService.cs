using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using SynTest.Vehicles;

namespace SynTest.InstanceServices {
    public static class InstanceService {
        public static IEnumerable<T> GetInstances<T>()
            where T : Vehicle {
            List<T> res = new List<T>();
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {
                if (typeof(T) == type.BaseType) {
                    T instance = Activator.CreateInstance(type) as T;
                    if (instance != null) {
                        res.Add(instance);
                    }
                }
            }
            return res;
        }

        public static IEnumerable<T> SearchType<T>(this IEnumerable<T> instances, string partOfTypeName)
            where T : Vehicle {
            IEnumerable<T> res = new List<T>();
            if (partOfTypeName != "") {
                res = instances.Where(t => t.GetType().Name.ToLower().Contains(partOfTypeName.ToLower())).ToList();
            }
            return res;
        }

        public static int WriteInstancesToDisk<T>(this IEnumerable<T> instances, string file = "instances.txt")
            where T : Vehicle {
            try {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))) {
                    foreach (var inst in instances) {
                        Type instType = inst.GetType();
                        streamWriter.WriteLine("Vehicle: " + instType.Name + "\nProperties:");
                        foreach (var prop in instType.GetRuntimeProperties()) {
                            streamWriter.WriteLine("{0}: {1}", prop.Name, prop.GetValue(inst, null));

                        }
                        streamWriter.WriteLine();
                    }
                }
                return 0;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return -1; //ret error code
            }
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace WebApplication1.Models
{
    public static class ServicesRepo
    {
        public static IEnumerable<Service> GetServicesList(string pathToFile)
        {
            return LoadServices(pathToFile);
        }

        private static List<Service> LoadServices(string pathToFile)
        {
            string jsonString = File.ReadAllText(pathToFile);

            return JsonSerializer.Deserialize<List<Service>>(jsonString);
        }

        private static void SaveServicesList(string pathToFile, IEnumerable<Service> services)
        {
            string jsonString = JsonSerializer.Serialize(services);
            File.WriteAllText(pathToFile, jsonString);
        }

        public static string GetByName(string name, string pathToFile)
        {
            Service srvc = GetService(name, pathToFile);

            if (srvc == null)
            {
                return "Service not found";
            }

            return JsonSerializer.Serialize(srvc);
        }

        public static void AddNewService(Service srvc, string pathToFile)
        {
            List<Service> services = LoadServices(pathToFile);
            services.Add(srvc);

            SaveServicesList(pathToFile, services);
        }

        public static Service GetService(string name, string pathToFile)
        {
            List<Service> services = LoadServices(pathToFile);
            return services.Find(s => s.Name == name);
        }

        public static Service GetService(int id, string pathToFile)
        {
            List<Service> services = LoadServices(pathToFile);
            return services.Find(s => s.Id == id);
        }

        public static void UpdateService(Service srvc, string pathToFile)
        {
            List<Service> services = LoadServices(pathToFile);
            Service existedSrvc = GetService(srvc.Id, pathToFile);

            if(existedSrvc == null)
            {
                return;
            }
            services.Remove(existedSrvc);
            services.Add(srvc);
            SaveServicesList(pathToFile, services);
        }

        public static void DeleteService(string name, string pathToFile)
        {
            List<Service> services = LoadServices(pathToFile);
            Service existedSrvc = GetService(name, pathToFile);

            if (existedSrvc == null)
            {
                return;
            }
            services.Remove(existedSrvc);
            SaveServicesList(pathToFile, services);
        }

        public static void DeleteService(int id, string pathToFile)
        {
            List<Service> services = LoadServices(pathToFile);
            Service existedSrvc = GetService(id, pathToFile);

            if (existedSrvc == null)
            {
                return;
            }
            services.RemoveAll(s=> s.Id == id);
            SaveServicesList(pathToFile, services);
        }
    }
}
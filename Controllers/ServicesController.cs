using System.Collections.Generic;
using System.Web.Hosting;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ServicesController : ApiController
    {        
        public IEnumerable<Service> Get()
        {
            return ServicesRepo.GetServicesList(GetServicesFilePath());
        }
        
        public string Get(string name)
        {
            return  ServicesRepo.GetByName(name, GetServicesFilePath());            
        }

        [HttpPost]
        public void Post([FromBody]Service value)
        {
            ServicesRepo.AddNewService(value, GetServicesFilePath());
        }

        [HttpPut]
        public void Put([FromBody] Service value)
        {
            ServicesRepo.UpdateService(value, GetServicesFilePath());
        }
        
        [HttpDelete]
        public void Delete(string name)
        {
            ServicesRepo.DeleteService(name, GetServicesFilePath());
        }

        private string GetServicesFilePath()
        {
            return HostingEnvironment.MapPath("~/App_Data/Services.json");
        }
    }
}

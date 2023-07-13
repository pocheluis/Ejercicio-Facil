using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejerciciofacil.Model;
using ejerciciofacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace ejercicio_facil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ApiService service = new ApiService();

        // GET api/values/5
        [HttpGet]
        public ActionResult<NewJsonToModel> Get([FromBody]JsonToModel value)
        {
            NewJsonToModel model = new NewJsonToModel();
            model = service.JsonTo(value);
            return model;
        }

    }
}

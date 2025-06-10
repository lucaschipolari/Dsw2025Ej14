using Dsw2025J14.Api.Data;
using Dsw2025J14.Api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Dsw2025J14.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private IPersistenciaEnMemoria _persistenciaEnMemoria;

        public ProductsController(IPersistenciaEnMemoria persistenciaEnMemoria) { 
            _persistenciaEnMemoria = persistenciaEnMemoria;
        }

        [HttpGet()]
        public IActionResult GetProducts() {
            try {

                var productos = _persistenciaEnMemoria.GetProducts();

                if (productos == null) { 
                
                }


                return Ok(productos);

            } catch (Exception ex) {
                return NotFound();
            }

           
        
        }

        [HttpGet("sku")]

        public IActionResult GetProduct(string sku) {
            try
            {

                var producto = _persistenciaEnMemoria.GetProduct(sku);

                if (producto == null)
                {

                }


                return Ok(producto);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

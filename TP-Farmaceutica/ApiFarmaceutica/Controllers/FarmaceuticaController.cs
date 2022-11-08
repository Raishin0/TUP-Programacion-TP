using DataApi.dominio;
using DataAPI.fachada;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFarmaceutica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaceuticaController : ControllerBase
    {
        private IDataApi dataApi; //punto de acceso a la API

        public FarmaceuticaController()
        {
            dataApi = new DataApiImp();
        }

        // GET: api/<FarmaceuticaController>
        [HttpGet("/login")]
        public IActionResult GetLogin(string nombre, string password)
        {
            bool correcto = false;
            try
            {
                correcto = dataApi.Login(nombre, password);
                return Ok(correcto);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error de sesion! Intente de nuevo");
            }
        }

        // GET api/<FarmaceuticaController>/5
        [HttpGet("/formaspago")]
        public IActionResult GetObtenerFormasPago()
        {
            Dictionary<int,string> data;
            try
            {
                data = dataApi.ObtenerFormasPago();
                return Ok(data);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Intente en otro momento");
            }
        }
        
        // GET api/<FarmaceuticaController>/5
        [HttpGet("/obrassociales")]
        public IActionResult GetObtenerObrasSociales()
        {
            Dictionary<int, string> data;
            try
            {
                data = dataApi.ObtenerObrasSociales();
                return Ok(data);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Intente en otro momento");
            }
        }
        
        // GET api/<FarmaceuticaController>/5
        [HttpGet("/tipossuministros")]
        public IActionResult GetObtenerTiposSuministro()
        {
            Dictionary<int, string> data;
            try
            {
                data = dataApi.ObtenerTiposSuministro();
                return Ok(data);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Intente en otro momento");
            }
        }

        // GET api/<FarmaceuticaController>/5
        [HttpGet("/ventas")]
        public IActionResult GetObtenerVentasPorFiltros(string desde, string hasta, string? cliente="")
        {
            List<Venta> ventas = null;
            try
            {
                DateTime fechaInicio = DateTime.Parse(desde);
                DateTime fechaFinal = DateTime.Parse(hasta);
                ventas = dataApi.ObtenerVentasPorFiltros(fechaInicio, fechaFinal, cliente);
                return Ok(ventas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Revise los parametros o intente en otro momento");
            }
        }

        [HttpGet("/ventasDeshabilitadas")]
        public IActionResult GetObtenerVentasDesPorFiltros(string desde, string hasta, string? cliente = "")
        {
            List<Venta> ventas;
            try
            {
                DateTime fechaInicio = DateTime.Parse(desde);
                DateTime fechaFinal = DateTime.Parse(hasta);
                ventas = dataApi.ObtenerVentasDeshabilitadasPorFiltros(fechaInicio, fechaFinal, cliente);
                return Ok(ventas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Revise los parametros o intente en otro momento");
            }
        }


        // GET api/<FarmaceuticaController>/5
        [HttpGet("/suministros")]
        public IActionResult GetObtenerSuministros()
        {
            List<Suministro> sums;
            try
            {
                sums = dataApi.ObtenerSuministros();
                return Ok(sums);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Intente en otro momento");
            }
        }

        [HttpGet("/venta/{nro}")]
        public IActionResult GetObtenerVentaPorNro(int nro)
        {
            Venta venta;
            try
            {
                venta = dataApi.ObtenerVentaPorNro(nro);
                return Ok(venta);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Revise los parametros o intente en otro momento");
            }
        }

        [HttpGet("/NroProximaVenta")]
        public IActionResult GetObtenerNroProximaVenta()
        {
            int nro;
            try
            {
                nro = dataApi.ObtenerProximoNro();
                return Ok(nro);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Intente en otro momento");
            }
        }

        [HttpGet("/reporteventas")]
        public IActionResult GetObtenerReporteVentas(string desde, string hasta)
        {
            DataTable venta;
            try
            {
                DateTime fechaInicio = DateTime.Parse(desde);
                DateTime fechaFinal = DateTime.Parse(hasta);
                venta = dataApi.ObtenerReporteVentas(fechaInicio, fechaFinal);
                return Ok(JsonConvert.SerializeObject(venta));

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Revise los parametros o intente en otro momento");
            }
        }
        
        [HttpGet("/reportesuministros")]
        public IActionResult GetObtenerReporteSuministros()
        {
            DataTable venta;
            try
            {
                venta = dataApi.ObtenerReporteSuministros();
                return Ok(JsonConvert.SerializeObject(venta));

            }
            catch (Exception)
            {
                return StatusCode(500, "Error ! Intente en otro momento");
            }
        }

        // POST api/<FarmaceuticaController>
        [HttpPost("/venta")]
        public IActionResult PostCrearVenta(Venta venta)
        {
            try
            {
                if (venta == null)
                {
                    return BadRequest("Datos incorrectos!");
                }

                return Ok(dataApi.CrearVenta(venta));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // POST api/<FarmaceuticaController>
        [HttpPost("/suministro")]
        public IActionResult PostCrearSuministro(Suministro suministro)
        {
            try
            {
                if (suministro == null)
                {
                    return BadRequest("Datos incorrectos!");
                }

                return Ok(dataApi.CrearSuministro(suministro));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // PUT api/<FarmaceuticaController>/5
        [HttpPut("/venta/{nro}")]
        public IActionResult PutActualizarVenta(int nro, Venta venta)
        {
            venta.Codigo = nro;
            try
            {
                if (venta == null)
                {
                    return BadRequest("Datos incorrectos!");
                }

                return Ok(dataApi.ActualizarVenta(venta));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // PUT api/<FarmaceuticaController>/5
        [HttpPut("/suministro/{nro}")]
        public IActionResult PutActualizarSuministro(int nro,Suministro suministro)
        {
            suministro.Codigo = nro;
            try
            {
                if (suministro == null)
                {
                    return BadRequest("Datos incorrectos!");
                }

                return Ok(dataApi.ActualizarSuministro(suministro));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // DELETE api/<FarmaceuticaController>/5
        [HttpDelete("/venta/{nro}")]
        public IActionResult DeleteBorrarVenta(int nro)
        {
            try
            {
                if (nro <= 0)
                {
                    return BadRequest("Datos incorrectos!");
                }

                return Ok(dataApi.BorrarVenta(nro));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        
        // DELETE api/<FarmaceuticaController>/5
        [HttpDelete("/suministro/{nro}")]
        public IActionResult DeleteBorrarSuministro(int nro)
        {
            try
            {
                if (nro == null)
                {
                    return BadRequest("Datos incorrectos!");
                }

                return Ok(dataApi.BorrarSuministro(nro));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}

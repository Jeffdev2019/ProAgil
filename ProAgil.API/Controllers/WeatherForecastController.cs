using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public WeatherForecastController(DataContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           try
           {
               var results = await _dbContext.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);

               return Ok(results);
           }
           catch (System.Exception)
           {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
           }
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _dbContext.Eventos.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}

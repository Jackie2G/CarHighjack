using CarHighjack.Domain;
using CarHighjack.Inftastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarHighjack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AmiFlotaContext _context;

        public CarsController(AmiFlotaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        [HttpGet("{vin}")]
        public async Task<ActionResult<Car>> GetCar(string vin)
        {
            var car = await _context.Cars.FindAsync(vin);
            if (car == null) return NotFound();
            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { vin = car.VIN }, car);
        }

        [HttpDelete("{vin}")]
        public async Task<IActionResult> DeleteCar(string vin)
        {
            var car = await _context.Cars.FindAsync(vin);
            if (car == null) return NotFound();
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
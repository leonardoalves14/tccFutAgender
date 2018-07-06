using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 CARGO

    [Route("api/cargos")]
    public class CargoController : Controller
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        [HttpGet]
        public IActionResult GetAllCargos()
        {
            var result = new List<CargoModel>();
            var list = _cargoRepository.GetAllCargos();

            foreach (var cargo in list)
            {
                result.Add(new CargoModel
                {
                    Cargo_Id = cargo.CargoId,
                    Cargo_Desc = cargo.CargoDesc
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargo([FromBody] CargoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cargo = new Cargo
            {
                CargoDesc = model.Cargo_Desc
            };

            var newCargo = _cargoRepository.CreateCargo(cargo);

            model.Cargo_Id = newCargo.CargoId;
            model.Cargo_Desc = newCargo.CargoDesc;

            return Ok(model);
        }

        [HttpPut("{cargoId}")]
        public IActionResult UpdateCargo(int cargoId, [FromBody] CargoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_cargoRepository.CargoExists(cargoId))
            {
                return NotFound($"Cargo {cargoId} não existe!");
            }

            var cargo = new Cargo
            {
                CargoId = model.Cargo_Id,
                CargoDesc = model.Cargo_Desc
            };

            _cargoRepository.UpdateCargo(cargo);

            return NoContent();
        }

        [HttpDelete("{cargoId}")]
        public IActionResult DeleteCargo(int cargoId)
        {
            if (!_cargoRepository.CargoExists(cargoId))
            {
                return NotFound($"Cargo {cargoId} não existe!");
            }

            _cargoRepository.DeleteCargo(cargoId);

            return NoContent();
        }
    }
}
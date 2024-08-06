using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.interfaces;
using WebApplication1.models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/kendaraan")]
    [ApiController]
    public class KendaraanController : ControllerBase
    {
        private readonly IKendaraanService _kendaraanService;

        public KendaraanController(IKendaraanService kendaraanService)
        {
            _kendaraanService = kendaraanService;
        }

        [HttpPost("mobil")]
        public IActionResult AddMobil([FromBody] Mobil kendaraan)
        {
            _kendaraanService.AddKendaraan(kendaraan);
            return Ok("data mobil disimpan");
        }

        [HttpPost("motor")]
        public IActionResult AddMotor([FromBody] Motor kendaraan)
        {
            _kendaraanService.AddKendaraan(kendaraan);
            return Ok("data motor disimpan");
        }

        [HttpPost("mobil-listrik")]
        public IActionResult AddMobilListrik([FromBody] MobilListrik mobil)
        {
            _kendaraanService.AddKendaraan(mobil);
            return Ok("data mobil listrik disimpan");
        }

        [HttpPost("motor-listrik")]
        public IActionResult AddMotorListrik([FromBody] MotorListrik motor)
        {   
            _kendaraanService.AddKendaraan(motor);
            return Ok("data motor listrik disimpan");
        }

        [HttpGet]
        public IActionResult GetAllKendaraan()
        {
            return Ok(_kendaraanService.GetAllKendaraan());
        }

        [HttpGet("{id}")]
        public IActionResult GetKendaraanById(int id)
        {

            var kendaraan = _kendaraanService.GetKendaraanById(id);
            if (kendaraan == null)
            {
                return NotFound();
            }
            return Ok(kendaraan);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateKendaraan(int id, [FromBody] Kendaraan updatedKendaraan)
        {
            updatedKendaraan.Id = id; 

            try
            {
                _kendaraanService.UpdateKendaraan(updatedKendaraan);
                return Ok("Kendaraan berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Terjadi kesalahan: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKendaraan(int id)
        {

            var delKendaraan = _kendaraanService.GetKendaraanById(id);

            if (delKendaraan == null)
            {

                return NotFound("ID tidak ditemukan");
            }

            _kendaraanService.DeleteKendaraan(id);
            return Ok("Data dengan id" + id +"berhasil dihapus");
        }

        [HttpPost("charge/{id}")]
        public IActionResult ChargeKendaraanListrik(int id, [FromBody] int chargeAmount)
        {
            try
            {
                _kendaraanService.ChargeKendaraanListrik(id, chargeAmount);
                return Ok("Kendaraan berhasil di-charge.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Terjadi kesalahan: {ex.Message}");
            }
        }

        [HttpGet("allKendaraan")]
        public IActionResult TampilkanSemuaKendaraan()
        {
            var kendaraanList = _kendaraanService.GetAllKendaraan();
            return Ok(kendaraanList);
        }
    }
}

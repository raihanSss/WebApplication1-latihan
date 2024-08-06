using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.interfaces;
using WebApplication1.models;

namespace WebApplication1.Services
{
    public class KendaraanService : IKendaraanService
    {

        private readonly EFCoreDbContext _context;

        public KendaraanService(EFCoreDbContext context)

        {

            _context = context;

        }
        private readonly List<Kendaraan> _kendaraanList = new List<Kendaraan>();

        public IEnumerable<Kendaraan> GetAllKendaraan()
        {
            return _context.Vehicles;
            
        }

        public Kendaraan GetKendaraanById(int id)
        {
            return _context.Vehicles.FirstOrDefault(k => k.Id == id);
        }

        public void AddKendaraan(Kendaraan kendaraan)
        {
            _context.Vehicles.Add(kendaraan);
            _context.SaveChanges();
        }

        public void UpdateKendaraan(Kendaraan updatedKendaraan)
        {
            var existingKendaraan = _context.Vehicles.FirstOrDefault(k => k.Id == updatedKendaraan.Id);

 
        }

        public void DeleteKendaraan(int id)
        {
            var kendaraan = GetKendaraanById(id);
            if (kendaraan != null)
            {
                _context.Vehicles.Remove(kendaraan);
            }
        }

        public void ChargeKendaraanListrik(int id, int chargeAmount)
        {
            var kendaraan = GetKendaraanById(id);

            if (kendaraan is IElektrik kendaraanListrik)
            {
                kendaraanListrik.Charge(chargeAmount);
            }
            else
            {
                throw new InvalidOperationException("Kendaraan tidak mendukung pengisian daya.");
            }
        }

        public string TampilkanSemuaKendaraan()
        {
            return string.Join(", ", _kendaraanList.Select(k => $"{k.GetType().Name} - Nama: {k.Nama}, Merk: {k.Merk}, ID: {k.Id}"));
        }


        


    }



}

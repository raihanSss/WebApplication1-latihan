
using System.Collections.Generic;
using WebApplication1.models
;
namespace WebApplication1.interfaces
{
    public interface IKendaraanService
    {
        IEnumerable<Kendaraan> GetAllKendaraan();
        Kendaraan GetKendaraanById(int id);
        void AddKendaraan(Kendaraan kendaraan);
        void UpdateKendaraan(Kendaraan kendaraan);
        void DeleteKendaraan(int id);
        void ChargeKendaraanListrik(int id, int chargeAmount);
        string TampilkanSemuaKendaraan();
    }
}

using WebApplication1.interfaces;

namespace WebApplication1.models
{
    public class MobilListrik : Mobil, IElektrik
    {
        public int KapasitasBaterai { get; set; }
        private int _dayaBaterai;

        public MobilListrik()
        {
           _dayaBaterai = 0;
        }

        public void Charge(int charge)
        {
            _dayaBaterai = Math.Min(_dayaBaterai + charge, KapasitasBaterai);
        }

        public int DayaBaterai
        {
            get { return _dayaBaterai; }
        }


    }
}

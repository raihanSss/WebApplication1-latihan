using WebApplication1.interfaces;

namespace WebApplication1.models
{
    public class MotorListrik : Motor, IElektrik
    {
        public int KapasitasBaterai { get; set; }
        private int _dayaBaterai;

        public MotorListrik()
        {
            _dayaBaterai = 0;
        }

        public void Charge(int charge)
        {
            if (charge < 0)
            {
                throw new ArgumentException("Charge amount must be non-negative.");
            }

            _dayaBaterai = Math.Min(_dayaBaterai + charge, KapasitasBaterai);
        }

        
        public int DayaBaterai
        {
            get { return _dayaBaterai; }
        }
    }
}

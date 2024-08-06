namespace WebApplication1.interfaces
{
    public interface IElektrik
    {
        int KapasitasBaterai { get; set; }
        void Charge(int charge);

    }
}

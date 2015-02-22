namespace Domino.Logic.Interfaces
{
    public interface ITile
    {
        bool IsDouble { get; set; }
        int Head { get; set; }
        int Tail { get; set; }
        bool HeadTaked { get; set; }
        bool TailTaked { get; set; }
        void Swap();
        int CompareTo(object obj);
        bool Equals(object obj);
    }
}
namespace Domino.Logic.Interfaces
{
    public interface IBoard
    {
        int TilesAmount { set; get; }
        void AddTile(int position, Tile tile);
        void Initialize();
    }
}
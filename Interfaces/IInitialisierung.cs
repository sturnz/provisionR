namespace Jasmin1.Interfaces
{
    public interface IInitialisierung
    {
        bool DatabaseExists();
        void MakeDatabase();
    }
}
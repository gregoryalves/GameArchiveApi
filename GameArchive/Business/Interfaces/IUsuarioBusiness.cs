namespace GameArchive.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        string GerarHashMd5(string? senha);
    }
}

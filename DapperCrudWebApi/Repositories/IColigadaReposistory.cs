using DapperCrudWebApi.Model;

namespace DapperCrudWebApi.Repositories
{
  public interface IColigadaReposistory
  {
    Task<List<Coligada>> GetColigadasAsync();
    Task<Coligada> GetColigadaByCodeAsync(string coligadaCode);
    Task<ColigadaContainer> GetColigadasAndCountAsync();
    Task<Coligada> SaveAsync(Coligada coligada);
    Task<Coligada> UpdateAsync(Coligada coligada);
    Task<int> DeleteAsync(string coligadaCode);
  }
}

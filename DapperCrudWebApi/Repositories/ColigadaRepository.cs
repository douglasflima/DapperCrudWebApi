using Dapper;
using DapperCrudWebApi.Helpers;
using DapperCrudWebApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace DapperCrudWebApi.Repositories
{
  public class ColigadaRepository : IColigadaReposistory
  {
    #region Propertities/Constructors
    private DbSession _db;

    public ColigadaRepository(DbSession db)
    {
      _db = db;
    }
    #endregion

    #region Public Methods
    public async Task<List<Coligada>> GetColigadasAsync() =>
      (await GetColigadasInternalAsync(_db.Connection)).ToList();

    public async Task<Coligada> GetColigadaByCodeAsync(string coligadaCode)
    {
      using var connection = _db.Connection;
      var anynomousParamColigadaCode = new { coligadaCode };
      var query = "SELECT TOP 10 * FROM DBO.COLIGADAFAKE WHERE CODE = @coligadaCode";
      return await connection.QueryFirstAsync<Coligada>(query, anynomousParamColigadaCode);
    }

    public async Task<ColigadaContainer> GetColigadasAndCountAsync()
    {
      using var connection = _db.Connection;
      var query =
        @"SELECT COUNT(1) FROM DBO.COLIGADAFAKE
          SELECT TOP 10 * FROM DBO.COLIGADAFAKE ORDER BY ID DESC";

      var result = await connection.QueryMultipleAsync(sql: query);

      return new ColigadaContainer
      {
        Count = (await result.ReadAsync<int>()).FirstOrDefault(),
        Coligadas = (await result.ReadAsync<Coligada>()).ToList()
      };
    }

    public async Task<Coligada> SaveAsync(Coligada coligada)
    {
      using var connection = _db.Connection;
      var anynomousParamColigada = new
      {
        coligada.Code,
        coligada.Description,
        coligada.RecCreatedBy,
        coligada.RecCreatedOn,
      };

      var query =
        @"INSERT INTO COLIGADAFAKE(CODE, DESCRIPTION, RECCREATEDBY, RECCREATEDON)
          VALUES(@Code, @Description, @RecCreatedBy, @RecCreatedOn)";

      await connection.ExecuteAsync(query, anynomousParamColigada);

      return await GetColigadaByCodeAsync(coligada.Code);
    }
        
    public async Task<Coligada> UpdateAsync(Coligada coligada)
    {
      using var connection = _db.Connection;
      var anynomousParamColigada = new
      {
        coligada.Code,
        coligada.Description,
        coligada.RecCreatedBy,
        coligada.RecCreatedOn,
      };

      var query = @"UPDATE COLIGADAFAKE SET 
          DESCRIPTION = @Description, RECCREATEDBY = @RecCreatedBy, RECCREATEDON = @RecCreatedOn
          WHERE CODE = @Code";

      await connection.ExecuteAsync(query, anynomousParamColigada);

      return await GetColigadaByCodeAsync(coligada.Code);
    }
    
    public async Task<int> DeleteAsync(string coligadaCode)
    {
      using var connection = _db.Connection;
      var anynomousParamColigadaCode = new { coligadaCode };
      var query = @"DELETE FROM COLIGADAFAKE WHERE CODE = @coligadaCode";

      return await connection.ExecuteAsync(query, anynomousParamColigadaCode);
    }
    #endregion

    #region Internal Methods
    internal static async Task<IEnumerable<Coligada>> GetColigadasInternalAsync(IDbConnection connection)
    {
      var query = "SELECT TOP 10 * FROM DBO.COLIGADAFAKE ORDER BY ID DESC";
      return (await connection.QueryAsync<Coligada>(sql: query)).ToList();
    }
    #endregion
  }
}

using Dapper;
using DapperCrudWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperCrudWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ColigadaController : ControllerBase
  {
    #region Propertities/Constructos
    private readonly IConfiguration _config;
    //private readonly IColigadaReposistory _coligadaRespoitory;

    public ColigadaController(IConfiguration config)
    {
      _config = config;
      //_coligadaRespoitory = coligadaRespoitory;
    }
    #endregion

    #region Public Methods
    [HttpGet]
    public async Task<ActionResult<List<Coligada>>> GetColigadasAsync()
    {
      using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      var coligadas = await GetColigadasInternalAsync(connection);
      
      return Ok(coligadas);
    }

    [HttpGet("{coligadaCode}")]
    public async Task<ActionResult<Coligada>> GetColigadaAsync(string coligadaCode)
    {
      using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      var anynomousParamColigadaCode = new { coligadaCode };
      var query = "SELECT * FROM DBO.COLIGADAFAKE WHERE CODE = @coligadaCode";
      var coligada = await connection.QueryFirstAsync<Coligada>(query, anynomousParamColigadaCode);

      return Ok(coligada);
    }

    [HttpPost]
    public async Task<ActionResult<Coligada>> SaveColigadaAsync(Coligada coligada)
    {
      using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
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

      return Ok(await GetColigadasInternalAsync(connection));
    }

    [HttpPut]
    public async Task<ActionResult<Coligada>> UpdateColigadaAsync(Coligada coligada)
    {
      using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
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

      return Ok(await GetColigadasInternalAsync(connection));
    }

    [HttpDelete("{coligadaCode}")]
    public async Task<ActionResult<Coligada>> DeleteColigadaAsync(string coligadaCode)
    {
      using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      var anynomousParamColigadaCode = new { coligadaCode };

      var query = @"DELETE FROM COLIGADAFAKE WHERE CODE = @coligadaCode";

      await connection.ExecuteAsync(query, anynomousParamColigadaCode);

      return Ok(await GetColigadasInternalAsync(connection));
    }
    #endregion

    #region Internal Methods
    internal static async Task<IEnumerable<Coligada>> GetColigadasInternalAsync(SqlConnection connection) =>
      await connection.QueryAsync<Coligada>("SELECT TOP 5 * FROM DBO.COLIGADAFAKE ORDER BY ID DESC");
    #endregion

    #region Implements
    /*
    [HttpGet]
    public async Task<ActionResult<ColigadaContainer>> GetColigadasAndCountAsync()
    {
      using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      var query =
        @"SELECT COUNT(1) FROM DBO.COLIGADAFAKE
          SELECT TOP 10 * FROM DBO.COLIGADAFAKE";

      var result = await connection.QueryMultipleAsync(sql: query);

      var coligadaContainer = new ColigadaContainer
      {
        Count = (await result.ReadAsync<int>()).FirstOrDefault(),
        Coligadas = (await result.ReadAsync<Coligada>()).ToList()
      };

      return Ok(coligadaContainer);
    }
    */
    #endregion
  }
}

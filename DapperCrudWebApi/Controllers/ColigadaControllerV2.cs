using DapperCrudWebApi.Model;
using DapperCrudWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrudWebApi.Controllers
{/*
  [Route("api/[controller]")]
  [ApiController]
  public class ColigadaControllerV2 : ControllerBase
  {
    #region Propertities/Constructos
    private readonly IColigadaReposistory _coligadaRespository;

    public ColigadaControllerV2(IColigadaReposistory coligadaRespository)
    {
      _coligadaRespository = coligadaRespository;
    }
    #endregion

    #region Publics Methods
    [HttpGet]
    public async Task<ActionResult<List<Coligada>>> GetColigadasAsync()
    {
      var coligadas = await _coligadaRespository.GetColigadasAsync();
      return Ok(coligadas);
    }

    [HttpGet("{coligadaCode}")]
    public async Task<ActionResult<Coligada>> GetColigadaAsync(string coligadaCode)
    {
      var coligadas = await _coligadaRespository.GetColigadaByCodeAsync(coligadaCode);
      return Ok(coligadas);
    }

    [HttpGet]
    public async Task<ActionResult<ColigadaContainer>> GetColigadasAndCountAsync()
    {
      var coligadas = await _coligadaRespository.GetColigadasAndCountAsync();
      return Ok(coligadas);
    }


    [HttpPost]
    public async Task<ActionResult<Coligada>> CreateColigadaAsync(Coligada coligada)
    {
      var coligadas = await _coligadaRespository.SaveAsync(coligada);
      return Ok(coligadas);
    }

    [HttpPut]
    public async Task<ActionResult<Coligada>> UpdateColigadaAsync(Coligada coligada)
    {
      var coligadas = await _coligadaRespository.UpdateAsync(coligada);
      return Ok(coligadas);
    }


    [HttpDelete("{coligadaCode}")]
    public async Task<ActionResult<int>> DeleteColigadaAsync(string coligadaCode)
    {
      var coligadas = await _coligadaRespository.DeleteAsync(coligadaCode);
      return Ok(coligadas);
    }
    #endregion
  }
*/
}

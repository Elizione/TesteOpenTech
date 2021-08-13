using CadastroEmpresaTeste.Data;
using CadastroEmpresaTeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEmpresaTeste.Controllers
{
    public class EmpresaController : Controller
    {
        public IAppRepository Repository { get; }

        public EmpresaController(IAppRepository repository)
        {
            this.Repository = repository;
        }


        public async Task<IActionResult> Index()
        {
            var result = await Repository.GetAllEmpresas();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repository.GetAllEmpresas();
                //return Ok(result);
                return View(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await Repository.GetEmpresa(id);
                return View(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpresa([FromBody] Empresa empresa)
        {
            try
            {
                Repository.Add(empresa);
                if (await Repository.SaveChangesAsync())
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(empresa);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpresa(int id, [FromBody] Empresa empresa)
        {
            try
            {
                Repository.Update(empresa);
                if (await Repository.SaveChangesAsync())
                {
                    return View(empresa);
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            try
            {
                var p = await Repository.GetEmpresa(id);
                Repository.Delete(p);
                if (await Repository.SaveChangesAsync())
                {
                    return RedirectToAction(nameof(Index));
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }
    }
}


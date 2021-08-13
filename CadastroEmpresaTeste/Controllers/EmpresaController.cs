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
            var result = await Repository.GetAllEmpresasAsync();
            return View(result);
        }

    
        

        // [HttpGet("{id}")]
        // public async Task<IActionResult> Get(int id)
        // {
        //     try
        //     {
        //         var result = await Repository.GetEmpresaAsync(id);
        //         return View(result);
        //     }
        //     catch (System.Exception)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
        //     }
        // }

        [HttpGet]
        public IActionResult CreateEmpresa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpresa(Empresa empresa)
        {
            try
            {
                Repository.Add(empresa);
                if (await Repository.SaveChangesAsync())
                {
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }

        [HttpGet]
        public IActionResult UpdateEmpresa(int id)
        {
            try
            {
                Empresa empresa = Repository.GetEmpresa(id);
                return View(empresa);
            }
            catch (System.Exception)
            {
                 return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
                
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmpresa(int id, Empresa empresa)
        {
            try
            {
                Repository.Update(empresa);
                if (await Repository.SaveChangesAsync())
                {
                    //return View(empresa);
                    return RedirectToAction(nameof(Index));
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }


        [HttpGet]
        public IActionResult DeleteEmpresa(int id)
        {
            try
            {
                Empresa empresa = Repository.GetEmpresa(id);
                return View(empresa);
            }
            catch (System.Exception)
            {
                 return StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
                
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEmpresa(int id, Empresa empresa)
        {
            try
            {
                var emp = await Repository.GetEmpresaAsync(id);
                Repository.Delete(emp);
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


using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using System.Linq;

namespace Proyecto_final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly Practica1Context _DBcontext;
        public CursoController(Practica1Context dBcontext)
        {
            this._DBcontext = dBcontext;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var curso=this._DBcontext.CursosUmgs.ToList();
            return Ok(curso);
        }
        [HttpGet("GetbyCode/{code}")]
        public IActionResult GetbyCode(int code)
        {
            var curso=this._DBcontext.CursosUmgs.FirstOrDefault(x=>x.Id==code);
            return Ok(curso);
        }

        [HttpDelete("Remove/{code}")]
        public IActionResult Remove(int code)
        {
            var curso = _DBcontext.CursosUmgs.FirstOrDefault(x => x.Id == code);
            if(curso!=null){
                this._DBcontext.CursosUmgs.Remove(curso);
                this._DBcontext.SaveChanges();
                return Ok(true);
            }
            return Ok(false);
        }
        
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CursosUmg _curso)
        {
            var curso = this._DBcontext.CursosUmgs.FirstOrDefault(x => x.Id == _curso.Id);
            if(curso!=null){
                curso.Curos=_curso.Curos;
                curso.Semestre=_curso.Semestre;
                curso.Creditos=_curso.Creditos;
                this._DBcontext.SaveChanges();
            }
            else{
                this._DBcontext.CursosUmgs.Add(_curso);
                this._DBcontext.SaveChanges();
            }
            return Ok(true);
        }
    }
}
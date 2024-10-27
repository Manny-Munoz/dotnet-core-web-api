using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using System.Linq;

namespace Proyecto_final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly Practica1Context _DBcontext;
        public EstudianteController(Practica1Context dBcontext)
        {
            this._DBcontext = dBcontext;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var estudiante=this._DBcontext.EstudiantesUmgs.ToList();
            return Ok(estudiante);
        }
        [HttpGet("GetbyCode/{code}")]
        public IActionResult GetbyCode(int code)
        {
            var estudiante=this._DBcontext.EstudiantesUmgs.FirstOrDefault(x=>x.Id==code);
            return Ok(estudiante);
        }

        [HttpDelete("Remove/{code}")]
        public IActionResult Remove(int code)
        {
            var estudiante = _DBcontext.EstudiantesUmgs.FirstOrDefault(x => x.Id == code);
            if(estudiante!=null){
                this._DBcontext.EstudiantesUmgs.Remove(estudiante);
                this._DBcontext.SaveChanges();
                return Ok(true);
            }
            return Ok(false);
        }
        
        [HttpPost("Create")]
        public IActionResult Create([FromBody] EstudiantesUmg _estudiante)
        {
            var estudiante = this._DBcontext.EstudiantesUmgs.FirstOrDefault(x => x.Id == _estudiante.Id);
            if(estudiante!=null){
                estudiante.Nombre=_estudiante.Nombre;
                estudiante.Apellido=_estudiante.Apellido;
                estudiante.Edad=_estudiante.Edad;
                estudiante.CorreoElectronico=_estudiante.CorreoElectronico;
                this._DBcontext.SaveChanges();
            }
            else{
                this._DBcontext.EstudiantesUmgs.Add(_estudiante);
                this._DBcontext.SaveChanges();
            }
            return Ok(true);
        }
    }
}
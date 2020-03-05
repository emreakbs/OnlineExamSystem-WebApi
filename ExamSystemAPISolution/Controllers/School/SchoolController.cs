using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model.SchoolModels;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystemAPISolution.Controllers.School
{
    [Route("School/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        #region AddSchool
        /// <summary>
        /// Okul eklemeye yarayan metod
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPost("AddSchool")]
        public IActionResult AddSchool(SchoolModel school)
        {
            try
            {
                if (!ModelState.IsValid) return (BadRequest("İstek geçerli değil."));
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var control = uow.GetRepository<SchoolModel>().Get(x => x.SchoolName.Equals(school.SchoolName));

                    switch (control)
                    {
                        case null:
                            uow.GetRepository<SchoolModel>().Add(school);
                            return uow.SaveChanges() > 0 ? Ok(school) : StatusCode(424, "Beklenmeyen hata gerçekleşti.");
                        default:
                            return Conflict("Okul adı daha önceden bulunmaktadır.");
                    }
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region SchoolList
        /// <summary>
        /// Okulları Listeleyen metod
        /// </summary>
        /// <param name="id">eğer 0 gönderilirse tümünü, 0 dan farklı gönderilirse tekli döndürür</param>
        /// <returns></returns>
        [HttpGet("SchoolList/{id}")]
        public IActionResult SchoolList(int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");

                using (UnitOfWork uow = new UnitOfWork())
                {
                    var schoolModel = uow.GetRepository<SchoolModel>();
                    return id == 0 ? Ok(schoolModel.GetAll().ToList()) : Ok(schoolModel.Get(x => x.Id.Equals(id)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        #endregion

        #region Remove School
        [HttpDelete("RemoveSchool/{id}")]
        public IActionResult RemoveSchool(int id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var schoolModel = uow.GetRepository<SchoolModel>();

                    schoolModel.Delete(schoolModel.Get(x => x.Id.Equals(id)));

                    return uow.SaveChanges() > 0
                        ? Ok("Okul başarı ile silindi.")
                        : StatusCode(424, "Beklenmeyen bir hata gerçekleşti.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        #endregion

    }
}
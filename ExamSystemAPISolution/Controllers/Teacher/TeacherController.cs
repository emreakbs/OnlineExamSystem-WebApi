using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model.TeacherModels;
using DataAccess.UnitOfWork;
using DataAccess.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystemAPISolution.Controllers.Teacher
{
    [Route("Teacher/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        #region AddTeacher
        /// <summary>
        /// Departman eklemeye yarayan metod
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost("AddTeacher")]
        public IActionResult AddTeacher(TeacherModel teacher)
        {
            try
            {
                if (!ModelState.IsValid) return (BadRequest("İstek geçerli değil."));
                using (UnitOfWork uow = new UnitOfWork())
                {
                    teacher.TeacherPassword=CryptoExtensions.Md5Encrypt(teacher.TeacherPassword);
                    uow.GetRepository<TeacherModel>().Add(teacher);
                    return uow.SaveChanges() > 0 ? Ok(teacher) : StatusCode(424, "Beklenmeyen hata gerçekleşti.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region TeacherList
        /// <summary>
        /// Departmanları Listeleyen metod
        /// </summary>
        /// <returns></returns>
        [HttpGet("TeacherList")]
        public IActionResult TeacherList()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");

                using (UnitOfWork uow = new UnitOfWork())
                {
                    var teacherModel = uow.GetRepository<TeacherModel>();
                    return Ok(teacherModel.GetAll().Include(x => x.Branch).Include(x => x.Department).ToList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        #endregion

        #region Remove Teacher
        [HttpDelete("RemoveTeacher/{id}")]
        public IActionResult RemoveTeacher(int id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var teacherModel = uow.GetRepository<TeacherModel>();

                    teacherModel.Delete(teacherModel.Get(x => x.Id.Equals(id)));

                    return uow.SaveChanges() > 0
                        ? Ok("Öğretmen başarı ile silindi.")
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

        #region Edit Teacher
        [HttpPut("EditTeacher")]
        public IActionResult EditTeacher(TeacherModel teacher)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var teacherModel = uow.GetRepository<TeacherModel>();
                    var teacherControl = teacherModel.GetAll(x => x.Id.Equals(teacher.Id));

                    if (teacherControl != null) uow.GetRepository<TeacherModel>().Update(teacher);

                    return uow.SaveChanges() > 0 ? Ok(teacher) : StatusCode(424, "Beklenmeyen bir hata oluştu.");
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
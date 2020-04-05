using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystemAPISolution.Controllers.Department
{
    [Route("Department/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        #region AddDepartment
        /// <summary>
        /// Departman eklemeye yarayan metod
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(DepartmentModel department)
        {
            try
            {
                if (!ModelState.IsValid) return (BadRequest("İstek geçerli değil."));
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var control = uow.GetRepository<DepartmentModel>().Get(x => x.DepartmentName.Equals(department.DepartmentName) && x.SchoolId.Equals(department.SchoolId));

                    switch (control)
                    {
                        case null:
                            uow.GetRepository<DepartmentModel>().Add(department);
                            return uow.SaveChanges() > 0 ? Ok(department) : StatusCode(424, "Beklenmeyen hata gerçekleşti.");
                        default:
                            return Conflict("Departman daha önceden bulunmaktadır.");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region DepartmentList
        /// <summary>
        /// Departmanları Listeleyen metod
        /// </summary>
        /// <returns></returns>
        [HttpGet("DepartmentList")]
        public IActionResult DepartmentList()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");

                using (UnitOfWork uow = new UnitOfWork())
                {
                    var departmentModel = uow.GetRepository<DepartmentModel>();
                   return Ok(departmentModel.GetAll().Include(x=>x.School).ToList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        #endregion

        #region Remove Department
        [HttpDelete("RemoveDepartment/{id}")]
        public IActionResult RemoveDepartment(int id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var departmentModel = uow.GetRepository<DepartmentModel>();

                    departmentModel.Delete(departmentModel.Get(x => x.Id.Equals(id)));

                    return uow.SaveChanges() > 0
                        ? Ok("Depatmant başarı ile silindi.")
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

        #region Edit Department
        [HttpPut("EditDepartment")]
        public IActionResult EditDepartment(DepartmentModel department)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var departmentModel = uow.GetRepository<DepartmentModel>();
                    var departmentControl = departmentModel.GetAll(x => x.Id.Equals(department.Id));

                    if (departmentControl != null) uow.GetRepository<DepartmentModel>().Update(department);

                    return uow.SaveChanges() > 0 ? Ok(department) : StatusCode(424, "Beklenmeyen bir hata oluştu.");
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
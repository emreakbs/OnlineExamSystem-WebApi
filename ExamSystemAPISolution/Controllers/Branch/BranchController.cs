using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model.TeacherModels;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystemAPISolution.Controllers.Branch
{
    [Route("Branch/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        #region Add Branch
        /// <summary>
        /// Branş eklemeye yarar
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        [HttpPost("AddBranch")]
        public IActionResult AddBranch(BranchModel branch)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var control = uow.GetRepository<BranchModel>().Get(x => x.BranchName.ToLower().Equals(branch.BranchName.ToLower()));

                    if (control == null)
                    {
                        uow.GetRepository<BranchModel>().Add(branch);
                        return uow.SaveChanges() > 0 ? Ok(branch) : StatusCode(424, "Beklenmeyen hata gerçekleşti.");
                    }
                    return Conflict("Branş daha önceden bulunmaktadır.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region BranchList
        /// <summary>
        /// Branşları Listeleyen metod
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        [HttpGet("BranchList/{searchKey?}")]
        public IActionResult BranchList(string searchKey)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");

                using (UnitOfWork uow = new UnitOfWork())
                {
                    var branchModel = searchKey != null
                        ? uow.GetRepository<BranchModel>().GetAll(x => x.BranchName.ToLower().StartsWith(searchKey.ToLower())).ToList()
                        : uow.GetRepository<BranchModel>().GetAll().ToList();
                    return Ok(branchModel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        #endregion
        #region Remove Branch
        /// <summary>
        /// Branş Silme Metodu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("RemoveBranch/{id}")]
        public IActionResult RemoveBranch(int id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var branchModel = uow.GetRepository<BranchModel>();

                    branchModel.Delete(branchModel.Get(x => x.Id.Equals(id)));

                    return uow.SaveChanges() > 0
                        ? Ok("Branş başarı ile silindi.")
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

        #region Edit Branch
        /// <summary>
        /// Branş Düzenleme Metodu
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        [HttpPut("EditBranch")]
        public IActionResult EditSchool(BranchModel branch)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("İstek geçerli değil.");
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var branchModel = uow.GetRepository<BranchModel>();
                    var branchControl = branchModel.GetAll(x => x.Id.Equals(branch.Id));

                    if (branchControl != null) uow.GetRepository<BranchModel>().Update(branch);

                    return uow.SaveChanges() > 0 ? Ok(branch) : StatusCode(424, "Beklenmeyen bir hata oluştu.");
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
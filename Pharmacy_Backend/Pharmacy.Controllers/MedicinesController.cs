using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pharmacy.Logic;
using System;
using System.Collections.Generic;
using System.Net;
using static Pharmacy.Api.MedicinesServiceContract;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController: ControllerBase
    {
        /// <summary>
        /// Controller method used for fetching either the list of medicines or perticular medicine
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        [HttpGet("GetMedicineList")]
        public ActionResult<GetMedicineResponse> GetMedicineList(string fullName)
        {
            try
            {
                return MedicinesLogic.GetMedicineList(new GetMedicineRequest() {FullName = fullName });
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Controller method used for Adding a new medicine
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddMedicine")]
        public ActionResult<AddMedicineResponse> AddMedicine(AddMedicineRequest request)
        {
            try
            {
                return MedicinesLogic.AddMedicine(request);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Controller method used for deleting a medicine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteMedicine/{id:int}")]
        public ActionResult<DeleteMedicineResponse> DeleteMedicine(int id)
        {
            try
            {
                return MedicinesLogic.DeleteMedicine(new DeleteMedicineRequest() { id = id });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}

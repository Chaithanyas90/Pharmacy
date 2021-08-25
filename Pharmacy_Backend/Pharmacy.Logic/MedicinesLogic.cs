using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pharmacy.Common;
using Pharmacy.Common.Helpers;
using Pharmacy.Dal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Pharmacy.Api.Common.ResponseResult;
using static Pharmacy.Api.MedicinesServiceContract;

namespace Pharmacy.Logic
{
    public class MedicinesLogic
    {
        /// <summary>
        /// Method used ot Get either the list or perticular medicine
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List of medicines</returns>
        public static GetMedicineResponse GetMedicineList(GetMedicineRequest request)
        {
            try
            {
                var _jsonData = File.ReadAllText("Medicines.json");
                JObject _parsedJsonData = JObject.Parse(_jsonData);
                List<Medicine> _listInfo = JsonConvert.DeserializeObject<List<Medicine>>(_parsedJsonData["ListInfo"].ToString());

                if (request.FullName != null)
                {
                    _listInfo = _listInfo.Where(medicine => medicine.FullName.ToLower() == request.FullName.ToLower()).ToList();
                }

                return new GetMedicineResponse
                {
                    ListInfo = _listInfo,
                    ResponseResult = ResponseResultEnum.Success.ToString(),
                    ResponseMsg = $"{_listInfo.Count} Record/s found"

                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<GetMedicineResponse>(request, ex);
            }
        }

        /// <summary>
        /// Method used to add or update the medicine
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List of medicines</returns>
        public static AddMedicineResponse AddMedicine(AddMedicineRequest request)
        {
            try
            {
                var _jsonData = File.ReadAllText("Medicines.json");
                JObject _parsedJsonData = JObject.Parse(_jsonData);
                JArray _listInfo = _parsedJsonData.GetValue("ListInfo") as JArray;
                string _medicine = String.Empty;
                bool isMedicineUpdated = false;

                foreach (var medicine in _listInfo.Where(med => med["FullName"].Value<string>().ToLower() == request.FullName.ToLower() && med["Brand"].Value<string>().ToLower() == request.Brand.ToLower()))
                {
                    if (DateTime.Parse(medicine["ExpiryDate"].Value<string>()).Date.ToString("MM/dd/yyyy") == request.ExpiryDate.Date.ToString("MM/dd/yyyy"))
                    {
                        medicine["Quantity"] = medicine["Quantity"].Value<int>() + request.Quantity;
                        isMedicineUpdated = true;
                    }
                }

                if (!isMedicineUpdated)
                {
                    _medicine = "{'Id':" + _listInfo.Count + ",'FullName':'" + request.FullName + "','Brand':'" + request.Brand + "','Price' :" + request.Price + ",'Quantity' :" + request.Quantity + ",'ExpiryDate':'" + request.ExpiryDate + "','Notes' :'" + request.Notes + "'}";
                    _listInfo.Add(JObject.Parse(_medicine));
                }

                _parsedJsonData["ListInfo"] = _listInfo;
                string _updatedJson = JsonConvert.SerializeObject(_parsedJsonData, Formatting.Indented);
                File.WriteAllText("Medicines.json", _updatedJson);
                List<Medicine> deserialize = JsonConvert.DeserializeObject<List<Medicine>>(JsonConvert.SerializeObject(_listInfo));

                return new AddMedicineResponse
                {
                    ListInfo = deserialize,
                    ResponseResult = ResponseResultEnum.Success.ToString(),
                    ResponseMsg = $"{_listInfo.Count} Record/s found"

                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<AddMedicineResponse>(request, ex);
            }
        }

        /// <summary>
        /// Method used to delete the medicines
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns list of medicines</returns>
        public static DeleteMedicineResponse DeleteMedicine(DeleteMedicineRequest request)
        {
            try
            {
                var _jsonData = File.ReadAllText("Medicines.json");
                JObject _parsedJsonData = JObject.Parse(_jsonData);
                JArray _listInfo = (JArray)_parsedJsonData["ListInfo"];

                if (request.id < 0)
                {
                    throw new Exception("Invalid medicine id");
                }

                var medicineToDelete = _listInfo.FirstOrDefault(medicine => medicine["Id"].Value<int>() == request.id);

                if (medicineToDelete == null)
                {
                    return new DeleteMedicineResponse
                    {
                        ResponseResult = ResponseResultEnum.Warning.ToString(),
                        ResponseMsg = "No medicine Found with id (" + request.id + ")"
                    };
                }

                _listInfo.Remove(medicineToDelete);
                string output = JsonConvert.SerializeObject(_parsedJsonData, Formatting.Indented);
                File.WriteAllText("Medicines.json", output);
                List<Medicine> deserialize = JsonConvert.DeserializeObject<List<Medicine>>(JsonConvert.SerializeObject(_listInfo));
                return new DeleteMedicineResponse
                {
                    ListInfo = deserialize,
                    ResponseResult = ResponseResultEnum.Success.ToString(),
                    ResponseMsg = $"{deserialize.Count} Record/s found"

                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<DeleteMedicineResponse>(request, ex);
            }
        }
    }
}

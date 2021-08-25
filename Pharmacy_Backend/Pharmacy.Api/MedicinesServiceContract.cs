using Pharmacy.Api.Common;
using Pharmacy.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Api
{
    public class MedicinesServiceContract
    {
        public class GetMedicineRequest : RequestBase
        {
            public string FullName { get; set; }
        }
        public class GetMedicineResponse : ResponseBase
        {
            public List<Medicine> ListInfo { get; set; }
        }

        public class AddMedicineRequest : RequestBase
        {
            public string FullName { get; set; }
            public string Brand { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
            public DateTime ExpiryDate { get; set; }
            public string Notes { get; set; }
        }
        public class AddMedicineResponse : ResponseBase
        {
            public List<Medicine> ListInfo { get; set; }
        }

        public class DeleteMedicineRequest : RequestBase
        {
            public int id { get; set; }
        }
        public class DeleteMedicineResponse : ResponseBase
        {
            public List<Medicine> ListInfo { get; set; }
        }
    }
}

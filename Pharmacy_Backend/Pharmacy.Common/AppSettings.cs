using Microsoft.Extensions.Configuration;
using System;

namespace Pharmacy.Common
{
    public class AppSettings
    {
        public enum DbTypeEnum
        {
            PharmacyDb
        }

        public static IConfiguration Configuration { get; set; }

        public static string DbConnection(DbTypeEnum Database)
        {
            switch (Database)
            {
                case DbTypeEnum.PharmacyDb:
                    return Configuration.GetConnectionString(Database.ToString());

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

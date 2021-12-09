
   
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibraries
{
    public class CsvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"F:\TPL\ThirdPartyLibraries\ThirdPartyLibraries\ThirdPartyLibraries\addresses.CSV";
            string exportFilePath = @"F:\TPL\ThirdPartyLibraries\ThirdPartyLibraries\ThirdPartyLibraries\export.CSV";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine(addressData.FirstName + "\t" + addressData.LastName + "\t" + addressData.Address + "\t" + addressData.City + "\t" + addressData.State + "\t" + addressData.Code + "\n");
                }
                Console.WriteLine("\n############  Now reading from csv file and write to csv file  ##############");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}

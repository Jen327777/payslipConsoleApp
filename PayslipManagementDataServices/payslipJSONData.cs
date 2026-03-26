//using payslipLibrary;
//using System;
//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Security.Principal;
//using System.Text;
//using System.Text.Json;

//namespace PayslipManagementDataServices
//{
//    public class payslipJSONData
//    {
//        private List<Employee> payslipRec = new List<Employee>();

//        private string _jsonFileName;

//        public payslipJSONData()
//        {
//            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Employee.json";
//            PopulateJsonFile();
//        }

//        private void PopulateJsonFile()
//        {
//            RetrieveDataFromJsonFile();

//            if(payslipRec.Count<= 0)
//            {
//                payslipRec.Add(new Employee 
//                { employeeName = "Jennifer Nicole Villareal", employeeNumber ="123456", shift = "9 hours shift", netSalary = 25000 });

//                SaveDataToJsonFile();
//            }


//        }
//        private void SaveDataToJsonFile()
//        {
//            string jsonString = JsonSerializer.Serialize(payslipRec, new JsonSerializerOptions { WriteIndented = true });
//            File.WriteAllText(_jsonFileName, jsonString);
//        }



//        //private void RetrieveDataFromJsonFile()
//        //{
//            //using (var jsonFileReader = File.OpenText(_jsonFileName))
//            //{
//            //    payslipRec = JsonSerializer.Deserialize<List<Employee>>
//            //        (jsonFileReader.ReadToEnd());

//            //}



//            private void RetrieveDataFromJsonFile()
//        {
//            if (!File.Exists(_jsonFileName))
//            {
//                payslipRec = new List<Employee>();
//                SaveDataToJsonFile();
//                return;
//            }

//            var json = File.ReadAllText(_jsonFileName).Trim();

//            if (string.IsNullOrWhiteSpace(json))
//            {
//                payslipRec = new List<Employee>();
//                SaveDataToJsonFile();
//                return;
//            }

//            // Quick sanity check: we expect an array in the file
//            if (!json.StartsWith("["))
//            {
//                // file likely corrupted or in wrong format — recreate with an empty list
//                payslipRec = new List<Employee>();
//                SaveDataToJsonFile();
//                return;
//            }

//            try
//            {
//                payslipRec = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
//            }
//            catch (JsonException)
//            {
//                // Corrupt JSON: recreate the file with an empty list (or choose another recovery)
//                payslipRec = new List<Employee>();
//                SaveDataToJsonFile();
//            }



//    }



//        }
//    }

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using payslipLibrary;

namespace PayslipManagementDataServices
{
    public class payslipJSONData
    {
        private readonly string _jsonFileName;
        public List<Employee> EmployeeList { get; private set; }

        public payslipJSONData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Employee.json";
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(_jsonFileName))
            {
                EmployeeList = new List<Employee>();
                SaveData();
                return;
            }

            string json = File.ReadAllText(_jsonFileName).Trim();

            if (string.IsNullOrWhiteSpace(json) || !json.StartsWith("["))
            {
                EmployeeList = new List<Employee>();
                SaveData();
                return;
            }

            try
            {
                EmployeeList = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
            }
            catch
            {
                EmployeeList = new List<Employee>();
                SaveData();
            }
        }

        public void SaveData()
        {
            string jsonString = JsonSerializer.Serialize(EmployeeList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFileName, jsonString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using payslipLibrary;

namespace PayslipManagementDataServices
{
    public class payslipJSONData
    {
        private string _jsonFileName;
        public List<Employee> EmployeeList { get; private set; }

        public payslipJSONData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Employee.json";
            LoadData();
        }

        public void LoadData()
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
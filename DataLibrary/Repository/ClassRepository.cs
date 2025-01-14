﻿using DataLibrary.DataAccessLayer;
using DataLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLibrary.Repository
{
    public class ClassRepository : IClassRepository
    {
        private IDataAccess _dataAccess;
        public ClassRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<ClassDTO> ClassList()
        {
            List<ClassDTO> list = new List<ClassDTO>();
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            DataTable dataTable = _dataAccess.PopulateDataTableViaStoredProcedure("spClassList", paramDictionary);
            return ConvertDataTableToDTOList(dataTable);
        }
        public ClassDTO ReadClass(string name)
        {
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("ClassName", name);
            DataTable dataTable = _dataAccess.PopulateDataTableViaStoredProcedure("spReadClass", paramDictionary);
            return ConvertDataTableToDTO(dataTable);
        }
        public ClassDTO AddClass(ClassDTO addClass)
        {

            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("ClassName", addClass.ClassName);
            paramDictionary.Add("ClassStartDate", addClass.ClassStartDate);
            paramDictionary.Add("ClassEndDate", addClass.ClassEndDate);
            paramDictionary.Add("ClassStartTime", addClass.ClassStartTime);
            paramDictionary.Add("ClassEndTime", addClass.ClassEndTime);
            paramDictionary.Add("ClassInformation", addClass.ClassInformation);
            paramDictionary.Add("ClassHost", addClass.ClassHost);
            paramDictionary.Add("ClassAddress", addClass.ClassAddress);
            DataTable dataTable = _dataAccess.PopulateDataTableViaStoredProcedure("spCreateClass", paramDictionary);
            return ConvertDataTableToDTO(dataTable);
        }
        public ClassDTO UpdateClass(ClassDTO updateClass)
        {
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("ClassName", updateClass.ClassName);
            paramDictionary.Add("ClassStartDate", updateClass.ClassStartDate);
            paramDictionary.Add("ClassEndDate", updateClass.ClassEndDate);
            paramDictionary.Add("ClassStartTime", updateClass.ClassStartTime);
            paramDictionary.Add("ClassEndTime", updateClass.ClassEndTime);
            paramDictionary.Add("ClassInformation", updateClass.ClassInformation);
            paramDictionary.Add("ClassHost", updateClass.ClassHost);
            paramDictionary.Add("ClassAddress", updateClass.ClassAddress);
            DataTable dataTable = _dataAccess.PopulateDataTableViaStoredProcedure("spUpdateClass", paramDictionary);
            return ConvertDataTableToDTO(dataTable);
        }
        public int DeleteClass(string className)
        {
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("ClassName", className);
            return Convert.ToInt32(_dataAccess.DeleteDataViaStoredProcedure("spDeleteClass", paramDictionary));
        }
        public string RegisterForClass(string className, string MSId)
        {
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("ClassName", className);
            paramDictionary.Add("MSId", MSId);
            object result = _dataAccess.UpdateDataViaStoredProcedure("spRegisterForClass", paramDictionary);
            return className;
        }
        public ClassDTO ConvertDataTableToDTO(DataTable dataTable)
        {
            ClassDTO classDTO = new ClassDTO();
            foreach (DataRow row in dataTable.Rows)
            {
                classDTO.ClassId = Convert.ToInt32(row["ClassId"]);
                classDTO.ClassName = row["ClassName"].ToString();
                classDTO.ClassStartDate = row["ClassStartDate"].ToString();
                classDTO.ClassEndDate = row["ClassEndDate"].ToString();
                classDTO.ClassStartTime = row["ClassStartTime"].ToString();
                classDTO.ClassEndTime = row["ClassEndTime"].ToString();
                classDTO.ClassInformation = row["ClassInformation"].ToString();
                classDTO.ClassHost = row["ClassHost"].ToString();
                classDTO.ClassAddress = row["ClassAddress"].ToString();
            }
            return classDTO;
        }
        public List<ClassDTO> ConvertDataTableToDTOList(DataTable dataTable)
        {
            List<ClassDTO> list = new List<ClassDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                ClassDTO classDTO = new ClassDTO();
                classDTO.ClassId = Convert.ToInt32(row["Id"]);
                classDTO.ClassName = row["ClassName"].ToString();
                classDTO.ClassStartDate = row["ClassStartDate"].ToString();
                classDTO.ClassEndDate = row["ClassEndDate"].ToString();
                classDTO.ClassStartTime = row["ClassStartTime"].ToString();
                classDTO.ClassEndTime = row["ClassEndTime"].ToString();
                classDTO.ClassInformation = row["ClassInformation"].ToString();
                classDTO.ClassHost = row["ClassHost"].ToString();
                classDTO.ClassAddress = row["ClassAddress"].ToString();
                list.Add(classDTO);
            }
            return list;
        }
    }
}

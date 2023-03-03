using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Collections;
using System.Configuration;

namespace Igor.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }

        public List<Company> getListOfCompanies() { 
            //gets a list of companies
            List<Company> companyList = null;

            try
            {
                string connstring = ConfigurationManager.ConnectionStrings["SQL_igor"].ToString();
                using (SqlConnection conn = new SqlConnection(connstring)) {
                    var cmd = new SqlCommand(@"select Id, co_code, co_name from dbo.Company;", conn);
                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            companyList = new List<Company>();
                            while (d.Read()) {
                                var c = new Company() { 
                                    Id = int.Parse(d["Id"].ToString()),
                                    CompanyCode = d["co_code"].ToString(),
                                    CompanyName = d["co_name"].ToString()
                                };

                                companyList.Add(c);
                            }

                            return companyList.ToList<Company>();
                        }
                        else { return companyList; }
                    }
                }
            }
            catch { return companyList; }
        }

    }
}

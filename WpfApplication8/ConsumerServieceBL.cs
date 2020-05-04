using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplication8
{
    class ConsumerServieceBL
    {
        ConsumerModel model = new ConsumerModel();
        public Database1Entities1 InsertClient(string companyName, string companyCountry, string priority, string[]ret , string note, string status,Database1Entities1 db1)
        {
            Company c = db1.Company.Add(new Company { compnay_name = companyName, company_country = companyCountry });
            Factory_Occupation fc = db1.Factory_Occupation.Add(new Factory_Occupation {factory_occupation_name = ChangeToString(ret)});
            db1.Clients.Add(new Clients {Buissnes_Priority = priority, Note = note, Deleted = status, Company = c, Factory_Occupation = fc });
            return db1;
        }

        public Database1Entities1 UpdateClient(string companyName, string companyCountry, string priority, string[] ret, string note, string status, Clients updateclient, Database1Entities1 db)
        {
            updateclient.Company.compnay_name = companyName;
            updateclient.Company.company_country = companyCountry;
            updateclient.Buissnes_Priority = priority;
            updateclient.Factory_Occupation.factory_occupation_name = ChangeToString(ret);
            updateclient.Note = note;
            updateclient.Deleted = status;
            db.Entry(updateclient).State = System.Data.Entity.EntityState.Modified;
            return db;
        }

        public bool CheckChanges(string companyName, string companyCountry, string priority, string[] ret, string note, string status)
        {
            bool flag = model.IsValidate(companyName, companyCountry, priority, ChangeToString(ret), note, status);
            return flag;
        }

        public string[] CheckBoxChecking(bool[]arr1, string[]arr2)
        {
            string[] ret = new string[arr1.Length];
            int k = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if(arr1[i]==true)
                {
                    ret[k] = arr2[i];
                    k++;
                }
            }
            return ret;
        }

        public int Account(string[]arr1, string[]arr2)
        {
            int counter = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if(arr1[i] == "Symplex Mask" && arr2[i]=="180")
                    counter++;
                if(arr1[i] == "Symplex Mask" && arr2[i] == "360")
                    counter += 2;
                if(arr1[i] == "Symplex Mask" && arr2[i]=="540")
                    counter += 3;
                if (arr1[i] == "Panorama Mask" && arr2[i] == "200")
                    counter++;
                if (arr1[i] == "Panorama Mask" && arr2[i] == "400")
                    counter += 2;
                if (arr1[i] == "Panorama Mask" && arr2[i] == "600")
                    counter += 3;
                if (arr1[i] == "Half Face Mask" && arr2[i] == "60")
                    counter++;
                if (arr1[i] == "Half Face Mask" && arr2[i] == "120")
                    counter += 2;
                if (arr1[i] == "Half Face Mask" && arr2[i] == "180")
                    counter += 3;
                if (arr1[i] == "M-15 Military Mask" && arr2[i] == "230")
                    counter++;
                if (arr1[i] == "M-15 Military Mask" && arr2[i] == "460")
                    counter += 2;
                if (arr1[i] == "M-15 Military Mask" && arr2[i] == "690")
                    counter += 3;
                if (arr1[i] == "Civilian NBC Blower" && arr2[i] == "250")
                    counter++;
                if (arr1[i] == "Civilian NBC Blower" && arr2[i] == "500")
                    counter += 2;
                if (arr1[i] == "Civilian NBC Blower" && arr2[i] == "750")
                    counter += 3;
                if (arr1[i] == "Personal NBC Filter" && arr2[i] == "30")
                    counter++;
                if (arr1[i] == "Personal NBC Filter" && arr2[i] == "60")
                    counter += 2;
                if (arr1[i] == "Personal NBC Filter" && arr2[i] == "90")
                    counter += 3;
                if (arr1[i] == "Industrial Personal Filter" && arr2[i] == "15")
                    counter++;
                if (arr1[i] == "Industrial Personal Filter" && arr2[i] == "30")
                    counter += 2;
                if (arr1[i] == "Industrial Personal Filter" && arr2[i] == "45")
                    counter += 3;
                if (arr1[i] == "Atropine Huto Injector" && arr2[i] == "30")
                    counter++;
                if (arr1[i] == "Atropine Huto Injector" && arr2[i] == "60")
                    counter += 2;
                if (arr1[i] == "Atropine Huto Injector" && arr2[i] == "90")
                    counter += 3;
                if (arr1[i] == "Collective Filters" && arr2[i] == "10000")
                    counter++;
                if (arr1[i] == "Collective Filters" && arr2[i] == "20000")
                    counter += 2;
                if (arr1[i] == "Collective Filters" && arr2[i] == "30000")
                    counter += 3;
            }
            return counter;
        }

        public string ChangeToString(string[]arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + "  ";
            }
            return str;
        }
    }
}

using ContactBook.Configurations;
using static ContactBook.DTOs.ContactDTO;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Repository
{
  
    public class ContactRepository
    {
        public string Create(ContactCreateDTO contact)
        {
            using (IDbConnection cn = new SqlConnection(GlobalSettings.ConStr))
            {
                try
                {
                    string commandText = "ContactInsert";
                    cn.Execute(commandText, contact, commandType: CommandType.StoredProcedure);
                    return "success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public string Update(ContactUpdateDTO contact)
        {
            using (IDbConnection cn = new SqlConnection(GlobalSettings.ConStr))
            {
                try
                {
                    string commandText = "ContactUpdate";
                    cn.Execute(commandText, contact, commandType: CommandType.StoredProcedure);
                    return "success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public string Delete(ContactDeleteDTO contactToDelete)
        {
            using (IDbConnection cn = new SqlConnection(GlobalSettings.ConStr))
            {
                try
                {
                    string commandText = "ContactDelete";
                    cn.Execute(commandText, contactToDelete, commandType: CommandType.StoredProcedure);
                    return "success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public IEnumerable<ContactsDTO> GetAll()
        {
            try
            {
                using (IDbConnection cn = new SqlConnection(GlobalSettings.ConStr))
                {
                    string cmd = "ContactSelect";
                    return cn.Query<ContactsDTO>(cmd, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ContactsDTO Get(int id)
        {
            // return GetCarts().FirstOrDefault(e => e.CartNo.Equals(cartNo));
            try
            {
                using (IDbConnection cn = new SqlConnection(GlobalSettings.ConStr))
                {
                    DynamicParameters dynamicParameters = new();
                    dynamicParameters.Add("@Id", id);
                    string cmd = "ContactSelectById";
                    return cn.Query<ContactsDTO>(cmd, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

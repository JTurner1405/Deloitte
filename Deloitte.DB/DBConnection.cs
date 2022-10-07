using Dapper;
using DapperExtensions;
using Deloitte.Models.DB_Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Slapper.AutoMapper;

namespace Deloitte.DB
{
    public class DBConnection : IDBConnection
    {

        public List<Cities> GetAllCities()
        {
            try
            {
                using (var connection = new SqlConnection(Configuration.GetConnectionString()))
                {
                    connection.Open();

                    var list = connection.Query<Cities>(@"SELECT [Id],[Name],[State],[Country],[TouristRating]
      ,[DateEstablished],[EstimatePopulation],[TwoDigitCountryCode],[ThreeDigitCountryCode],[CurrencyCode]
  FROM [Cities]");

                    return list.ToList();
                }
            }
            catch(Exception ex)
            {
                var v1 = ex.Message;
                return new List<Cities>();
            }
        }

        public Cities? GetCities(int id)
        {
            try
            {
                using (var connection = new SqlConnection(Configuration.GetConnectionString()))
                {
                    connection.Open();
                    var sql = @"SELECT [Id],[Name],[State],[Country],[TouristRating]
      ,[DateEstablished],[EstimatePopulation],[TwoDigitCountryCode],[ThreeDigitCountryCode],[CurrencyCode]
  FROM [Cities] WHERE Id = @Id";
                    var city = connection.Query<Cities>(sql, new { Id = id }).FirstOrDefault();

                    return city;
                }
            }
            catch(Exception ex)
            {
                var v1 = ex.Message;
                return null;
            }
        }

        public Cities? GetCities(string name)
        {
            try
            {
                using (var connection = new SqlConnection(Configuration.GetConnectionString()))
                {
                    connection.Open();
                    var sql = @"SELECT [Id],[Name],[State],[Country],[TouristRating]
      ,[DateEstablished],[EstimatePopulation],[TwoDigitCountryCode],[ThreeDigitCountryCode],[CurrencyCode]
  FROM [Cities] WHERE Name = @Name";
                    var city = connection.Query<Cities>(sql, new { Name = name }).FirstOrDefault();

                    return city;
                }
            }
            catch (Exception ex)
            {
                var v1 = ex.Message;
                return null;
            }
        }

        public bool RemoveCity(int id)
        {
            try
            {
                using (var connection = new SqlConnection(Configuration.GetConnectionString()))
                {
                    connection.Open();
                    var sql = @"DELETE FROM [dbo].[Cities]
      WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
            }
            catch(Exception ex)
            {
                var v1 = ex.Message;
                return false;
            }

            return true;
        }

        public bool UpdateCity(Cities city)
        {
            try
            {
                using (var connection = new SqlConnection(Configuration.GetConnectionString()))
                {
                    connection.Open();
                    var sql = @"UPDATE [dbo].[Cities]
   SET [Name] = @Name
      ,[State] = @State
      ,[Country] = @Country
      ,[TouristRating] = @TouristRating
      ,[DateEstablished] = @DateEstablished
      ,[EstimatePopulation] = @EstimatePopulation
      ,[TwoDigitCountryCode] = @TwoDigitCountryCode
      ,[ThreeDigitCountryCode] = @ThreeDigitCountryCode
      ,[CurrencyCode] = @CurrencyCode
WHERE Id = @Id";
                    var param = new
                    {
                        Id = city.Id,
                        Name = city.Name,
                        State = city.State,
                        Country = city.Country,
                        TouristRating = city.TouristRating,
                        DateEstablished = city.DateEstablished,
                        EstimatePopulation = city.EstimatePopulation,
                        TwoDigitCountryCode = city.TwoDigitCountryCode,
                        ThreeDigitCountryCode = city.ThreeDigitCountryCode,
                        CurrencyCode = city.CurrencyCode
                    };

                    connection.Query<Cities>(sql, param).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                var v1 = ex.Message;
                return false;
            }
            return true;
        }

        public Cities? CreateCity(Cities city)
        {
            try
            {
                using (var connection = new SqlConnection(Configuration.GetConnectionString()))
                {
                    connection.Open();

                    var sql = @"INSERT INTO [dbo].[Cities]
           ([Name]
           ,[State]
           ,[Country]
           ,[TouristRating]
           ,[DateEstablished]
           ,[EstimatePopulation]
           ,[TwoDigitCountryCode]
           ,[ThreeDigitCountryCode]
           ,[CurrencyCode])
     VALUES
    ( @Name
      ,@State
      ,@Country
      ,@TouristRating
      ,@DateEstablished
      ,@EstimatePopulation
      ,@TwoDigitCountryCode
      ,@ThreeDigitCountryCode
      ,@CurrencyCode)";
                    var param = new
                    {
                        Name = city.Name,
                        State = city.State,
                        Country = city.Country,
                        TouristRating = city.TouristRating,
                        DateEstablished = city.DateEstablished,
                        EstimatePopulation = city.EstimatePopulation,
                        TwoDigitCountryCode = city.TwoDigitCountryCode,
                        ThreeDigitCountryCode = city.ThreeDigitCountryCode,
                        CurrencyCode = city.CurrencyCode
                    };

                    connection.Execute(sql, param);

                    return GetCities(city.Name);
                }
            }
            catch (Exception ex)
            {
                var v1 = ex.Message;
                return null;
            }
        }
    }
}


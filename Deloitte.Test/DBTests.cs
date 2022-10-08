using Dapper;
using Deloitte.DB;
using Deloitte.Models.DB_Models;
using System.Data.SqlClient;

namespace Deloitte.Test
{
    public class DBTests
    {
        private DBConnection conn;
        private int recordId;

        public DBTests()
        {
            conn = new DBConnection();
        }

        [SetUp]
        public void Setup()
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
                    Name = "City",
                    State = "state",
                    Country = "Country",
                    TouristRating = 1,
                    DateEstablished = DateTime.Now,
                    EstimatePopulation = "546725",
                    TwoDigitCountryCode = "34",
                    ThreeDigitCountryCode = "125",
                    CurrencyCode = "£"
                };

                var param2 = new
                {
                    Name = "City 2",
                    State = "state 3",
                    Country = "country 4",
                    TouristRating = 4,
                    DateEstablished = DateTime.UtcNow,
                    EstimatePopulation = "45634",
                    TwoDigitCountryCode = "54",
                    ThreeDigitCountryCode = "234",
                    CurrencyCode = "$"
                };

                var param3 = new
                {
                    Name = "City 3",
                    State = "state",
                    Country = "country",
                    TouristRating = 1,
                    DateEstablished = DateTime.Now.AddYears(-50),
                    EstimatePopulation = "12344",
                    TwoDigitCountryCode = "35",
                    ThreeDigitCountryCode = "123",
                    CurrencyCode = "&"
                };

                try
                {
                    connection.Execute(sql, param);
                    connection.Execute(sql, param2);
                    connection.Execute(sql, param3);

                    recordId = connection.Query<int>(@"SELECT top 1 [Id]
  FROM [Deloitte].[dbo].[Cities]").FirstOrDefault();
                }
                catch(Exception ex)
                {
                    var v1 = ex.Message;
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var connection = new SqlConnection(Configuration.GetConnectionString()))
            {
                connection.Open();

                var list = connection.Execute(@"DELETE FROM [dbo].[Cities]");
            }
        }

        [Test]
        public void GetAllCities()
        {
            var list = conn.GetAllCities();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Any());
            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        [TestCase(null, true)]
        [TestCase(-9, false)]
        public void GetSingleCity(int? cityId, bool succcessful)
        {
            var id = cityId ?? recordId;

            var city = conn.GetCities(id);

            if (succcessful)
            {
                Assert.IsNotNull(city);
            }
            else
            {
                Assert.IsNull(city);
            }                
        }

        [Test]
        public void CreateCity()
        {
            var city = conn.CreateCity(new Models.DB_Models.Cities()
            {
                Name = "lkadjs" + Guid.NewGuid(),
                State = "state",
                Country = "Country",
                TouristRating = 1,
                EstimatePopulation = "555",
                TwoDigitCountryCode = "df",
                ThreeDigitCountryCode = "ads",
                CurrencyCode = "$"
            });

            Assert.IsNotNull(city);
            Assert.IsTrue(city.Id > 0);
        }

        [Test]
        public void UpdateCity()
        {
            var city = conn.GetCities(recordId);
            city.Name = "UPdated name";
            city.State = "updated state";

            var success = conn.UpdateCity(city);
            Assert.IsTrue(success);
        }
    }
}
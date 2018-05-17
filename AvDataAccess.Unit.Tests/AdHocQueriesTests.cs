using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Xunit;
using AvEntities;

namespace AvDataAccess.Unit.Tests
{
    public class AdHocQueriesTests
    {

        [Fact]
        public virtual void Create_Returns_Query_List()
        {
            // arrange
            
            // act
            var queryCollection = AdHocQueries.Create();

            // assert
            Assert.NotEmpty(queryCollection.Queries);
        }

        [Fact]
        public virtual void Evaluate_Returns_Query_Results()
        {
            // arrange
            var query = new AdHocQuery
            {
                ConnectionString = "Data Source=lonbscadsqlbl01;Initial Catalog=CADIS_E2E01;Integrated Security=True",
                Sql = "select top 10 sec_id, sec_name from t_master_aam_sec"
            };

            // act
            //AvDataContext = 

            // assert

        }
    }
}

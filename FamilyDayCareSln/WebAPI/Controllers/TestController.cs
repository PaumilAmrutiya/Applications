using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Repository.FamilyDayCare.ClassLibrary;
using Repository.FamilyDayCare.DataAccessLayer;

namespace WebAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/test/GetAllUser/")]
        public IEnumerable<User> GetAllUser()
        {
            DataAccessLayer dal=new DataAccessLayer();
            List<User> userList = dal.GetAllUser();
            return userList;
        }
    }
}

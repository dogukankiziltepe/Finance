using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace Finance.Base.Base
{
    /// <summary>
    /// Tüm controller lar için genel olarak kullanılan methodların yer aldığı base controller class ı
    /// </summary>
    [Route("api/[controller]"), ApiController]

    public class BaseController : ControllerBase
    {
        public string UserId
        {
            get
            {
                try
                {
                    return User.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public string NullableUserId
        {
            get
            {
                try
                {
                    return User.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public string CompanyId
        {
            get
            {
                try
                {
                    return User.Claims.Single(claim => claim.Type == "CompanyId").Value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public string NullableCompanyId
        {
            get
            {
                try
                {
                    return User.Claims.Single(claim => claim.Type == "CompanyId").Value;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public string RoleName
        {
            get
            {
                try
                {
                    return User.Claims.Single(claim => claim.Type == ClaimTypes.Role).Value;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public string IP => HttpContext.Request.Headers.Keys.Any(x => x == "X-Forwarded-For") ?
                                HttpContext.Request.Headers["X-Forwarded-For"][0] :
                            HttpContext.Request.Headers.Keys.Any(x => x == "client_ip") ?
                                HttpContext.Request.Headers["client_ip"][0] :
                            HttpContext.Request.Headers.Keys.Any(x => x == "ClientRemoteIP") ?
                                HttpContext.Request.Headers["ClientRemoteIP"][0] : "";
        public string UserAgent => HttpContext.Request.Headers.Keys.Any(x => x == "User-Agent") ? HttpContext.Request.Headers["User-Agent"].ToString() : null;
    }
}
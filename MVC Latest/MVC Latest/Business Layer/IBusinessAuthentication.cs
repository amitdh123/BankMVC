using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IAuthentication
/// </summary>
public interface IBusinessAuthentication
{
    string IsValidUser(string uname, string pwd);
    bool RegisterUser(string uname, string password, string chkAcctNum);
    bool UpdatePassword(string uname, string oldpwd, string newpwd);
	
}
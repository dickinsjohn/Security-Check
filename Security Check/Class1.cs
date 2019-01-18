using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_Check
{
    public static class SecurityLNT
    {
        public static bool Security_Check()
        {
            string Domain = System.Environment.UserDomainName.ToString();

            if (Domain.ToUpper() == "ECC-WEB" || Domain.ToUpper() == "HQNET")
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(@"\\edrcdatacenter1\APP\CAD\DALicense.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    System.IO.StreamReader rd = new System.IO.StreamReader(fs);
                    string CHKFile = rd.ReadLine();

                    if (CHKFile != "050519742310198222021985")
                    {
                        MessageBox.Show("Sorry! You are not in L&T ECC Domain.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Unexpected Error! Try later.");
                    return false;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Could not authenticate your login identity! Try later.");
                return false;
            }
        }

    }
}

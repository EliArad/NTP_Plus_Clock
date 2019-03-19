using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSync;

namespace NTPServerApi
{
   public class NTPC
   {

      string m_server = "time.nist.gov";
      public NTPC(string server = "")
      {
         if (server != string.Empty)
            m_server = server;
      }
      public bool Get()
      {
         string TimeServer = m_server;

         NTPClient client;
         try
         {
            client = new NTPClient(TimeServer);
            client.Connect(true);
            return true;
         }
         catch (Exception e)
         {
             return false;
         }
      }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public partial class Subsriber
    {
        public string FullName
        {
            get
            {
                return Surname + " " + Name + " " + Patronumic;
            }
        }
        public string ListServices
        {
            get
            {
                List<ConectedService> services = ClassBase.entities.ConectedService.Where(x => x.ConnectedUser == ID).ToList();
                string strServices = "";
                for (int i = 0; i < services.Count; i++)
                {
                    if (i == services.Count - 1)
                    {
                        strServices = strServices + services[i].Service1.NameServices;
                    }
                    else
                    {
                        strServices = strServices + services[i].Service1.NameServices + ", ";
                    }
                }
                return strServices;
            }
            set
            {

            }
        }
        public string ConnectedServices
        {
            get
            {
                List<ConectedService> services = ClassBase.entities.ConectedService.Where(x => x.ConnectedUser == ID).ToList();
                string strServices = "";
                for (int i = 0; i < services.Count; i++)
                {
                    if (i == services.Count - 1)
                    {
                        if (services[i].DateConnected != null)
                        {

                            strServices = strServices + services[i].Service1.NameServices + " - " + Convert.ToDateTime(services[i].DateConnected).ToString("d");
                        }
                        else
                        {
                            strServices = strServices + services[i].Service1.NameServices;
                        }
                    }
                    else
                    {
                        if (services[i].DateConnected != null)
                        {
                            strServices = strServices + services[i].Service1.NameServices + " - " + Convert.ToDateTime(services[i].DateConnected).ToString("d") + ", ";
                        }
                        else
                        {
                            strServices = strServices + services[i].Service1.NameServices + ", ";
                        }

                    }
                }
                return strServices;
            }
            set
            {

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NewRobot2GJWinF
{
    class KDBAsynch
    {
        int IdTask;
        public string Code;
        public String Error;
        public Int32 IdCase;

        public KDBAsynch(int In_Task, string In_Code, String In_Error, Int32 In_Case)
        {
            this.Code = In_Code;
            this.Error = In_Error;
            this.IdTask = In_Task;
            this.IdCase = In_Case;
        }

        public void RunSolution()
        {
            if ((this.IdTask == 59682) && (this.Code == "891") && 
                (this.Error == "ValidationException: Error: Object reference not set to an instance of an object."))
            {
                this.Solution1();
            }
        }

        public void Solution1()
        {
            CapaSOA2GJ.CapaFacade2GJ objFac = new CapaSOA2GJ.CapaFacade2GJ();
            DataSet dts = objFac.QryFastByDS("SELECT WFC.idCase, WFC.radNumber, WFC.idWorkflow, WFC.idParentCase, WFCP.idcase, WFCP.radnumber, WFCP.idWorkflow, WFCP.idParentCase FROM WFCASE WFC INNER JOIN WFCASE WFCP ON WFC.idparentcase = WFCP.idcase WHERE WFC.idworkflow = 476 AND WFCP.idworkflow = 800 AND WFC.idcase = " + this.IdCase);

            //Carga informacion del caso de correspondencia y notificacion personal.
            DataTable dt = dts.Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow drw in dt.Rows)
                {

                }
            }
            
        }
    }
}

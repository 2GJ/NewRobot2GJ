using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace NewRobot2GJWinF
{
    public class KDBAsynch
    {
        public Int32 IdTask;
        public string Code;
        public String Error;
        public Int32 IdCase;
        public Boolean Retry;
        public String Log;

        public KDBAsynch(Int32 In_Task, string In_Code, String In_Error, Int32 In_Case)
        {
            this.Code = In_Code;
            this.Error = In_Error;
            this.IdTask = In_Task;
            this.IdCase = In_Case;
        }

        public void RunSolution()
        {
            this.Retry = false;
            this.Log = "";

            if ((this.IdTask == 59682) && (this.Code == "891") && 
                (this.Error == "ValidationException: Error: Object reference not set to an instance of an object."))
            {
                this.Solution1();
            }
        }

        public void Solution1()
        {
            bool bExisteCU = false;
            bool bExisteCI = false;

            Int64 IdCU = 0;
            Int64 IdCI = 0;

            this.Log += "-> Inicio Solucion 1.";

            //Se realiza consulta a BD para consultar si el caso efectivamente aplica a esta solucion...
            CapaSOA2GJ.CapaFacade2GJ objFac = new CapaSOA2GJ.CapaFacade2GJ();
            String tmp1 = "SELECT WFC.idCase, WFC.radNumber, WFC.idWorkflow, WFC.idParentCase, WFCP.idcase, WFCP.radnumber, WFCP.idWorkflow, WFCP.idParentCase, MPA.IdPA01_M_NotificPersonal, CATPA.idM_cat_ProcesosDeApoyo, T.idM_Tramite, CNOT.IdPA01_M_CiudadanoNotific, CNOT.Id_TipoDocumento, CNOT.SNumeroDocumento, CNOT.SPrimerNombre, CNOT.SPrimerApellido, CNOT.SSegundoNombre, CNOT.SSegundoApellido, CNOT.SDireccionDeResidencia, CNOT.IdP_Municipio FROM WFCASE WFC INNER JOIN (select wfc1.idcase, wfc1.radnumber, wfc1.idworkflow, wfc1.idparentcase from WFCASE wfc1 union select wfc2.idcase, wfc2.radnumber, wfc2.idworkflow, wfc2.idparentcase from WFCASECL wfc2) WFCP ON WFC.idparentcase = WFCP.idcase INNER JOIN (select pv1.idcase, pv1.M_Cat_ProcesosDeApoyo from PVApp pv1 union select pv2.idcase, pv2.M_Cat_ProcesosDeApoyo from PVCLApp pv2) PV on WFCP.idcase = PV.idcase INNER JOIN M_cat_ProcesosDeApoyo CATPA on PV.M_Cat_ProcesosDeApoyo = CATPA.idM_cat_ProcesosDeApoyo INNER JOIN PA01_M_NotificPersonal MPA on CATPA.IdM_PA01_NotificPersonal = MPA.IdPA01_M_NotificPersonal INNER JOIN PA01_M_CiudadanoNotific CNOT on MPA.IdM_CiudadanoANotificar = CNOT.IdPA01_M_CiudadanoNotific INNER JOIN M_Tramite T on CATPA.IdM_TRamite = T.idM_Tramite WHERE WFC.idworkflow = 476 AND WFCP.idworkflow = 800 AND WFC.idcase = " + this.IdCase;
            DataSet DS = objFac.QryFastByDS(tmp1);

            WFCASE objCase = new WFCASE();
            WFCASE objCaseP = new WFCASE();
            M_Tramite objTramite = new M_Tramite();
            M_PersonaNotificar objPN = new M_PersonaNotificar();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(DS.GetXml());

            XmlNode NodosDS = xmlDoc.SelectSingleNode("/NewDataSet");

            if (NodosDS.ChildNodes.Count > 0)
            {
                foreach (XmlNode NodoDS in NodosDS.ChildNodes)
                {
                    if (NodoDS.Name.ToString() == "NOMTABLA")
                    {
                        foreach (XmlNode ColDS in NodoDS.ChildNodes)
                        {
                            if (ColDS.Name.ToString() == "idCase")
                                objCase.IdCase = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "radNumber")
                                objCase.RadNumber = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "idWorkflow")
                                objCase.IdWorkFlow = Convert.ToInt16(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "idParentCase")
                                objCaseP.IdCase = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "radnumber1")
                                objCaseP.RadNumber = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "idWorkflow1")
                                objCaseP.IdWorkFlow = Convert.ToInt16(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "idM_Tramite")
                                objTramite.IdM_Tramite = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "Id_TipoDocumento")
                                objPN.IdTipoDocumento = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "SNumeroDocumento")
                                objPN.NumeroDocumento = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SPrimerNombre")
                                objPN.SPrimerNombre = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SPrimerApellido")
                                objPN.SPrimerApellido = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SSegundoNombre")
                                objPN.SSegundoNombre = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SSegundoApellido")
                                objPN.SSegundoApellido = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SDireccionDeResidencia")
                                objPN.SDireccionDeResidencia = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "IdP_Municipio")
                                objPN.IdMunicipio = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                        }
                    }
                }
                objCase.ParentCase = objCaseP;

                //Validar que la informacion del caso consultada esta completa.
                if ((objCase.IdCase != null && objCase.IdWorkFlow != null && objCase.ParentCase.IdCase != null && objCase.RadNumber != null && objPN.IdTipoDocumento != null && objPN.NumeroDocumento != null))
                {
                    this.Log += "-> Aplica Solucion 1.";

                    //Buscar en M_CiudadanoUnico
                    String tmp2 = "SELECT idM_CiudadanoUnico, IdP_TipoDocumento, SNumeroDocumento, SPrimerNombre, SPrimerApellido, SSegundoNombre, SSegundoApellido, SDireccionDeResidencia, IdP_MunicipioResidencia from M_CiudadanoUnico where IdP_TipoDocumento = " + objPN.IdTipoDocumento.ToString() + " and SNumeroDocumento = '" + objPN.NumeroDocumento.ToString() + "'";
                    DataSet DSCU = objFac.QryFastByDS(tmp2);

                    XmlDocument xmlDocCU = new XmlDocument();
                    xmlDocCU.LoadXml(DSCU.GetXml());

                    XmlNode NodosDSCU = xmlDocCU.SelectSingleNode("/NewDataSet");

                    if (NodosDSCU.ChildNodes.Count > 0)
                    {
                        this.Log += "-> Ciudadano Unico Existe.";
                        //SI EXISTE CIUDADANO UNICO
                        foreach (XmlNode NodoDSCU in NodosDSCU.ChildNodes)
                        {
                            if (NodosDSCU.Name.ToString() == "NOMTABLA")
                            {
                                foreach (XmlNode ColDS in NodoDSCU.ChildNodes)
                                {
                                    if (ColDS.Name.ToString() == "idM_CiudadanoUnico")
                                    {
                                        IdCU = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                                        this.Log += "-> Id Ciudadano Unico " + IdCU.ToString() + ".";
                                        bExisteCU = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bExisteCU = false;
                        this.Log += "-> Ciudadano Unico No Existe.";
                        String tmpSE1 = "<IdP_TipoDocumento>" + objPN.IdTipoDocumento.ToString() + "</IdP_TipoDocumento>";
                        tmpSE1 += "<SNumeroDocumento>" + objPN.NumeroDocumento.ToString() + "</SNumeroDocumento>";
                        tmpSE1 += "<SDireccionDeResidencia>" + objPN.SDireccionDeResidencia.ToString() + "</SDireccionDeResidencia>";
                        tmpSE1 += "<SDirCorrespondencia>" + objPN.SDireccionDeResidencia.ToString() + "</SDirCorrespondencia>";
                        tmpSE1 += "<SPrimerNombre>" + objPN.SPrimerNombre.ToString() + "</SPrimerNombre>";
                        tmpSE1 += "<SPrimerApellido>" + objPN.SPrimerApellido.ToString() + "</SPrimerApellido>";
                        if (objPN.SSegundoNombre != null)
                            tmpSE1 += "<SSegundoNombre>" + objPN.SSegundoNombre.ToString() + "</SSegundoNombre>";
                        if (objPN.SSegundoApellido != null)
                            tmpSE1 += "<SSegundoApellido>" + objPN.SSegundoApellido.ToString() + "</SSegundoApellido>";

                        CapaSOA2GJ.CapaSOA2GJ objCPSE = new CapaSOA2GJ.CapaSOA2GJ();
                        objCPSE.SetInXML(tmpSE1);
                        IdCU = objCPSE.InsertSaveEntity("M_CiudadanoUnico");
                        this.Log += "-> Se crea Ciudadano Unico " + IdCU.ToString() + ".";
                        if (IdCU > 0)
                            bExisteCU = true;
                    }

                    if (bExisteCU == true)
                    {
                        this.Log += "-> Inicia creacion Ciudadano.";
                        String tmpSE1 = "<IdP_TipoDocumento>" + objPN.IdTipoDocumento.ToString() + "</IdP_TipoDocumento>";
                        tmpSE1 += "<SNumeroDocumento>" + objPN.NumeroDocumento.ToString() + "</SNumeroDocumento>";
                        tmpSE1 += "<SDireccionDeResidencia>" + objPN.SDireccionDeResidencia.ToString() + "</SDireccionDeResidencia>";
                        tmpSE1 += "<SPrimerNombre>" + objPN.SPrimerNombre.ToString() + "</SPrimerNombre>";
                        tmpSE1 += "<SPrimerApellido>" + objPN.SPrimerApellido.ToString() + "</SPrimerApellido>";
                        if (objPN.SSegundoNombre != null)
                            tmpSE1 += "<SSegundoNombre>" + objPN.SSegundoNombre.ToString() + "</SSegundoNombre>";
                        if (objPN.SSegundoApellido != null)
                            tmpSE1 += "<SSegundoApellido>" + objPN.SSegundoApellido.ToString() + "</SSegundoApellido>";
                        tmpSE1 += "<IdM_CiudadanoUnico>" + IdCU + "</IdM_CiudadanoUnico>";

                        CapaSOA2GJ.CapaSOA2GJ objCPSE = new CapaSOA2GJ.CapaSOA2GJ();
                        objCPSE.SetInXML(tmpSE1);
                        IdCI = objCPSE.InsertSaveEntity("M_Ciudadano");
                        this.Log += "-> Se crea Ciudadano " + IdCI.ToString() + ".";
                        if (IdCI > 0)
                            bExisteCI = true;

                        if (bExisteCI == true)
                        {
                            string strSaveEntity = "";

                            this.Log += "-> Se actualiza tramite.";
                            strSaveEntity += "<BizAgiWSParam>";
                            strSaveEntity += "<Entities idCase=\"" + objCase.ParentCase.IdCase.ToString() + "\">";
                            strSaveEntity += "<M_cat_ProcesosDeApoyo><IdM_Tramite>";
                            strSaveEntity += "<IdM_Ciudadano>" + IdCI + "</IdM_Ciudadano>";
                            strSaveEntity += "</IdM_Tramite></M_cat_ProcesosDeApoyo>";
                            strSaveEntity += "</Entities>";
                            strSaveEntity += "</BizAgiWSParam>";

                            CapaSOA2GJ.CapaSOA2GJ objSEF = new CapaSOA2GJ.CapaSOA2GJ();
                            objSEF.SetInXML(strSaveEntity);
                            objSEF.SaveEntity();

                            this.Retry = true;
                        }
                    }
                    else
                    {
                        //Ciudadano unico no existe. (Respuesta Pendiente).
                        this.Retry = false;
                        this.Log += "-> Ciudadano unico no existe y no se puedo crear.";
                    }
                }
                else
                {
                    //Informacion del caso incompleta. (Respuesta Pendiente).
                    this.Retry = false;
                    this.Log += "-> Informacion del caso no esta completa.";
                }
            }
            else
            {
                //Caso no aplica el primer script. (Respuesta Pendiente).
                this.Retry = false;
                this.Log += "-> Caso no aplica para solucion 1.";
            }
        }
    }

    public class WFCASE
    {
        public Int32 IdCase;
        public String RadNumber;
        public Int16 IdWorkFlow;
        public WFCASE ParentCase;
    }

    public class M_Tramite
    {
        public Int32 IdM_Tramite;
    }

    public class M_PersonaNotificar
    {
        public Int32 IdTipoDocumento;
        public String NumeroDocumento;
        public String SPrimerNombre;
        public String SPrimerApellido;
        public String SSegundoNombre;
        public String SSegundoApellido;
        public Int32 IdMunicipio;
        public String SDireccionDeResidencia;
    }
}

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
        public Boolean GenUpdData;
        public String LogUpdData;

        public KDBAsynch(Int32 In_Task, string In_Code, String In_Error, Int32 In_Case)
        {
            this.Code = In_Code;
            this.Error = In_Error;
            this.IdTask = In_Task;
            this.IdCase = In_Case;
        }

        public KDBAsynch(Int32 In_Task, Int32 In_Case)
        {
            this.Code = null;
            this.Error = null;
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

                if (this.Retry == false)
                    this.Solution2();
            }

            if ((this.IdTask == 59330) && (this.Code == "891") &&
                (this.Error == "ValidationException: Verifique el nombre del destinatario, se esperaba un nombre superior a 4 caracteres"))
            {
                this.Solution3();
            }

            if ((this.IdTask == 64234) && (this.Code == "891") &&
                (this.Error == "ValidationException: Verifique la Dirección, se esperaba una dirección superior a 5 carcteres"))
            {
                this.ActualizacionData1();
            }

            if ((this.IdTask == 59330) && (this.Code == "891") &&
                (this.Error == "ValidationException: Verifique la Dirección, se esperaba una dirección superior a 5 carcteres"))
            {
                this.ActualizacionData2();
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

        public void Solution2()
        {
            bool bExisteCU = false;
            bool bExisteCI = false;

            Int64 IdCU = 0;
            Int64 IdCI = 0;

            this.Log += "-> Inicio Solucion 2.";

            //Se realiza consulta a BD para consultar si el caso efectivamente aplica a esta solucion...
            CapaSOA2GJ.CapaFacade2GJ objFac = new CapaSOA2GJ.CapaFacade2GJ();
            String tmp1 = "SELECT WFC.idCase, WFC.radNumber, WFC.idWorkflow, WFC.idParentCase, WFCP.idcase, WFCP.radnumber, WFCP.idWorkflow, WFCP.idParentCase, EC.IdTipoDocDestinatario, EC.SNumeroDocDestinatario, EC.SDireccionCorrespondenci, EC.SNombreDestinatario, EC.IdP_MunicipioDireccion, EC.STelefono, EC.STelefonoCelular FROM WFCASE WFC INNER JOIN (select wfc1.idcase, wfc1.radnumber, wfc1.idworkflow, wfc1.idparentcase from WFCASE wfc1 union select wfc2.idcase, wfc2.radnumber, wfc2.idworkflow, wfc2.idparentcase from WFCASECL wfc2) WFCP ON WFC.idparentcase = WFCP.idcase INNER JOIN (select pv1.idcase, pv1.M_Cat_Correspondencia from PVApp pv1 union select pv2.idcase, pv2.M_Cat_Correspondencia from PVCLApp pv2) PV on WFCP.idcase = PV.idcase INNER JOIN M_Cat_Correspondencia CAT on PV.M_Cat_Correspondencia = CAT.idM_Cat_Correspondencia INNER JOIN ECE_EnvioCorrespondencia EC on CAT.IdM_ECE_EnvioCorresponde = EC.idECE_EnvioCorrespondencia WHERE WFC.idworkflow = 476 AND WFCP.idworkflow = 234 AND WFC.idcase = " + this.IdCase;
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
                            //if (ColDS.Name.ToString() == "idM_Tramite")
                            //    objTramite.IdM_Tramite = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "IdTipoDocDestinatario")
                                objPN.IdTipoDocumento = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString() == "SNumeroDocDestinatario")
                                objPN.NumeroDocumento = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SNombreDestinatario")
                                objPN.SPrimerNombre = ColDS.LastChild.Value.ToString();
                            //if (ColDS.Name.ToString() == "SPrimerApellido")
                            //    objPN.SPrimerApellido = ColDS.LastChild.Value.ToString();
                            //if (ColDS.Name.ToString() == "SSegundoNombre")
                            //    objPN.SSegundoNombre = ColDS.LastChild.Value.ToString();
                            //if (ColDS.Name.ToString() == "SSegundoApellido")
                            //    objPN.SSegundoApellido = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString() == "SDireccionCorrespondenci")
                                objPN.SDireccionDeResidencia = ColDS.LastChild.Value.ToString();
                            //if (ColDS.Name.ToString() == "IdP_Municipio")
                            //    objPN.IdMunicipio = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                        }
                    }
                }
                objCase.ParentCase = objCaseP;

                //Validar que la informacion del caso consultada esta completa.
                if ((objCase.IdCase != null && objCase.IdWorkFlow != null && objCase.ParentCase.IdCase != null && objCase.RadNumber != null && objPN.IdTipoDocumento != null && objPN.NumeroDocumento != null))
                {
                    this.Log += "-> Aplica Solucion 2.";

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
                        if (objPN.SPrimerApellido != null)
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
                        if (objPN.SPrimerApellido != null)
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
                            strSaveEntity += "<Entities idCase=\"" + objCase.IdCase.ToString() + "\">";
                            strSaveEntity += "<M_Cat_Correspondencia><IdM_Tramite><IdM_Ciudadano>" + IdCI + "</IdM_Ciudadano></IdM_Tramite></M_Cat_Correspondencia>";
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
                this.Log += "-> Caso no aplica para solucion 2.";
            }
        }

        public void Solution3()
        {
            this.Retry = false;

            this.Log += "-> Inicio Solucion 3.";

            //M_cat_Reconocimiento.IdM_RC01Reconocimiento.IdM_DatosActividad.RC01_DtosAct_Notificar[IdP_TipoNotificante.SCodigo = '02']
            CapaSOA2GJ.CapaFacade2GJ objFac = new CapaSOA2GJ.CapaFacade2GJ();
            String tmp1 = "SELECT WFC.idcase, WFC.radnumber, WFC.IDWORKFLOW, CAT.IDM_CAT_RECONOCIMIENTO, RC.IDM_RC01_RECONOCIMIENTO, ACT.IDM_RC01_DATOSACTIVIDAD, PN.IDM_RC01_PERSONASNOTIFICAR, PN.IDP_TIPONOTIFICANTE, PN.IDP_TIPODOCUMENTO, PN.SNUMERODOCUMENTO, PN.SPRIMERNOMBRE, PN.SDIRECCION FROM WFCASE WFC INNER JOIN PVAPP PV ON WFC.IDCASE = PV.IDCASE INNER JOIN M_CAT_RECONOCIMIENTO CAT ON PV.M_CAT_RECONOCIMIENTO = CAT.IDM_CAT_RECONOCIMIENTO INNER JOIN M_RC01_RECONOCIMIENTO RC ON CAT.IDM_RC01RECONOCIMIENTO = RC.IDM_RC01_RECONOCIMIENTO INNER JOIN M_RC01_DatosActividad ACT ON RC.IDM_DATOSACTIVIDAD = ACT.IDM_RC01_DATOSACTIVIDAD INNER JOIN M_RC01_PersonasNotificar PN ON PN.RC01_DatosActividad = ACT.IDM_RC01_DATOSACTIVIDAD LEFT JOIN P_TipoNotificante P1 ON PN.IdP_TipoNotificante = P1.IDP_TIPONOTIFICANTE WHERE P1.SCODIGO = '02' AND LEN(SPrimerNombre) < 5 AND WFC.IDCASE = " + this.IdCase;
            DataSet DS = objFac.QryFastByDS(tmp1);


            WFCASE objCase = new WFCASE();
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
                            if (ColDS.Name.ToString().ToUpper() == "IDCASE")
                                objCase.IdCase = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "RADNUMBER")
                                objCase.RadNumber = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "IDWORKFLOW")
                                objCase.IdWorkFlow = Convert.ToInt16(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "IDM_RC01_PERSONASNOTIFICAR")
                                objPN.Id = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "IDM_RC01_PERSONASNOTIFICAR")
                                objPN.Id = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "IDP_TIPONOTIFICANTE")
                                objPN.IdTipoNotificante = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "IDP_TIPODOCUMENTO")
                                objPN.IdTipoDocumento = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "SNUMERODOCUMENTO")
                                objPN.NumeroDocumento = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "SPRIMERNOMBRE")
                                objPN.SPrimerNombre = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "SDIRECCION")
                                objPN.SDireccionDeResidencia = ColDS.LastChild.Value.ToString();
                        }
                    }
                }
            }

            //COPRAA NOMBRES PARA REALIZAR CAMBIO.
            //SENA - SERVICIO NACIONAL DE APRENDIZAJE
            if (objPN.SPrimerNombre.Trim() == "SENA")
            {
                this.Log += "-> Reporto SENA.";
                objPN.SPrimerNombre = "SERVICIO NACIONAL DE APRENDIZAJE";
                this.Retry = true;
            }
            //UGPP - UNIDAD GESTION PENSIONAL PARAFISCAL
            if (objPN.SPrimerNombre.Trim() == "UGPP")
            {
                this.Log += "-> Reporto UGPP.";
                objPN.SPrimerNombre = "UNIDAD GESTION PENSIONAL PARAFISCAL";
                this.Retry = true;
            }

            //CAR - CORPORACION AUTONOMA REGIONAL
            if (objPN.SPrimerNombre.Trim() == "CAR")
            {
                this.Log += "-> Reporto CAR.";
                objPN.SPrimerNombre = "CORPORACION AUTONOMA REGIONAL";
                this.Retry = true;
            }

            //DIAN - DIRECCION DE IMPUESTOS Y ADUANAS NACIONALES
            if (objPN.SPrimerNombre.Trim() == "DIAN")
            {
                this.Log += "-> Reporto DIAN.";
                objPN.SPrimerNombre = "DIRECCION DE IMPUESTOS Y ADUANAS NACIONALES";
                this.Retry = true;
            }

            //ICBF - INSTITUTO COLOMBIANO DE BIENESTAR FAMILIAR
            if (objPN.SPrimerNombre.Trim() == "ICBF")
            {
                this.Log += "-> Reporto ICBF.";
                objPN.SPrimerNombre = "INSTITUTO COLOMBIANO DE BIENESTAR FAMILIAR";
                this.Retry = true;
            }

            //ESAP - ESCUELA SUPERIOR DE ADMINISTRACION PUBLICA
            if (objPN.SPrimerNombre.Trim() == "ESAP")
            {
                this.Log += "-> Reporto ESAP.";
                objPN.SPrimerNombre = "ESCUELA SUPERIOR DE ADMINISTRACION PUBLICA";
                this.Retry = true;
            }

            //UIS - UNIVERSIDAD INDUSTRIAL DE SANTANDER
            if (objPN.SPrimerNombre.Trim() == "UIS")
            {
                this.Log += "-> Reporto UIS.";
                objPN.SPrimerNombre = "UNIVERSIDAD INDUSTRIAL DE SANTANDER";
                this.Retry = true;
            }

            //DANE - DEPARTAMENTO NACIONAL DE ESTADISTICA DANE
            if (objPN.SPrimerNombre.Trim() == "DANE")
            {
                this.Log += "-> Reporto DANE.";
                objPN.SPrimerNombre = "DEPARTAMENTO NACIONAL DE ESTADISTICA DANE";
                this.Retry = true;
            }

            //BBVA - BANCO BBVA
            if (objPN.SPrimerNombre.Trim() == "BBVA")
            {
                this.Log += "-> Reporto BBVA.";
                objPN.SPrimerNombre = "BANCO BBVA";
                this.Retry = true;
            }

            //DAFP - DEPARTAMENTO ADMINISTRATIVO DE LA FUNCION PUBLICA
            if (objPN.SPrimerNombre.Trim() == "DAFP")
            {
                this.Log += "-> Reporto DAFP.";
                objPN.SPrimerNombre = "DEPARTAMENTO ADMINISTRATIVO DE LA FUNCION PUBLICA";
                this.Retry = true;
            }

            //ETB - EMPRESA TELECOMUNICACIONES BOGOTA
            if (objPN.SPrimerNombre.Trim() == "ETB")
            {
                this.Log += "-> Reporto ETB.";
                objPN.SPrimerNombre = "EMPRESA TELECOMUNICACIONES BOGOTA";
                this.Retry = true;
            }

            //IIS - INSTITUTO DE SEGUROS SOCIALES
            if (objPN.SPrimerNombre.Trim() == "ISS")
            {
                this.Log += "-> Reporto ISS.";
                objPN.SPrimerNombre = "INSTITUTO DE SEGUROS SOCIALES";
                this.Retry = true;
            }


            if (this.Retry == true)
            {
                string strSaveEntity = "";

                this.Log += "-> Se actualiza notificante.";
                strSaveEntity += "<BizAgiWSParam>";
                strSaveEntity += "<Entities>";
                strSaveEntity += "<M_RC01_PersonasNotificar key=\"" + objPN.Id.ToString() + "\">";
                strSaveEntity += "<SPrimerNombre>" + objPN.SPrimerNombre.ToString() + "</SPrimerNombre>";
                strSaveEntity += "</M_RC01_PersonasNotificar>";
                strSaveEntity += "</Entities>";
                strSaveEntity += "</BizAgiWSParam>";

                CapaSOA2GJ.CapaSOA2GJ objSEF = new CapaSOA2GJ.CapaSOA2GJ();
                objSEF.SetInXML(strSaveEntity);
                objSEF.SaveEntity();
            }
            else
            {
                this.Log += "-> URGENTE REVISAR NOMBRE DESTINATARIO [" + objPN.SPrimerNombre.Trim() + "]";
            }
        }

        public void RunActualizacion(string[] StrArry)
        {
            String Lock1 = "";
            Int32 Id = 0;

            for (int i = 0; i < StrArry.Length; i++)
            {
                if (i == 3)
                    Lock1 += StrArry[i];
                if (i == 4)
                    Id += Convert.ToInt32(StrArry[i]);
            }

            if (Lock1 == ("A1" + this.IdCase.ToString() + this.IdTask.ToString() + Id.ToString() + "1A"))
            {
                this.A1(StrArry);
            }
            if (Lock1 == ("A2" + this.IdCase.ToString() + this.IdTask.ToString() + Id.ToString() + "2A"))
            {
                this.A2(StrArry);
            }

        }
        
        public void ActualizacionData1()
        {
            this.GenUpdData = false;

            this.Log += "-> Inicio Actualizacion 1.";

            CapaSOA2GJ.CapaFacade2GJ objFac = new CapaSOA2GJ.CapaFacade2GJ();
            String tmp1 = "SELECT WFC.IDCASE, WFC.RADNUMBER, RC.IDM_RC01_RECONOCIMIENTO, EVI.IDECE_ENVIOCORRESPONDENCIA, EVI.IDTIPODOCDESTINATARIO, EVI.SNUMERODOCDESTINATARIO, EVI.SNOMBREDESTINATARIO, EVI.SDIRECCIONCORRESPONDENCI FROM WFCASE WFC INNER JOIN PVApp PV on WFC.idcase = PV.idcase INNER JOIN M_Cat_Reconocimiento CAT on PV.M_Cat_Reconocimiento = CAT.idM_Cat_Reconocimiento INNER JOIN M_RC01_Reconocimiento RC on CAT.IdM_RC01Reconocimiento = RC.idM_RC01_Reconocimiento INNER JOIN ECE_EnvioCorrespondencia EVI on EVI.M_RC01_Reconocimiento = RC.idM_RC01_Reconocimiento WHERE WFC.idcase = " + this.IdCase;
            DataSet DS = objFac.QryFastByDS(tmp1);
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(DS.GetXml());

            XmlNode NodosDS = xmlDoc.SelectSingleNode("/NewDataSet");

            if (NodosDS.ChildNodes.Count > 0)
            {
                foreach (XmlNode NodoDS in NodosDS.ChildNodes)
                {
                    WFCASE objCase = new WFCASE();
                    M_PersonaNotificar objPN = new M_PersonaNotificar();

                    if (NodoDS.Name.ToString() == "NOMTABLA")
                    {
                        foreach (XmlNode ColDS in NodoDS.ChildNodes)
                        {
                            if (ColDS.Name.ToString().ToUpper() == "IDCASE")
                                objCase.IdCase = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "RADNUMBER")
                                objCase.RadNumber = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "IDECE_ENVIOCORRESPONDENCIA")
                                objPN.Id = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "IDTIPODOCDESTINATARIO")
                                objPN.IdTipoDocumento = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "SNUMERODOCDESTINATARIO")
                                objPN.NumeroDocumento = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "SNOMBREDESTINATARIO")
                                objPN.SPrimerNombre = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "SDIRECCIONCORRESPONDENCI")
                                objPN.SDireccionDeResidencia = ColDS.LastChild.Value.ToString();
                        }
                    }
                    if (objCase.IdCase > 0 && objCase.RadNumber != null && objPN.Id > 0)
                    {
                        objPN.SPrimerNombre = objPN.SPrimerNombre.Replace("\n", String.Empty);
                        objPN.SPrimerNombre = objPN.SPrimerNombre.Replace("\r", String.Empty);
                        objPN.SDireccionDeResidencia = objPN.SDireccionDeResidencia.Replace("\n", String.Empty);
                        objPN.SDireccionDeResidencia = objPN.SDireccionDeResidencia.Replace("\r", String.Empty);

                        this.LogUpdData += objCase.IdCase + "\t" + objCase.RadNumber + "\t" + this.IdTask + "\t" + "A1" + objCase.IdCase + this.IdTask + objPN.Id + "1A" + "\t" + objPN.Id + "\t" + objPN.IdTipoDocumento + "\t" + objPN.NumeroDocumento + "\t" + objPN.SPrimerNombre + "\t" + objPN.SDireccionDeResidencia + "\t" + "A1" + objCase.IdCase + this.IdTask + objPN.Id + "1A" + "\n";
                        this.GenUpdData = true;
                    }
                }
            }

            

        }

        public void ActualizacionData2()
        {
            this.GenUpdData = false;

            this.Log += "-> Inicio Actualizacion 2.";

            CapaSOA2GJ.CapaFacade2GJ objFac = new CapaSOA2GJ.CapaFacade2GJ();
            String tmp1 = "SELECT WFC.IDCASE, WFC.RADNUMBER, PN.IDM_RC01_PERSONASNOTIFICAR, PN.IDP_TIPODOCUMENTO, PN.SNUMERODOCUMENTO, PN.SPRIMERNOMBRE, PN.SDIRECCION FROM WFCASE WFC INNER JOIN PVApp PV on WFC.idcase = PV.idcase INNER JOIN M_Cat_Reconocimiento CAT on PV.M_Cat_Reconocimiento = CAT.idM_Cat_Reconocimiento INNER JOIN M_RC01_Reconocimiento RC on CAT.IdM_RC01Reconocimiento = RC.idM_RC01_Reconocimiento INNER JOIN M_RC01_DatosActividad DA on RC.IdM_DatosActividad = DA.IDM_RC01_DatosActividad INNER JOIN M_RC01_PersonasNotificar PN on PN.RC01_DATOSACTIVIDAD = DA.IDM_RC01_DatosActividad INNER JOIN P_TipoNotificante P1 ON PN.IdP_TipoNotificante = P1.IDP_TipoNotificante WHERE P1.SCODIGO = '02' AND WFC.IDCASE = " + this.IdCase;
            DataSet DS = objFac.QryFastByDS(tmp1);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(DS.GetXml());

            XmlNode NodosDS = xmlDoc.SelectSingleNode("/NewDataSet");

            if (NodosDS.ChildNodes.Count > 0)
            {
                foreach (XmlNode NodoDS in NodosDS.ChildNodes)
                {
                    WFCASE objCase = new WFCASE();
                    M_PersonaNotificar objPN = new M_PersonaNotificar();

                    if (NodoDS.Name.ToString() == "NOMTABLA")
                    {
                        foreach (XmlNode ColDS in NodoDS.ChildNodes)
                        {
                            if (ColDS.Name.ToString().ToUpper() == "IDCASE")
                                objCase.IdCase = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "RADNUMBER")
                                objCase.RadNumber = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "IDM_RC01_PERSONASNOTIFICAR")
                                objPN.Id = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "IDP_TIPODOCUMENTO")
                                objPN.IdTipoDocumento = Convert.ToInt32(ColDS.LastChild.Value.ToString());
                            if (ColDS.Name.ToString().ToUpper() == "SNUMERODOCUMENTO")
                                objPN.NumeroDocumento = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "SPRIMERNOMBRE")
                                objPN.SPrimerNombre = ColDS.LastChild.Value.ToString();
                            if (ColDS.Name.ToString().ToUpper() == "SDIRECCION")
                                objPN.SDireccionDeResidencia = ColDS.LastChild.Value.ToString();
                        }
                    }
                    if (objCase.IdCase > 0 && objCase.RadNumber != null && objPN.Id > 0)
                    {
                        objPN.SPrimerNombre = objPN.SPrimerNombre.Replace("\n", String.Empty);
                        objPN.SPrimerNombre = objPN.SPrimerNombre.Replace("\r", String.Empty);
                        objPN.SDireccionDeResidencia = objPN.SDireccionDeResidencia.Replace("\n", String.Empty);
                        objPN.SDireccionDeResidencia = objPN.SDireccionDeResidencia.Replace("\r", String.Empty);

                        this.LogUpdData += objCase.IdCase + "\t" + objCase.RadNumber + "\t" + this.IdTask + "\t" + "A2" + objCase.IdCase + this.IdTask + objPN.Id + "2A" + "\t" + objPN.Id + "\t" + objPN.IdTipoDocumento + "\t" + objPN.NumeroDocumento + "\t" + objPN.SPrimerNombre + "\t" + objPN.SDireccionDeResidencia + "\t" + "A2" + objCase.IdCase + this.IdTask + objPN.Id + "2A" + "\n";
                        this.GenUpdData = true;
                    }
                }
            }
        }

        public void A1(string[] StrArry)
        {
            M_PersonaNotificar objPN = new M_PersonaNotificar();

            this.Log += "A1" + "\t" + "IdTipoDocDestinatario ->" + StrArry[5] + "\t";
            this.Log += "Numero Documento ->" + StrArry[6] + "\t";
            this.Log += "Nombre ->" + StrArry[7] + "\t";
            this.Log += "Direccion ->" + StrArry[8] + "\t";

            objPN.Id = Convert.ToInt32(StrArry[4]);
            objPN.IdTipoDocumento = Convert.ToInt16(StrArry[5]);
            objPN.NumeroDocumento = StrArry[6];
            objPN.SPrimerNombre = StrArry[7];
            objPN.SDireccionDeResidencia = StrArry[8];

            String strSaveEntity = "";
            strSaveEntity += "<BizAgiWSParam>";
            strSaveEntity += "<Entities>";
            strSaveEntity += "<ECE_EnvioCorrespondencia key=\"" + objPN.Id.ToString() + "\">";
            strSaveEntity += "<IdTipoDocDestinatario>" + objPN.IdTipoDocumento.ToString() + "</IdTipoDocDestinatario>";
            strSaveEntity += "<SNumeroDocDestinatario>" + objPN.NumeroDocumento.ToString() + "</SNumeroDocDestinatario>";
            strSaveEntity += "<SNombreDestinatario>" + objPN.SPrimerNombre.ToString() + "</SNombreDestinatario>";
            strSaveEntity += "<SDireccionCorrespondenci>" + objPN.SDireccionDeResidencia.ToString() + "</SDireccionCorrespondenci>";
            strSaveEntity += "</ECE_EnvioCorrespondencia>";
            strSaveEntity += "</Entities>";
            strSaveEntity += "</BizAgiWSParam>";

            CapaSOA2GJ.CapaSOA2GJ objSEF = new CapaSOA2GJ.CapaSOA2GJ();
            objSEF.SetInXML(strSaveEntity);
            objSEF.SaveEntity();

            this.Log += "ACTUALIZADO";
        }

        public void A2(string[] StrArry)
        {
            M_PersonaNotificar objPN = new M_PersonaNotificar();

            this.Log += "A2" + "\t" + "IdTipoDocDestinatario ->" + StrArry[5] + "\t";
            this.Log += "Numero Documento ->" + StrArry[6] + "\t";
            this.Log += "Nombre ->" + StrArry[7] + "\t";
            this.Log += "Direccion ->" + StrArry[8] + "\t";

            objPN.Id = Convert.ToInt32(StrArry[4]);
            objPN.IdTipoDocumento = Convert.ToInt16(StrArry[5]);
            objPN.NumeroDocumento = StrArry[6];
            objPN.SPrimerNombre = StrArry[7];
            objPN.SDireccionDeResidencia = StrArry[8];

            String strSaveEntity = "";
            strSaveEntity += "<BizAgiWSParam>";
            strSaveEntity += "<Entities>";
            strSaveEntity += "<M_RC01_PersonasNotificar key=\"" + objPN.Id.ToString() + "\">";
            strSaveEntity += "<IdP_TipoDocumento>" + objPN.IdTipoDocumento.ToString() + "</IdP_TipoDocumento>";
            strSaveEntity += "<SNumeroDocumento>" + objPN.NumeroDocumento.ToString() + "</SNumeroDocumento>";
            strSaveEntity += "<SPrimerNombre>" + objPN.SPrimerNombre.ToString() + "</SPrimerNombre>";
            strSaveEntity += "<SDireccion>" + objPN.SDireccionDeResidencia.ToString() + "</SDireccion>";
            strSaveEntity += "</M_RC01_PersonasNotificar>";
            strSaveEntity += "</Entities>";
            strSaveEntity += "</BizAgiWSParam>";

            CapaSOA2GJ.CapaSOA2GJ objSEF = new CapaSOA2GJ.CapaSOA2GJ();
            objSEF.SetInXML(strSaveEntity);
            objSEF.SaveEntity();

            this.Log += "ACTUALIZADO";
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
        public Int32 Id;
        public Int32 IdTipoNotificante;
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

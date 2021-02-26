using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models {
    public class CFDIInfoModel {
        protected String uuid;

        protected String rfcEmisor;

        protected String rfcReceptor;

        protected DateTime fechaDescarga;

        protected DateTime fechaPago;

        protected bool conciliado;
        

    protected DateTime fechaEmision;

        protected bool emitida;

        protected bool estadoCFDI;

        protected String efectoComprobante;

        protected String totalCFDI;

        protected String pacqueCertifico;
      // "yyyy-MM-dd hh:mm:ss"

    protected DateTime fechaCertificacion;


        //pendientes de usar
        protected String complementoPago;

        protected String descargaUuid;

        protected Boolean disponible;
    }
}

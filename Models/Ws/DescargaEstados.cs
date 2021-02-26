using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws {
    public static class ESTADO {
        public static String ESPERANDO = "ESPERANDO";
        public static String EN_PROCESO = "EN PROCESO"; //aplica cuando esta en proceso la descargaprogramada
        public static String COMPLETADO = "COMPLETADO"; //aplica cuando ha sido correcta la descarga programada
        public static String ERROR = "ERROR";
        public static String INCOMPLETO = "INCOMPLETA";
        public static String BLOQUEADO = "BLOQUEADA";
        public static String TODOS   = "*"; //para consultar
    }
}

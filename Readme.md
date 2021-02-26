# ![Sifei](https://www.sifei.com.mx/web/image/res.company/1/logo?unique=38c7250)



# SDK API consumo de descargaSAT

Este repositorio incluye en el SDK en .NET y ejemplos para el consumo de endpoints del API REST de descargaSAT

[DescargaSAT](https://descargasat.sifei.com.mx/)

[Sifei](https://www.sifei.com.mx/) 

La clase principal es DescargaSATSDK
# Ejemplos

## Ejemplo Descargar CFDI por UUID:


```csharp
public static void TestObtenerCFDIPorUUID() {
            var cli = new DescargaSATSDK();
            //se establece el TOKEN
            cli.Token = token;
            //se establece el uuid del CFDI, ws ResponseMaster contendra la respuesta y se parametriza el data de tipo CFDIModelAPI(ver referencia)
            WsResponseMaster<CFDIModelAPI> wsResponse = cli.ObtenerCFDIPorUUID(cfdiUUID);
            if (wsResponse.IsStatusSuccess()) {
                CFDIModelAPI cfdi = wsResponse.Data;

                Console.WriteLine(string.Format("UUID:{0}", cfdi.Uuid));
                Console.WriteLine(string.Format("FechaEmision:{0}", cfdi.FechaEmision));
                Console.WriteLine(string.Format("RfcEmisor:{0}", cfdi.RfcEmisor));
                Console.WriteLine(string.Format("RfcReceptor:{0}", cfdi.RfcReceptor));
                Console.WriteLine(string.Format("Total:{0}", cfdi.Total));
                Console.WriteLine(string.Format("Efecto:{0}", cfdi.Efecto));
                Console.WriteLine(string.Format("FechaCertificacion:{0}", cfdi.FechaCertificacion));
                Console.WriteLine(string.Format("Pacquecertifico:{0}", cfdi.Pacquecertifico));

                if (cfdi.EsSolicitadoPorXML() && cfdi.DisponibleXML) { //si es true y no en cancelado se puede descargar.
                    //invocar al metodo de descarga CFDI, o indicar en tu bd que esta registrado,etc:
                    // ...........
                }
                else if (cfdi.EsSolicitadoPorXML() && cfdi.DisponibleXML == false) {
                    //significa que el CFDI no ha sido descontado de tu paquete, por lo cual deberas comprar un paquete para poder descargarlo

                }
                else if (cfdi.EsSolicitadoPorMeta()) {
                    //solo se tiene el meta del CFDI(es decir el resumen de datos), se debe solicitar la descarga de CFDI.(ver manual para entender mejor)

                }
            }
            else {
                if (wsResponse.isNotFound()) {
                    //no existe el cfdi.
                    Console.WriteLine("No existe el CFDI");
                }
                else {
                    ///otro tipo de error:
                }
            }
            Console.ReadLine();
        }

```

## Ejemplo programar Descarga

```csharp


        public static void TestProgramarDescarga() {
            var sdk = new DescargaSATSDK();
            sdk.Token = token;

            var paramerters = new DescargaProgramadaRequest();
            paramerters.FechaInicial = new DateTime(2018, 12, 1);
            paramerters.FechaFinal = new DateTime(2018, 12, 5);
            //nota: las descargas de CFDI son divididas siempre por DIAS
            //debido a esto al crearse una descarga el servicio devuelve un uuid por cada descarga-dia, es decir, si se envia un rango de 30 dias, el ws retornara el uuid de las descargas diarias. Esto permite evitar descargar mas de una vez un mismo dia. 

            var wsResponse = sdk.ProgramarDescarga(paramerters);

            if (wsResponse.IsStatusSuccess()) {
                var data = wsResponse.Data;
                Console.WriteLine(data.Resultado);
                Console.WriteLine(data.Exitosos);
                //descargas efectivamente creadas
                foreach (var uuidgenerado in data.Exitosos) {
                    Console.WriteLine("Se creo descarga con uuid: {0} , apartir de este comento se debera consumir el servicio de consulta descarga para saber si ya fue completado", uuidgenerado);
                }
                //descargas diarias ya existentes:
                foreach (var uuidYaExistente in data.Repetidos) {
                    Console.WriteLine("Ya existe una descarga con el uuid:{0}, por lo que no se volvera a descargar");
                }
                //lista de errores (si es que hubo)
                foreach (var error in data.Errores) {

                    Console.WriteLine("Error :{0}", error);
                }
            }
            else {
                //puede deberse a:
                /** 
                 * Que el rango de la descarga ya existe(descarga duplicada)
                 * Para mas detalle ver tabla de errores.
                 * 
                 */

                Console.WriteLine(string.Format("Codigo de error:{0}", wsResponse.Code));
                Console.WriteLine(string.Format("Mensaje de error:{0}", wsResponse.Message));

            }
            Console.ReadLine();

        }
```

## Ejemplo Consulta de CFDI (varios parametros)

```csharp
 public static void ConsultarCFDI() {
            var sdk = new DescargaSATSDK();
            sdk.Token =token;
            var paramsN = new ParametersCFDIQuery();
            //se puede establecer el efecto del CFDI
            paramsN.EfectoCFDI = "I";
            //se establece la fecha inicial
            paramsN.FechaInicial = DateTime.ParseExact("2019-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            //se establece numero maximo de resultados a devolver:
            paramsN.Limit = 3;
            //se setean los parametros:
            WsResponseMaster<DataResponseCFDIConsulta> wsResponse = sdk.ConsultarCFDIDatos(paramsN);
            //se verifica el status de la peticion.
            if (wsResponse.IsStatusSuccess()) {
                //si todo fue bien entonces:                
                Console.WriteLine(wsResponse.Data.cfdi);
                if (wsResponse.Data.cfdi.Count > 0) {
                    //hubo resultados
                    foreach (var cfdi in wsResponse.Data.cfdi) {
                        Console.WriteLine(cfdi.Uuid);
                        Console.WriteLine(cfdi.RfcEmisor);
                        Console.WriteLine(cfdi.RfcReceptor);
                    }
                }
            }
            else {//error:
                Console.WriteLine(string.Format("Codigo de error:{0}", wsResponse.Code));
                Console.WriteLine(string.Format("Mensaje de error:{0}", wsResponse.Message));
            }            
            Console.ReadLine();
        }

```


## Ejemplo descarga de CFDI

```csharp
public static void descargarCFDIPorConsulta() {
            var sdk = new DescargaSATSDK();
            sdk.Token = token;
            //se instancia objeto que permite que establecer los criterios de seleccion de CFDI
            var parameters = new ParametersDownloadCFDI();
            //se establece el efecto
            parameters.EfectoCFDI = "N";
            parameters.FechaInicial = new DateTime(2018, 01, 01); //requerido
            parameters.FechaFinal = new DateTime(2018, 02, 01);//requerido
            
            try {
                //se establecen los paramtros , en este caso data sera un string que contiene el archivo zip en b64
                WsResponseMaster<string> wsResponse = sdk.DescargarCFDIConsulta(parameters);
                if (wsResponse.IsStatusSuccess()) { //verifica el campos status sea success
                    string zipXML = wsResponse.Data;
                    //se decodifica para obtener los bytes.
                    byte[] zipBytes = Convert.FromBase64String(zipXML);
                    //haz lo que se necesite. por ejemplo extraer a un dir. el el SDK se incluye la clase Utils:
                    int numeroXmlExtraidos=Utils.ExtraerArchivosZipAFolder(zipBytes, @"C:\dir");
                    Console.WriteLine(string.Format("Se han extraido {0} xmls",numeroXmlExtraidos));

                }
                else {
                    Console.WriteLine(string.Format("Codigo de error:{0}", wsResponse.Code));
                    Console.WriteLine(string.Format("Mensaje de error:{0}", wsResponse.Message));
                }
            }
            catch (System.Net.WebException e) {
                Console.WriteLine(e);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
```
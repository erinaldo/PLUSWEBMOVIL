using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CapaProceso.ConfiarPrueba
{
    public class LLenarModelo
    {
        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
        List<modelowmspcarticulos> listaArticulos = null;
        modelowmspcarticulos articulo = new modelowmspcarticulos();

        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public List<ModeloDetalleFactura> listaConsDet = null;
        public Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();

        public ConsultaEmpresa ConsultaEmpresa = new ConsultaEmpresa();
        public modelowmspcempresas ModeloEmpresa = new modelowmspcempresas();
        public List<modelowmspcempresas> ListaModeloEmpresa = null;

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        modelowmspctitulares cliente = new modelowmspctitulares();
        List<modelowmspctitulares> lista = null;

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";

        string metodo = "LLenarModelo.cs";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTAE";

        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        public string nro_trans = null;
        public string impuesto_rest = "0";
        public string ArtB__articulo = "tubo";
        public string ArtB__tipo = "0";
        public string ArtB__compras = "0";
        public string ArtB__ventas = "S";
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        public string LlenarResolucionFactura(string usuario, string empresa, string nro_trans)
        {
            try
            {
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(empresa, usuario, Ccf_tipo1, Ccf_tipo2, nro_trans);
                //Traer datos de resolusion propia de cada factura
                listaRes = ConsultaResolucion.ConsultaResolusiones(usuario, empresa, "0", conscabcera.serie_docum, "F");
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(empresa,usuario);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                ModeloConfiar Modelo = new ModeloConfiar();
                Invoice pruebaInvoice = new Invoice();
             //   pruebaInvoice.UBLExtensions = LlenarPrincipal(); //LLena las extensiones
                pruebaInvoice = LlenarXml(usuario, empresa);
                Modelo.invoice = pruebaInvoice;

                string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                string pathXML = pathtmpfac + empresa.Trim()+ DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "factura.xml";

               

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
               ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
               ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
               ns.Add("clm66411", "urn:un:unece:uncefact:codelist:specification:66411:2001");
               ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
               ns.Add("clmIANAMIMEMediaType", "urn:un:unece:uncefact:codelist:specification:IANAMIMEMediaType:2003");
               ns.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
               ns.Add("udt" , "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
               ns.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
               ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
               ns.Add("ccts", "urn:un:unece:uncefact:documentation:2");
               ns.Add("ds",  "http://www.w3.org/2000/09/xmldsig#");
               ns.Add("clm54217", "urn:un:unece:uncefact:codelist:specification:54217:2001");
               ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                // [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
                XmlSerializer oXmlSerializar = new XmlSerializer(typeof(Invoice));
                string sXml = "";
                string utf8;
                /* using (var sww = new StringWriter())
                 {
                     using (XmlWriter writter = XmlWriter.Create(sww))
                     {

                         oXmlSerializar.Serialize(writter, pruebaInvoice,ns);
                         sXml = sww.ToString();
                     }
                 }*/
                using (StringWriter writer = new Utf8StringWriter())
                {
                    oXmlSerializar.Serialize(writer, pruebaInvoice, ns);
                    utf8 = writer.ToString();
                }

                System.IO.File.WriteAllText(pathXML, utf8);								
              
                return pathXML;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "LlenarResolucionFactura", e.ToString(), DateTime.Now,empresa);
                return null;
            }
        }

        public Invoice LlenarXml(string usuario, string empresa)
        {
            try
            {
                // conscabcera = null;
                //conscabcera = buscarCabezeraFactura(empresa, usuario, Ccf_tipo1, Ccf_tipo2, "664");
            string schemeAgencyID = "195";
            string schemeAgencyName = "CO, DIAN (Dirección de Impuestos y Aduanas Nacionales)";
            listaConsDet = ConsultaDeta.ConsultaDetalleFacura(conscabcera.nro_trans);
            ListaModeloEmpresa = ConsultaEmpresa.BuscartaEmpresa(usuario, empresa);
            ModeloImpuesto = null;
            ModeloImpuesto = BuscarImpuestosREst(usuario, empresa, conscabcera.nro_trans, impuesto_rest);

            foreach (modelowmspcempresas item in ListaModeloEmpresa)
            {

                ModeloEmpresa = item;

            }
            Invoice Invoice = new Invoice();
                //---------------------------------------------------------------cabecerea--------------------------------------------
                ExtensionContent ExtensionContent = new ExtensionContent();

                DianExtensions DianExtensions = new DianExtensions();

                AuthorizationPeriod AuthorizationPeriod = new AuthorizationPeriod();
                AuthorizedInvoices AuthorizedInvoices = new AuthorizedInvoices();
                InvoiceSource InvoiceSource = new InvoiceSource();


                //----------------------------------FIN CLASES--------------------------------------------
                InvoiceControl InvoiceControl = new InvoiceControl();
                InvoiceControl.InvoiceAuthorization = Convert.ToInt64(resolucion.cod_atrib1);
                // DianExtensions.InvoiceControl = InvoiceControl;
                AuthorizationPeriod.StartDate = resolucion.fec_emision; //Fecha de autorizacion
                AuthorizationPeriod.EndDate = resolucion.fec_caducidad;

                InvoiceControl.AuthorizationPeriod = AuthorizationPeriod;

                AuthorizedInvoices.Prefix = resolucion.serie_docum; //Prefijo de la autorizacion
                AuthorizedInvoices.From = Convert.ToInt64(resolucion.nro_docum); //# desde que se habilito la autorizacion
                AuthorizedInvoices.To = Convert.ToInt64(resolucion.nro_docum_ref); //# hasta que se habilito la autorizacion 
                InvoiceControl.AuthorizedInvoices = AuthorizedInvoices;

                DianExtensions.InvoiceControl = InvoiceControl;
                //---------------------------SEGUNDA PARTE-------------------------
                IdentificationCode IdentificationCode = new IdentificationCode();
                IdentificationCode.listAgencyID = "6";
                IdentificationCode.listAgencyName = "United Nations Economic Commission for Europe";
                IdentificationCode.listSchemeURI = "urn:oasis:names:specification:ubl:codelist:gc:CountryIdentificationCode-2.1";
                IdentificationCode.value = "CO";
                InvoiceSource.IdentificationCode = IdentificationCode;

                DianExtensions.InvoiceSource = InvoiceSource;
                //-----------------------TERCERA PARTE-----------------------------
                SoftwareProvider SoftwareProvider = new SoftwareProvider();
                ProviderID ProviderID = new ProviderID();
              //  string schemeAgencyID = "195";
               // string schemeAgencyName = "CO, DIAN (Dirección de Impuestos y Aduanas Nacionales)";

                ProviderID.valor = null; //se pued eenviar vacio 
                ProviderID.schemeAgencyID = schemeAgencyID; //Enviar vacio
                ProviderID.schemeAgencyName = schemeAgencyName;
                ProviderID.schemeID = "9";
                ProviderID.schemeAgencyName = "31";
                SoftwareProvider.ProviderID = ProviderID;

                SoftwareID SoftwareID = new SoftwareID();
                SoftwareID.schemeAgencyID = schemeAgencyID;
                SoftwareID.schemeAgencyName = schemeAgencyName;
                SoftwareID.valor = null; //ENVIAR VACIO
                SoftwareProvider.SoftwareID = SoftwareID;

                DianExtensions.SoftwareProvider = SoftwareProvider;

                //--------------------CUARTA PARTE.......................................
                SoftwareSecurityCode SoftwareSecurityCode = new SoftwareSecurityCode();
                SoftwareSecurityCode.schemeAgencyID = schemeAgencyID;
                SoftwareSecurityCode.schemeAgencyName = schemeAgencyName;
                SoftwareSecurityCode.valor = null;
                DianExtensions.SoftwareSecurityCode = SoftwareSecurityCode; //ENVIAR VACIO

                //..................QUINTA PARTE------------------------
                AuthorizationProvider AuthorizationProvider = new AuthorizationProvider();
                AuthorizationProviderID AuthorizationProviderID = new AuthorizationProviderID();
                AuthorizationProviderID.schemeAgencyID = schemeAgencyID;
                AuthorizationProviderID.schemeAgencyName = schemeAgencyName;
                AuthorizationProviderID.schemeID = "4";
                AuthorizationProviderID.schemeName = "31";
                AuthorizationProviderID.valor = "800197268"; //NIT DIAN
                AuthorizationProvider.AuthorizationProviderID = AuthorizationProviderID;
                DianExtensions.AuthorizationProvider = AuthorizationProvider;
                //--------------------------SEXTA PARTE------------------------
                DianExtensions.QRCode = "";
                //------------------SEPTIMA PARTE------------------------------

                ExtensionContent.DianExtensions = DianExtensions;
                UBLExtensionsUBLExtension UBLExtension = new UBLExtensionsUBLExtension();

                UBLExtension.ExtensionContent = ExtensionContent;

                //------------------LISTA.......
                ExtensionContent ExtensionContent1 = new ExtensionContent();

                UBLExtensionsUBLExtension UBLExtension1 = new UBLExtensionsUBLExtension();
                //UBLExtensions UBLExtensions1 = new UBLExtensions();
                Signature Signature = new Signature();
                Signature.Id = "xmldsig-ab2df1fb-1819-413d-8b8c-79e9ed75638a";
                SignedInfo SignedInfo = new SignedInfo();
                CanonicalizationMethod CanonicalizationMethod = new CanonicalizationMethod();
                CanonicalizationMethod.Algorithm = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
                SignedInfo.CanonicalizationMethod = CanonicalizationMethod;
                Signature.SignedInfo = SignedInfo;
                ExtensionContent1.Signature = Signature;
                UBLExtension1.ExtensionContent = ExtensionContent1;
                //  s.Add(UBLExtension1);
                //  ListaUBL.Add(UBLExtension1);
                // UBLExtensions.UBLExtension = ListaUBL;

                UBLExtensionsUBLExtension[] mas = new UBLExtensionsUBLExtension[2];
                mas[0] = UBLExtension;
                mas[1] = UBLExtension1;
                //...........................................................fin-----------------------------------------
                Invoice.UBLExtensions = mas;
            //Principal Factura
            Invoice.UBLVersionID = "UBL 2.1";
            Invoice.CustomizationID = "05"; //Por defecto
            Invoice.ProfileID = "DIAN 2.1"; //Por defecto
            Invoice.ProfileExecutionID = 2; // 2 Pruebas, 1 Produccion
            ID ID1 = new ID();
            ID1.value = (conscabcera.serie_docum + conscabcera.nro_docum); //numero de factura
            Invoice.ID = ID1;
            //--------------CUFE----------------------------
            UUID UUID = new UUID();
            UUID.schemeID = "2"; //AMBIENTE PRUEBAS 2, 1 PRODUCCION
            UUID.schemeName = "CUFE-SHA384";//ALGORITMO CUFE CUFE-SHA384
            UUID.valor = null; //SE PUEDE ENVIA VACIO
            Invoice.UUID = UUID;// se puede envuar vacio
            //-------------------FIN CUFE-------------------
            Invoice.IssueDate = conscabcera.fec_doc_str;   //Formato aaaa-mm-dd
            DateTime HoraActual = DateTime.Now;
            string FechaFormato = HoraActual.ToString("yyyy-MM-dd");
            int Hora = HoraActual.Hour;
            int min = HoraActual.Minute;
            int seg = HoraActual.Second;
            string FechaEnvio = Hora + ":" + min + ":" + seg + "-5:00";

            Invoice.IssueTime = FechaEnvio; //colocar la hora en que envia el xml*/
            Invoice.Note = conscabcera.observaciones;
            Invoice.DocumentCurrencyCode = conscabcera.cod_moneda; //codigo moneda en la que se factura
            Invoice.LineCountNumeric = listaConsDet.Count; //# total de lineas de deatalle que contendra la factura

            InvoicePeriod InvoicePeriod = new InvoicePeriod(); //no es indispensable pero se envia
            InvoicePeriod.StarDate = conscabcera.fec_doc_str;
            InvoicePeriod.StarTime = null; //no es requerido aunque se envie la fecha
            InvoicePeriod.EndDate = FechaFormato;
            InvoicePeriod.EndTime = null; //no es requerido aunque se envie la fecha
            Invoice.InvoicePeriod = InvoicePeriod;
            //--------------------------------------DATOS DEL EMISOR----------------------------------
            AccountingSupplierParty AccountingSupplierParty = new AccountingSupplierParty();

            string personeria = null;
            if (ModeloEmpresa.personeria == "J")
            {
                personeria = "1";
            }
            else
            {
                personeria = "2";
            }
            AccountingSupplierParty.AdditionalAccountID = personeria;//Tipo de persona 2 natura/1 juridica del emisor de la factura

            Party Party = new Party(); //Clase party
            PartyName PartyName = new PartyName(); // SubClase party 1
            Name eje1 = new Name();
            eje1.value = ModeloEmpresa.nom_emp; //nombre comercial empresa
            PartyName.Name = eje1;
            Party.PartyName = PartyName;

            PhysicalLocation PhysicalLocation = new PhysicalLocation(); // SubClase party 2

            Address Address = new Address(); //Sub clase PhysicalLocation 1
            ID ID2 = new ID();
            ID2.value = ModeloEmpresa.ciudad_tit; //Codigo del municipio
            Address.ID = ID2;
            Address.CityName = ModeloEmpresa.nom_ciudad; //nombre ciudada
            Address.PostalZone = "111221";//no existe en el maestro se quema
            Address.CountrySubentity = ModeloEmpresa.nom_provincia;//nombre departemanto
            Address.CountrySubentityCode = ModeloEmpresa.cod_provincia;//codigo departamneto

            AddressLine AddressLine = new AddressLine(); //Sub clase address
            AddressLine.Line = ModeloEmpresa.dir_tit;
            Address.AddressLine = AddressLine;

            Country Country = new Country();
            IdentificationCode prueba= new IdentificationCode();
            prueba.value = "CO";
            Country.IdentificationCode = prueba;
           

            Name Name = new Name();
            Name.languageID = "es";
            Name.value = ModeloEmpresa.nom_pais;
            Country.Name = Name;
            Address.Country = Country;

            PhysicalLocation.Address = Address;
            Party.PhysicalLocation = PhysicalLocation;

            PartyTaxScheme PartyTaxScheme = new PartyTaxScheme(); // SubClase party 3
            PartyTaxScheme.RegistrationName = ModeloEmpresa.nom_emp; //Razon social emisor

            CompanyID CompanyID = new CompanyID();
            CompanyID.value = ModeloEmpresa.nro_dgi2.Trim(); //Nit del emisor 
            CompanyID.schemeID = ModeloEmpresa.nro_dgi1.Trim(); //DIGITO VERIFICADOR DEL EMISOR
            CompanyID.shemeName = ModeloEmpresa.tipo_ide; //Solo admite NIT DE COLOMBIA documento tipo 31
            CompanyID.schemeAgencyID = schemeAgencyID;
            CompanyID.schemeAgencyName = schemeAgencyName;

            PartyTaxScheme.CompanyID = CompanyID;

            TaxLevelCode TaxLevelCode = new TaxLevelCode();
            TaxLevelCode.listName = ModeloEmpresa.tributacion; //Regimen fiscal al que pertenece el emisor 48-49
            TaxLevelCode.value = "O-99";//por defecto responsabilidad fiscal----------------------------------------------QUE SE DEBE ENVIAR
            PartyTaxScheme.TaxLevelCode = TaxLevelCode; 

            RegistrationAddress RegistrationAddress = new RegistrationAddress(); //sub clase PartyTaxScheme
            ID ID3 = new ID();
            ID3.value = ModeloEmpresa.ciudad_tit; //Codigo del municipio
            RegistrationAddress.ID = ID3;
            RegistrationAddress.CityName = ModeloEmpresa.nom_ciudad; //nombre ciudada
            RegistrationAddress.PostalZone = "111221";//no existe en el maestro se quema----------------------------------------------QUE SE DEBE ENVIAR
            RegistrationAddress.CountrySubentity = ModeloEmpresa.nom_provincia;//nombre departemanto
            RegistrationAddress.CountrySubentityCode = ModeloEmpresa.cod_provincia;//codigo departamneto

            AddressLine AddressLine1 = new AddressLine(); //Sub clase address
            AddressLine1.Line = ModeloEmpresa.dir_tit;
            RegistrationAddress.AddressLine = AddressLine1;

            Country Country1 = new Country();
            IdentificationCode prueba2 = new IdentificationCode();
            prueba2.value = "CO";
            Country1.IdentificationCode =prueba2;//NO EXISTE ESTA INFORMACION ----------------------------------------------QUE SE DEBE ENVIAR
            Name Name1 = new Name();
            Name1.value = ModeloEmpresa.nom_pais;
            Name1.languageID = "es"; //PAIS DEL EMISOR IDIOMAQUE SE USA----------------------------------------------QUE SE DEBE ENVIAR
            Country1.Name = Name1;
            RegistrationAddress.Country = Country1;
            PartyTaxScheme.RegistrationAddress = RegistrationAddress;

            TaxScheme TaxScheme = new TaxScheme();
            ID ID4 = new ID();
            ID4.value = "01";
            TaxScheme.ID = ID4;
            Name eje2 = new Name();
            eje2.value = "IVA";
            TaxScheme.Name = eje2;
            PartyTaxScheme.TaxScheme = TaxScheme;
            Party.PartyTaxScheme = PartyTaxScheme;

            PartyLegalEntity PartyLegalEntity = new PartyLegalEntity();
            PartyLegalEntity.RegistrationName = ModeloEmpresa.nom_emp;

            CompanyID CompanyID2 = new CompanyID();
            CompanyID2.value = ModeloEmpresa.nro_dgi2.Trim(); //Nit del emisor 
            CompanyID2.schemeID = ModeloEmpresa.nro_dgi1.Trim(); //DIGITO VERIFICADOR DEL EMISOR
            CompanyID2.shemeName = ModeloEmpresa.tipo_ide; //Solo admite NIT DE COLOMBIA documento tipo 31
            CompanyID2.schemeAgencyID = schemeAgencyID;
            CompanyID2.schemeAgencyName = schemeAgencyName;
            PartyLegalEntity.CompanyID = CompanyID2;

            CorporateRegistrationScheme CorporateRegistrationScheme = new CorporateRegistrationScheme();
            ID ID5 = new ID();
            ID5.value = conscabcera.serie_docum;
            CorporateRegistrationScheme.ID = ID5;
            CorporateRegistrationScheme.Name = null; //Registro mercantil puede enviarse nulo

            PartyLegalEntity.CorporateRegistrationScheme = CorporateRegistrationScheme;
            Party.PartyLegalEntity = PartyLegalEntity;

            Contact Contact = new Contact();
            Contact.ElectronicMail = ModeloEmpresa.email_tit;
            Party.Contact = Contact;

            AccountingSupplierParty.Party = Party;
            Invoice.AccountingSupplierParty = AccountingSupplierParty;
            //--------------------------FIN DATOS DEL EMISOR
            //----------------------------DATOS DEL CLIENTE------------------------------------
            //Datos del cliente
            string Ven__cod_tit = conscabcera.cod_cliente;

            lista = ConsultaTitulares.ConsultaTitulares(usuario, empresa, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, conscabcera.cod_sucursal);
            foreach (modelowmspctitulares item in lista)
            {
             
                cliente = item;
            }
            AccountingCustomerParty AccountingCustomerParty = new AccountingCustomerParty();
            AccountingCustomerParty.AdditionalAccountID = "1"; //POR DEFECTO

            Party Party1 = new Party();

            PartyName PartyName1 = new PartyName();
            Name eje3 = new Name();
            eje3.value = conscabcera.nom_tit; //Npmbre comercial del cliete
            PartyName1.Name = eje3;
            Party1.PartyName = PartyName1;

            PhysicalLocation PhysicalLocation1 = new PhysicalLocation();
            Address Address1 = new Address();
            ID ID6 = new ID();
            ID6.value = cliente.ciudad_tit;
            Address1.ID = ID6;
            Address1.CityName = cliente.nom_ciudad;
            Address1.PostalZone = "110231";
            Address1.CountrySubentity = cliente.nom_provincia;
            Address1.CountrySubentityCode = cliente.cod_provincia;

            AddressLine AddressLine2 = new AddressLine();
            AddressLine2.Line = cliente.dir_tit;
            Address1.AddressLine = AddressLine2;

            Country Country2 = new Country();
            IdentificationCode prueba3 = new IdentificationCode();
            prueba3.value = "CO";
            Country2.IdentificationCode = prueba3;

            Name Name3 = new Name();
            Name3.value = cliente.nom_pais; //pais del cliente
            Name3.languageID = "es"; //suponiendo que todo sea colombia
            Country2.Name = Name3;

            Address1.Country = Country2;
            PhysicalLocation1.Address = Address1;
            Party1.PhysicalLocation = PhysicalLocation1;

            PartyTaxScheme PartyTaxScheme1 = new PartyTaxScheme();
            PartyTaxScheme1.RegistrationName = cliente.nom_tit;

            CompanyID CompanyID1 = new CompanyID();
            CompanyID1.value = cliente.nro_dgi2.Trim(); //Nit del  cliente
            CompanyID1.schemeID = cliente.nro_dgi1.Trim(); //DIGITO VERIFICADOR DEL cliente
            CompanyID1.shemeName = cliente.cod_dgi.Trim(); //tabla de tipos si coincide con comfiar
            CompanyID1.schemeAgencyID = schemeAgencyID;
            CompanyID1.schemeAgencyName = schemeAgencyName;
            PartyTaxScheme1.CompanyID = CompanyID1;

            TaxLevelCode TaxLevelCode1 = new TaxLevelCode();
            TaxLevelCode1.value = "O-99";//Responsabilidades fiscales del cliente--SE ENVIA POR DEFECTO O-99 = Otro tipo de obligado
            TaxLevelCode1.listName = cliente.regimen_tributacion.Trim();//TRIBUTACION 48-49
            PartyTaxScheme1.TaxLevelCode = TaxLevelCode1;

            RegistrationAddress RegistrationAddress1 = new RegistrationAddress();
            ID ID7 = new ID();
            ID7.value = cliente.ciudad_tit;
            RegistrationAddress1.ID = ID7;
            RegistrationAddress1.CityName = cliente.nom_ciudad;
            RegistrationAddress1.PostalZone = "111221";
            RegistrationAddress1.CountrySubentity = cliente.cod_provincia;
            RegistrationAddress1.CountrySubentityCode = cliente.nom_provincia;

            AddressLine AddressLine3 = new AddressLine();
            AddressLine3.Line = cliente.dir_tit;
            RegistrationAddress1.AddressLine = AddressLine3;

            Country Country3 = new Country();
            IdentificationCode prueba4 = new IdentificationCode();
            prueba4.value = "CO";
            Country3.IdentificationCode = prueba4;

            Name Name4 = new Name();
            Name4.value = cliente.nom_pais; //pais del cliente
            Name4.languageID = "es"; //suponiendo que todo sea colombia
            Country3.Name = Name4;
            RegistrationAddress1.Country = Country3;

            PartyTaxScheme1.RegistrationAddress = RegistrationAddress1;

            TaxScheme TaxScheme1 = new TaxScheme();
            Name eje4 = new Name();
            eje4.value = "IVA";
            ID ID8 = new ID();
            ID8.value = "01";
            TaxScheme1.ID = ID8;
            TaxScheme1.Name = eje4;

            PartyTaxScheme1.TaxScheme = TaxScheme1;
            Party1.PartyTaxScheme = PartyTaxScheme1;

            PartyLegalEntity PartyLegalEntity1 = new PartyLegalEntity();
            PartyLegalEntity1.RegistrationName = cliente.nom_tit;

            CompanyID CompanyID3 = new CompanyID();
            CompanyID3.value = cliente.nro_dgi2.Trim(); //Nit del  cliente
            CompanyID3.schemeID = cliente.nro_dgi1.Trim(); //DIGITO VERIFICADOR DEL cliente
            CompanyID3.shemeName = cliente.cod_dgi.Trim(); //tabla de tipos si coincide con comfiar
            CompanyID3.schemeAgencyID = schemeAgencyID;
            CompanyID3.schemeAgencyName = schemeAgencyName;
            PartyLegalEntity1.CompanyID = CompanyID3;

            CorporateRegistrationScheme CorporateRegistrationScheme1 = new CorporateRegistrationScheme();
            CorporateRegistrationScheme1.Name = null;

            PartyLegalEntity1.CorporateRegistrationScheme = CorporateRegistrationScheme1;
            Party1.PartyLegalEntity = PartyLegalEntity1;

            Contact Contact2 = new Contact();
            Contact2.ElectronicMail = cliente.email_tit;
            Party1.Contact = Contact2;

            AccountingCustomerParty.Party = Party1;
            Invoice.AccountingCustomerParty = AccountingCustomerParty;
            //------------------------FIN INFORMACION CLIENTE--------------------------
            //-----------------------FORMA DE PAGO-------------------------------------
            PaymentMeans PaymentMeans = new PaymentMeans();
            ID ID9 = new ID();
            ID9.value = "1";//fORMA DE PAGO 1.EFECTIVO 2. CREDITO
            PaymentMeans.ID = ID9;
            PaymentMeans.PaymentMeansCode = "ZZZ"; //MEDIO DE PAGO POR DEFECTO ZZZ ACORDADO CON EL CLIENTE
            PaymentMeans.PaymentDueDate = null; //ES OBLIGATORIO SI ES CREDITO
            PaymentMeans.PaymentID = null; //IDENTIFICADOR ALGUN PAGO
            Invoice.PaymentMeans = PaymentMeans;
            //-----------------------DETALLE IMPUESTOS-------------------------
            TaxTotal TaxTotal = new TaxTotal();
            TaxAmount TaxAmount = new TaxAmount();
            TaxAmount.valor = Convert.ToDecimal(ModeloImpuesto.valor_impu);//TOtal de impuestos enviados
            TaxAmount.currencyID = conscabcera.cod_moneda;
            TaxTotal.TaxAmount = TaxAmount;

            TaxSubtotal TaxSubtotal = new TaxSubtotal();
            TaxableAmount TaxableAmount = new TaxableAmount();
            TaxableAmount.currencyID = conscabcera.cod_moneda.Trim();//codigo moneda
            TaxableAmount.value = Convert.ToDecimal(ModeloImpuesto.base_impu); //base imponible
            TaxSubtotal.TaxableAmount = TaxableAmount;

            TaxAmount TaxAmount1 = new TaxAmount();
            TaxAmount1.currencyID = conscabcera.cod_moneda.Trim();
            TaxAmount1.valor = Convert.ToDecimal(ModeloImpuesto.valor_impu);
            TaxSubtotal.TaxAmount = TaxAmount1;

            TaxCategory TaxCategory = new TaxCategory();
            TaxCategory.Percent = Convert.ToDecimal(ModeloImpuesto.porc_impu);

            string nombre_imp=null;
            if (ModeloImpuesto.cod_tasa_impu.Trim() =="01")
            {
                nombre_imp = "IVA";
            }
            TaxScheme TaxScheme2 = new TaxScheme();
            ID ID10 = new ID();
            ID10.value = ModeloImpuesto.cod_tasa_impu.Trim();
            TaxScheme2.ID = ID10;
            Name eje5 = new Name();
            eje5.value = nombre_imp;
            TaxScheme2.Name = eje5;

            TaxCategory.TaxScheme = TaxScheme2;
            TaxSubtotal.TaxCategory = TaxCategory;
            TaxTotal.TaxSubtotal = TaxSubtotal;

            Invoice.TaxTotal = TaxTotal;
            //-------------------------------FIN IMPUESTOS-------------------------------------
            //------------------------------IMPUESTOS TOTALES------------------------------
            LegalMonetaryTotal LegalMonetaryTotal = new LegalMonetaryTotal();

            LineExtensionAmount LineExtensionAmount = new LineExtensionAmount();
            LineExtensionAmount.currencyID = conscabcera.cod_moneda.Trim();
            LineExtensionAmount.valor = conscabcera.subtotal; //valor bruto antes de impuestos
            LegalMonetaryTotal.LineExtensionAmount = LineExtensionAmount;

            TaxExclusiveAmount TaxExclusiveAmount = new TaxExclusiveAmount();
            TaxExclusiveAmount.currencyID = conscabcera.cod_moneda.Trim();
            TaxExclusiveAmount.valor = conscabcera.monto_imponible;//valor gravable
            LegalMonetaryTotal.TaxExclusiveAmount = TaxExclusiveAmount;

            TaxInclusiveAmount TaxInclusiveAmount = new TaxInclusiveAmount();
            TaxInclusiveAmount.currencyID = conscabcera.cod_moneda.Trim(); 
            TaxInclusiveAmount.valor = conscabcera.total; //total;
            LegalMonetaryTotal.TaxInclusiveAmount = TaxInclusiveAmount;

            AllowanceTotalAmount AllowanceTotalAmount = new AllowanceTotalAmount();
            AllowanceTotalAmount.currencyID = conscabcera.cod_moneda.Trim(); 
            AllowanceTotalAmount.Value = conscabcera.descuento; //valor totL DE DESCUENTO APLIACADO  LA FACTURA;
            LegalMonetaryTotal.AllowanceTotalAmount = AllowanceTotalAmount;

            ChargeTotalAmount ChargeTotalAmount = new ChargeTotalAmount();
            ChargeTotalAmount.currencyID = conscabcera.cod_moneda.Trim(); 
            ChargeTotalAmount.valor =0;
            LegalMonetaryTotal.ChargeTotalAmount = ChargeTotalAmount; //cargos totales  aplicados ala factura

            PrepaidAmount PrepaidAmount = new PrepaidAmount();
            PrepaidAmount.currencyID = conscabcera.cod_moneda.Trim();
            PrepaidAmount.valor =0;
            LegalMonetaryTotal.PrepaidAmount = PrepaidAmount; //pagos totales anticipados aplicados a la factura

            PayableRoundingAmount PayableRoundingAmount = new PayableRoundingAmount();
            PayableRoundingAmount.currencyID = conscabcera.cod_moneda.Trim();
            PayableRoundingAmount.valor = 0;
            LegalMonetaryTotal.PayableRoundingAmount = PayableRoundingAmount;  //valor del redondeo aplicado

            PayableAmount PayableAmount = new PayableAmount();
            PayableAmount.currencyID = conscabcera.cod_moneda.Trim();
            PayableAmount.valor = conscabcera.total;
            LegalMonetaryTotal.PayableAmount = PayableAmount;
            Invoice.LegalMonetaryTotal = LegalMonetaryTotal;
            //-------------------IMPUESTOS TOTALES---------------------------------------

            List<InvoiceLine> InvoiceLine = new List<InvoiceLine>();
            
            int count = 0;
            foreach ( var item in listaConsDet)//Trae lista de los productos
            {
                InvoiceLine itemDetalle = new InvoiceLine();
                ArtB__articulo = item.cod_articulo;
                listaArticulos = ConsultaArticulo.ConsultaArticulos(usuario,empresa, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);
                foreach (modelowmspcarticulos caso in listaArticulos)
                {
                   
                    articulo = caso;
                }

                count++;
                ID ID11 = new ID();
                ID11.value = count.ToString();
                itemDetalle.ID = ID11;
                itemDetalle.InvoicedQuantity = item.cantidad; //cantidad de producto

                LineExtensionAmount LineExtensionAmount1 = new LineExtensionAmount();
                LineExtensionAmount1.valor = item.subtotal; //cantx precio- descuento
                LineExtensionAmount1.currencyID = conscabcera.cod_moneda.Trim();
                itemDetalle.LineExtensionAmount = LineExtensionAmount1;

                TaxTotal TaxTotal2 = new TaxTotal();
                TaxAmount TaxAmount2 = new TaxAmount();
                TaxAmount2.currencyID = conscabcera.cod_moneda.Trim();
                TaxAmount2.valor = item.valor_iva;  //valor total de impuestos

                TaxTotal2.TaxAmount = TaxAmount2;

                TaxSubtotal TaxSubtotal2 = new TaxSubtotal();
                TaxableAmount TaxableAmount2 = new TaxableAmount();
                TaxableAmount2.currencyID = conscabcera.cod_moneda.Trim();
                TaxableAmount2.value = item.base_iva; //base imponible
                TaxSubtotal2.TaxableAmount = TaxableAmount2;

                TaxAmount TaxAmount3 = new TaxAmount();
                TaxAmount3.currencyID = conscabcera.cod_moneda.Trim();
                TaxAmount3.valor = item.valor_iva; //valor total del imuesto aplicado el %
                TaxSubtotal2.TaxAmount = TaxAmount3;

                TaxCategory TaxCategory2 = new TaxCategory();
                TaxCategory2.Percent = item.porc_iva;

                TaxScheme TaxScheme3 = new TaxScheme();
                ID ID12 = new ID();
                ID12.value = "01"; //Si es iva 01
                TaxScheme3.ID = ID12;
                Name eje6 = new Name();
                eje6.value = "IVA";//NOMBRE IVA
                TaxScheme3.Name = eje6;

                TaxCategory2.TaxScheme = TaxScheme3;
                TaxSubtotal2.TaxCategory = TaxCategory2;
                TaxTotal2.TaxSubtotal = TaxSubtotal2;
                itemDetalle.TaxTotal = TaxTotal2;
                //----------IMFORMACION PRODUCTO----------------------
                Item Item = new Item();
                Item.Description = item.nom_articulo2; //descripcion del articulo
                Item.AdditionalInformation = null;//MAS INFORMACION

                StandardItemIdentification StandardItemIdentification = new StandardItemIdentification();
                ID ID = new ID();
                
                ID.schemeID = "999"; //por defecto
                ID.schemeName = "Estándar de adopción del contribuyente";
                ID.value = item.cod_articulo;
                StandardItemIdentification.ID = ID;

                Item.StandardItemIdentification = StandardItemIdentification;

                AdditionalItemProperty AdditionalItemProperty = new AdditionalItemProperty();
                Name eje8 = new Name();
                eje8.value = articulo.nom_articulo;
                AdditionalItemProperty.Name = eje8;
                AdditionalItemProperty.Value = articulo.cod_tipoart;

                Item.AdditionalItemProperty = AdditionalItemProperty;
                itemDetalle.Item = Item;
                //---------------FIN INFORMACION PRODUCTO-------------------
                Price Price = new Price();
                PriceAmount PriceAmount = new PriceAmount();
                PriceAmount.valor = item.precio_unit; //precio del articulo
                PriceAmount.currencyID = conscabcera.cod_moneda.Trim();
                Price.PriceAmount = PriceAmount;
                BaseQuantity BaseQuantity = new BaseQuantity();
                BaseQuantity.unitCode = "NIU";//UNIDAD DE MEDIDA
                BaseQuantity.valor = item.cantidad; //cantidad real del producto
                Price.BaseQuantity = BaseQuantity;
                itemDetalle.Price = Price;
               InvoiceLine.Add(itemDetalle); 
            }
            Invoice.InvoiceLine = InvoiceLine;
                return Invoice;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "LlenarXml", e.ToString(), DateTime.Now, empresa);
                return null;
            }
        }
        public UBLExtensionsUBLExtension[] LlenarPrincipal(string usuario, string empresa)
        {
            try
            {

            ExtensionContent ExtensionContent = new ExtensionContent();
           
            DianExtensions DianExtensions = new DianExtensions();
            
            AuthorizationPeriod AuthorizationPeriod = new AuthorizationPeriod();
            AuthorizedInvoices AuthorizedInvoices = new AuthorizedInvoices();
            InvoiceSource InvoiceSource = new InvoiceSource();
           
        
            //----------------------------------FIN CLASES--------------------------------------------
            InvoiceControl InvoiceControl = new InvoiceControl();
            InvoiceControl.InvoiceAuthorization = Convert.ToInt64(resolucion.cod_atrib1);
               // DianExtensions.InvoiceControl = InvoiceControl;
                AuthorizationPeriod.StartDate = resolucion.fec_emision; //Fecha de autorizacion
                AuthorizationPeriod.EndDate = resolucion.fec_caducidad;

                InvoiceControl.AuthorizationPeriod = AuthorizationPeriod;

                AuthorizedInvoices.Prefix = resolucion.serie_docum; //Prefijo de la autorizacion
                AuthorizedInvoices.From = Convert.ToInt64(resolucion.nro_docum); //# desde que se habilito la autorizacion
                AuthorizedInvoices.To = Convert.ToInt64(resolucion.nro_docum_ref); //# hasta que se habilito la autorizacion 
                InvoiceControl.AuthorizedInvoices = AuthorizedInvoices;

                DianExtensions.InvoiceControl = InvoiceControl;
                //---------------------------SEGUNDA PARTE-------------------------
               IdentificationCode IdentificationCode = new IdentificationCode();
               IdentificationCode.listAgencyID = "6";
               IdentificationCode.listAgencyName = "United Nations Economic Commission for Europe";
               IdentificationCode.listSchemeURI = "urn:oasis:names:specification:ubl:codelist:gc:CountryIdentificationCode-2.1";
               IdentificationCode.value = "CO";
               InvoiceSource.IdentificationCode = IdentificationCode;

                DianExtensions.InvoiceSource = InvoiceSource;
            //-----------------------TERCERA PARTE-----------------------------
                SoftwareProvider SoftwareProvider = new SoftwareProvider();
                ProviderID ProviderID = new ProviderID();
            string schemeAgencyID = "195";
            string schemeAgencyName = "CO, DIAN (Dirección de Impuestos y Aduanas Nacionales)";

            ProviderID.valor = null; //se pued eenviar vacio 
            ProviderID.schemeAgencyID = schemeAgencyID; //Enviar vacio
                ProviderID.schemeAgencyName = schemeAgencyName;
                ProviderID.schemeID = "9";
                ProviderID.schemeAgencyName = "31";
            SoftwareProvider.ProviderID = ProviderID;

            SoftwareID SoftwareID = new SoftwareID();
            SoftwareID.schemeAgencyID = schemeAgencyID;
            SoftwareID.schemeAgencyName = schemeAgencyName;
            SoftwareID.valor = null; //ENVIAR VACIO
            SoftwareProvider.SoftwareID = SoftwareID;

            DianExtensions.SoftwareProvider = SoftwareProvider;

            //--------------------CUARTA PARTE.......................................
            SoftwareSecurityCode SoftwareSecurityCode = new SoftwareSecurityCode();
            SoftwareSecurityCode.schemeAgencyID = schemeAgencyID;
            SoftwareSecurityCode.schemeAgencyName = schemeAgencyName;
            SoftwareSecurityCode.valor = null;
            DianExtensions.SoftwareSecurityCode = SoftwareSecurityCode; //ENVIAR VACIO

            //..................QUINTA PARTE------------------------
            AuthorizationProvider AuthorizationProvider = new AuthorizationProvider();
            AuthorizationProviderID AuthorizationProviderID = new AuthorizationProviderID();
            AuthorizationProviderID.schemeAgencyID = schemeAgencyID;
            AuthorizationProviderID.schemeAgencyName = schemeAgencyName;
            AuthorizationProviderID.schemeID = "4";
            AuthorizationProviderID.schemeName = "31";
            AuthorizationProviderID.valor = "800197268"; //NIT DIAN
            AuthorizationProvider.AuthorizationProviderID = AuthorizationProviderID;
            DianExtensions.AuthorizationProvider = AuthorizationProvider;
            //--------------------------SEXTA PARTE------------------------
                DianExtensions.QRCode = "";
            //------------------SEPTIMA PARTE------------------------------

            ExtensionContent.DianExtensions = DianExtensions;
                UBLExtensionsUBLExtension UBLExtension = new UBLExtensionsUBLExtension();
  
                UBLExtension.ExtensionContent = ExtensionContent;
             
                /* UBLExtension[] prueba;
                 prueba = new UBLExtension[1]; 

                 for (int i=0; i<=0; i++)
                 {
                     prueba[i] = UBLExtension;
                 }*/
                
          // UBLExtensions.UBLExtension = p;
                //h.Add(UBLExtensions);
               // UBLExtensions.UBLExtension = UBLExtension;
                // ListaUbl.Add(UBLExtensions);
                //------------------LISTA.......
                ExtensionContent ExtensionContent1 = new ExtensionContent();

                UBLExtensionsUBLExtension UBLExtension1 = new UBLExtensionsUBLExtension();
            //UBLExtensions UBLExtensions1 = new UBLExtensions();
            Signature Signature = new Signature();
            Signature.Id = "xmldsig-ab2df1fb-1819-413d-8b8c-79e9ed75638a";
            SignedInfo SignedInfo = new SignedInfo();
            CanonicalizationMethod CanonicalizationMethod = new CanonicalizationMethod();
            CanonicalizationMethod.Algorithm = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
            SignedInfo.CanonicalizationMethod = CanonicalizationMethod;
            Signature.SignedInfo = SignedInfo;
            ExtensionContent1.Signature = Signature;
            UBLExtension1.ExtensionContent = ExtensionContent1;
                //  s.Add(UBLExtension1);
                //  ListaUBL.Add(UBLExtension1);
                // UBLExtensions.UBLExtension = ListaUBL;

                UBLExtensionsUBLExtension[] mas = new UBLExtensionsUBLExtension[2];
                mas[0] = UBLExtension;
                mas[1] = UBLExtension1;
                //ListaUbl.Add(UBLExtensions1);*/
                return mas;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "LlenarXml", e.ToString(), DateTime.Now, empresa);
                return null;
            }
        }



        public modelowmspcfacturasWMimpuRest BuscarImpuestosREst(string Ccf_usuario, string Ccf_cod_emp, string Ccf_nro_trans, string impuesto)
        {
            try
            {
                ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, impuesto);
                foreach (modelowmspcfacturasWMimpuRest item in ListaModeloimpuesto)
                {
                    if (item.nom_impuesto.Trim() == "IVA GENERADO")
                    {
                        ModeloImpuesto = item;
                        break;
                    }

                }

                return ModeloImpuesto;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarImpuestosREst", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

    }
}

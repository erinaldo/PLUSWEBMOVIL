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

namespace CapaProceso.Comfiar
{
   public  class XmlFacturaV1
    {
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

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

       
        string metodo = "XmlFacturaV1.cs";
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";

        
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

        //DATOS DE LA RESOLUCION DE LA FACTURA

        public string LlenarResolucionFactura(string empresa, string usuario)
        {
            try
            {
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(empresa, usuario, Ccf_tipo1, Ccf_tipo2, "664");
                listaConsDet = null;
                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(conscabcera.nro_trans);
                //Traer datos de resolusion propia de cada factura
                listaRes = ConsultaResolucion.ConsultaResolusiones(usuario, empresa, "0", conscabcera.serie_docum, "F");
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(empresa, usuario);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                ListaModeloEmpresa = ConsultaEmpresa.BuscartaEmpresa(usuario, empresa);
                ModeloImpuesto = null;
                ModeloImpuesto = BuscarImpuestosREst(usuario, empresa, conscabcera.nro_trans, impuesto_rest);

                foreach (modelowmspcempresas item in ListaModeloEmpresa)
                {

                    ModeloEmpresa = item;

                }
                // -----------------------------------------INICIO INVOICE------------------------------------
                Invoice InvoiceFactura = new Invoice();
                UBLExtensions UBLExtensions = new UBLExtensions();
                UBLExtensionsUBLExtension UBLExtension = new UBLExtensionsUBLExtension();
               
                UBLExtensionsUBLExtensionExtensionContent ExtensionContent = new UBLExtensionsUBLExtensionExtensionContent();

                DianExtensions DianExtensions = new DianExtensions(); 

                //----------------------------------FIN CLASES--------------------------------------------
               DianExtensionsInvoiceControl   InvoiceControl  = new DianExtensionsInvoiceControl();
                InvoiceControl.InvoiceAuthorization = Convert.ToUInt64(resolucion.cod_atrib1);
                DianExtensionsInvoiceControlAuthorizationPeriod AuthorizationPeriod = new DianExtensionsInvoiceControlAuthorizationPeriod();
                
                 AuthorizationPeriod.StartDate = Convert.ToDateTime(resolucion.fec_emision); //Fecha de autorizacion
                AuthorizationPeriod.EndDate = Convert.ToDateTime(resolucion.fec_caducidad);
                 DianExtensions.InvoiceControl = InvoiceControl;
                InvoiceControl.AuthorizationPeriod = AuthorizationPeriod;

                DianExtensionsInvoiceControlAuthorizedInvoices AuthorizedInvoices = new DianExtensionsInvoiceControlAuthorizedInvoices();
                AuthorizedInvoices.Prefix = resolucion.serie_docum; //Prefijo de la autorizacion
                AuthorizedInvoices.From = Convert.ToByte(resolucion.nro_docum); //# desde que se habilito la autorizacion
                AuthorizedInvoices.To = resolucion.nro_docum_ref.Trim(); //# hasta que se habilito la autorizacion 
                InvoiceControl.AuthorizedInvoices = AuthorizedInvoices;

                DianExtensions.InvoiceControl = InvoiceControl;
                //---------------------------SEGUNDA PARTE-------------------------
                DianExtensionsInvoiceSource InvoiceSource = new DianExtensionsInvoiceSource();
                IdentificationCode IdentificationCode = new IdentificationCode();
                IdentificationCode.listAgencyID = 6;
                IdentificationCode.listAgencyName = "United Nations Economic Commission for Europe";
                IdentificationCode.listSchemeURI = "urn:oasis:names:specification:ubl:codelist:gc:CountryIdentificationCode-2.1";
                IdentificationCode.Value = "CO";
                InvoiceSource.IdentificationCode = IdentificationCode;

                DianExtensions.InvoiceSource = InvoiceSource;
                //-----------------------TERCERA PARTE-----------------------------
               
                 byte schemeAgencyID = 195;
                string schemeAgencyName = "CO, DIAN (Dirección de Impuestos y Aduanas Nacionales)";

                //--------------------CUARTA PARTE.......................................
               DianExtensionsSoftwareSecurityCode SoftwareSecurityCode  = new DianExtensionsSoftwareSecurityCode();
                SoftwareSecurityCode.schemeAgencyID = schemeAgencyID;
                SoftwareSecurityCode.schemeAgencyName = schemeAgencyName;
              
                DianExtensions.SoftwareSecurityCode = SoftwareSecurityCode; //ENVIAR VACIO

                //..................QUINTA PARTE------------------------
               DianExtensionsAuthorizationProvider AuthorizationProvider  = new DianExtensionsAuthorizationProvider ();
                DianExtensionsAuthorizationProviderAuthorizationProviderID AuthorizationProviderID = new DianExtensionsAuthorizationProviderAuthorizationProviderID();
                AuthorizationProviderID.schemeAgencyID = schemeAgencyID;
                AuthorizationProviderID.schemeAgencyName = schemeAgencyName;
                AuthorizationProviderID.schemeID = 4;
                AuthorizationProviderID.schemeName = 31;
                AuthorizationProviderID.Value = 800197268; //NIT DIAN
                AuthorizationProvider.AuthorizationProviderID = AuthorizationProviderID;
                DianExtensions.AuthorizationProvider = AuthorizationProvider;
                //--------------------------SEXTA PARTE------------------------
                DianExtensions.QRCode = "";
                //------------------SEPTIMA PARTE------------------------------

                ExtensionContent.DianExtensions = DianExtensions;
          
                UBLExtension.ExtensionContent = ExtensionContent;
                UBLExtensions.UBLExtension = UBLExtension;
          
                  InvoiceFactura.UBLExtensions = UBLExtensions;
                //-------------------FIN DE EXTENSIONES-----------------------------------------------
                //..............................INVOICE...........................................
                //Principal Factura
                InvoiceFactura.UBLVersionID = "UBL 2.1";
                InvoiceFactura.CustomizationID = 05; //Por defecto
                InvoiceFactura.ProfileID = "DIAN 2.1"; //Por defecto
                InvoiceFactura.ProfileExecutionID = 2; // 2 Pruebas, 1 Produccion
                ID ID1 = new ID();
                ID1.Value = (conscabcera.serie_docum + conscabcera.nro_docum); //numero de factura
                InvoiceFactura.ID = ID1;
                //--------------CUFE----------------------------

                UUID UUID = new UUID();
                UUID.schemeID = 2; //AMBIENTE PRUEBAS 2, 1 PRODUCCION
                UUID.schemeName = "CUFE-SHA384";//ALGORITMO CUFE CUFE-SHA384
               
                InvoiceFactura.UUID = UUID;// se puede envuar vacio
                                           //-------------------FIN CUFE-------------------
                InvoiceFactura.IssueDate = Convert.ToDateTime(conscabcera.fec_doc_str);   //Formato aaaa-mm-dd
                DateTime HoraActual = DateTime.Now;
                string FechaFormato = HoraActual.ToString("yyyy-MM-dd");
                int Hora = HoraActual.Hour;
                int min = HoraActual.Minute;
                int seg = HoraActual.Second;
                string FechaEnvio = Hora + ":" + min + ":" + seg + "-5:00";

                InvoiceFactura.IssueTime = Convert.ToDateTime(FechaEnvio); //colocar la hora en que envia el xml*/
                //InvoiceFactura.Note = conscabcera.observaciones;
                InvoiceFactura.InvoiceTypeCode = 01; //para facturas de compra nacional
                InvoiceFactura.LineCountNumeric = listaConsDet.Count; //# total de lineas de deatalle que contendra la factura
                InvoiceFactura.DocumentCurrencyCode = conscabcera.cod_moneda; //codigo moneda en la que se factura
                
               //--------------------------------------DATOS DE LA FACTURA-------------------------------------------------
                                          //--------------------------------------DATOS DEL EMISOR----------------------------------
                AccountingSupplierParty AccountingSupplierParty = new AccountingSupplierParty();

                byte personeria =0;
                if (ModeloEmpresa.personeria == "J")
                {
                    personeria = 1;
                }
                else
                {
                    personeria = 2;
                }
                AccountingSupplierParty.AdditionalAccountID = personeria;//Tipo de persona 2 natura/1 juridica del emisor de la factura

                AccountingSupplierPartyParty Party= new AccountingSupplierPartyParty(); //Clase party
                AccountingSupplierPartyPartyPartyName PartyName = new AccountingSupplierPartyPartyPartyName(); // SubClase party 1
                Name eje1 = new Name();
                eje1.Value= ModeloEmpresa.nom_emp; //nombre comercial empresa
                PartyName.Name = eje1;
                Party.PartyName = PartyName;

                AccountingSupplierPartyPartyPhysicalLocation PhysicalLocation  = new AccountingSupplierPartyPartyPhysicalLocation(); // SubClase party 2

                AccountingSupplierPartyPartyPhysicalLocationAddress Address  = new AccountingSupplierPartyPartyPhysicalLocationAddress(); //Sub clase PhysicalLocation 1
                ID ID2 = new ID();
                ID2.Value= ModeloEmpresa.ciudad_tit; //Codigo del municipio
                Address.ID = ID2;
                Address.CityName = ModeloEmpresa.nom_ciudad; //nombre ciudada
                Address.PostalZone = 111221;//no existe en el maestro se quema
                Address.CountrySubentity = ModeloEmpresa.nom_provincia;//nombre departemanto
                Address.CountrySubentityCode =Convert.ToByte(ModeloEmpresa.cod_provincia);//codigo departamneto

                AccountingSupplierPartyPartyPhysicalLocationAddressAddressLine AddressLine  = new AccountingSupplierPartyPartyPhysicalLocationAddressAddressLine(); //Sub clase address
                AddressLine.Line = ModeloEmpresa.dir_tit;
                Address.AddressLine = AddressLine;

                AccountingSupplierPartyPartyPhysicalLocationAddressCountry Country = new AccountingSupplierPartyPartyPhysicalLocationAddressCountry();
                IdentificationCode prueba = new IdentificationCode();
                prueba.Value = "CO";
                Country.IdentificationCode = prueba;


                Name Name = new Name();
                Name.languageID = "es";
                Name.Value = ModeloEmpresa.nom_pais;
                Country.Name = Name;
                Address.Country = Country;

                PhysicalLocation.Address = Address;
                Party.PhysicalLocation = PhysicalLocation;

               AccountingSupplierPartyPartyPartyTaxScheme PartyTaxScheme  = new AccountingSupplierPartyPartyPartyTaxScheme(); // SubClase party 3
                PartyTaxScheme.RegistrationName = ModeloEmpresa.nom_emp; //Razon social emisor

                CompanyID CompanyID = new CompanyID();
                CompanyID.Value = Convert.ToUInt32(ModeloEmpresa.nro_dgi2); //Nit del emisor 
                CompanyID.schemeID =Convert.ToByte(ModeloEmpresa.nro_dgi1); //DIGITO VERIFICADOR DEL EMISOR
                CompanyID.schemeName =Convert.ToByte(ModeloEmpresa.tipo_ide); //Solo admite NIT DE COLOMBIA documento tipo 31
                CompanyID.schemeAgencyID = schemeAgencyID;
                CompanyID.schemeAgencyName = schemeAgencyName;

                PartyTaxScheme.CompanyID = CompanyID;

                TaxLevelCode TaxLevelCode = new TaxLevelCode();
                TaxLevelCode.listName =Convert.ToByte(ModeloEmpresa.tributacion); //Regimen fiscal al que pertenece el emisor 48-49
                TaxLevelCode.Value = "O-99";//por defecto responsabilidad fiscal----------------------------------------------QUE SE DEBE ENVIAR
                PartyTaxScheme.TaxLevelCode = TaxLevelCode;

                AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddress RegistrationAddress  = new AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddress(); //sub clase PartyTaxScheme
                ID ID3 = new ID();
                ID3.Value = ModeloEmpresa.ciudad_tit; //Codigo del municipio
                RegistrationAddress.ID = ID3;
                RegistrationAddress.CityName = ModeloEmpresa.nom_ciudad; //nombre ciudada
                RegistrationAddress.PostalZone = 111221;//no existe en el maestro se quema----------------------------------------------QUE SE DEBE ENVIAR
                RegistrationAddress.CountrySubentity = ModeloEmpresa.nom_provincia;//nombre departemanto
                RegistrationAddress.CountrySubentityCode =Convert.ToByte(ModeloEmpresa.cod_provincia);//codigo departamneto

                AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressAddressLine AddressLine1  = new  AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressAddressLine(); //Sub clase address
                AddressLine1.Line = ModeloEmpresa.dir_tit;
                RegistrationAddress.AddressLine = AddressLine1;

                AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressCountry  Country1 = new AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressCountry();
                IdentificationCode prueba2 = new IdentificationCode();
                prueba2.Value = "CO";
                Country1.IdentificationCode = prueba2;//NO EXISTE ESTA INFORMACION ----------------------------------------------QUE SE DEBE ENVIAR
                Name Name1 = new Name();
                Name1.Value = ModeloEmpresa.nom_pais;
                Name1.languageID = "es"; //PAIS DEL EMISOR IDIOMAQUE SE USA----------------------------------------------QUE SE DEBE ENVIAR
                Country1.Name = Name1;
                RegistrationAddress.Country = Country1;
                PartyTaxScheme.RegistrationAddress = RegistrationAddress;

                AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme TaxScheme  = new AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme();
                ID ID4 = new ID();
                ID4.Value = "01";
                TaxScheme.ID = ID4;
                Name eje2 = new Name();
                eje2.Value = "IVA";
                TaxScheme.Name = eje2;
                PartyTaxScheme.TaxScheme = TaxScheme;
                Party.PartyTaxScheme = PartyTaxScheme;

                AccountingSupplierPartyPartyPartyLegalEntity PartyLegalEntity  = new AccountingSupplierPartyPartyPartyLegalEntity();
                PartyLegalEntity.RegistrationName = ModeloEmpresa.nom_emp;

                CompanyID CompanyID2 = new CompanyID();
                CompanyID2.Value = Convert.ToUInt32(ModeloEmpresa.nro_dgi2); //Nit del emisor 
                CompanyID2.schemeID =Convert.ToByte(ModeloEmpresa.nro_dgi1.Trim()); //DIGITO VERIFICADOR DEL EMISOR
                CompanyID2.schemeName = Convert.ToByte(ModeloEmpresa.tipo_ide); //Solo admite NIT DE COLOMBIA documento tipo 31
                CompanyID2.schemeAgencyID = schemeAgencyID;
                CompanyID2.schemeAgencyName = schemeAgencyName;
                PartyLegalEntity.CompanyID = CompanyID2;

                AccountingSupplierPartyPartyPartyLegalEntityCorporateRegistrationScheme CorporateRegistrationScheme  = new AccountingSupplierPartyPartyPartyLegalEntityCorporateRegistrationScheme();
                ID ID5 = new ID();
                ID5.Value = conscabcera.serie_docum;
                CorporateRegistrationScheme.ID = ID5;
               

                PartyLegalEntity.CorporateRegistrationScheme = CorporateRegistrationScheme;
                Party.PartyLegalEntity = PartyLegalEntity;

                AccountingSupplierParty.Party = Party;
                InvoiceFactura.AccountingSupplierParty = AccountingSupplierParty;
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
                AccountingCustomerParty.AdditionalAccountID = 1; //POR DEFECTO

               AccountingCustomerPartyParty  Party1 = new AccountingCustomerPartyParty();
                AccountingCustomerPartyPartyPartyIdentification PartyIdentification = new AccountingCustomerPartyPartyPartyIdentification();
                ID id_cliente = new ID();
                id_cliente.Value = cliente.nro_dgi1;//digito vrificador
                id_cliente.schemeName = cliente.cod_dgi; //tipo identficacion
                id_cliente.Value = cliente.nro_dgi2;//nit
                PartyIdentification.ID = id_cliente;
  
                AccountingCustomerPartyPartyPartyName PartyName1 = new AccountingCustomerPartyPartyPartyName();
                Name eje3 = new Name();
                eje3.Value = conscabcera.nom_tit; //Npmbre comercial del cliete
                PartyName1.Name = eje3;
                Party1.PartyName = PartyName1;

                AccountingCustomerPartyPartyPhysicalLocation  PhysicalLocation1 = new AccountingCustomerPartyPartyPhysicalLocation();
                AccountingCustomerPartyPartyPhysicalLocationAddress Address1 = new AccountingCustomerPartyPartyPhysicalLocationAddress();
                ID ID6 = new ID();
                ID6.Value = cliente.ciudad_tit;
                Address1.ID = ID6;
                Address1.CityName = cliente.nom_ciudad;
                Address1.PostalZone = 110231;
                Address1.CountrySubentity = cliente.nom_provincia;
                Address1.CountrySubentityCode =Convert.ToByte(cliente.cod_provincia);

                AccountingCustomerPartyPartyPhysicalLocationAddressAddressLine  AddressLine2 = new AccountingCustomerPartyPartyPhysicalLocationAddressAddressLine();
                AddressLine2.Line = cliente.dir_tit;
                Address1.AddressLine = AddressLine2;

                AccountingCustomerPartyPartyPhysicalLocationAddressCountry  Country2 = new AccountingCustomerPartyPartyPhysicalLocationAddressCountry();
                IdentificationCode prueba3 = new IdentificationCode();
                prueba3.Value = "CO";
                Country2.IdentificationCode = prueba3;

                Name Name3 = new Name();
                Name3.Value = cliente.nom_pais; //pais del cliente
                Name3.languageID = "es"; //suponiendo que todo sea colombia
                Country2.Name = Name3;

                Address1.Country = Country2;
                PhysicalLocation1.Address = Address1;
                Party1.PhysicalLocation = PhysicalLocation1;

                AccountingCustomerPartyPartyPartyTaxScheme PartyTaxScheme1 = new AccountingCustomerPartyPartyPartyTaxScheme();
                PartyTaxScheme1.RegistrationName = cliente.nom_tit;

                CompanyID CompanyID1 = new CompanyID();
                CompanyID1.Value =Convert.ToUInt32(cliente.nro_dgi2.Trim()); //Nit del  cliente
                CompanyID1.schemeID = Convert.ToByte(cliente.nro_dgi1.Trim()); //DIGITO VERIFICADOR DEL cliente
                CompanyID1.schemeName =Convert.ToByte(cliente.cod_dgi.Trim()); //tabla de tipos si coincide con comfiar
                CompanyID1.schemeAgencyID = schemeAgencyID;
                CompanyID1.schemeAgencyName = schemeAgencyName;
                PartyTaxScheme1.CompanyID = CompanyID1;

                TaxLevelCode TaxLevelCode1 = new TaxLevelCode();
                TaxLevelCode1.Value = "O-99";//Responsabilidades fiscales del cliente--SE ENVIA POR DEFECTO O-99 = Otro tipo de obligado
                TaxLevelCode1.listName =Convert.ToByte(cliente.regimen_tributacion.Trim());//TRIBUTACION 48-49
                PartyTaxScheme1.TaxLevelCode = TaxLevelCode1;

                AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme TaxScheme1 = new AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme();
                Name eje4 = new Name();
                eje4.Value = "ZZ";  //Tributos del adquiriente vamos a probar por defecto zz
                ID ID8 = new ID();
                ID8.Value = "No aplica";
                TaxScheme1.ID = ID8;
                TaxScheme1.Name = eje4;

                PartyTaxScheme1.TaxScheme = TaxScheme1;
                Party1.PartyTaxScheme = PartyTaxScheme1;

                AccountingCustomerPartyPartyPartyLegalEntity  PartyLegalEntity1 = new AccountingCustomerPartyPartyPartyLegalEntity();
                PartyLegalEntity1.RegistrationName = cliente.nom_tit;

                CompanyID CompanyID3 = new CompanyID();
                CompanyID3.Value = Convert.ToUInt32(cliente.nro_dgi2.Trim()); //Nit del  cliente
                CompanyID3.schemeID = Convert.ToByte(cliente.nro_dgi1.Trim()); //DIGITO VERIFICADOR DEL cliente
                CompanyID3.schemeName = Convert.ToByte(cliente.cod_dgi.Trim()); //tabla de tipos si coincide con comfiar
                CompanyID3.schemeAgencyID = schemeAgencyID;
                CompanyID3.schemeAgencyName = schemeAgencyName;
                PartyLegalEntity1.CompanyID = CompanyID3;

                AccountingCustomerPartyPartyContact Contact = new AccountingCustomerPartyPartyContact();
                Contact.ElectronicMail = cliente.email_tit;
                Contact.Telephone =Convert.ToUInt32(cliente.tel_tit.Trim());
                Party1.Contact = Contact;

                AccountingCustomerPartyPartyPerson Person = new AccountingCustomerPartyPartyPerson();
                Person.FirstName = cliente.razon_social;
                Party1.Person = Person;

                AccountingCustomerParty.Party = Party1;
                InvoiceFactura.AccountingCustomerParty = AccountingCustomerParty;
                //------------------------FIN INFORMACION CLIENTE--------------------------
                //.............delivery no se envia no es requerido------------------------
                //-----------------------FORMA DE PAGO-------------------------------------
                PaymentMeans PaymentMeans = new PaymentMeans();
                ID ID9 = new ID();
                ID9.Value = "1";//fORMA DE PAGO 1.EFECTIVO 2. CREDITO
                PaymentMeans.ID = ID9;
                PaymentMeans.PaymentMeansCode = "ZZZ"; //MEDIO DE PAGO POR DEFECTO ZZZ ACORDADO CON EL CLIENTE
              //  PaymentMeans.PaymentDueDate = null; //ES OBLIGATORIO SI ES CREDITO
                //PaymentMeans.PaymentID = null; //IDENTIFICADOR ALGUN PAGO
                InvoiceFactura.PaymentMeans = PaymentMeans;
                //-----------------------DETALLE IMPUESTOS-------------------------
                TaxTotal TaxTotal = new TaxTotal();
                TaxAmount TaxAmount = new TaxAmount();
                TaxAmount.Value = Convert.ToDecimal(ModeloImpuesto.valor_impu);//TOtal de impuestos enviados
                TaxAmount.currencyID = conscabcera.cod_moneda;
                TaxTotal.TaxAmount = TaxAmount;

                TaxTotalTaxSubtotal TaxSubtotal = new TaxTotalTaxSubtotal();
                TaxableAmount TaxableAmount = new TaxableAmount();
                TaxableAmount.currencyID = conscabcera.cod_moneda.Trim();//codigo moneda
                TaxableAmount.Value = Convert.ToDecimal(ModeloImpuesto.base_impu); //base imponible
                TaxSubtotal.TaxableAmount = TaxableAmount;

                TaxAmount TaxAmount1 = new TaxAmount();
                TaxAmount1.currencyID = conscabcera.cod_moneda.Trim();
                TaxAmount1.Value = Convert.ToDecimal(ModeloImpuesto.valor_impu);
                TaxSubtotal.TaxAmount = TaxAmount1;

                TaxTotalTaxSubtotalTaxCategory TaxCategory = new TaxTotalTaxSubtotalTaxCategory();
                TaxCategory.Percent = Convert.ToDecimal(ModeloImpuesto.porc_impu);

                string nombre_imp = null;
                if (ModeloImpuesto.cod_tasa_impu.Trim() == "01")
                {
                    nombre_imp = "IVA";
                }
                TaxTotalTaxSubtotalTaxCategoryTaxScheme TaxScheme2 = new TaxTotalTaxSubtotalTaxCategoryTaxScheme();
                ID ID10 = new ID();
                ID10.Value = ModeloImpuesto.cod_tasa_impu.Trim();
                TaxScheme2.ID = ID10;
                Name eje5 = new Name();
                eje5.Value = nombre_imp;
                TaxScheme2.Name = eje5;

                TaxCategory.TaxScheme = TaxScheme2;
                TaxSubtotal.TaxCategory = TaxCategory;
                TaxTotal.TaxSubtotal = TaxSubtotal;

                InvoiceFactura.TaxTotal = TaxTotal;
                //-------------------------------FIN IMPUESTOS-------------------------------------
                //------------------------------IMPUESTOS TOTALES------------------------------
                LegalMonetaryTotal LegalMonetaryTotal = new LegalMonetaryTotal();

                LineExtensionAmount LineExtensionAmount = new LineExtensionAmount();
                LineExtensionAmount.currencyID = conscabcera.cod_moneda.Trim();
                LineExtensionAmount.Value = conscabcera.subtotal; //valor bruto antes de impuestos
                LegalMonetaryTotal.LineExtensionAmount = LineExtensionAmount;

                TaxExclusiveAmount TaxExclusiveAmount = new TaxExclusiveAmount();
                TaxExclusiveAmount.currencyID = conscabcera.cod_moneda.Trim();
                TaxExclusiveAmount.Value = conscabcera.monto_imponible;//valor gravable
                LegalMonetaryTotal.TaxExclusiveAmount = TaxExclusiveAmount;

                TaxInclusiveAmount TaxInclusiveAmount = new TaxInclusiveAmount();
                TaxInclusiveAmount.currencyID = conscabcera.cod_moneda.Trim();
                TaxInclusiveAmount.Value = conscabcera.total; //total;
                LegalMonetaryTotal.TaxInclusiveAmount = TaxInclusiveAmount;

                AllowanceTotalAmount AllowanceTotalAmount = new AllowanceTotalAmount();
                AllowanceTotalAmount.currencyID = conscabcera.cod_moneda.Trim();
                AllowanceTotalAmount.Value = conscabcera.descuento; //valor totL DE DESCUENTO APLIACADO  LA FACTURA;
                LegalMonetaryTotal.AllowanceTotalAmount = AllowanceTotalAmount;

                ChargeTotalAmount ChargeTotalAmount = new ChargeTotalAmount();
                ChargeTotalAmount.currencyID = conscabcera.cod_moneda.Trim();
                ChargeTotalAmount.Value = 0;
                LegalMonetaryTotal.ChargeTotalAmount = ChargeTotalAmount; //cargos totales  aplicados ala factura

                PrepaidAmount PrepaidAmount = new PrepaidAmount();
                PrepaidAmount.currencyID = conscabcera.cod_moneda.Trim();
                PrepaidAmount.Value = 0;
                LegalMonetaryTotal.PrepaidAmount = PrepaidAmount; //pagos totales anticipados aplicados a la factura


                PayableAmount PayableAmount = new PayableAmount();
                PayableAmount.currencyID = conscabcera.cod_moneda.Trim();
                PayableAmount.Value = conscabcera.total;
                LegalMonetaryTotal.PayableAmount = PayableAmount;
                InvoiceFactura.LegalMonetaryTotal = LegalMonetaryTotal;
                //-------------------IMPUESTOS TOTALES---------------------------------------
                //----------------------------------------FIN DATOS DE FACTURA------------------------------------------------
                Comprobantes Comprobantes = new Comprobantes();
                ComprobantesComprobante Comprobante = new ComprobantesComprobante();
                ComprobantesComprobanteInformacionOrganismo informacionOrganismo = new ComprobantesComprobanteInformacionOrganismo();

               
                //  ---------------------------------------------------------DetalleFactura---------------

                
                ListaModeloEmpresa = ConsultaEmpresa.BuscartaEmpresa(usuario, empresa);
                ModeloImpuesto = null;
                ModeloImpuesto = BuscarImpuestosREst(usuario, empresa, conscabcera.nro_trans, impuesto_rest);

                foreach (modelowmspcempresas item in ListaModeloEmpresa)
                {

                    ModeloEmpresa = item;

                }
                List<InvoiceLine> InvoiceLine = new List<InvoiceLine>();
                int total_articulos = listaConsDet.Count;
     
                InvoiceLine[] array = new InvoiceLine[total_articulos];
                int count = 0;
                foreach (var item in listaConsDet)//Trae lista de los productos
                {
                    InvoiceLine itemDetalle = new InvoiceLine();
                    ArtB__articulo = item.cod_articulo;
                    listaArticulos = ConsultaArticulo.ConsultaArticulos(usuario, empresa, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);
                    foreach (modelowmspcarticulos caso in listaArticulos)
                    {

                        articulo = caso;
                    }

                    count++;
                   
                    ID ID11 = new ID();
                    ID11.Value = count.ToString();
                    itemDetalle.ID = ID11;
                    itemDetalle.Note = item.nom_articulo2; //va a ir la descripion 2
                    InvoicedQuantity InvoicedQuantity = new InvoicedQuantity();
                    InvoicedQuantity.Value = Convert.ToByte(item.cantidad); //cantidad de producto
                    itemDetalle.InvoicedQuantity = InvoicedQuantity;

                    LineExtensionAmount LineExtensionAmount1 = new LineExtensionAmount();
                    LineExtensionAmount1.Value = item.subtotal; //cantx precio- descuento
                    LineExtensionAmount1.currencyID = conscabcera.cod_moneda.Trim();
                    itemDetalle.LineExtensionAmount = LineExtensionAmount1;

                   InvoiceLineTaxTotal  TaxTotal2 = new InvoiceLineTaxTotal();
                    TaxAmount TaxAmount2 = new TaxAmount();
                    TaxAmount2.currencyID = conscabcera.cod_moneda.Trim();
                    TaxAmount2.Value = item.valor_iva;  //valor total de impuestos

                    TaxTotal2.TaxAmount = TaxAmount2;

                   InvoiceLineTaxTotalTaxSubtotal  TaxSubtotal2 = new InvoiceLineTaxTotalTaxSubtotal ();
                    TaxableAmount TaxableAmount2 = new TaxableAmount();
                    TaxableAmount2.currencyID = conscabcera.cod_moneda.Trim();
                    TaxableAmount2.Value = item.base_iva; //base imponible
                    TaxSubtotal2.TaxableAmount = TaxableAmount2;

                    TaxAmount TaxAmount3 = new TaxAmount();
                    TaxAmount3.currencyID = conscabcera.cod_moneda.Trim();
                    TaxAmount3.Value = item.valor_iva; //valor total del imuesto aplicado el %
                    TaxSubtotal2.TaxAmount = TaxAmount3;

                   InvoiceLineTaxTotalTaxSubtotalTaxCategory  TaxCategory2 = new InvoiceLineTaxTotalTaxSubtotalTaxCategory();
                    TaxCategory2.Percent = item.porc_iva;
                    InvoiceLineTaxTotalTaxSubtotalTaxCategoryTaxScheme TaxScheme3 = new InvoiceLineTaxTotalTaxSubtotalTaxCategoryTaxScheme();
                    
                    ID ID12 = new ID();
                    ID12.Value = "01"; //Si es iva 01
                    TaxScheme3.ID = ID12;
                    Name eje6 = new Name();
                    eje6.Value = "IVA";//NOMBRE IVA
                    TaxScheme3.Name = eje6;

                    TaxCategory2.TaxScheme = TaxScheme3;
                    TaxSubtotal2.TaxCategory = TaxCategory2;
                    TaxTotal2.TaxSubtotal = TaxSubtotal2;
                    itemDetalle.TaxTotal = TaxTotal2;
                    //----------IMFORMACION PRODUCTO----------------------
                   InvoiceLineItem Item = new InvoiceLineItem();
                    Item.Description = item.nom_articulo; //descripcion del articulo
                    InvoiceLineItemManufacturersItemIdentification ManufacturersItemIdentification = new InvoiceLineItemManufacturersItemIdentification();
                    ID ID_P = new ID();
                    ID_P.Value = item.cod_articulo;
                    ManufacturersItemIdentification.ID = ID_P;

                    InvoiceLineItemStandardItemIdentification  StandardItemIdentification  = new InvoiceLineItemStandardItemIdentification();
                     ID ID = new ID();

                    ID.schemeID= 999; //por defecto
                    ID.schemeName = "Estándar de adopción del contribuyente";
                    ID.Value = item.cod_articulo;
                    StandardItemIdentification.ID = ID;

                    Item.StandardItemIdentification = StandardItemIdentification;
                    itemDetalle.Item = Item;
                    //---------------FIN INFORMACION PRODUCTO-------------------
                    InvoiceLinePrice Price  = new InvoiceLinePrice();
                    PriceAmount PriceAmount = new PriceAmount();
                    PriceAmount.Value = item.precio_unit; //precio del articulo
                    PriceAmount.currencyID = conscabcera.cod_moneda.Trim();
                    Price.PriceAmount = PriceAmount;
                    BaseQuantity BaseQuantity = new BaseQuantity();
                    BaseQuantity.unitCode = "NIU";//UNIDAD DE MEDIDA
                    BaseQuantity.Value = item.cantidad; //cantidad real del producto
                    Price.BaseQuantity = BaseQuantity;
                    itemDetalle.Price = Price;
                    InvoiceLine.Add(itemDetalle);
                    for(int i=0; i< total_articulos; i++)
                    {
                        array[i] = itemDetalle;
                    }
                    
                }
                InvoiceFactura.InvoiceLine = array;
                informacionOrganismo.Invoice = InvoiceFactura;
                //............................................FIN DETALE FACTURA PRUEBA
              
                //----------------------------------------INFORMACIO COMFIAR-------------------------
                ComprobantesComprobanteInformacionComfiar informacionComfiar = new ComprobantesComprobanteInformacionComfiar();
                informacionComfiar.ruc = Convert.ToUInt32(ModeloEmpresa.nro_dgi2);
                informacionComfiar.codDoc = 01;
                informacionComfiar.prefixPtoVenta = conscabcera.serie_docum;
                informacionComfiar.nroCbte = 31;

                ComprobantesComprobanteInformacionComfiarReceptores Receptores = new ComprobantesComprobanteInformacionComfiarReceptores();
                ComprobantesComprobanteInformacionComfiarReceptoresReceptor Receptor = new ComprobantesComprobanteInformacionComfiarReceptoresReceptor();
                Receptor.Login = "prueba";
                Receptor.TipoUsuario = 0;
                Receptor.Nombre = ModeloEmpresa.nom_emp;
                Receptor.Mail = ModeloEmpresa.email_tit;
                Receptor.Idioma = 5;
                Receptores.Receptor = Receptor;
                //Comprobante.informacionComfiar = informacionComfiar;
                
                ///F----------------FIN DATOS COMFIAR-----------------------------
                ///.................DATOS PARA CONFIAR.............................
                informacionOrganismo.Invoice = InvoiceFactura;
                Comprobante.informacionOrganismo = informacionOrganismo;
                Comprobante.informacionComfiar = informacionComfiar;

                string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                string pathXML = pathtmpfac + empresa.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "factura.xml";



                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
                ns.Add("clm66411", "urn:un:unece:uncefact:codelist:specification:66411:2001");
                ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                ns.Add("clmIANAMIMEMediaType", "urn:un:unece:uncefact:codelist:specification:IANAMIMEMediaType:2003");
                ns.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                ns.Add("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                ns.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
                ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                ns.Add("ccts", "urn:un:unece:uncefact:documentation:2");
                ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
                ns.Add("clm54217", "urn:un:unece:uncefact:codelist:specification:54217:2001");
                ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                // [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
                XmlSerializer oXmlSerializar = new XmlSerializer(typeof(Invoice));
                string utf8;
   
                using (StringWriter writer = new Utf8StringWriter())
                {
                    oXmlSerializar.Serialize(writer, InvoiceFactura, ns);
                    utf8 = writer.ToString();
                }

                System.IO.File.WriteAllText(pathXML, utf8);

                return pathXML;

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "LlenarEnacabezadoPdfJSON", e.ToString(), DateTime.Now, usuario);
               return null;
            }
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        public UBLExtensions UBLExtensions()
        {
            UBLExtensions prueba = new UBLExtensions();
            return prueba;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CapaProceso.ConfiarPrueba
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", IsNullable = false)]
    public class Invoice
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public UBLExtensionsUBLExtension[] UBLExtensions { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string UBLVersionID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CustomizationID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ProfileID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public int ProfileExecutionID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public  UUID UUID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueDate { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueTime { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string InvoiceTypeCode { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Note { get; set; }
        //-----ULTIMAS CLASES-----------
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentCurrencyCode { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public int LineCountNumeric { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public InvoicePeriod InvoicePeriod;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingSupplierParty AccountingSupplierParty;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingCustomerParty AccountingCustomerParty;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PaymentMeans PaymentMeans;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxTotal TaxTotal;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public LegalMonetaryTotal LegalMonetaryTotal;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<InvoiceLine> InvoiceLine;

    }
    public class UUID
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string valor { get; set; }
    }

    public class InvoiceLine
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID  ID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Note { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public decimal InvoicedQuantity { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount { get; set; }
        public TaxTotal TaxTotal;
        public Item Item;
        public Price Price;
    }
    public class Price
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PriceAmount PriceAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public BaseQuantity BaseQuantity { get; set; }
    }

    public class PriceAmount
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class BaseQuantity
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitCode { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class Item
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Description { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string AdditionalInformation { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public StandardItemIdentification StandardItemIdentification;
        public AdditionalItemProperty AdditionalItemProperty;
    }

    public class AdditionalItemProperty
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Name Name { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Value { get; set; }
    }
    public class StandardItemIdentification
    {
        /// <remarks/>
       [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID  ID { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public class Numero
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string schemeID { get; set; }
        [System.Xml.Serialization.XmlAttribute()]
        public string schemeName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string valor { get; set; }

    }
  
    public class ID
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string schemeID { get; set; }
        [System.Xml.Serialization.XmlAttribute()]
        public string schemeName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string value { get; set; }

    }
    public class LegalMonetaryTotal
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxExclusiveAmount TaxExclusiveAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxInclusiveAmount TaxInclusiveAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public AllowanceTotalAmount AllowanceTotalAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ChargeTotalAmount ChargeTotalAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PrepaidAmount PrepaidAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PayableRoundingAmount PayableRoundingAmount { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PayableAmount PayableAmount { get; set; }

    }

    public class LineExtensionAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class TaxInclusiveAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class ChargeTotalAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class PrepaidAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class PayableRoundingAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }

    public class TaxExclusiveAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }
    public class PayableAmount
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
    }

    public class TaxTotal
    {
        
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount { get; set; }

        public TaxSubtotal TaxSubtotal;
    }

    public class TaxAmount
    {
        [System.Xml.Serialization.XmlText()]
        public decimal valor { get; set; }
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
    }
    public class TaxSubtotal
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxableAmount TaxableAmount { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount { get; set; }
        public TaxCategory TaxCategory;
    }
  
    public class TaxableAmount
    {
        [System.Xml.Serialization.XmlText()]
        public decimal value { get; set; }
        [System.Xml.Serialization.XmlAttribute()]
        public string currencyID { get; set; }
    }

    public class TaxCategory
    {
        /// <remarks/>
       [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public decimal Percent { get; set; }
        public TaxScheme TaxScheme;
    }

    public class PaymentMeans
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PaymentMeansCode { get; set; }
        //[System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PaymentDueDate { get; set; }
        //[System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PaymentID { get; set; }
    }
    public class InvoicePeriod
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string StarDate { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string StarTime { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string EndDate { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string EndTime { get; set; }
    }
    public class PartyName
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Name Name { get; set; }
    }

    public class Address
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]

        public string CityName { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PostalZone { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentity { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentityCode { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AddressLine AddressLine;
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Country Country;
    }

    
    public class Country
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentificationCode IdentificationCode { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Name Name { get; set; }

    }

    public class Name
    {
        
        [System.Xml.Serialization.XmlText()]
        public string value { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string languageID { get; set; }
    }
    public class AddressLine
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Line { get; set; }
    }
    public class PhysicalLocation
    {
        public Address Address;
    }
    public class Party
    {
        public PartyName PartyName;
        public PhysicalLocation PhysicalLocation;
        public PartyTaxScheme PartyTaxScheme;
        public PartyLegalEntity PartyLegalEntity;
        public Contact Contact;
    }

    public class Contact
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ElectronicMail { get; set; }
    }
    public class PartyLegalEntity
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID { get; set; }
        public CorporateRegistrationScheme CorporateRegistrationScheme;
    }

    public class CorporateRegistrationScheme
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Name Name { get; set; }
    }
    public class RegistrationAddress
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CityName { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PostalZone { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentity { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CountrySubentityCode { get; set; }

        public AddressLine AddressLine;
        public Country Country;
    }

    public class TaxScheme
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Name Name { get; set; }
    }
    public class PartyTaxScheme
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public  CompanyID CompanyID { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxLevelCode TaxLevelCode { get; set; }
        public RegistrationAddress RegistrationAddress;
        public TaxScheme TaxScheme;
    }
    public class TaxLevelCode
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]

        public string listName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string value { get; set; }
    }
    public class CompanyID
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string shemeName { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyID { get; set; }
        [System.Xml.Serialization.XmlAttribute()]
        public string schemeAgencyName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string value { get; set; }
    }
    public class AccountingSupplierParty
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string AdditionalAccountID { get; set; }
        public Party Party;
    }

    public class AccountingCustomerParty
    {
        public string AdditionalAccountID { get; set; }
        public Party Party;
    }

   /* [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]*/
    public class UBLExtensions
    {
      //  public UBLExtension UBLExtension;

    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class UBLExtensionsUBLExtension
    {
        public ExtensionContent ExtensionContent { get; set; }
    }

    public class ExtensionContent
    {
        public DianExtensions DianExtensions { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class Signature
    {
        public SignedInfo SignedInfo;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id { get; set; }
    }
    public class SignedInfo
    {
        public CanonicalizationMethod CanonicalizationMethod;
    }

    public class CanonicalizationMethod
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "dian:gov:co:facturaelectronica:Structures-2-1", IsNullable = false)]
    public class DianExtensions
    {
        public InvoiceControl InvoiceControl;
        public InvoiceSource InvoiceSource;
        public SoftwareProvider SoftwareProvider;
        public SoftwareSecurityCode SoftwareSecurityCode { get; set; }
        public AuthorizationProvider AuthorizationProvider { get; set; }
        public string QRCode;
    }
  
    public class  SoftwareSecurityCode
        {
           
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string schemeAgencyID { get; set; }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string schemeAgencyName { get; set; }
            [System.Xml.Serialization.XmlText()]
            public string valor { get; set; }
        }
    
    public class AuthorizationProvider
    {
        public  AuthorizationProviderID AuthorizationProviderID { get; set; }
    }
    public class AuthorizationProviderID
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyName { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string valor { get; set; }
    }
    public class SoftwareProvider
    {
        public ProviderID ProviderID { get; set; }
        public SoftwareID SoftwareID { get; set; }

    }
    public class ProviderID
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyName { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string valor { get; set; }
    }
    public class SoftwareID
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyName { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string valor { get; set; }
    }
    public class InvoiceSource
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentificationCode IdentificationCode { get; set; }

    }
    public class IdentificationCode
    {
       
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string listAgencyID { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string listAgencyName { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string listSchemeURI { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string value { get; set; }
    }

    public class InvoiceControl
    {
        public long InvoiceAuthorization { get; set; }
        public AuthorizationPeriod AuthorizationPeriod;
        public AuthorizedInvoices AuthorizedInvoices;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public class AuthorizationPeriod
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string StartDate { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string EndDate { get; set; }
    }
    public class AuthorizedInvoices
    {
        public string Prefix { get; set; }
        public Int64 From { get; set; }
        public Int64 To { get; set; }
    }

    public  class ModeloConfiar
    {
        public Invoice invoice;
    }
}

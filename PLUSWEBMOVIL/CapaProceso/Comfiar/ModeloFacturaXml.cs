
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", IsNullable = false)]
public partial class Invoice
{

    private UBLExtensionsUBLExtension[] uBLExtensionsField;

    private string uBLVersionIDField;

    private byte customizationIDField;

    private string profileIDField;

    private byte profileExecutionIDField;

    private ID idField;

    private UUID uUIDField;

    private System.DateTime issueDateField;

    private System.DateTime issueTimeField;

    private byte invoiceTypeCodeField;

    private string noteField;

    private System.DateTime taxPointDateField;

    private string documentCurrencyCodeField;

    private byte lineCountNumericField;

    private OrderReference orderReferenceField;

    private AccountingSupplierParty accountingSupplierPartyField;

    private AccountingCustomerParty accountingCustomerPartyField;

    private PaymentMeans paymentMeansField;

    private PaymentTerms paymentTermsField;

    private TaxTotal taxTotalField;

    private LegalMonetaryTotal legalMonetaryTotalField;

    private InvoiceLine[] invoiceLineField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    [System.Xml.Serialization.XmlArrayItemAttribute("UBLExtension", IsNullable = false)]
    public UBLExtensionsUBLExtension[] UBLExtensions
    {
        get
        {
            return this.uBLExtensionsField;
        }
        set
        {
            this.uBLExtensionsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string UBLVersionID
    {
        get
        {
            return this.uBLVersionIDField;
        }
        set
        {
            this.uBLVersionIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte CustomizationID
    {
        get
        {
            return this.customizationIDField;
        }
        set
        {
            this.customizationIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string ProfileID
    {
        get
        {
            return this.profileIDField;
        }
        set
        {
            this.profileIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte ProfileExecutionID
    {
        get
        {
            return this.profileExecutionIDField;
        }
        set
        {
            this.profileExecutionIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UUID UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
    public System.DateTime IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "time")]
    public System.DateTime IssueTime
    {
        get
        {
            return this.issueTimeField;
        }
        set
        {
            this.issueTimeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte InvoiceTypeCode
    {
        get
        {
            return this.invoiceTypeCodeField;
        }
        set
        {
            this.invoiceTypeCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
    public System.DateTime TaxPointDate
    {
        get
        {
            return this.taxPointDateField;
        }
        set
        {
            this.taxPointDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string DocumentCurrencyCode
    {
        get
        {
            return this.documentCurrencyCodeField;
        }
        set
        {
            this.documentCurrencyCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte LineCountNumeric
    {
        get
        {
            return this.lineCountNumericField;
        }
        set
        {
            this.lineCountNumericField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public OrderReference OrderReference
    {
        get
        {
            return this.orderReferenceField;
        }
        set
        {
            this.orderReferenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public AccountingSupplierParty AccountingSupplierParty
    {
        get
        {
            return this.accountingSupplierPartyField;
        }
        set
        {
            this.accountingSupplierPartyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public AccountingCustomerParty AccountingCustomerParty
    {
        get
        {
            return this.accountingCustomerPartyField;
        }
        set
        {
            this.accountingCustomerPartyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public PaymentMeans PaymentMeans
    {
        get
        {
            return this.paymentMeansField;
        }
        set
        {
            this.paymentMeansField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public PaymentTerms PaymentTerms
    {
        get
        {
            return this.paymentTermsField;
        }
        set
        {
            this.paymentTermsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public TaxTotal TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public LegalMonetaryTotal LegalMonetaryTotal
    {
        get
        {
            return this.legalMonetaryTotalField;
        }
        set
        {
            this.legalMonetaryTotalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("InvoiceLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public InvoiceLine[] InvoiceLine
    {
        get
        {
            return this.invoiceLineField;
        }
        set
        {
            this.invoiceLineField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
public partial class UBLExtensionsUBLExtension
{

    private UBLExtensionsUBLExtensionExtensionContent extensionContentField;

    /// <remarks/>
    public UBLExtensionsUBLExtensionExtensionContent ExtensionContent
    {
        get
        {
            return this.extensionContentField;
        }
        set
        {
            this.extensionContentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
public partial class UBLExtensionsUBLExtensionExtensionContent
{

    private Signature signatureField;

    private DianExtensions dianExtensionsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public Signature Signature
    {
        get
        {
            return this.signatureField;
        }
        set
        {
            this.signatureField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
    public DianExtensions DianExtensions
    {
        get
        {
            return this.dianExtensionsField;
        }
        set
        {
            this.dianExtensionsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class Signature
{

    private SignatureSignedInfo signedInfoField;

    private SignatureSignatureValue signatureValueField;

    private SignatureKeyInfo keyInfoField;

    private SignatureObject objectField;

    private string idField;

    /// <remarks/>
    public SignatureSignedInfo SignedInfo
    {
        get
        {
            return this.signedInfoField;
        }
        set
        {
            this.signedInfoField = value;
        }
    }

    /// <remarks/>
    public SignatureSignatureValue SignatureValue
    {
        get
        {
            return this.signatureValueField;
        }
        set
        {
            this.signatureValueField = value;
        }
    }

    /// <remarks/>
    public SignatureKeyInfo KeyInfo
    {
        get
        {
            return this.keyInfoField;
        }
        set
        {
            this.keyInfoField = value;
        }
    }

    /// <remarks/>
    public SignatureObject Object
    {
        get
        {
            return this.objectField;
        }
        set
        {
            this.objectField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfo
{

    private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

    private SignatureSignedInfoSignatureMethod signatureMethodField;

    private SignatureSignedInfoReference[] referenceField;

    /// <remarks/>
    public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
    {
        get
        {
            return this.canonicalizationMethodField;
        }
        set
        {
            this.canonicalizationMethodField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoSignatureMethod SignatureMethod
    {
        get
        {
            return this.signatureMethodField;
        }
        set
        {
            this.signatureMethodField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Reference")]
    public SignatureSignedInfoReference[] Reference
    {
        get
        {
            return this.referenceField;
        }
        set
        {
            this.referenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoCanonicalizationMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoSignatureMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReference
{

    private SignatureSignedInfoReferenceTransforms transformsField;

    private SignatureSignedInfoReferenceDigestMethod digestMethodField;

    private string digestValueField;

    private string idField;

    private string uRIField;

    private string typeField;

    /// <remarks/>
    public SignatureSignedInfoReferenceTransforms Transforms
    {
        get
        {
            return this.transformsField;
        }
        set
        {
            this.transformsField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoReferenceDigestMethod DigestMethod
    {
        get
        {
            return this.digestMethodField;
        }
        set
        {
            this.digestMethodField = value;
        }
    }

    /// <remarks/>
    public string DigestValue
    {
        get
        {
            return this.digestValueField;
        }
        set
        {
            this.digestValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string URI
    {
        get
        {
            return this.uRIField;
        }
        set
        {
            this.uRIField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceTransforms
{

    private SignatureSignedInfoReferenceTransformsTransform transformField;

    /// <remarks/>
    public SignatureSignedInfoReferenceTransformsTransform Transform
    {
        get
        {
            return this.transformField;
        }
        set
        {
            this.transformField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceTransformsTransform
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceDigestMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignatureValue
{

    private string idField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureKeyInfo
{

    private SignatureKeyInfoX509Data x509DataField;

    /// <remarks/>
    public SignatureKeyInfoX509Data X509Data
    {
        get
        {
            return this.x509DataField;
        }
        set
        {
            this.x509DataField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureKeyInfoX509Data
{

    private string x509CertificateField;

    /// <remarks/>
    public string X509Certificate
    {
        get
        {
            return this.x509CertificateField;
        }
        set
        {
            this.x509CertificateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureObject
{

    private QualifyingProperties qualifyingPropertiesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public QualifyingProperties QualifyingProperties
    {
        get
        {
            return this.qualifyingPropertiesField;
        }
        set
        {
            this.qualifyingPropertiesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://uri.etsi.org/01903/v1.3.2#", IsNullable = false)]
public partial class QualifyingProperties
{

    private QualifyingPropertiesSignedProperties signedPropertiesField;

    private string targetField;

    /// <remarks/>
    public QualifyingPropertiesSignedProperties SignedProperties
    {
        get
        {
            return this.signedPropertiesField;
        }
        set
        {
            this.signedPropertiesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Target
    {
        get
        {
            return this.targetField;
        }
        set
        {
            this.targetField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedProperties
{

    private QualifyingPropertiesSignedPropertiesSignedSignatureProperties signedSignaturePropertiesField;

    private string idField;

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignatureProperties SignedSignatureProperties
    {
        get
        {
            return this.signedSignaturePropertiesField;
        }
        set
        {
            this.signedSignaturePropertiesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignatureProperties
{

    private System.DateTime signingTimeField;

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCert[] signingCertificateField;

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifier signaturePolicyIdentifierField;

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole signerRoleField;

    /// <remarks/>
    public System.DateTime SigningTime
    {
        get
        {
            return this.signingTimeField;
        }
        set
        {
            this.signingTimeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Cert", IsNullable = false)]
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCert[] SigningCertificate
    {
        get
        {
            return this.signingCertificateField;
        }
        set
        {
            this.signingCertificateField = value;
        }
    }

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifier SignaturePolicyIdentifier
    {
        get
        {
            return this.signaturePolicyIdentifierField;
        }
        set
        {
            this.signaturePolicyIdentifierField = value;
        }
    }

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole SignerRole
    {
        get
        {
            return this.signerRoleField;
        }
        set
        {
            this.signerRoleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCert
{

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCertCertDigest certDigestField;

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCertIssuerSerial issuerSerialField;

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCertCertDigest CertDigest
    {
        get
        {
            return this.certDigestField;
        }
        set
        {
            this.certDigestField = value;
        }
    }

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCertIssuerSerial IssuerSerial
    {
        get
        {
            return this.issuerSerialField;
        }
        set
        {
            this.issuerSerialField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCertCertDigest
{

    private DigestMethod digestMethodField;

    private string digestValueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public DigestMethod DigestMethod
    {
        get
        {
            return this.digestMethodField;
        }
        set
        {
            this.digestMethodField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public string DigestValue
    {
        get
        {
            return this.digestValueField;
        }
        set
        {
            this.digestValueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class DigestMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesCertIssuerSerial
{

    private string x509IssuerNameField;

    private ulong x509SerialNumberField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public string X509IssuerName
    {
        get
        {
            return this.x509IssuerNameField;
        }
        set
        {
            this.x509IssuerNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public ulong X509SerialNumber
    {
        get
        {
            return this.x509SerialNumberField;
        }
        set
        {
            this.x509SerialNumberField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifier
{

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyId signaturePolicyIdField;

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyId SignaturePolicyId
    {
        get
        {
            return this.signaturePolicyIdField;
        }
        set
        {
            this.signaturePolicyIdField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyId
{

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyId sigPolicyIdField;

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyHash sigPolicyHashField;

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyId SigPolicyId
    {
        get
        {
            return this.sigPolicyIdField;
        }
        set
        {
            this.sigPolicyIdField = value;
        }
    }

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyHash SigPolicyHash
    {
        get
        {
            return this.sigPolicyHashField;
        }
        set
        {
            this.sigPolicyHashField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyId
{

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyIdIdentifier identifierField;

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyIdIdentifier Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyIdIdentifier
{

    private string qualifierField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Qualifier
    {
        get
        {
            return this.qualifierField;
        }
        set
        {
            this.qualifierField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignaturePolicyIdentifierSignaturePolicyIdSigPolicyHash
{

    private DigestMethod digestMethodField;

    private string digestValueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public DigestMethod DigestMethod
    {
        get
        {
            return this.digestMethodField;
        }
        set
        {
            this.digestMethodField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public string DigestValue
    {
        get
        {
            return this.digestValueField;
        }
        set
        {
            this.digestValueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole
{

    private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles claimedRolesField;

    /// <remarks/>
    public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles ClaimedRoles
    {
        get
        {
            return this.claimedRolesField;
        }
        set
        {
            this.claimedRolesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles
{

    private string claimedRoleField;

    /// <remarks/>
    public string ClaimedRole
    {
        get
        {
            return this.claimedRoleField;
        }
        set
        {
            this.claimedRoleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "dian:gov:co:facturaelectronica:Structures-2-1", IsNullable = false)]
public partial class DianExtensions
{

    private DianExtensionsInvoiceControl invoiceControlField;

    private DianExtensionsInvoiceSource invoiceSourceField;

    private DianExtensionsSoftwareProvider softwareProviderField;

    private DianExtensionsSoftwareSecurityCode softwareSecurityCodeField;

    private DianExtensionsAuthorizationProvider authorizationProviderField;

    private string qRCodeField;

    /// <remarks/>
    public DianExtensionsInvoiceControl InvoiceControl
    {
        get
        {
            return this.invoiceControlField;
        }
        set
        {
            this.invoiceControlField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsInvoiceSource InvoiceSource
    {
        get
        {
            return this.invoiceSourceField;
        }
        set
        {
            this.invoiceSourceField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsSoftwareProvider SoftwareProvider
    {
        get
        {
            return this.softwareProviderField;
        }
        set
        {
            this.softwareProviderField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsSoftwareSecurityCode SoftwareSecurityCode
    {
        get
        {
            return this.softwareSecurityCodeField;
        }
        set
        {
            this.softwareSecurityCodeField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsAuthorizationProvider AuthorizationProvider
    {
        get
        {
            return this.authorizationProviderField;
        }
        set
        {
            this.authorizationProviderField = value;
        }
    }

    /// <remarks/>
    public string QRCode
    {
        get
        {
            return this.qRCodeField;
        }
        set
        {
            this.qRCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsInvoiceControl
{

    private ulong invoiceAuthorizationField;

    private DianExtensionsInvoiceControlAuthorizationPeriod authorizationPeriodField;

    private DianExtensionsInvoiceControlAuthorizedInvoices authorizedInvoicesField;

    /// <remarks/>
    public ulong InvoiceAuthorization
    {
        get
        {
            return this.invoiceAuthorizationField;
        }
        set
        {
            this.invoiceAuthorizationField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsInvoiceControlAuthorizationPeriod AuthorizationPeriod
    {
        get
        {
            return this.authorizationPeriodField;
        }
        set
        {
            this.authorizationPeriodField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsInvoiceControlAuthorizedInvoices AuthorizedInvoices
    {
        get
        {
            return this.authorizedInvoicesField;
        }
        set
        {
            this.authorizedInvoicesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsInvoiceControlAuthorizationPeriod
{

    private System.DateTime startDateField;

    private System.DateTime endDateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
    public System.DateTime StartDate
    {
        get
        {
            return this.startDateField;
        }
        set
        {
            this.startDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
    public System.DateTime EndDate
    {
        get
        {
            return this.endDateField;
        }
        set
        {
            this.endDateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsInvoiceControlAuthorizedInvoices
{

    private string prefixField;

    private byte fromField;

    private ushort toField;

    /// <remarks/>
    public string Prefix
    {
        get
        {
            return this.prefixField;
        }
        set
        {
            this.prefixField = value;
        }
    }

    /// <remarks/>
    public byte From
    {
        get
        {
            return this.fromField;
        }
        set
        {
            this.fromField = value;
        }
    }

    /// <remarks/>
    public ushort To
    {
        get
        {
            return this.toField;
        }
        set
        {
            this.toField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsInvoiceSource
{

    private IdentificationCode identificationCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IdentificationCode IdentificationCode
    {
        get
        {
            return this.identificationCodeField;
        }
        set
        {
            this.identificationCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class IdentificationCode
{

    private byte listAgencyIDField;

    private bool listAgencyIDFieldSpecified;

    private string listAgencyNameField;

    private string listSchemeURIField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte listAgencyID
    {
        get
        {
            return this.listAgencyIDField;
        }
        set
        {
            this.listAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool listAgencyIDSpecified
    {
        get
        {
            return this.listAgencyIDFieldSpecified;
        }
        set
        {
            this.listAgencyIDFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string listAgencyName
    {
        get
        {
            return this.listAgencyNameField;
        }
        set
        {
            this.listAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string listSchemeURI
    {
        get
        {
            return this.listSchemeURIField;
        }
        set
        {
            this.listSchemeURIField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsSoftwareProvider
{

    private DianExtensionsSoftwareProviderProviderID providerIDField;

    private DianExtensionsSoftwareProviderSoftwareID softwareIDField;

    /// <remarks/>
    public DianExtensionsSoftwareProviderProviderID ProviderID
    {
        get
        {
            return this.providerIDField;
        }
        set
        {
            this.providerIDField = value;
        }
    }

    /// <remarks/>
    public DianExtensionsSoftwareProviderSoftwareID SoftwareID
    {
        get
        {
            return this.softwareIDField;
        }
        set
        {
            this.softwareIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsSoftwareProviderProviderID
{

    private byte schemeAgencyIDField;

    private string schemeAgencyNameField;

    private byte schemeIDField;

    private byte schemeNameField;

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeAgencyID
    {
        get
        {
            return this.schemeAgencyIDField;
        }
        set
        {
            this.schemeAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeAgencyName
    {
        get
        {
            return this.schemeAgencyNameField;
        }
        set
        {
            this.schemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeID
    {
        get
        {
            return this.schemeIDField;
        }
        set
        {
            this.schemeIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeName
    {
        get
        {
            return this.schemeNameField;
        }
        set
        {
            this.schemeNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public uint Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsSoftwareProviderSoftwareID
{

    private byte schemeAgencyIDField;

    private string schemeAgencyNameField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeAgencyID
    {
        get
        {
            return this.schemeAgencyIDField;
        }
        set
        {
            this.schemeAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeAgencyName
    {
        get
        {
            return this.schemeAgencyNameField;
        }
        set
        {
            this.schemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsSoftwareSecurityCode
{

    private byte schemeAgencyIDField;

    private string schemeAgencyNameField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeAgencyID
    {
        get
        {
            return this.schemeAgencyIDField;
        }
        set
        {
            this.schemeAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeAgencyName
    {
        get
        {
            return this.schemeAgencyNameField;
        }
        set
        {
            this.schemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsAuthorizationProvider
{

    private DianExtensionsAuthorizationProviderAuthorizationProviderID authorizationProviderIDField;

    /// <remarks/>
    public DianExtensionsAuthorizationProviderAuthorizationProviderID AuthorizationProviderID
    {
        get
        {
            return this.authorizationProviderIDField;
        }
        set
        {
            this.authorizationProviderIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "dian:gov:co:facturaelectronica:Structures-2-1")]
public partial class DianExtensionsAuthorizationProviderAuthorizationProviderID
{

    private byte schemeAgencyIDField;

    private string schemeAgencyNameField;

    private byte schemeIDField;

    private byte schemeNameField;

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeAgencyID
    {
        get
        {
            return this.schemeAgencyIDField;
        }
        set
        {
            this.schemeAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeAgencyName
    {
        get
        {
            return this.schemeAgencyNameField;
        }
        set
        {
            this.schemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeID
    {
        get
        {
            return this.schemeIDField;
        }
        set
        {
            this.schemeIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeName
    {
        get
        {
            return this.schemeNameField;
        }
        set
        {
            this.schemeNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public uint Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class ID
{

    private byte schemeAgencyNameField;

    private bool schemeAgencyNameFieldSpecified;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeAgencyName
    {
        get
        {
            return this.schemeAgencyNameField;
        }
        set
        {
            this.schemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool schemeAgencyNameSpecified
    {
        get
        {
            return this.schemeAgencyNameFieldSpecified;
        }
        set
        {
            this.schemeAgencyNameFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class UUID
{

    private byte schemeIDField;

    private string schemeNameField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeID
    {
        get
        {
            return this.schemeIDField;
        }
        set
        {
            this.schemeIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeName
    {
        get
        {
            return this.schemeNameField;
        }
        set
        {
            this.schemeNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class OrderReference
{

    private ID idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class AccountingSupplierParty
{

    private byte additionalAccountIDField;

    private AccountingSupplierPartyParty partyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte AdditionalAccountID
    {
        get
        {
            return this.additionalAccountIDField;
        }
        set
        {
            this.additionalAccountIDField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyParty Party
    {
        get
        {
            return this.partyField;
        }
        set
        {
            this.partyField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyParty
{

    private AccountingSupplierPartyPartyPartyName partyNameField;

    private AccountingSupplierPartyPartyPhysicalLocation physicalLocationField;

    private AccountingSupplierPartyPartyPartyTaxScheme partyTaxSchemeField;

    private AccountingSupplierPartyPartyPartyLegalEntity partyLegalEntityField;

    private AccountingSupplierPartyPartyContact contactField;

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyName PartyName
    {
        get
        {
            return this.partyNameField;
        }
        set
        {
            this.partyNameField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPhysicalLocation PhysicalLocation
    {
        get
        {
            return this.physicalLocationField;
        }
        set
        {
            this.physicalLocationField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyTaxScheme PartyTaxScheme
    {
        get
        {
            return this.partyTaxSchemeField;
        }
        set
        {
            this.partyTaxSchemeField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyLegalEntity PartyLegalEntity
    {
        get
        {
            return this.partyLegalEntityField;
        }
        set
        {
            this.partyLegalEntityField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyContact Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyName
{

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class Name
{

    private string languageIDField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string languageID
    {
        get
        {
            return this.languageIDField;
        }
        set
        {
            this.languageIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPhysicalLocation
{

    private AccountingSupplierPartyPartyPhysicalLocationAddress addressField;

    /// <remarks/>
    public AccountingSupplierPartyPartyPhysicalLocationAddress Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPhysicalLocationAddress
{

    private ID idField;

    private string cityNameField;

    private string countrySubentityField;

    private byte countrySubentityCodeField;

    private AccountingSupplierPartyPartyPhysicalLocationAddressAddressLine addressLineField;

    private AccountingSupplierPartyPartyPhysicalLocationAddressCountry countryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string CountrySubentity
    {
        get
        {
            return this.countrySubentityField;
        }
        set
        {
            this.countrySubentityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte CountrySubentityCode
    {
        get
        {
            return this.countrySubentityCodeField;
        }
        set
        {
            this.countrySubentityCodeField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPhysicalLocationAddressAddressLine AddressLine
    {
        get
        {
            return this.addressLineField;
        }
        set
        {
            this.addressLineField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPhysicalLocationAddressCountry Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPhysicalLocationAddressAddressLine
{

    private string lineField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string Line
    {
        get
        {
            return this.lineField;
        }
        set
        {
            this.lineField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPhysicalLocationAddressCountry
{

    private IdentificationCode identificationCodeField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IdentificationCode IdentificationCode
    {
        get
        {
            return this.identificationCodeField;
        }
        set
        {
            this.identificationCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyTaxScheme
{

    private string registrationNameField;

    private CompanyID companyIDField;

    private TaxLevelCode taxLevelCodeField;

    private AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddress registrationAddressField;

    private AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme taxSchemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string RegistrationName
    {
        get
        {
            return this.registrationNameField;
        }
        set
        {
            this.registrationNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyID CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxLevelCode TaxLevelCode
    {
        get
        {
            return this.taxLevelCodeField;
        }
        set
        {
            this.taxLevelCodeField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddress RegistrationAddress
    {
        get
        {
            return this.registrationAddressField;
        }
        set
        {
            this.registrationAddressField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class CompanyID
{

    private byte schemeAgencyIDField;

    private string schemeAgencyNameField;

    private byte schemeIDField;

    private byte schemeNameField;

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeAgencyID
    {
        get
        {
            return this.schemeAgencyIDField;
        }
        set
        {
            this.schemeAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeAgencyName
    {
        get
        {
            return this.schemeAgencyNameField;
        }
        set
        {
            this.schemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeID
    {
        get
        {
            return this.schemeIDField;
        }
        set
        {
            this.schemeIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte schemeName
    {
        get
        {
            return this.schemeNameField;
        }
        set
        {
            this.schemeNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public uint Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class TaxLevelCode
{

    private byte listNameField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte listName
    {
        get
        {
            return this.listNameField;
        }
        set
        {
            this.listNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddress
{

    private ID idField;

    private string cityNameField;

    private string countrySubentityField;

    private byte countrySubentityCodeField;

    private AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressAddressLine addressLineField;

    private AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressCountry countryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string CountrySubentity
    {
        get
        {
            return this.countrySubentityField;
        }
        set
        {
            this.countrySubentityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte CountrySubentityCode
    {
        get
        {
            return this.countrySubentityCodeField;
        }
        set
        {
            this.countrySubentityCodeField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressAddressLine AddressLine
    {
        get
        {
            return this.addressLineField;
        }
        set
        {
            this.addressLineField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressCountry Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressAddressLine
{

    private string lineField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string Line
    {
        get
        {
            return this.lineField;
        }
        set
        {
            this.lineField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyTaxSchemeRegistrationAddressCountry
{

    private IdentificationCode identificationCodeField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IdentificationCode IdentificationCode
    {
        get
        {
            return this.identificationCodeField;
        }
        set
        {
            this.identificationCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme
{

    private ID idField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyLegalEntity
{

    private string registrationNameField;

    private CompanyID companyIDField;

    private AccountingSupplierPartyPartyPartyLegalEntityCorporateRegistrationScheme corporateRegistrationSchemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string RegistrationName
    {
        get
        {
            return this.registrationNameField;
        }
        set
        {
            this.registrationNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyID CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    /// <remarks/>
    public AccountingSupplierPartyPartyPartyLegalEntityCorporateRegistrationScheme CorporateRegistrationScheme
    {
        get
        {
            return this.corporateRegistrationSchemeField;
        }
        set
        {
            this.corporateRegistrationSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyPartyLegalEntityCorporateRegistrationScheme
{

    private ID idField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingSupplierPartyPartyContact
{

    private string electronicMailField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string ElectronicMail
    {
        get
        {
            return this.electronicMailField;
        }
        set
        {
            this.electronicMailField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class AccountingCustomerParty
{

    private byte additionalAccountIDField;

    private AccountingCustomerPartyParty partyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte AdditionalAccountID
    {
        get
        {
            return this.additionalAccountIDField;
        }
        set
        {
            this.additionalAccountIDField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyParty Party
    {
        get
        {
            return this.partyField;
        }
        set
        {
            this.partyField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyParty
{

    private AccountingCustomerPartyPartyPartyName partyNameField;

    private AccountingCustomerPartyPartyPhysicalLocation physicalLocationField;

    private AccountingCustomerPartyPartyPartyTaxScheme partyTaxSchemeField;

    private AccountingCustomerPartyPartyPartyLegalEntity partyLegalEntityField;

    private AccountingCustomerPartyPartyContact contactField;

    /// <remarks/>
    public AccountingCustomerPartyPartyPartyName PartyName
    {
        get
        {
            return this.partyNameField;
        }
        set
        {
            this.partyNameField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPhysicalLocation PhysicalLocation
    {
        get
        {
            return this.physicalLocationField;
        }
        set
        {
            this.physicalLocationField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPartyTaxScheme PartyTaxScheme
    {
        get
        {
            return this.partyTaxSchemeField;
        }
        set
        {
            this.partyTaxSchemeField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPartyLegalEntity PartyLegalEntity
    {
        get
        {
            return this.partyLegalEntityField;
        }
        set
        {
            this.partyLegalEntityField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyContact Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPartyName
{

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPhysicalLocation
{

    private AccountingCustomerPartyPartyPhysicalLocationAddress addressField;

    /// <remarks/>
    public AccountingCustomerPartyPartyPhysicalLocationAddress Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPhysicalLocationAddress
{

    private ID idField;

    private string cityNameField;

    private string countrySubentityField;

    private byte countrySubentityCodeField;

    private AccountingCustomerPartyPartyPhysicalLocationAddressAddressLine addressLineField;

    private AccountingCustomerPartyPartyPhysicalLocationAddressCountry countryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string CountrySubentity
    {
        get
        {
            return this.countrySubentityField;
        }
        set
        {
            this.countrySubentityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte CountrySubentityCode
    {
        get
        {
            return this.countrySubentityCodeField;
        }
        set
        {
            this.countrySubentityCodeField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPhysicalLocationAddressAddressLine AddressLine
    {
        get
        {
            return this.addressLineField;
        }
        set
        {
            this.addressLineField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPhysicalLocationAddressCountry Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPhysicalLocationAddressAddressLine
{

    private string lineField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string Line
    {
        get
        {
            return this.lineField;
        }
        set
        {
            this.lineField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPhysicalLocationAddressCountry
{

    private IdentificationCode identificationCodeField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IdentificationCode IdentificationCode
    {
        get
        {
            return this.identificationCodeField;
        }
        set
        {
            this.identificationCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPartyTaxScheme
{

    private string registrationNameField;

    private CompanyID companyIDField;

    private TaxLevelCode taxLevelCodeField;

    private AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme taxSchemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string RegistrationName
    {
        get
        {
            return this.registrationNameField;
        }
        set
        {
            this.registrationNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyID CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxLevelCode TaxLevelCode
    {
        get
        {
            return this.taxLevelCodeField;
        }
        set
        {
            this.taxLevelCodeField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme
{

    private ID idField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPartyLegalEntity
{

    private string registrationNameField;

    private CompanyID companyIDField;

    private AccountingCustomerPartyPartyPartyLegalEntityCorporateRegistrationScheme corporateRegistrationSchemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string RegistrationName
    {
        get
        {
            return this.registrationNameField;
        }
        set
        {
            this.registrationNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyID CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    /// <remarks/>
    public AccountingCustomerPartyPartyPartyLegalEntityCorporateRegistrationScheme CorporateRegistrationScheme
    {
        get
        {
            return this.corporateRegistrationSchemeField;
        }
        set
        {
            this.corporateRegistrationSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyPartyLegalEntityCorporateRegistrationScheme
{

    private ID idField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class AccountingCustomerPartyPartyContact
{

    private string electronicMailField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string ElectronicMail
    {
        get
        {
            return this.electronicMailField;
        }
        set
        {
            this.electronicMailField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class PaymentMeans
{

    private ID idField;

    private string paymentMeansCodeField;

    private System.DateTime paymentDueDateField;

    private byte paymentIDField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string PaymentMeansCode
    {
        get
        {
            return this.paymentMeansCodeField;
        }
        set
        {
            this.paymentMeansCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
    public System.DateTime PaymentDueDate
    {
        get
        {
            return this.paymentDueDateField;
        }
        set
        {
            this.paymentDueDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte PaymentID
    {
        get
        {
            return this.paymentIDField;
        }
        set
        {
            this.paymentIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class PaymentTerms
{

    private byte referenceEventCodeField;

    private PaymentTermsSettlementPeriod settlementPeriodField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public byte ReferenceEventCode
    {
        get
        {
            return this.referenceEventCodeField;
        }
        set
        {
            this.referenceEventCodeField = value;
        }
    }

    /// <remarks/>
    public PaymentTermsSettlementPeriod SettlementPeriod
    {
        get
        {
            return this.settlementPeriodField;
        }
        set
        {
            this.settlementPeriodField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class PaymentTermsSettlementPeriod
{

    private DurationMeasure durationMeasureField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DurationMeasure DurationMeasure
    {
        get
        {
            return this.durationMeasureField;
        }
        set
        {
            this.durationMeasureField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class DurationMeasure
{

    private string unitCodeField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unitCode
    {
        get
        {
            return this.unitCodeField;
        }
        set
        {
            this.unitCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class TaxTotal
{

    private TaxAmount taxAmountField;

    private TaxTotalTaxSubtotal taxSubtotalField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxAmount TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    /// <remarks/>
    public TaxTotalTaxSubtotal TaxSubtotal
    {
        get
        {
            return this.taxSubtotalField;
        }
        set
        {
            this.taxSubtotalField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class TaxAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class TaxTotalTaxSubtotal
{

    private TaxableAmount taxableAmountField;

    private TaxAmount taxAmountField;

    private TaxTotalTaxSubtotalTaxCategory taxCategoryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxableAmount TaxableAmount
    {
        get
        {
            return this.taxableAmountField;
        }
        set
        {
            this.taxableAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxAmount TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    /// <remarks/>
    public TaxTotalTaxSubtotalTaxCategory TaxCategory
    {
        get
        {
            return this.taxCategoryField;
        }
        set
        {
            this.taxCategoryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class TaxableAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class TaxTotalTaxSubtotalTaxCategory
{

    private decimal percentField;

    private TaxTotalTaxSubtotalTaxCategoryTaxScheme taxSchemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public decimal Percent
    {
        get
        {
            return this.percentField;
        }
        set
        {
            this.percentField = value;
        }
    }

    /// <remarks/>
    public TaxTotalTaxSubtotalTaxCategoryTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class TaxTotalTaxSubtotalTaxCategoryTaxScheme
{

    private ID idField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class LegalMonetaryTotal
{

    private LineExtensionAmount lineExtensionAmountField;

    private TaxExclusiveAmount taxExclusiveAmountField;

    private TaxInclusiveAmount taxInclusiveAmountField;

    private AllowanceTotalAmount allowanceTotalAmountField;

    private ChargeTotalAmount chargeTotalAmountField;

    private PrepaidAmount prepaidAmountField;

    private PayableAmount payableAmountField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineExtensionAmount LineExtensionAmount
    {
        get
        {
            return this.lineExtensionAmountField;
        }
        set
        {
            this.lineExtensionAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxExclusiveAmount TaxExclusiveAmount
    {
        get
        {
            return this.taxExclusiveAmountField;
        }
        set
        {
            this.taxExclusiveAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxInclusiveAmount TaxInclusiveAmount
    {
        get
        {
            return this.taxInclusiveAmountField;
        }
        set
        {
            this.taxInclusiveAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AllowanceTotalAmount AllowanceTotalAmount
    {
        get
        {
            return this.allowanceTotalAmountField;
        }
        set
        {
            this.allowanceTotalAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ChargeTotalAmount ChargeTotalAmount
    {
        get
        {
            return this.chargeTotalAmountField;
        }
        set
        {
            this.chargeTotalAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrepaidAmount PrepaidAmount
    {
        get
        {
            return this.prepaidAmountField;
        }
        set
        {
            this.prepaidAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PayableAmount PayableAmount
    {
        get
        {
            return this.payableAmountField;
        }
        set
        {
            this.payableAmountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class LineExtensionAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class TaxExclusiveAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class TaxInclusiveAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class AllowanceTotalAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class ChargeTotalAmount
{

    private string currencyIDField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class PrepaidAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class PayableAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
public partial class InvoiceLine
{

    private ID idField;

    private InvoicedQuantity invoicedQuantityField;

    private LineExtensionAmount lineExtensionAmountField;

    private InvoiceLineTaxTotal taxTotalField;

    private InvoiceLineItem itemField;

    private InvoiceLinePrice priceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InvoicedQuantity InvoicedQuantity
    {
        get
        {
            return this.invoicedQuantityField;
        }
        set
        {
            this.invoicedQuantityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineExtensionAmount LineExtensionAmount
    {
        get
        {
            return this.lineExtensionAmountField;
        }
        set
        {
            this.lineExtensionAmountField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineTaxTotal TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItem Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }

    /// <remarks/>
    public InvoiceLinePrice Price
    {
        get
        {
            return this.priceField;
        }
        set
        {
            this.priceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class InvoicedQuantity
{

    private string unitCodeField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unitCode
    {
        get
        {
            return this.unitCodeField;
        }
        set
        {
            this.unitCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineTaxTotal
{

    private TaxAmount taxAmountField;

    private InvoiceLineTaxTotalTaxSubtotal taxSubtotalField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxAmount TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineTaxTotalTaxSubtotal TaxSubtotal
    {
        get
        {
            return this.taxSubtotalField;
        }
        set
        {
            this.taxSubtotalField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineTaxTotalTaxSubtotal
{

    private TaxableAmount taxableAmountField;

    private TaxAmount taxAmountField;

    private InvoiceLineTaxTotalTaxSubtotalTaxCategory taxCategoryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxableAmount TaxableAmount
    {
        get
        {
            return this.taxableAmountField;
        }
        set
        {
            this.taxableAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxAmount TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineTaxTotalTaxSubtotalTaxCategory TaxCategory
    {
        get
        {
            return this.taxCategoryField;
        }
        set
        {
            this.taxCategoryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineTaxTotalTaxSubtotalTaxCategory
{

    private decimal percentField;

    private InvoiceLineTaxTotalTaxSubtotalTaxCategoryTaxScheme taxSchemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public decimal Percent
    {
        get
        {
            return this.percentField;
        }
        set
        {
            this.percentField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineTaxTotalTaxSubtotalTaxCategoryTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineTaxTotalTaxSubtotalTaxCategoryTaxScheme
{

    private ID idField;

    private Name nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public Name Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineItem
{

    private string descriptionField;

    private InvoiceLineItemSellersItemIdentification sellersItemIdentificationField;

    private InvoiceLineItemStandardItemIdentification standardItemIdentificationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public string Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItemSellersItemIdentification SellersItemIdentification
    {
        get
        {
            return this.sellersItemIdentificationField;
        }
        set
        {
            this.sellersItemIdentificationField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItemStandardItemIdentification StandardItemIdentification
    {
        get
        {
            return this.standardItemIdentificationField;
        }
        set
        {
            this.standardItemIdentificationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineItemSellersItemIdentification
{

    private ID idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLineItemStandardItemIdentification
{

    private ID idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
public partial class InvoiceLinePrice
{

    private PriceAmount priceAmountField;

    private BaseQuantity baseQuantityField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriceAmount PriceAmount
    {
        get
        {
            return this.priceAmountField;
        }
        set
        {
            this.priceAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BaseQuantity BaseQuantity
    {
        get
        {
            return this.baseQuantityField;
        }
        set
        {
            this.baseQuantityField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class PriceAmount
{

    private string currencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
public partial class BaseQuantity
{

    private string unitCodeField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unitCode
    {
        get
        {
            return this.unitCodeField;
        }
        set
        {
            this.unitCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2", IsNullable = false)]
public partial class UBLExtensions
{

    private UBLExtensionsUBLExtension[] uBLExtensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UBLExtension")]
    public UBLExtensionsUBLExtension[] UBLExtension
    {
        get
        {
            return this.uBLExtensionField;
        }
        set
        {
            this.uBLExtensionField = value;
        }
    }
}


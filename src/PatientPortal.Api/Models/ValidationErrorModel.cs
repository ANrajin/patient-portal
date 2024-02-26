namespace PatientPortal.Api.Models
{
    public sealed record ValidationErrorModel(string Propertyname, string ValidationMessage);
}

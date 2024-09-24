using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using UberSystem.Domain.Entities;

namespace UberSystem.OData.Handlers;

public static class AppEdmModel
{
    public static IEdmModel GetModel()
    {
        var builder = new ODataConventionModelBuilder();

        var products = builder.EntitySet<Customer>("Customers");

        products.HasReadRestrictions()
            .HasPermissions(p =>
                p.HasSchemeName("Scheme").HasScopes(s => s.HasScope("Customers.Read")))
            .HasReadByKeyRestrictions(r => r.HasPermissions(p =>
                p.HasSchemeName("Scheme").HasScopes(s => s.HasScope("Customers.ReadByKey"))));

        products.HasInsertRestrictions()
            .HasPermissions(p => p.HasSchemeName("Scheme").HasScopes(s => s.HasScope("Customers.Create")));
        products.HasUpdateRestrictions()
            .HasPermissions(p => p.HasSchemeName("Scheme").HasScopes(s => s.HasScope("Customers.Update")));

        products.HasDeleteRestrictions()
            .HasPermissions(p => p.HasSchemeName("Scheme").HasScopes(s => s.HasScope("Customers.Delete")));

        return builder.GetEdmModel();
    }
}
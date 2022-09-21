using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class ProductMap : ClassMapping<Product>
    {   
        public ProductMap()
        {   
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Generator(Generators.Increment);
                x.Column("id");
                x.UnsavedValue(0);
            });
            Property(b => b.ProductName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("productname");
            });
            Property(b => b.ProductDescription, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("productdescription");
            });

            Property(b => b.Color, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("color");
            });
            Property(b => b.Price, x =>
            {

                x.Type(NHibernateUtil.Double);

                x.Column("price");
            });
            Property(b => b.CategoryId, x =>
            {
                
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("categoryid");
            });

            Property(b => b.Brand, x =>
            {
             
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("brand");
            });
            Property(b => b.IsOfferable, x =>
            {

                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
                x.Column("isofferable");
            });
            Property(b => b.IsSold, x =>
            {

                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
                x.Column("issold");
            });
            Property(b => b.ProductOwner, x =>
            {

                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("productowner");
            });
            Table("product");

        }
    }
}
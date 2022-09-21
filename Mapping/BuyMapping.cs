using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class BuyMap : ClassMapping<Buy>
    {   // Container tablosu map işlemleri
        public BuyMap()
        {   // Primary key olduğu için property yerine id kullanıldı.
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);

            });

            Property(b => b.Price, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
                x.Column("price");
            });
            Property(b => b.ProductId, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("productid");
            });
            Property(b => b.ProductOwner, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("productowner");
            });
            Property(b => b.Customer, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("customer");
            });
           

            Table("buy");

        }
    }
}
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class OfferMap : ClassMapping<Offer>
    {
        public OfferMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Generator(Generators.Increment);
                x.Column("id");
                x.UnsavedValue(0);
            });
            
            Property(b => b.Price, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
                x.Column("price");
            });

            Property(b => b.ProductId, x =>
            {

                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("productid");
            });
            Property(b => b.IsAccept, x =>
            {

                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
                x.Column("isaccept");
            });
            Property(b => b.Customer, x =>
            {

                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("customer");
            });

            Table("offers");

        }
    }
}
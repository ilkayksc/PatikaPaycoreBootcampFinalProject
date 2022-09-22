using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class CategoryMap : ClassMapping<Category>
    {   // Category tablosu map işlemleri
        public CategoryMap()
        {   // Primary key olduğu için property yerine id kullanıldı.
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);

            });
            
            Property(b => b.CategoryName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("categoryname");
            });
            Property(b => b.CategoryDescription, x =>
            {
                x.Length(350);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("categorydescription");
            });

            Table("category");

        }
    }
}

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class ColorMap : ClassMapping<Color>
    {   // Container tablosu map işlemleri
        public ColorMap()
        {   // Primary key olduğu için property yerine id kullanıldı.
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);

            });

            Property(b => b.ColorName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("colorname");
            });
            Property(b => b.ColorCode, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("colorcode");
            });

            Table("color");

        }
    }
}
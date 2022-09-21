using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class AccountMap : ClassMapping<Account>
    {   // Container tablosu map işlemleri
        public AccountMap()
        {   // Primary key olduğu için property yerine id kullanıldı.
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Generator(Generators.Increment);
                x.Column("id");
                x.UnsavedValue(0);
                
                
            });
            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("name");
            });
            Property(b => b.Surname, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("surname");
            });

            Property(b => b.Email, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("email");
            });
            Property(b => b.DateOfBirth, x =>
            {
                
                x.Type(NHibernateUtil.DateTime);
               
                x.Column("dateofbirth");
            });
            Property(b => b.Password, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("password");
            });
            Property(b => b.PhoneNumber, x =>
            {
                x.Length(20);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("phonenumber");
            });
            Property(b => b.LastActivity, x =>
            {
              
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
                x.Column("lastactivity");
            });
            Table("account");

        }
    }
}
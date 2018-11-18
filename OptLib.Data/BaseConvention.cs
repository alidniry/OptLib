using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data
{
    public class BaseModelConfigurationConvention : Convention
    {
        public BaseModelConfigurationConvention()
        {
            //Properties()
            //    .Where(p => p.Name == p.DeclaringType.Name + "Id")
            //    .Configure(p => p.IsKey());
            Properties()
                .Where(p => p.Name == "Active")
                .Configure(p =>
                {
                    p.IsRequired();
                });
            Properties()
                .Where(p => p.Name == "Lock")
                .Configure(p =>
                {
                    p.IsRequired();
                });
            Properties()
                .Where(p => p.Name == "Visible")
                .Configure(p =>
                {
                    p.IsRequired();
                });
            Properties()
                .Where(p => p.Name == "Id")
                .Configure(p =>
                {
                    p.IsKey();
                    p.IsRequired();
                    p.HasColumnOrder(1);
                    p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                });
            Properties()
                .Where(p => p.Name == "Name")
                .Configure(p =>
                {
                    p.IsRequired();
                    p.HasColumnType("nvarchar");
                    p.HasColumnOrder(2);
                    p.HasMaxLength(50);
                });
            Properties()
                .Where(p => p.Name == "Description")
                .Configure(p =>
                {
                    p.HasColumnType("nvarchar");
                    p.HasMaxLength(255);
                });
            Properties()
                .Where(p => p.Name == "Value")
                .Configure(p =>
                {
                    p.IsRequired();
                    p.HasColumnOrder(3);
                });

            //Properties()
            //    .Where(p => p.Name == "Name")
            //    .Configure(p => p.HasColumnName("FullName"));

        }
    }

}

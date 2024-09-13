using Company.G01.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.DAL.Data.Configurations
{
    public class DepartmentConfig : IEntityTypeConfiguration<DepartmentRepo>
    {
        public void Configure(EntityTypeBuilder<DepartmentRepo> builder)
        {
            builder
                .Property(d => d.Id)
                .UseIdentityColumn(10, 10);

        }
    }
}

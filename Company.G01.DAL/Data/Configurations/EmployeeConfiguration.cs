﻿using Company.G01.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.DAL.Data.Configurations
{
    internal class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    { 
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
            .Property(e => e.Salary)
            .HasColumnType("decimal(18,2)");
        }
    }
}

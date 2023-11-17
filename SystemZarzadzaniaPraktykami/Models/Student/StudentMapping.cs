﻿using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Impl;

namespace SystemZarzadzaniaPraktykami.Models.Student
{
    public class StudentMapping : ClassMap<Student>
    {
        readonly String tablename = nameof(Student);

        public StudentMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.StudentNumber);
            Map(x => x.Name);
            Map(x => x.MiddleNames);
            Map(x => x.Surname);
            Map(x => x.BirthDate);
            Map(x => x.StudentStatus);

            Table(tablename);
        }
    }
}
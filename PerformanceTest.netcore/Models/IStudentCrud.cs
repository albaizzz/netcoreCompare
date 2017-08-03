using System;

namespace PerformanceTest.netcore.Models
{
    public interface IStudentCrud
    {
        void AddStudent(StudentMongo student);
    }
}
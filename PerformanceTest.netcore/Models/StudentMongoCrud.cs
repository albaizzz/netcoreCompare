using System;
using PerformanceTest.netcore.Models;
using Microsoft.Extensions.Options;

namespace PerformanceTest.netcore.Models
{
    public class StudentMongoCruds : IStudentCrud
    {
        private readonly DataAccessMongo _context = null;
        public StudentMongoCruds(IOptions<Settings> Setting)
        {
             _context = new DataAccessMongo(Setting);
        }
        public void AddStudent(StudentMongo student)
        {
             _context.Students.InsertOneAsync(student);
        }
        
    }
}
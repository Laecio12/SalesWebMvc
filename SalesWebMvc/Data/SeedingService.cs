using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() || 
                _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department department1 = new Department(1, "Computers");
            Department department2 = new Department(2, "Electronics");
            Department department3 = new Department(3, "Fashion");
            Department department4 = new Department(4, "Books");

            Seller seller1 = new Seller(1, "Bob Brown", "bob@gmail.com", 1000.00, new DateTime(1998, 4, 21), department1);
            Seller seller2 = new Seller(2, "Maria Green", "maria@gmail.com", 3500.00, new DateTime(1992, 9, 1), department2);
            Seller seller3 = new Seller(3, "Alex Grey", "alex@gmail.com", 2000.00, new DateTime(1994, 3, 26), department3);
            Seller seller4 = new Seller(4, "laecio", "laecio@gmail.com", 1500.00, new DateTime(1995, 6, 30), department4);

            SalesRecord record1 = new SalesRecord(1, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record2 = new SalesRecord(2, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller2);
            SalesRecord record3 = new SalesRecord(3, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller3);
            SalesRecord record4 = new SalesRecord(4, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller4);
            SalesRecord record5 = new SalesRecord(5, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record6 = new SalesRecord(6, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller3);
            SalesRecord record7 = new SalesRecord(7, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record8 = new SalesRecord(8, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller2);
            SalesRecord record9 = new SalesRecord(9, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record10 = new SalesRecord(10, new DateTime(2021, 11, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record11 = new SalesRecord(11, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller4);
            SalesRecord record12 = new SalesRecord(12, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller3);
            SalesRecord record13 = new SalesRecord(13, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record14 = new SalesRecord(14, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller2);
            SalesRecord record15 = new SalesRecord(15, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record16 = new SalesRecord(16, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record17 = new SalesRecord(17, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record18 = new SalesRecord(18, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller2);
            SalesRecord record19 = new SalesRecord(19, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record20 = new SalesRecord(20, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller3);
            SalesRecord record21 = new SalesRecord(21, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record22 = new SalesRecord(22, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record23 = new SalesRecord(23, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller2);
            SalesRecord record24 = new SalesRecord(24, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller3);
            SalesRecord record25 = new SalesRecord(25, new DateTime(2021, 10, 15), 2000.0, SalesStatus.Billed, seller1);

            _context.Department.AddRange(department1, department2, department3, department4);

            _context.Seller.AddRange(seller1, seller1, seller3, seller4);

            _context.SalesRecord.AddRange(record1, record2, record3, record4, record5, record6, record7,
                                        record8, record9, record10, record11, record12, record13, record14, record15, record16,
                                        record17, record18, record19, record20, record21, record22, record23, record24, record25
                                        );
            _context.SaveChanges();
        }
    }
}

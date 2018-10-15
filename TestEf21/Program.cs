using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestEf21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var canReadCount = context.Parents
                    .Include(p => p.Children)
                    .Count(p => CanRead(p));
                Console.WriteLine("Using CanRead method:" + canReadCount);
            }

            using (var context = new MyDbContext())
            {
                var canReadCount = context.Parents
                    .Include(p => p.Children)
                    .Where(GetCanReadExpression())
                    .Count();
                Console.WriteLine("Using CanRead expression: " + canReadCount);
            }

            using (var context = new MyDbContext())
            {
                var canReadCount = context.Parents
                    .Include(p => p.Children)
                    .Where(p => CanRead(p))
                    .ToList()
                    .Count;
                Console.WriteLine("Using CanRead method with ToList: " + canReadCount);
            }

            Console.ReadKey();
        }

        private static bool CanRead(ParentEntity entity)
        {
            return entity?.Children != null && entity.Children.Any(c => c.CanView);
        }

        private static Expression<Func<ParentEntity, bool>> GetCanReadExpression()
        {
            return p => p.Children.Any(c => c.CanView);
        }
    }
}

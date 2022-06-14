using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var percentRequired = Students.Count * (20 / 100);
            var studentGrades = Students.OrderByDescending(i => i.AverageGrade).Select(i => i.AverageGrade).ToList();

            if(averageGrade >= studentGrades[percentRequired - 1])
            {
                return 'A';
            }

            if (averageGrade >= studentGrades[(percentRequired * 2) - 1])
            {
                return 'B';
            }

            if (averageGrade >= studentGrades[(percentRequired * 3) - 1])
            {
                return 'C';
            }

            if (averageGrade >= studentGrades[(percentRequired * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }
    }
}

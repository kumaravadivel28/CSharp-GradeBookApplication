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

            var percentRequired = (int)Math.Ceiling(Students.Count * 0.2);
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

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
    }
}

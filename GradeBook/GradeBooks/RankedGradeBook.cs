using System;

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
            int studentsNumber = Students.Count;
            if (studentsNumber < 5)
                throw new InvalidOperationException();

            int betterStudents = 0;
            foreach (var S in Students)
                if (averageGrade < S.AverageGrade) betterStudents++;

            int result = (100 * betterStudents) / studentsNumber;

            if (result < 20) return 'A';
            if (result < 40) return 'B';
            if (result < 60) return 'C';
            if (result < 80) return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            int studentsNumber = Students.Count;
            if (studentsNumber < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }
    }
}


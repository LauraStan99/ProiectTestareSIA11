using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectTestare.PageObjects.Home.InputData;

namespace ProiectTestare.Tests.Shared
{
    public class ExercisesFactory
    {
        public static NewExcerciseBo ValidExercise()
        {
            return new NewExcerciseBo
            {
                ActivityName = "Yoga",
                Duration = "20",
                EnergyBurned = "75"
            };
        }

        public static NewExcerciseBo InvalidExercise()
        {
            return new NewExcerciseBo
            {
                ActivityName = "Yoga",
                Duration = "-20",
                EnergyBurned = "-75"
            };
        }
    }
}

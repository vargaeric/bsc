using System.Collections.Generic;
using System;

namespace PersonalAgenda
{
    internal class Agenda
    {
        public List<Activity> activites;
        public Agenda()
        {
            activites = new List<Activity>();
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < activites.Count; i++)
                output += activites[i].ToString();

            return output;
        }

        public void addActivity(Activity activity)
        {
            activites.Add(activity);
        }

        public void removeActivity(int activityId)
        {
            int activityToDeleteIndex = -1;

            for(int i = 0; i < activites.Count; i++)
                if (activites[i].Id == activityId)
                    activityToDeleteIndex = i;

            if (activityToDeleteIndex != - 1)
                activites.RemoveAt(activityToDeleteIndex);
        }
    }
}
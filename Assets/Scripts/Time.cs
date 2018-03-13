using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time {

    int hour;
    int min;

    public Time(int hour, int min)
    {
        if (hour >= 24 || min >= 60)
        {
            throw new System.Exception("Bad time format: " + hour + ":" + min);
        }
        this.hour = hour;
        this.min = min;
    }

    /*
     * IN: string in format "hour:min" 
     * RET: time in Time type
     */
    public static Time makeTime(string time)
    {
        string[] tmp = time.Split(':');
        Time result = new Time(int.Parse(tmp[0]), int.Parse(tmp[1]));
        return result;
    }

    /*
     * IN: time and amounth of minutes to add
     * RET: time increased by that amounth of minutes
     */
    public static Time addToTime(Time time, int plus)
    {
        if (time.min + plus < 60) return new Time(time.hour, time.min + plus);
        else
        {
            int newMins = (time.min + plus) % 60;
            int addHours = (time.min + plus) / 60;
            return new Time((time.hour + addHours) % 24, newMins);
        }
    }

    /*
     * IN: two times t1, t2
     * RET: new time with value t2 - t1
     * (t1 needs to be sooner than t2 for positive output)
     */
    public static Time differenceBetweenTimes(Time t1, Time t2)
    {
        return Time.addToTime(new Time(0, 0), differenceBetweenTimesMin(t1, t2));
    }

    /*
     * IN: two times t1, t2
     * RET: t2 - t1 in minutes 
     * (t1 needs to be sooner than t2 for positive output)
     */
    public static int differenceBetweenTimesMin(Time t1, Time t2)
    {
        return Time.TimeToMinutes(t2) - Time.TimeToMinutes(t1);
    }

    /*
     * IN: Time type object
     * RET: time in minutes
     */
    public static int TimeToMinutes(Time time)
    {
        return (time.hour * 60) + time.min;
    }

    override
    public string ToString()
    {
        return this.hour + ":" + this.min;
    }

}

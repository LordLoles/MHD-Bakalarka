public class Time {

    internal int hour;
    internal int min;

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
    public static Time addToTime(Time time, int plusMin)
    {
        if (time.min + plusMin < 60) return new Time(time.hour, time.min + plusMin);
        else
        {
            int newMins = (time.min + plusMin) % 60;
            int addHours = (time.min + plusMin) / 60;
            return new Time((time.hour + addHours) % 24, newMins);
        }
    }


    /*
     * IN: amounth of minutes to add
     * RET: this time increased by that amounth of minutes
     */
    public Time addToTime(int plus)
    {
        return addToTime(this, plus);
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


    public static int Compare(Time t1, Time t2)
    {
        return System.Math.Sign(differenceBetweenTimesMin(t2, t1));
    }


    public int CompareTo(Time t2)
    {
        return Compare(this, t2);
    }


    public bool isThis(Time time)
    {
        return differenceBetweenTimesMin(this, time) == 0;
    }


    public bool isBetween(Time fromTime, Time endTime)
    {
        return (!(CompareTo(fromTime) == -1)) && (CompareTo(endTime) == -1);
    }


    override
    public string ToString()
    {
        return this.hour.ToString("00") + ":" + this.min.ToString("00");
    }

}

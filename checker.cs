int RtcYear = 26;
int RtcHour = 0;
int RtcMinute = 0;
int RtcSecond = 0;
int RtcMonth = 2;
int RtcDay = 23;
int RtcDayOfWeek = 1;
int getDayOfWeek()
{
    int dayOfWeek = 0;
    int savedYear = 16;
    int[] savedDaysOfMonths = { 5, 1, 2, 5, 7, 3, 5, 1, 4, 6, 2, 4 };
    //the first day of 2016 was on friday
    int passedYears = RtcYear - savedYear;
    int dephasedDays = passedYears;
    int leapYears = 0;
    for (int i = savedYear + 1; i <= RtcYear; ++i)
    {
        if (i % 4 == 0)
            leapYears++;
    }
    dephasedDays += leapYears;
    if (RtcMonth < 3)
    {
        if (savedYear % 4 == 0)
            dephasedDays++;
        if (RtcYear % 4 == 0)
            dephasedDays--;
        if (RtcYear == savedYear)
        {
            dephasedDays = 0;
        }
    }
    dayOfWeek = savedDaysOfMonths[RtcMonth - 1] + dephasedDays;
    dayOfWeek += (RtcDay - 1);
    dayOfWeek = dayOfWeek % 7;
    if (dayOfWeek == 0)
        dayOfWeek = 7;
    return dayOfWeek;
}

bool isOraVara(int month, int day, int dayOfWeek)
{
    bool isOraVara = false;
    if (month > 3 && month < 10)
    {
        isOraVara = true;
    }
    else if (month == 3)
    {
        isOraVara = false;
        if (day > 24)
        {
            isOraVara = true;
            if (day + (7 - dayOfWeek) <= 31)
            {
                isOraVara = false;
            }
        }
    }
    else if (month == 10)
    {
        isOraVara = true;
        if (day > 24)
        {
            isOraVara = false;
            if (day + (7 - dayOfWeek) <= 31)
            {
                isOraVara = true;
            }
        }
    }
    return isOraVara;
}


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
DateTime day = DateTime.Now;

bool last = false;
for (int i = 0; i < 365*10; i++)
{
    RtcDay = day.Day;
    RtcMonth = day.Month;
    RtcYear = day.Year%100;
    int dayOfWeek = getDayOfWeek();
    bool isVara = isOraVara(RtcMonth, RtcDay, dayOfWeek);

    int newDayOfWeek = (int)day.DayOfWeek;
    if (newDayOfWeek == 0)
        newDayOfWeek = 7;

    if (newDayOfWeek != dayOfWeek)
    {
        Console.WriteLine("issue on " + day.ToString());
        Console.WriteLine($"{newDayOfWeek}   {dayOfWeek}");
    }

    if(last!=isVara)
    {
        Console.WriteLine("issueschimbare on " + day.ToString());
        Console.WriteLine($"{isVara}   {last}");
        last = isVara;
    }

    //Console.WriteLine(day.ToString("yyyy MM dd ") + dayOfWeek.ToString() + "    " + isVara.ToString());
    day = day.AddDays(1);
}

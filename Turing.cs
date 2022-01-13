\using System;

//Caleb Cooper
public class Turing
{
    //allows for creation of tape
    static public void tape(char[] t)
    {
        System.Console.WriteLine("|");
        foreach (char e in t) { System.Console.Write("| " + e + " "); }
        System.Console.WriteLine("|");
    }

    //tells the machince to go left or right or halt
    static public void print(int i, char[] t, int s, char m)
    {
        switch (m)
        {
            case 'R':
                i++;
                break;
            case 'L':
                i--;
                break;
            default:
                break;
        }
        int j = 0;
        tape(t);
        foreach (char e in t)
        {
            if (i == j) { System.Console.Write("| p "); }
            else { System.Console.Write("|   "); };
            j++;
        }
        System.Console.Write("|");
        System.Console.Write(" Sequence: " + s);
        System.Console.WriteLine();
    }

    //runs the tape in debug menu
    static public void runtape(char[] t)
    {
        int i = 0; int s = 0;
        foreach (char e in t)
        {
            if (i < 10) { System.Console.Write("| " + i++ + " "); }
            else { System.Console.Write("| " + i++); };
        }
        //inital state
        print(i = 0, t, s++, '0');
        q0(t, i, s);
        if (t[i] == '1') { t[i] = '^'; print(i++, t, s++, 'R'); };

        System.Console.WriteLine();
    }

    // intial state
    static public void q0(char[] t, int i, int s)
    {
        // check for blank keep going till reach 1 then change it to x and go right. if * go left and to state 6 as its the end.
        while (t[i] == '^') { print(i++, t, s++, 'R'); };
        if (t[i] == '1')
        {
            t[i] = 'x';
            print(i++, t, s++, 'R');
            q1(t, i, s);
        }
        else if (t[i] == '*')
        {
            print(i--, t, s++, 'L');
            q6(t, i, s);
        };
    }

    // state 1
   
    static public void q1(char[] t, int i, int s)
    {
        // leave all 1's and go right till * then keep * and move to right and state 2
        while (t[i] == '1') { print(i++, t, s++, 'R'); };
        if (t[i] == '*')
        {
            print(i++, t, s++, 'R');
            q2(t, i, s);
        };
    }
    //state 2
    static public void q2(char[] t, int i, int s)
    {
        // change 1 to y and go right to state 3 and if = leave as = and go left to state 5
        if (t[i] == '1')
        {
            t[i] = 'y';
            print(i++, t, s++, 'R');
            q3(t, i, s);
        }
        else if(t[i] == '=')
        {
            print(i--, t, s++, 'L');
            q5(t, i, s);
        };

    }
    //state 3
    static public void q3(char[] t, int i, int s)
    {
        // leave all the 1's and = and go right change ^ to 1 go left and go to state 4 
        while (t[i] == '1' || t[i] == '=') { print(i++, t, s++, 'R'); };
        if (t[i] == '^')
        {
            t[i] = '1';
            print(i--, t, s++, 'L');
            q4(t, i, s);
        };

    }
    // state 4
    static public void q4(char[] t, int i, int s)
    {
        // leave the 1's and = go left until y is reached then go right and leave y go back to state 2
        while (t[i] == '1' || t[i] == '=') { print(i--, t, s++, 'L'); };
        if (t[i] == 'y')
        {
            print(i++, t, s++, 'R');
            q2(t, i, s);
        };

    }

    //state 5
    static public void q5(char[] t, int i, int s)
    {
        //change all the y's to 1's
        while (t[i] == 'y')
        {
            t[i] = '1';
            print(i--, t, s++, 'L');
        };
        //keep all the * and 1's and go left 
        if (t[i] == '*') { print(i--, t, s++, 'L'); };
        while (t[i] == '1') { print(i--, t, s++, 'L'); };
        //if x is found go right leave x and go back to state 0
        if (t[i] == 'x')
        {
            print(i++, t, s++, 'R');
            q0(t, i, s);
        };
    }
    //state 6
    static public void q6(char[] t, int i, int s)
    {
        // change all the x's to 1's
        while (t[i] == 'x')
        {
            t[i] = '1';
            print(i--, t, s++, 'L');
        };
        // if it finds blank go to end state
        if (t[i] == '^')
        {
            print(i++, t, s++, 'R');
            q7(t, i, s);

        }
    }

    //end state
    static public void q7(char[] t, int i, int s)
    {
        System.Console.WriteLine("turning machine is terminated");
    }

    //Tests
    public static void Main()
    {
        char[] t1 = { '^', '1','1', '*', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '=', '^', '^','^', '^', '^', '^', '^', '^', '^', '^', '^','^', '^', '^', '^', '^', '^', '^', '^', '^', '^', '^' };
        char[] t2 = { '^','1', '*', '1','=', '^', '^', '^', '^' };
        char[] t3 = { '^', '1', '1', '1', '*', '1', '=', '^', '^', '^', '^' };
        char[] t4 = { '^', '1','*', '1', '1', '1', '=', '^', '^', '^', '^' };
        char[] t5 = { '^', '1', '1', '1', '1','1', '*', '1', '1', '1', '=', '^', '^', '^', '^', '^', '^', '^', '^', '^','^', '^', '^', '^', '^', '^', '^', '^', '^' };
        char[] t6 = { '^', '1', '*', '0', '=', '^', '^', '^', '^' };
       runtape(t1);
       //runtape(t2);
       //runtape(t3);
       //runtape(t4);
       //runtape(t5);
       //runtape(t6);
    }
}


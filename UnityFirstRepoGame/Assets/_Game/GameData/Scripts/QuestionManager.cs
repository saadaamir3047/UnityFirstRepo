using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    public GameManager gm;

    public BaseParent BP;
    //public int count = 0;
    public Text text;
    public float time = 0;
    public BallJump bj;

    public float w;
    public float x;
    public float y;
    public float z;
    public string decimalAns1;
    public string decimalAns2;
    public string decimalAns3;
    public string decimalAns4;
    public string decimalQuestion;

    public float ans;
    public int velocityToIncrease;

    public GameObject slider;
    public GameObject slider2;
    public GameObject Dice1;
    public GameObject Dice2;
    public GameObject Dice3;
    public GameObject Dice4;
    public GameObject Dice5;

    public string question;
    //Start is called before the first frame update
    void Start()
    {
        //add2number1to10();
        if (gm.all)
        {
            nextAns();
        }
        if (gm.multiply)
        {
            dividemultiply();
        }
        if (gm.equation)
        {
            equation();

        }
        if (gm.conversion)
        {
            conversion();
        }
        if (gm.plus)
        {
            additionsubs();
        }
        if (gm.addEasy)
        {
            add2number1to10();
            //DecToFraction();
        }
        if (gm.addMedium)
        {
            add2numbert20to100();
            //FractionToDec();
        }
        if (gm.addHard)
        {
            add2numbert100to1000();
        }
        if (gm.SubEasy)
        {
            subs2number1to10();
        }
        if (gm.SubHard)
        {
            subs2numbert1to100();
        }
        if (gm.mulEasy)
        {
            multiplcation2number2to10();
        }
        if (gm.mulHard)
        {
            multiplcation2number2to10and10to20();
        }
        if (gm.divEasy)
        {
            division2to50();
        }
        if (gm.divHard)
        {
            division2to100();
        }
        if (gm.kg)
        {
            kgconversion();
        }
        if (gm.meter)
        {
            mconversion();
        }
        if (gm.metersq)
        {
            m2conversion();
        }
        if (gm.centiMeter)
        {
            cm3conversion();
        }
        if (gm.miliLiters)
        {
            mlconversion();
        }
        if (gm.dbms)
        {
            dmas();
        }
        if (gm.roots)
        {
            roots();
        }
        if (gm.simpleEq)
        {
            simpleequation();
        }
        if (gm.DecimalToFraction)
        {
            DecToFraction();
        }
        if (gm.fractionToDecimal)
        {
            FractionToDec();
        }
        if (gm.DecimalOrFractionBoth)
        {
            DecimalFractionBoth();
        }
        if (gm.TwoDices)
        {
            DiceTwo();
        }
        if (gm.ThreeDices)
        {
            DiceThree();
        }
        if (gm.MixDices)
        {
            MixDices();
        }
    }
    private void Awake()
    {
        instance = this;

    }

    public float TimeToAnswer = 0;
    // Update is called once per frame
    void Update()
    {
        if (! bj.isDead)
        {
            slider.GetComponent<Slider>().value += Time.deltaTime;
            slider2.GetComponent<Slider>().value -= Time.deltaTime;
            TimeToAnswer += Time.deltaTime;
            if (slider.GetComponent<Slider>().value >= time)
            {
                GameOverPannelUI.ShowUI();
                gm.bj.isDead = true;
                //gm.gameover();
            }
            if(slider2.GetComponent<Slider>().value <= 0)
            {
                slider2.SetActive(false);
                bj.velocity = 17f;
            }
        }
    }
    public void add2number1to10()
    {
        int a;
        int b;
        int n;
        
       
        a = Random.Range(1, 11);
        b = Random.Range(1, 11);
        n = Random.Range(1, 5);

        question = a.ToString() + "+" + b.ToString();
        
        text.text = question;
        ans = a + b;
        
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans+ 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans+ 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;

        }
        

    }
    public void add2numbert20to100()
    {
        int a;
        int b;
        int n;
        a = Random.Range(20, 101);
        b = Random.Range(20, 101);
        n = Random.Range(1, 5);
        question = a.ToString() + "+" + b.ToString();

        text.text = question;

        ans = a + b;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 11;
                y = ans - 11;
                z = ans + 21;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 11;
                y = ans - 11;
                z = ans + 21;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 11;
                w = ans - 11;
                z = ans + 21;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 11;
                y = ans - 11;
                w = ans + 21;
                break;

        }
    }
    public void add2numbert100to1000()
    {
        int a;
        int b;
        int n;
        a = Random.Range(100, 1001);
        b = Random.Range(100, 1001);
        n = Random.Range(1, 5);
        
        question = a.ToString() + "+" + b.ToString();

        text.text = question;

        ans = a + b;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 201;
                y = ans - 202;
                z = ans + 503;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 201;
                y = ans - 202;
                z = ans + 503;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 201;
                w = ans - 202;
                z = ans + 503;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 201;
                y = ans - 202;
                w = ans + 503;
                break;

        }
    }
    public void multiplcation2number2to10()
    {
        int a;
        int b;
        int n;
        a = Random.Range(2, 11);
        b = Random.Range(2, 11);
        n = Random.Range(1, 5);

        question = a.ToString() + "*" + b.ToString();

        text.text = question;

        ans = a * b;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans * 2;
                y = ans / 2;
                z = ans + 50;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans * 2;
                y = ans / 2;
                z = ans + 50;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans * 2;
                w = ans / 2;
                z = ans + 50;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans * 2;
                y = ans / 2;
                w = ans + 50;
                break;

        }
    }
    public void multiplcation2number2to10and10to20()
    {
        int a;
        int b;
        int n;
        a = Random.Range(2, 11);
        b = Random.Range(1, 21);
        n = Random.Range(1, 5);

        question = a.ToString() + "*" + b.ToString();

        text.text = question;
        ans = a * b;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans * 2;
                y = ans / 2;
                z = ans + 50;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans * 2;
                y = ans / 2;
                z = ans + 50;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans * 2;
                w = ans / 2;
                z = ans + 50;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans * 2;
                y = ans / 2;
                w = ans + 50;
                break;

        }
    }
    public void subs2number1to10()
    {
        int a;
        int b;
        int n;
        a = Random.Range(1, 11);
        b = Random.Range(a, 11);
        n = Random.Range(1, 5);
        
        question = b.ToString() + "-" + a.ToString();

        text.text = question;
        ans = b - a;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 11;
                y = ans - 11;
                z = ans + 51;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 11;
                y = ans - 11;
                z = ans + 51;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 11;
                w = ans - 21;
                z = ans + 51;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 11;
                y = ans - 21;
                w = ans + 50;
                break;

        }
    }
    public void subs2numbert1to100()
    {
        int a;
        int b;
        int n;
        a = Random.Range(1, 101);
        b = Random.Range(a, 101);
        n = Random.Range(1, 5);

        question = b.ToString() + "-" + a.ToString();

        text.text = question;
        ans = b - a;

        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 11;
                y = ans - 21;
                z = ans + 50;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 11;
                y = ans - 21;
                z = ans + 50;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 11;
                w = ans - 21;
                z = ans + 50;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 11;
                y = ans - 21;
                w = ans + 50;
                break;

        }
    }
    public void division2to50()
    {
        int a;
        int b;
        int n;
        int count = 0;

        a = Random.Range(2, 51);
        b = Random.Range(a, 51);
        n = Random.Range(1, 5);

        while (b % a != 0)
        {
            a = Random.Range(2, 51);
            b = Random.Range(a, 51);
            count++;
            if (count >= 50)
            {
                a = Random.Range(1, 26);
                b=(a * 2);
                question = b.ToString() + "/" + "2";
                break;
            }
        }

        question = b.ToString() + "/" + a.ToString();

        text.text = question;

        ans = b / a;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;

        }

    }
    public void division2to100()
    {
        int a;
        int b;
        int n;
        int count = 0;
        a = Random.Range(2, 101);
        b = Random.Range(a, 101);
        n = Random.Range(1, 5);

        while (b % a != 0)
        {
            a = Random.Range(2, 101);
            b = Random.Range(a, 101);
            count++;
            if (count >= 50)
            {
                a = Random.Range(1, 51);
                b = (a * 2);
                question = b.ToString() + "/" + "2";
                break;
            }

        }

        question = b.ToString() + "/" + a.ToString();

        text.text = question;

        ans = b / a;
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;

        }
    }
    public void simpleequation()
    {
        print("AAAAA");
        int a;
        int b;
        int m;
        int n;
        
        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        n = Random.Range(1, 5);
        m = Random.Range(1, 5);

        
        switch (n)
        {
            case 1:
                question = a.ToString()  + " + " + " x " + " = " + b.ToString();
                ans = b - a;
                break;

            case 2:
                question = a.ToString() + " - " + " x " + " = " + b.ToString();
                ans = a + b;
                break;

            case 3:
                question =  " x " + " + " + a.ToString() + " = " + b.ToString();
                ans = b - a;
                break;

            case 4:
                question = " x " + " - " + a.ToString() + " = " + b.ToString();
                ans = b + a; 
                break;
        }
        text.text = question;

        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;

        }
    }
    public void kgconversion()
    {
        int a;
        int m;
        int n;

        a = Random.Range(1, 10);
        n = Random.Range(1, 5);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question =  a  + "Kg " + " to " + "gram?";
                ans = a * 1000;
                break;

            case 2:
                question = a*1000 + "g " + " to " + "Kg?";
                ans = a;
                break;

            case 3:
                question = a*1000 + "Kg " + " to " + "Tons?";
                ans = a;
                break;

            case 4:
                question = a + "Tons " + " to " + "Kg? ";
                ans = a * 1000;
                break;
        }
        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans * 10;
                w = ans * 100;
                z = ans / 10;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans * 10;
                y = ans * 100;
                w = ans / 10;
                break;

        }
    }
    public void mconversion()
    {
        int a;
        int m;
        int n;

        a = Random.Range(1, 10);
        n = Random.Range(1, 9);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question = a + "m " + " to " + "cm?";
                ans = a * 100;
                break;

            case 2:
                question = a * 100 + "cm " + " to " + "m?";
                ans = a;
                break;

            case 3:
                question = a*10 + "mm " + " to " + "cm?";
                ans = a;
                break;

            case 4:
                question = a + "cm " + " to " + "mm?";
                ans = a * 10;
                break;

            case 5:
                question = a + "dm " + " to " + "cm?";
                ans = a * 10;
                break;

            case 6:
                question = a*10 + "cm " + " to " + "dm?";
                ans = a;
                break;

            case 7:
                question = a + "km " + " to " + "m?";
                ans = a * 1000;
                break;

            case 8:
                question = a*1000 + "m " + " to " + "km? ";
                ans = a;
                break;
        }
        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans * 100;
                y = ans * 10;
                z = ans / 10;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans * 10;
                w = ans * 100;
                z = ans / 10;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans * 10;
                y = ans * 100;
                w = ans / 10;
                break;

        }
    }
    public void m2conversion()
    {
        int a;

        int n;
        int m;

        a = Random.Range(1, 10);
        n = Random.Range(1, 9);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question = a + "m² " + " to " + "cm²?";
                ans = a * 10000;
                break;

            case 2:
                question = a*10000 + "cm² " + " to " + "m²?";
                ans = a;
                break;

            case 3:
                question = a*100 + "mm² " + " to " + "cm?²";
                ans = a;
                break;

            case 4:
                question = a + "cm² " + " to " + "mm²? ";
                ans = a * 100;
                break;

            case 5:
                question = a + "dm² " + " to " + "cm²?";
                ans = a * 100;
                break;

            case 6:
                question = a*100 + "cm² " + " to " + "dm²?";
                ans = a;
                break;

            case 7:
                question = a + "km² " + " to " + "m²?";
                ans = a * 1000000;
                break;

            case 8:
                question = a*1000000 + "m² " + " to " + "km²? ";
                ans = a;
                break;
        }
        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans * 10;
                w = ans * 100;
                z = ans / 10;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans * 10;
                y = ans * 100;
                w = ans / 10;
                break;

        }
    }
    public void cm3conversion()
    {
        int a;
        int n;
        int m;

        a = Random.Range(1, 10);
        n = Random.Range(1, 3);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question = a + "cm³ " + " to " + "mm³?";
                ans = a * 1000;
                break;

            case 2:
                question = a*1000 + "mm³ " + " to " + "cm³?";
                ans = a;
                break;

        }
        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;

        }
    }
    public void mlconversion()
    {
        int a;
        int n;
        int m;

        a = Random.Range(1, 10);
        n = Random.Range(1, 5);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question = a*1000 + "ml " + " to " + "liter?";
                ans = a;
                break;

            case 2:
                question = a*10 + "dl " + " to " + "liter?";
                ans = a;
                break;

            case 3:
                question = a + "liter " + " to " + "ml?";
                ans = a * 1000;
                break;

            case 4:
                question = a + "liter " + " to " + "dl? ";
                ans = a * 10;
                break;
        }
        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans * 10;
                y = ans * 100;
                z = ans / 10;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans * 10;
                w = ans * 100;
                z = ans / 10;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans * 10;
                y = ans * 100;
                w = ans / 10;
                break;
        }
    }

    public void dmas()
    {
        int a;
        int b;
        int c;
        int n;
        int m;

        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        c = Random.Range(1, 10);
        n = Random.Range(1, 5);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question = a + " + " + b + " * " + c;
                ans = a + (b * c);
                break;

            case 2:
                question = a + " * " + b + " + " + c;
                ans = (a * b) + c;
                break;

            case 3:
                question = a + " - " + b + " * " + c;
                ans = a - (b * c);
                break;

            case 4:
                question = a + " * " + b + " - " + c;
                ans = (a * b) - c;
                break;
            case 5:
                question = a + " + " + b + "+" + c;
                ans = a + b + c;
                break;

            case 6:
                question = a + " - " + b + " - " + c;
                ans = a - b - c;
                break;

            case 7:
                question = a + " * " + b + "*" + c;
                ans = a * b * c;
                break;

            case 8:
                question = a + "²" + "+" + c;
                ans = (a * a) + c;
                break;
            case 9:
                question = a + "+" + c + "²";
                ans = a + (c * c);
                break;
            case 10:
                question = a + "²" + "*" + c;
                ans = (a * a) * c;
                break;
            case 11:
                question = a + "*" + c + "²";
                ans = a * (c * c);
                break;
            case 12:
                question = a + "²" + "-" + c;
                ans = (a * a) - c;
                break;
            case 13:
                question = a + "-" + c + "²";
                ans = a - (c * c);
                break;
        }

        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;
        }
    }
    public void roots()
    {
        int a;
        int m;
        int n;

        a = Random.Range(1, 11);
        n = Random.Range(1, 5);
        m = Random.Range(1, 5);


        switch (n)
        {
            case 1:
                question = "√" + a * a;
                ans = a;
                break;

            case 2:
                question = "³√" + a * a * a;
                ans = a;
                break;

            case 3:
                question = a + "³ ";
                ans = a * a * a;
                break;

            case 4:
                question = a + "² ";
                ans = a * a;
                break;
        }
        text.text = question;
        switch (m)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 2;
                y = ans - 2;
                z = ans + 5;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 2;
                w = ans - 2;
                z = ans + 5;
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                y = ans - 2;
                w = ans + 5;
                break;

        }
    }


    public void nextAns()
    {
        int count;
        
        count = Random.Range(1, 18);
        switch (count)
        {
            case 1:
                add2number1to10();
                break;
            case 2:
                add2numbert20to100();
                break;
            case 3:
                add2numbert100to1000();
                break;
            case 4:
                multiplcation2number2to10();
                break;
            case 5:
                multiplcation2number2to10and10to20();
                break;
            case 6:
                subs2number1to10();
                break;
            case 7:
                subs2numbert1to100();
                break;
            case 8:
                division2to50();
                break;
            case 9:
                division2to100();
                break;
            case 10:
                simpleequation();
                break;
            case 11:
                kgconversion();
                break;
            case 12:
                mconversion();
                break;
            case 13:
                m2conversion();
                break;
            case 14:
                cm3conversion();
                break;
            case 15:
                mlconversion();
                break;
            case 16:
                dmas();
                break;
            case 17:
                roots();
                count = 1;
                break;
            
        }
    }

    public void additionsubs()
    {
        int count;
        count = Random.Range(1, 6);
        switch (count)
        {
            case 1:
                add2number1to10();
                break;
            case 2:
                add2numbert20to100();
                break;
            case 3:
                add2numbert100to1000();
                break;
            case 4:
                subs2number1to10();
                break;
            case 5:
                subs2numbert1to100();
                break;
            
        }
    }
   
    public void dividemultiply()
    {
        int count;
        count = Random.Range(1, 5);
        switch (count)
        {
            case 1:
                division2to50();
                break;
            case 2:
                division2to100();
                break;
            case 3:
                multiplcation2number2to10();
                break;
            case 4:
                multiplcation2number2to10and10to20();
                break;
        }
    }
    public void conversion()
    {
        int count;
        count = Random.Range(1, 6);
        switch (count)
        {
            case 1:
                kgconversion();
                break;
            case 2:
                mconversion();
                break;
            case 3:
                m2conversion();
                break;
            case 4:
                cm3conversion();
                break;
            case 5:
                mlconversion();
                break;
        }
    }

    public void equation()
    {
        int count;
        count = Random.Range(1, 4);
        switch (count)
        {
            case 1:
                dmas();
                break;
            case 2:
                roots();
                count = 1;
                break;
            case 3:
                simpleequation();
                break;
        }
    }

    public void FractionToDec()
    {
        int a;
        int b;
        int n;
        int count = 0;

        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        n = Random.Range(1, 5);

        question = a.ToString() + "/" + b.ToString();

        text.text = question;

        ans = (float) a / b;
        ans = Mathf.Round(ans * 100f) / 100f;
        //ans = Mathf.Round(ans);
        //ans.ToString("F2");
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                x = ans + 0.2f;
                y = ans - 0.2f;
                z = ans + 0.5f;
                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                w = ans + 0.2f;
                y = ans - 0.2f;
                z = ans + 0.5f;
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                x = ans + 0.2f;
                w = ans - 0.2f;
                z = ans + 0.5f;
                break;
            case 4:
                print("case 4");
                z = ans;
                BP.setBoxz();
                x = ans + 0.2f;
                y = ans - 0.2f;
                w = ans + 0.5f;
                break;
        }
    }

    public void DecToFraction()
    {
        int a;
        int b;
        int n;
        int count = 0;

        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        n = Random.Range(1, 5);

        question = a.ToString() + "/" + b.ToString();

        float temp;
        temp = (float)a / b;
        temp = Mathf.Round(temp * 100f) / 100f;
        question = temp.ToString();
        
        text.text = question;
        Debug.Log("Question is :" + question);
        Debug.Log("Num 1: " + a + "Num 2: " + b);
        //ans = Mathf.Round(ans);
        //ans.ToString("F2");
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                decimalAns1 = a + "/" + b;
                decimalAns2 = a+2 + "/" + b;
                decimalAns3 = a + "/" + b+2;
                decimalAns4 = a+3 + "/" + b+1;
                BP.setBoxw();
                x = ans + 0.2f;
                
                y = ans - 0.2f;
                z = ans + 0.5f;
                break;
            case 2:
                print("case 2");

                x = ans;
                decimalAns2 = a + "/" + b;
                decimalAns1 = a+2 + "/" + b;
                decimalAns3 = a + "/" + b+3;
                decimalAns4 = a+1 + "/" + b;
                BP.setBoxx();
                w = ans + 0.2f;
                y = ans - 0.2f;
                z = ans + 0.5f;
                break;
            case 3:
                print("case 3");
                y = ans;
                decimalAns3 = a + "/" + b;
                decimalAns1 = a+1 + "/" + b+2;
                decimalAns2 = a + "/" + b+3;
                decimalAns4 = a+2 + "/" + b;
                BP.setBoxy();
                x = ans + 0.2f;
                w = ans - 0.2f;
                z = ans + 0.5f;
                break;
            case 4:
                decimalAns4 = a + "/" + b;
                decimalAns1 = a+3 + "/" + b+1;
                decimalAns2 = a+5 + "/" + b;
                decimalAns3 = a+1 + "/" + b+1;
                print("case 4");
                z = ans;
                BP.setBoxz();
                x = ans + 0.2f;
                y = ans - 0.2f;
                w = ans + 0.5f;
                break;
        }
    }

    public void DecimalFractionBoth()
    {
        int count;
        count = Random.Range(1, 3);
        switch (count)
        {
            case 1:
                FractionToDec();
                break;
            case 2:
                DecToFraction();
                break;
        }
    }

    public void MixDices()
    {
        int count;
        count = Random.Range(1, 3);
        switch (count)
        {
            case 1:
                DiceTwo();
                break;
            case 2:
                DiceThree();
                break;
        }
    }

    public void DiceTwo()
    {
        //Dice2.transform.parent.GetComponent<Text>().enabled = false;
        for (int f=0; f<6; f++)
        {
            Dice1.transform.GetChild(f).gameObject.SetActive(false);
            Dice2.transform.GetChild(f).gameObject.SetActive(false);
            Dice3.transform.GetChild(f).gameObject.SetActive(false);
            Dice4.transform.GetChild(f).gameObject.SetActive(false);
            Dice5.transform.GetChild(f).gameObject.SetActive(false);
        }
        int a;
        int b;
        int n;


        a = Random.Range(1, 7);
        b = Random.Range(1, 7);
        n = Random.Range(1, 5);

        question = a.ToString() + "+" + b.ToString();

        text.text = question;
        ans = a + b;
        switch (a)
        {
            case 1:
                Dice1.transform.GetChild(0).gameObject.SetActive(true);
            break;
            case 2:
                Dice1.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                Dice1.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                Dice1.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 5:
                Dice1.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 6:
                Dice1.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }

        switch (b)
        {
            case 1:
                Dice2.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                Dice2.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                Dice2.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                Dice2.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 5:
                Dice2.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 6:
                Dice2.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }
        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();
                
                do
                {
                    x = ans + 2;
                } while ((x < 1 && x > 12));
                
                do
                {
                    y = ans - 2;
                } while ((y < 1 && y > 12));

                do
                {
                    z = ans + 5;
                } while ((z < 1 && z > 12));

                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();
                
                do { w = ans + 2;  } while ((w < 1 && w > 12));

                do { y = ans - 2; } while ((y < 1 && y > 12));
                
                do { z = ans + 5; } while ((z < 1 && z > 12));
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                do { x = ans + 2; } while ((x < 1 && x > 12));
                
                do { w = ans - 2;  } while ((w < 1 && w > 12));
                
                do { z = ans + 5;  } while ((z < 1 && z > 12));
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                x = ans + 2;
                do { } while ((x < 1 && x > 12));

                y = ans - 2;
                do { } while ((y < 1 && y > 12));

                w = ans + 5;
                do { } while ((w < 1 && w > 12));

                break;
        }
        Dice2.transform.parent.GetComponent<Text>().enabled = false;
    }

    public void DiceThree()
    {
        
        for (int f = 0; f < 6; f++)
        {
            Dice1.transform.GetChild(f).gameObject.SetActive(false);
            Dice2.transform.GetChild(f).gameObject.SetActive(false);
            Dice3.transform.GetChild(f).gameObject.SetActive(false);
            Dice4.transform.GetChild(f).gameObject.SetActive(false);
            Dice5.transform.GetChild(f).gameObject.SetActive(false);
        }

        int a;
        int b;
        int c;
        int n;


        a = Random.Range(1, 7);
        b = Random.Range(1, 7);
        c = Random.Range(1, 7);
        n = Random.Range(1, 5);

        question = a.ToString() + "+" + b.ToString() + "+" + c.ToString();

        text.text = question;
        ans = a + b + c;

        switch (a)
        {
            case 1:
                Dice3.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                Dice3.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                Dice3.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                Dice3.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 5:
                Dice3.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 6:
                Dice3.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }

        switch (b)
        {
            case 1:
                Dice4.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                Dice4.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                Dice4.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                Dice4.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 5:
                Dice4.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 6:
                Dice4.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }

        switch (c)
        {
            case 1:
                Dice5.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                Dice5.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                Dice5.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                Dice5.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 5:
                Dice5.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 6:
                Dice5.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }

        switch (n)
        {
            case 1:
                print("case 1");
                w = ans;
                BP.setBoxw();

                do
                {
                    x = ans + 2;
                } while ((x < 1 && x > 18));

                do
                {
                    y = ans - 2;
                } while ((y < 1 && y > 18));

                do
                {
                    z = ans + 5;
                } while ((z < 1 && z > 18));

                break;
            case 2:
                print("case 2");

                x = ans;
                BP.setBoxx();

                do { w = ans + 2; } while ((w < 1 && w > 18));

                do { y = ans - 2; } while ((y < 1 && y > 18));

                do { z = ans + 5; } while ((z < 1 && z > 18));
                break;
            case 3:
                print("case 3");

                y = ans;
                BP.setBoxy();
                do { x = ans + 2; } while ((x < 1 && x > 18));

                do { w = ans - 2; } while ((w < 1 && w > 18));

                do { z = ans + 5; } while ((z < 1 && z > 18));
                break;
            case 4:
                print("case 4");

                z = ans;
                BP.setBoxz();
                
                do { x = ans + 2; } while ((x < 1 && x > 18));

                y = ans - 2;
                do { y = ans - 2; } while ((y < 1 && y > 18));

                w = ans + 5;
                do { w = ans + 5; } while ((w < 1 && w > 18));
                break;
        }
        Dice3.transform.parent.GetComponent<Text>().enabled = false;
    }


}

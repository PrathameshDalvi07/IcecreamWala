using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{ 
    public static int icecreamWalaScore = 0;
    public static int custumorScore = 0;

    public static int icecreamWalaChartScore = 0;
    public static int custumorChartScore = 0;

    private void Start()
    {
        icecreamWalaScore = 0;
        custumorScore = 0;

        icecreamWalaChartScore = 0;
        custumorChartScore = 0;
    }
}

namespace Task006;


public class Model{
    public string getResult(string data){
        string equation = GetEquation(data); 
        Console.WriteLine(equation);
        string result = GetCorrectionedEquation(equation);
        return result;
    }


    public string GetEquation(string equation){
        return equation.Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("+", " + ").Replace("=", " = ");
    }

    public string GetCorrectionedEquation(string equation){
        string [] arrayFromEquation = equation.Split(" ");
        string numberQ = arrayFromEquation[0];
        string numberW = arrayFromEquation[2];
        string numberE = arrayFromEquation[4];
        int sizeQ = arrayFromEquation[0].Length;
        int sizeW = arrayFromEquation[2].Length;
        int sizeE = arrayFromEquation[4].Length;
        int resultQ = 0;
        int resultW = 0;
        int resultE = 0;
        string result;
        int currentMultiplier = 1;
        int temp = 0;
        while(sizeE != 0){
            if (sizeQ != 0 && sizeW != 0){
                int [] numbers = getNumbers(numberQ[sizeQ-- - 1], numberW[sizeW-- - 1], numberE[sizeE-- - 1], temp);
                resultQ += numbers[0] * currentMultiplier;
                resultW += numbers[1] * currentMultiplier;
                resultE += numbers[2] * currentMultiplier;
                temp = numbers[3];
                currentMultiplier *= 10;
            }
            else if (sizeQ != 0){
                int [] numbers = getNumbers(numberQ[sizeQ-- - 1], '0', numberE[sizeE-- - 1], temp);
                resultQ += numbers[0] * currentMultiplier;
                resultE += numbers[2] * currentMultiplier;
                temp = numbers[3];
                currentMultiplier *= 10;
            }
            else if (sizeW  != 0){
                int [] numbers = getNumbers('0', numberW[sizeW-- - 1], numberE[sizeE-- - 1], temp);
                resultW += numbers[1] * currentMultiplier;
                resultE += numbers[2] * currentMultiplier;
                temp = numbers[3];
                currentMultiplier *= 10;
            }
            else{
                int [] numbers = getNumbers('0', '0', numberE[sizeE-- - 1], temp);
                resultE += numbers[2] * currentMultiplier;
                temp = numbers[3];
                currentMultiplier *= 10;
            }
        }
        result = $"{resultQ}+{resultW}={resultE}";
        return result;
    }


    public int[] getNumbers(char stringA, char stringB, char stringC, int additional){
        int numA = 0;
        int numB = 0;
        int numC = 0;
        int temp = 0;
        if($"{stringA}{stringB}{stringC}".Replace("?", "").Length == 0){
            numC = 1 + additional;
            numA = 1;
            numB = 0;
        }else if (stringA.ToString() == "?" && stringB.ToString() == "?"){
            numC = Convert.ToInt32(stringC.ToString());
            if(numC == 0) numA = 0;
            else numA = numC - additional;
            numB = 0;
        }else if (stringA.ToString() == "?" && stringC.ToString() == "?"){
            numB = Convert.ToInt32(stringB.ToString());
            numA = 0;
            numC = numB + additional;
        }else if (stringB.ToString() == "?" && stringC.ToString() == "?"){
            numA = Convert.ToInt32(stringA.ToString());
            numB = 0;
            numC = numA + additional;
        }else if (stringA.ToString() == "?"){
            numB = Convert.ToInt32(stringB.ToString());
            numC = Convert.ToInt32(stringC.ToString());
            if(numC < numB){
                temp = 1;
                numA = numC + 10 - numB - additional;
            }else numA = numC - numB - additional;
        }else if(stringB.ToString() == "?"){
            numA = Convert.ToInt32(stringA.ToString());
            numC = Convert.ToInt32(stringC.ToString());
            if(numC < numA){
                temp = 1;
                numB = numC + 10 - numA - additional;
            }else numB = numC - numA - additional;
        }else if(stringC.ToString() == "?"){
            numA = Convert.ToInt32(stringA.ToString());
            numB = Convert.ToInt32(stringB.ToString());
            numC = numA + numB + additional;
            if(numC > 9){
                numC -= 10;
                temp = 1;
            }
        }else{
            numA = Convert.ToInt32(stringA.ToString());
            numB = Convert.ToInt32(stringB.ToString());
            numC = Convert.ToInt32(stringC.ToString());
        }
        return new int[] {numA, numB, numC, temp};
    }
}
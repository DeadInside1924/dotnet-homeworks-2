.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser extends [System.Runtime]System.Object
{
    .method public static void ParseCalcArguments(
            string[] args,
            [out] float64& val1,
            [out] valuetype Hw2.CalculatorOperation& operation,
            [out] float64& val2)
    {
                    ldarg.0         // args
                    call bool Hw2.Parser::IsArgLengthSupported(string[])
                    brfalse.s IL_0001
                    
                    ldarg.0
                    ldc.i4.0
                    ldelem.ref      // args[0]
                    ldarg.1         // val1
                    call bool [System.Runtime]System.Double::TryParse(string, float64&)
                    brfalse.s IL_0001
                    
                    ldarg.0
                    ldc.i4.2
                    ldelem.ref      // args[2]
                    ldarg.3         // val2
                    call bool [System.Runtime]System.Double::TryParse(string, float64&)
                    brfalse.s IL_0001
                    
                    ldarg.2         // load operation as addr
                    ldarg.0
                    ldc.i4.1
                    ldelem.ref      // args[1]
                    call valuetype Hw2.CalculatorOperation Hw2.Parser::ParseOperation(string)
                    stind.i4         // operation = ParseOperation(args[1]);
                    
                    ret
        
        IL_0001:    newobj instance void [System.Runtime]System.ArgumentException::.ctor()
                    throw
    }

    .method private static bool IsArgLengthSupported (string[] args) cil managed
    {
                    ldarg.0         
                    ldlen           // args.Length
                    ldc.i4.3        // 3
                    ceq             // ==
                    ret
    }
    
    .method private static valuetype Hw2.CalculatorOperation ParseOperation(string arg)
    {
                    ldarg.0
                    ldstr       "+"
                    call bool [System.Runtime]System.String::op_Equality(string, string)
                    brtrue.s    CASE_PLUS     
                    
                    ldarg.0
                    ldstr       "-"
                    call bool [System.Runtime]System.String::op_Equality(string, string)
                    brtrue.s    CASE_MINUS     
                    
                    ldarg.0
                    ldstr       "*"
                    call bool [System.Runtime]System.String::op_Equality(string, string)
                    brtrue.s    CASE_MULTIPLY     
                    
                    ldarg.0
                    ldstr       "/"
                    call bool [System.Runtime]System.String::op_Equality(string, string)
                    brtrue.s    CASE_DIVIDE     
                    
                    br.s        CASE_UNKNOWN     
                    
      CASE_PLUS:  ldc.i4.0
                    ret
                    
      CASE_MINUS: ldc.i4.1
                    ret
                    
      CASE_MULTIPLY:ldc.i4.2
                    ret
                    
      CASE_DIVIDE:  ldc.i4.3
                    ret
                    
      CASE_UNKNOWN: newobj instance void [System.Runtime]System.InvalidOperationException::.ctor()
                    throw
    }
}
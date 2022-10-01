.class public abstract sealed auto ansi beforefieldinit
  Hw2.Calculator extends System.Object
{

    .method public static float64 Calculate (
            float64 value1, 
            valuetype Hw2.CalculatorOperation  operation, 
            float64 value2) cil managed
    {
                    ldarg.0
                    ldarg.2                 // push val1 and val2 to stack
    
                    Plus:
                    ldarg.1
                    ldc.i4.0
                    beq.s       IL_0001    
                    
                    Minus:
                    ldarg.1
                    ldc.i4.1
                    beq.s       IL_0002     
                    
                    Multiply:
                    ldarg.1
                    ldc.i4.2
                    beq.s      IL_0003     
                    
                    Divide:
                    ldarg.1
                    ldc.i4.3
                    beq.s       IL_0004     
                    
                    Unknown:
                    br.s        IL_0005     
        
        IL_0001:    add
                    ret
        
        IL_0002:    sub
                    ret
                    
        IL_0003:    mul
                    ret
                    
        IL_0004:    div
                    ret
                    
        IL_0005:    newobj instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor()
                    throw
                    
    }
    
}
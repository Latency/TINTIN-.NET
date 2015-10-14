// *****************************************************************************
// File:      DynamicProxyConsumer.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace TinTin {
  internal class DynamicProxyGenerator {
    public Type CreateProxy(Type serviceInterface, Type baseType) {
      var fqn = "DYNA" + Guid.NewGuid().ToString().Replace("-", "");

      // Create assembly

      var assemblyName = new AssemblyName(fqn);

      var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

      // Create module

      var moduleBuilder = assemblyBuilder.DefineDynamicModule(fqn, false);

      // Create type

      var typeBuilder = moduleBuilder.DefineType(
                                                 fqn + ".Dynamic",
                                                 TypeAttributes.Public,
                                                 baseType);
      typeBuilder.AddInterfaceImplementation(serviceInterface);

      // Construct the proxy object

      var proxyField = typeBuilder.DefineField("proxy", serviceInterface, FieldAttributes.Private);

      // Create type constructor

      AddConstructor(typeBuilder, serviceInterface, proxyField, baseType);

      // Generate the code

      var memberId = 0;
      var invokeMethod = baseType.GetMethod("Invoke", BindingFlags.NonPublic | BindingFlags.Instance);
      var methods = new List<MethodInfo>();
      foreach (var info in serviceInterface.GetMethods()) {
        methods.Add(info);

        // Add the method contents

        AddMember(typeBuilder, info, memberId++, invokeMethod);
      }

      // Create the 'handleimpl' and 'getmethodname' methods

      AddHandleImplMethod(typeBuilder, methods, proxyField);
      AddGetMethodName(typeBuilder, methods);

      var t = typeBuilder.CreateType();
      return t;
    }

    private static void AddConstructor(TypeBuilder typeBuilder, Type serviceInterface, FieldInfo proxyField, Type baseType) {
      var constructorBuilder = typeBuilder.DefineConstructor(
                                                             MethodAttributes.Public | MethodAttributes.HideBySig |
                                                             MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
                                                             CallingConventions.HasThis,
                                                             new[] {
                                                               serviceInterface
                                                             });

      // Generate the constructor IL. 

      var gen = constructorBuilder.GetILGenerator();

      // The constructor calls the base constructor with the string[] parameter.

      gen.Emit(OpCodes.Ldarg_0);
      gen.Emit(OpCodes.Call, baseType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, Type.EmptyTypes, null));

      gen.Emit(OpCodes.Ldarg_0);
      gen.Emit(OpCodes.Ldarg_1);
      gen.Emit(OpCodes.Stfld, proxyField);

      gen.Emit(OpCodes.Ret);
    }

    private static void AddGetMethodName(TypeBuilder typeBuilder, IReadOnlyList<MethodInfo> methods) {
      var mb = typeBuilder.DefineMethod(
                                        "GetMethodName",
                                        MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                                        CallingConventions.HasThis,
                                        typeof (string),
                                        new[] {
                                          typeof (int)
                                        });

      var gen = mb.GetILGenerator();

      var retval = gen.DeclareLocal(typeof (string));

      // We implement the method handling as a jump table for maximum performance.

      var jumpTable = new Label[methods.Count];
      for (var i = 0; i < jumpTable.Length; ++i)
        jumpTable[i] = gen.DefineLabel();
      var endOfMethod = gen.DefineLabel();

      gen.Emit(OpCodes.Ldarg_1);
      gen.Emit(OpCodes.Switch, jumpTable);
      gen.Emit(OpCodes.Ldnull);
      gen.Emit(OpCodes.Stloc, retval);

      gen.Emit(OpCodes.Br, endOfMethod); // default = end-of-method

      for (var i = 0; i < jumpTable.Length; ++i) {
        gen.MarkLabel(jumpTable[i]);

        gen.Emit(OpCodes.Ldstr, methods[i].Name);
        gen.Emit(OpCodes.Stloc, retval);
        gen.Emit(OpCodes.Br, endOfMethod);
      }

      gen.MarkLabel(endOfMethod);
      gen.Emit(OpCodes.Ldloc, retval);
      gen.Emit(OpCodes.Ret);
    }

    private static void AddHandleImplMethod(TypeBuilder typeBuilder, IReadOnlyList<MethodInfo> methods, FieldInfo proxyField) {
      var mb = typeBuilder.DefineMethod(
                                        "HandleImpl",
                                        MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                                        CallingConventions.HasThis,
                                        typeof (void),
                                        new[] {
                                          typeof (int),
                                          typeof (object[])
                                        });

      var gen = mb.GetILGenerator();

      // We implement the method handling as a jump table for maximum performance.

      var jumpTable = new Label[methods.Count];
      for (var i = 0; i < jumpTable.Length; ++i)
        jumpTable[i] = gen.DefineLabel();
      var endOfMethod = gen.DefineLabel();

      gen.Emit(OpCodes.Ldarg_1);
      gen.Emit(OpCodes.Switch, jumpTable);
      gen.Emit(OpCodes.Br, endOfMethod); // default = end-of-method

      for (var i = 0; i < jumpTable.Length; ++i) {
        gen.MarkLabel(jumpTable[i]);

        // convert the arguments passed in argument 2 to a callable set of parameters

        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldfld, proxyField);
        var pars = methods[i].GetParameters();
        for (var j = 0; j < pars.Length; ++j) {
          gen.Emit(OpCodes.Ldarg_2);
          gen.Emit(OpCodes.Ldc_I4, j + 1);
          gen.Emit(OpCodes.Ldelem_Ref);
          gen.Emit(pars[j].ParameterType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, pars[j].ParameterType);
        }
        gen.Emit(OpCodes.Callvirt, methods[i]);
        gen.Emit(OpCodes.Br, endOfMethod);
      }

      gen.MarkLabel(endOfMethod);
      gen.Emit(OpCodes.Ret);
    }

    private static void AddMember(TypeBuilder typeBuilder, MethodInfo info, int memberId, MethodInfo invokeMethod) {
      // Generate the method

      var parameterTypes = info.GetParameters().Select(a => (a.ParameterType)).ToArray();
      var mb = typeBuilder.DefineMethod(
                                        info.Name,
                                        MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot |
                                        MethodAttributes.Virtual | MethodAttributes.Final, CallingConventions.HasThis,
                                        info.ReturnType,
                                        parameterTypes);

      if (info.ReturnType != typeof (void))
        throw new NotSupportedException("Thread barriers don't support non-void return types");

      // Generate the method variables

      var gen = mb.GetILGenerator();
      var pars = gen.DeclareLocal(typeof (object[]));

      // Generate the code

      //    object[] par = new object[] { 1, aap, haar, id }; 

      // where 1 is the method id


      gen.Emit(OpCodes.Ldarg_0);
      gen.Emit(OpCodes.Ldc_I4, parameterTypes.Length + 1);
      gen.Emit(OpCodes.Newarr, typeof (object));
      gen.Emit(OpCodes.Stloc, pars);
      gen.Emit(OpCodes.Ldloc, pars);
      gen.Emit(OpCodes.Ldc_I4_0);
      gen.Emit(OpCodes.Ldc_I4, memberId);
      gen.Emit(OpCodes.Box, typeof (int));
      gen.Emit(OpCodes.Stelem_Ref);
      for (var i = 0; i < parameterTypes.Length; ++i) {
        gen.Emit(OpCodes.Ldloc, pars);
        gen.Emit(OpCodes.Ldc_I4, i + 1);
        gen.Emit(OpCodes.Ldarg, i + 1);
        if (parameterTypes[i].IsValueType)
          gen.Emit(OpCodes.Box, parameterTypes[i]);
        gen.Emit(OpCodes.Stelem_Ref);
      }

      gen.Emit(OpCodes.Ldloc, pars);
      gen.Emit(OpCodes.Callvirt, invokeMethod);

      gen.Emit(OpCodes.Ret);
    }
  }
}